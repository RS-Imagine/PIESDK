using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIE.DataSource;
using PIE.Geometry;
using Sunny.UI;

namespace PIE_We
{
    public partial class FormBandMergeWater : UIForm
    {
        public FormBandMergeWater()
        {
            InitializeComponent();
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择待数据(波段)合成的多波段影像";
            //ofd.Multiselect = true;
            ofd.Filter = "TIFF|*.tif;*.tiff";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxIn.Text = ofd.FileName;
            uiTextBoxIn.Enabled = true;
            uiTextBoxOut.Enabled = true;
            uiTextBoxIn2.Text = "";
            uiTextBoxIn2.Enabled = false;
            uiTextBoxOut2.Text = "";
            uiTextBoxOut2.Enabled = false;
        }

        private void uiButtonOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择数据(波段)合成结果输出路径";
            sfd.Filter = "TIFF|*.tif;*.tiff";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxOut.Text = sfd.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            if (uiTextBoxIn.Enabled == true)
            {
                IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(uiTextBoxIn.Text, OpenMode.ReadOnly);
                //读取原始数据
                int xSize = rdIn.GetRasterXSize();
                int ySize = rdIn.GetRasterYSize();
                ISpatialReference sr = rdIn.SpatialReference;
                double[] geoTrans = rdIn.GetGeoTransform();
                int bandCount = rdIn.GetBandCount();

                double[] data = new double[xSize * ySize];
                IRasterBand rdInBand;
                double[] dataOut = new double[xSize * ySize];

                for (int i = 0; i < bandCount; i++)
                {
                    rdInBand = rdIn.GetRasterBand(i);
                    rdInBand.Read(0, 0, xSize, ySize, data, xSize, ySize, PixelDataType.Float64);
                    for (int j = 0; j < xSize * ySize; j++)
                    {
                        dataOut[j] += data[j];
                    }
                }

                IRasterDataset rdOut = DatasetFactory.CreateRasterDataset(uiTextBoxOut.Text, xSize, ySize, 1, PixelDataType.Float64, "GTIFF", null);
                rdOut.Write(0, 0, xSize, ySize, dataOut, xSize, ySize, PixelDataType.Float64, 1, new int[] { 1 });
                rdOut.SetGeoTransform(geoTrans);
                rdOut.SpatialReference = sr;
                ((IDisposable)rdOut).Dispose();

                UIMessageBox.Show("月降水数据成功合成至年数据！", "提示", UIStyle.LayuiGreen);
            }
            if (uiTextBoxIn2.Enabled == true)
            {
                UIMessageBox.Show("批量操作时间较长请耐心等待！", "提示", UIStyle.LayuiGreen);
                string[] files = Directory.GetFiles(uiTextBoxIn2.Text, "*.tif");//获取文件夹下一级的所有tif影像文件绝对路径到files字符串组
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
                int bandCount = rdIn.GetBandCount();
                for (int i = 0; i < fileNum; i++)
                {
                    (rdIn as IDisposable).Dispose();//释放前一个rdIn数据集
                    rdIn = DatasetFactory.OpenRasterDataset(files[i], OpenMode.ReadOnly);
                    double[] data = new double[xSize * ySize];
                    IRasterBand rdInBand;
                    double[] dataOut = new double[xSize * ySize];
                    for (int j = 0; j < bandCount; j++)
                    {
                        rdInBand = rdIn.GetRasterBand(j);
                        rdInBand.Read(0, 0, xSize, ySize, data, xSize, ySize, PixelDataType.Float64);
                        for (int h = 0; h < xSize * ySize; h++)
                        {
                            dataOut[h] += data[h];
                        }
                    }
                    IRasterDataset rdOut = DatasetFactory.CreateRasterDataset(uiTextBoxOut2.Text + "\\" + Path.GetFileName(files[i]), xSize, ySize, 1, PixelDataType.Float64, "GTIFF", null);
                    rdOut.Write(0, 0, xSize, ySize, dataOut, xSize, ySize, PixelDataType.Float64, 1, new int[] { 1 });
                    rdOut.SetGeoTransform(geoTrans);
                    rdOut.SpatialReference = sr;
                    ((IDisposable)rdOut).Dispose();
                }
                (rdIn as IDisposable).Dispose();//释放最后一个rdIn数据集
                UIMessageBox.Show("月降水数据成功批量合成至年数据！", "提示", UIStyle.LayuiGreen);
            }
            /*
            UIMessageBox.Show("波段运算时间较长(预计在两分钟左右)，请耐心等待直到运行结束......", "重要提示", UIStyle.LayuiGreen);
            //参数的设置
            PIE.CommonAlgo.BandOper_Exchange_Info info = new PIE.CommonAlgo.BandOper_Exchange_Info();
            info.StrExp = "b12+b11+b10+b9+b8+b7+b6+b5+b4+b3+b2+b1";
            info.SelectFileBands = new List<int> { 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            info.SelectFileNames = new List<string>
            {
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text,
                uiTextBoxIn.Text
            };//分别为band12--band1数据路径
            info.OutputFilePath = uiTextBoxOut.Text;
            info.FileTypeCode = "GTiff";

            PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.BandOperAlgo");
            if (algo == null) return;
            //2、算法执行
            PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
            algo.Name = "波段运算";
            algo.Params = info;

            //3、结果显示
            bool result = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo);
            if (result)
            {
                UIMessageBox.Show("波段运算（数据合成）成功", "提示", UIStyle.LayuiGreen);
            }
            else
            {
                UIMessageBox.ShowError("波段算法只执行失败！");
            }
            */
        }

        private void uiButtonIn2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择tif格式的影像文件夹";
            //是否显示对话框左下角新建文件夹 按钮，默认为 true  
            dialog.ShowNewFolderButton = false;
            //按下确定选择的按钮  
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录
                uiTextBoxIn2.Text = dialog.SelectedPath;
            }
            uiTextBoxIn2.Enabled = true;
            uiTextBoxOut2.Enabled = true;
            uiTextBoxIn.Text = "";
            uiTextBoxIn.Enabled = false;
            uiTextBoxOut.Text = "";
            uiTextBoxOut.Enabled = false;
        }

        private void uiButtonOut2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择合成数据输出影像文件夹";
            //是否显示对话框左下角新建文件夹 按钮，默认为 true  
            dialog.ShowNewFolderButton = true;
            //按下确定选择的按钮  
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                uiTextBoxOut2.Text = dialog.SelectedPath;
            }
        }
    }
}
