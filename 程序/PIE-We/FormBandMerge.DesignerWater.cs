namespace PIE_We
{
    partial class FormBandMerge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiTextBoxIn = new Sunny.UI.UITextBox();
            this.uiButtonIn = new Sunny.UI.UIButton();
            this.uiLabelIn = new Sunny.UI.UILabel();
            this.uiTextBoxOut = new Sunny.UI.UITextBox();
            this.uiButtonOut = new Sunny.UI.UIButton();
            this.uiLabelOut = new Sunny.UI.UILabel();
            this.uiButtonRun = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiTextBoxIn
            // 
            this.uiTextBoxIn.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxIn.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiTextBoxIn.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiTextBoxIn.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxIn.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiTextBoxIn.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiTextBoxIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxIn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiTextBoxIn.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxIn.Location = new System.Drawing.Point(20, 94);
            this.uiTextBoxIn.Margin = new System.Windows.Forms.Padding(18);
            this.uiTextBoxIn.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxIn.Name = "uiTextBoxIn";
            this.uiTextBoxIn.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxIn.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxIn.ShowText = false;
            this.uiTextBoxIn.Size = new System.Drawing.Size(511, 35);
            this.uiTextBoxIn.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiTextBoxIn.TabIndex = 5;
            this.uiTextBoxIn.Text = "请选择待合成的多波段影像文件";
            this.uiTextBoxIn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxIn.Watermark = "";
            this.uiTextBoxIn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonIn
            // 
            this.uiButtonIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonIn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonIn.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiButtonIn.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonIn.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonIn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonIn.Location = new System.Drawing.Point(566, 94);
            this.uiButtonIn.Margin = new System.Windows.Forms.Padding(18);
            this.uiButtonIn.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonIn.Name = "uiButtonIn";
            this.uiButtonIn.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonIn.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiButtonIn.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonIn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonIn.Size = new System.Drawing.Size(109, 35);
            this.uiButtonIn.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiButtonIn.TabIndex = 4;
            this.uiButtonIn.Text = "浏览";
            this.uiButtonIn.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonIn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonIn.Click += new System.EventHandler(this.uiButtonIn_Click);
            // 
            // uiLabelIn
            // 
            this.uiLabelIn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelIn.Location = new System.Drawing.Point(14, 51);
            this.uiLabelIn.Margin = new System.Windows.Forms.Padding(18);
            this.uiLabelIn.Name = "uiLabelIn";
            this.uiLabelIn.Size = new System.Drawing.Size(286, 33);
            this.uiLabelIn.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabelIn.TabIndex = 3;
            this.uiLabelIn.Text = "待数据合成的多波段影像：";
            this.uiLabelIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelIn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxOut
            // 
            this.uiTextBoxOut.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxOut.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiTextBoxOut.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiTextBoxOut.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxOut.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiTextBoxOut.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiTextBoxOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxOut.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiTextBoxOut.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxOut.Location = new System.Drawing.Point(19, 193);
            this.uiTextBoxOut.Margin = new System.Windows.Forms.Padding(18);
            this.uiTextBoxOut.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxOut.Name = "uiTextBoxOut";
            this.uiTextBoxOut.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxOut.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiTextBoxOut.ShowText = false;
            this.uiTextBoxOut.Size = new System.Drawing.Size(511, 35);
            this.uiTextBoxOut.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiTextBoxOut.TabIndex = 8;
            this.uiTextBoxOut.Text = "请选择合成结果影像文件输出路径";
            this.uiTextBoxOut.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxOut.Watermark = "";
            this.uiTextBoxOut.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonOut
            // 
            this.uiButtonOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonOut.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonOut.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiButtonOut.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonOut.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonOut.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonOut.Location = new System.Drawing.Point(566, 193);
            this.uiButtonOut.Margin = new System.Windows.Forms.Padding(18);
            this.uiButtonOut.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonOut.Name = "uiButtonOut";
            this.uiButtonOut.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonOut.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiButtonOut.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonOut.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonOut.Size = new System.Drawing.Size(109, 35);
            this.uiButtonOut.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiButtonOut.TabIndex = 7;
            this.uiButtonOut.Text = "浏览";
            this.uiButtonOut.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonOut.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonOut.Click += new System.EventHandler(this.uiButtonOut_Click);
            // 
            // uiLabelOut
            // 
            this.uiLabelOut.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelOut.Location = new System.Drawing.Point(14, 151);
            this.uiLabelOut.Margin = new System.Windows.Forms.Padding(18);
            this.uiLabelOut.Name = "uiLabelOut";
            this.uiLabelOut.Size = new System.Drawing.Size(286, 33);
            this.uiLabelOut.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabelOut.TabIndex = 6;
            this.uiLabelOut.Text = "合成结果影像输出路径：";
            this.uiLabelOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelOut.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonRun
            // 
            this.uiButtonRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRun.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonRun.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonRun.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiButtonRun.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonRun.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonRun.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRun.Location = new System.Drawing.Point(20, 264);
            this.uiButtonRun.Margin = new System.Windows.Forms.Padding(18);
            this.uiButtonRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRun.Name = "uiButtonRun";
            this.uiButtonRun.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButtonRun.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiButtonRun.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonRun.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiButtonRun.Size = new System.Drawing.Size(655, 53);
            this.uiButtonRun.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiButtonRun.TabIndex = 9;
            this.uiButtonRun.Text = "开始处理";
            this.uiButtonRun.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonRun.Click += new System.EventHandler(this.uiButtonRun_Click);
            // 
            // FormBandMerge
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(697, 342);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.Controls.Add(this.uiButtonRun);
            this.Controls.Add(this.uiTextBoxOut);
            this.Controls.Add(this.uiButtonOut);
            this.Controls.Add(this.uiLabelOut);
            this.Controls.Add(this.uiTextBoxIn);
            this.Controls.Add(this.uiButtonIn);
            this.Controls.Add(this.uiLabelIn);
            this.MaximizeBox = false;
            this.Name = "FormBandMerge";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.Text = "数据合成";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox uiTextBoxIn;
        private Sunny.UI.UIButton uiButtonIn;
        private Sunny.UI.UILabel uiLabelIn;
        private Sunny.UI.UITextBox uiTextBoxOut;
        private Sunny.UI.UIButton uiButtonOut;
        private Sunny.UI.UILabel uiLabelOut;
        private Sunny.UI.UIButton uiButtonRun;
    }
}