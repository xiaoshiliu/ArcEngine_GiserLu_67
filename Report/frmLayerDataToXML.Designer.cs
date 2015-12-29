using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace DynamicReport
{
    partial class LayerDataToXML
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvDatasets = new System.Windows.Forms.TreeView();
            this.lsvDetails = new System.Windows.Forms.ListView();
            this.btnSelectDataSources = new System.Windows.Forms.Button();
            this.btnLayerDataToXML = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnExportDir = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvDatasets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lsvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(471, 299);
            this.splitContainer1.SplitterDistance = 157;
            this.splitContainer1.TabIndex = 1;
            // 
            // trvDatasets
            // 
            this.trvDatasets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDatasets.HotTracking = true;
            this.trvDatasets.Location = new System.Drawing.Point(0, 0);
            this.trvDatasets.Name = "trvDatasets";
            this.trvDatasets.Size = new System.Drawing.Size(157, 299);
            this.trvDatasets.TabIndex = 0;
            this.trvDatasets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDatasets_AfterSelect);
            // 
            // lsvDetails
            // 
            this.lsvDetails.CheckBoxes = true;
            this.lsvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDetails.Location = new System.Drawing.Point(0, 0);
            this.lsvDetails.Name = "lsvDetails";
            this.lsvDetails.Size = new System.Drawing.Size(310, 299);
            this.lsvDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvDetails.TabIndex = 0;
            this.lsvDetails.UseCompatibleStateImageBehavior = false;
            this.lsvDetails.View = System.Windows.Forms.View.List;
            // 
            // btnSelectDataSources
            // 
            this.btnSelectDataSources.Location = new System.Drawing.Point(48, 9);
            this.btnSelectDataSources.Name = "btnSelectDataSources";
            this.btnSelectDataSources.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDataSources.TabIndex = 2;
            this.btnSelectDataSources.Text = "选择数据源";
            this.btnSelectDataSources.UseVisualStyleBackColor = true;
            this.btnSelectDataSources.Click += new System.EventHandler(this.btnSelectDataSources_Click);
            // 
            // btnLayerDataToXML
            // 
            this.btnLayerDataToXML.Location = new System.Drawing.Point(324, 9);
            this.btnLayerDataToXML.Name = "btnLayerDataToXML";
            this.btnLayerDataToXML.Size = new System.Drawing.Size(100, 23);
            this.btnLayerDataToXML.TabIndex = 3;
            this.btnLayerDataToXML.Text = "输出为报表数据";
            this.btnLayerDataToXML.UseVisualStyleBackColor = true;
            this.btnLayerDataToXML.Click += new System.EventHandler(this.btnLayerDataToXML_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 4;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "选择报表数据文件输出位置";
            // 
            // btnExportDir
            // 
            this.btnExportDir.Location = new System.Drawing.Point(167, 9);
            this.btnExportDir.Name = "btnExportDir";
            this.btnExportDir.Size = new System.Drawing.Size(113, 23);
            this.btnExportDir.TabIndex = 2;
            this.btnExportDir.Text = "设置输出目标路径";
            this.btnExportDir.UseVisualStyleBackColor = true;
            this.btnExportDir.Click += new System.EventHandler(this.btnExportDir_Click);
            // 
            // LayerDataToXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLayerDataToXML);
            this.Controls.Add(this.btnExportDir);
            this.Controls.Add(this.btnSelectDataSources);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LayerDataToXML";
            this.Text = "要素类数据输出为报表数据格式";
            this.Load += new System.EventHandler(this.LayerDataToXML_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvDatasets;
        private System.Windows.Forms.ListView lsvDetails;
        private System.Windows.Forms.Button btnSelectDataSources;
        private System.Windows.Forms.Button btnLayerDataToXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnExportDir;
    }
}