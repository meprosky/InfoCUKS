using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace InfoCUKS
{
    class NewTNcreator
    {
        private TreeView l_TreeView;
        private TreeNode l_TreeNode;

        // оструктор
        public NewTNcreator(TreeView tview, 
            DataTable tree_dt, /*DataTable info_dt,*/
            int id_field_index2, int idarc_field_index2,
            int[] dbf, string sortOrder, int lastChildNodeField) 
        {
            l_TreeView = get_nodes(tview, 
                tree_dt, /*info_dt, */
                id_field_index2, idarc_field_index2,
                dbf, sortOrder, lastChildNodeField);
        }
        
        // оструктор 2
        public NewTNcreator(TreeNode tnode, 
            DataTable tree_dt, /*DataTable info_dt,*/
            int id_field_index2, int idarc_field_index2,
            int[] dbf, string sortOrder, int lastChildNodeField)
        {
            l_TreeNode = get_nodes(tnode, 
                tree_dt, /*info_dt,*/
                id_field_index2, idarc_field_index2,
                dbf, sortOrder, lastChildNodeField);
        }

        
        
        private TreeView get_nodes(TreeView tview, 
            DataTable tree_dt, /*DataTable info_dt,*/
            int id_field_index2, int idarc_field_index2, 
            int[] dbf, string sortOrder, int lastChildNodeField)
        {
            
            DataView dv = new DataView(tree_dt);
            dv.Sort = sortOrder;

            TreeNode[] p = new TreeNode[dbf.Length + 1];
            DataRow row0 = dv[0].Row;

            int k = 0;
            foreach (DataRowView rowView in dv)
            {
                DataRow row = rowView.Row;
                int j = 0;

                foreach (int i in dbf) //пол€ по которым строим дерево
                {
                    if (!row[i].Equals(row0[i]) || (k == 0) || (i == lastChildNodeField))
                    {

                        if (j == 0) { p[j + 1] = CreateNode(tview, row[i].ToString()); }
                        else { p[j + 1] = CreateNode(p[j], row[i].ToString()); }

                        if (j == (dbf.Length - 1))
                        {
                            NewTagNode inf = new NewTagNode(row[id_field_index2].ToString(), row[idarc_field_index2].ToString());


                                                       
                            p[j + 1].Tag = inf;
                        }
                    }
                    j++;
                }
                row0 = row;
                k++;
            }
            return tview;
        }

        private TreeNode get_nodes(TreeNode tnode,
            DataTable tree_dt, /*DataTable info_dt,*/
            int id_field_index2, int idarc_field_index2,
            int[] dbf, string sortOrder, int lastChildNodeField)
        {
 
            
            DataView dv = new DataView(tree_dt);
            dv.Sort = sortOrder;

            TreeNode[] p = new TreeNode[dbf.Length + 1];
            DataRow row0 = dv[0].Row;

            p[0] = tnode;

            int k = 0;
            foreach (DataRowView rowView in dv)
            {
                DataRow row = rowView.Row;
                int j = 0;

                foreach (int i in dbf) //пол€ по которым строим дерево
                {
                    if (!row[i].Equals(row0[i]) || (k == 0) || (i == lastChildNodeField))
                    {
                        p[j + 1] = CreateNode(p[j], row[i].ToString());
                        if (j == (dbf.Length - 1))
                        {
                            //string s1 = row[id_field_index2].ToString();
                            //string s2 = row[idarc_field_index2].ToString();

                            NewTagNode inf = new NewTagNode(row[id_field_index2].ToString(), row[idarc_field_index2].ToString());

                            p[j + 1].Tag = inf;
                        }
                    }
                    j++;
                }
                row0 = row;
                k++;
            }
            return tnode;
        }

        private TreeNode CreateNode(TreeNode parent, string s)
        {
            TreeNode newnode = new TreeNode(s);
            parent.Nodes.Add(newnode);
            return newnode;
        }

        private TreeNode CreateNode(TreeView parent, string s)
        {
            TreeNode newnode = new TreeNode(s);
            parent.Nodes.Add(newnode);
            return newnode;
        }


    }


    public class NewTagNode
    {
        public string id;
        public string idarc;
        public int x = 0;
        public int y = 0;
      
        public NewTagNode(string id, string idarc)
        {
            this.id = id;
            this.idarc = idarc;
        }
        
    }




}//end ns
