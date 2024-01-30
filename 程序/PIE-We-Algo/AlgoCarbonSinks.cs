using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using PIE.DataSource;
using PIE.Geometry;
using PIE.SystemAlgo;

namespace PIE_We_Algo
{
    public class AlgoCarbonSinks : BaseSystemAlgo
    {
        public override bool Execute()
        {
            AlgoCarbonSinksParams info = (AlgoCarbonSinksParams)Params;

            IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(info.rdInFile, OpenMode.ReadOnly);
            int xSize = rdIn.GetRasterXSize();
            int ySize = rdIn.GetRasterYSize();
            double[] geoTrans = rdIn.GetGeoTransform();
            ISpatialReference sr = rdIn.SpatialReference;
            //读取原始数据
            double[] data = new double[xSize * ySize];
            int[] bandMap = { 1 };
            rdIn.Read(0, 0, xSize, ySize, data, xSize, ySize, PixelDataType.Float64, 1, bandMap);

            //去除背景区域
            List<double> noBG = new List<double>();
            for (int i = 0; i < xSize * ySize; i++)
            {
                if (Math.Abs(data[i] - data[0]) > 0.000001)//浮点数的判断方式，这里我们默认第一个像元为背景像元
                {
                    noBG.Add(data[i]);
                }
            }

            //分级
            Int16[] result = new Int16[xSize * ySize];//注意此处的结果数组，将此数组写入数据集时注意其像元数据类型为Int16
            int[] classNum = { 0, 0, 0 };
            double[] classPer = new double[3];
            double[] classMean = new double[3];
            double[] classSum = { 0, 0, 0};
            for (int i = 0; i < xSize * ySize; i++)
            {
                if(Math.Abs(data[i] - data[0]) > 0.000001)
                {
                    if (data[i] < 0) 
                    {
                        result[i] = -1;
                        classNum[0] += 1;
                        classSum[0] += data[i];
                    }
                    else if ((data[i] - 0.000) <0.000001) 
                    {
                        result[i] = 0;
                        classNum[1] += 1;
                        classSum[1] += data[i];
                    }
                    else if (data[i] >0) 
                    {
                        result[i] = 1;
                        classNum[2] += 1;
                        classSum[2] += data[i];
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                classPer[i] = (double)classNum[i] / noBG.Count * 1.0 * 100.0;
                classMean[i] = classSum[i] / classNum[i] * 1.0;
            }


            //分级结果写入数据集
            info.rdOut = DatasetFactory.CreateRasterDataset("", xSize, ySize, 1, PixelDataType.Int16, "MEM", null);
            info.rdOut.SpatialReference = sr;
            info.rdOut.SetGeoTransform(geoTrans);
            info.rdOut.Write(0, 0, xSize, ySize, result, xSize, ySize, PixelDataType.Int16, 1, bandMap);

            //保存数据表格文件
            string[] className = { "碳源区", "平衡区", "碳汇区"};
            StreamWriter streamWriter = new StreamWriter(info.CSVfile, false, Encoding.UTF8);
            streamWriter.WriteLine("等级,像元个数,面积占比（%）,均值");
            for (int i = 0; i < 3; i++)
            {
                string strTemp = className[i] + "," + classNum[i] + "," + classPer[i] + "," + classMean[i];
                streamWriter.WriteLine(strTemp);
            }
            streamWriter.Close();

            for (int i = 0; i < 3; i++)
            {
                info.classNumOut[i] = classNum[i];
                info.classperOut[i] = classPer[i];
                info.classNameOut[i] = className[i];
                info.classMeanOut[i] = classMean[i];
            }
            return true;
        }
    }

    public class AlgoCarbonSinksParams
    {
        public string rdInFile;//输入多年均值的NEP影像文件路径
        
        public string CSVfile;//输出分级后统计结果CSV文件的输出路径

        public IRasterDataset rdOut;//分级结果栅格数据集

        /// <summary>
        /// 以下是影像分级后的统计数据输出，方便数据表的显示，分别是类名、类像元数、类百分占比、类均值
        /// </summary>
        public string[] classNameOut;
        public int[] classNumOut;
        public double[] classperOut;
        public double[] classMeanOut;
    }
}
