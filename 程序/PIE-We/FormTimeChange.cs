using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIE.DataSource;
using PIE.Geometry;
using PIE.SystemAlgo;
using PIE_We_Algo;
using Sunny.UI;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace PIE_We
{
    public partial class FormTimeChange : UIForm
    {
        public FormTimeChange()
        {
            InitializeComponent();
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
            dialog.Title = "CSV结果保存路径";
            dialog.AddExtension = true;
            dialog.Filter = "CSV|*.csv";
            if (dialog.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxOut.Text = dialog.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(uiTextBoxIn.Text, "*.tif");//获取文件夹下一级的所有tif影像文件绝对路径到files字符串组
            int fileNum = 0;//用于计数符合格式要求的文件个数
            foreach (string file in files)
            {
                fileNum++;
            }

            AlgoImageMeanParams info = new AlgoImageMeanParams();
            info.folder = uiTextBoxIn.Text;
            info.CSVfile = uiTextBoxOut.Text;
            info.imageMean = new double[fileNum];

            ISystemAlgo algo = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoImageMean");
            if (algo == null) { UIMessageBox.Show("ImageMean算法创建失败！", "提示", UIStyle.LayuiGreen); }
            algo.Params = info;
            AlgoFactory.Instance().ExecuteAlgo(algo);
            UIMessageBox.Show("每张影像的均值计算成功！", "提示", UIStyle.LayuiGreen);

            chart.ChartAreas[0].AxisY.Maximum = (int)info.imageMean[0] + 100;
            chart.ChartAreas[0].AxisY.Minimum = (int)info.imageMean[0] - 50;
            for (int i = 0; i < fileNum; i++)
            {
                chart.Series["NEP"].Points.AddXY(i+2000,(double)Math.Round(info.imageMean[i] * 100) / 100);
            }
            FileInfo outInfo = new FileInfo(this.uiTextBoxOut.Text);
            string pathOut = outInfo.Directory.FullName; //输出文件路径
            string pieOut = pathOut + @"\云南省年NEP均值变化.jpg"; //折线图图输出路径
            string fullFileName = pieOut;
            chart.SaveImage(fullFileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

            for(int i = 0; i < fileNum; i++)
            {
                int idx = this.uiDataGridViewStats.Rows.Add();

                this.uiDataGridViewStats.Rows[idx].Cells[0].Value = i+2000;
                this.uiDataGridViewStats.Rows[idx].Cells[1].Value = info.imageMean[i];
            }
            //this.Close();
        }
    }





}
