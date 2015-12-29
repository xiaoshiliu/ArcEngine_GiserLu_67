namespace Giser_Lu
{
    partial class frmBufferAnalyst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBufferAnalyst));
            this.cbx_Layer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_Distance = new System.Windows.Forms.RadioButton();
            this.rdb_Field = new System.Windows.Forms.RadioButton();
            this.rdb_Ring = new System.Windows.Forms.RadioButton();
            this.nmUD_Distance = new System.Windows.Forms.NumericUpDown();
            this.lbl_DistanceUnit = new System.Windows.Forms.Label();
            this.cbx_Field = new System.Windows.Forms.ComboBox();
            this.lbl_FieldUnit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nmud_TotalRings = new System.Windows.Forms.NumericUpDown();
            this.nmUD_DistanceOfEachRing = new System.Windows.Forms.NumericUpDown();
            this.lbl_RingUnit = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_GlobalUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdb_DissolveTrue = new System.Windows.Forms.RadioButton();
            this.rdb_DissovleFalse = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdb_PolygonInsideAndOutSide = new System.Windows.Forms.RadioButton();
            this.rdb_PolygonOutSide = new System.Windows.Forms.RadioButton();
            this.rdb_PolygonInside = new System.Windows.Forms.RadioButton();
            this.rdb_PolygonOutSideAndIncludeInSide = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdb_SaveAsGraphics = new System.Windows.Forms.RadioButton();
            this.rdb_SaveAsShapeFile = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_BrowsePathOfSaveShp = new System.Windows.Forms.Button();
            this.txtbx_TestPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_Waiting = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_Distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_TotalRings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_DistanceOfEachRing)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_Layer
            // 
            this.cbx_Layer.FormattingEnabled = true;
            this.cbx_Layer.Location = new System.Drawing.Point(53, 6);
            this.cbx_Layer.Name = "cbx_Layer";
            this.cbx_Layer.Size = new System.Drawing.Size(344, 20);
            this.cbx_Layer.TabIndex = 0;
            this.cbx_Layer.SelectedIndexChanged += new System.EventHandler(this.cbx_Layer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图层:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_RingUnit);
            this.groupBox1.Controls.Add(this.nmUD_DistanceOfEachRing);
            this.groupBox1.Controls.Add(this.nmud_TotalRings);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbl_FieldUnit);
            this.groupBox1.Controls.Add(this.cbx_Field);
            this.groupBox1.Controls.Add(this.lbl_DistanceUnit);
            this.groupBox1.Controls.Add(this.nmUD_Distance);
            this.groupBox1.Controls.Add(this.rdb_Ring);
            this.groupBox1.Controls.Add(this.rdb_Field);
            this.groupBox1.Controls.Add(this.rdb_Distance);
            this.groupBox1.Location = new System.Drawing.Point(14, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 184);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "缓冲方式";
            // 
            // rdb_Distance
            // 
            this.rdb_Distance.AutoSize = true;
            this.rdb_Distance.Checked = true;
            this.rdb_Distance.Location = new System.Drawing.Point(19, 20);
            this.rdb_Distance.Name = "rdb_Distance";
            this.rdb_Distance.Size = new System.Drawing.Size(53, 16);
            this.rdb_Distance.TabIndex = 0;
            this.rdb_Distance.TabStop = true;
            this.rdb_Distance.Text = "距离:";
            this.rdb_Distance.UseVisualStyleBackColor = true;
            // 
            // rdb_Field
            // 
            this.rdb_Field.AutoSize = true;
            this.rdb_Field.Location = new System.Drawing.Point(19, 47);
            this.rdb_Field.Name = "rdb_Field";
            this.rdb_Field.Size = new System.Drawing.Size(53, 16);
            this.rdb_Field.TabIndex = 1;
            this.rdb_Field.Text = "字段:";
            this.rdb_Field.UseVisualStyleBackColor = true;
            // 
            // rdb_Ring
            // 
            this.rdb_Ring.AutoSize = true;
            this.rdb_Ring.Location = new System.Drawing.Point(19, 103);
            this.rdb_Ring.Name = "rdb_Ring";
            this.rdb_Ring.Size = new System.Drawing.Size(59, 16);
            this.rdb_Ring.TabIndex = 2;
            this.rdb_Ring.Text = "缓冲环";
            this.rdb_Ring.UseVisualStyleBackColor = true;
            // 
            // nmUD_Distance
            // 
            this.nmUD_Distance.Location = new System.Drawing.Point(69, 17);
            this.nmUD_Distance.Name = "nmUD_Distance";
            this.nmUD_Distance.Size = new System.Drawing.Size(78, 21);
            this.nmUD_Distance.TabIndex = 3;
            this.nmUD_Distance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_DistanceUnit
            // 
            this.lbl_DistanceUnit.AutoSize = true;
            this.lbl_DistanceUnit.Location = new System.Drawing.Point(149, 24);
            this.lbl_DistanceUnit.Name = "lbl_DistanceUnit";
            this.lbl_DistanceUnit.Size = new System.Drawing.Size(41, 12);
            this.lbl_DistanceUnit.TabIndex = 4;
            this.lbl_DistanceUnit.Text = "label2";
            // 
            // cbx_Field
            // 
            this.cbx_Field.FormattingEnabled = true;
            this.cbx_Field.Location = new System.Drawing.Point(19, 69);
            this.cbx_Field.Name = "cbx_Field";
            this.cbx_Field.Size = new System.Drawing.Size(128, 20);
            this.cbx_Field.TabIndex = 5;
            // 
            // lbl_FieldUnit
            // 
            this.lbl_FieldUnit.AutoSize = true;
            this.lbl_FieldUnit.Location = new System.Drawing.Point(149, 73);
            this.lbl_FieldUnit.Name = "lbl_FieldUnit";
            this.lbl_FieldUnit.Size = new System.Drawing.Size(41, 12);
            this.lbl_FieldUnit.TabIndex = 6;
            this.lbl_FieldUnit.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数量:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "间距:";
            // 
            // nmud_TotalRings
            // 
            this.nmud_TotalRings.Location = new System.Drawing.Point(77, 125);
            this.nmud_TotalRings.Name = "nmud_TotalRings";
            this.nmud_TotalRings.Size = new System.Drawing.Size(70, 21);
            this.nmud_TotalRings.TabIndex = 9;
            // 
            // nmUD_DistanceOfEachRing
            // 
            this.nmUD_DistanceOfEachRing.Location = new System.Drawing.Point(77, 152);
            this.nmUD_DistanceOfEachRing.Name = "nmUD_DistanceOfEachRing";
            this.nmUD_DistanceOfEachRing.Size = new System.Drawing.Size(70, 21);
            this.nmUD_DistanceOfEachRing.TabIndex = 10;
            // 
            // lbl_RingUnit
            // 
            this.lbl_RingUnit.AutoSize = true;
            this.lbl_RingUnit.Location = new System.Drawing.Point(149, 158);
            this.lbl_RingUnit.Name = "lbl_RingUnit";
            this.lbl_RingUnit.Size = new System.Drawing.Size(41, 12);
            this.lbl_RingUnit.TabIndex = 11;
            this.lbl_RingUnit.Text = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbx_GlobalUnit);
            this.groupBox2.Location = new System.Drawing.Point(14, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 53);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "距离单位";
            // 
            // cbx_GlobalUnit
            // 
            this.cbx_GlobalUnit.FormattingEnabled = true;
            this.cbx_GlobalUnit.Items.AddRange(new object[] {
            "Unknown",
            "Inches",
            "Points",
            "Feet",
            "Yards",
            "Miles",
            "NauticalMiles",
            "Millimeters",
            "Centimeters",
            "Meters",
            "Kilometers",
            "DecimalDegrees",
            "Decimeters"});
            this.cbx_GlobalUnit.Location = new System.Drawing.Point(89, 20);
            this.cbx_GlobalUnit.Name = "cbx_GlobalUnit";
            this.cbx_GlobalUnit.Size = new System.Drawing.Size(121, 20);
            this.cbx_GlobalUnit.TabIndex = 0;
            this.cbx_GlobalUnit.SelectedIndexChanged += new System.EventHandler(this.cbx_GlobalUnit_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "缓冲单位:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdb_DissovleFalse);
            this.groupBox3.Controls.Add(this.rdb_DissolveTrue);
            this.groupBox3.Location = new System.Drawing.Point(261, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 54);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "融合";
            // 
            // rdb_DissolveTrue
            // 
            this.rdb_DissolveTrue.AutoSize = true;
            this.rdb_DissolveTrue.Checked = true;
            this.rdb_DissolveTrue.Location = new System.Drawing.Point(18, 22);
            this.rdb_DissolveTrue.Name = "rdb_DissolveTrue";
            this.rdb_DissolveTrue.Size = new System.Drawing.Size(35, 16);
            this.rdb_DissolveTrue.TabIndex = 0;
            this.rdb_DissolveTrue.TabStop = true;
            this.rdb_DissolveTrue.Text = "是";
            this.rdb_DissolveTrue.UseVisualStyleBackColor = true;
            // 
            // rdb_DissovleFalse
            // 
            this.rdb_DissovleFalse.AutoSize = true;
            this.rdb_DissovleFalse.Location = new System.Drawing.Point(59, 22);
            this.rdb_DissovleFalse.Name = "rdb_DissovleFalse";
            this.rdb_DissovleFalse.Size = new System.Drawing.Size(35, 16);
            this.rdb_DissovleFalse.TabIndex = 1;
            this.rdb_DissovleFalse.Text = "否";
            this.rdb_DissovleFalse.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdb_PolygonOutSideAndIncludeInSide);
            this.groupBox4.Controls.Add(this.rdb_PolygonInside);
            this.groupBox4.Controls.Add(this.rdb_PolygonOutSide);
            this.groupBox4.Controls.Add(this.rdb_PolygonInsideAndOutSide);
            this.groupBox4.Location = new System.Drawing.Point(261, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 106);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "多边形缓冲方式";
            // 
            // rdb_PolygonInsideAndOutSide
            // 
            this.rdb_PolygonInsideAndOutSide.AutoSize = true;
            this.rdb_PolygonInsideAndOutSide.Checked = true;
            this.rdb_PolygonInsideAndOutSide.Location = new System.Drawing.Point(16, 20);
            this.rdb_PolygonInsideAndOutSide.Name = "rdb_PolygonInsideAndOutSide";
            this.rdb_PolygonInsideAndOutSide.Size = new System.Drawing.Size(83, 16);
            this.rdb_PolygonInsideAndOutSide.TabIndex = 0;
            this.rdb_PolygonInsideAndOutSide.TabStop = true;
            this.rdb_PolygonInsideAndOutSide.Text = "内部与外部";
            this.rdb_PolygonInsideAndOutSide.UseVisualStyleBackColor = true;
            // 
            // rdb_PolygonOutSide
            // 
            this.rdb_PolygonOutSide.AutoSize = true;
            this.rdb_PolygonOutSide.Location = new System.Drawing.Point(16, 38);
            this.rdb_PolygonOutSide.Name = "rdb_PolygonOutSide";
            this.rdb_PolygonOutSide.Size = new System.Drawing.Size(71, 16);
            this.rdb_PolygonOutSide.TabIndex = 1;
            this.rdb_PolygonOutSide.Text = "只是外部";
            this.rdb_PolygonOutSide.UseVisualStyleBackColor = true;
            // 
            // rdb_PolygonInside
            // 
            this.rdb_PolygonInside.AutoSize = true;
            this.rdb_PolygonInside.Location = new System.Drawing.Point(16, 60);
            this.rdb_PolygonInside.Name = "rdb_PolygonInside";
            this.rdb_PolygonInside.Size = new System.Drawing.Size(71, 16);
            this.rdb_PolygonInside.TabIndex = 2;
            this.rdb_PolygonInside.Text = "只是内部";
            this.rdb_PolygonInside.UseVisualStyleBackColor = true;
            // 
            // rdb_PolygonOutSideAndIncludeInSide
            // 
            this.rdb_PolygonOutSideAndIncludeInSide.AutoSize = true;
            this.rdb_PolygonOutSideAndIncludeInSide.Location = new System.Drawing.Point(16, 79);
            this.rdb_PolygonOutSideAndIncludeInSide.Name = "rdb_PolygonOutSideAndIncludeInSide";
            this.rdb_PolygonOutSideAndIncludeInSide.Size = new System.Drawing.Size(107, 16);
            this.rdb_PolygonOutSideAndIncludeInSide.TabIndex = 3;
            this.rdb_PolygonOutSideAndIncludeInSide.Text = "外部与整个内部";
            this.rdb_PolygonOutSideAndIncludeInSide.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_BrowsePathOfSaveShp);
            this.groupBox5.Controls.Add(this.rdb_SaveAsShapeFile);
            this.groupBox5.Controls.Add(this.rdb_SaveAsGraphics);
            this.groupBox5.Location = new System.Drawing.Point(261, 205);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(136, 64);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "保存方式";
            // 
            // rdb_SaveAsGraphics
            // 
            this.rdb_SaveAsGraphics.AutoSize = true;
            this.rdb_SaveAsGraphics.Location = new System.Drawing.Point(18, 20);
            this.rdb_SaveAsGraphics.Name = "rdb_SaveAsGraphics";
            this.rdb_SaveAsGraphics.Size = new System.Drawing.Size(71, 16);
            this.rdb_SaveAsGraphics.TabIndex = 0;
            this.rdb_SaveAsGraphics.Text = "存为图形";
            this.rdb_SaveAsGraphics.UseVisualStyleBackColor = true;
            // 
            // rdb_SaveAsShapeFile
            // 
            this.rdb_SaveAsShapeFile.AutoSize = true;
            this.rdb_SaveAsShapeFile.Checked = true;
            this.rdb_SaveAsShapeFile.Location = new System.Drawing.Point(18, 42);
            this.rdb_SaveAsShapeFile.Name = "rdb_SaveAsShapeFile";
            this.rdb_SaveAsShapeFile.Size = new System.Drawing.Size(65, 16);
            this.rdb_SaveAsShapeFile.TabIndex = 1;
            this.rdb_SaveAsShapeFile.TabStop = true;
            this.rdb_SaveAsShapeFile.Text = "存为Shp";
            this.rdb_SaveAsShapeFile.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(322, 275);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_BrowsePathOfSaveShp
            // 
            this.btn_BrowsePathOfSaveShp.Location = new System.Drawing.Point(89, 40);
            this.btn_BrowsePathOfSaveShp.Name = "btn_BrowsePathOfSaveShp";
            this.btn_BrowsePathOfSaveShp.Size = new System.Drawing.Size(34, 18);
            this.btn_BrowsePathOfSaveShp.TabIndex = 2;
            this.btn_BrowsePathOfSaveShp.Text = "...";
            this.btn_BrowsePathOfSaveShp.UseVisualStyleBackColor = true;
            this.btn_BrowsePathOfSaveShp.Click += new System.EventHandler(this.btn_BrowsePathOfSaveShp_Click);
            // 
            // txtbx_TestPath
            // 
            this.txtbx_TestPath.Location = new System.Drawing.Point(12, 275);
            this.txtbx_TestPath.Name = "txtbx_TestPath";
            this.txtbx_TestPath.Size = new System.Drawing.Size(304, 21);
            this.txtbx_TestPath.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_Waiting});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(405, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_Waiting
            // 
            this.status_Waiting.Image = ((System.Drawing.Image)(resources.GetObject("status_Waiting.Image")));
            this.status_Waiting.Name = "status_Waiting";
            this.status_Waiting.Size = new System.Drawing.Size(69, 17);
            this.status_Waiting.Text = "缓冲完毕";
            this.status_Waiting.Visible = false;
            // 
            // frmBufferAnalyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 323);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtbx_TestPath);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Layer);
            this.Name = "frmBufferAnalyst";
            this.Text = "frmBufferAnalyst";
            this.Load += new System.EventHandler(this.frmBufferAnalyst_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_Distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmud_TotalRings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_DistanceOfEachRing)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Layer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_RingUnit;
        private System.Windows.Forms.NumericUpDown nmUD_DistanceOfEachRing;
        private System.Windows.Forms.NumericUpDown nmud_TotalRings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_FieldUnit;
        private System.Windows.Forms.ComboBox cbx_Field;
        private System.Windows.Forms.Label lbl_DistanceUnit;
        private System.Windows.Forms.NumericUpDown nmUD_Distance;
        private System.Windows.Forms.RadioButton rdb_Ring;
        private System.Windows.Forms.RadioButton rdb_Field;
        private System.Windows.Forms.RadioButton rdb_Distance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_GlobalUnit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdb_DissovleFalse;
        private System.Windows.Forms.RadioButton rdb_DissolveTrue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdb_PolygonOutSideAndIncludeInSide;
        private System.Windows.Forms.RadioButton rdb_PolygonInside;
        private System.Windows.Forms.RadioButton rdb_PolygonOutSide;
        private System.Windows.Forms.RadioButton rdb_PolygonInsideAndOutSide;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdb_SaveAsShapeFile;
        private System.Windows.Forms.RadioButton rdb_SaveAsGraphics;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_BrowsePathOfSaveShp;
        private System.Windows.Forms.TextBox txtbx_TestPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_Waiting;

    }
}