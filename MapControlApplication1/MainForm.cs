using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;

namespace InfoCUKS
{

    public sealed partial class MainForm : Form
    {
        #region class private members

        
        //ISpatialReferenceFactory2 spatRefFact = new SpatialReferenceEnvironmentClass();
        //private IGeographicCoordinateSystem m_GeographicCoordinateSystem;
        //private IProjectedCoordinateSystem m_ProjectedCoordinateSystem;

        private IPoint m_pointToZoom = new PointClass();

        private ITOCControl2 m_tocControl = null;
        public IMapControl3 m_mapControl = null;

        
        //для получения выбр. слоя TOC
        public IBasicMap map = null;
        public ILayer layer = null;
        public System.Object other = null;
        public System.Object index = null;
        public esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
        private string m_mapDocumentName = string.Empty;
        public double Xmap, Ymap;
        public int R = 255, G = 0, B = 0;
        public Font font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
        public bool font_isbold = false;
        public bool font_isitalic = false;
        public string ExecPath;

            
            
        public float font_size = 10;

        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();

            

        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;

            //get the TocControl
            m_tocControl = (ITOCControl2)axTOCControl1.Object;

            m_mapControl.LoadMxFile(ProgParam.mxdName, Type.Missing, Type.Missing);


            Color bclr = Color.FromArgb(this.BackColor.R,this.BackColor.G,this.BackColor.B);
            axToolbarControl1.BackColor = bclr;

            ExecPath = Application.StartupPath;
            
        }

        #region Main Menu event handlers
        
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void MnuItemGoToXY_Click(object sender, EventArgs e)
        {
            m_mapControl.CenterAt(m_pointToZoom);
            IDisplayTransformation pDT = m_mapControl.ActiveView.ScreenDisplay.DisplayTransformation;
            pDT.ScaleRatio = 40000;
            m_mapControl.ActiveView.Refresh();
        }

      

        private void btnKV_Click(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("КВ", true);
            frm.Owner = this;
            frm.Show();
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            /*
            if (m_mapControl.MousePointer == esriControlsMousePointer.esriPointerCrosshair)
            {
                ClassIdentify idfe = new ClassIdentify(m_mapControl);
                idfe.identifyFeatures(e.x, e.y);
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
            */


        }

        private void kola_Click(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("АД", true);
            frm.Owner = this;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //testForm f = new testForm("КВ");
        }

        private void btnRK_Click(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("НасПункты", true);
            frm.Owner = this;
            frm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("ПЧ2011", true);
            frm.Owner = this;
            frm.Show();
        }





        private void copyViewToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Сохранить файл карты";
            saveFileDialog1.ShowDialog();
            //string s;
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "" || saveFileDialog1.FileName !=null)
            {
                string filename = saveFileDialog1.FileName;
                CreateJPEGFromActiveView(m_mapControl.ActiveView, filename);
            }
            ;
        }

        public System.Boolean CreateJPEGFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            //parameter check
            if (activeView == null || !(pathFileName.EndsWith(".jpg")))
            {
                return false;
            }
            ESRI.ArcGIS.Output.IExport export = new ESRI.ArcGIS.Output.ExportJPEGClass();
            export.ExportFileName = pathFileName;
            // Microsoft Windows default DPI resolution
            export.Resolution = 96;          //96;
            tagRECT exportRECT = activeView.ExportFrame;
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.PixelBounds = envelope;
            System.Int32 hDC = export.StartExporting();
            activeView.Output(hDC, (System.Int16)export.Resolution, ref exportRECT, null, null);
            // Finish writing the export file and cleanup any intermediate files
            export.FinishExporting();
            export.Cleanup();
            return true;
        }

        private void Котельные_Click(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("Котельные", true);
            frm.Owner = this;
            frm.Show();
        
        }

        private void базыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

            базыДанныхToolStripMenuItem.DropDownItems.Clear();
            
            DataTable servicet = Util.get_dtService();
            string expression = "show_db = 'y'";
            DataRow[] fndrow = servicet.Select(expression, "table_alias ASC");
            if (fndrow.Length == 0) return;
            foreach (DataRow row in fndrow)
            {
                string alias = (string)row["table_alias"];
                string table = (string)row["Table"];
                

                ToolStripMenuItem subdb = new System.Windows.Forms.ToolStripMenuItem();
                subdb.Click += new System.EventHandler(this.subdb_Click);
                subdb.Text = alias;
                subdb.Tag = table;

                базыДанныхToolStripMenuItem.DropDownItems.Add(subdb);

            }
        }

        private void subdb_Click(object sender, EventArgs e)
        {
            string table = (string)(sender as ToolStripMenuItem).Tag;

            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm(table, true);
            frm.Owner = this;
            frm.Show();
        }

        public void deselect_tool()
        {
            UID pUID = new UIDClass();
            pUID.Value = "esriControlCommands.ControlsSelectTool";
            ICommand pCommand = axToolbarControl1.CommandPool.FindByUID(pUID);
            axToolbarControl1.CurrentTool = (ITool)pCommand;
            m_mapControl.CurrentTool = null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Drawing.Runned()) return;
            Drawing drw = new Drawing(axMapControl1, m_mapControl);
            drw.Owner = this;
            drw.Show();
        }

        private void view_all_RK_Click(object sender, EventArgs e)
        {
            double x_min = 24;        //29.5;     //29.334906;
            double y_min = 60;        //60.55;    //60.677325;
            double x_max = 42;        //36.5;     //37.981685;
            double y_max = 68;        //66.8;     //66.652421;
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords((double)x_min, (double)y_min, (double)x_max, (double)y_max);
            IEnvelope projenv = Util.transformDegPulkovoToCK42_Z6(envelope);
            m_mapControl.Extent = projenv;
            m_mapControl.ActiveView.Refresh();

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_mapControl.ActiveView.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Drawing.Runned()) return;
            Drawing drw = new Drawing(axMapControl1, m_mapControl);
            drw.Owner = this;
            drw.Show();

        }

        private void butt_ASR(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("СиС_АСР", true);
            frm.Owner = this;
            frm.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(ProgParam.alg_str);
            }
            catch
            {
                MessageBox.Show("Связанные документы открыть не удалось!");
            }
        }

        private void путиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Path2DB pdb = new Path2DB();
            pdb.Show();
        }

        private void arendator_Click(object sender, EventArgs e)
        {
            if (TreeForm.Runned()) return;
            TreeForm frm = new TreeForm("СиС_арендаторы", true);
            frm.Owner = this;
            frm.Show();
        }

        private void tsbSiS_Click(object sender, EventArgs e)
        {
            try
            {
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                m_mapControl.CurrentTool = null;
                axMapControl1.OnMouseDown +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.SiS_Calc);
            }
            catch
            {
            }
        }

        private void SiS_Calc(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //если выбран другой инструмент отписываемя от события
            if (m_mapControl.CurrentTool != null)
            {
                axMapControl1.OnMouseDown -=
                    new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.SiS_Calc);
                return;
            }

            IPoint p = Util.transformCK42_Z6ToDegPulkovo(e.mapX, e.mapY);

            List<ILayer> layerlist = GetAllLayersInMap(axMapControl1);
            List<SiS> sislist = new List<SiS>();

            for (int i = 0; i < layerlist.Count; i++)
            {
                if (layerlist[i].Name.StartsWith(@"_sisc_"))
                {
                    getInfo(e.mapX, e.mapY, layerlist[i], ref sislist);
                }
            }

            ForestPlan fp = getForestPlan(e.mapX, e.mapY, "Квартальная сеть", layerlist);

            SiSForm siscform = new SiSForm(sislist, p, fp);
            siscform.Show();
        
        
        
        
        }

        public static List<ILayer> GetAllLayersInMap(AxMapControl axMap)
        {
            List<ILayer> oLayerList = new List<ILayer>();
            try
            {
                for (int i = 0; i < axMap.LayerCount; i++)
                {
                    ILayer ipLayer = axMap.get_Layer(i);
                    
                    if (ipLayer is IGroupLayer)
                    {
                        GetAllLayersInGroupLayer(ipLayer as IGroupLayer, ref oLayerList);
                    }
                    else if (ipLayer.Valid)
                    {
                        oLayerList.Add(ipLayer);
                    }
                }

                if (oLayerList.Count == 0)
                {
                    oLayerList = null;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oLayerList;
        }

        private static void GetAllLayersInGroupLayer(IGroupLayer ipGroupLayer, ref List<ILayer> oLayerList)
        {
            try
            {
                ICompositeLayer ipCompositeLayer = ipGroupLayer as ICompositeLayer;
                for (int i = 0; i < ipCompositeLayer.Count; i++)
                {
                    ILayer ipLayer = ipCompositeLayer.get_Layer(i);
                    if (ipLayer is IGroupLayer)
                    {
                        GetAllLayersInGroupLayer(ipLayer as IGroupLayer, ref oLayerList);
                    }
                    else if (ipLayer.Valid)
                    {
                       oLayerList.Add(ipLayer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void getInfo(double x, double y, ILayer layer, ref List<SiS> sislist)
        {
            
            if (layer is IFeatureLayer)
            {
                IPoint p = new PointClass();
                p.PutCoords(x, y);

                int searchDistPixels = 0; // 10;
                IEnvelope env = areaAroundPoint(p, searchDistPixels);
                IIdentify pId = layer as IIdentify;
                IArray pArr = pId.Identify(env);

                //SiS sisc = new SiS();


                if (null == pArr)
                {
                    SiS sisc = new SiS();
                    sisc.layer = layer.Name;
                    sisc.RSCS = layer.Name.Replace(@"_sisc_", @"");
                    sisc.MO = @"";
                    sisc.Dislocation = @"";
                    sisc.Org = @"";
                    sisc.Contact = @"";
                    sisc.LS = 0;
                    sisc.Technics = 0;
                    sisc.Prim1 = @"СиС от " + sisc.RSCS + @" в данной точке недоступны";
                    sisc.Prim2 = @"";

                    sislist.Add(sisc);

                    return;
                
                }

                

                for (int i = 0; i < pArr.Count; i++)
                {
                    IIdentifyObj o = pArr.get_Element(i) as IIdentifyObj;
                    IFeatureIdentifyObj pFeatId = pArr.get_Element(i) as IFeatureIdentifyObj;
                    IRowIdentifyObject pRow = pFeatId as IRowIdentifyObject;
                    IFeature feature = pRow.Row as IFeature;
                    ITable tabl = feature.Table;
                    IGeometry geometry1 = feature.Shape;
                    IField pField = feature.Fields.get_Field(2);


                    
                    //int nuumOfFields = pRow.Row.Fields.FieldCount;

                    //2,3,4,5, string
                    //6,7,8 int
                    //9,10 string

                    //int ind = pRow.Row.Fields.FindField("Орг_я");
                    //string s = (string)pRow.Row.get_Value(ind);

                    SiS sisc = new SiS();
                    sisc.layer = layer.Name;
                    sisc.RSCS = layer.Name.Replace(@"_sisc_", @"");
                    sisc.MO = (string)pRow.Row.get_Value(2);
                    sisc.Dislocation = (string)pRow.Row.get_Value(3);
                    sisc.Org = (string)pRow.Row.get_Value(4);
                    sisc.Contact = (string)pRow.Row.get_Value(5);
                    sisc.LS = (int)pRow.Row.get_Value(6);
                    sisc.Technics = (int)pRow.Row.get_Value(7);
                    sisc.Prim1 = (string)pRow.Row.get_Value(8);
                    sisc.Prim2 = (string)pRow.Row.get_Value(9);

                    sislist.Add(sisc);
                }

                //return sisc;
            
            }
        //return null;
        }

        private ForestPlan getForestPlan(double x, double y, string layer_name_ForestPlan, List<ILayer> layerlist)
        {
            ILayer layer = null;

            for (int i = 0; i < layerlist.Count; i++)
            {
                if (layerlist[i].Name == layer_name_ForestPlan)
                {
                    layer = layerlist[i];
                }
            }

            if (layer is IFeatureLayer)
            {
                IPoint p = new PointClass();
                p.PutCoords(x, y);

                int searchDistPixels = 0; // 10;
                IEnvelope env = areaAroundPoint(p, searchDistPixels);
                IIdentify pId = layer as IIdentify;
                IArray pArr = pId.Identify(env);

                if (null == pArr)
                {
                    MessageBox.Show("Информация о лесоустройстве не найдена");
                    return null;
                }

                //for (int i = 0; i < pArr.Count; i++)
                
                    
                IIdentifyObj o = pArr.get_Element(0) as IIdentifyObj;
                IFeatureIdentifyObj pFeatId = pArr.get_Element(0) as IFeatureIdentifyObj;
                IRowIdentifyObject pRow = pFeatId as IRowIdentifyObject;
                IFeature feature = pRow.Row as IFeature;
                ITable tabl = feature.Table;
                IGeometry geometry1 = feature.Shape;
                
                //IField pField = feature.Fields.get_Field(2);
                //int nuumOfFields = pRow.Row.Fields.FieldCount;
                //3 - MO, 4 - kv, 5 - ЦЛ, 6 - УЛ, 7 - F_class, 12 - ООПТ

                //int ind = pRow.Row.Fields.FindField("Орг_я");
                //string s = (string)pRow.Row.get_Value(ind);

                ForestPlan  fp = new ForestPlan();
                   
                fp.MO = (string)pRow.Row.get_Value(3);
                fp.CL = (string)pRow.Row.get_Value(5);
                fp.UL = (string)pRow.Row.get_Value(6);
                fp.Kv = pRow.Row.get_Value(4).ToString();
                fp.F_class = (string)pRow.Row.get_Value(7);
                fp.OOPT = (string)pRow.Row.get_Value(12);

                return fp;

            }
            return null;
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (!FormLP.isRun)
            {
                FormLP flp = new FormLP(axMapControl1, m_mapControl, axToolbarControl1);
                flp.Show();
            }
        }

        private void лесныеПожарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormLP.isRun)
            {
                FormLP flp = new FormLP(axMapControl1, m_mapControl, axToolbarControl1);
                flp.Show();
            }
        }

        private void погодаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\zyGrib", "zyGrib.exe");
        }

        private void погодаСводкаОтЦГМСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\Прогноз ЦГМС", "Текущий прогноз ЦГМС.doc");
        }

        private void твердыеВзрывчатыеВеществаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\4", "blast-s.exe");
        }

        private void топливовоздушнаяСмесьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\2", "blast-fam.exe");
        }

        private void газоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\3", "blast-gam.exe");
        }

        private void пылевоздушнаяСмесьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\1", "blast-d.exe");
        }

        private void горениеЛВЖToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\5", "blast-l.exe");
        }

        private void карточкиАХОВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\АХОВ", "Аварийные карточки.mdb");
        }

        private void аварииСАХОВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\6", "ahovapp.exe");
        }




        public void call_ex_prog(string exprog_path, string name_prog)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.WorkingDirectory = ExecPath + exprog_path;
                proc.StartInfo.FileName = name_prog;
                proc.Start();
                //proc.WaitForExit();
            }
            catch
            {
                MessageBox.Show("Ошибка запуска внешней программы!\n" + exprog_path + "\\" + name_prog);
            }


        }

        private void сетевойГрафикПроизводстваРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\Сетевой график", "sg.exe");
        }

        private void расчетПаденияТемпературыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\ЖКХ", "Расчет падения температуры в здании.xls");
        }

        private void расчетСнабженияВодойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call_ex_prog("\\ЖКХ", "Расчеты по воде.xls");
        }


        


        

    
    } //end class


   
   




    public class SiS
        {
        public string layer;
        public string RSCS;
        public string MO;
        public string Dislocation;
        public string Contact;
        public string Org;
        public int LS;
        public int Technics;
        public string Prim1;
        public string Prim2;
        }

    public class ForestPlan
    {
        public string MO;
        public string CL;
        public string UL;
        public string Kv;
        public string F_class;
        public string OOPT;
    }

   




} //end ns