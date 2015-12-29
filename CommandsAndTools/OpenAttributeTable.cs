using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.GeoDatabaseUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using System.Windows.Forms;


namespace Giser_Lu
{
    class OpenAttributeTable:BaseCommand
    {
        private IMapControlDefault m_MapControl;
        private IHookHelper m_hookHelper = new HookHelperClass();
       // private string m_LayerString = null;
       
        public OpenAttributeTable(IMapControlDefault mapcontrol)
        {
            m_MapControl = mapcontrol;
        }

        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;
          
        }

        public override void OnClick()
        {
            frmAttributeTable frmAT = new frmAttributeTable(m_MapControl);
            frmAT.Show();
        }

        public override string Caption
        {
            get
            {
                return "打开属性表";
            }
        }
    }
}
