using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;


namespace InfoCUKS
{
    public partial class Drawing : Form
    {
        //IMapControl3 m_mapControl;
        public static bool isrun = false;
        public AxMapControl axMapControl1;
        public IMapControl3 m_mapControl;
        private IGraphicProperties m_graphicProperties;
        public int R = 255, G = 0, B = 0;
        public Font font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
        public float font_size = 10;
        public bool font_isbold = false;
        public bool font_isitalic = false;

        public static bool Runned()
        {
            return isrun;
        }
        


        public Drawing(AxMapControl axMapControl1, IMapControl3 mc)
		{
			InitializeComponent();
            //m_mapControl = mc;
            this.axMapControl1 = axMapControl1;
            this.m_mapControl = mc;
            isrun = true;
		}

     

        private void Drawing_Load(object sender, EventArgs e)
        {
            axToolbarControl1.SetBuddyControl(axMapControl1);
            
            Color bclr = Color.FromArgb(this.BackColor.R, this.BackColor.G, this.BackColor.B);
            axToolbarControl1.BackColor = bclr;
            
            
            //Get the ArcGIS install location by opening the subkey for reading
            //Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\ESRI\\CoreRuntime", true);
            //Load the ESRI.ServerStyle file into the SymbologyControl
            //axSymbologyControl1.LoadStyleFile(regKey.GetValue("InstallDir") + "\\Styles\\ESRI.ServerStyle");
            axSymbologyControl1.LoadStyleFile(ProgParam.stylePath);

            comboBox1.Items.Add("Знаки");
            comboBox1.Items.Add("Линии");
            comboBox1.Items.Add("Заполнение");
            comboBox1.Items.Add("Текст");
            comboBox1.SelectedIndex = 0;

            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassMarkerSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassLineSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassFillSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassTextSymbols).Update();

            m_graphicProperties = new CommandsEnvironmentClass();

            IStyleGalleryItem styleGalleryItem = new ServerStyleGalleryItemClass();
            styleGalleryItem.Name = "myStyle";

            ISymbologyStyleClass styleClass;

            //Get the marker symbol style class
            styleClass = axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassMarkerSymbols);
            
            
            
            //Set the commands environment marker symbol into the item
            styleGalleryItem.Item = m_graphicProperties.MarkerSymbol;
            //Add the item to the style class
            styleClass.AddItem(styleGalleryItem, 0);

            //Get the line symbol style class
            styleClass = axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassLineSymbols);
            //Set the commands environment line symbol into the item
            styleGalleryItem.Item = m_graphicProperties.LineSymbol;
            //Add the item to the style class
            styleClass.AddItem(styleGalleryItem, 0);

            //Get the fill symbol style class
            styleClass = axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassFillSymbols);
            //Set the commands environment fill symbol into the item
            styleGalleryItem.Item = m_graphicProperties.FillSymbol;
            //Add the item to the style class
            styleClass.AddItem(styleGalleryItem, 0);

            //Get the text symbol style class
            styleClass = axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassTextSymbols);
            //Set the commands environment text symbol into the item
            styleGalleryItem.Item = m_graphicProperties.TextSymbol;
            //Add the item to the style class
            styleClass.AddItem(styleGalleryItem, 0);

            axMapControl1.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(get_click_fr_map);



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the SymbologyControl style class
            if (comboBox1.SelectedItem.ToString() == "Знаки")
                axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            else if (comboBox1.SelectedItem.ToString() == "Линии")
                axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
            else if (comboBox1.SelectedItem.ToString() == "Заполнение")
                axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
            else if (comboBox1.SelectedItem.ToString() == "Текст")
                axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassTextSymbols;
        
            //m_mapControl.on
        
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            IStyleGalleryItem styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;

            if (styleGalleryItem.Item is IMarkerSymbol)
                //Set the default marker symbol
                m_graphicProperties.MarkerSymbol = (IMarkerSymbol)styleGalleryItem.Item;
            else if (styleGalleryItem.Item is ILineSymbol)
                //Set the default line symbol
                m_graphicProperties.LineSymbol = (ILineSymbol)styleGalleryItem.Item;
            else if (styleGalleryItem.Item is IFillSymbol)
                //Set the default fill symbol
                m_graphicProperties.FillSymbol = (IFillSymbol)styleGalleryItem.Item;
            else if (styleGalleryItem.Item is ITextSymbol)
                //Set the default text symbol
                m_graphicProperties.TextSymbol = (ITextSymbol)styleGalleryItem.Item;
        }


        private void get_click_fr_map(object sender, IMapControlEvents2_OnMouseDownEvent e) 
        {
            if (e.button != 2) return;

            //Create a new point
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(e.mapX, e.mapY);

            //Create a new text element 
            ITextElement textElement = new TextElementClass();
            //Set the text to display todays date
            textElement.Text = DateTime.Now.ToShortDateString();

            IElement pElem = (IElement) textElement;

            pElem.Geometry = (IGeometry)pPoint;
            
            //Add element to graphics container using the CommandsEnvironment default text symbol
            (axMapControl1 as IMapControl3).ActiveView.GraphicsContainer.AddElement(pElem, 0);
               // ((IElement)textElement, pPoint, m_graphicProperties.TextSymbol, "", 0);
            //Refresh the graphics
            axMapControl1.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        
        
        
        
        }

        private void drawtext_Click(object sender, EventArgs e)
        {
            if (EnterText.Runned()) return;

            EnterText textform = new EnterText(m_mapControl, 0);
            textform.Owner = this;
            textform.Show();
        }
    
        private void drawcallouttext_Click(object sender, EventArgs e)
        {
            if (EnterText.Runned()) return;
            EnterText textform = new EnterText(m_mapControl);
            textform.Owner = this;
            textform.Show();
        }

        public void deselect_tool()
        {
            UID pUID = new UIDClass();
            pUID.Value = "esriControlCommands.ControlsSelectTool";
            ICommand pCommand = this.axToolbarControl1.CommandPool.FindByUID(pUID);
            axToolbarControl1.CurrentTool = (ITool)pCommand;
            m_mapControl.CurrentTool = null;
        }



        private void change_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bColor.BackColor = colorDialog1.Color;
                R = colorDialog1.Color.R;
                G = colorDialog1.Color.G;
                B = colorDialog1.Color.B;
            }

        }

        private void change_font_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    font = fontDialog1.Font;
                    font_size = font.Size;
                    font_isbold = font.Bold;
                    font_isitalic = font.Italic;
                }
            }
            catch
            {
                MessageBox.Show("Выберите другой шрифт");
            }

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("vrdsrsa");
        }

        private void Drawing_FormClosed(object sender, FormClosedEventArgs e)
        {
            isrun = false;
        }

      
     
      

		
    }

       
}