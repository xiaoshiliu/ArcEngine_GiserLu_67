namespace Giser_Lu
{
    partial class frmSelectionByLocation
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
            this.chxlstbx_SelecteFeatureInLayer = new System.Windows.Forms.CheckedListBox();
            this.cbx_SelectMethod = new System.Windows.Forms.ComboBox();
            this.lbl_SelectMethod = new System.Windows.Forms.Label();
            this.lbl_FormLayer = new System.Windows.Forms.Label();
            this.lbl_RelationShip = new System.Windows.Forms.Label();
            this.cbx_SelectRelationShip = new System.Windows.Forms.ComboBox();
            this.lbl_InLayer = new System.Windows.Forms.Label();
            this.cbx_InTheLayer = new System.Windows.Forms.ComboBox();
            this.chx_OnlySelectedFeatures = new System.Windows.Forms.CheckBox();
            this.lbl_TotalFeatureS = new System.Windows.Forms.Label();
            this.nmUD_Distance = new System.Windows.Forms.NumericUpDown();
            this.chx_BufferDistance = new System.Windows.Forms.CheckBox();
            this.cbx_Units = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_Distance)).BeginInit();
            this.SuspendLayout();
            // 
            // chxlstbx_SelecteFeatureInLayer
            // 
            this.chxlstbx_SelecteFeatureInLayer.CheckOnClick = true;
            this.chxlstbx_SelecteFeatureInLayer.FormattingEnabled = true;
            this.chxlstbx_SelecteFeatureInLayer.Location = new System.Drawing.Point(3, 81);
            this.chxlstbx_SelecteFeatureInLayer.Name = "chxlstbx_SelecteFeatureInLayer";
            this.chxlstbx_SelecteFeatureInLayer.Size = new System.Drawing.Size(334, 164);
            this.chxlstbx_SelecteFeatureInLayer.TabIndex = 0;
            this.chxlstbx_SelecteFeatureInLayer.SelectedIndexChanged += new System.EventHandler(this.chxlstbx_SelecteFeatureInLayer_SelectedIndexChanged);
            // 
            // cbx_SelectMethod
            // 
            this.cbx_SelectMethod.FormattingEnabled = true;
            this.cbx_SelectMethod.Items.AddRange(new object[] {
            "创建新的查询",
            "加入现有查询",
            "从现有查询中移去",
            "在现有查询中查询"});
            this.cbx_SelectMethod.Location = new System.Drawing.Point(3, 26);
            this.cbx_SelectMethod.Name = "cbx_SelectMethod";
            this.cbx_SelectMethod.Size = new System.Drawing.Size(334, 20);
            this.cbx_SelectMethod.TabIndex = 1;
            this.cbx_SelectMethod.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectMethod_SelectedIndexChanged);
            // 
            // lbl_SelectMethod
            // 
            this.lbl_SelectMethod.AutoSize = true;
            this.lbl_SelectMethod.Location = new System.Drawing.Point(3, 7);
            this.lbl_SelectMethod.Name = "lbl_SelectMethod";
            this.lbl_SelectMethod.Size = new System.Drawing.Size(29, 12);
            this.lbl_SelectMethod.TabIndex = 2;
            this.lbl_SelectMethod.Text = "我想";
            // 
            // lbl_FormLayer
            // 
            this.lbl_FormLayer.Location = new System.Drawing.Point(3, 49);
            this.lbl_FormLayer.Name = "lbl_FormLayer";
            this.lbl_FormLayer.Size = new System.Drawing.Size(334, 29);
            this.lbl_FormLayer.TabIndex = 5;
            this.lbl_FormLayer.Text = "从";
            // 
            // lbl_RelationShip
            // 
            this.lbl_RelationShip.AutoSize = true;
            this.lbl_RelationShip.Location = new System.Drawing.Point(3, 248);
            this.lbl_RelationShip.Name = "lbl_RelationShip";
            this.lbl_RelationShip.Size = new System.Drawing.Size(53, 12);
            this.lbl_RelationShip.TabIndex = 6;
            this.lbl_RelationShip.Text = "用某关系";
            // 
            // cbx_SelectRelationShip
            // 
            this.cbx_SelectRelationShip.FormattingEnabled = true;
            this.cbx_SelectRelationShip.Items.AddRange(new object[] {
            "相交",
            "外包络多边形相交",
            "外包络多边形索引相交",
            "共享边界(不能用于点要素与点要素)",
            "重叠(只能用于相同类型要素,点/点除外)",
            "返回更低维度的共有部分(线/线,线/面,多点/面,多点/线)  ",
            "包含",
            "完全包含"});
            this.cbx_SelectRelationShip.Location = new System.Drawing.Point(3, 266);
            this.cbx_SelectRelationShip.Name = "cbx_SelectRelationShip";
            this.cbx_SelectRelationShip.Size = new System.Drawing.Size(334, 20);
            this.cbx_SelectRelationShip.TabIndex = 7;
            this.cbx_SelectRelationShip.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectRelationShip_SelectedIndexChanged);
            // 
            // lbl_InLayer
            // 
            this.lbl_InLayer.AutoSize = true;
            this.lbl_InLayer.Location = new System.Drawing.Point(3, 289);
            this.lbl_InLayer.Name = "lbl_InLayer";
            this.lbl_InLayer.Size = new System.Drawing.Size(65, 12);
            this.lbl_InLayer.TabIndex = 8;
            this.lbl_InLayer.Text = "在某图层中";
            // 
            // cbx_InTheLayer
            // 
            this.cbx_InTheLayer.FormattingEnabled = true;
            this.cbx_InTheLayer.Location = new System.Drawing.Point(3, 306);
            this.cbx_InTheLayer.Name = "cbx_InTheLayer";
            this.cbx_InTheLayer.Size = new System.Drawing.Size(334, 20);
            this.cbx_InTheLayer.TabIndex = 9;
            this.cbx_InTheLayer.SelectedIndexChanged += new System.EventHandler(this.cbx_InTheLayer_SelectedIndexChanged);
            // 
            // chx_OnlySelectedFeatures
            // 
            this.chx_OnlySelectedFeatures.AutoSize = true;
            this.chx_OnlySelectedFeatures.Location = new System.Drawing.Point(3, 332);
            this.chx_OnlySelectedFeatures.Name = "chx_OnlySelectedFeatures";
            this.chx_OnlySelectedFeatures.Size = new System.Drawing.Size(108, 16);
            this.chx_OnlySelectedFeatures.TabIndex = 10;
            this.chx_OnlySelectedFeatures.Text = "在选中的要素中";
            this.chx_OnlySelectedFeatures.UseVisualStyleBackColor = true;
            this.chx_OnlySelectedFeatures.CheckedChanged += new System.EventHandler(this.chx_OnlySelectedFeatures_CheckedChanged);
            // 
            // lbl_TotalFeatureS
            // 
            this.lbl_TotalFeatureS.AutoSize = true;
            this.lbl_TotalFeatureS.Location = new System.Drawing.Point(156, 333);
            this.lbl_TotalFeatureS.Name = "lbl_TotalFeatureS";
            this.lbl_TotalFeatureS.Size = new System.Drawing.Size(0, 12);
            this.lbl_TotalFeatureS.TabIndex = 11;
            // 
            // nmUD_Distance
            // 
            this.nmUD_Distance.Location = new System.Drawing.Point(3, 384);
            this.nmUD_Distance.Name = "nmUD_Distance";
            this.nmUD_Distance.Size = new System.Drawing.Size(120, 21);
            this.nmUD_Distance.TabIndex = 12;
            // 
            // chx_BufferDistance
            // 
            this.chx_BufferDistance.AutoSize = true;
            this.chx_BufferDistance.Location = new System.Drawing.Point(3, 362);
            this.chx_BufferDistance.Name = "chx_BufferDistance";
            this.chx_BufferDistance.Size = new System.Drawing.Size(84, 16);
            this.chx_BufferDistance.TabIndex = 13;
            this.chx_BufferDistance.Text = "在距某图层";
            this.chx_BufferDistance.UseVisualStyleBackColor = true;
            // 
            // cbx_Units
            // 
            this.cbx_Units.FormattingEnabled = true;
            this.cbx_Units.Location = new System.Drawing.Point(129, 385);
            this.cbx_Units.Name = "cbx_Units";
            this.cbx_Units.Size = new System.Drawing.Size(121, 20);
            this.cbx_Units.TabIndex = 14;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(262, 382);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 15;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frmSelectionByLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 414);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cbx_Units);
            this.Controls.Add(this.chx_BufferDistance);
            this.Controls.Add(this.nmUD_Distance);
            this.Controls.Add(this.lbl_TotalFeatureS);
            this.Controls.Add(this.chx_OnlySelectedFeatures);
            this.Controls.Add(this.cbx_InTheLayer);
            this.Controls.Add(this.lbl_InLayer);
            this.Controls.Add(this.cbx_SelectRelationShip);
            this.Controls.Add(this.lbl_RelationShip);
            this.Controls.Add(this.lbl_FormLayer);
            this.Controls.Add(this.lbl_SelectMethod);
            this.Controls.Add(this.cbx_SelectMethod);
            this.Controls.Add(this.chxlstbx_SelecteFeatureInLayer);
            this.Name = "frmSelectionByLocation";
            this.Text = "frmSelectionByLocation";
            this.Load += new System.EventHandler(this.frmSelectionByLocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmUD_Distance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chxlstbx_SelecteFeatureInLayer;
        private System.Windows.Forms.ComboBox cbx_SelectMethod;
        private System.Windows.Forms.Label lbl_SelectMethod;
        private System.Windows.Forms.Label lbl_FormLayer;
        private System.Windows.Forms.Label lbl_RelationShip;
        private System.Windows.Forms.ComboBox cbx_SelectRelationShip;
        private System.Windows.Forms.Label lbl_InLayer;
        private System.Windows.Forms.ComboBox cbx_InTheLayer;
        private System.Windows.Forms.CheckBox chx_OnlySelectedFeatures;
        private System.Windows.Forms.Label lbl_TotalFeatureS;
        private System.Windows.Forms.NumericUpDown nmUD_Distance;
        private System.Windows.Forms.CheckBox chx_BufferDistance;
        private System.Windows.Forms.ComboBox cbx_Units;
        private System.Windows.Forms.Button btn_OK;
    }
}