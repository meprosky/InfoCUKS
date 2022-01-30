using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace InfoCUKS
{
    public partial class TreeForm
    {

        public TreeNode get_treenodes(TreeNode parent, int parent_pk, 
            string from_t, string fk_f,  string view_f, string sort_f, string layer, string id_f, string idarc_f, bool islast)
        {
            
            DataTable dt = Util.get_dt(from_t, fk_f, parent_pk);
            string table_name = dt.TableName;
            
            DataView dv = new DataView(dt);
            dv.Sort = sort_f + " ASC";

            foreach (DataRowView drv in dv)
            {
                DataRow row = drv.Row;
                TreeNode newnode = new TreeNode(row[view_f].ToString());
                newnode.Name = row[view_f].ToString();
                DynTagNode inf = new DynTagNode(table_name, (int)row[id_f], layer, (int)row[idarc_f], row);
                newnode.Tag = inf;
                
                if(!islast)
                    newnode.Nodes.Add("");
                
                parent.Nodes.Add(newnode);
            }

            return parent;
        }

        public TreeView get_root_treenodes(TreeView tv_parent, 
            string from_t, string view_f, string sort_f, string layer, string id_f, string idarc_f, bool islast)
        {

            //if (tv_parent.LastNode.Name == "")
            //    tv_parent.LastNode.Remove();

            DataTable dt = Util.get_dt(from_t, "", -1);
            string table_name = dt.TableName;

            DataView dv = new DataView(dt);
            dv.Sort = sort_f + " ASC";

            foreach (DataRowView drv in dv)
            {
                DataRow row = drv.Row;
                TreeNode newnode = new TreeNode(row[view_f].ToString());
                newnode.Name = row[view_f].ToString();
                DynTagNode inf = new DynTagNode(table_name, (int)row[id_f], layer, (int)row[idarc_f], row);
                newnode.Tag = inf;

                if (!islast)
                    newnode.Nodes.Add("");

                tv_parent.Nodes.Add(newnode);
            }

            return tv_parent;
        }

        public string get_multitab(string parent_tname, int parent_pk)  //, ref bool islast)
        {
           
            DataTable dtParent = Util.get_dtTrec_fr_serv(parent_tname);
            DataRow row_multi = dtParent.Rows[0];
            string s_islast = row_multi["is_last"] as string;
            
 

            string ismulti_s = row_multi["multi"] as string;

            if (ismulti_s == null || ismulti_s != "y")
                return null;
            
            
            DataTable dtServ = Util.get_dtService();
            string expression = "multi_tables Like " + "'*" + parent_tname + "(" + parent_pk.ToString() + ")*'";
            DataRow[] rowsServ = dtServ.Select(expression);
            DataRow row = rowsServ[0];

            string child_table = row["Table"] as string;
            

            return child_table;
        }
    }
}
