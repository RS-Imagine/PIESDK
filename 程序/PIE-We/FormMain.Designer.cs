namespace PIE_We
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1_LoadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1_ZoonIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3_PanTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4_FullExtent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRasterIdentify = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.去异常值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.投影变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矢量数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.栅格数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像裁剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据合成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.月均温数据合成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.月总降水量数据合成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数值缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.净生态系统生产力NEPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.nEP时间变化特征分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEP空间分布特征分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEP变化趋势分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.碳源汇分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.加载模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new Sunny.UI.UISplitContainer();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.tabPageLayout = new System.Windows.Forms.TabPage();
            this.关于本次实习ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiContextMenuStripAbout = new Sunny.UI.UIContextMenuStrip();
            this.uiContextMenuStripTOC = new Sunny.UI.UIContextMenuStrip();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.栅格渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拉伸渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGB渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分级渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.uiContextMenuStripAbout.SuspendLayout();
            this.uiContextMenuStripTOC.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1_LoadData,
            this.toolStripButton1_ZoonIn,
            this.toolStripButton2_ZoomOut,
            this.toolStripButton3_PanTool,
            this.toolStripButton4_FullExtent,
            this.toolStripButtonRasterIdentify,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4});
            this.toolStrip1.Location = new System.Drawing.Point(2, 36);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1663, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1_LoadData
            // 
            this.toolStripButton1_LoadData.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1_LoadData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1_LoadData.Image")));
            this.toolStripButton1_LoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_LoadData.Name = "toolStripButton1_LoadData";
            this.toolStripButton1_LoadData.Size = new System.Drawing.Size(138, 35);
            this.toolStripButton1_LoadData.Text = "加载数据";
            this.toolStripButton1_LoadData.Click += new System.EventHandler(this.toolStripButton1_LoadData_Click);
            // 
            // toolStripButton1_ZoonIn
            // 
            this.toolStripButton1_ZoonIn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1_ZoonIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1_ZoonIn.Image")));
            this.toolStripButton1_ZoonIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_ZoonIn.Name = "toolStripButton1_ZoonIn";
            this.toolStripButton1_ZoonIn.Size = new System.Drawing.Size(138, 35);
            this.toolStripButton1_ZoonIn.Text = "地图放大";
            this.toolStripButton1_ZoonIn.Click += new System.EventHandler(this.toolStripButton1_ZoonIn_Click);
            // 
            // toolStripButton2_ZoomOut
            // 
            this.toolStripButton2_ZoomOut.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton2_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2_ZoomOut.Image")));
            this.toolStripButton2_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2_ZoomOut.Name = "toolStripButton2_ZoomOut";
            this.toolStripButton2_ZoomOut.Size = new System.Drawing.Size(138, 35);
            this.toolStripButton2_ZoomOut.Text = "地图缩小";
            this.toolStripButton2_ZoomOut.Click += new System.EventHandler(this.toolStripButton2_ZoomOut_Click);
            // 
            // toolStripButton3_PanTool
            // 
            this.toolStripButton3_PanTool.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton3_PanTool.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3_PanTool.Image")));
            this.toolStripButton3_PanTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3_PanTool.Name = "toolStripButton3_PanTool";
            this.toolStripButton3_PanTool.Size = new System.Drawing.Size(90, 35);
            this.toolStripButton3_PanTool.Text = "漫游";
            this.toolStripButton3_PanTool.Click += new System.EventHandler(this.toolStripButton3_PanTool_Click);
            // 
            // toolStripButton4_FullExtent
            // 
            this.toolStripButton4_FullExtent.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton4_FullExtent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4_FullExtent.Image")));
            this.toolStripButton4_FullExtent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4_FullExtent.Name = "toolStripButton4_FullExtent";
            this.toolStripButton4_FullExtent.Size = new System.Drawing.Size(138, 35);
            this.toolStripButton4_FullExtent.Text = "全图显示";
            this.toolStripButton4_FullExtent.Click += new System.EventHandler(this.toolStripButton4_FullExtent_Click);
            // 
            // toolStripButtonRasterIdentify
            // 
            this.toolStripButtonRasterIdentify.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButtonRasterIdentify.Image = global::PIE_We.Properties.Resources.探针工具;
            this.toolStripButtonRasterIdentify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRasterIdentify.Name = "toolStripButtonRasterIdentify";
            this.toolStripButtonRasterIdentify.Size = new System.Drawing.Size(138, 35);
            this.toolStripButtonRasterIdentify.Text = "探针工具";
            this.toolStripButtonRasterIdentify.Click += new System.EventHandler(this.toolStripButtonRasterIdentify_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.去异常值ToolStripMenuItem,
            this.投影变换ToolStripMenuItem,
            this.图像裁剪ToolStripMenuItem,
            this.数据合成ToolStripMenuItem,
            this.数值缩放ToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(176, 35);
            this.toolStripDropDownButton1.Text = "数据预处理";
            // 
            // 去异常值ToolStripMenuItem
            // 
            this.去异常值ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.去异常值ToolStripMenuItem.Name = "去异常值ToolStripMenuItem";
            this.去异常值ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.去异常值ToolStripMenuItem.Text = "除去异常值";
            this.去异常值ToolStripMenuItem.Click += new System.EventHandler(this.去异常值ToolStripMenuItem_Click);
            // 
            // 投影变换ToolStripMenuItem
            // 
            this.投影变换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矢量数据ToolStripMenuItem,
            this.栅格数据ToolStripMenuItem});
            this.投影变换ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.投影变换ToolStripMenuItem.Name = "投影变换ToolStripMenuItem";
            this.投影变换ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.投影变换ToolStripMenuItem.Text = "投影变换";
            // 
            // 矢量数据ToolStripMenuItem
            // 
            this.矢量数据ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.矢量数据ToolStripMenuItem.Name = "矢量数据ToolStripMenuItem";
            this.矢量数据ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.矢量数据ToolStripMenuItem.Text = "矢量数据";
            this.矢量数据ToolStripMenuItem.Click += new System.EventHandler(this.矢量数据ToolStripMenuItem_Click);
            // 
            // 栅格数据ToolStripMenuItem
            // 
            this.栅格数据ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.栅格数据ToolStripMenuItem.Name = "栅格数据ToolStripMenuItem";
            this.栅格数据ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.栅格数据ToolStripMenuItem.Text = "栅格数据";
            this.栅格数据ToolStripMenuItem.Click += new System.EventHandler(this.栅格数据ToolStripMenuItem_Click);
            // 
            // 图像裁剪ToolStripMenuItem
            // 
            this.图像裁剪ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.图像裁剪ToolStripMenuItem.Name = "图像裁剪ToolStripMenuItem";
            this.图像裁剪ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.图像裁剪ToolStripMenuItem.Text = "图像裁剪";
            this.图像裁剪ToolStripMenuItem.Click += new System.EventHandler(this.图像裁剪ToolStripMenuItem_Click);
            // 
            // 数据合成ToolStripMenuItem
            // 
            this.数据合成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.月均温数据合成ToolStripMenuItem,
            this.月总降水量数据合成ToolStripMenuItem});
            this.数据合成ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.数据合成ToolStripMenuItem.Name = "数据合成ToolStripMenuItem";
            this.数据合成ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.数据合成ToolStripMenuItem.Text = "数据合成至";
            // 
            // 月均温数据合成ToolStripMenuItem
            // 
            this.月均温数据合成ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.月均温数据合成ToolStripMenuItem.Name = "月均温数据合成ToolStripMenuItem";
            this.月均温数据合成ToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.月均温数据合成ToolStripMenuItem.Text = "年均温数据";
            this.月均温数据合成ToolStripMenuItem.Click += new System.EventHandler(this.月均温数据合成ToolStripMenuItem_Click);
            // 
            // 月总降水量数据合成ToolStripMenuItem
            // 
            this.月总降水量数据合成ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.月总降水量数据合成ToolStripMenuItem.Name = "月总降水量数据合成ToolStripMenuItem";
            this.月总降水量数据合成ToolStripMenuItem.Size = new System.Drawing.Size(238, 34);
            this.月总降水量数据合成ToolStripMenuItem.Text = "年总降水量数据";
            this.月总降水量数据合成ToolStripMenuItem.Click += new System.EventHandler(this.月总降水量数据合成ToolStripMenuItem_Click);
            // 
            // 数值缩放ToolStripMenuItem
            // 
            this.数值缩放ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.数值缩放ToolStripMenuItem.Name = "数值缩放ToolStripMenuItem";
            this.数值缩放ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.数值缩放ToolStripMenuItem.Text = "数值缩放";
            this.数值缩放ToolStripMenuItem.Click += new System.EventHandler(this.数值缩放ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.净生态系统生产力NEPToolStripMenuItem});
            this.toolStripDropDownButton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(200, 35);
            this.toolStripDropDownButton2.Text = "指数计算模块";
            // 
            // 净生态系统生产力NEPToolStripMenuItem
            // 
            this.净生态系统生产力NEPToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.净生态系统生产力NEPToolStripMenuItem.Name = "净生态系统生产力NEPToolStripMenuItem";
            this.净生态系统生产力NEPToolStripMenuItem.Size = new System.Drawing.Size(326, 36);
            this.净生态系统生产力NEPToolStripMenuItem.Text = "净生态系统生产力NEP";
            this.净生态系统生产力NEPToolStripMenuItem.Click += new System.EventHandler(this.净生态系统生产力NEPToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nEP时间变化特征分析ToolStripMenuItem,
            this.nEP空间分布特征分析ToolStripMenuItem,
            this.nEP变化趋势分析ToolStripMenuItem,
            this.碳源汇分析ToolStripMenuItem});
            this.toolStripDropDownButton3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(200, 35);
            this.toolStripDropDownButton3.Text = "变化分析模块";
            // 
            // nEP时间变化特征分析ToolStripMenuItem
            // 
            this.nEP时间变化特征分析ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nEP时间变化特征分析ToolStripMenuItem.Name = "nEP时间变化特征分析ToolStripMenuItem";
            this.nEP时间变化特征分析ToolStripMenuItem.Size = new System.Drawing.Size(326, 36);
            this.nEP时间变化特征分析ToolStripMenuItem.Text = "NEP时间变化特征分析";
            this.nEP时间变化特征分析ToolStripMenuItem.Click += new System.EventHandler(this.nEP时间变化特征分析ToolStripMenuItem_Click);
            // 
            // nEP空间分布特征分析ToolStripMenuItem
            // 
            this.nEP空间分布特征分析ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nEP空间分布特征分析ToolStripMenuItem.Name = "nEP空间分布特征分析ToolStripMenuItem";
            this.nEP空间分布特征分析ToolStripMenuItem.Size = new System.Drawing.Size(326, 36);
            this.nEP空间分布特征分析ToolStripMenuItem.Text = "NEP空间分布特征分析";
            this.nEP空间分布特征分析ToolStripMenuItem.Click += new System.EventHandler(this.nEP空间分布特征分析ToolStripMenuItem_Click);
            // 
            // nEP变化趋势分析ToolStripMenuItem
            // 
            this.nEP变化趋势分析ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nEP变化趋势分析ToolStripMenuItem.Name = "nEP变化趋势分析ToolStripMenuItem";
            this.nEP变化趋势分析ToolStripMenuItem.Size = new System.Drawing.Size(326, 36);
            this.nEP变化趋势分析ToolStripMenuItem.Text = "NEP变化趋势分析";
            this.nEP变化趋势分析ToolStripMenuItem.Click += new System.EventHandler(this.nEP变化趋势分析ToolStripMenuItem_Click);
            // 
            // 碳源汇分析ToolStripMenuItem
            // 
            this.碳源汇分析ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.碳源汇分析ToolStripMenuItem.Name = "碳源汇分析ToolStripMenuItem";
            this.碳源汇分析ToolStripMenuItem.Size = new System.Drawing.Size(326, 36);
            this.碳源汇分析ToolStripMenuItem.Text = "碳源汇分析";
            this.碳源汇分析ToolStripMenuItem.Click += new System.EventHandler(this.碳源汇分析ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载模板ToolStripMenuItem,
            this.保存图片ToolStripMenuItem,
            this.栅格渲染ToolStripMenuItem});
            this.toolStripDropDownButton4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(152, 35);
            this.toolStripDropDownButton4.Text = "专题制图";
            // 
            // 加载模板ToolStripMenuItem
            // 
            this.加载模板ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.加载模板ToolStripMenuItem.Name = "加载模板ToolStripMenuItem";
            this.加载模板ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.加载模板ToolStripMenuItem.Text = "加载模板";
            this.加载模板ToolStripMenuItem.Click += new System.EventHandler(this.加载模板ToolStripMenuItem_Click);
            // 
            // 保存图片ToolStripMenuItem
            // 
            this.保存图片ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.保存图片ToolStripMenuItem.Name = "保存图片ToolStripMenuItem";
            this.保存图片ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.保存图片ToolStripMenuItem.Text = "保存图片";
            this.保存图片ToolStripMenuItem.Click += new System.EventHandler(this.保存图片ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.splitContainer1.BarColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.HandleColor = System.Drawing.Color.Teal;
            this.splitContainer1.HandleHoverColor = System.Drawing.Color.IndianRed;
            this.splitContainer1.Location = new System.Drawing.Point(2, 76);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1663, 801);
            this.splitContainer1.SplitterDistance = 437;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.uiTabControl1.Controls.Add(this.tabPageMap);
            this.uiTabControl1.Controls.Add(this.tabPageLayout);
            this.uiTabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.Frame = null;
            this.uiTabControl1.ItemSize = new System.Drawing.Size(100, 25);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.White;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(1215, 801);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTabControl1.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTabControl1.SelectedIndexChanged += new System.EventHandler(this.uiTabControl1_SelectedIndexChanged);
            // 
            // tabPageMap
            // 
            this.tabPageMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tabPageMap.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPageMap.ForeColor = System.Drawing.Color.Transparent;
            this.tabPageMap.Location = new System.Drawing.Point(0, 0);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Size = new System.Drawing.Size(1215, 776);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "地图模式";
            // 
            // tabPageLayout
            // 
            this.tabPageLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tabPageLayout.Location = new System.Drawing.Point(0, 0);
            this.tabPageLayout.Name = "tabPageLayout";
            this.tabPageLayout.Size = new System.Drawing.Size(200, 60);
            this.tabPageLayout.TabIndex = 1;
            this.tabPageLayout.Text = "制图模式";
            // 
            // 关于本次实习ToolStripMenuItem
            // 
            this.关于本次实习ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于本次实习ToolStripMenuItem.Name = "关于本次实习ToolStripMenuItem";
            this.关于本次实习ToolStripMenuItem.Size = new System.Drawing.Size(190, 30);
            this.关于本次实习ToolStripMenuItem.Text = "关于本次实习";
            this.关于本次实习ToolStripMenuItem.Click += new System.EventHandler(this.关于本次实习ToolStripMenuItem_Click);
            // 
            // uiContextMenuStripAbout
            // 
            this.uiContextMenuStripAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiContextMenuStripAbout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStripAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiContextMenuStripAbout.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uiContextMenuStripAbout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于本次实习ToolStripMenuItem});
            this.uiContextMenuStripAbout.Name = "uiContextMenuStripAbout";
            this.uiContextMenuStripAbout.Size = new System.Drawing.Size(191, 34);
            this.uiContextMenuStripAbout.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiContextMenuStripAbout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiContextMenuStripTOC
            // 
            this.uiContextMenuStripTOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStripTOC.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStripTOC.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uiContextMenuStripTOC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem,
            this.ZoomtoToolStripMenuItem});
            this.uiContextMenuStripTOC.Name = "uiContextMenuStripTOC";
            this.uiContextMenuStripTOC.Size = new System.Drawing.Size(175, 64);
            this.uiContextMenuStripTOC.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.DeleteToolStripMenuItem.Text = "删除图层";
            this.DeleteToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TOCMenuItem_Click);
            // 
            // ZoomtoToolStripMenuItem
            // 
            this.ZoomtoToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZoomtoToolStripMenuItem.Name = "ZoomtoToolStripMenuItem";
            this.ZoomtoToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.ZoomtoToolStripMenuItem.Text = "放缩至图层";
            this.ZoomtoToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TOCMenuItem_Click);
            // 
            // 栅格渲染ToolStripMenuItem
            // 
            this.栅格渲染ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拉伸渲染ToolStripMenuItem,
            this.rGB渲染ToolStripMenuItem,
            this.分级渲染ToolStripMenuItem});
            this.栅格渲染ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.栅格渲染ToolStripMenuItem.Name = "栅格渲染ToolStripMenuItem";
            this.栅格渲染ToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.栅格渲染ToolStripMenuItem.Text = "栅格渲染";
            // 
            // 拉伸渲染ToolStripMenuItem
            // 
            this.拉伸渲染ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.拉伸渲染ToolStripMenuItem.Name = "拉伸渲染ToolStripMenuItem";
            this.拉伸渲染ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.拉伸渲染ToolStripMenuItem.Text = "拉伸渲染";
            this.拉伸渲染ToolStripMenuItem.Click += new System.EventHandler(this.拉伸渲染ToolStripMenuItem_Click);
            // 
            // rGB渲染ToolStripMenuItem
            // 
            this.rGB渲染ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rGB渲染ToolStripMenuItem.Name = "rGB渲染ToolStripMenuItem";
            this.rGB渲染ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.rGB渲染ToolStripMenuItem.Text = "RGB渲染";
            this.rGB渲染ToolStripMenuItem.Click += new System.EventHandler(this.rGB渲染ToolStripMenuItem_Click);
            // 
            // 分级渲染ToolStripMenuItem
            // 
            this.分级渲染ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.分级渲染ToolStripMenuItem.Name = "分级渲染ToolStripMenuItem";
            this.分级渲染ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.分级渲染ToolStripMenuItem.Text = "分级渲染";
            this.分级渲染ToolStripMenuItem.Click += new System.EventHandler(this.分级渲染ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1667, 879);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStripAbout;
            this.ExtendSymbol = 62108;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowTitleIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.Text = " PIE二次开发实习 应用程序";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 636, 470);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.uiContextMenuStripAbout.ResumeLayout(false);
            this.uiContextMenuStripTOC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1_LoadData;    
        private System.Windows.Forms.ToolStripButton toolStripButton1_ZoonIn;
        private System.Windows.Forms.ToolStripButton toolStripButton2_ZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButton3_PanTool;
        private System.Windows.Forms.ToolStripButton toolStripButton4_FullExtent;
        private Sunny.UI.UISplitContainer splitContainer1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.TabPage tabPageLayout;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 图像裁剪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 去异常值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数值缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 投影变换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据合成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 净生态系统生产力NEPToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem nEP时间变化特征分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEP空间分布特征分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEP变化趋势分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem 加载模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于本次实习ToolStripMenuItem;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStripAbout;
        private System.Windows.Forms.ToolStripMenuItem 月均温数据合成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 月总降水量数据合成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonRasterIdentify;
        private System.Windows.Forms.ToolStripMenuItem 矢量数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 栅格数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 碳源汇分析ToolStripMenuItem;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStripTOC;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 栅格渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拉伸渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGB渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分级渲染ToolStripMenuItem;
    }
}

