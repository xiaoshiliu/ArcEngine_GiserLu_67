namespace Giser_Lu
{
    partial class frmLableByField
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
            this.cbx_Layer = new System.Windows.Forms.ComboBox();
            this.cbx_Field = new System.Windows.Forms.ComboBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_FontSelector = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_PreviewFont = new System.Windows.Forms.Label();
            this.btn_FontColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // cbx_Layer
            // 
            this.cbx_Layer.FormattingEnabled = true;
            this.cbx_Layer.Location = new System.Drawing.Point(44, 4);
            this.cbx_Layer.Name = "cbx_Layer";
            this.cbx_Layer.Size = new System.Drawing.Size(121, 20);
            this.cbx_Layer.TabIndex = 0;
            this.cbx_Layer.SelectedIndexChanged += new System.EventHandler(this.cbx_Layer_SelectedIndexChanged);
            // 
            // cbx_Field
            // 
            this.cbx_Field.FormattingEnabled = true;
            this.cbx_Field.Location = new System.Drawing.Point(44, 32);
            this.cbx_Field.Name = "cbx_Field";
            this.cbx_Field.Size = new System.Drawing.Size(121, 20);
            this.cbx_Field.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图层:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "字段:";
            // 
            // btn_FontSelector
            // 
            this.btn_FontSelector.Location = new System.Drawing.Point(171, 2);
            this.btn_FontSelector.Name = "btn_FontSelector";
            this.btn_FontSelector.Size = new System.Drawing.Size(75, 23);
            this.btn_FontSelector.TabIndex = 4;
            this.btn_FontSelector.Text = "文字属性";
            this.btn_FontSelector.UseVisualStyleBackColor = true;
            this.btn_FontSelector.Click += new System.EventHandler(this.btn_FontSelector_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(171, 62);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_PreviewFont
            // 
            this.lbl_PreviewFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PreviewFont.Location = new System.Drawing.Point(5, 62);
            this.lbl_PreviewFont.Name = "lbl_PreviewFont";
            this.lbl_PreviewFont.Size = new System.Drawing.Size(160, 23);
            this.lbl_PreviewFont.TabIndex = 6;
            this.lbl_PreviewFont.Text = "Hello 我是测试 1234";
            // 
            // btn_FontColor
            // 
            this.btn_FontColor.Location = new System.Drawing.Point(171, 32);
            this.btn_FontColor.Name = "btn_FontColor";
            this.btn_FontColor.Size = new System.Drawing.Size(75, 23);
            this.btn_FontColor.TabIndex = 7;
            this.btn_FontColor.Text = "文字颜色";
            this.btn_FontColor.UseVisualStyleBackColor = true;
            this.btn_FontColor.Click += new System.EventHandler(this.btn_FontColor_Click);
            // 
            // frmLableByField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 94);
            this.Controls.Add(this.btn_FontColor);
            this.Controls.Add(this.lbl_PreviewFont);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_FontSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Field);
            this.Controls.Add(this.cbx_Layer);
            this.Name = "frmLableByField";
            this.Text = "frmLableByField";
            this.Load += new System.EventHandler(this.frmLableByField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Layer;
        private System.Windows.Forms.ComboBox cbx_Field;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_FontSelector;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_PreviewFont;
        private System.Windows.Forms.Button btn_FontColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}