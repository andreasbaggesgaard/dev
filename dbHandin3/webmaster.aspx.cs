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
    public partial class webmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            UpdateGridView();
           
        }

        public string myDb()
        {
            database db = new database();
            return db.dbConnection();
        }

        private void UpdateGridView()
        {


            SqlConnection conn = new SqlConnection(myDb());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select * from pokemons";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "pokemons");
                dt = ds.Tables["pokemons"];

                GridViewPokemons.DataSource = dt;
                GridViewPokemons.DataBind();
            }
            catch (Exception ex)
            {
                LabelEditMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myDb());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from pokemons";
            string sqlins = "insert into pokemons values (@number, @name, @nextevolution, @image)";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "newPokemon");
                dt = ds.Tables["newPokemon"];

                DataRow newrow = dt.NewRow();
                newrow["number"] = TextBoxNumber.Text;
                newrow["name"] = TextBoxName.Text;
                newrow["nextevolution"] = TextBoxNextEvo.Text;
                newrow["image"] = TextBoxImage.Text;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@number", SqlDbType.Int, 200, "number");
                cmd.Parameters.Add("@name", SqlDbType.Text, 50, "name");
                cmd.Parameters.Add("@nextevolution", SqlDbType.Text, 50, "nextevolution");
                cmd.Parameters.Add("@image", SqlDbType.Text, 50, "image");

                da.InsertCommand = cmd;
                da.Update(ds, "newPokemon");
                LabelMessage.Text = "Pokémon has been added";

                UpdateGridView();

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

        protected void GridViewPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxEditNumber.Text = GridViewPokemons.SelectedRow.Cells[2].Text;
            TextBoxEditName.Text = GridViewPokemons.SelectedRow.Cells[3].Text;
            TextBoxEditNextEvo.Text = GridViewPokemons.SelectedRow.Cells[4].Text;
            TextBoxEditImage.Text = GridViewPokemons.SelectedRow.Cells[5].Text;
            LabelEditMessage.Text = "You chose Pokémon " + GridViewPokemons.SelectedRow.Cells[3].Text;

            GridViewPokemons.SelectedRowStyle.BackColor = System.Drawing.Color.LightGray;

        }


        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myDb());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from pokemons";
            string sqlupd = "update pokemons set number = @number, name = @name, nextevolution = @nextevo, image = @image where pokemonid = @pokemonid";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "pokemon");
                dt = ds.Tables["pokemon"];

                int mytableindex = GridViewPokemons.SelectedIndex;
                dt.Rows[mytableindex]["number"] = TextBoxEditNumber.Text;
                dt.Rows[mytableindex]["name"] = TextBoxEditName.Text;
                dt.Rows[mytableindex]["nextevolution"] = TextBoxEditNextEvo.Text;
                dt.Rows[mytableindex]["image"] = TextBoxEditImage.Text;

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@number", SqlDbType.Int, 200, "number");
                cmd.Parameters.Add("@name", SqlDbType.Text, 50, "name");
                cmd.Parameters.Add("@nextevo", SqlDbType.Text, 50, "nextevolution");
                cmd.Parameters.Add("@image", SqlDbType.Text, 50, "image");
                SqlParameter parm = cmd.Parameters.Add("@pokemonid", SqlDbType.Int, 4, "pokemonid");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "pokemon");
                LabelEditMessage.Text = "Pokémon has been updated";

                UpdateGridView();

            }
            catch (Exception ex)
            {
                LabelEditMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myDb());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from pokemons";
            string sqldel = "delete from pokemons where pokemonid = @pokemonid";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "pokemon");
                dt = ds.Tables["pokemon"];

                int mytableindex = GridViewPokemons.SelectedIndex;
                dt.Rows[mytableindex]["pokemonid"] = Convert.ToInt32(GridViewPokemons.SelectedRow.Cells[1].Text);

                cmd = new SqlCommand(sqldel, conn);
                SqlParameter parm = cmd.Parameters.Add("@pokemonid", SqlDbType.Int, 4, "pokemonid");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "pokemon");

                LabelEditMessage.Text = TextBoxEditName.Text + " has been deleted";

                UpdateGridView();

            }
            catch (Exception ex)
            {
                LabelEditMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}