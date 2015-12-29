using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ESRI.ArcGIS.Carto;

namespace Giser_Lu.MapAndPageLayoutSynchronizer
{
    class Maps : IMaps, IDisposable
    {
        private ArrayList m_array = null;

        public Maps()
        {
            m_array = new ArrayList();
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (m_array != null)
            {
                m_array.Clear();
                m_array = null;
            }
        }

        #endregion

        #region IMaps 成员

        public void RemoveAt(int index)
        {
            if (index > m_array.Count || index < 0)
            {
                throw new Exception("Maps::RemoveAt /r/n index is out of range");
            }
            else
            {
                m_array.Remove(index);
            }
        }

        public void Reset()
        {
            m_array.Clear();
        }

        public int Count
        {
            get
            {
                return m_array.Count;
            }
        }

        public IMap get_Item(int index)
        {
            if (index > m_array.Count || index < 0)
            {
                throw new Exception("Maps::Get_Item /r/n index is out of range");
            }
            else
            {
                return (IMap)m_array[index];
            }
        }

        public void Remove(IMap map)
        {
            m_array.Remove(map);
        }

        public IMap Create()
        {
            IMap newMap = new MapClass();
            m_array.Add(newMap);

            return newMap;
        }

        public void Add(IMap map)
        {
            if (map == null)
            {
                throw new Exception("Maps::Add /r/n New map is not initialized");
            }
            else
            {
                m_array.Add(map);
            }
        }

        #endregion


    }
}
