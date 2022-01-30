using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;

namespace InfoCUKS
{
    public partial class EnterText : Form
    {
        public static bool isRun = false;
        public IMapControl3 m_mapControl = null;
        private Drawing main;
        private int text_type  = 1;

        public EnterText(IMapControl3 mc)
        {
            InitializeComponent();
            m_mapControl = mc;
        }

        public EnterText(IMapControl3 mc, int t_type)
        {
            InitializeComponent();
            m_mapControl = mc;
            text_type = t_type;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            isRun = false;
            this.Close();
            this.Dispose();
        }

        private void EnterText_Load(object sender, EventArgs e)
        {
            isRun = true;
            if (text_type == 1)
                this.Text = "Текст с выноской";
            else
                this.Text = "Текст";

            main = this.Owner as Drawing;
            
            
            try
            {
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerPencil;
                main.deselect_tool();
                m_mapControl.CurrentTool = null;
                main.axMapControl1.OnMouseDown +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClick2);
            }
            catch
            {
            }
        
        }

        public static bool Runned()
        {
            return isRun;
        }

        private void EnterText_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRun = false;
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            //отписываемся от события
            main.axMapControl1.OnMouseDown -= new 
                ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClick2);

        }

        private void EnterText_Activated(object sender, EventArgs e)
        {
            //if (m_mapControl == null) return;
            try
            {
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerPencil;
                main.deselect_tool();
                m_mapControl.CurrentTool = null;
                main.axMapControl1.OnMouseDown +=
                        new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClick2);
            }
            catch
            {
            }

        }

        public void getClick2(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //если выбран другой инструмент отписываемя от события
            if (m_mapControl.CurrentTool != null)
            {
                main.axMapControl1.OnMouseDown -=
                    new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.getClick2);
                return;
            }

            IPoint p = new PointClass();

            string s = this.textBox1.Text;
            
            p.PutCoords(e.mapX, e.mapY);

            if (text_type == 1)
            {
                Draws.DrawCalloutText(m_mapControl.ActiveView, p, p, s, 0, main.R, main.G, main.B,
                    main.font.Name, main.font_size, main.font_isbold, main.font_isitalic);
            
            }
            else
            {
                Draws.DrawText(m_mapControl.ActiveView, p, p, s, 0, main.R, main.G, main.B, 
                    main.font.Name, main.font_size,main.font_isbold, main.font_isitalic);
            
            }

        }
    }
}