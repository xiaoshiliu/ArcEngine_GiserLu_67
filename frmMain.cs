using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.GeoDatabaseUI;
using ESRI.ArcGIS.Geodatabase;

using Giser_Lu.MapAndPageLayoutSynchronizer;
using Giser_Lu.CommandsAndTools;
using DynamicReport;



namespace Giser_Lu
{
    public partial class frmMain : Form,IOpEnRecentFile
    {
        #region 成员变量

        
        private IMapControlDefault m_MapControl = null;
        private IPageLayoutControlDefault m_pagelayoutcontrol;
        private ITOCControlDefault m_toccontrol;
        
        private IEngineEditProperties m_EngineEditProperties = null;
       

        private RecnetFilesList m_REcentFelesList;
        private ControlsSynchronizer m_controlsSynchronizer;

        public static string LayoutConfigName = System.Environment.CurrentDirectory + "\\" + "Config.xml";
       
        #endregion

        #region 构造方法

        public frmMain()
        {
            InitializeComponent();
           
          
      
        }
        #endregion

        #region 窗体相关

        private void frmMain_Load(object sender, EventArgs e)
        {
       
            m_MapControl = (IMapControlDefault)axMapControl1.Object;
            m_pagelayoutcontrol = (IPageLayoutControlDefault)axPageLayoutControl1.Object;
            m_toccontrol = (ITOCControlDefault)axTOCControl1.Object;

            m_controlsSynchronizer = new ControlsSynchronizer(m_MapControl, m_pagelayoutcontrol);

            m_controlsSynchronizer.BindControls(true);

            m_controlsSynchronizer.AddFrameworkControl(axTOCControl1.Object);
          
           
            if (!File.Exists(LayoutConfigName))
            {
                dotNetBarManager1.SaveLayout(LayoutConfigName);
            }
              
            dotNetBarManager1.LoadLayout(LayoutConfigName);


            m_REcentFelesList = new RecnetFilesList();

            m_REcentFelesList.ReadRegistryKey();
            if (RecnetFilesList.arrRencentFilesList.Count != 0)
            {
                SetRecentFilesListMenuItem();
            }
            else
            {
                meunItem_Recent.Enabled = false;
            }
          

            TOCControlContextMenu();

           DisableControlInEditorToolBar();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(File.Exists(LayoutConfigName))
            this.dotNetBarManager1.SaveLayout(LayoutConfigName);

            m_REcentFelesList.WriteRegistyKey();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
            Application.Exit();
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                m_controlsSynchronizer.ActivateMap();
            }
            else
            {
                m_controlsSynchronizer.ActivatePageLayout();
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusLB_XY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void SetRecentFilesListMenuItem()
        {
            for (int i =0; i <m_REcentFelesList.TotalRecentFiles; i++)
            {

                DevComponents.DotNetBar.ButtonItem bi;
                bi = new DevComponents.DotNetBar.ButtonItem();
                if (((string)RecnetFilesList.arrRencentFilesList[i])!= null)
                {
                    bi.Text = (string)RecnetFilesList.arrRencentFilesList[i];
                    meunItem_Recent.SubItems.Add(bi);
                    bi.Click += new EventHandler(this.RecentFilesListMenuItem_Click);
                }
            }
           
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {

            if (e.button == 2)
            {
                axMapControl1.Pan();
            }
        }

        private void TOCControlContextMenu()
        {
            TOCControlContextMenu t = new TOCControlContextMenu(m_toccontrol, m_MapControl);
            axTOCControl1.OnMouseDown += new ITOCControlEvents_Ax_OnMouseDownEventHandler(t.SelectLayer);
        }
    

        #endregion

        #region 菜单事件

        #region 文件
        private void menuItem_Open_Click(object sender, EventArgs e)
        {
            OpenMapDoc();
           
        }

        private void menuItem_new_Click(object sender, EventArgs e)
        {
            NewMapDoc();
        }

        private void menuItem_Save_Click(object sender, EventArgs e)
        {
            SaveMapDoc();
        }

        private void menuItem_SaveAs_Click(object sender, EventArgs e)
        {
            SaveAsMapDoc();
        }

        private void RecentFilesListMenuItem_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem b = new DevComponents.DotNetBar.ButtonItem();
            b = (DevComponents.DotNetBar.ButtonItem)sender;
            OpenRecnetFile(b.Text);
        }

        #endregion

        #region 编辑

        private void menuItem_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void menuItem_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void menuItem_Copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void menuItem_Paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void menuItem_Cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void menuItem_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        #endregion

        #region 窗口

        private void menuItem_OverView_Click(object sender, EventArgs e)
        {           
            Form f = new Form();

                OverView o = new OverView(ref f, m_MapControl);
                if (m_MapControl.Map.LayerCount > 0)
                {
                    f.Shown += new EventHandler(o.frmOverView_Shown);
                }
                f.Show();
                this.axMapControl1.OnMapReplaced += new IMapControlEvents2_Ax_OnMapReplacedEventHandler(o.OverViewSynchronizeOnMapReplace);
                this.axMapControl1.OnExtentUpdated += new IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(o.OverViewSynchronizeDraw);
            }

        #endregion

        #region 工具

        private void meunItem_ClassBreakRenderer_Click(object sender, EventArgs e)
            {
                frmClassBreakRendererSymbolize frmCBR = new frmClassBreakRendererSymbolize(m_MapControl);
                frmCBR.Show();
            }

        private void menuItem_Report_Click(object sender, EventArgs e)
        {
            frmGeoReport frmR = new frmGeoReport(m_MapControl.Map);
            frmR.Show();
        }
        
        private void menuItem_UniqueValueRenderer_Click(object sender, EventArgs e)
            {
                 frmUniqueValueRenderer frmUVR = new frmUniqueValueRenderer(m_MapControl);
                 frmUVR.Show();
            }

        private void menuItem_ProportionalSymbolRenderer_Click(object sender, EventArgs e)
            {
                frmProportionalSymbolRenderer frmPSR = new frmProportionalSymbolRenderer(m_MapControl);
                frmPSR.Show();
            }

        private void btn_PieChartRenderer_Click(object sender, EventArgs e)
        {
            frmPieChartRenderer frmPCR = new frmPieChartRenderer(m_MapControl);
            frmPCR.Show();
        }

        private void menuItem_Label_Click(object sender, EventArgs e)
        {
            frmLableByField frmLBF = new frmLableByField(m_MapControl);
            frmLBF.Show();
        }

        private void menuItem_Annotation_Click(object sender, EventArgs e)
        {
            frmAnnotationByField frmABF = new frmAnnotationByField(m_MapControl);
            frmABF.Show();
        }


        private void menuItem_CustomizeDialog_Click(object sender, EventArgs e)
        {
            dotNetBarManager1.Customize();
        }

        private void meunItem_Option_Click(object sender, EventArgs e)
        {
            frmOption frmO = new frmOption();
            frmO.Show();
        }


        #endregion

        #region 分析
        private void menuItem_BufferAnalyst_Click(object sender, EventArgs e)
        {
            ICommand cmd = new BufferAnalyst();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }
        private void menuItem_Overlay_Click(object sender, EventArgs e)
        {
            ICommand cmd = new OverlayAnalyst();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }
        #endregion

        #region 查询

        private void btn_SelectByAttribute_Click(object sender, EventArgs e)
        {
            ICommand cmd = new OpenFormSelectByAttribute();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }

        private void btn_SelectionByLocation_Click(object sender, EventArgs e)
        {
            ICommand cmd = new OpenFormSelectionByLocation();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }

        #endregion

        #region 插入
        private void menuItem_InsertTXT_Click(object sender, EventArgs e)
        {
            frmAddTxtElement frmATE = new frmAddTxtElement(m_MapControl);
            frmATE.Show();
            axMapControl1.OnMouseDown+=new IMapControlEvents2_Ax_OnMouseDownEventHandler(frmATE.MapControl_OnMouseDown);
        }


        private void menuItem_InsertLegend_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddLegendCmd();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            cmd.OnClick();
        }

        private void menuItem_NorthArrow_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddNorthArrow();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            m_pagelayoutcontrol.CurrentTool = (ITool)cmd;
        }

        private void menuItem_ScaleBar_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddScaleBar();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            m_pagelayoutcontrol.CurrentTool = (ITool)cmd;

        }
        #endregion
        #endregion

        #region 工具栏按钮事件

        #region 绘图
        private void btn_SelectElement_Click(object sender, EventArgs e)
        {
          
            ICommand cmd = new ControlsSelectToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
            
        }
        private void btn_DrawTxt_Click(object sender, EventArgs e)
        {
            frmAddTxtElement frmDT = new frmAddTxtElement(m_MapControl);
            frmDT.Show();
            axMapControl1.OnMouseDown+=new IMapControlEvents2_Ax_OnMouseDownEventHandler(frmDT.MapControl_OnMouseDown);
           // axMapControl1.OnAfterDraw += new IMapControlEvents2_Ax_OnAfterDrawEventHandler(frmDT.MapControl_OnAfterDraw);
        }
        private void btn_Rotates_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsRotateElementToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }


        private void btn_DrawRectangle_Click(object sender, EventArgs e)
        {
            
            ICommand cmd = new ControlsNewRectangleToolClass();
            cmd.OnCreate( m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
            
        }

        private void btn_DrawCircle_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsNewCircleToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }
        private void btn_DrawPolygon_Click(object sender, EventArgs e)
        {
           
            ICommand cmd = new ControlsNewPolygonToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }

        private void btn_DrawEllipse_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsNewEllipseToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }

        private void btn_DrawLine_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsNewLineToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }
        private void btn_DrawCurve_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsNewCurveToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }
        private void btn_DrawFreeHand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsNewFreeHandToolClass();
            cmd.OnCreate(m_controlsSynchronizer.ActiveControl);
            m_controlsSynchronizer.ActiveControlCurrentTool = (ITool)cmd;
        }

        #endregion

        #region 布局视图标准
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPageZoomInToolClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            m_pagelayoutcontrol.CurrentTool = (ITool)cmd;
        }

        private void btn_PageLayoutZoomOut_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPageZoomOutToolClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            m_pagelayoutcontrol.CurrentTool = (ITool)cmd;
        }

        private void btn_LayoutPan_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPagePanToolClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            m_pagelayoutcontrol.CurrentTool = (ITool)cmd;
        }

        private void btn_PageLayoutFixedZoomIn_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPageZoomInFixedCommandClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            cmd.OnClick();
        }

        private void btn_PageLayOutFixedZoomOut_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPageZoomOutFixedCommandClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            cmd.OnClick();
        }

        private void btn_PageLayoutZommwhole_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPageZoomWholePageCommandClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            cmd.OnClick();
        }

        private void btn_PageLayoutZoomTo100_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsPageZoom100PercentCommandClass();
            cmd.OnCreate(m_pagelayoutcontrol.Object);
            cmd.OnClick();
        }



        #endregion

        #region 标准
        private void buttonItem_Open_Click(object sender, EventArgs e)
        {
            OpenMapDoc();
        }
        private void btn_AddData_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsAddDataCommandClass();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }
        private void buttonItem_Save_Click(object sender, EventArgs e)
        {
            SaveMapDoc();
        }
        private void buttonItem_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void buttonItem_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void buttonItem_ClearSelection_Click(object sender, EventArgs e)
        {
            m_MapControl.Map.ClearSelection();
            m_MapControl.ActiveView.Refresh();
        }
        #region SelectByShape
        private void buttonItem_selectByShape_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            ICommand cmd = new SelectbyPoint();
            cmd.OnCreate(m_MapControl);
            m_MapControl.CurrentTool = cmd as ITool;
        }

        private void buttonItem_SelectByRectangle_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            ICommand cmd = new SelectByRectangle();
            cmd.OnCreate(m_MapControl);
            m_MapControl.CurrentTool = cmd as ITool;
        }

        private void buttonItem_selectByPolygon_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            ICommand cmd = new SelectByPolygon();
            cmd.OnCreate(m_MapControl);
            m_MapControl.CurrentTool = cmd as ITool;
        }

        private void buttonItem_selectByCircle_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            ICommand cmd = new SelectByCircle();
            cmd.OnCreate(m_MapControl);
            m_MapControl.CurrentTool = cmd as ITool;


        }

        private void buttonItem_SelectByLine_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SelectByLine();
            cmd.OnCreate(m_MapControl);
            m_MapControl.CurrentTool = (ITool)cmd;



        }
        #endregion
        #endregion

        #region 工具

        private void buttonItem_New_Click(object sender, EventArgs e)
        {
            NewMapDoc();
        }

        private void buttonItem_FullExtent_Click(object sender, EventArgs e)
        {
            FullExtend();

        }

        private void buttonItem_ZoomIn_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            ZoomIn();
        }

        private void buttonItem_ZoomOut_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            ZoomOut();
        }

        private void buttonItem_fixedZoomIn_Click(object sender, EventArgs e)
        {
            FixedZoomIn();
        }

        private void buttonItem1_fixedZoomOut_Click(object sender, EventArgs e)
        {
            FixedZoomOut();
        }


        private void buttonItem_ClearCurrentTool_Click(object sender, EventArgs e)
        {
            ClearCurrentTool();
            m_MapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
        }

        #endregion

        #region 图幅整饰

        private void buttonItem3_ChageBorder_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ChangeMapBorder();
            cmd.OnCreate(m_pagelayoutcontrol);
            cmd.OnClick();
        }

        private void buttonItem_ChangeShadow_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ChangeMapShadow();
            cmd.OnCreate(m_pagelayoutcontrol);
            cmd.OnClick();
        }

        private void buttonItem_ChangeBackGroud_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ChangeBackGround();
            cmd.OnCreate(m_pagelayoutcontrol);
            cmd.OnClick();
        }

        private void buttonItem_ZoomToWhole_Click(object sender, EventArgs e)
        {
            m_pagelayoutcontrol.ZoomToWholePage();

        }

        private void buttonItem_zoomtowidth_Click(object sender, EventArgs e)
        {
            m_pagelayoutcontrol.PageLayout.ZoomToWidth();
        }
        #endregion

        #region 编辑



        private void btn_StartEditing_Click(object sender, EventArgs e)
        {

            ICommand cmd = new ControlsEditingStartCommandClass();
            cmd.OnCreate(m_MapControl.Object);
            cmd.OnClick();
            m_EngineEditProperties = new EngineEditorClass();
            if (m_EngineEditProperties.TargetLayer != null)
            {
                EnableControlInEditorToolBar();

                cbx_EditTask.SelectedIndex = 0;
            }
        }

        private void btn_StopEditing_Click(object sender, EventArgs e)
        {
            DisableControlInEditorToolBar();
            ICommand cmd = new ControlsEditingStopCommandClass();
            cmd.OnCreate(m_MapControl.Object);
            cmd.OnClick();

        }

        private void btn_SaveEdits_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsEditingSaveCommandClass();
            cmd.OnCreate(m_MapControl.Object);
            cmd.OnClick();
        }

        private void btn_SelectFeature_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsEditingEditToolClass();
            cmd.OnCreate(m_MapControl.Object);
            m_MapControl.CurrentTool = (ITool)cmd;
        }


        private void btn_Sketch_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsEditingSketchToolClass();
            cmd.OnCreate(m_MapControl.Object);
            m_MapControl.CurrentTool = (ITool)cmd;


        }


        private void cbx_EditTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbx_EditTask.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        ClearCurrentTool();
                        ICommand cmd = new ControlsEditingSketchToolClass();
                        cmd.OnCreate(m_MapControl.Object);
                        m_MapControl.CurrentTool = (ITool)cmd;
                        break;
                    }
                case 1:
                    {
                        ClearCurrentTool();
                        TrimPolyline();
                        break;
                    }
                case 2:
                    {
                        ClearCurrentTool();
                        CreateCircleFeature();
                        break;
                    }
                case 3:
                    {
                        ClearCurrentTool();
                        CreateEnvelope();
                        break;
                    }

                default:
                    {
                        ClearCurrentTool();
                        ICommand cmd = new ControlsEditingSketchToolClass();
                        cmd.OnCreate(m_MapControl.Object);
                        m_MapControl.CurrentTool = (ITool)cmd;
                        break;
                    }
            }

        }


        private void CreateCircleFeature()
        {
            ICommand cmd = new CreateCirclePolygonFeatureTool();
            cmd.OnCreate(m_MapControl.Object);
            m_MapControl.CurrentTool = (ITool)cmd;
        }

        private void TrimPolyline()
        {
            ICommand cmd = new TrimPloylineTool();
            cmd.OnCreate(m_MapControl.Object);
            m_MapControl.CurrentTool = (ITool)cmd;
        }
        private void CreateEnvelope()
        {
            ICommand cmd = new CreateEnvelopeTool();
            cmd.OnCreate(m_MapControl.Object);
            m_MapControl.CurrentTool = (ITool)cmd;
        }

        private void btn_PolygonsDifference_Click(object sender, EventArgs e)
        {
            ICommand cmd = new PolygonsDifference();
            cmd.OnCreate(m_MapControl.Object);
            m_MapControl.CurrentTool = (ITool)cmd;

        }

        private void btn_Union_Click(object sender, EventArgs e)
        {
            ICommand cmd = new UnionFeaturesCmd();
            cmd.OnCreate(m_MapControl.Object);
            cmd.OnClick();
        }

        private void btn_AttributeTable_Click(object sender, EventArgs e)
        {
            frmAttributeTable frmAt = new frmAttributeTable(m_MapControl, m_EngineEditProperties.TargetLayer.Name);
            frmAt.Show();

        }

        #endregion

        #endregion

        #region 事件方法

        private void OpenMapDoc()
        {
            OpenDocument openDoc = new OpenDocument(m_controlsSynchronizer);
            openDoc.OnCreate(m_controlsSynchronizer.MapControl.Object);
            openDoc.OnClick();
            
        }

        private void NewMapDoc()
        {
            DialogResult res = MessageBox.Show("是否保存当前文档?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                ICommand command = new ControlsSaveAsDocCommandClass();
                if (m_MapControl != null)
                {
                    command.OnCreate(m_controlsSynchronizer.MapControl.Object);
                }
                else
                {
                    command.OnCreate(m_controlsSynchronizer.PageLayoutControl.Object);
                }
                command.OnClick();

            }

            IMap map = new MapClass();
            map.Name = "新建地图文档";
            m_controlsSynchronizer.MapControl.DocumentFilename = string.Empty;

            m_controlsSynchronizer.ReplaceMap(map);
        }

        private void SaveMapDoc()
        {
            if(null != m_pagelayoutcontrol.DocumentFilename && m_MapControl.CheckMxFile(m_pagelayoutcontrol.DocumentFilename))
            {
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_pagelayoutcontrol.DocumentFilename,string.Empty);
                mapDoc.ReplaceContents((IMxdContents)m_pagelayoutcontrol.PageLayout);
                mapDoc.Save(mapDoc.UsesRelativePaths,false);
                mapDoc.Close();
            }
        }

        private void SaveAsMapDoc()
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_controlsSynchronizer.ActiveControl);
            command.OnClick();

        

        }

        public void OpenRecnetFile(string filename)
        {
            OpenDocument openDoc = new OpenDocument(m_controlsSynchronizer);
            openDoc.OnCreate(m_controlsSynchronizer.MapControl.Object);
            openDoc.OnClick_RecentFileMenuItem(filename);
        }

        private void FullExtend()
        {
            ICommand c = new ControlsMapFullExtentCommandClass();
            c.OnCreate(axMapControl1.Object);
            c.OnClick();
        }

        private void ZoomIn()
        {
            ICommand tool = new ControlsMapZoomInToolClass();
            tool.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = tool as ITool;
            
        }

        private void ZoomOut()
        {
            ICommand c = new ControlsMapZoomOutToolClass();
            c.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = (ITool)c;
        }

        private void FixedZoomIn()
        {
            ICommand c = new ControlsMapZoomInFixedCommandClass();
            c.OnCreate(axMapControl1.Object);
            c.OnClick();
        }

        private void FixedZoomOut()
        {
            ICommand c = new ControlsMapZoomOutFixedCommandClass();
            c.OnCreate(axMapControl1.Object);
            c.OnClick();
        }

        private void Undo()
        {
            ICommand cmd = new ControlsUndoCommandClass();
            cmd.OnCreate(axTOCControl1.Object);
            cmd.OnClick();
        }

        private void Redo()
        {
            ICommand cmd = new ControlsRedoCommandClass();
            cmd.OnCreate(axTOCControl1.Object);
            cmd.OnClick();
        }

        private void Copy()
        {
            ICommand cmd = new ControlsEditingCopyCommandClass();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }

        private void Paste()
        {
            ICommand cmd = new ControlsEditingPasteCommandClass();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }

        private void Cut()
        {
            ICommand cmd = new ControlsEditingCutCommandClass();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();
        }

        private void ClearCurrentTool()
        {
            m_MapControl.CurrentTool = null;
            m_pagelayoutcontrol.CurrentTool = null;
           
        }

        private void Delete()
        {
            ICommand cmd = new ControlsEditingClearCommandClass();
            cmd.OnCreate(m_MapControl);
            cmd.OnClick();

        }


        private void EnableControlInEditorToolBar()
        {

            cbx_EditTask.Enabled = true;
            btn_AttributeTable.Enabled = true;
            btn_SelectFeature.Enabled = true;
            btn_Sketch.Enabled = true;
            btn_StopEditing.Enabled = true;
            lbl_EditTask.Enabled = true;
            btn_StartEditing.Enabled = false;

        }
        private void DisableControlInEditorToolBar()
        {

            cbx_EditTask.Enabled = false;
            btn_AttributeTable.Enabled = false;
            btn_SelectFeature.Enabled = false;
            btn_Sketch.Enabled = false;
            btn_StopEditing.Enabled = false;
            lbl_EditTask.Enabled = false;



            btn_StartEditing.Enabled = true;

        }

        #endregion


        private void buttonItem3_Click(object sender, EventArgs e)
        {
            //GetSelectedPolylineLength cmd = new GetSelectedPolylineLength();
            //cmd.OnCreate(m_MapControl);
            //cmd.OnClick();
            //buttonItem3.Enabled = cmd.Enabled;
            //buttonItem3.Text = cmd.PolyLineLength;
            IMapDocument pmd = new MapDocumentClass();
            //pmd.Ope "");
            
            MessageBox.Show(axMapControl1.DocumentFilename);
            MessageBox.Show(m_pagelayoutcontrol.ActiveView.FocusMap.Name);
            MessageBox.Show(m_MapControl.DocumentFilename);
            MessageBox.Show(m_MapControl.ActiveView.FocusMap.Name);
            
           
        }

        private void menuItem_Export_Click(object sender, EventArgs e)
        {
           
        }

        private void menuItem_Print_Click(object sender, EventArgs e)
        {
            frmPrint f = new frmPrint(m_pagelayoutcontrol);
            f.Show();
        }

    }
}