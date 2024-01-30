using PIE.AxControls;
using PIE.Carto;
using PIE.Controls;
using PIE.SystemUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using PIE.Display;
using PIE.DataSource;
using PIE.Geometry;

namespace PIE_We
{
    public partial class FormMain : UIForm
    {
        #region 成员变量

        /// <summary>
        /// 地图控件
        /// </summary>
        private PIE.AxControls.MapControl m_MapControlMain;

        /// <summary>
        /// TOC控件
        /// </summary>
        private PIE.AxControls.TOCControl m_TocControlMain;

        /// <summary>
        ///制图控件
        /// </summary>
        private PIE.AxControls.PageLayoutControl m_PageLayoutControlMain;



        #endregion

        #region 构造函数
        public FormMain()
        {
            InitializeComponent();
            this.splitContainer1.SplitterWidth = 10; //手动解决UIForm初始化后分离条宽度大于10会导致的显示问题
            InitialFrm();

            //绑定TOC右键菜单Command
            DeleteToolStripMenuItem.Tag = new DeleteLayerCommand();
            ZoomtoToolStripMenuItem.Tag = new ZoomToLayerCommand();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化地图
        /// </summary>
        private void InitialFrm()
        {
            //1、地图控件MapControl
            m_MapControlMain = new MapControl();
            (m_MapControlMain as Control).Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(m_MapControlMain as Control);//将MapControl控件添加到右侧的splitContainer的Pannel2中
            this.tabPageMap.Controls.Add(m_MapControlMain as Control);//将MapControl控件添加到右侧的tabPageMap中

            //2、TocControl控件
            m_TocControlMain = new TOCControl();
            m_TocControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(m_TocControlMain);//将TocControl控件添加到左侧的splitContainer的Pannel1中
            this.m_TocControlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_TocControlMain_MouseClick);

            //3、制图控件，模仿PIE自动生成的地图控件MapControl
            m_PageLayoutControlMain = new PageLayoutControl();
            (m_PageLayoutControlMain as Control).Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageLayout.Controls.Add(m_PageLayoutControlMain as Control);

            //4、设置TOC和MapControl进行绑定
            m_TocControlMain.SetBuddyControl(m_MapControlMain as IPmdContents);
            
            m_MapControlMain.FocusMap = m_PageLayoutControlMain.FocusMap;//关联地图控件和制图控件的地图对象
            m_MapControlMain.Activate();//设置地图控件为激活状态;
            m_PageLayoutControlMain.DeActivate();//设置制图控件为非激活状态

        }
        #endregion

        #region 地图基本操作
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_LoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;//不能多选
            openFileDialog.Filter = "RasterFile|*.tif;*.tiff;*.img|ShapeFile|*.shp";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(openFileDialog.FileName)) return;

            string filePath = openFileDialog.FileName;

            //读取图层列表
            IList<ILayer> layers = m_MapControlMain.FocusMap.GetAllLayer();
            string[] layerList = new string[layers.Count];
            for (int i = 0; i < layers.Count; i++)
            {
                layerList[i] = layers[i].DataSourcePath;
            }

            //加载显示新图层，已有图层不重复加载
            if (!layerList.Contains(filePath))
            {
                m_MapControlMain.AddLayerFromFile(filePath, layers.Count);
                m_MapControlMain.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
            else
            {
                int idx = Array.IndexOf(layerList, filePath);
                m_MapControlMain.MoveLayerTo(idx, layers.Count - 1);
            }
        }

        /// <summary>
        ///地图拉框放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_ZoonIn_Click(object sender, EventArgs e)
        {
            ITool tool = new MapZoomInTool();
            (tool as ICommand).OnCreate(m_MapControlMain);
            m_MapControlMain.CurrentTool = tool;
        }

        /// <summary>
        ///地图拉框缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_ZoomOut_Click(object sender, EventArgs e)
        {
            ITool tool = new MapZoomOutTool();
            (tool as ICommand).OnCreate(m_MapControlMain);
            m_MapControlMain.CurrentTool = tool;
        }
        /// <summary>
        ///地图漫游
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_PanTool_Click(object sender, EventArgs e)
        {
            ITool tool = new PanTool();
            (tool as ICommand).OnCreate(m_MapControlMain);
            m_MapControlMain.CurrentTool = tool;
        }

        /// <summary>
        ///地图全图显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_FullExtent_Click(object sender, EventArgs e)
        {
            ICommand cmd = new FullExtentCommand();
            cmd.OnCreate(m_MapControlMain);
            cmd.OnClick();
        }
        #endregion

        #region 按钮及工具

        private void 加载模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //加载地图模板文档
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "地图模板|*.pmd";
            openFileDialog.Title = "选择地图模板";
            if (openFileDialog.ShowDialog() != DialogResult.OK) { return; }
            string pmdFile = openFileDialog.FileName;

            //加载地图模板文档
            IMapDocument mapDoc = new MapDocument();//加载地图文档对象
            mapDoc.Open(pmdFile);//打开地图模板

            //用原模版中的地图替换新模板的地图
            IMap map = m_PageLayoutControlMain.FocusMap;//获取原模版的地图对象
            IList<IMap> mapList = new List<IMap>();//地图对象添加到地图列表中
            mapList.Add(map);
            mapDoc.GetPageLayout().ReplaceMaps(mapList);//将原模版的地图替换到新模板中

            //连同地图显示新模板
            m_PageLayoutControlMain.PageLayout = mapDoc.GetPageLayout();
            uiTabControl1.SelectedIndex = 1;//切换成制图模式
            m_PageLayoutControlMain.PartialRefresh(ViewDrawPhaseType.ViewAll);
            m_MapControlMain.FocusMap = m_PageLayoutControlMain.FocusMap;
            
        }

        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择一个输出路径
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "选择保存路径";
            saveFileDialog.Filter = "JPGE File|*.jpg";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) { return; }

            string jpgFile = saveFileDialog.FileName;
            //保存图片
            m_PageLayoutControlMain.PageLayout.OutputJPG(jpgFile, 300, null, null, null);

            UIMessageBox.Show("保存成功！","提示",UIStyle.LayuiGreen,UIMessageBoxButtons.OK,true,true);
        }

        private void 净生态系统生产力NEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNEP formNEP = new FormNEP(m_MapControlMain);
            formNEP.ShowDialog();
        }

        private void 去异常值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRemoveOutliers formRemoveOutliers = new FormRemoveOutliers(m_MapControlMain);
            formRemoveOutliers.ShowDialog();
        }

        private void 图像裁剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImageClip formImageCut = new FormImageClip();
            formImageCut.ShowDialog();
        }

        private void 数值缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormValueScaling formValueScaling = new FormValueScaling(m_MapControlMain);
            formValueScaling.ShowDialog();
        }

        private void 月均温数据合成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBandMergeTemperature formBandMergeTemperature = new FormBandMergeTemperature();
            formBandMergeTemperature.Show();
        }

        private void 月总降水量数据合成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBandMergeWater formBandMergeWater = new FormBandMergeWater();
            formBandMergeWater.Show();

        }

        private void toolStripButtonRasterIdentify_Click(object sender, EventArgs e)
        {
            ITool rIdentifyTool = new RasterIdentifyTool();
            ICommand cmd = rIdentifyTool as ICommand;
            if (uiTabControl1.SelectedIndex == 0)
            {
                cmd.OnCreate(m_MapControlMain);
                cmd.OnClick();
                m_MapControlMain.CurrentTool = rIdentifyTool;
            }
        } 

        private void nEP时间变化特征分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimeChange formTimeChange = new FormTimeChange();
            formTimeChange.Show();
        }

        private void nEP空间分布特征分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormYearChange formYearChange = new FormYearChange(m_MapControlMain);
            formYearChange.Show();
        }
        

        private void nEP变化趋势分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChange formChange = new FormChange(m_MapControlMain);
            formChange.Show();
        }

        private void 栅格数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjectionTransformation formProjectionTransformation = new FormProjectionTransformation(m_MapControlMain);
            formProjectionTransformation.Show();
        }

        private void 矢量数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjectionTransformationSHP formProjectionTransformationSHP = new FormProjectionTransformationSHP(m_MapControlMain);
            formProjectionTransformationSHP.Show();
        }

        private void 碳源汇分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCarbonSinks formCarbonSinks = new FormCarbonSinks(m_MapControlMain);
            formCarbonSinks.Show();
        }



        #endregion

        private void 关于本次实习ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://rsimagine.eu.org/");
        }

        /// <summary>
        /// TOC右键菜单
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件触发参数</param>
        private void m_TocControlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PIETOCNodeType type = PIETOCNodeType.Null;
                IMap map = null;
                ILayer layer = null;
                Object unk = Type.Missing;
                Object data = Type.Missing;
                m_TocControlMain.HitTest(e.X, e.Y, ref type, ref map, ref layer, ref unk, ref data);

                switch (type)
                {
                    case PIETOCNodeType.FeatureLayer:
                        IFeatureLayer featureLayer = layer as IFeatureLayer;
                        if (featureLayer == null) return;

                        this.uiContextMenuStripTOC.Show(m_TocControlMain, new System.Drawing.Point(e.X, e.Y)); //显示菜单
                        break;

                    case PIETOCNodeType.RasterLayer:
                        IRasterLayer rasterLayer = layer as IRasterLayer;
                        if (rasterLayer == null) return;

                        this.uiContextMenuStripTOC.Show(m_TocControlMain, new System.Drawing.Point(e.X, e.Y)); //显示菜单
                        break;
                }
            }
        }
        /// <summary>
        /// TOC右键菜单功能实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TOCMenuItem_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;

            ICommand command = item.Tag as ICommand;
            if (command == null) return;
            command.OnCreate(m_MapControlMain);
            command.OnClick();

            ITool tool = command as ITool;
            if (tool != null)
            {
                m_MapControlMain.CurrentTool = tool;
            }
        }

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)//切换模式
        {
            if (uiTabControl1.SelectedIndex == 0)
            {
                m_MapControlMain.Activate();
                m_PageLayoutControlMain.DeActivate();
                m_MapControlMain.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
            else if (uiTabControl1.SelectedIndex == 1)
            {
                m_MapControlMain.DeActivate();
                m_PageLayoutControlMain.Activate();
                m_PageLayoutControlMain.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
        }

        private void 拉伸渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_MapControlMain.ActiveView.CurrentLayer == null) return;
            //选中的图层是否为栅格图层
            IRasterLayer rasterLayer = m_MapControlMain.ActiveView.CurrentLayer as IRasterLayer;
            if (rasterLayer == null) return;
            //设置色带
            IAlgorithmicColorRamp algoColorRamp = new AlgorithmicColorRamp();
            algoColorRamp.FromColor = Color.White;
            algoColorRamp.ToColor = Color.DarkGreen;

            bool resultOK = algoColorRamp.CreateRamp();
            //设置StretchColorRampRender
            IRasterStretchColorRampRender rasterSColorRampRender = new RasterStretchColorRampRender();
            rasterSColorRampRender.BandIndex = 0; //设置要拉伸的波段索引号
            rasterSColorRampRender.ClassColors = (algoColorRamp as IColorRamp).GetColors();
            //设置Render属性
            IRasterRender rasterRender = rasterSColorRampRender as IRasterRender;
            rasterLayer.Render = rasterRender;
            // 刷新地图
            m_MapControlMain.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        private void rGB渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当前选中的图层，通过鼠标点击进行设置
            if (m_MapControlMain.ActiveView.CurrentLayer == null) return;
            //判断选择的图层是否为栅格图层
            IRasterLayer rasterLayer = m_MapControlMain.ActiveView.CurrentLayer as IRasterLayer;
            if (rasterLayer == null) return;
            //初始化rgbRender
            IRasterRGBRender rRGBRender = new PIE.Carto.RasterRGBRender();

            //设置参数
            rRGBRender.UseRedBand = true;
            rRGBRender.UseGreenBand = true;
            rRGBRender.UseBlueBand = true;
            //根据栅格数据的波段数进行rgb波段索引设置，
            rRGBRender.SetBandIndices(2,1,0);

            //设置rasterrender
            IRasterRender render = rRGBRender as IRasterRender;
            rasterLayer.Render = render;
            //刷新视图
            m_MapControlMain.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        private void 分级渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_MapControlMain.ActiveView.CurrentLayer == null) return;
            IRasterLayer rasterLayer = m_MapControlMain.ActiveView.CurrentLayer as IRasterLayer;
            if (rasterLayer == null)
                return;
            //1 设置分级阈值，根据实际情况进行添加
            IUniqueValues uniqueValues = new UniqueValues();
            uniqueValues.Clear();
            uniqueValues.Add(1,1);
            uniqueValues.Add(2,2);
            uniqueValues.Add(3,3);
            uniqueValues.Add(4,4);
            uniqueValues.Add(5,5);

            //2 设置色带
            IList<Color> colors = new List<Color>();
            colors.Add(Color.White);
            colors.Add(Color.DarkBlue);
            colors.Add(Color.LightSkyBlue);
            colors.Add(Color.Purple);
            colors.Add(Color.DarkRed);
            colors.Add(Color.Red);

            //3 RasterClassifyColorRampRender分级渲染
            IRasterClassifyColorRampRender rClassifyColorRampRender = new RasterClassifyColorRampRender();
            rClassifyColorRampRender.ClassColors = colors;

            rClassifyColorRampRender.SetBandIndex(0);
            rClassifyColorRampRender.UniqueValues = uniqueValues;

            //4 设置备注信息（可以自定义备注信息）
            
            IList<string> listLabel = new List<string>();
            int count = uniqueValues.GetCount();
            string beginLabel = "0";
            string lastLabel = "";
            for (int i = 0; i < count; i++)
            {
                if (i - 1 >= 0)
                {
                    beginLabel = uniqueValues.GetUniqueValue(i - 1).ToString();
                }
                lastLabel = uniqueValues.GetUniqueValue(i).ToString();
                string labelInfo = string.Format("{0}-{1}", beginLabel, lastLabel);
                listLabel.Add(labelInfo);
            }
            rClassifyColorRampRender.Labels = listLabel;
            
            //设置rasterRender
            IRasterRender rasterRender = rClassifyColorRampRender as IRasterRender;
            rasterLayer.Render = rasterRender;
            m_MapControlMain.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }
    }
}
