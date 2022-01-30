using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;


using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;

//using ESRI.ArcGIS.ADF;


//using ESRI.ArcGIS.SystemUI;


namespace InfoCUKS
{
    class ClassIdentify
    {

        private IMapControl3 m_mapControl;
        private ILayer lastLayer;

        public ClassIdentify(IMapControl3 av)
        {
            m_mapControl = av;
        }


        private IEnvelope areaAroundPoint(IPoint p, int dist)
        {

            IActiveView activeView = m_mapControl.ActiveView;

            tagRECT deviceRect = activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
            int pixelExtent = deviceRect.right - deviceRect.left;
            double realWorldDisplayExtent = activeView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / pixelExtent;
            double searchDistMapUnits = sizeOfOnePixel * dist;

            IEnvelope env = new EnvelopeClass();
            env.XMin = 0; env.YMin = 0; env.XMax = 0; env.YMax = 0;
            env.Width = searchDistMapUnits;
            env.Height = searchDistMapUnits;
            env.CenterAt(p);
            //this.drawEnvelope(p, searchDistMapUnits);

            return env;
        }

        public void identifyFeatures(int x, int y)
        {
            IActiveView activeView = m_mapControl.ActiveView;
            IEnvelope envelope = activeView.Extent;
            IArray pArr;
            IIdentify pId;
            IMap map = activeView.FocusMap;
            IPoint p = new PointClass();
            p = (activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y) as ESRI.ArcGIS.Geometry.IPoint);
            int searchDistPixels = 4;
            IEnvelope env = areaAroundPoint(p, searchDistPixels);

            for (int j = 0; j < m_mapControl.LayerCount; j++)
            {
                lastLayer = map.get_Layer(j);
                
                //if(lastLayer is IGroupLayer)
                //     MessageBox.Show("Group layer = " + ((IGroupLayer)lastLayer).Name);




                
                if (lastLayer is IFeatureLayer)
                {
                    IFeatureLayer fl = lastLayer as IFeatureLayer;
                    pId = fl as IIdentify;
                    pArr = pId.Identify(env as IGeometry);
                    if (pArr != null)
                    {
                        for (int i = 0; i < pArr.Count; i++)
                        {
                            IIdentifyObj o = pArr.get_Element(i) as IIdentifyObj;

                            IFeatureIdentifyObj pFeatId = pArr.get_Element(i) as IFeatureIdentifyObj;

                            IRowIdentifyObject pRow = pFeatId as IRowIdentifyObject;

                            IFeature feature = pRow.Row as IFeature;

                            ITable tabl = feature.Table;


                            IGeometry geometry1 = feature.Shape;

                            int indf = findFieldIndex("idb", feature);

                            MessageBox.Show("Layer = " + o.Layer.Name + " VAl = " + feature.get_Value(3).ToString());

                        }
                    }
                }
            }
        }


        private int findFieldIndex(string s, IFeature f)
        {
            for (int i = 0; i < f.Fields.FieldCount; i++)
            {
                if (f.Fields.get_Field(i).Name.ToString() == s)
                    return i;
            }
            return -1;
        }


        private DataRow[] getDataByKeyField(int f_key_value, string key_field_dt, DataTable dt)
        {
            DataRow[] drow = dt.Select(key_field_dt + "=" + f_key_value.ToString());


            string nametabke = drow[0].Table.TableName.ToString();

            return drow;

        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    } //end class
} //end namespace
