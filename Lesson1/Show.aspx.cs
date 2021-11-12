using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

namespace Lesson1
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=20010803");
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM public.data";
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter(comm);
                DataTable dt = new DataTable();
                nda.Fill(dt);
                comm.Dispose();
                conn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch
            {
                Label1.Text = "資料庫未連線!";
            }
        }
    }
}