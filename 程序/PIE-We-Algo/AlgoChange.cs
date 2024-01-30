using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIE.DataSource;
using PIE.Geometry;
using PIE.SystemAlgo;

namespace PIE_We_Algo
{
    public class AlgoChange : BaseSystemAlgo
    {
        public override bool Execute()
        {
            AlgonChangeParams info = this.Params as AlgonChangeParams;
            string[] files = Directory.GetFiles(info.folder, "*.tif");//获取文件夹中tif影像，即多年NEP影像
            int filesNum = 0;//统计文件个数
            foreach (string file in files)
            {
                filesNum++;
            }
            //1.读取一张NEP输入数据,获取相关信息
            IRasterDataset rdNEP = DatasetFactory.OpenRasterDataset(files[0], OpenMode.ReadOnly);
            ISpatialReference sr = rdNEP.SpatialReference;//空间参考
            double[] geoTrans = rdNEP.GetGeoTransform();//仿射变换系数
            int xSizeNEP = rdNEP.GetRasterXSize();//行
            int ySizeNEP = rdNEP.GetRasterYSize();//列

            double[] dataNEP = new double[xSizeNEP * ySizeNEP];//用于存储每年的NEP
            double[] dataiNEPsum = new double[xSizeNEP * ySizeNEP];//用于存储总共filesNum年内每个像元多年NEP乘以对应序号的总和
            double[] dataNEPsum = new double[xSizeNEP * ySizeNEP];//用于存储filesNum年内每个像元多年NEP总和
            for (int i = 0; i < filesNum; i++)//循环每一张影像文件
            {
                IRasterDataset rdNEPtemp;
                rdNEPtemp = DatasetFactory.OpenRasterDataset(files[i], OpenMode.ReadOnly);//读取第i个文件
                rdNEPtemp.Read(0, 0, xSizeNEP, ySizeNEP, dataNEP, xSizeNEP, ySizeNEP, PixelDataType.Float64, 1, new int[1] { 1 });
                for (int j = 0; j < xSizeNEP * ySizeNEP; j++)//遍历每张影像的每个像元
                {
                    if (Math.Abs(dataNEP[j] - dataNEP[0]) > 0.000001)
                    {
                        dataNEPsum[j] += dataNEP[j];
                        dataiNEPsum[j] += (i + 1) * dataNEP[j];
                    }
                }
                (rdNEPtemp as IDisposable).Dispose();//释放前一个临时数据集
            }

            int XH_sum = 0;//存储年份序号和
            int XH_HPF = 0;//存储年份序号和的平方
            int XH_PFH = 0;//存储年份序号平方的和
            for(int i= 0; i < filesNum; i++)//对上面三个序号运算数组进行赋值
            {
                XH_sum += i + 1;
                XH_PFH += (i + 1) * (i + 1);
            }
            XH_HPF = XH_sum * XH_sum;

            //下面进行Slope的计算
            double[] dataSlope = new double[xSizeNEP * ySizeNEP];//用于存储多年NEP变化率
            for(int j = 0; j < xSizeNEP * ySizeNEP; j++)//像元的遍历
            {
                dataSlope[j] = (filesNum * dataiNEPsum[j] - XH_sum * dataNEPsum[j]) / (filesNum * XH_PFH - XH_HPF);
            }
            //写入输出
            info.rdSlope = DatasetFactory.CreateRasterDataset("", xSizeNEP, ySizeNEP, 1, PixelDataType.Float64, "MEM", null);
            info.rdSlope.SpatialReference = sr;
            info.rdSlope.SetGeoTransform(geoTrans);
            info.rdSlope.Write(0, 0, xSizeNEP, ySizeNEP, dataSlope, xSizeNEP, ySizeNEP, PixelDataType.Float64, 1, new int[1] { 1 });
            return true;
        }
    }

    public class AlgonChangeParams
    {
        public string folder;//多年NEP影像文件路径

        public IRasterDataset rdSlope;//输出Slope数据集
        public IRasterDataset rdLevel;//输出分级编号数据集
    }
}
