using System;
using stdole;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Controls;




namespace InfoCUKS
{
    static class Util
    {
        //для снятия выделения с инстурмента
        public static void deselect_tool(IMapControl3 m_mapControl, AxToolbarControl axToolbarControl1)
        {
            
            UID pUID = new UIDClass();
            pUID.Value = "esriControlCommands.ControlsSelectTool";
            ICommand pCommand = axToolbarControl1.CommandPool.FindByUID(pUID);
            axToolbarControl1.CurrentTool = (ITool)pCommand;
            m_mapControl.CurrentTool = null;
        }

        public static IPoint transformDegPulkovoToCK42_Z6(double x, double y)
        {
            IGeographicCoordinateSystem m_GeographicCoordinateSystem;
            IProjectedCoordinateSystem m_ProjectedCoordinateSystem;
            
            
            ISpatialReferenceFactory2 spatRefFact = new SpatialReferenceEnvironmentClass();
            m_GeographicCoordinateSystem = spatRefFact.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            m_ProjectedCoordinateSystem = spatRefFact.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);

            IPoint projPoint = new PointClass();
            projPoint.PutCoords(x, y);
            projPoint.SpatialReference = m_GeographicCoordinateSystem;
            projPoint.Project(m_ProjectedCoordinateSystem);

            return projPoint;
        }

        public static IPoint transformDegPulkovoToCK42_Z6(IPoint p)
        {
            IGeographicCoordinateSystem m_GeographicCoordinateSystem;
            IProjectedCoordinateSystem m_ProjectedCoordinateSystem;


            ISpatialReferenceFactory2 spatRefFact = new SpatialReferenceEnvironmentClass();
            m_GeographicCoordinateSystem = spatRefFact.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            m_ProjectedCoordinateSystem = spatRefFact.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);

            IPoint projPoint = new PointClass();
            projPoint.PutCoords(p.X, p.Y);
            projPoint.SpatialReference = m_GeographicCoordinateSystem;
            projPoint.Project(m_ProjectedCoordinateSystem);

            return projPoint;
        }
        
        public static IPoint transformCK42_Z6ToDegPulkovo(double x, double y)
        {
            IGeographicCoordinateSystem m_GeographicCoordinateSystem;
            IProjectedCoordinateSystem m_ProjectedCoordinateSystem;


            ISpatialReferenceFactory2 spatRefFact = new SpatialReferenceEnvironmentClass();
            
            m_GeographicCoordinateSystem = spatRefFact.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            m_ProjectedCoordinateSystem = spatRefFact.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);

            IPoint projPoint = new PointClass();
            projPoint.PutCoords(x, y);
            projPoint.SpatialReference = m_ProjectedCoordinateSystem;
            projPoint.Project(m_GeographicCoordinateSystem);

            return projPoint;
        }

        public static IPoint transformCK42_Z6ToDegPulkovo(IPoint p)
        {
            IGeographicCoordinateSystem m_GeographicCoordinateSystem;
            IProjectedCoordinateSystem m_ProjectedCoordinateSystem;


            ISpatialReferenceFactory2 spatRefFact = new SpatialReferenceEnvironmentClass();

            m_GeographicCoordinateSystem = spatRefFact.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            m_ProjectedCoordinateSystem = spatRefFact.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);

            IPoint projPoint = new PointClass();
            projPoint.PutCoords(p.X, p.Y);
            projPoint.SpatialReference = m_ProjectedCoordinateSystem;
            projPoint.Project(m_GeographicCoordinateSystem);

            return projPoint;
        }

        public static IEnvelope transformDegPulkovoToCK42_Z6(IEnvelope env)
        {
            IGeographicCoordinateSystem m_GeographicCoordinateSystem;
            IProjectedCoordinateSystem m_ProjectedCoordinateSystem;


            ISpatialReferenceFactory2 spatRefFact = new SpatialReferenceEnvironmentClass();
            m_GeographicCoordinateSystem = spatRefFact.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Pulkovo1942);
            m_ProjectedCoordinateSystem = spatRefFact.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_Pulkovo1942GK_6);

            IEnvelope projEnv = new EnvelopeClass();
            projEnv.PutCoords(env.XMin, env.YMin, env.XMax, env.YMax);
            projEnv.SpatialReference = m_GeographicCoordinateSystem;
            projEnv.Project(m_ProjectedCoordinateSystem);

            return projEnv;
        }





        public static string[] regex_strArr(string s, string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(s);

            List<string> strlist = new List<string>();

            while (match.Success)
            {

                strlist.Add(match.Value);

                match = match.NextMatch();

            }


            return strlist.GetRange(0, strlist.Count).ToArray();



        } //end getDataTable

        public static string regex_firstStr(string s, string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(s);

            return match.Value;
        } 

        public static DataTable get_dtLrec_fr_serv(string layername)
        {
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;
            DataTable service_table = new DataTable("service_table");

            dbCommand.CommandText = @"SELECT * FROM " + ProgParam.serviceTableName + " WHERE Layer = " + "'" + layername + "'";

            try { connection.Open(); }
            catch { MessageBox.Show("Ошибка подключения к БД"); return null; }


            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null; }

            service_table.Load(dbDataReader);

            dbDataReader.Close();
            connection.Close();

            return service_table;
        }

        public static DataTable get_dtTrec_fr_serv(string table)
        {
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;
            DataTable dt = new DataTable("service_table");

            dbCommand.CommandText = @"SELECT * FROM " + ProgParam.serviceTableName + " WHERE Table = " + "'" + table + "'";

            try { connection.Open(); }
            catch { MessageBox.Show("Ошибка подключения к БД"); return null; }


            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null; }

            dt.Load(dbDataReader);

            dbDataReader.Close();
            connection.Close();

            return dt;
        }

        public static List<int_val> get_info_fields(string table)
        {
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;
            DataTable service_table = new DataTable("service_table");

            dbCommand.CommandText = @"SELECT * FROM " + ProgParam.serviceTableName + " WHERE Table = " + "'" + table + "'";

            try { connection.Open(); }
            catch { MessageBox.Show("Ошибка подключения к БД"); return null; }


            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null; }

            service_table.Load(dbDataReader);

            dbDataReader.Close();
            connection.Close();

            int num_rows = service_table.Rows.Count;

            if (num_rows == 0)
            {
                MessageBox.Show("Не найдена таблица = " + table);
                return null;
            }
            if (num_rows >1)
            {
                MessageBox.Show("Найдены несколько одинаковых " + table + "\nв сервисной таблице, будет взята первая запись");
            }

            
            string info_fields_1 = "";
            string info_fields_2 = "";
            string info_fields_3 = "";
            string info_fields_4 = "";
            
            if(service_table.Rows[0]["info_fields_1"] is string)
            {
                info_fields_1 = (string)service_table.Rows[0]["info_fields_1"];
            }
            if(service_table.Rows[0]["info_fields_2"] is string)
            {
                info_fields_2 = (string)service_table.Rows[0]["info_fields_2"];
            }
            if (service_table.Rows[0]["info_fields_3"] is string)
            {
                info_fields_3 = (string)service_table.Rows[0]["info_fields_3"];
            }
            if (service_table.Rows[0]["info_fields_4"] is string)
            {
                info_fields_4 = (string)service_table.Rows[0]["info_fields_4"];
            }

            string info_fields = info_fields_1 + info_fields_2 + info_fields_3 + info_fields_4;
            
            string[] arr_str = Util.regex_strArr(info_fields, ProgParam.regexInfoFields);

           
            List<int_val> listv = new List<int_val>();
            
            for (int i = 0; i < arr_str.Length; i+=2)
            {
                int_val iv = new int_val();
                iv.i_key = Convert.ToInt32(arr_str[i]);
                iv.s_val = arr_str[i + 1];
                listv.Add(iv);
            }

            return listv;
        }

        public static DataTable get_dtService()
        {
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;
            DataTable service_table = new DataTable("service_table");

            dbCommand.CommandText = @"SELECT * FROM " + ProgParam.serviceTableName;

            try { connection.Open(); }
            catch { MessageBox.Show("Ошибка подключения к БД"); return null; }


            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null; }

            service_table.Load(dbDataReader);

            dbDataReader.Close();
            connection.Close();

            return service_table;
        }

        public static DataTable get_dtSchema()
        {
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;
            DataTable dtSchema = new DataTable("schemes");

            dbCommand.CommandText = @"SELECT * FROM " + ProgParam.schemas_table;

            try { connection.Open(); }
            catch { MessageBox.Show("Ошибка подключения к БД"); return null; }


            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка в запросе SQL\ndbDataReader = FAIL"); return null; }

            dtSchema.Load(dbDataReader);

            dbDataReader.Close();
            connection.Close();

            DataColumn dc = dtSchema.Columns[0];
            DataColumn[] dca = new DataColumn[] { dc };
            dtSchema.PrimaryKey = dca;

            return dtSchema;
        }

        public static DataTable get_dt(string table_name, string fk_field, int ID)
        {
            OleDbConnection connection = new OleDbConnection(ProgParam.connectionString);
            OleDbCommand dbCommand = connection.CreateCommand();
            OleDbDataReader dbDataReader;

            DataTable tn_table = new DataTable(table_name);

            //string expression = "SELECT " + fk_field + ", " + idarc_field + ", " + tn_field + ", " + sort_field +
            //                   " FROM " + from_table;

            string expression = "SELECT * FROM " + table_name;

            if (ID != -1)
                expression += " WHERE " + fk_field + " = " + ID.ToString();

          
            dbCommand.CommandText = expression;

            connection.Open();

            try { dbDataReader = dbCommand.ExecuteReader(); }
            catch { MessageBox.Show("Ошибка загрузки = " + table_name + "\n" + "dbDataReader = FAIL"); return null; }
            tn_table.Load(dbDataReader);


            dbDataReader.Close();
            connection.Close();

            return tn_table;

            //try { dbDataReader = dbCommand.ExecuteReader(); }
            //catch { MessageBox.Show("Ошибка загрузки = " + table_name + "\n" + "dbDataReader = FAIL"); return null; }
            //infoDataTable.Load(dbDataReader);
        }
    
    }


    public class int_val
    {
        public int i_key;
        public string s_val;
    }

    static class ProgParam
    {
        
        //home
        //public static string mxdName = @"D:\C#\Data\РК.mxd";
        //work
        //public static string mxdName = @"..\..\..\rkv2_4beta1.mxd";
        //net
        public static string mxdName = @"InfoCuks.mxd";

        //home
        //public static string connectionString = @"provider=Microsoft.Jet.OLEDB.4.0; data source=d:\c#\data\db3.mdb";
        //work
        //public static string connectionString = @"provider=Microsoft.Jet.OLEDB.4.0; data source=..\..\..\db3_beta.mdb";
        //net
        public static string connectionString = @"provider=Microsoft.Jet.OLEDB.4.0; data source=InfoCuks_v3.mdb";
        

        //home
        //public static string stylePath = @"..\..\new.serverstyle";
        //work
        //public static string stylePath = @"..\..\new.serverstyle";
        //net
        public static string stylePath = @"InfoCuks.serverstyle";
        
        
        
        //public static string connectionString = @"provider=Microsoft.Jet.OLEDB.4.0; data source=V:\ПО\DB\db3.mdb";
        public static string alg_str = @"Z:\ЦУКС2\1 Документы ОДС\12_Алгоритмы";


        
        public static string serviceTableName = "_servicetable";
        public static string schemas_table = "_schemas";

        public static string queryservicdb = @"SELECT * FROM";

        public static string regexRelTables =          @"(?<=\([^\(]*?)[a-zA-Z0-9а-яА-Я_]+(?=[^\)]*?\))";
        public static string regexQueryFields =        @"[a-zA-Z0-9а-яА-Я_]+\.([a-zA-Z0-9а-яА-Я_]+|\*)";
        public static string regexTreeViewFields = @"(?<=\()[a-zA-Z0-9а-яА-Я_:,.* ]+(?=\))";

        public static string regexTreeViewFields2 = @"[a-zA-Z0-9а-яА-Я_]+\.?[a-zA-Z0-9а-яА-Я_*]+";

        public static string regexTreeViewFields3 = @"[a-zA-Z0-9а-яА-Я_]+\.?[a-zA-Z0-9а-яА-Я_*]+";

        public static string regexTreeViewSortFields = @"(?<=\([^\(]*?)[a-zA-Z0-9а-яА-Я_:,]+(?=[^\)]*?\))";
        public static string regexTreeViewSortFields2 = @"(?<=\()[a-zA-Z0-9а-яА-Я_,.: ]+(?=\))";

        public static string regexStrDig1 = @"\b[^,:][a-zA-Z0-9а-яА-Я_]+";
        public static string regexStrDig2 = @"\b[0-9]+";

        public static string regexSchema = @"\d(?=\W*?:)";
        public static string regexTableFieldPair = @"[\w]+\.[\w*]+";

        public static string regexTwoPart = @"\w";

        public static string regexFirstPart = @".*[^.](?=\.)";
        public static string regexSecondPart = @"(?<=\.).*";

        public static string regexRel1 = @"(?<=\().*?(?=\))";
        public static string regexRel2 = @"(\b\w+)|\.";

        public static string regexNum_Schema = @"\d+|(?<="")[^ ,;].*?(?="")";

        public static string regexCon_1 = @"((?<=[[(])\w+)|(\w+(?=:Районы))|((?<=Районы.)\w+)";

        public static string regexInfoFields = @"((?<=\([ ]*?)\d+(?=[ ]*?[:]))|((?<=[:][ ]*?).*?(?=[ ]*?\)))";


        
    }


}
