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
    public partial class Main : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=20010803");
        string name = "";
        string age = "";
        string education = "";
        string gender = "";
        string interest = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {       
            if (tbxName.Text != "" && tbxAge.Text != "" && ddlEducation.SelectedItem.Text != "" && rbtnlistGender.SelectedItem.ToString() != "" && cblInterest.SelectedIndex != -1)
            {
                name = tbxName.Text;
                age = tbxAge.Text;
                education = ddlEducation.SelectedItem.Text;
                for (int i = 0; i < cblInterest.Items.Count; i++)
                {
                    if (cblInterest.Items[i].Selected)
                    {
                        interest += cblInterest.Items[i].ToString();
                    }
                }
                gender = rbtnlistGender.SelectedItem.ToString();
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand("INSERT INTO public.data(name, age, gender, education, interest) VALUES (@a1,@b1,@c1,@d1,@e1)", conn);
                comm.Parameters.AddWithValue("a1", name);
                comm.Parameters.AddWithValue("b1", age);
                comm.Parameters.AddWithValue("c1", gender);
                comm.Parameters.AddWithValue("d1", education);
                comm.Parameters.AddWithValue("e1", interest);
                comm.ExecuteNonQuery();
                conn.Close();                
                Response.Redirect("Show.aspx");
            }
            else
            {
                lblError.Text = "Please insert your all information";
                name = age = education = gender = interest = "";
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand("DELETE FROM public.data WHERE name = @a1 and age = @b1", conn);
            comm.Parameters.AddWithValue("a1",tbxName.Text);
            comm.Parameters.AddWithValue("b1", tbxAge.Text);
            comm.ExecuteNonQuery();//執行
            conn.Close();
            Response.Redirect("Show.aspx");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand("SELECT * FROM public.data WHERE name = @a1 and age = @b1",conn);
            comm.Parameters.AddWithValue("a1", tbxName.Text);
            comm.Parameters.AddWithValue("b1", tbxAge.Text);
            var reader = comm.ExecuteReader();
            while (reader.Read())//確認每個資料是否正確
            {
                reader.GetString(0);
                reader.GetString(1);
                reader.GetString(2);
                reader.GetString(3);
                reader.GetString(4);

            }
            reader.Close();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(comm);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            comm.Dispose();
            conn.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxName.Text != "" && tbxAge.Text != "" && ddlEducation.SelectedItem.Text != "" && rbtnlistGender.SelectedItem.ToString() != "" && cblInterest.SelectedIndex != -1)
            {
                name = tbxName.Text;
                age = tbxAge.Text;
                education = ddlEducation.SelectedItem.Text;
                for (int i = 0; i < cblInterest.Items.Count; i++)
                {
                    if (cblInterest.Items[i].Selected)
                    {
                        interest += cblInterest.Items[i].ToString();
                    }
                }
                gender = rbtnlistGender.SelectedItem.ToString();
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand("UPDATE public.data SET name=@a1, age=@b1, gender=@c1, education=@d1, interest=@e1 WHERE name = @a2 and age = @b2",conn);
                comm.Parameters.AddWithValue("a2", name);
                comm.Parameters.AddWithValue("b2", age);
                comm.Parameters.AddWithValue("a1", name);
                comm.Parameters.AddWithValue("b1", age);
                comm.Parameters.AddWithValue("c1", gender);
                comm.Parameters.AddWithValue("d1", education);
                comm.Parameters.AddWithValue("e1", interest);
                comm.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Show.aspx");
            }
            else
            {
                lblError.Text = "Please insert your all information";
                name = age = education = gender = interest = "";
            }
        }
    }
}