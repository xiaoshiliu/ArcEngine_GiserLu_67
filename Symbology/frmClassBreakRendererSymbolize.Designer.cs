namespace Giser_Lu
{
    partial class frmClassBreakRendererSymbolize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassBreakRendererSymbolize));
            this.cbx_Layer = new System.Windows.Forms.ComboBox();
            this.cbx_Field = new System.Windows.Forms.ComboBox();
            this.numUD_TotalClasses = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_TotalClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_Layer
            // 
            this.cbx_Layer.FormattingEnabled = true;
            this.cbx_Layer.Location = new System.Drawing.Point(43, 14);
            this.cbx_Layer.Name = "cbx_Layer";
            this.cbx_Layer.Size = new System.Drawing.Size(228, 20);
            this.cbx_Layer.TabIndex = 0;
            this.cbx_Layer.SelectedIndexChanged += new System.EventHandler(this.cbx_Layer_SelectedIndexChanged);
            // 
            // cbx_Field
            // 
            this.cbx_Field.FormattingEnabled = true;
            this.cbx_Field.Location = new System.Drawing.Point(43, 40);
            this.cbx_Field.Name = "cbx_Field";
            this.cbx_Field.Size = new System.Drawing.Size(228, 20);
            this.cbx_Field.TabIndex = 1;
            this.cbx_Field.SelectedIndexChanged += new System.EventHandler(this.cbx_Field_SelectedIndexChanged);
            // 
            // numUD_TotalClasses
            // 
            this.numUD_TotalClasses.Location = new System.Drawing.Point(336, 13);
            this.numUD_TotalClasses.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_TotalClasses.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUD_TotalClasses.Name = "numUD_TotalClasses";
            this.numUD_TotalClasses.Size = new System.Drawing.Size(40, 21);
            this.numUD_TotalClasses.TabIndex = 2;
            this.numUD_TotalClasses.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "图层:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "字段:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "分类数:";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(301, 40);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(3, 69);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(391, 448);
            this.axSymbologyControl1.TabIndex = 7;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // frmClassBreakRendererSymbolize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 519);
            this.Controls.Add(this.axSymbologyControl1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numUD_TotalClasses);
            this.Controls.Add(this.cbx_Field);
            this.Controls.Add(this.cbx_Layer);
            this.Name = "frmClassBreakRendererSymbolize";
            this.Text = "frmClassBreakRendererSymbolize";
            this.Load += new System.EventHandler(this.frmClassBreakRendererSymbolize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUD_TotalClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Layer;
        private System.Windows.Forms.ComboBox cbx_Field;
        private System.Windows.Forms.NumericUpDown numUD_TotalClasses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ok;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
    }
}