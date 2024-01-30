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
    //NPP算法类
    public class AlgoNEP : BaseSystemAlgo
    {
        public override bool Execute()
        {
            //获取算法参数
            AlgoNEPParams info = this.Params as AlgoNEPParams;

            #region 年Rh数据影像的求取
            //𝑅ℎ = 0.22 × [𝑒_(0.0913𝑇) +ln(0.3145𝑅 +1) × 30 × 46.5 %]

            //读取年均温、年总降水量数据集
            int xSize = info.rdNPP.GetRasterXSize();
            int ySize = info.rdNPP.GetRasterYSize();
            ISpatialReference sr = info.rdNPP.SpatialReference;
            double[] geoTrans = info.rdNPP.GetGeoTransform();

            double[] dataTem = new double[xSize * ySize];//存储年均温影像像元值的数组
            double[] dataWat = new double[xSize * ySize];//存储年总降水量影像像元值的数组
            info.rdTem.Read(0, 0, xSize, ySize, dataTem, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });
            info.rdWat.Read(0, 0, xSize, ySize, dataWat, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });

            double[] dataRh = new double[xSize * ySize];//存储Rh影像像元值的数组
            //Rh的计算
            for(int i = 0; i < xSize * ySize; i++)
            {
                dataRh[i] = 0.22 * (Math.Exp(0.0913 * dataTem[i]) + Math.Log(0.3145 * dataWat[i] + 1) * 30 * 0.465);
            }
            //Rh数据的存储输出
            info.rdRh = DatasetFactory.CreateRasterDataset("", xSize, ySize, 1, PixelDataType.Float64, "MEM", null);
            info.rdRh.SetGeoTransform(geoTrans);
            info.rdRh.SpatialReference = sr;
            info.rdRh.Write(0, 0, xSize, ySize, dataRh, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });
            #endregion


            #region 年NEP数据集的求得
            //NEP = NPP - Rh
            double[] dataNPP = new double[xSize * ySize];//存储年NPP影像像元值的数组
            info.rdNPP.Read(0, 0, xSize, ySize, dataNPP, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });

            double[] dataNEP = new double[xSize * ySize];//存储年NEP影像像元值的数组
            //NEP的计算
            for (int i = 0; i < xSize * ySize; i++)
            {
                dataNEP[i] = dataNPP[i] - dataRh[i];
            }
            #endregion

            //NEP数据的存储输出
            info.rdNEP = DatasetFactory.CreateRasterDataset("", xSize, ySize, 1, PixelDataType.Float64, "MEM", null);
            info.rdNEP.SetGeoTransform(geoTrans);
            info.rdNEP.SpatialReference = sr;
            info.rdNEP.Write(0, 0, xSize, ySize, dataNEP, xSize, ySize, PixelDataType.Float64, 1, new int[1] { 1 });

            return true;
        }
    }

    //NPP算法的参数类
    public class AlgoNEPParams
    {
        public IRasterDataset rdTem;//年均温度数据集
        public IRasterDataset rdWat;//年总降水量数据集
        public IRasterDataset rdNPP;//年NPP数据集

        public IRasterDataset rdRh;//年Rh数据集
        public IRasterDataset rdNEP;//年NEI数据集
    }
}
