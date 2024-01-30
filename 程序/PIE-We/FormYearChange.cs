using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIE.AxControls;
using PIE.Carto;
using PIE.DataSource;
using PIE.Geometry;
using PIE.SystemAlgo;
using PIE_We_Algo;
using Sunny.UI;
using System.Web.Script.Serialization;
using System.IO;

namespace PIE_We
{
    public partial class FormYearChange : UIForm
    {
        MapControl m_mapControlMain;
        public FormYearChange(MapControl mapControl)
        {
            InitializeComponent();
            m_mapControlMain = mapControl;
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择tif格式的影像文件夹";
            //是否显示对话框左下角新建文件夹 按钮，默认为 true  
            dialog.ShowNewFolderButton = false;
            //按下确定选择的按钮  
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                uiTextBoxIn.Text = dialog.SelectedPath;
            }
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
            uiTextBoxClass.Text = dialog.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            //清空统计结果
            this.uiDataGridViewStats.Rows.Clear();
            #region 根据背景值创建掩膜
            /*
            string testPath = uiTextBoxIn.Text + "\\2003.tif";
            IRasterDataset rdtest = DatasetFactory.OpenRasterDataset(testPath, OpenMode.ReadOnly);
            int xsize = rdtest.GetRasterXSize();
            int ysize = rdtest.GetRasterYSize();
            AlgoMaskParams infoMask = new AlgoMaskParams();
            infoMask.rdIn = rdtest;
            infoMask.BGvalue = -0.220000;
            infoMask.outputMask = new int[ysize,xsize];

            ISystemAlgo algoMask = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoMask");
            if (algoMask == null) { UIMessageBox.Show("掩膜算法创建失败！", "提示", UIStyle.LayuiGreen); }
            algoMask.Params = infoMask;
            AlgoFactory.Instance().ExecuteAlgo(algoMask);
            UIMessageBox.Show("掩膜成功！", "提示", UIStyle.LayuiGreen);
            ((IDisposable)infoMask.rdIn).Dispose();
            ((IDisposable)rdtest).Dispose();
            */
            #endregion

            #region 计算十六年的均值影像
            AlgoYearMeanParams info = new AlgoYearMeanParams();
            info.folder = uiTextBoxIn.Text;
            //info.mask = infoMask.outputMask;

            ISystemAlgo algo = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoYearMean");
            if (algo == null) { UIMessageBox.Show("YearMean算法创建失败！", "提示", UIStyle.LayuiGreen); }
            algo.Params = info;
            AlgoFactory.Instance().ExecuteAlgo(algo);
            info.rdOut.Copy(uiTextBoxOut.Text);
            ((IDisposable)info.rdOut).Dispose();
            bool isLoad =  UIMessageBox.Show($"多年NEP影像的均值计算成功！{Environment.NewLine}是否需要将该影像加载到图层？", "提示", UIStyle.LayuiGreen,UIMessageBoxButtons.OKCancel,true,true);
            if (isLoad == true)
            {
                m_mapControlMain.AddLayerFromFile(uiTextBoxOut.Text, 0);
                m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
            }      
            //(info.rdOut as IDisposable).Dispose();
            #endregion

            #region 分级统计并输出到文件
            AlgoClassParams infoClass = new AlgoClassParams();
            //infoClass.mask = infoMask.outputMask;
            infoClass.rdInFile = uiTextBoxOut.Text;
            infoClass.CSVfile = (uiTextBoxOut.Text).Substring(0, (uiTextBoxOut.Text).LastIndexOf(@"\")) + @"\分级结果统计.csv";
            infoClass.classNameOut = new string[5];
            infoClass.classNumOut = new int[5];
            infoClass.classperOut = new double[5];
            infoClass.classMeanOut = new double[5];
            ISystemAlgo algoClass = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoClassYearMean");
            if (algo == null) { UIMessageBox.Show("分级统计算法创建失败！", "提示", UIStyle.LayuiGreen); }
            algoClass.Params = infoClass;
            AlgoFactory.Instance().ExecuteAlgo(algoClass);
            infoClass.rdOut.Copy(uiTextBoxClass.Text);
            ((IDisposable)infoClass.rdOut).Dispose();
            bool isLoad2 = UIMessageBox.Show($"分级统计成功！统计结果将会加载到数据表，请等待！{Environment.NewLine}是否需要将分级影像加载到图层？", "提示", UIStyle.LayuiGreen,UIMessageBoxButtons.OKCancel,true,true);
            if (isLoad2 == true)
            {
                m_mapControlMain.AddLayerFromFile(uiTextBoxClass.Text, 0);
                m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
            }
            #endregion

            #region 显示统计结果到DataGridView
            //添加行，写入数据
            int rows = 5;
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
            FileInfo fileInfo = new FileInfo(uiTextBoxClass.Text);
            string pieOut = fileInfo.Directory.FullName + @"\分级结果统计饼状图.jpg";
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
