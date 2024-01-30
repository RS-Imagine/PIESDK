using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIE.AxControls;
using PIE.DataSource;
using PIE.SystemAlgo;
using PIE_We_Algo;
using Sunny.UI;
using static System.Net.Mime.MediaTypeNames;

namespace PIE_We
{
    public partial class FormValueScaling : UIForm
    {
        MapControl m_mapControlMain;
        public FormValueScaling(MapControl mapControl)
        {
            InitializeComponent();
            m_mapControlMain = mapControl;
        }

        private void uiTextBoxScale_MouseDown(object sender, MouseEventArgs e)
        {
            uiTextBoxScale.Text = "";
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            if(uiTextBoxIn.Enabled == true)
            {
                Regex reg = new Regex(@"^(-?\d+)(\.\d+)?$");//浮点数的正则表达式
                Match MAX = reg.Match(uiTextBoxScale.Text);
                if (MAX.Success)//如果输入的是数值
                {
                    AlgoValueScalingParams info = new AlgoValueScalingParams();
                    IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(uiTextBoxIn.Text, OpenMode.ReadOnly);
                    info.rdIn = rdIn;
                    info.scaling = Convert.ToDouble(uiTextBoxScale.Text);

                    ISystemAlgo algo = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoValueScaling");
                    if (algo == null) { UIMessageBox.Show("数值缩放算法创建失败！", "提示", UIStyle.LayuiGreen); }
                    algo.Params = info;
                    AlgoFactory.Instance().ExecuteAlgo(algo);
                    info.rdOut.Copy(uiTextBoxOut.Text);
                    bool dialogResult = UIMessageBox.Show($"数值缩放成功！{System.Environment.NewLine}是否需要加载结果影像到图层？", "提示", UIStyle.LayuiGreen, UIMessageBoxButtons.OKCancel, true, true);
                    if (dialogResult == true)
                    {
                        m_mapControlMain.AddLayerFromFile(uiTextBoxOut.Text, 0);
                        m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
                    }
                    (info.rdIn as IDisposable).Dispose();
                    (info.rdOut as IDisposable).Dispose();

                    //this.Close();
                }
                else//如果输入了非数字
                {
                    UIMessageBox.Show("请输入数值作为缩放倍数！", "提示", UIStyle.LayuiGreen);
                }
            }

            if(uiTextBoxIn2.Enabled == true)//批量输入
            {
                Regex reg2 = new Regex(@"^(-?\d+)(\.\d+)?$");//浮点数的正则表达式
                Match MAX2 = reg2.Match(uiTextBoxScale.Text);
                if (MAX2.Success)//如果输入的是数值
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
                        AlgoValueScalingParams info = new AlgoValueScalingParams();
                        IRasterDataset rdIn = DatasetFactory.OpenRasterDataset(files[i], OpenMode.ReadOnly);
                        info.rdIn = rdIn;
                        info.scaling = Convert.ToDouble(uiTextBoxScale.Text);

                        ISystemAlgo algo = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoValueScaling");
                        if (algo == null) { UIMessageBox.Show("数值缩放算法创建失败！", "提示", UIStyle.LayuiGreen); }
                        algo.Params = info;
                        AlgoFactory.Instance().ExecuteAlgo(algo);
                        info.rdOut.Copy(uiTextBoxOut.Text + "\\" + Path.GetFileName(files[i]));

                        (info.rdIn as IDisposable).Dispose();
                        (info.rdOut as IDisposable).Dispose();
                    }
                    UIMessageBox.Show("批量数值缩放成功！", "提示", UIStyle.LayuiGreen);

                }
                else//如果输入了非数字
                {
                    UIMessageBox.Show("请输入数值作为缩放倍数！", "提示", UIStyle.LayuiGreen);
                }
            }
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择待数值缩放的影像";
            ofd.Filter = "TIFF File|*.tif;*.tiff";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxIn.Text = ofd.FileName;

            uiTextBoxIn2.Text = "";
            uiTextBoxIn.Enabled = true;
            uiTextBoxIn2.Enabled = false;
        }

        private void uiButtonOut_Click(object sender, EventArgs e)
        {
            if (uiTextBoxIn.Enabled == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "选择缩放结果输出路径";
                sfd.Filter = "TIFF|*.tif;*.tiff";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() != DialogResult.OK) { return; }
                uiTextBoxOut.Text = sfd.FileName;
            }
            if (uiTextBoxIn2.Enabled == true)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择缩放输出影像文件夹";
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
