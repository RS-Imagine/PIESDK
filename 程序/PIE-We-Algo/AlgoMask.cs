using PIE.DataSource;
using PIE.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.SystemAlgo;

namespace PIE_We_Algo
{
    public class AlgoMask:BaseSystemAlgo
    {
        public override bool Execute()
        {
            //定义参数
            AlgoMaskParams info = (AlgoMaskParams)this.Params;

            //获取影像信息
            int xSize = info.rdIn.GetRasterXSize();
            int ySize = info.rdIn.GetRasterYSize();
            int bandCount = info.rdIn.GetBandCount();

            //读取原始数据
            int[] bandMap = new int[bandCount];
            for (int i = 0; i < bandCount; i++)
            {
                bandMap[i] = i + 1;
            }
            double[,,] data = new double[ySize, xSize, bandCount];

            info.rdIn.Read(0, 0, xSize, ySize, data, xSize, ySize, PixelDataType.Float64, bandCount, bandMap);

            //所有波段值均为info.BGvalue则视为背景区域
            double isZero = 0;
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {                    
                    for (int k = 0; k < bandCount; k++)
                    {
                        isZero += data[i, j, k];
                    }

                    //背景像元赋值为0，非背景像元赋值为1
                    if (isZero == info.BGvalue*bandCount)
                    {
                        info.outputMask[i, j] = 0;
                    }
                    else
                    {
                        info.outputMask[i, j] = 1;
                    }
                    isZero = 0;
                }
            }
            return true;
        }        
    }

    public class AlgoMaskParams
    {
        public IRasterDataset rdIn;
        public double BGvalue;

        public int[,] outputMask;
    }
}
