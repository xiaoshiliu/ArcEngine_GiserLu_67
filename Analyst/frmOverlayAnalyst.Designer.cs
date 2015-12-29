namespace Giser_Lu
{
    partial class frmOverlayAnalyst
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
            this.cbx_InPutLayer = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nmUd_InputPrecisionLevel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nmUD_OverlayLayerPrecisionLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_OverlayLayer = new System.Windows.Forms.ComboBox();
            this.nmUd_Tolerance = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbx_OutPutFeatureType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbx_OutPutAttributeType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_OverlayAnalystType = new System.Windows.Forms.ComboBox();
            this.btn_BrowseOutPutPath = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUd_InputPrecisionLevel)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_OverlayLayerPrecisionLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUd_Tolerance)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_InPutLayer
            // 
            this.cbx_InPutLayer.FormattingEnabled = true;
            this.cbx_InPutLayer.Location = new System.Drawing.Point(44, 20);
            this.cbx_InPutLayer.Name = "cbx_InPutLayer";
            this.cbx_InPutLayer.Size = new System.Drawing.Size(167, 20);
            this.cbx_InPutLayer.TabIndex = 1;
            this.cbx_InPutLayer.SelectedIndexChanged += new System.EventHandler(this.cbx_InPutLayer_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nmUd_InputPrecisionLevel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbx_InPutLayer);
            this.groupBox2.Location = new System.Drawing.Point(4, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 87);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入图层";
            // 
            // nmUd_InputPrecisionLevel
            // 
            this.nmUd_InputPrecisionLevel.Location = new System.Drawing.Point(73, 53);
            this.nmUd_InputPrecisionLevel.Name = "nmUd_InputPrecisionLevel";
            this.nmUd_InputPrecisionLevel.Size = new System.Drawing.Size(115, 21);
            this.nmUd_InputPrecisionLevel.TabIndex = 4;
            this.nmUd_InputPrecisionLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUd_InputPrecisionLevel.ValueChanged += new System.EventHandler(this.nmUd_InputPrecisionLevel_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "精度等级:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图层:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nmUD_OverlayLayerPrecisionLevel);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbx_OverlayLayer);
            this.groupBox3.Location = new System.Drawing.Point(4, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 87);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "叠置图层";
            // 
            // nmUD_OverlayLayerPrecisionLevel
            // 
            this.nmUD_OverlayLayerPrecisionLevel.Location = new System.Drawing.Point(73, 53);
            this.nmUD_OverlayLayerPrecisionLevel.Name = "nmUD_OverlayLayerPrecisionLevel";
            this.nmUD_OverlayLayerPrecisionLevel.Size = new System.Drawing.Size(115, 21);
            this.nmUD_OverlayLayerPrecisionLevel.TabIndex = 4;
            this.nmUD_OverlayLayerPrecisionLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUD_OverlayLayerPrecisionLevel.ValueChanged += new System.EventHandler(this.nmUD_OverlayLayerPrecisionLevel_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "精度等级:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "图层:";
            // 
            // cbx_OverlayLayer
            // 
            this.cbx_OverlayLayer.FormattingEnabled = true;
            this.cbx_OverlayLayer.Location = new System.Drawing.Point(44, 20);
            this.cbx_OverlayLayer.Name = "cbx_OverlayLayer";
            this.cbx_OverlayLayer.Size = new System.Drawing.Size(167, 20);
            this.cbx_OverlayLayer.TabIndex = 1;
            this.cbx_OverlayLayer.SelectedIndexChanged += new System.EventHandler(this.cbx_OverlayLayer_SelectedIndexChanged);
            // 
            // nmUd_Tolerance
            // 
            this.nmUd_Tolerance.Location = new System.Drawing.Point(73, 14);
            this.nmUd_Tolerance.Name = "nmUd_Tolerance";
            this.nmUd_Tolerance.Size = new System.Drawing.Size(111, 21);
            this.nmUd_Tolerance.TabIndex = 6;
            this.nmUd_Tolerance.ValueChanged += new System.EventHandler(this.nmUd_Tolerance_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "容差:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_BrowseOutPutPath);
            this.groupBox4.Controls.Add(this.cbx_OutPutFeatureType);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cbx_OutPutAttributeType);
            this.groupBox4.Location = new System.Drawing.Point(4, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 79);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "输出类型";
            // 
            // cbx_OutPutFeatureType
            // 
            this.cbx_OutPutFeatureType.FormattingEnabled = true;
            this.cbx_OutPutFeatureType.Items.AddRange(new object[] {
            "根据输入要素确定",
            "线",
            "点"});
            this.cbx_OutPutFeatureType.Location = new System.Drawing.Point(42, 52);
            this.cbx_OutPutFeatureType.Name = "cbx_OutPutFeatureType";
            this.cbx_OutPutFeatureType.Size = new System.Drawing.Size(103, 20);
            this.cbx_OutPutFeatureType.TabIndex = 4;
            this.cbx_OutPutFeatureType.SelectedIndexChanged += new System.EventHandler(this.cbx_OutPutFeatureType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "要素:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "属性:";
            // 
            // cbx_OutPutAttributeType
            // 
            this.cbx_OutPutAttributeType.FormattingEnabled = true;
            this.cbx_OutPutAttributeType.Items.AddRange(new object[] {
            "所有属性",
            "不包括FID",
            "仅包括FID"});
            this.cbx_OutPutAttributeType.Location = new System.Drawing.Point(44, 20);
            this.cbx_OutPutAttributeType.Name = "cbx_OutPutAttributeType";
            this.cbx_OutPutAttributeType.Size = new System.Drawing.Size(101, 20);
            this.cbx_OutPutAttributeType.TabIndex = 1;
            this.cbx_OutPutAttributeType.SelectedIndexChanged += new System.EventHandler(this.cbx_OutPutAttributeType_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nmUd_Tolerance);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(4, 233);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 44);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(145, 366);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbx_OverlayAnalystType);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 44);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分析类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "叠置类型:";
            // 
            // cbx_OverlayAnalystType
            // 
            this.cbx_OverlayAnalystType.FormattingEnabled = true;
            this.cbx_OverlayAnalystType.Items.AddRange(new object[] {
            "求交叠置",
            "求和叠置",
            "同一性叠置",
            "擦除叠置",
            "更新叠置",
            "异或叠置"});
            this.cbx_OverlayAnalystType.Location = new System.Drawing.Point(73, 18);
            this.cbx_OverlayAnalystType.Name = "cbx_OverlayAnalystType";
            this.cbx_OverlayAnalystType.Size = new System.Drawing.Size(137, 20);
            this.cbx_OverlayAnalystType.TabIndex = 0;
            this.cbx_OverlayAnalystType.SelectedIndexChanged += new System.EventHandler(this.cbx_OverlayAnalystType_SelectedIndexChanged);
            // 
            // btn_BrowseOutPutPath
            // 
            this.btn_BrowseOutPutPath.Location = new System.Drawing.Point(149, 32);
            this.btn_BrowseOutPutPath.Name = "btn_BrowseOutPutPath";
            this.btn_BrowseOutPutPath.Size = new System.Drawing.Size(61, 23);
            this.btn_BrowseOutPutPath.TabIndex = 11;
            this.btn_BrowseOutPutPath.Text = "输出路径";
            this.btn_BrowseOutPutPath.UseVisualStyleBackColor = true;
            this.btn_BrowseOutPutPath.Click += new System.EventHandler(this.btn_BrowseOutPutPath_Click);
            // 
            // frmOverlayAnalyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 394);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmOverlayAnalyst";
            this.Text = "frmOverlayAnalyst";
            this.Load += new System.EventHandler(this.frmOverlayAnalyst_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUd_InputPrecisionLevel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_OverlayLayerPrecisionLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUd_Tolerance)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_InPutLayer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nmUd_InputPrecisionLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nmUD_OverlayLayerPrecisionLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_OverlayLayer;
        private System.Windows.Forms.NumericUpDown nmUd_Tolerance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbx_OutPutFeatureType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_OutPutAttributeType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_OverlayAnalystType;
        private System.Windows.Forms.Button btn_BrowseOutPutPath;
    }
}