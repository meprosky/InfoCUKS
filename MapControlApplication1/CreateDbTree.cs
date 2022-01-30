using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InfoCUKS
{
    class TableTreeClass
    {

        //private DataTable dt = null;
        private DTTreeParam dttparams = null;

        public DTTreeParam get_dttparam()
        {
            return dttparams;
        }

        public DataTable get_dt()
        {
            return dttparams.tree_dt;
        }

        public TableTreeClass(string layername)
        {
            dttparams = get_DTTParam(layername);
        }

        DTTreeParam get_DTTParam(string layername)
        {
            
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;


            DataTable serviceTable = new DataTable("servicedb");

            
            dbCommand.CommandText = @"SELECT * FROM " + ProgParam.serviceTableName + " WHERE Layer = " + "'" + layername + "'";

            
            try { connection.Open(); }
            catch { MessageBox.Show("Ошибка подключения к БД"); return null;}

            
            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null;}

            serviceTable.Load(dbDataReader);

            
            
            
            //string treeTablesString = serviceTable.Rows[0]["treeTable"] as string;
            string layer_name = serviceTable.Rows[0]["Layer"] as string;
            string table_name = serviceTable.Rows[0]["Table"] as string;
            string rel_tables = serviceTable.Rows[0]["rel_tables"] as string;
            string query_field = serviceTable.Rows[0]["query_fields"] as string;
            string id_field = serviceTable.Rows[0]["id_field"] as string;
            string idarc_field = serviceTable.Rows[0]["idarc_field"] as string;
            string tree_root = serviceTable.Rows[0]["tree_root"] as string;
            int tree_last_child_index = Convert.ToInt32(serviceTable.Rows[0]["last_child"]);
            string tree_fields = serviceTable.Rows[0]["tree_fields"] as string;
            string tree_sort_fields = serviceTable.Rows[0]["tree_sort"] as string;

            string[] rel_tables_params =    Util.regex_strArr(rel_tables,         ProgParam.regexRelTables);
            string[] query_tree_fields =    Util.regex_strArr(query_field,        ProgParam.regexQueryFields);
            
            string[] treeview_fields =      Util.regex_strArr(tree_fields,        ProgParam.regexTreeViewFields);
            List<StrDig> tvflist = new List<StrDig>();
            foreach(string s in treeview_fields) tvflist.Add(new StrDig(s));
            
            
            string[] treeview_sort_fields = Util.regex_strArr(tree_sort_fields,   ProgParam.regexTreeViewSortFields);
            List<StrDig> tvsortlist = new List<StrDig>();
            foreach (string s in treeview_sort_fields) tvsortlist.Add(new StrDig(s));
            

            List<TablesForTree> listTreeTablesParam = new List<TablesForTree>();

            
                
            for(int i = 0; i < rel_tables_params.Length; i+=3)
            {
                listTreeTablesParam.Add(new TablesForTree(table_name, 
                    rel_tables_params[i], rel_tables_params[i+1], rel_tables_params[i+2]));
            }
            




            
            

            //SELECT АД.Автодорога, Районы.Район, ФАД_Кола_км.КМ 
            //FROM ((ФАД_Кола_км INNER JOIN АД ON АД.idad = ФАД_Кола_км.idad) INNER JOIN Районы ON Районы.idr = ФАД_Кола_км.idr) 
             
            //string[] sortord = new string[] {tree_sort_fields, "", ""};

            //string infoFields = serviceTable.Rows[0]["infoFields"] as string; ;

            
            //DataTable infoDataTable = new DataTable(table_name);
            //dbCommand.CommandText = "SELECT * FROM " + table_name;
            //try { dbDataReader = dbCommand.ExecuteReader(); }
            //catch { MessageBox.Show("Ошибка загрузки = " + table_name + "\n" + "dbDataReader = FAIL"); return null; }
            //infoDataTable.Load(dbDataReader);

            DataTable treeDataTable = new DataTable("tree_" + table_name);
            string querystring = CreateOleDbQuery(listTreeTablesParam, query_tree_fields, table_name);
            dbCommand.CommandText = querystring;
            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null; }
            treeDataTable.Load(dbDataReader);

            
            //testForm testf = new testForm();
            //testf.dataGridView1.DataSource = destTable;
            //testf.Show();

            DTTreeParam dttparams = new DTTreeParam(treeDataTable, /*infoDataTable,*/ id_field, idarc_field, 
                tree_root, tree_last_child_index, 
                layer_name, table_name,
                querystring, rel_tables_params, query_tree_fields, 
                tvflist, tvsortlist);

            dbDataReader.Close();
            connection.Close();

            return dttparams;
        }

        private string CreateOleDbQuery(List<TablesForTree> list_rel_tables, string[] query_tree_fields, string table_name)
        {
            string sel = "SELECT ";

            for (int i = 0; i < query_tree_fields.Length; i++)
                sel += query_tree_fields[i] + ((i != query_tree_fields.Length - 1) ? ", " : " FROM ");

            //sel += listTbl4Tree[0].tableName + " ";




            if (list_rel_tables.Count == 0)
            {
                sel += table_name;
            }
            else if(list_rel_tables.Count > 0)
            {

                foreach (TablesForTree t in list_rel_tables) { sel += "("; }
                sel += list_rel_tables[0].table_name + " ";
                foreach (TablesForTree t in list_rel_tables)
                {
                    sel += "INNER JOIN " + t.table_to_join + " ON " + t.table_to_join + "." + t.FK + " = " + t.table_name + "." + t.PK + ") ";
                }
            }
            
            
            
            
            //пример
            //SELECT НасПункты.Назв_алф,  Районы.Район, Поселения.Поселение
            //FROM ((НасПункты INNER JOIN  Районы ON Районы.idr = НасПункты.idr) INNER JOIN  Поселения ON Поселения.idp = НасПункты.idp);


            return sel;
            

            //SELECT АД.Автодорога, Районы.Район, ФАД_Кола_км.КМ 
            //FROM ((ФАД_Кола_км INNER JOIN idad ON idad.idad = ФАД_Кола_км.АД) INNER JOIN idr ON idr.idr = ФАД_Кола_км.Районы) 
        
            //throw new Exception("The method or operation is not implemented.");
        }

        public class TablesForTree
        {
            public TablesForTree(string table_name, string PK, string table_to_join, string FK)
            {
                this.table_name = table_name;
                this.PK = PK;
                this.table_to_join = table_to_join;
                this.FK = FK;
            }
            
            public string table_name;
            public string PK;
            public string table_to_join;
            public string FK;
              
        }

        






    
    }//end class BuildTree

    public class StrDig
    {
        public string str;
        public  List<int> d = new List<int>();
        
        public StrDig(string inps)
        {
            str = (Util.regex_strArr(inps, ProgParam.regexStrDig1) as string[])[0];
            string[] regsarr = Util.regex_strArr(inps, ProgParam.regexStrDig2);
            foreach (string s in regsarr) { d.Add(Convert.ToInt32(s));}
        }

        public int[] get_larray()
        {
            return d.GetRange(0, d.Count).ToArray();
        }


    }


    public class DTTreeParam
    {
        public DataTable tree_dt;
        //public DataTable info_dt;
        
        public string id_field;
        //public int id_field_index;
        
        public string id_field2;
        public int id_field_index2;

        public string idarc_field;
        //public int idarc_field_index;

        public string idarc_field2;
        public int idarc_field_index2;
        
        
        
        
        public string treeRoot;
        public string tree_last_child;
        public int tree_last_child_index;
        public string layer_name;
        public string table_name;
        public string querystring;
        public string[] relTables;
        public string[] fieldsResTable;
        public List<string> sortorders = new List<string>();
        public List<string> tag_fields = new List<string>();

        public List<StrDig> tvflist;
        public List<StrDig> tvsortlist;

        public DTTreeParam()
        {
        }

        public DTTreeParam(DataTable tree_dt, /*DataTable info_dt,*/ string id_field, string idarc_field,
            string treeRoot, int last_child_index, 
            string layerName, string tableName, 
            string querystring, string[] relTables, string[] flds, 
            List<StrDig> tvflist, List<StrDig> tvsortlist)
        {
            
            this.tree_dt = tree_dt;
            //this.info_dt = info_dt;

            this.layer_name = layerName;
            this.table_name = tableName;
            
            this.id_field = id_field;
            //this.id_field_index = info_dt.Columns[id_field].Ordinal;
            
            
            if (tree_dt.Columns.Contains(this.table_name + "." + this.id_field))
            {
                id_field2 = this.table_name + "." + this.id_field;
                this.id_field_index2 = tree_dt.Columns[id_field2].Ordinal;
            }
            else
            {
                id_field2 = this.id_field;
                this.id_field_index2 = tree_dt.Columns[id_field2].Ordinal;
            }


            this.idarc_field = idarc_field;
            //this.idarc_field_index = info_dt.Columns[idarc_field].Ordinal;
            
            if (tree_dt.Columns.Contains(this.table_name + "." + this.idarc_field))
            {
                idarc_field2 = this.table_name + "." + this.idarc_field;
                this.idarc_field_index2 = tree_dt.Columns[idarc_field2].Ordinal;
            }
            else
            {
                idarc_field2 = this.idarc_field;
                this.idarc_field_index2 = tree_dt.Columns[idarc_field2].Ordinal;
            }

            this.treeRoot = treeRoot;
            this.tree_last_child_index = last_child_index;

            this.querystring = querystring;
            this.relTables = relTables;
            this.fieldsResTable = flds;
            
            this.tvflist = tvflist;
            
            this.tvsortlist = tvsortlist;
            
            foreach (StrDig strd in this.tvsortlist)
            {
                string s = "";
                int i = 0;
                foreach (int fld in strd.d)
                {
                    string cname = tree_dt.Columns[fld].ColumnName;
                    s +=  (i != strd.d.Count - 1)? cname + ", " : cname + " ASC";
                    i++;
                }

                sortorders.Add(s);
            
            }


            this.tree_last_child = tree_dt.Columns[tree_last_child_index].ColumnName;



        }

        

            
            
            
            
            
            
            
            
            
       

    }

}//end ns

