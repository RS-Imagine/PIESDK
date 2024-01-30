using PIE.DataSource;
using PIE.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.SystemAlgo;
using System.IO;

namespace PIE_We_Algo
{
    public class AlgoClassYearMean:BaseSystemAlgo
    {
        public override bool Execute()
        {
            //定义参数
            AlgoClassParams info = (AlgoClassParams)this.Params;

            IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(info.rdInFile, OpenMode.ReadOnly);
            //获取影像信息
            int xSize = rdIn.GetRasterXSize();
            int ySize = rdIn.GetRasterYSize();
            ISpatialReference sr = rdIn.SpatialReference;
            double[] geoTrans = rdIn.GetGeoTransform();

            //读取原始数据
            double[] data = new double[xSize * ySize];
            int[] bandMap = { 1 };
            rdIn.Read(0, 0, xSize, ySize, data, xSize, ySize, PixelDataType.Float64, 1, bandMap);

            //去除背景区域
            List<double> noBG = new List<double>();
            for (int i = 0; i < xSize * ySize; i++)
            {
                if (Math.Abs(data[i] - data[0]) > 0.000001)
                {
                    noBG.Add(data[i]);
                }
            }
            double[] stats = noBG.ToArray();

            //计算均值、标准差
            double mean = stats.Average(); //均值
            double stddev = 0; //标准差
            double tempSum = 0;
            for (int i = 0; i < stats.Length; i++)
            {
                tempSum += (stats[i] - mean) * (stats[i] - mean);
            }
            stddev = (double)Math.Sqrt(tempSum / (stats.Length));

            //分级
            UInt16[] result = new UInt16[xSize * ySize];
            int[] classNum = { 0, 0, 0, 0, 0 };
            double[] classPer = new double[5];
            double[] classMean = new double[5];
            double[] classSum = { 0, 0, 0, 0, 0 };
            for (int i = 0; i < xSize * ySize; i++)
            {
                if (Math.Abs(data[i] - data[0]) > 0.000001)
                {
                    if (data[i] < (mean - stddev)) //低
                    {
                        result[i] = 1;
                        classNum[0] += 1;
                        classSum[0] += data[i];
                    }
                    else if (data[i] < (mean - 0.5 * stddev)) //较低
                    {
                        result[i] = 2;
                        classNum[1] += 1;
                        classSum[1] += data[i];
                    }
                    else if (data[i] < (mean + 0.5 * stddev)) //中等
                    {
                        result[i] = 3;
                        classNum[2] += 1;
                        classSum[2] += data[i];
                    }
                    else if (data[i] < (mean + stddev)) //较高
                    {
                        result[i] = 4;
                        classNum[3] += 1;
                        classSum[3] += data[i];
                    }
                    else //高
                    {
                        result[i] = 5;
                        classNum[4] += 1;
                        classSum[4] += data[i];
                    }
                }
            }

            for(int i = 0; i < 5; i++)
            {
                classPer[i] = (double)classNum[i] / noBG.Count*1.0*100.0;
                classMean[i] = classSum[i] / classNum[i] * 1.0;
            }
            //分级结果写入数据集
            info.rdOut = DatasetFactory.CreateRasterDataset("", xSize, ySize, 1, PixelDataType.UInt16, "MEM", null);
            info.rdOut.SpatialReference = sr;
            info.rdOut.SetGeoTransform(geoTrans);
            info.rdOut.Write(0, 0, xSize, ySize, result, xSize, ySize, PixelDataType.UInt16, 1, bandMap);

            //保存数据表格文件
            string[] className = {"低","较低","中等","较高","高"};
            StreamWriter streamWriter = new StreamWriter(info.CSVfile, false, Encoding.UTF8);
            streamWriter.WriteLine("等级,像元个数,面积占比（%）,均值");
            for (int i = 0; i < 5; i++)
            {
                string strTemp = className[i] + "," + classNum[i] + "," + classPer[i] + "," + classMean[i];
                streamWriter.WriteLine(strTemp);
            }
            streamWriter.Close();

            for(int i = 0; i < 5; i++)
            {
                info.classNumOut[i] = classNum[i];
                info.classperOut[i] = classPer[i];
                info.classNameOut[i] = className[i];
                info.classMeanOut[i] = classMean[i];
            }
            return true;
        }
    }

    public class AlgoClassParams
    {
        //public int[,] mask;//影像的掩膜
        public string rdInFile;//待分级的影像

        public IRasterDataset rdOut;//分级的结果
        public string CSVfile;//CSV文件的输出路径

        /// <summary>
        /// 以下是影像分级后的统计数据输出，方便数据表的显示，分别是类名、类像元数、类百分占比、类均值
        /// </summary>
        public string[] classNameOut;
        public int[] classNumOut;
        public double[] classperOut;
        public double[] classMeanOut;
    }
}
