using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B7_Entertainment.Models;

namespace B7_Entertainment.Controllers
{
    public class HomePageController : Controller
    {
        ConnectionStringSettings myConn = ConfigurationManager.ConnectionStrings["Entertain"];
        DataTable dt = new DataTable();
        
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }


        //Load Data
        public ActionResult EList()
        {
            return View();
        }

        public ActionResult LoadDataEList(EntertainmentModel EM){

            List<string> ModelData = new List<string>();
            string ConString = myConn.ConnectionString;
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();
            try
            {
                using (SqlCommand command = new SqlCommand("EntertainTransac", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Option", System.Data.SqlDbType.Int);
                    command.Parameters["@Option"].Value = 1;
                    SqlDataAdapter sa = new SqlDataAdapter();
                    sa.SelectCommand = command;
                    sa.Fill(dt);
                }
            }
            catch (Exception ex) {
                return View(ex.Message);
            }
            conn.Close();

            List<Dictionary<string, Object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, Object> row;
            foreach (DataRow dr in dt.Rows) {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns) {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return Json(rows);
        }
    }
}