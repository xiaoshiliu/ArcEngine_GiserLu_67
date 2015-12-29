using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;

namespace Giser_Lu
{
    public partial class frmSelectByAttribute : Form
    {
        IMapControlDefault m_MapControl;
        IFeatureLayer m_FeatureLayer;
        esriSelectionResultEnum m_SelectMethod;
        IFeatureSelection m_FeatureSelection;
        int m_SelectionTextIndex =0 ;

        public frmSelectByAttribute(IMapControlDefault mapcontrol)
        {
            
            InitializeComponent();
            m_MapControl = mapcontrol;
        }

        private void frmSelectByAttribute_Load(object sender, EventArgs e)
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                BindClickEventToButton();
                AddLayerToCBX();
                AddFieldsToListBox();
                cbx_SelectMethod.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("未加载地图");
                this.Dispose();
            }
        }

        private void BindClickEventToButton()
        {
            foreach (Button btn in this.groupBox1.Controls)
            {
                 btn.Click +=new EventHandler(Btn_Click);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            SetBtnTextToSQLExpression(btn.Text);
            
        }

        private void SetBtnTextToSQLExpression(string str)
        {
         

            InsertCharacterAtCursorInTextBox i = new InsertCharacterAtCursorInTextBox(rtxtBx_SqlExpression);
            i.InsertCharacterAtCursor(ref m_SelectionTextIndex, str);
           

        }

        private void AddLayerToCBX()
        {
            if (m_MapControl.Map.LayerCount > 0)
            {
                for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
                {
                    if (m_MapControl.Map.get_Layer(i) is FeatureLayer)
                    {
                        cbx_Layer.Items.Add(m_MapControl.Map.get_Layer(i).Name);
                    }
                }
                cbx_Layer.SelectedIndex = 0;
            }
           
           
        }

        private void AddFieldsToListBox()
        {
            lst_Field.Items.Clear();
            if (cbx_Layer.SelectedItem != null)
            {
                GetLayerByName(cbx_Layer.SelectedItem.ToString());

                if (m_FeatureLayer.FeatureClass.Fields != null)
                {

                    for (int i = 0; i < m_FeatureLayer.FeatureClass.Fields.FieldCount; i++)
                    {
                        if (m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry)
                        {
                            lst_Field.Items.Add(m_FeatureLayer.FeatureClass.Fields.get_Field(i).Name);
                        }

                    }
                    if (lst_Field.Items.Count == 0)
                    {
                        lst_Field.Items.Add("None");

                    }

                    lst_Field.SelectedIndex = 0;


                }
            }
           
        }

    private void GetLayerByName(string name)
    {
        if (m_MapControl.Map.LayerCount > 0)
        {
            for (int i = 0; i < m_MapControl.Map.LayerCount; i++)
            {
                if (name == m_MapControl.Map.get_Layer(i).Name)
                {
                    m_FeatureLayer = (IFeatureLayer)m_MapControl.Map.get_Layer(i);
                }
            }
        }
        
    }

        private void AddValueOfFieldToListBox()
        {
            lst_ValueOfField.Items.Clear();
            GetLayerByName(cbx_Layer.SelectedItem.ToString());

            IFeatureCursor pFeatureCursor;
            IFeature pFeature;
           
            pFeatureCursor = m_FeatureLayer.FeatureClass.Search(null, true);
            pFeature = pFeatureCursor.NextFeature();
            
            
            while (pFeature != null)
            {
               int i = m_FeatureLayer.FeatureClass.FindField(lst_Field.SelectedItem.ToString());
               string  pValueOfFied = pFeature.get_Value(i).ToString();
            
                
                if (lst_ValueOfField.FindStringExact(pValueOfFied) == ListBox.NoMatches)
                {
                    if(m_FeatureLayer.FeatureClass.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeString)
                    {
                        pValueOfFied ="\'"+ pFeature.get_Value(i).ToString()+"\'";
                    }
                    else
                    {
                         pValueOfFied = pFeature.get_Value(i).ToString();
                    }

                    lst_ValueOfField.Items.Add(pValueOfFied);
                }

                pFeature = pFeatureCursor.NextFeature();
            }

        }

        private void cbx_Layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFieldsToListBox();
        }

        private void lst_Field_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_Field.SelectedItem != null)
            {
                InsertCharacterAtCursorInTextBox i = new InsertCharacterAtCursorInTextBox(rtxtBx_SqlExpression);
                i.InsertCharacterAtCursor(ref m_SelectionTextIndex, lst_Field.SelectedItem.ToString());
            }
        }

        private void lst_ValueOfField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_ValueOfField.SelectedItem != null)
            {
                InsertCharacterAtCursorInTextBox i = new InsertCharacterAtCursorInTextBox(rtxtBx_SqlExpression);
                i.InsertCharacterAtCursor(ref m_SelectionTextIndex, lst_ValueOfField.SelectedItem.ToString());
            }           
        }

        private void btn_GetValueOfField_Click(object sender, EventArgs e)
        {
            AddValueOfFieldToListBox();
        }

        private void btn_ClearSqlExpression_Click(object sender, EventArgs e)
        {
            rtxtBx_SqlExpression.Text ="";
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            ExecuteQuery();
        }

        private void ExecuteQuery()
        {
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = rtxtBx_SqlExpression.Text;

           
            if (m_SelectMethod == esriSelectionResultEnum.esriSelectionResultNew)
            {
                m_MapControl.Map.ClearSelection();
            }
            m_FeatureSelection = (IFeatureSelection)m_FeatureLayer;
            float pSelcetionCount = m_FeatureSelection.SelectionSet.Count;
            try
            {
                m_FeatureSelection.SelectFeatures(pQueryFilter, m_SelectMethod, false);
            }
            catch (Exception)
            {
                MessageBox.Show("请检查表达式是否正确!");
                return;
            }
            

            if (m_SelectMethod == esriSelectionResultEnum.esriSelectionResultNew && m_FeatureSelection.SelectionSet.Count == 0)
            {
                MessageBox.Show("无法创建满足条件的新查询");
            }
            else if (m_SelectMethod == esriSelectionResultEnum.esriSelectionResultAnd && m_FeatureSelection.SelectionSet.Count == 0)
            {
                MessageBox.Show("不能从当前查询中查询到满足条件要素");
            }
            else if (m_FeatureSelection.SelectionSet.Count == pSelcetionCount)
            {
                MessageBox.Show("无满足查询条件的要素");
            }

            m_MapControl.ActiveView.Refresh();
            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);


        }

        private void cbx_SelectMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pSelectItem = cbx_SelectMethod.SelectedItem.ToString();
            switch (pSelectItem)
            {
                case "创建新的查询":
                    {
                        m_SelectMethod = esriSelectionResultEnum.esriSelectionResultNew;
                        break;
                    }
                case "加入现有查询":
                    {
                        m_SelectMethod = esriSelectionResultEnum.esriSelectionResultAdd;
                        break;
                    }
                case "从现有查询中移去":
                    {
                        m_SelectMethod = esriSelectionResultEnum.esriSelectionResultSubtract;
                        break;
                    }
                case "在现有查询中查询":
                    {
                        m_SelectMethod = esriSelectionResultEnum.esriSelectionResultAnd;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void rtxtBx_SqlExpression_Leave(object sender, EventArgs e)
        {
            m_SelectionTextIndex = rtxtBx_SqlExpression.SelectionStart;
        }

       


    }
}