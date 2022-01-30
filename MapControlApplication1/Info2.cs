using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InfoCUKS
{
    public partial class Info2 : Form
    {

        //private TreeForm main;
        //private DataRow row;
        private DynTagNode tag;

        public Info2(DynTagNode input_tag)
        {
            InitializeComponent();

            tag = input_tag;
            
            
            //row = input_row;

            

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Характеристика", "Характеристика");
            Font gridFont1 = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView1.Columns[0].DefaultCellStyle.Font = gridFont1;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns.Add("Значение", "Значение");
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridView1.ClipboardCopyMode =
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void Info2_Load(object sender, EventArgs e)
        {
            //main = this.Owner as TreeForm;
            
            //DynTagNode tag = main.selected_node_tag;

            string table_name = tag.table;
            DataRow row = tag.dbrow;
                
            if (table_name == null) 
                return;

            List<int_val> n_column_name = Util.get_info_fields(table_name);

            if (n_column_name.Count == 0)
            {
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = row.Table.Columns[i].ColumnName;
                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = row.Table.Rows[j - 1][i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < n_column_name.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = n_column_name[i].s_val;
                    int field_index = n_column_name[i].i_key;
                    dataGridView1.Rows[i].Cells[1].Value = row[field_index]; 
                }
            }

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
    }
}