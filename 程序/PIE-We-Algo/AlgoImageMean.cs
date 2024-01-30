using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.SystemAlgo;
using PIE.Geometry;
using System.Data;
using System.IO;
using PIE.DataSource;

namespace PIE_We_Algo
{
    public class AlgoImageMean : BaseSystemAlgo
    {
        public override bool Execute()
        {
            //算法参数
            AlgoImageMeanParams info = this.Params as AlgoImageMeanParams;

            string[] files = Directory.GetFiles(info.folder, "*.tif");//获取文件夹下一级的所有tif影像文件绝对路径到files字符串组
            int fileNum = 0;//用于计数符合格式要求的文件个数
            foreach (string file in files)
            {
                fileNum++;
            }

            double[] dataMean = new double[fileNum];//用于存储每张影像的均值,共fileNum个数字
            for(int i = 0; i < fileNum; i++)
            {
                IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(files[i], OpenMode.ReadOnly);
                int xSize = rdIn.GetRasterXSize();
                int ySize = rdIn.GetRasterYSize();

                double[] dataIn = new double[xSize * ySize];//存储输入影像像元值的数组
                rdIn.Read(0, 0, xSize, ySize, dataIn, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });
                (rdIn as IDisposable).Dispose();

                double All = 0;
                int AllNum = 0;//统计除开背景值的像元数
                for (int j = 0; j < xSize * ySize; j++)//读取每张影像的每个像元值
                {
                    if (dataIn[j] - dataIn[0] > 0.000001)//排除背景值，NPP、温度和降水量都为零时，NEP计算得-0.22
                    {
                        All = dataIn[j] + All;//一张影像的NEP正确值像元值相加值赋给All
                        AllNum++;
                    }
                }
                dataMean[i]= All / AllNum;
            }

            //以下为Mean[]数组的输出，CSV文件
            FileStream fsCSV = System.IO.File.Create(info.CSVfile);
            StreamWriter streamWriter = new StreamWriter(fsCSV, Encoding.UTF8);
            streamWriter.WriteLine("年份,均值");
            for (int i = 0; i < fileNum; i++)
            {
                string steamtemp = System.IO.Path.GetFileNameWithoutExtension(files[i]) + "," + dataMean[i];
                streamWriter.WriteLine(steamtemp);
            }
            streamWriter.Close();
            fsCSV.Close();

            //输出年均值数值
            for(int i = 0; i < fileNum; i++)
            {
                info.imageMean[i] = dataMean[i];
            }
            return true;
        }


    }

    public class AlgoImageMeanParams
    {
        public string folder;//影像文件夹路径
        public string CSVfile;//输出CVS格式的统计文件

        public double[] imageMean;//输出每个影像的均值
    }
}
