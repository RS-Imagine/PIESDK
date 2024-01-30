using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.DataSource;
using PIE.SystemAlgo;
using PIE.Geometry;
using System.Data;

namespace PIE_We_Algo
{
    public class AlgoValueScaling : BaseSystemAlgo
    {
        public override bool Execute()
        {
            //获取算法参数
            AlgoValueScalingParams info = this.Params as AlgoValueScalingParams;

            //读取数据集
            int xSize = info.rdIn.GetRasterXSize();
            int ySize = info.rdIn.GetRasterYSize();
            ISpatialReference sr = info.rdIn.SpatialReference;
            double[] geoTrans = info.rdIn.GetGeoTransform();

            double[] dataIn = new double[xSize * ySize];//存储输入影像像元值的数组
            info.rdIn.Read(0, 0, xSize, ySize, dataIn, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });

            double[] dataOut = new double[xSize * ySize];//存储输出影像像元值的数组
            for (int i = 0; i < xSize * ySize; i++)
            {
                dataOut[i] = info.scaling * dataIn[i];
            }
            //缩放后数据的存储
            info.rdOut = DatasetFactory.CreateRasterDataset("", xSize, ySize, 1, PixelDataType.Float64, "MEM", null);
            info.rdOut.SetGeoTransform(geoTrans);
            info.rdOut.SpatialReference = sr;
            info.rdOut.Write(0, 0, xSize, ySize, dataOut, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });

            return true;
        }
    }
    public class AlgoValueScalingParams
    {
        public double scaling;
        public IRasterDataset rdIn;

        public IRasterDataset rdOut;
    }
}
