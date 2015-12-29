﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;

namespace Giser_Lu
{
    /// <summary>
    /// Summary description for AddScaleBar.
    /// </summary>
    [Guid("7f0e544c-a93d-45c7-b101-5c26d2101c0d")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Giser_Lu.AddScaleBar")]
    public sealed class AddScaleBar : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IHookHelper m_HookHelper;
        private INewEnvelopeFeedback m_Feedback;
        private IPoint m_Point;
        private bool m_InUse;
        private IPageLayoutControlDefault m_PageLayOutControl;
        //Windows API functions to capture mouse and keyboard
        //input to a window when the mouse is outside the window
        [DllImport("User32", CharSet = CharSet.Auto)]
        private static extern int SetCapture(int hWnd);
        [DllImport("User32", CharSet = CharSet.Auto)]
        private static extern int GetCapture();
        [DllImport("User32", CharSet = CharSet.Auto)]
        private static extern int ReleaseCapture();
        public AddScaleBar()
        {
            //Create an IHookHelper object
            m_HookHelper = new HookHelperClass();
            //base.m_bitmap = new System.Drawing.Bitmap(GetType().Assembly.GetManifestResourceStream(GetType(), "NorthArrow.bmp"));

            //Set the tool properties
            //
            // TODO: Define values for the public properties
            //
         

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            m_HookHelper.Hook = hook;
            m_PageLayOutControl = (IPageLayoutControlDefault)hook;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add CreateScaleBar.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //Create a point in map coordinates
            m_Point = m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

            //Start capturing mouse events
            SetCapture(m_HookHelper.ActiveView.ScreenDisplay.hWnd);

            m_InUse = true;
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (m_InUse == false) return;

            //Start an envelope feedback
            if (m_Feedback == null)
            {
                m_Feedback = new NewEnvelopeFeedbackClass();
                m_Feedback.Display = m_HookHelper.ActiveView.ScreenDisplay;
                m_Feedback.Start(m_Point);
            }

            //Move the envelope feedback
            m_Feedback.MoveTo(m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y));
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            if (m_InUse == false) return;

            //Stop capturing mouse events
            if (GetCapture() == m_HookHelper.ActiveView.ScreenDisplay.hWnd)
                ReleaseCapture();

            //If an envelope has not been tracked or its height/width is 0
            if (m_Feedback == null)
            {
                m_Feedback = null;
                m_InUse = false;
                return;
            }
            IEnvelope envelope = m_Feedback.Stop();
            if ((envelope.IsEmpty) || (envelope.Width == 0) || (envelope.Height == 0))
            {
                m_Feedback = null;
                m_InUse = false;
                return;
            }

            //Create the form with the SymbologyControl
            SymbolForm symbolForm = new SymbolForm();
            //Get the IStyleGalleryItem
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassScaleBars);
            //Release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Get the map frame of the focus map
            IMapFrame mapFrame = (IMapFrame)m_HookHelper.ActiveView.GraphicsContainer.FindFrame(m_HookHelper.ActiveView.FocusMap);

            //Create a map surround frame
            IMapSurroundFrame mapSurroundFrame = new MapSurroundFrameClass();
            //Set its map frame and map surround
            mapSurroundFrame.MapFrame = mapFrame;
            mapSurroundFrame.MapSurround = (IMapSurround)styleGalleryItem.Item;

            //QI to IElement and set its geometry
            IElement element = (IElement)mapSurroundFrame;
            element.Geometry = envelope;

            //Add the element to the graphics container
            m_HookHelper.ActiveView.GraphicsContainer.AddElement((IElement)mapSurroundFrame, 0);
            //Refresh
            m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, mapSurroundFrame, null);
            
            m_Feedback = null;
            m_InUse = false;

            m_PageLayOutControl.CurrentTool = null;

            
        }
        #endregion
    }
}
