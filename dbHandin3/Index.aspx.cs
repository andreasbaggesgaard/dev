using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace dbHandin3
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPokemons();
        }

        public string MyDb()
        {
            database db = new database();
            return db.dbConnection();
        }

        private void ShowPokemons()
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            string sqlsel = "SELECT TOP 3 * FROM pokemons";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
           
                rdr = cmd.ExecuteReader();
                RepeaterPokemons.DataSource = rdr;
                RepeaterPokemons.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonRun;");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            try
            {
                conn.Open();

                cmd = new SqlCommand("CheckUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("username", TextBoxAlias.Text);
                SqlParameter p2 = new SqlParameter("password", TextBoxPassword.Text);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);

                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                   
                    FormsAuthentication.RedirectFromLoginPage(TextBoxAlias.Text.ToLower(), true);

                    if(TextBoxAlias.Text.ToLower() == "webmaster")
                    {
                        Response.Redirect("webmaster.aspx");
                    }
                    else
                    {
                        Response.Redirect("crud.aspx");
                    }
                }
                    
                else
                {
                    LabelMessage.Text = "Invalid username or password - Try again.";
                }
            }
            catch(Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}