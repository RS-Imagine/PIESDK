using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using PIE.AxControls;
using PIE.SystemAlgo;
using PIE_We_Algo;
using Sunny.UI;

namespace PIE_We
{
    public partial class FormCarbonSinks : UIForm
    {
        MapControl m_mapControlMain;
        public FormCarbonSinks(MapControl mapControl)
        {
            InitializeComponent();
            m_mapControlMain = mapControl;
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择待多年NEP均值影像";
            ofd.Filter = "TIFF File|*.tif;*.tiff";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxIn.Text = ofd.FileName;
        }

        private void uiButtonOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "结果影像保存路径";
            dialog.AddExtension = true;
            dialog.Filter = "TIF|*.tif;*tiff";
            if (dialog.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxOut.Text = dialog.FileName;
        }

        private void uiButtonClass_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "分级结果影像保存路径";
            dialog.AddExtension = true;
            dialog.Filter = "TIF|*.tif;*tiff";
            if (dialog.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxOut.Text = dialog.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            //清空统计结果
            this.uiDataGridViewStats.Rows.Clear();
            #region 分级统计并输出到文件
            AlgoCarbonSinksParams infoClass = new AlgoCarbonSinksParams();
            //infoClass.mask = infoMask.outputMask;
            infoClass.rdInFile = uiTextBoxIn.Text;
            infoClass.CSVfile = (uiTextBoxOut.Text).Substring(0, (uiTextBoxOut.Text).LastIndexOf(@"\")) + @"\碳源汇分级结果统计.csv";
            infoClass.classNameOut = new string[3];
            infoClass.classNumOut = new int[3];
            infoClass.classperOut = new double[3];
            infoClass.classMeanOut = new double[3];
            ISystemAlgo algoClass = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoCarbonSinks");
            if (algoClass == null) { UIMessageBox.Show("分级统计算法创建失败！", "提示", UIStyle.LayuiGreen); }
            algoClass.Params = infoClass;
            AlgoFactory.Instance().ExecuteAlgo(algoClass);
            infoClass.rdOut.Copy(uiTextBoxOut.Text);
            ((IDisposable)infoClass.rdOut).Dispose();
            bool diaResult = UIMessageBox.Show($"分级统计成功！统计结果将会加载到数据表，请等待！{System.Environment.NewLine}是否加载碳源汇分级结果影像到图层？", "提示", UIStyle.LayuiGreen, UIMessageBoxButtons.OKCancel, true, true);
            if (diaResult == true)
            {
                m_mapControlMain.AddLayerFromFile(uiTextBoxOut.Text, 0);
                m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
            }
            #endregion

            #region 显示统计结果到DataGridView
            //添加行，写入数据
            int rows = 3;
            for (int i = 0; i < rows; i++)
            {
                int idx = this.uiDataGridViewStats.Rows.Add();

                this.uiDataGridViewStats.Rows[idx].Cells[0].Value = infoClass.classNameOut[i];
                this.uiDataGridViewStats.Rows[idx].Cells[1].Value = infoClass.classNumOut[i].ToString("###,###");
                this.uiDataGridViewStats.Rows[idx].Cells[2].Value = infoClass.classperOut[i];
                uiDataGridViewStats.Rows[idx].Cells[3].Value = infoClass.classMeanOut[i];
            }
            #endregion

            #region 使用Python生成饼状图
            //调用python脚本,生成饼状图
            Process p = new Process(); //创建进程
            p.StartInfo.FileName = "PlotPie.exe"; //进程执行Python程序
            p.StartInfo.UseShellExecute = false; //直接从可执行程序创建进程
            p.StartInfo.RedirectStandardOutput = true; //需获取输出
            p.StartInfo.RedirectStandardInput = true; //需获取输入
            p.StartInfo.CreateNoWindow = true; //不创建窗口

            //参数设置
            string argData = new JavaScriptSerializer().Serialize(infoClass.classperOut.ToList()); //数据
            string argLegends = string.Empty; //图例
            for (int i = 0; i < infoClass.classNameOut.Length; i++)
            {
                argLegends += infoClass.classNameOut[i];
                if (i < infoClass.classNameOut.Length - 1)
                {
                    argLegends += ',';
                }
            }
            FileInfo fileInfo = new FileInfo(uiTextBoxOut.Text);
            string pieOut = fileInfo.Directory.FullName + @"\碳源汇分级结果统计饼状图.jpg";
            string pie = pieOut;
            p.StartInfo.Arguments = String.Format("\"{0}\" {1} {2}", pie, argData, argLegends); //设置传入Python程序的参数：路径、数据、图例
            p.Start(); //启动进程，生成饼状图
            string output = p.StandardOutput.ReadToEnd(); //获取Python程序返回值，无返回值则为空
            p.WaitForExit(); //等待进程结束
            p.Close(); //关闭进程

            this.pictureBoxStats.SizeMode = PictureBoxSizeMode.StretchImage; //图片显示方式设置为自动缩放
            this.pictureBoxStats.Load(pie); //显示图片
            #endregion
        }
    }
}
