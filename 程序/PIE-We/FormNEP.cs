using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIE.DataSource;
using PIE.SystemAlgo;
using Sunny.UI;
using PIE_We_Algo;
using PIE.AxControls;

namespace PIE_We
{
    public partial class FormNEP : UIForm
    {
        MapControl m_mapControlMain;
        public FormNEP(MapControl mapControl)
        {
            InitializeComponent();
            m_mapControlMain = mapControl;
        }

        private void uiButtonTem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择年均温度影像";
            ofd.Filter = "TIFF File|*.tif;*.tiff";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxTem.Text = ofd.FileName;
        }

        private void uiButtonWat_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择年总降水量影像";
            ofd.Filter = "TIFF File|*.tif;*.tiff";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxWat.Text = ofd.FileName;
        }

        private void uiButtonNPP_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择年NPP影像";
            ofd.Filter = "TIFF File|*.tif;*.tiff";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxNPP.Text = ofd.FileName;
        }

        private void uiButtonNEP_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择年NEP影像的输出路径";
            sfd.Filter = "TIFF File|*.tif;*.tiff";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxNEP.Text = sfd.FileName;
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            AlgoNEPParams info = new AlgoNEPParams();
            IRasterDataset Tem = DatasetFactory.OpenRasterDataset(uiTextBoxTem.Text, OpenMode.ReadOnly);
            IRasterDataset Wat = DatasetFactory.OpenRasterDataset(uiTextBoxWat.Text, OpenMode.ReadOnly);
            IRasterDataset NPP = DatasetFactory.OpenRasterDataset(uiTextBoxNPP.Text, OpenMode.ReadOnly);
            info.rdTem = Tem;
            info.rdWat = Wat;
            info.rdNPP = NPP;

            ISystemAlgo algo = AlgoFactory.Instance().CreateAlgo("PIE-We-Algo.dll", "PIE_We_Algo.AlgoNEP");
            if (algo == null) { UIMessageBox.Show("NEP算法创建失败！", "提示", UIStyle.LayuiGreen); }
            algo.Params = info;
            AlgoFactory.Instance().ExecuteAlgo(algo);

            info.rdNEP.Copy(uiTextBoxNEP.Text);
            info.rdRh.Copy(uiTextBoxRh.Text);
            bool dialogResult = UIMessageBox.Show($"NEI定量计算成功！{System.Environment.NewLine}是否需要加载结果影像到图层？", "提示", UIStyle.LayuiGreen, UIMessageBoxButtons.OKCancel, true, true);
            if (dialogResult == true)
            {
                m_mapControlMain.AddLayerFromFile(uiTextBoxNEP.Text, 0);
                m_mapControlMain.PartialRefresh(PIE.Carto.ViewDrawPhaseType.ViewAll);
            }
            //this.Close();
            //释放内存
            (info.rdWat as IDisposable).Dispose();
            (info.rdTem as IDisposable).Dispose();
            (info.rdRh as IDisposable).Dispose();
            (info.rdNPP as IDisposable).Dispose();
            (Tem as IDisposable).Dispose();
            (Wat as IDisposable).Dispose();
            (NPP as IDisposable).Dispose();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择Rh影像的输出路径";
            sfd.Filter = "TIFF File|*.tif;*.tiff";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            uiTextBoxRh.Text = sfd.FileName;
        }
    }
}
