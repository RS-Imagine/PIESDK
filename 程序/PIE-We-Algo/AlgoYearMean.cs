using PIE.DataSource;
using PIE.Geometry;
using PIE.SystemAlgo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIE_We_Algo
{
    //算法类
    public class AlgoYearMean : BaseSystemAlgo
    {
        public override bool Execute()
        {
            //算法参数
            AlgoYearMeanParams info = this.Params as AlgoYearMeanParams;

            string[] files = Directory.GetFiles(info.folder, "*.tif");//获取文件夹下一级的所有tif影像文件绝对路径到files字符串组
            int fileNum = 0;//用于计数符合格式要求的文件个数
            foreach (string file in files)
            {
                fileNum++;
            }

            //先读取一个影像，获取像元数等原始信息
            IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(files[0], OpenMode.ReadOnly);
            int xSize = rdIn.GetRasterXSize();
            int ySize = rdIn.GetRasterYSize();
            double[] geoTrans = rdIn.GetGeoTransform();
            ISpatialReference sr = rdIn.SpatialReference;

            double[] dataMeans = new double[xSize * ySize];//用于存储NEP影像的最后像元的多年均值
            double[] dataAll = new double[xSize * ySize];//用与存储每个像元的年总和值
            for (int i = 0; i < fileNum; i++)
            {
                (rdIn as IDisposable).Dispose();//释放前一个rdIn数据集
                rdIn = DatasetFactory.OpenRasterDataset(files[i], OpenMode.ReadOnly);//读取第i个文件的影像
                double[] dataIn = new double[xSize * ySize];//存储当前影像像元值的数组
                rdIn.Read(0, 0, xSize, ySize, dataIn, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });

                for (int j = 0; j < xSize * ySize; j++)//读取每张影像的每个像元值
                {
                    dataAll[j] += dataIn[j];//将该影像的每个像元值与之前的相加
                }
            }
            (rdIn as IDisposable).Dispose();//释放最后一个rdIn数据集
            //NEP多年影像均值计算
            for (int i = 0; i < xSize * ySize; i++)
            {
                dataMeans[i] = dataAll[i] / fileNum;
            }
            //写入输出
            info.rdOut = DatasetFactory.CreateRasterDataset("", xSize, ySize, 1, PixelDataType.Float64, "MEM", null);
            info.rdOut.SpatialReference = sr;
            info.rdOut.SetGeoTransform(geoTrans);
            info.rdOut.Write(0, 0, xSize, ySize, dataMeans, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });
            return true;
        }
    }
    //参数类
    public class AlgoYearMeanParams
    {
        public string folder;//多年NEP影像文件夹路径
        public IRasterDataset rdOut;//输出多年的均值影像
        //public int[,] mask;
    }
}
