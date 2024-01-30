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
using static System.Net.Mime.MediaTypeNames;

namespace PIE_We
{
    public partial class FormImageClip : UIForm
    {
        public FormImageClip()
        {
            InitializeComponent();
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            if(uiTextBoxIn.Enabled == true)
            {
                PIE.CommonAlgo.DataPreImgClip_Exchange_Info info = new PIE.CommonAlgo.DataPreImgClip_Exchange_Info();
                //参数设置
                string featurePath = uiTextBoxYanMo.Text; //裁剪的几何要素
                info.InputFilePath = uiTextBoxIn.Text;  //待裁剪影像
                PIE.DataSource.IRasterDataset rDataset = PIE.DataSource.DatasetFactory.OpenRasterDataset(info.InputFilePath, PIE.DataSource.OpenMode.ReadOnly);
                if (rDataset == null) return;

                int count = rDataset.GetBandCount();
                List<int> list = new List<int> { };
                for (int i = 0; i < count; i++)
                {
                    list.Add(i);
                }
                info.listBands = list;
                info.bInvalidValue = true;//背景值设为NAN
                info.OutputFilePath = uiTextBoxOut.Text;  //裁剪保存结果
                info.ShpFilePath = featurePath;
                info.Type = 1;  // (等于1表示使用shape文件裁剪)
                info.FileType = "GTiff";  //Tiff数据的FileTypeCode为“GTiff”,IMG数据的FileTypeCode为"HFA",其他格式的为"ENVI"
                PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.ImageClipAlgo");
                if (algo == null) return;

                //2、算法执行
                PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
                algo.Name = "影像裁剪";
                algo.Params = info;
                PIE.SystemAlgo.AlgoFactory.Instance().AsynExecuteAlgo(algo);
                UIMessageBox.Show("掩膜裁剪成功！", "提示", UIStyle.LayuiGreen);
            }


            if(uiTextBoxIn2.Enabled == true)//如果输入的是批量操作
            {
                UIMessageBox.Show("批量操作的时间可能会较长请耐心等待！", "提示", UIStyle.LayuiGreen);
                string[] files = Directory.GetFiles(uiTextBoxIn2.Text, "*.tif");//获取文件夹下一级的所有tif影像文件绝对路径到files字符串组
                int fileNum = 0;//用于计数符合格式要求的文件个数
                foreach (string file in files)
                {
                    fileNum++;
                }
                for (int i = 0; i < fileNum; i++)
                {
                    PIE.CommonAlgo.DataPreImgClip_Exchange_Info info = new PIE.CommonAlgo.DataPreImgClip_Exchange_Info();
                    string featurePath = uiTextBoxYanMo.Text; //裁剪的几何要素
                    info.InputFilePath = files[i];  //待裁剪影像
                    PIE.DataSource.IRasterDataset rDataset = PIE.DataSource.DatasetFactory.OpenRasterDataset(info.InputFilePath, PIE.DataSource.OpenMode.ReadOnly);
                    if (rDataset == null) return;

                    int count = rDataset.GetBandCount();
                    List<int> list = new List<int> { };
                    for (int j = 0; j < count; j++)
                    {
                        list.Add(j);
                    }
                    info.listBands = list;
                    info.bInvalidValue = true;//背景值设为NAN
                    info.OutputFilePath = uiTextBoxOut.Text+ "\\" + Path.GetFileName(files[i]);  //裁剪保存结果
                    info.ShpFilePath = featurePath;
                    info.Type = 1;  // (等于1表示使用shape文件裁剪)
                    info.FileType = "GTiff";  //Tiff数据的FileTypeCode为“GTiff”,IMG数据的FileTypeCode为"HFA",其他格式的为"ENVI"
                    PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.ImageClipAlgo");
                    if (algo == null) return;

                    //2、算法执行
                    PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
                    algo.Name = "影像裁剪";
                    algo.Params = info;
                    PIE.SystemAlgo.AlgoFactory.Instance().AsynExecuteAlgo(algo);
                    //((IDisposable)info).Dispose();
                }
                UIMessageBox.Show("批量掩膜裁剪成功！", "提示", UIStyle.LayuiGreen);
            }
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择待裁剪影像";
            ofd.Filter = "TIFF File|*.tif;*.tiff";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxIn.Text = ofd.FileName;

            uiTextBoxIn2.Text = "";
            uiTextBoxIn.Enabled = true;
            uiTextBoxIn2.Enabled = false;
        }

        private void uiButtonYanMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择掩膜文件";
            ofd.Filter = "矢量文件|*.shp";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxYanMo.Text = ofd.FileName;
        }

        private void uiButtonOut_Click(object sender, EventArgs e)
        {
            if(uiTextBoxIn.Enabled == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "选择裁剪结果输出路径";
                sfd.Filter = "TIFF|*.tif;*.tiff";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() != DialogResult.OK) { return; }
                uiTextBoxOut.Text = sfd.FileName;
            }
            if(uiTextBoxIn2.Enabled == true)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择批量裁剪输出影像文件夹";
                //是否显示对话框左下角新建文件夹 按钮，默认为 true  
                dialog.ShowNewFolderButton = true;
                //按下确定选择的按钮  
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //记录选中的目录  
                    uiTextBoxOut.Text = dialog.SelectedPath;
                }
            }
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
            uiTextBoxIn.Text = "";
            uiTextBoxIn.Enabled = false;
        }
    }
}
