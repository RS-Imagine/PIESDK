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

    public partial class FormProjectionTransformation : UIForm
    {
        MapControl m_mapControlMain;
        public FormProjectionTransformation(MapControl mapControl)
        {
            InitializeComponent();
            m_mapControlMain = mapControl;
        }

        private void uiButtonIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择待投影转换的文件";
            ofd.Filter = "TIFF|*.tif;*.tiff";
            if (ofd.ShowDialog() != DialogResult.OK){ return; }
            uiTextBoxIn.Text = ofd.FileName;
        }

        private void uiButtonTo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择参考投影(目标投影)的文件";
            ofd.Filter = "TIFF|*.tif;*.tiff";
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxTo.Text = ofd.FileName;
        }

        private void uiButtonOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择投影转换结果输出路径";
            sfd.Filter = "TIFF|*.tif;*.tiff";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK){ return; }
            uiTextBoxOut.Text = sfd.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("请耐心等待！", "提示", UIStyle.LayuiGreen);
            IRasterDataset rasterDataSet = DatasetFactory.OpenRasterDataset(uiTextBoxTo.Text, OpenMode.ReadOnly);
            ISpatialReference spatialReference = rasterDataSet.SpatialReference;
            bool bOk = DataSourceUtil.Transform(uiTextBoxIn.Text, uiTextBoxOut.Text, spatialReference, 0, null, null, 500, 500);
            if (bOk)
            {
                UIMessageBox.Show("投影转换成功！","提示",UIStyle.LayuiGreen);
                m_mapControlMain.AddLayerFromFile(uiTextBoxOut.Text, 0);
                m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
            }
            else
            {
                UIMessageBox.ShowError("投影转换失败！");
            }
        }
    }
}
