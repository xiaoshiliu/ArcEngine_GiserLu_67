// Copyright 2006 ESRI
//
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
//
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
//
// See use restrictions at /arcgis/developerkit/userestrictions.

using System;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;

namespace Giser_Lu
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmPrint : System.Windows.Forms.Form
    {
		public System.Windows.Forms.GroupBox Frame2;
		public System.Windows.Forms.RadioButton optLandscape;
		public System.Windows.Forms.RadioButton optPortrait;
		public System.Windows.Forms.ComboBox cboPageToPrinterMapping;
		public System.Windows.Forms.ComboBox cboPageSize;
		public System.Windows.Forms.Label lblPageCount;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.GroupBox fraPrint;
		public System.Windows.Forms.TextBox txbOverlap;
		public System.Windows.Forms.Button cmdPrint;
		public System.Windows.Forms.TextBox txbStartPage;
		public System.Windows.Forms.TextBox txbEndPage;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.GroupBox fraPrinter;
		public System.Windows.Forms.Label lblPrinterOrientation;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label lblPrinterName;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label lblPrinterSize;
		public System.Windows.Forms.Label lblPdcdcrinter;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private AxLicenseControl axLicenseControl1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private IPageLayoutControlDefault m_PageLayoutControl;
        //private IMapControlDefault m_MapControl;

		public frmPrint(IPageLayoutControlDefault page)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            m_PageLayoutControl = page;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            //Release COM objects
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.optLandscape = new System.Windows.Forms.RadioButton();
            this.optPortrait = new System.Windows.Forms.RadioButton();
            this.cboPageToPrinterMapping = new System.Windows.Forms.ComboBox();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.fraPrint = new System.Windows.Forms.GroupBox();
            this.txbOverlap = new System.Windows.Forms.TextBox();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.txbStartPage = new System.Windows.Forms.TextBox();
            this.txbEndPage = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.fraPrinter = new System.Windows.Forms.GroupBox();
            this.lblPrinterOrientation = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblPrinterSize = new System.Windows.Forms.Label();
            this.lblPdcdcrinter = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.Frame2.SuspendLayout();
            this.fraPrint.SuspendLayout();
            this.fraPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame2
            // 
            this.Frame2.BackColor = System.Drawing.SystemColors.Control;
            this.Frame2.Controls.Add(this.optLandscape);
            this.Frame2.Controls.Add(this.optPortrait);
            this.Frame2.Controls.Add(this.cboPageToPrinterMapping);
            this.Frame2.Controls.Add(this.cboPageSize);
            this.Frame2.Controls.Add(this.lblPageCount);
            this.Frame2.Controls.Add(this.Label9);
            this.Frame2.Controls.Add(this.Label8);
            this.Frame2.Controls.Add(this.Label6);
            this.Frame2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame2.Location = new System.Drawing.Point(326, 9);
            this.Frame2.Name = "Frame2";
            this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame2.Size = new System.Drawing.Size(273, 192);
            this.Frame2.TabIndex = 19;
            this.Frame2.TabStop = false;
            this.Frame2.Text = "页面设置";
            // 
            // optLandscape
            // 
            this.optLandscape.BackColor = System.Drawing.SystemColors.Control;
            this.optLandscape.Cursor = System.Windows.Forms.Cursors.Default;
            this.optLandscape.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLandscape.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optLandscape.Location = new System.Drawing.Point(89, 129);
            this.optLandscape.Name = "optLandscape";
            this.optLandscape.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optLandscape.Size = new System.Drawing.Size(174, 27);
            this.optLandscape.TabIndex = 22;
            this.optLandscape.TabStop = true;
            this.optLandscape.Text = "风景";
            this.optLandscape.UseVisualStyleBackColor = false;
            this.optLandscape.Click += new System.EventHandler(this.optLandscape_Click);
            // 
            // optPortrait
            // 
            this.optPortrait.BackColor = System.Drawing.SystemColors.Control;
            this.optPortrait.Cursor = System.Windows.Forms.Cursors.Default;
            this.optPortrait.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPortrait.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optPortrait.Location = new System.Drawing.Point(10, 129);
            this.optPortrait.Name = "optPortrait";
            this.optPortrait.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optPortrait.Size = new System.Drawing.Size(119, 27);
            this.optPortrait.TabIndex = 21;
            this.optPortrait.TabStop = true;
            this.optPortrait.Text = "肖像";
            this.optPortrait.UseVisualStyleBackColor = false;
            this.optPortrait.Click += new System.EventHandler(this.optPortrait_Click);
            // 
            // cboPageToPrinterMapping
            // 
            this.cboPageToPrinterMapping.BackColor = System.Drawing.SystemColors.Window;
            this.cboPageToPrinterMapping.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboPageToPrinterMapping.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPageToPrinterMapping.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPageToPrinterMapping.Location = new System.Drawing.Point(10, 95);
            this.cboPageToPrinterMapping.Name = "cboPageToPrinterMapping";
            this.cboPageToPrinterMapping.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPageToPrinterMapping.Size = new System.Drawing.Size(250, 22);
            this.cboPageToPrinterMapping.TabIndex = 20;
            this.cboPageToPrinterMapping.Text = "Combo2";
            this.cboPageToPrinterMapping.Click += new System.EventHandler(this.cboPageToPrinterMapping_Click);
            // 
            // cboPageSize
            // 
            this.cboPageSize.BackColor = System.Drawing.SystemColors.Window;
            this.cboPageSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboPageSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPageSize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPageSize.Location = new System.Drawing.Point(10, 43);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPageSize.Size = new System.Drawing.Size(250, 22);
            this.cboPageSize.TabIndex = 18;
            this.cboPageSize.Text = "Combo1";
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);
            // 
            // lblPageCount
            // 
            this.lblPageCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPageCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPageCount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPageCount.Location = new System.Drawing.Point(116, 163);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPageCount.Size = new System.Drawing.Size(144, 19);
            this.lblPageCount.TabIndex = 26;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.SystemColors.Control;
            this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label9.Location = new System.Drawing.Point(10, 163);
            this.Label9.Name = "Label9";
            this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label9.Size = new System.Drawing.Size(161, 19);
            this.Label9.TabIndex = 23;
            this.Label9.Text = "总数";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label8.Location = new System.Drawing.Point(10, 77);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label8.Size = new System.Drawing.Size(250, 28);
            this.Label8.TabIndex = 19;
            this.Label8.Text = "Page to Printer Mapping";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(10, 26);
            this.Label6.Name = "Label6";
            this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label6.Size = new System.Drawing.Size(250, 36);
            this.Label6.TabIndex = 17;
            this.Label6.Text = "大小";
            // 
            // fraPrint
            // 
            this.fraPrint.BackColor = System.Drawing.SystemColors.Control;
            this.fraPrint.Controls.Add(this.txbOverlap);
            this.fraPrint.Controls.Add(this.cmdPrint);
            this.fraPrint.Controls.Add(this.txbStartPage);
            this.fraPrint.Controls.Add(this.txbEndPage);
            this.fraPrint.Controls.Add(this.Label5);
            this.fraPrint.Controls.Add(this.Label1);
            this.fraPrint.Controls.Add(this.Label2);
            this.fraPrint.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraPrint.Location = new System.Drawing.Point(326, 325);
            this.fraPrint.Name = "fraPrint";
            this.fraPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraPrint.Size = new System.Drawing.Size(273, 116);
            this.fraPrint.TabIndex = 21;
            this.fraPrint.TabStop = false;
            this.fraPrint.Text = "打印";
            // 
            // txbOverlap
            // 
            this.txbOverlap.AcceptsReturn = true;
            this.txbOverlap.BackColor = System.Drawing.SystemColors.Window;
            this.txbOverlap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbOverlap.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOverlap.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbOverlap.Location = new System.Drawing.Point(192, 26);
            this.txbOverlap.MaxLength = 0;
            this.txbOverlap.Name = "txbOverlap";
            this.txbOverlap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbOverlap.Size = new System.Drawing.Size(68, 20);
            this.txbOverlap.TabIndex = 9;
            this.txbOverlap.Text = "0";
            this.txbOverlap.Leave += new System.EventHandler(this.txbOverlap_Leave);
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
            this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdPrint.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdPrint.Location = new System.Drawing.Point(10, 77);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdPrint.Size = new System.Drawing.Size(250, 28);
            this.cmdPrint.TabIndex = 8;
            this.cmdPrint.Text = "打印页面布局";
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // txbStartPage
            // 
            this.txbStartPage.AcceptsReturn = true;
            this.txbStartPage.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbStartPage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStartPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbStartPage.Location = new System.Drawing.Point(71, 51);
            this.txbStartPage.MaxLength = 0;
            this.txbStartPage.Name = "txbStartPage";
            this.txbStartPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbStartPage.Size = new System.Drawing.Size(58, 20);
            this.txbStartPage.TabIndex = 7;
            this.txbStartPage.Text = "1";
            // 
            // txbEndPage
            // 
            this.txbEndPage.AcceptsReturn = true;
            this.txbEndPage.BackColor = System.Drawing.SystemColors.Window;
            this.txbEndPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbEndPage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEndPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbEndPage.Location = new System.Drawing.Point(192, 51);
            this.txbEndPage.MaxLength = 0;
            this.txbEndPage.Name = "txbEndPage";
            this.txbEndPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbEndPage.Size = new System.Drawing.Size(68, 20);
            this.txbEndPage.TabIndex = 6;
            this.txbEndPage.Text = "0";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(10, 51);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(61, 19);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "页:";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(141, 51);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(30, 19);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "To";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(10, 26);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(222, 36);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "页面重叠";
            // 
            // fraPrinter
            // 
            this.fraPrinter.BackColor = System.Drawing.SystemColors.Control;
            this.fraPrinter.Controls.Add(this.lblPrinterOrientation);
            this.fraPrinter.Controls.Add(this.Label10);
            this.fraPrinter.Controls.Add(this.lblPrinterName);
            this.fraPrinter.Controls.Add(this.Label7);
            this.fraPrinter.Controls.Add(this.lblPrinterSize);
            this.fraPrinter.Controls.Add(this.lblPdcdcrinter);
            this.fraPrinter.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraPrinter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraPrinter.Location = new System.Drawing.Point(326, 211);
            this.fraPrinter.Name = "fraPrinter";
            this.fraPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraPrinter.Size = new System.Drawing.Size(273, 100);
            this.fraPrinter.TabIndex = 20;
            this.fraPrinter.TabStop = false;
            this.fraPrinter.Text = "打印机";
            // 
            // lblPrinterOrientation
            // 
            this.lblPrinterOrientation.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterOrientation.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterOrientation.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterOrientation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterOrientation.Location = new System.Drawing.Point(141, 73);
            this.lblPrinterOrientation.Name = "lblPrinterOrientation";
            this.lblPrinterOrientation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrinterOrientation.Size = new System.Drawing.Size(122, 18);
            this.lblPrinterOrientation.TabIndex = 25;
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.SystemColors.Control;
            this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label10.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label10.Location = new System.Drawing.Point(10, 73);
            this.Label10.Name = "Label10";
            this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label10.Size = new System.Drawing.Size(250, 18);
            this.Label10.TabIndex = 24;
            this.Label10.Text = "纸张方向:";
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterName.Location = new System.Drawing.Point(58, 20);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrinterName.Size = new System.Drawing.Size(209, 28);
            this.lblPrinterName.TabIndex = 4;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.SystemColors.Control;
            this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label7.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label7.Location = new System.Drawing.Point(10, 21);
            this.Label7.Name = "Label7";
            this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label7.Size = new System.Drawing.Size(250, 17);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "名字:";
            // 
            // lblPrinterSize
            // 
            this.lblPrinterSize.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterSize.Location = new System.Drawing.Point(86, 49);
            this.lblPrinterSize.Name = "lblPrinterSize";
            this.lblPrinterSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrinterSize.Size = new System.Drawing.Size(181, 19);
            this.lblPrinterSize.TabIndex = 2;
            // 
            // lblPdcdcrinter
            // 
            this.lblPdcdcrinter.BackColor = System.Drawing.SystemColors.Control;
            this.lblPdcdcrinter.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPdcdcrinter.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPdcdcrinter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPdcdcrinter.Location = new System.Drawing.Point(10, 49);
            this.lblPdcdcrinter.Name = "lblPdcdcrinter";
            this.lblPdcdcrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPdcdcrinter.Size = new System.Drawing.Size(250, 19);
            this.lblPdcdcrinter.TabIndex = 1;
            this.lblPdcdcrinter.Text = "纸张大小";
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Location = new System.Drawing.Point(12, 9);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(300, 437);
            this.axPageLayoutControl1.TabIndex = 22;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(169, 159);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 24;
            // 
            // frmPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(608, 451);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axPageLayoutControl1);
            this.Controls.Add(this.fraPrint);
            this.Controls.Add(this.fraPrinter);
            this.Controls.Add(this.Frame2);
            this.Name = "frmPrint";
            this.Text = "frmPrint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Frame2.ResumeLayout(false);
            this.fraPrint.ResumeLayout(false);
            this.fraPrint.PerformLayout();
            this.fraPrinter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

        private void LoadDocumentToPageLayout()
        {
            for (int i = m_PageLayoutControl.ActiveView.FocusMap.LayerCount-1; i >=0; i--)
            {
                axPageLayoutControl1.ActiveView.FocusMap.AddLayer(m_PageLayoutControl.ActiveView.FocusMap.get_Layer(i));
            }
            
                        //Update page display
            cboPageSize.SelectedIndex = (int)axPageLayoutControl1.Page.FormID;
            cboPageToPrinterMapping.SelectedIndex = (int)axPageLayoutControl1.Page.PageToPrinterMapping;
            if (axPageLayoutControl1.Page.Orientation == 1)
            {
                optPortrait.Checked = true;
            }
            else
            {
                optLandscape.Checked = true;
            }

            //Zoom to whole page
            axPageLayoutControl1.ZoomToWholePage();

            //Update printer page display
            UpdatePrintPageDisplay();
        }
        //private void cmdLoadMxFile_Click(object sender, System.EventArgs e)
        //{
        //    //Open a file dialog for selecting map documents
        //    openFileDialog1.Title = "Browse Map Document";
        //    openFileDialog1.Filter = "Map Documents (*.mxd)|*.mxd";
        //    openFileDialog1.ShowDialog();

        //    //Exit if no map document is selected
        //    string sFilePath = openFileDialog1.FileName;
        //    if (sFilePath == "")
        //    {
        //        return;
        //    }

        //    //Validate and load the Mx document
        //    if (axPageLayoutControl1.CheckMxFile(sFilePath)== true)
        //    {
        //        axPageLayoutControl1.MousePointer = esriControlsMousePointer.esriPointerHourglass;
        //        axPageLayoutControl1.LoadMxFile(sFilePath,"");
        //        axPageLayoutControl1.MousePointer = esriControlsMousePointer.esriPointerDefault;
        //        txbMxFilePath.Text = sFilePath;
        //    }
        //    else
        //    {
        //        MessageBox.Show(sFilePath + " is not a valid ArcMap document");
        //    }

            //Update page display
            //cboPageSize.SelectedIndex = (int)axPageLayoutControl1.Page.FormID;
            //cboPageToPrinterMapping.SelectedIndex = (int)axPageLayoutControl1.Page.PageToPrinterMapping;
            //if (axPageLayoutControl1.Page.Orientation == 1)
            //{
            //    optPortrait.Checked = true;
            //}
            //else
            //{
            //    optLandscape.Checked = true;
            //}

            //Zoom to whole page
            //axPageLayoutControl1.ZoomToWholePage();

            //Update printer page display
            //UpdatePrintPageDisplay();
        //}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			if (axPageLayoutControl1.Printer != null) 
			{
				//Set mouse pointer
				axPageLayoutControl1.MousePointer = esriControlsMousePointer.esriPointerHourglass;

				//Get IPrinter interface through the PageLayoutControl's printer
				IPrinter printer = axPageLayoutControl1.Printer;

				//Determine whether printer paper's orientation needs changing
				if (printer.Paper.Orientation != axPageLayoutControl1.Page.Orientation)
				{
					printer.Paper.Orientation = axPageLayoutControl1.Page.Orientation;
					//Update the display
					UpdatePrintingDisplay();
				}

				//Print the page range with the specified overlap
				axPageLayoutControl1.PrintPageLayout(Convert.ToInt16(txbStartPage.Text), Convert.ToInt16(txbEndPage.Text), Convert.ToDouble(txbOverlap.Text));

				//Set the mouse pointer
				axPageLayoutControl1.MousePointer = esriControlsMousePointer.esriPointerDefault;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//Add esriPageFormID constants to drop down
			cboPageSize.Items.Add("Letter - 8.5in x 11in.");
			cboPageSize.Items.Add("Legal - 8.5in x 14in.");
			cboPageSize.Items.Add("Tabloid - 11in x 17in.");
			cboPageSize.Items.Add("C - 17in x 22in.");
			cboPageSize.Items.Add("D - 22in x 34in.");
			cboPageSize.Items.Add("E - 34in x 44in.");
			cboPageSize.Items.Add("A5 - 148mm x 210mm.");
			cboPageSize.Items.Add("A4 - 210mm x 297mm.");
			cboPageSize.Items.Add("A3 - 297mm x 420mm.");
			cboPageSize.Items.Add("A2 - 420mm x 594mm.");
			cboPageSize.Items.Add("A1 - 594mm x 841mm.");
			cboPageSize.Items.Add("A0 - 841mm x 1189mm.");
			cboPageSize.Items.Add("Custom Page Size.");
			cboPageSize.Items.Add("Same as Printer Form.");
			cboPageSize.SelectedIndex = 7;

			//Add esriPageToPrinterMapping constants to drop down
			cboPageToPrinterMapping.Items.Add("0: Crop");
			cboPageToPrinterMapping.Items.Add("1: Scale");
			cboPageToPrinterMapping.Items.Add("2: Tile");
			cboPageToPrinterMapping.SelectedIndex = 1;
			optPortrait.Checked = true;
            EnableOrientation(false);

			//Display printer details
			UpdatePrintingDisplay();

            LoadDocumentToPageLayout();
		}

		private void UpdatePrintPageDisplay()
		{
			//Determine the number of pages
			short iPageCount = axPageLayoutControl1.get_PrinterPageCount(Convert.ToDouble(txbOverlap.Text));
			lblPageCount.Text = iPageCount.ToString();

			//Validate start and end pages
			int iPageStart = Convert.ToInt32(txbStartPage.Text);
			int iPageEnd = Convert.ToInt32(txbEndPage.Text);
			if ((iPageStart < 1) | (iPageStart > iPageCount))
			{
				txbStartPage.Text = "1";
			}
			if ((iPageEnd < 1) | (iPageEnd > iPageCount))
			{
				txbEndPage.Text = iPageCount.ToString();
			}
		}

		private void UpdatePrintingDisplay()
		{
			if (axPageLayoutControl1.Printer != null) 
			{
				//Get IPrinter interface through the PageLayoutControl's printer
				IPrinter printer = axPageLayoutControl1.Printer;

				//Determine the orientation of the printer's paper
				if (printer.Paper.Orientation == 1)
				{
					lblPrinterOrientation.Text = "Portrait";
				}
				else
				{
					lblPrinterOrientation.Text = "Landscape";
				}

				//Determine the printer name
				lblPrinterName.Text = printer.Paper.PrinterName;

				//Determine the printer's paper size
				double dWidth; 
				double dheight;
				printer.Paper.QueryPaperSize(out dWidth, out dheight);
				lblPrinterSize.Text = dWidth.ToString("###.000") + " by " + dheight.ToString("###.000") + " Inches";
			}
		}

		private void txbOverlap_Leave(object sender, System.EventArgs e)
		{
			//Update printer page display
			UpdatePrintPageDisplay();
		}

		private void cboPageToPrinterMapping_Click(object sender, System.EventArgs e)
		{
			//Set the printer to page mapping
			axPageLayoutControl1.Page.PageToPrinterMapping = (esriPageToPrinterMapping) cboPageToPrinterMapping.SelectedIndex;
			//Update printer page display
			UpdatePrintPageDisplay();
		}

		private void optLandscape_Click(object sender, System.EventArgs e)
		{
			if (optLandscape.Checked == true)
			{
				//Set the page orientation
				if (axPageLayoutControl1.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
				{
					axPageLayoutControl1.Page.Orientation = 2;
				}
				//Update printer page display
				UpdatePrintPageDisplay();
			}
		}

		private void optPortrait_Click(object sender, System.EventArgs e)
		{
			if (optPortrait.Checked == true)
			{
				//Set the page orientation
				if (axPageLayoutControl1.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
				{
					axPageLayoutControl1.Page.Orientation = 1;
				}
				//Update printer page display
				UpdatePrintPageDisplay();
			}
		}

        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Orientation cannot change if the page size is set to 'Same as Printer'
            if (cboPageSize.SelectedIndex == 13)
                EnableOrientation(false);
            else
                EnableOrientation(true);
            //Set the page size
            axPageLayoutControl1.Page.FormID = (esriPageFormID)cboPageSize.SelectedIndex;
            //Update printer page display
            UpdatePrintPageDisplay();
        }

        private void EnableOrientation(bool b)
        {
            optPortrait.Enabled = b;
            optLandscape.Enabled = b;
        }
	}
}
