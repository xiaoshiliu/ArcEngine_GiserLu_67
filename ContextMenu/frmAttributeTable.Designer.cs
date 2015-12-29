namespace Giser_Lu
{
    partial class frmAttributeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttributeTable));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl_Count = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuslbl_selectedrows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.选择全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除选中行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.只显示选中行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(487, 554);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl_Count,
            this.statuslbl_selectedrows,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLbl_Count
            // 
            this.statusLbl_Count.Name = "statusLbl_Count";
            this.statusLbl_Count.Size = new System.Drawing.Size(53, 17);
            this.statusLbl_Count.Text = "全部记录";
            // 
            // statuslbl_selectedrows
            // 
            this.statuslbl_selectedrows.Name = "statuslbl_selectedrows";
            this.statuslbl_selectedrows.Size = new System.Drawing.Size(29, 17);
            this.statuslbl_selectedrows.Text = "选中";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择全部ToolStripMenuItem,
            this.清除选中行ToolStripMenuItem,
            this.只显示选中行ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(45, 20);
            this.toolStripSplitButton1.Text = "选项";
            // 
            // 选择全部ToolStripMenuItem
            // 
            this.选择全部ToolStripMenuItem.Name = "选择全部ToolStripMenuItem";
            this.选择全部ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.选择全部ToolStripMenuItem.Text = "选择全部";
            this.选择全部ToolStripMenuItem.Click += new System.EventHandler(this.选择全部ToolStripMenuItem_Click);
            // 
            // 清除选中行ToolStripMenuItem
            // 
            this.清除选中行ToolStripMenuItem.Name = "清除选中行ToolStripMenuItem";
            this.清除选中行ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.清除选中行ToolStripMenuItem.Text = "取消选中行";
            this.清除选中行ToolStripMenuItem.Click += new System.EventHandler(this.清除选中行ToolStripMenuItem_Click);
            // 
            // 只显示选中行ToolStripMenuItem
            // 
            this.只显示选中行ToolStripMenuItem.Name = "只显示选中行ToolStripMenuItem";
            this.只显示选中行ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.只显示选中行ToolStripMenuItem.Text = "只显示选中行";
            this.只显示选中行ToolStripMenuItem.Click += new System.EventHandler(this.只显示选中行ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem1.Text = "显示全部";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // frmAttributeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(487, 554);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmAttributeTable";
            this.Text = "frmAttributeTable";
            this.Load += new System.EventHandler(this.frmAttributeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl_Count;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl_selectedrows;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem 清除选中行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 只显示选中行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}