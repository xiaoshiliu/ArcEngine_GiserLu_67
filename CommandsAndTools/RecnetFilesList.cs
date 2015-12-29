using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using System.Collections;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Giser_Lu.CommandsAndTools
{
    class RecnetFilesList
    {
        public static ArrayList arrRencentFilesList;
        private int m_totalRencentFiles = 10 ;
        static string RecentFilesRegistryKeyPath = @"Software\Giser_Lu\Recent Files";

        public int TotalRecentFiles
        {
            get
            {
                if (arrRencentFilesList.Count >= m_totalRencentFiles)
                {
                    arrRencentFilesList.RemoveRange(m_totalRencentFiles, arrRencentFilesList.Count - m_totalRencentFiles);
                }
                return arrRencentFilesList.Count;
            }
            set
            {
                
                if (arrRencentFilesList.Count >= m_totalRencentFiles)
                {
                    arrRencentFilesList.RemoveRange(m_totalRencentFiles, arrRencentFilesList.Count - m_totalRencentFiles);
                }
              
            }

        }
      
        public RecnetFilesList()
        {
            arrRencentFilesList = new ArrayList();
            arrRencentFilesList.Clear();
            
        }

        public static void Add(string filename)
        {
            
            arrRencentFilesList.Remove(filename);
            
            arrRencentFilesList.Insert(0, filename);
        }

        public static void Remove(string filename)
        {
            arrRencentFilesList.Remove(filename);
        }

        public  void WriteRegistyKey()
        {
            
             //Registry.CurrentUser.DeleteSubKey(RecentFilesRegistryKeyPath);
             Registry.CurrentUser.DeleteSubKey(RecentFilesRegistryKeyPath, false);
             RegistryKey rlKey = Registry.CurrentUser.CreateSubKey(RecentFilesRegistryKeyPath);
            
            if (arrRencentFilesList != null)
            {
                for (int i = 0; i < arrRencentFilesList.Count; i++)
                {
                    if(!string.IsNullOrEmpty((string)arrRencentFilesList[i]))
                    {
                        rlKey.SetValue(i.ToString(), (string)arrRencentFilesList[i]);
                    }
                }
            }
            else
            {
               
                MessageBox.Show("Recent Flies List is null!");
            }
           
        }

        public  void ReadRegistryKey()
        {
            RegistryKey rlKey = Registry.CurrentUser.OpenSubKey(RecentFilesRegistryKeyPath);
            if (rlKey != null)
            {
                arrRencentFilesList.Clear();
                string[] temp = rlKey.GetValueNames() ;
                foreach (string s in temp)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        string filename = rlKey.GetValue(s,string.Empty).ToString();
                        if (!string.IsNullOrEmpty(filename))
                        {
                            arrRencentFilesList.Add(filename);
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("SubKey is null");
            }
          
        }


    }
    public interface IOpEnRecentFile
    {
        void OpenRecnetFile(string filename);
    }

}
