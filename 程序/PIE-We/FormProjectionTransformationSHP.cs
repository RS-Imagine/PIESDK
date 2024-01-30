using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIE.AxControls;
using PIE.DataSource;
using PIE.Geometry;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIE_We
{
    public partial class FormProjectionTransformationSHP : UIForm
    {
        MapControl m_mapControlMain;
        public FormProjectionTransformationSHP(MapControl mapControl)
        {
            InitializeComponent();
            m_mapControlMain = mapControl;
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择待投影转换的文件";
            ofd.Filter = "矢量文件|*.shp";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxIn.Text = ofd.FileName;
        }

        private void uiButtonTo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择参考投影(目标投影)的文件";
            ofd.Filter = "矢量文件|*.shp";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxTo.Text = ofd.FileName;
        }

        private void uiButtonOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择投影转换结果输出路径";
            sfd.Filter = "矢量文件|*.shp";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxOut.Text = sfd.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            string pathSource = uiTextBoxIn.Text;
            string path1 = uiTextBoxTo.Text;
            IFeatureDataset featureDataSet = DatasetFactory.OpenFeatureDataset(path1);
            ISpatialReference spatialReference = featureDataSet.SpatialReference;
            string pathDes = uiTextBoxOut.Text;
            try
            {
                bool bOk = PIE.DataSource.DataSourceUtil.Transform(pathSource, pathDes, (ISpatialReference)spatialReference, 0, null, null, 500, 500);
                if (bOk)
                {
                    UIMessageBox.Show("投影转换成功！","提示",UIStyle.LayuiGreen);
                    m_mapControlMain.AddLayerFromFile(uiTextBoxOut.Text, 0);
                    m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "矢量投影转换异常");
            }
            this.Close();
            this.Dispose();
        }
    }
}
