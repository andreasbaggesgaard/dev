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
    public partial class crud : System.Web.UI.Page
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

        public void UpdateGridView()
        {
            string getSessionUser = HttpContext.Current.User.Identity.Name;

            SqlConnection conn = new SqlConnection(myDb());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select catchid,name,lvl,experience,health,power,defense,speed,nextevolution,image from pokecatches, pokehunters, pokemons where pokecatches.fk_pokehunterid = pokehunters.hunterid and pokecatches.fk_pokemonid = pokemons.pokemonid and alias= '" + getSessionUser + "'";


            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewPokemons.DataSource = rdr;
                GridViewPokemons.DataBind();
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

        public void GridViewPokemons_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection conn = new SqlConnection(myDb());
            SqlCommand cmd = null;
            string sqldel = "delete from pokecatches where catchid = @catchid";


            try
            {
                conn.Open();

                cmd = new SqlCommand(sqldel, conn);
                cmd.Parameters.Add("@catchid", SqlDbType.Int);

                cmd.Parameters["@catchid"].Value = Convert.ToInt32(GridViewPokemons.Rows[e.RowIndex].Cells[3].Text);

                cmd.ExecuteNonQuery();

                LabelMessage.Text = "Pokemon has been deleted";
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
                UpdateGridView();
            }

        }

        protected void GridViewPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBoxName.Text = GridViewPokemons.SelectedRow.Cells[4].Text;
            LabelPokemonName.Text = "ID: " + GridViewPokemons.SelectedRow.Cells[3].Text;
        }

        protected void ButtonCatchPokemon_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myDb());
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            string sqlsel = "select pokemonid, number, name, nextevolution, image from pokemons";
            string sqlsel2 = "select * from pokecatches";

            List<Pokemon> pokemonList = new List<Pokemon>();

            try   
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();
                 
                while (rdr.Read())
                {
                    Pokemon p = new Pokemon();
                    p.id = (int)rdr["pokemonid"];
                    p.name = (string)rdr["name"];
                    p.image = (string)rdr["image"];
                    pokemonList.Add(p);

                    Random random = new Random();
                    int index = random.Next(0, pokemonList.Count);
                    var randomPokemon = pokemonList[index];

                    string writePokemon = "";
                     
                    writePokemon += "<div>"; 
                    writePokemon += "<h5>" + randomPokemon.id + "</h5>";
                    writePokemon += "<h3>" + randomPokemon.name + "</h5>";
                    writePokemon += "<img src=" + randomPokemon.image + " width='200'>";
                    writePokemon += "</div>";
                    
                    LiteralPokemon.Text = writePokemon;

                }
            }
            catch(Exception ex)
            {
                LabelCatchMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}