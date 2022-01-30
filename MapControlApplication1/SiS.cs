using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;

namespace InfoCUKS
{
    public partial class SiSForm : Form
    {

        List<SiS> sislist;
        //IPoint p;
        
        public SiSForm(List<SiS> sislist, IPoint p, ForestPlan fp)
        {
            InitializeComponent();

            //this.p = p;

            int D, M, S;
            string coor;


            D = (int)(p.Y);
            M = (int)((p.Y - D) * 60);
            S = (int)Math.Floor((p.Y - D - (double)M / 60) * 3600);

            coor = D.ToString() + @"° " + M.ToString() + @"' " + S.ToString() + @""" с.ш. ,  ";
            
            
            D = (int)(p.X);
            M = (int)((p.X - D) * 60);
            S = (int)Math.Floor((p.X - D - (double)M / 60) * 3600);

            coor = coor + D.ToString() + @"° " + M.ToString() + @"' " + S.ToString() + @""" в.д.";
            textBoxCoor.Text = coor;

            textBoxMO.Text = fp.MO;
            textBoxCL.Text = fp.CL;
            textBoxUL.Text = fp.UL;
            textBoxKv.Text = fp.Kv.ToString(); ;

            if (fp.OOPT == "да")
            {
                textBoxOOPT.Text = "ДА";
                textBoxOOPT.ForeColor = Color.Red;
            }
            else
            {
                textBoxOOPT.Text = "нет";
            }


            
            this.sislist = sislist;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("№ п/п", "№ п/п");
            dataGridView1.Columns[0].Width = 30;

            dataGridView1.Columns.Add("Система", "Система");
            dataGridView1.Columns[1].Width = 120;

            dataGridView1.Columns.Add("Район", "Район");
            dataGridView1.Columns[2].Width = 120;


            dataGridView1.Columns.Add("Дислокация", "Дислокация");
            dataGridView1.Columns[3].Width = 120;

            dataGridView1.Columns.Add("Организация", "Организация");
            dataGridView1.Columns[4].Width = 300;

            dataGridView1.Columns.Add("Конт. инф-я", "Конт. инф-я");
            dataGridView1.Columns[5].Width = 250;
            
            dataGridView1.Columns.Add("ЛС , чел.", "ЛС, чел.");
            dataGridView1.Columns[6].Width = 60;

            dataGridView1.Columns.Add("Техника, ед.", "Техника, ед.");
            dataGridView1.Columns[7].Width = 60;
            
            dataGridView1.Columns.Add("Примечания", "Примечания");
            dataGridView1.Columns[8].Width = 220;

            dataGridView1.Columns.Add("Доп. прим.", "Доп. прим.");
            dataGridView1.Columns[9].Width = 200;





            Font gridFont1 = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            //dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            //dataGridView1.Columns[0].DefaultCellStyle.Font = gridFont1;
            //dataGridView1.Columns[0].Width = 200;
            //dataGridView1.Columns.Add("Значение", "Значение");
            
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridView1.ClipboardCopyMode =
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void SiSForm_Load(object sender, EventArgs e)
        {

            int sumLS = 0, sumT = 0, k = 0;
            for (int i = 0; i < sislist.Count; i++)
            {

                if (sislist[i].Org == "")
                    continue;

                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = k+1;
                dataGridView1.Rows[k].Cells[1].Value = sislist[i].RSCS;
                dataGridView1.Rows[k].Cells[2].Value = sislist[i].MO;
                dataGridView1.Rows[k].Cells[3].Value = sislist[i].Dislocation;
                dataGridView1.Rows[k].Cells[4].Value = sislist[i].Org;
                dataGridView1.Rows[k].Cells[5].Value = sislist[i].Contact;
                dataGridView1.Rows[k].Cells[6].Value = sislist[i].LS;
                sumLS += sislist[i].LS;
                dataGridView1.Rows[k].Cells[7].Value = sislist[i].Technics;
                sumT += sislist[i].Technics;
                dataGridView1.Rows[k].Cells[8].Value = sislist[i].Prim1;
                dataGridView1.Rows[k].Cells[9].Value = sislist[i].Prim2;
                k++;
            }

            
            dataGridView1.Rows.Add();

            Font gridFont2 = new Font(dataGridView1.Font.FontFamily, 12, FontStyle.Bold);
            dataGridView1.Rows[k].DefaultCellStyle.Font = gridFont2;
            dataGridView1.Rows[k].Cells[5].Value = "Всего";
            dataGridView1.Rows[k].Cells[6].Value = sumLS;
            dataGridView1.Rows[k].Cells[7].Value = sumT;
            

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1
            .GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(
                        this.dataGridView1.GetClipboardContent());

                    // Replace the text box contents with the clipboard text.
                    //this.TextBox1.Text = Clipboard.GetText();
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    //this.TextBox1.Text =
                      //  "The Clipboard could not be accessed. Please try again.";
                }
            }

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.GetClipboardContent() != null)
            {
                Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
                Clipboard.GetData(DataFormats.Text);
                IDataObject dt = Clipboard.GetDataObject();
                if (dt.GetDataPresent(typeof(string)))
                {
                    string tb = (string)(dt.GetData(typeof(string)));
                    //ASCIIEncoding ee = new ASCIIEncoding();
                    Encoding myEncoding = Encoding.GetEncoding(1251);
                    byte[] abyDataStr = new byte[tb.Length];
                    abyDataStr = myEncoding.GetBytes(tb);
                    Clipboard.SetDataObject(myEncoding.GetString(abyDataStr));
                }
            }
        }

        private void SiSForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            
        }

        

        

        

       
    }
}