using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.DataSource;
using PIE.SystemAlgo;
using PIE.Geometry;

namespace PIE_We_Algo
{
    public class AlgoRemoveOutliers: BaseSystemAlgo
    {
        public override bool Execute()
        {
            AlgoRemoveOutliersParams info = this.Params as AlgoRemoveOutliersParams;

            //1.读取输入数据
            IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(info.inputFile, OpenMode.ReadOnly);
            ISpatialReference sr = rdIn.SpatialReference;//空间参考
            double[] geoTrans = rdIn.GetGeoTransform();//仿射变换系数
            int xSize = rdIn.GetRasterXSize();//行
            int ySize = rdIn.GetRasterYSize();//列

            double[] dataR = new double[xSize * ySize];
            rdIn.Read(0, 0, xSize, ySize, dataR, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });
            for (int i = 0; i < xSize * ySize; i++)
            {
                if (info.Min > dataR[i] || dataR[i] > info.Max)
                {
                    dataR[i] = 0;
                }
            }

            //输出结果
            //写入输出数据集
            IRasterDataset rdOut = DatasetFactory.CreateRasterDataset(info.outputFile, xSize, ySize, 1, PixelDataType.Float64, "GTIFF", null);
            //写入数据
            rdOut.SpatialReference = sr;//设置空间参考
            rdOut.SetGeoTransform(geoTrans);//设置仿射变换系数
            rdOut.Write(0, 0, xSize, ySize, dataR, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });//写入dataR的数据

            (rdIn as IDisposable).Dispose();//释放该数据集，以便加载
            return true;
        }
    }

    public class AlgoRemoveOutliersParams
    {
        public string inputFile;//输入的影像
        public int Max;//上限值
        public int Min;//下限值

        public string outputFile;//输出的路径
    }
}
