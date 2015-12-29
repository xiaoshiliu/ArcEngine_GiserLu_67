namespace Giser_Lu
{
    partial class frmPieChartRenderer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPieChartRenderer));
            this.label1 = new System.Windows.Forms.Label();
            this.lstbx_RightFields = new System.Windows.Forms.ListBox();
            this.lstbx_LeftFields = new System.Windows.Forms.ListBox();
            this.btn_AddField = new System.Windows.Forms.Button();
            this.btn_RemoveField = new System.Windows.Forms.Button();
            this.cbx_Layer = new System.Windows.Forms.ComboBox();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_BackGroundColor = new System.Windows.Forms.Button();
            this.btn_RemoveAllFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层:";
            // 
            // lstbx_RightFields
            // 
            this.lstbx_RightFields.FormattingEnabled = true;
            this.lstbx_RightFields.ItemHeight = 12;
            this.lstbx_RightFields.Location = new System.Drawing.Point(172, 33);
            this.lstbx_RightFields.Name = "lstbx_RightFields";
            this.lstbx_RightFields.Size = new System.Drawing.Size(120, 88);
            this.lstbx_RightFields.TabIndex = 3;
            this.lstbx_RightFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstbx_RightFields_MouseDoubleClick);
            // 
            // lstbx_LeftFields
            // 
            this.lstbx_LeftFields.FormattingEnabled = true;
            this.lstbx_LeftFields.ItemHeight = 12;
            this.lstbx_LeftFields.Location = new System.Drawing.Point(12, 33);
            this.lstbx_LeftFields.Name = "lstbx_LeftFields";
            this.lstbx_LeftFields.Size = new System.Drawing.Size(120, 88);
            this.lstbx_LeftFields.TabIndex = 4;
            this.lstbx_LeftFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstbx_LeftFields_MouseDoubleClick);
            // 
            // btn_AddField
            // 
            this.btn_AddField.Location = new System.Drawing.Point(138, 33);
            this.btn_AddField.Name = "btn_AddField";
            this.btn_AddField.Size = new System.Drawing.Size(28, 23);
            this.btn_AddField.TabIndex = 5;
            this.btn_AddField.Text = ">";
            this.btn_AddField.UseVisualStyleBackColor = true;
            this.btn_AddField.Click += new System.EventHandler(this.btn_AddField_Click);
            // 
            // btn_RemoveField
            // 
            this.btn_RemoveField.Location = new System.Drawing.Point(138, 62);
            this.btn_RemoveField.Name = "btn_RemoveField";
            this.btn_RemoveField.Size = new System.Drawing.Size(28, 23);
            this.btn_RemoveField.TabIndex = 6;
            this.btn_RemoveField.Text = "<";
            this.btn_RemoveField.UseVisualStyleBackColor = true;
            this.btn_RemoveField.Click += new System.EventHandler(this.btn_RemoveField_Click);
            // 
            // cbx_Layer
            // 
            this.cbx_Layer.FormattingEnabled = true;
            this.cbx_Layer.Location = new System.Drawing.Point(62, 7);
            this.cbx_Layer.Name = "cbx_Layer";
            this.cbx_Layer.Size = new System.Drawing.Size(226, 20);
            this.cbx_Layer.TabIndex = 7;
            this.cbx_Layer.SelectedIndexChanged += new System.EventHandler(this.cbx_Layer_SelectedIndexChanged);
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(12, 127);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(280, 278);
            this.axSymbologyControl1.TabIndex = 8;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(217, 411);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_BackGroundColor
            // 
            this.btn_BackGroundColor.Location = new System.Drawing.Point(12, 411);
            this.btn_BackGroundColor.Name = "btn_BackGroundColor";
            this.btn_BackGroundColor.Size = new System.Drawing.Size(75, 23);
            this.btn_BackGroundColor.TabIndex = 10;
            this.btn_BackGroundColor.Text = "背景色";
            this.btn_BackGroundColor.UseVisualStyleBackColor = true;
            this.btn_BackGroundColor.Click += new System.EventHandler(this.btn_BackGroundColor_Click);
            // 
            // btn_RemoveAllFields
            // 
            this.btn_RemoveAllFields.Location = new System.Drawing.Point(138, 91);
            this.btn_RemoveAllFields.Name = "btn_RemoveAllFields";
            this.btn_RemoveAllFields.Size = new System.Drawing.Size(28, 23);
            this.btn_RemoveAllFields.TabIndex = 11;
            this.btn_RemoveAllFields.Text = "<<";
            this.btn_RemoveAllFields.UseVisualStyleBackColor = true;
            this.btn_RemoveAllFields.Click += new System.EventHandler(this.btn_RemoveAllFields_Click);
            // 
            // frmPieChartRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 446);
            this.Controls.Add(this.btn_RemoveAllFields);
            this.Controls.Add(this.btn_BackGroundColor);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.axSymbologyControl1);
            this.Controls.Add(this.cbx_Layer);
            this.Controls.Add(this.btn_RemoveField);
            this.Controls.Add(this.btn_AddField);
            this.Controls.Add(this.lstbx_LeftFields);
            this.Controls.Add(this.lstbx_RightFields);
            this.Controls.Add(this.label1);
            this.Name = "frmPieChartRenderer";
            this.Text = "frmPieChartRenderer";
            this.Load += new System.EventHandler(this.frmPieChartRenderer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstbx_RightFields;
        private System.Windows.Forms.ListBox lstbx_LeftFields;
        private System.Windows.Forms.Button btn_AddField;
        private System.Windows.Forms.Button btn_RemoveField;
        private System.Windows.Forms.ComboBox cbx_Layer;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_BackGroundColor;
        private System.Windows.Forms.Button btn_RemoveAllFields;
    }
}