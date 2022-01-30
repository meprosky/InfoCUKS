using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace InfoCUKS
{
    public partial class TreeForm : Form
    {
        public static bool IsRun = false;
        private MainForm main;

        private string tree_table_name;
        ToolStripMenuItem sub;

        public DynTagNode selected_node_tag;
        public DataRow info_row;

        private Dictionary<string, string> sub_item = new Dictionary<string, string>();


        private DataTable dtService = Util.get_dtService();
        private DataTable dtSchema = Util.get_dtSchema();
        //private DataTable dtSchema = Util.get_dtSchema();
        
        
        private Dictionary<int, string> for_comboBox_list_items = new Dictionary<int, string>();

        public static bool Runned()
        {
            return IsRun;
        }


        public TreeForm(string table_name, bool istable)
        {
            InitializeComponent();
            tree_table_name = table_name;
        }


        private void TreeForm_Load(object sender, EventArgs e)
        {
            IsRun = true;
            
            main = this.Owner as MainForm;
            if (main == null) { this.Close(); return;}

            treeView1.Nodes.Clear();

            DataTable dtTrec = Util.get_dtTrec_fr_serv(tree_table_name);

            string schemes = dtTrec.Rows[0]["schemas"] as string;
            string[] arr = Util.regex_strArr(schemes, @"[-]?\d+");
            
            string default_schema = Util.regex_firstStr(schemes, @"[-]?\d+");
            int default_schema_pk = Convert.ToInt32(default_schema);

            for (int i = 0; i < arr.Length; i++)
            {
                int schTable_pk = Convert.ToInt32(arr[i]);
                DataRow row;
                string s;
                row = dtSchema.Rows.Find(schTable_pk);
                s = row["sch_name"] as string;
                for_comboBox_list_items.Add(schTable_pk, s);
            }
            //cBox_schema
            
                
            //toolStripComboBox1.ComboBox.DataSource = new BindingSource(for_comboBox_list_items, null);
            //toolStripComboBox1.ComboBox.DisplayMember = "Value";
            //toolStripComboBox1.ComboBox.ValueMember = "Key";
            //toolStripComboBox1.SelectedIndex = 0;

            cBox_schema.DataSource = new BindingSource(for_comboBox_list_items, null);
            cBox_schema.DisplayMember = "Value";
            cBox_schema.ValueMember = "Key";
            cBox_schema.SelectedIndex = 0;
            
      
            DataRow rowSchemT = dtSchema.Rows.Find(default_schema_pk);
            
            
            string root_table = rowSchemT["root_table"] as string;
            DataTable dtRoot = Util.get_dt(root_table, "", -1);
            
           
            DataTable dtRecRoot = Util.get_dtTrec_fr_serv(root_table);
            DataRow rowRoot = dtRecRoot.Rows[0];


            string sort_f = rowRoot["sort_f"] as string;
            string view_f = rowRoot["view_f"] as string;
            string id_f = rowRoot["id_field"] as string;
            string idarc_f = rowRoot["idarc_field"] as string;
            string layer_f = rowRoot["Layer"] as string;

            get_root_treenodes(treeView1, root_table, view_f, sort_f, layer_f, id_f, idarc_f, false);

            TreeNode[] tnc = treeView1.Nodes.Find("Республика Карелия", false);
            if (tnc != null)
                tnc[0].Expand();

        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

            if ((e.Node.Tag as DynTagNode).pk == -1) return;
            if (cBox_schema.Enabled == false) return;

            int selectedCombo = (int)cBox_schema.SelectedValue; //выбранная схема

            //родительский узел
            TreeNode parentTreeNode = e.Node;
            int parent_node_pk = (parentTreeNode.Tag as DynTagNode).pk;
            string parent_tname = (parentTreeNode.Tag as DynTagNode).table;

            //проверяем схему
            DataRow rowSchemT = dtSchema.Rows.Find(selectedCombo);
            string strSchemT = rowSchemT["sch_rel"] as string;
            
            string regex = @"(\b\w+\b.)?" + parent_tname + @".\b\w+\b";
            string s1 = Util.regex_firstStr(strSchemT, regex);
            //if (s1 == "") return;

            string regex_next = @"(?<=" + s1 + @"[ ]*?[-][ ]*?)" + @"\w+[.]\w+[.]\w+";
            string s2 = Util.regex_firstStr(strSchemT, regex_next);

            
            string child_table;

            if (s2 == "")
            {
                child_table = tree_table_name;
            }
            else
            {
                string[] arr2 = Util.regex_strArr(s2, @"\b\w+\b");
                child_table = arr2[1];
            }


            string child_multi_table =
                get_multitab(parent_tname, parent_node_pk);  //, ref isLast);

            if (child_multi_table != null)
            {
                child_table = child_multi_table;
            }

            //запись в серв. таблице о таблице для которой строится дерево
            DataTable dtRecServT = Util.get_dtTrec_fr_serv(child_table);
            DataRow rowServT = dtRecServT.Rows[0];
            string s_islast = rowServT["is_last"] as string;

            bool isLast = false;
            if (s_islast == "y" && s2 == "")
                isLast = true;
            else
                isLast = false;
            
            //запись из серв.т. о предках к которым м.б. присоединена данная таблица
            string parents = rowServT["parents"] as string;
            string parents_pk = Util.regex_firstStr(parents, @"\b\w+\b *?- *?" + parent_tname + @".\b\w+\b");
            string[] arr = Util.regex_strArr(parents_pk, @"\b\w+\b");
            
            
            string ch_fk = arr[0];
            string parent_pk = arr[2];
            string ch_view_f = rowServT["view_f"] as string;
            string ch_sort_f = rowServT["sort_f"] as string;
            string ch_layer_f = rowServT["Layer"] as string;
            string ch_id_f = rowServT["id_field"] as string;
            string ch_idarc_f = rowServT["idarc_field"] as string;

            parentTreeNode.Nodes.Clear();

            get_treenodes(parentTreeNode, parent_node_pk, child_table, ch_fk, ch_view_f, ch_sort_f, ch_layer_f, ch_id_f, ch_idarc_f, isLast);

        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            построитьСвязиToolStripMenuItem.DropDownItems.Clear();
            
            // Point where the mouse is clicked.
            System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);

            // Get the node that the user has clicked.
            TreeNode node = treeView1.GetNodeAt(p);

            treeView1.SelectedNode = node;

            if (node == null) return;

            DynTagNode inf = (DynTagNode)node.Tag;

            if (null != node.Tag)
            {
                //m_pointToZoom = main.transformDegPulkovoToCK42_Z6(inf.x, inf.y);
            }


            if (e.Button == MouseButtons.Right)
            {
                if (null != node.Tag)
                {

                    
                    contextMenuStrip1.Show(treeView1, p);
                }

            }



        }

        private void показатьНаКартеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TreeNode selected = treeView1.SelectedNode;
            DynTagNode taginfo = selected.Tag as DynTagNode;

            bool contain_xy = taginfo.dbrow.Table.Columns.Contains("x") & taginfo.dbrow.Table.Columns.Contains("y");
            bool contain_env = taginfo.dbrow.Table.Columns.Contains("x_min") & taginfo.dbrow.Table.Columns.Contains("y_min") &
                taginfo.dbrow.Table.Columns.Contains("x_max") & taginfo.dbrow.Table.Columns.Contains("y_max");
                
                
            
            if (contain_xy)
            {
                object x = (double)taginfo.dbrow["x"];
                object y = (double)taginfo.dbrow["y"];

                if (x != null && y != null)
                {
                    IPoint m_pointToZoom = new PointClass();
                    m_pointToZoom = Util.transformDegPulkovoToCK42_Z6( (double)x, (double)y);
                    main.m_mapControl.CenterAt(m_pointToZoom);
                    
                    IDisplayTransformation pDT = main.m_mapControl.ActiveView.ScreenDisplay.DisplayTransformation;
                    pDT.ScaleRatio = 40000;
                    main.m_mapControl.ActiveView.Refresh();
                }
            }

            if (contain_env)
            {
                object x_min = taginfo.dbrow["x_min"];
                object y_min = taginfo.dbrow["y_min"];
                object x_max = taginfo.dbrow["x_max"];
                object y_max = taginfo.dbrow["y_max"];

                if (x_min != null && y_min != null && x_max != null && y_max != null )
                {
                    IEnvelope envelope = new EnvelopeClass();
                    envelope.PutCoords((double)x_min, (double)y_min, (double)x_max, (double)y_max);

                    IEnvelope projenv = Util.transformDegPulkovoToCK42_Z6(envelope);
                   
                    main.m_mapControl.Extent = projenv;
                  
                    main.m_mapControl.ActiveView.Refresh();
                }
            }

        }

        private void testForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsRun = false;
            this.Dispose();
        }

        private void cBox_schema_DropDownClosed(object sender, EventArgs e)
        {
            int pk = (int)cBox_schema.SelectedValue;
            
            treeView1.Nodes.Clear();
            
            DataTable record_table = Util.get_dtTrec_fr_serv(tree_table_name);
            
            string tree_view_schema = record_table.Rows[0]["schemas"] as string;
            string[] arr_schemas = Util.regex_strArr(tree_view_schema, @"[-]?\d+");

            string first_s = Util.regex_firstStr(tree_view_schema, @"[-]?\d+");
            int root_pk = Convert.ToInt32(first_s);

            DataRow row_schem = dtSchema.Rows.Find(pk);
            string root_table = row_schem["root_table"] as string;
            DataTable dt_root = Util.get_dt(root_table, "", -1);

            DataTable dt_fr_st = Util.get_dtTrec_fr_serv(root_table);
            string sort_f = dt_fr_st.Rows[0]["sort_f"] as string;
            string view_f = dt_fr_st.Rows[0]["view_f"] as string;
            string id_f = dt_fr_st.Rows[0]["id_field"] as string;
            string idarc_f = dt_fr_st.Rows[0]["idarc_field"] as string;
            string layer_f = dt_fr_st.Rows[0]["Layer"] as string;

            get_root_treenodes(treeView1, root_table, view_f, sort_f, layer_f, id_f, idarc_f, false);

            TreeNode[] tnc = treeView1.Nodes.Find("Республика Карелия", false);
            if (tnc.Length != 0)
                tnc[0].Expand();
        }

        private void построитьСвязиToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            sub_item.Clear();
            
            TreeNode selected_node = treeView1.SelectedNode;

            if (selected_node.Text == "Республика Карелия")
                return;
            
            DynTagNode taginfo = selected_node.Tag as DynTagNode;


            int pk = taginfo.pk;
            string table = taginfo.table;


            DataTable servicet = Util.get_dtService();

            string expression = "con_field Like " + "'*" + table + "*'";

            DataRow[] fndrow = servicet.Select(expression, "table_alias ASC");
            


            if (fndrow.Length == 0) return;

            string regexstring = @"((?<=[[(])\w+)|(\w+(?=:" + table + @"))|((?<=" + table + @".)\w+)";

            string child_table;

            построитьСвязиToolStripMenuItem.DropDownItems.Clear();
            
            

            foreach (DataRow row in fndrow)
            {
                string s = (string)row["con_field"];
                string alias = (string)row["table_alias"];
                string[] arrs = Util.regex_strArr(s, regexstring);

                child_table = (string)row["Table"];

                sub = new System.Windows.Forms.ToolStripMenuItem();
                sub.Click += new System.EventHandler(this.sub_Click);
                sub.Text = alias;
                sub.Tag = child_table;
                построитьСвязиToolStripMenuItem.DropDownItems.Add(sub);


                //(contextMenuStrip1.Items["Построить связи"] as ToolStripMenuItem).DropDownItems.Add(parent_table);
                //contextMenuStrip1.Items.


            }

        
        
        
        
        }

        private void sub_Click(object sender, EventArgs e)
        {

            cBox_schema.Enabled = false;

            TreeNode selected_node = treeView1.SelectedNode;
            DynTagNode taginfo = selected_node.Tag as DynTagNode;

            if (selected_node.Text == "Республика Карелия")
                return;

            string parent_table = taginfo.table;
            string parent_layer = taginfo.layer;
            int parent_pk = taginfo.pk;
            
            string child_table = (sender as ToolStripMenuItem).Tag as string;

            DataTable service_table = Util.get_dtService();

            string expression = "con_field Like " + "'*" + parent_table + "*'" + " And Table = " + "'" + child_table + "'";

            DataRow[] fndrow = service_table.Select(expression);

            if (fndrow.Length == 0) return;

            DataRow row = fndrow[0];

            string regexstring = @"((?<=[[(])\w+)|(\w+(?=:" + parent_table + @"))|((?<=" + parent_table + @".)\w+)";
            string s = (string)row["con_field"];
            string[] arrs = Util.regex_strArr(s, regexstring);
            string tn_fiels = arrs[0];
            string sort_field = arrs[1];
            string childKey = arrs[2];
            string parentKey = arrs[3];


            selected_node.Nodes.Clear();

            //get_treenodes(selected_node, parent_pk, child_table, childKey, tn_fiels, sort_field, "", "idarc", true);


            selected_node.Expand();
            treeView1.Update();

            List<string> a = new List<string>();

            a.Add((sender as ToolStripMenuItem).Text);

            cBox_schema.DataSource = new BindingSource(a, null);
        
        }

        private void иформацияОбОбъектеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            TreeNode selected_node = treeView1.SelectedNode;
            DynTagNode taginfo = selected_node.Tag as DynTagNode;
            selected_node_tag = taginfo;
            info_row = taginfo.dbrow;
            
            
            Info2 finfo = new Info2(taginfo);
            

            

            //if (selected_node.Text == "Республика Карелия") 
            //    return;
            
            
            
            


            finfo.Owner = this;
            
            if (info_row != null)
                finfo.Show();
            else
                MessageBox.Show("Информация об объекте отсутсвует");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = cboxSearch.Text;

            TreeNodeCollection tnc = treeView1.Nodes;

            foreach (TreeNode tn in tnc)
            {
                if(recn(tn, text))
                    return;
            }

            

        }

        private bool recn(TreeNode parent, string text)
        {
            
            
            if (parent.Text.ToUpper().StartsWith(text.ToUpper()))
            {
                if(treeView1.SelectedNode != null)
                    treeView1.SelectedNode.BackColor = Color.Empty;
                
                treeView1.SelectedNode = parent;
                treeView1.SelectedNode.BackColor = Color.LightSkyBlue;

                //treeView1.Select();
                //textBox1.Focus();
                return true;
            }

            foreach (TreeNode tn in parent.Nodes)
            {
                if(recn(tn, text))
                    return true;
            }

            return false;
        
        
        }

        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selected = treeView1.SelectedNode;
            DynTagNode taginfo = selected.Tag as DynTagNode;

            bool contain_dir = taginfo.dbrow.Table.Columns.Contains("dir");

            if (contain_dir)
            {
                object dir_str = taginfo.dbrow["dir"];
                if (dir_str != null)
                {
                    try
                    {
                        System.Diagnostics.Process.Start((string)dir_str);
                    }
                    catch
                    {
                        MessageBox.Show("Связанные документы открыть не удалось!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Связанные документы отсутствуют!");
            }





        }

       

      
      







    }






    public class DynTagNode
    {

        public string table;
        public string layer;
        public int pk;
        public int idarc;
        public DataRow dbrow;

   
        public DynTagNode(string table, int pk, string layer, int idarc)
        {
            this.table = table;
            this.pk = pk;
            this.layer = layer;
            this.idarc = idarc;
        }

        public DynTagNode(string table, int pk, string layer, int idarc, DataRow row)
        {
            this.table = table;
            this.pk = pk;
            this.layer = layer;
            this.idarc = idarc;
            this.dbrow = row;
        }




    }




}