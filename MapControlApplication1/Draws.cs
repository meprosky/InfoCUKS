using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;

namespace InfoCUKS
{
    public static class Draws

    {
        public static void DrawPoint(ESRI.ArcGIS.Carto.IActiveView activeView, System.Int32 x, System.Int32 y)
        {
            
            if (activeView == null)
            {
                return;
            }
            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;


            // Constant
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast

            ISimpleMarkerSymbol simpleMarkerSymbol = new ESRI.ArcGIS.Display.SimpleMarkerSymbolClass();

            ISymbol symbol = simpleMarkerSymbol as ESRI.ArcGIS.Display.ISymbol; // Dynamic Cast

            screenDisplay.SetSymbol(symbol);

            IDisplayTransformation displayTransformation = screenDisplay.DisplayTransformation;

            // x and y are in device coordinates
            ESRI.ArcGIS.Geometry.IPoint point = displayTransformation.ToMapPoint(x, y);

            IElement pElement = new MarkerElement();

            IColor rgbColor = new RgbColorClass();

            rgbColor.RGB = 155;

            simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSDiamond;
            simpleMarkerSymbol.Color = rgbColor;
            simpleMarkerSymbol.Size = 18;

            IMarkerElement markerElement = new MarkerElementClass();
            markerElement.Symbol = simpleMarkerSymbol;
            pElement = (IElement)markerElement;

            pElement.Geometry = point;

            activeView.GraphicsContainer.AddElement(pElement, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            //screenDisplay.Invalidate(null, true, (short)esriScreenCache.esriScreenRecording);
            screenDisplay.FinishDrawing();

        }

        //public static void DrawLine(ESRI.ArcGIS.Carto.IActiveView activeView)
        public static void DrawPolyLine(ESRI.ArcGIS.Carto.IActiveView activeView, int R, int G, int B)
        {
            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast

            IRubberBand rubberBand = new  RubberLineClass();

            //IRubberBand rubberBand = new RubberPointClass();

            
            
            IGeometry geometry = rubberBand.TrackNew(screenDisplay, null);

            


            ISimpleLineSymbol lineSymbol = Draws.arc_get_LineSymbol(
                R, G, B, 1.5, esriSimpleLineStyle.esriSLSSolid);

            ILineElement lineElement = new LineElementClass();
            lineElement.Symbol = lineSymbol;

            IElement pElem = (IElement)lineElement;

            pElem.Geometry = geometry as IGeometry;  //polygon as IGeometry;

            activeView.GraphicsContainer.AddElement(pElem, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            screenDisplay.FinishDrawing();

        }
        
        public static void DrawPolygon(ESRI.ArcGIS.Carto.IActiveView activeView, int R, int G, int B)
        {
            if (activeView == null)
            {
                return;
            }

            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache);

            ESRI.ArcGIS.Display.IRubberBand rubberBand = new ESRI.ArcGIS.Display.RubberPolygonClass();
            ESRI.ArcGIS.Geometry.IGeometry geometry = rubberBand.TrackNew(screenDisplay, null);

            IPolygon pPolygon = (IPolygon)geometry;

            pPolygon.SimplifyPreserveFromTo();	//  check geomtry, to avoid "Incorrect ring ordering" error

            IFillShapeElement fillShape = Draws.arc_get_FillShapeElement(
                R, G, B, 1.5, esriSimpleLineStyle.esriSLSSolid,
                0, 255, 0, esriSimpleFillStyle.esriSFSNull);

            IElement pElem = new PolygonElementClass(); //

            pElem = fillShape as IElement;  //fillShape as IElement;

            pElem.Geometry = geometry as IGeometry;  //polygon as IGeometry;

            activeView.GraphicsContainer.AddElement(pElem, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            screenDisplay.FinishDrawing();

        }

        public static void DrawRectangle(ESRI.ArcGIS.Carto.IActiveView activeView, int R, int G, int B)
        {
            //IActiveView activeView = m_mapControl.ActiveView;

            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast

            IRubberBand rubberBand = new RubberRectangularPolygon();
            IGeometry geometry = rubberBand.TrackNew(screenDisplay, null);

            IFillShapeElement fillShape = Draws.arc_get_FillShapeElement(
                R, G, B, 1.5, esriSimpleLineStyle.esriSLSSolid,
                0, 255, 0, esriSimpleFillStyle.esriSFSNull);



            IElement pElem = new PolygonElementClass(); //

            pElem = fillShape as IElement;  //fillShape as IElement;

            pElem.Geometry = geometry as IGeometry;  //polygon as IGeometry;

            activeView.GraphicsContainer.AddElement(pElem, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            screenDisplay.FinishDrawing();

            //axMapControl1.OnMouseDown -=
            //        new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.DrawRectangle);
            
        }

        public static void DrawEllipse(ESRI.ArcGIS.Carto.IActiveView activeView, int R, int G, int B)
        {

            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast

            IRubberBand rubberBand = new RubberEnvelopeClass();
            IGeometry geometry = rubberBand.TrackNew(screenDisplay, null);

            IFillShapeElement fillShape = Draws.arc_get_FillShapeElement(
                R, G, B, 1.5, esriSimpleLineStyle.esriSLSSolid,
                0, 255, 0, esriSimpleFillStyle.esriSFSNull);          //esriSFSDiagonalCross);

            IConstructEllipticArc pEll = new EllipticArcClass();
            pEll.ConstructEnvelope(geometry as IEnvelope);

            ISegment segment = pEll as ISegment;
            ISegmentCollection polygon = new PolygonClass();
            object Missing = Type.Missing;
            polygon.AddSegment(segment, ref Missing, ref Missing);

            IElement pElem = new PolygonElementClass(); //

            pElem = fillShape as IElement;  

            pElem.Geometry = polygon as IGeometry;  

            activeView.GraphicsContainer.AddElement(pElem, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            screenDisplay.FinishDrawing();

        }

        public static void DrawCircle(ESRI.ArcGIS.Carto.IActiveView activeView, int R, int G, int B)
        {

            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast

            IRubberBand rubberBand = new RubberCircleClass();
            IGeometry geometry = rubberBand.TrackNew(screenDisplay, null);

            IFillShapeElement fillShape = Draws.arc_get_FillShapeElement(
                R, G, B, 1.5, esriSimpleLineStyle.esriSLSSolid,
                0, 255, 0, esriSimpleFillStyle.esriSFSNull);

      
            ISegment segment = geometry as ISegment;
            ISegmentCollection polygon = new PolygonClass();
            object Missing = Type.Missing;
            polygon.AddSegment(segment, ref Missing, ref Missing);

            IElement pElem = new PolygonElementClass(); //

            pElem = fillShape as IElement;

            pElem.Geometry = polygon as IGeometry;

            activeView.GraphicsContainer.AddElement(pElem, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            screenDisplay.FinishDrawing();

        }
       
        public static void DrawCalloutText(ESRI.ArcGIS.Carto.IActiveView activeView, IPoint textPoint, IPoint centralPoint, string s, double rotangle,
            int R, int G, int B, string font_name, float font_size, bool isbold, bool isitalic)
        {

            IRgbColor rgbColorText = new RgbColorClass();
            rgbColorText.Red = R;
            rgbColorText.Green = G;
            rgbColorText.Blue = B;
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
            fnt.Name = font_name;
            //fnt.Name = "Courier New";

            fnt.Size = Convert.ToInt32(font_size); //12;
            fnt.Bold = isbold; // true;
            fnt.Italic = isitalic;

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

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            activeView.ScreenDisplay.FinishDrawing();

        }

        public static void DrawText(ESRI.ArcGIS.Carto.IActiveView activeView, IPoint textPoint, IPoint centralPoint,
            string s, double rotangle, int R, int G, int B, string font_name, float font_size, bool isbold, bool isitalic)
        {

            IRgbColor rgbColorText = new RgbColorClass();
            rgbColorText.Red = R;
            rgbColorText.Green = G;
            rgbColorText.Blue = B;
            IColor colorText = rgbColorText;
            
            ITextElement textElem = new TextElementClass();
            
            IElement pElem;

            stdole.IFontDisp fnt = (stdole.IFontDisp)new stdole.StdFontClass();
            fnt.Name = font_name;         //"Arial";
            //fnt.Name = "Courier New";

            fnt.Size = Convert.ToInt32(font_size); //12;
            fnt.Bold = isbold;        //false; // true;
            fnt.Italic = isitalic;

            ITextSymbol textSym = new TextSymbolClass();
            textSym.Font = fnt;
            textSym.Color = colorText;
            textSym.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
            
            textElem.Text = s;
            textElem.Symbol = textSym;

            pElem = textElem as IElement;
            pElem.Geometry = textPoint as IGeometry;

            activeView.GraphicsContainer.AddElement(pElem, 0);

            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            activeView.ScreenDisplay.FinishDrawing();

        }

        public static IFillShapeElement arc_get_FillShapeElement(
               int R_l, int G_l, int B_l, double width_l,
               ESRI.ArcGIS.Display.esriSimpleLineStyle style_l,
               int R_f, int G_f, int B_f,
               ESRI.ArcGIS.Display.esriSimpleFillStyle style_f)
        {
            IRgbColor rgbColor_l = new RgbColorClass();
            rgbColor_l.Red = R_l;
            rgbColor_l.Green = G_l;
            rgbColor_l.Blue = B_l;
            IColor color_l = rgbColor_l;

            ISimpleLineSymbol pLineSym = new SimpleLineSymbolClass();
            pLineSym.Color = color_l;
            pLineSym.Width = width_l;
            pLineSym.Style = style_l;

            RgbColor rgbColor_f = new RgbColorClass();
            rgbColor_f.Red = R_f;
            rgbColor_f.Green = G_f;
            rgbColor_f.Blue = B_f;
            IColor color_f = rgbColor_f;

            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            simpleFillSymbol.Color = color_f;
            simpleFillSymbol.Style = style_f;        //esriSFSSolid;       //esriSFSNull;
            simpleFillSymbol.Outline = pLineSym;

            ISymbol symbol = simpleFillSymbol as ISymbol;

            IFillShapeElement fillShape = new PolygonElementClass();
            fillShape.Symbol = (IFillSymbol)symbol;

            return fillShape;

        }

        public static ISimpleLineSymbol arc_get_LineSymbol(
            int R_l, int G_l, int B_l, double width_l,
            ESRI.ArcGIS.Display.esriSimpleLineStyle style_l)
        {
            IRgbColor rgbColor_l = new RgbColorClass();
            rgbColor_l.Red = R_l;
            rgbColor_l.Green = G_l;
            rgbColor_l.Blue = B_l;
            IColor color_l = rgbColor_l;

            ISimpleLineSymbol pLineSym = new SimpleLineSymbolClass();
            pLineSym.Color = color_l;
            pLineSym.Width = width_l;
            pLineSym.Style = style_l;
            

            return pLineSym;  //symbol;

        }
    
    }
}
