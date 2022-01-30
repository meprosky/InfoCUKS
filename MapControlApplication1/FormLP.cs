using System;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;


namespace InfoCUKS
{
    public partial class FormLP : Form
    {
        public int iV, iVSiS, iWoodType, iEmerType, iEmerTypeSiS, iFirType, iAngleRad;
        public int SiSls, SiSt;
        public double P0, S0=1, R0, Sprogn, Pprogn, deltaP, TimeProgn=1, Vf, Vfl, Vt;
        public double angleRad, km, km_t;
        public bool AllOK = true;

        public AxToolbarControl axToolbarControl1;
        public AxMapControl axMapControl1; 
        public IMapControl3 m_mapControl;

        public static bool isRun = false;




        public FormLP(AxMapControl axMapControl1, IMapControl3 m_mapControl, AxToolbarControl axToolbarControl1)
        {
            InitializeComponent();

            isRun = true;

            iV = this.cboxVwind.SelectedIndex;
            iWoodType = this.cboxWoodType.SelectedIndex;
            iEmerType = this.cboxEmerClass.SelectedIndex;
            iFirType = this.cboxFirType.SelectedIndex;

            this.axMapControl1 = axMapControl1;
            this.m_mapControl = m_mapControl;
            this.axToolbarControl1 = axToolbarControl1;
            this.axToolbarControl1.SetBuddyControl(this.axMapControl1);

            try
            {
                
               
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;

                Util.deselect_tool(m_mapControl, axToolbarControl1);
                m_mapControl.CurrentTool = null;
                axMapControl1.OnMouseDown +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClickWildFire);
            }
            catch
            {
            }


        }
        /*
        private void button_Close(object sender, EventArgs e)
        {
            
        }
         * */

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cboxVwind.Items.AddRange(Fir1.Vwind);
            this.cboxVwind.SelectedIndex = 0;

            this.cboxFirType.Items.AddRange(Fir1.FirType);
            this.cboxFirType.SelectedIndex = 0;


            this.cboxWoodType.Items.AddRange(Fir1.WoodType);
            this.cboxWoodType.SelectedIndex = 0;

            this.cboxEmerClass.Items.AddRange(Fir1.FirEmerClass);
            this.cboxEmerClass.SelectedIndex = 0;

            this.cBoxWindDirection.Items.AddRange(Fir1.sWindDirection);
            this.cBoxWindDirection.SelectedIndex = 0;

            this.tboxS0.Text = "1";
            this.tBoxTime.Text = "1";

            //this.chkbOchag.Checked = true;
            //this.chkBoxInfo.Checked = true;

            S0 = Convert.ToDouble(this.tboxS0.Text);
            TimeProgn = Convert.ToDouble(this.tBoxTime.Text);
            
            Area_and_Perimetr();

            ViewPrognoz();
        }

        private void ViewPrognoz()
        {
            iV = this.cboxVwind.SelectedIndex;
            iFirType = this.cboxFirType.SelectedIndex;
            iWoodType = this.cboxWoodType.SelectedIndex;
            
            //iEmerType2 = this.cboxEmerClass.SelectedIndex;
            
            switch (this.cboxEmerClass.SelectedIndex)
            {
                case 0: iEmerType = 0; iEmerTypeSiS = 0; break;  //2 класс, для СиС 3-й
                case 1: iEmerType = 1; iEmerTypeSiS = 0; break;  //3
                case 2: iEmerType = 1; iEmerTypeSiS = 1; break;  //4 
                case 3: iEmerType = 1; iEmerTypeSiS = 2; break;  //5 класс
                default: iEmerType = 0; break;
            }

            switch (this.cboxVwind.SelectedIndex)
            {
                case 0:                                
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: iVSiS = 0; break;
                case 6: 
                case 7:
                case 8: iVSiS = 1; break;
                case 9: iVSiS = 2; break;
                default: iVSiS = 0; break;
            }




            iAngleRad = this.cBoxWindDirection.SelectedIndex;

            Vf  = Fir1.V[iV, iFirType, iWoodType, iEmerType, 0];
            Vfl = Fir1.V[iV, iFirType, iWoodType, iEmerType, 1];
            Vt  = Fir1.V[iV, iFirType, iWoodType, iEmerType, 2];
            


            angleRad = Fir1.radWindDirection[iAngleRad];

            km = Convert.ToDouble(this.tboxKM.Text);
            km_t = km * 1000 / Vf;
            this.tboxKM_T.Text = km_t.ToString("F1", CultureInfo.InvariantCulture);

            Area_and_Perimetr();

                        
            SiSls = Fir1.SiS[0, iVSiS, iEmerTypeSiS, 0];
            SiSt = Fir1.SiS[0, iVSiS, iEmerTypeSiS, 1];

            

            int ns = Fir1.S_Sis.Length;

            for (int i = 1; i < ns; i++)
            {
                if (Sprogn > Fir1.S_Sis[i-1] && Sprogn < Fir1.S_Sis[i])
                {
                    
                    
                    
                    SiSls =(int)Math.Ceiling(
                        Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 0] +
                            (Fir1.SiS[i, iVSiS, iEmerTypeSiS, 0] - Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 0]) /
                            (Fir1.S_Sis[i] - Fir1.S_Sis[i - 1]) * 
                            (Sprogn - Fir1.S_Sis[i-1])
                            );

                    SiSt = (int)Math.Ceiling(
                        Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 1] +
                            (Fir1.SiS[i, iVSiS, iEmerTypeSiS, 1] - Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 1]) /
                            (Fir1.S_Sis[i] - Fir1.S_Sis[i - 1]) *
                            (Sprogn - Fir1.S_Sis[i - 1])
                            );


                    if (Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 1] == 0 && Fir1.SiS[i, iVSiS, iEmerTypeSiS, 1] == 1 &&
                        Sprogn > Fir1.S_Sis[i - 1])
                    {
                        SiSls = Fir1.SiS[i, iVSiS, iEmerTypeSiS, 0];
                        SiSt = Fir1.SiS[i, iVSiS, iEmerTypeSiS, 1];
                    }


                    break;
                }
                else if (Sprogn > 500)
                {
                    
                    SiSls = (int)Math.Ceiling(Fir1.SiS[ns-1, iVSiS, iEmerTypeSiS, 0] * Sprogn / 500);
                    SiSls = (int)(Math.Ceiling((double)SiSls / 10) * 10);
                    SiSt = (int)Math.Ceiling(Fir1.SiS[ns - 1, iVSiS, iEmerTypeSiS, 1] * Sprogn / 500);
                    break;
                }
                else if (Sprogn == Fir1.S_Sis[i - 1])
                {
                    SiSls = Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 0];
                    SiSt = Fir1.SiS[i - 1, iVSiS, iEmerTypeSiS, 1];
                    break;
                }
                
            }

           
                       
            
            
            string textProgn2 ="Исходные данные.\r\n" +
                               "Координаты очага: задайте центр очага пожара на карте\r\n" +
                               "Площадь очага: " + S0.ToString() + " Га\r\n" +
                               "Ветер: " + Fir1.sWindDirection[this.cBoxWindDirection.SelectedIndex] + ", " + Fir1.Vwind[this.cboxVwind.SelectedIndex] + " м/с\r\n" +
                               "Вид пожара: " + Fir1.FirType[this.cboxFirType.SelectedIndex] + "\r\n" +
                               "Класс горимости насаждений: " + Fir1.WoodType[this.cboxWoodType.SelectedIndex] + "\r\n" +
                               "Класс пожарной опасности погоды: " + Fir1.FirEmerClass[this.cboxEmerClass.SelectedIndex] + "\r\n\r\n" +
                               "Прогноз развития через " + TimeProgn.ToString() + " час.\r\n" +
                               "Площадь: " + Sprogn.ToString("F2", CultureInfo.InvariantCulture) + " Га " +
                               "Периметр: " + Pprogn.ToString("F0", CultureInfo.InvariantCulture) + " м\r\n" +
                               "Скорость : " + "фронт " + Vf.ToString() + " м/час, фланги " + Vfl.ToString() + " м/час, тыл " + Vt.ToString() + " м/час";
            
            string textSiS =   "Л/С: " + SiSls.ToString() + " чел.\r\n" +
                               "Техника: " + SiSt.ToString() + " ед.\r\n" +
                               "(бульдозеры, тракторы с плугами, пожарные агрегаты)";


            this.tboxSiS.Text = textSiS;
            
            
            this.tBoxPrognoz.Text = textProgn2;   
        }

        private void cboxVwind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ViewPrognoz();
        }

        private void Area_and_Perimetr()
        {
            P0 = 500 * Math.Sqrt(S0);
            R0 = Math.Sqrt(S0 * 10000 / Math.PI);   //в метрах

            deltaP = 3.3 * Vf * TimeProgn;
            Pprogn = P0 + deltaP;
            Sprogn = 0.000004 * Pprogn * Pprogn;
        }

        private void tboxS0_TextChanged(object sender, EventArgs e)
        {

            try
            {
                S0 = Convert.ToDouble(this.tboxS0.Text);
                this.labelS.ForeColor = SystemColors.ControlText;
                this.AllOK = true;
            }
            catch
            {

                this.labelS.ForeColor = Color.Red;
                if (this.tboxS0.Text != "")
                {
                    MessageBox.Show("Введено неправильное число");
                }
                this.tboxS0.SelectAll();
                this.AllOK = false;
            }

            ViewPrognoz();
        }

        private void tBoxTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TimeProgn = Convert.ToDouble(this.tBoxTime.Text);
                this.labelT.ForeColor = SystemColors.ControlText;
                this.AllOK = true;
            }
            catch
            {
                this.labelT.ForeColor = Color.Red;
                if (this.tBoxTime.Text != "")
                {
                    MessageBox.Show("Введено неправильное число");
                }
                this.tBoxTime.SelectAll();
                this.AllOK = false;
            }
            ViewPrognoz();
        }

        private void tboxS0_Leave(object sender, EventArgs e)
        {
            try
            {
                S0 = Convert.ToDouble(this.tboxS0.Text);
            }
            catch
            {
                MessageBox.Show("Введено неправильное число");
                this.tboxS0.Focus();
            }
        }

        private void tboxKM_TextChanged(object sender, EventArgs e)
        {
            try
            {
               km = Convert.ToDouble(this.tboxKM.Text);
               this.label8.ForeColor = SystemColors.ControlText;
            }
            catch
            {
                this.label8.ForeColor = Color.Red;
                if (this.tBoxTime.Text != "")
                {
                    MessageBox.Show("Введено неправильное число");
                }
                this.tboxKM.SelectAll();
            }
            km_t = km * 1000 / Vf;
            this.tboxKM_T.Text = km_t.ToString("F1", CultureInfo.InvariantCulture);
        }


        private void EnterText_Activated(object sender, EventArgs e)
        {
            //if (m_mapControl == null) return;
            

        }

        public void getClickWildFire(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //если выбран другой инструмент отписываемя от события
            if (m_mapControl.CurrentTool != null)
            {
                axMapControl1.OnMouseDown -=
                    new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClickWildFire);
                return;
            }

            IPoint p = new PointClass();
            p.PutCoords(e.mapX, e.mapY);

            DrawFirePrognoz5(m_mapControl.ActiveView, p);




            

        }

        public void DrawFirePrognoz5(ESRI.ArcGIS.Carto.IActiveView activeView, IPoint point)
        {
            double x0, y0, x1, x2, y1, y2, a, b;


            /*
            double R0 = ib.R0;
            double S0 = ib.S0;
            double AngleRad = ib.angleRad;
            double TimeProgn = ib.TimeProgn;
            double Sprogn = ib.Sprogn;
            double Pprogn = ib.Pprogn;
            double Vf = ib.Vf;
            double Vfl = ib.Vfl;
            double Vt = ib.Vt;
            int Vwind = ib.cboxVwind.SelectedIndex;
            int SiSls = ib.SiSls;
            int SiSt = ib.SiSt;
            */

            int Vwind = cboxVwind.SelectedIndex;

            x0 = point.X;
            y0 = point.Y;
            x1 = point.X - R0 - Vt * TimeProgn;
            x2 = point.X + R0 + Vf * TimeProgn;
            y1 = point.Y - R0 - Vfl * TimeProgn;
            y2 = point.Y + R0 + Vfl * TimeProgn;


            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast

            IRgbColor rgbColor1 = new RgbColorClass();
            rgbColor1.Red = 255;
            rgbColor1.Green = 0;
            rgbColor1.Blue = 0;
            IColor color1 = rgbColor1;
            ISimpleLineSymbol pLineSym = new SimpleLineSymbolClass();
            pLineSym.Color = rgbColor1;
            pLineSym.Width = 1.5;
            pLineSym.Style = esriSimpleLineStyle.esriSLSSolid;
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            simpleFillSymbol.Color = color1;
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSNull;
            simpleFillSymbol.Outline = pLineSym;
            ISymbol symbol = simpleFillSymbol as ISymbol;
            IFillShapeElement fillShape = new PolygonElementClass();
            fillShape.Symbol = (IFillSymbol)symbol;


            IRgbColor rgbColor2 = new RgbColorClass();
            rgbColor2.Red = 255;
            rgbColor2.Green = 0;
            rgbColor2.Blue = 0;
            IColor color2 = rgbColor2;
            ISimpleLineSymbol pLineSym2 = new SimpleLineSymbolClass();
            pLineSym2.Color = rgbColor2;
            pLineSym2.Width = 1;
            pLineSym2.Style = esriSimpleLineStyle.esriSLSSolid;
            ISimpleFillSymbol simpleFillSymbol2 = new SimpleFillSymbolClass();
            simpleFillSymbol2.Color = color2;
            simpleFillSymbol2.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
            simpleFillSymbol2.Outline = pLineSym2;
            ISymbol symbol2 = simpleFillSymbol2 as ISymbol;
            IFillShapeElement fillShape2 = new PolygonElementClass();
            fillShape2.Symbol = (IFillSymbol)symbol2;

            //text
            IRgbColor rgbColorText = new RgbColorClass();
            rgbColorText.Red = 255;
            rgbColorText.Green = 255;
            rgbColorText.Blue = 255;
            IColor colorText = rgbColorText;

            object Missing = Type.Missing;

            ISegmentCollection segCol = new PolygonClass();
            IElement pElement = new PolygonElementClass();

            //пересчитываем параметры эллипса под площадь
            IConstructEllipticArc FireProgEllipse = new EllipticArcClass();
            IEnvelope env = new EnvelopeClass();

            if (Vwind == 0) //если ветер = 0 то рисуем круг
            {
                a = Math.Sqrt(Sprogn * 10000 / Math.PI);
                b = a;
                x1 = x0 - a;
                x2 = x0 + a;
            }
            else
            {
                a = (x2 - x1) / 2;
                b = Sprogn * 10000 / (Math.PI * a);
            }

            env.XMin = x1;
            env.YMin = y0 - b;
            env.XMax = x2;
            env.YMax = y0 + b;

            FireProgEllipse.ConstructEnvelope(env);

            segCol.AddSegment((ISegment)FireProgEllipse, ref Missing, ref Missing);

            double ang2 = 0; //GetAnglZonePopr(point);

            //поворачиваем эллипс
            ITransform2D pTransform;

            pTransform = segCol as ITransform2D;
            pTransform.Rotate(point, angleRad + ang2);

            pElement = fillShape as IElement;
            pElement.Geometry = segCol as IGeometry;

            activeView.GraphicsContainer.AddElement(pElement, 0); //добавляем эллипс пожара

            string textLat = GetDMSck42(point, 0);
            string textLong = GetDMSck42(point, 1);

            string textProgn = "Очаг: " + textLat + "сш  " + textLong + "вд\r\n" +
                               "Площадь очага: " + S0.ToString() + " Га\r\n" +
                               "Ветер: " + Fir1.sWindDirection[cBoxWindDirection.SelectedIndex] + ", " + Fir1.Vwind[cboxVwind.SelectedIndex] + " м/с\r\n\r\n" +
                               "ПРОГНОЗ РАЗВИТИЯ через " + TimeProgn.ToString() + " час.\r\n" +
                               "Площадь: " + Sprogn.ToString("F2", CultureInfo.InvariantCulture) + " Га " +
                               "Периметр: " + Pprogn.ToString("F0", CultureInfo.InvariantCulture) + " м\r\n";


            string textProgn2 = "Исходные данные.\r\n" +
                               "Координаты очага: " + textLat + "сш  " + textLong + "вд\r\n" +
                               "Площадь очага: " + S0.ToString() + " Га\r\n" +
                               "Ветер: " + Fir1.sWindDirection[cBoxWindDirection.SelectedIndex] + ", " + Fir1.Vwind[cboxVwind.SelectedIndex] + " м/с\r\n" +
                               "Тип пожара: " + Fir1.FirType[cboxFirType.SelectedIndex] + "\r\n" +
                               "Класс горимости насаждений: " + Fir1.WoodType[cboxWoodType.SelectedIndex] + "\r\n" +
                               "Класс пожарной опасности погоды: " + Fir1.FirEmerClass[cboxEmerClass.SelectedIndex] + "\r\n\r\n" +
                               "Прогноз развития через " + TimeProgn.ToString() + " час.\r\n" +
                               "Площадь: " + Sprogn.ToString("F2", CultureInfo.InvariantCulture) + " Га " +
                               "Периметр: " + Pprogn.ToString("F0", CultureInfo.InvariantCulture) + " м\r\n" +
                               "Скорость : " + "фронт " + Vf.ToString() + " м/час, фланги " + Vfl.ToString() + " м/час, тыл " + Vt.ToString() + " м/час";

            string textSiS = "\r\nСИС НЕОБХОДИМЫЕ ДЛЯ ЛИКВИДАЦИИ ЛП\r\n" +
                              "л/с: " + SiSls.ToString() + " чел.\r\n" +
                              "техника: " + SiSt.ToString() + " ед. " +
                              "(бульд., тр-ра с плугами, пож. агр-ты)";




            tBoxPrognoz.Text = textProgn2;

            IPoint textPoint = new PointClass();
            textPoint.PutCoords(x2, y0);



            if (chkBoxInfo.Checked)
            {
                if (chkBoxSiS.Checked)
                {
                    AddTextToPointCoor(activeView, textPoint, point, textProgn + textSiS, angleRad + ang2);
                }
                else
                {
                    AddTextToPointCoor(activeView, textPoint, point, textProgn, angleRad + ang2);
                }
            }



            if (chkbOchag.Checked) //рисуем очаг пожара
            {
                IConstructCircularArc pCirc = new CircularArcClass();
                pCirc.ConstructCircle(point, R0, false);
                ISegment segmentochag = pCirc as ISegment;
                ISegmentCollection polygonochag = new PolygonClass();
                polygonochag.AddSegment(segmentochag, ref Missing, ref Missing);
                IElement pElemochag = new PolygonElementClass();
                pElemochag = fillShape2 as IElement;

                pElemochag.Geometry = polygonochag as IGeometry;
                activeView.GraphicsContainer.AddElement(pElemochag, 0);
            }

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            screenDisplay.FinishDrawing();

        }

        public string GetDMSck42(IPoint tpoint, int ll) //0 - lat, 1 - long
        {

            ISpatialReferenceFactory pSpatialRefFactory = new SpatialReferenceEnvironmentClass();
            IGeographicCoordinateSystem pGeogrpahicCoordSys = pSpatialRefFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            ISpatialReference pSpatialRef = pGeogrpahicCoordSys;


            ISpatialReferenceFactory pSpatialRefFactory2 = new SpatialReferenceEnvironmentClass();
            IProjectedCoordinateSystem pProjectCoordSys = pSpatialRefFactory2.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);
            ISpatialReference pProjSpRef = pProjectCoordSys;

            IGeometry pGeometry = new PointClass();

            pGeometry = ((IClone)tpoint).Clone() as IGeometry;
            pGeometry.SpatialReference = pProjSpRef;

            try
            {
                pGeometry.Project(pSpatialRef);
            }
            catch
            {
                MessageBox.Show("Очаг пожара задана неверно");
            }

            ILatLonFormat latlon = new LatLonFormatClass();
            int D, M;
            double S;

            if (ll == 0)
            {
                try
                {
                    latlon.GetDMS((pGeometry as IPoint).Y, out D, out M, out S);
                }
                catch
                {
                    MessageBox.Show("Очаг пожара задан неверно");
                    D = 0; M = 0; S = 0;
                }

            }
            else
            {

                try
                {
                    latlon.GetDMS((pGeometry as IPoint).X, out D, out M, out S);
                }
                catch
                {
                    //MessageBox.Show("Очаг пожара задан неверно");
                    D = 0; M = 0; S = 0;
                }

            }



            return D.ToString() + "°" + M.ToString() + "'" + S.ToString("F0", CultureInfo.InvariantCulture) + @"""";
        }

        public void AddTextToPointCoor(ESRI.ArcGIS.Carto.IActiveView activeView, IPoint textPoint, IPoint centralPoint, string s, double rotangle)
        {

            IRgbColor rgbColorText = new RgbColorClass();
            rgbColorText.Red = 255;
            rgbColorText.Green = 0;
            rgbColorText.Blue = 0;
            //IColor colorText = rgbColorText;

            IRgbColor rgbColorCallout = new RgbColorClass();
            rgbColorCallout.Red = 255;
            rgbColorCallout.Green = 255;
            rgbColorCallout.Blue = 115;
            //IColor colorTextShad = rgbColorShad;

            IRgbColor rgbColorOutline = new RgbColorClass();
            rgbColorOutline.Red = 0;
            rgbColorOutline.Green = 0;
            rgbColorOutline.Blue = 0;
            //IColor colorOutline = rgbColorOutline;

            ITextElement textElem = new TextElementClass();
            IElement pElem;

            stdole.IFontDisp fnt = (stdole.IFontDisp)new stdole.StdFontClass();
            fnt.Name = "Arial";
            //fnt.Name = "Courier New";

            fnt.Size = 10; //12;
            fnt.Bold = false; // true;

            IFormattedTextSymbol textSym = new TextSymbolClass();
            textSym.Font = fnt;
            textSym.Color = rgbColorText;
            textSym.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;

            IFillSymbol fillSymb = new SimpleFillSymbolClass();
            ILineSymbol lineSymb = new SimpleLineSymbolClass();
            lineSymb.Color = rgbColorOutline;
            lineSymb.Width = 1;
            fillSymb.Color = rgbColorCallout;
            fillSymb.Outline = lineSymb;

            IBalloonCallout bCallout = new BalloonCalloutClass();
            bCallout.Style = esriBalloonCalloutStyle.esriBCSRectangle;
            bCallout.Symbol = fillSymb;

            IPoint textPoint2 = new PointClass();
            textPoint2.PutCoords(textPoint.X + 100, textPoint.Y);
            (textPoint2 as ITransform2D).Rotate(centralPoint, rotangle);

            ITransform2D pTransform = textPoint as ITransform2D;
            pTransform.Rotate(centralPoint, rotangle);

            bCallout.AnchorPoint = textPoint;

            textSym.Background = bCallout as ITextBackground;
            textElem.Text = s;
            textElem.Symbol = textSym;

            pElem = textElem as IElement;
            pElem.Geometry = textPoint2 as IGeometry;

            activeView.GraphicsContainer.AddElement(pElem, 0);

        }

        public double GetAnglZonePopr(IPoint point)
        {

            ISpatialReferenceFactory pSpatialRefFactory = new SpatialReferenceEnvironmentClass();
            IGeographicCoordinateSystem pGeogrpahicCoordSys = pSpatialRefFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            ISpatialReference pSpatialRef = pGeogrpahicCoordSys;


            ISpatialReferenceFactory pSpatialRefFactory2 = new SpatialReferenceEnvironmentClass();
            IProjectedCoordinateSystem pProjectCoordSys = pSpatialRefFactory2.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);
            ISpatialReference pProjSpRef = pProjectCoordSys;

            IGeometry pGeometry = new PointClass();

            pGeometry = ((IClone)point).Clone() as IGeometry;
            pGeometry.SpatialReference = pProjSpRef;

            try
            {
                pGeometry.Project(pSpatialRef);
            }
            catch
            {
                //MessageBox.Show("Очаг пожара задана неверно");
                return 0;
            }

            ILatLonFormat latlon = new LatLonFormatClass();
            int D, M;
            double S;

            try
            {
                latlon.GetDMS((pGeometry as IPoint).Y, out D, out M, out S);
            }
            catch
            {
                //MessageBox.Show("Очаг пожара задан неверно");
                return 0;
            }

            int zoneGK, zone6 = 6;
            double dz;

            zoneGK = (int)Math.Ceiling((pGeometry as IPoint).X / 6);

            double angle6rad = (6 - 0.71616) * Math.PI / 180;

            dz = (zoneGK - zone6) * angle6rad;

            return dz;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                Util.deselect_tool(m_mapControl, axToolbarControl1);
                m_mapControl.CurrentTool = null;
                axMapControl1.OnMouseDown +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClickWildFire);
            }
            catch
            {
            }
        }

        private void FormLP_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRun = false;
            this.Dispose();
            //Util.deselect_tool(m_mapControl, axToolbarControl1);
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            axMapControl1.OnMouseDown -=
                    new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClickWildFire);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            isRun = false;
            this.Dispose();
            //Util.deselect_tool(m_mapControl, axToolbarControl1);
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            axMapControl1.OnMouseDown -=
                    new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClickWildFire);

        }



      
    
       
                
    }
}