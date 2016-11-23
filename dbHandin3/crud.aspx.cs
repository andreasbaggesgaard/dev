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

        public string MyDb()
        {
            database db = new database();
            return db.dbConnection();
        }

        public string GetUser()
        {
            string getSessionUser;
            return getSessionUser = HttpContext.Current.User.Identity.Name;
        }

        public void UpdateGridView()
        {
        
            SqlConnection conn = new SqlConnection(MyDb());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select catchid,name,nextevolution,lvl,experience,health,power,defense,speed, image 
                from pokecatches, pokehunters, pokemons 
                where pokecatches.fk_pokehunterid = pokehunters.hunterid 
                and pokecatches.fk_pokemonid = pokemons.pokemonid 
                and alias= '" + GetUser() + "'";

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
            SqlConnection conn = new SqlConnection(MyDb());
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

        // Display random pokemon on page
        protected void ButtonCatchPokemon_Click(object sender, EventArgs e)
        {          
            SqlConnection conn = new SqlConnection(MyDb());
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            string sqlsel = "select pokemonid, number, name, nextevolution, image from pokemons";

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
                    writePokemon += "<div class='pokemon pull-right'>"; 
                    //writePokemon += "<h5>" + randomPokemon.id + "</h5>";
                    writePokemon += "<h4 style='font-weight:bolder'>A wild " + randomPokemon.name + " appears!</h4>";
                    writePokemon += "<img src=" + randomPokemon.image + " width='150' style='margin-top:30px;'>";
                    writePokemon += "</div>";                   
                    LiteralPokemon.Text = writePokemon;

                    Application["caughtPokemonId"] = randomPokemon.id;
                    Application["pokemonName"] = randomPokemon.name;

                }
            }
            catch(Exception ex)
            {
                LiteralCatchMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
                
            }         
           
        }

        // Method to get nextevolutionid
        public int GetNextEvolutionId()
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            int nextEvoId = 0;
            string nextEvoName = GridViewPokemons.SelectedRow.Cells[5].Text;
            string sqlsel = "select pokemonid from pokemons where name ='"+ nextEvoName +"'";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Evolve e = new Evolve();
                    nextEvoId = e.pokemonid = (int)rdr["pokemonid"];

                }
            }
            catch (Exception ex)
            {
                LiteralCatchMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();

            }
            return nextEvoId;
        }

        // Method to get catchid for evolve
        public int GetCatchId()
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            int catchid = 0;
            string sqlsel = "select catchid from pokecatches, pokehunters, pokemons 
                where pokecatches.fk_pokehunterid = pokehunters.hunterid 
                and pokecatches.fk_pokemonid = pokemons.pokemonid 
                and name= '"+ GridViewPokemons.SelectedRow.Cells[4].Text + "'";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Evolve e = new Evolve();
                    catchid = e.catchid = (int)rdr["catchid"];
                }
            }
            catch (Exception ex)
            {
                LiteralCatchMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();

            }
            return catchid;
        }

        // Method to get catchid for evolve
        public int GetPokehunterId()
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            int pokehunterid = 0;
            string sqlsel = "select fk_pokehunterid from pokecatches, pokehunters, pokemons 
                where pokecatches.fk_pokehunterid = pokehunters.hunterid 
                and pokecatches.fk_pokemonid = pokemons.pokemonid 
                and name= '" + GridViewPokemons.SelectedRow.Cells[4].Text + "' and alias= '" + GetUser() + "'";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Evolve e = new Evolve();
                    pokehunterid = e.hunterid = (int)rdr["fk_pokehunterid"];
                }
            }
            catch (Exception ex)
            {
                LiteralCatchMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();

            }
            return pokehunterid;
        }

        // evolve pokemon
        protected void GridViewPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlCommand cmd = null;
            string sqlupd = "update pokecatches set fk_pokemonid = @pokemonid 
                where fk_pokehunterid = @pokehunterid 
                and catchid = @catchid";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@pokemonid", SqlDbType.Int);
                cmd.Parameters.Add("@pokehunterid", SqlDbType.Int);
                cmd.Parameters.Add("@catchid", SqlDbType.Int);

                cmd.Parameters["@pokemonid"].Value = GetNextEvolutionId();
                cmd.Parameters["@pokehunterid"].Value = GetPokehunterId();
                cmd.Parameters["@catchid"].Value = GetCatchId();

                cmd.ExecuteNonQuery();
                LabelMessage.Text = "Pokémon has been evolved";
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


        // Method to return current pokehunterid in session
        public int GetHunterId()
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            string getId = null;
            int pokehunterId = 0;
            string sqlsel = "select hunterid from pokehunters where alias='"+ GetUser() +"'";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    getId = rdr[0].ToString();
                    pokehunterId = Convert.ToInt32(getId);
                }
            }
            catch(Exception ex)
            {
                LiteralCatchMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }     
            return pokehunterId;
        }

        // Catch Pokemon based on random number
        protected void ButtonCatch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(MyDb());
            SqlDataAdapter da = null;          
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from pokecatches";
            string sqlins = "insert into pokecatches 
                values (@lvl, @health, @power, @defense, @speed, @experience, @fk_pokehunterid, @fk_pokemonid)";

            Random ifCaught = new Random();
            int number = ifCaught.Next(1, 10);
             
            if(number % 2 == 0)
            {
                try
                {
                    da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(sqlsel, conn);

                    ds = new DataSet();
                    da.Fill(ds, "caughtPokemon");
                    dt = ds.Tables["caughtPokemon"];

                    Random random = new Random();
                    int lvl = random.Next(1, 10); 
                    int health = random.Next(1, 200);   
                    int power = random.Next(1, 200);
                    int defense = random.Next(1, 50);
                    int speed = random.Next(1, 50);
                    int experience = random.Next(1, 2000);

                    DataRow newrow = dt.NewRow();
                    newrow["lvl"] = lvl;
                    newrow["health"] = health;
                    newrow["power"] = power;
                    newrow["defense"] = defense;
                    newrow["speed"] = speed;
                    newrow["experience"] = experience;
                    newrow["fk_pokehunterid"] = GetHunterId();
                    newrow["fk_pokemonid"] = Application["caughtPokemonId"];
                    dt.Rows.Add(newrow);

                    cmd = new SqlCommand(sqlins, conn);
                    cmd.Parameters.Add("@lvl", SqlDbType.Int, 10, "lvl");
                    cmd.Parameters.Add("@health", SqlDbType.Int, 200, "health");
                    cmd.Parameters.Add("@power", SqlDbType.Int, 200, "power");
                    cmd.Parameters.Add("@defense", SqlDbType.Int, 50, "defense");
                    cmd.Parameters.Add("@speed", SqlDbType.Int, 50, "speed");
                    cmd.Parameters.Add("@experience", SqlDbType.Int, 2000, "experience");
                    cmd.Parameters.Add("@fk_pokehunterid", SqlDbType.Int, 50, "fk_pokehunterid");
                    cmd.Parameters.Add("@fk_pokemonid", SqlDbType.Int, 50, "fk_pokemonid");

                    da.InsertCommand = cmd;
                    da.Update(ds, "caughtPokemon");
                    LiteralCatchMessage.Text = "<div class='alert alert-success msg'>You were strong enough! <b>" 
                        + Application["pokemonName"] + "</b> has been caught!</div>";

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
            else
            {
                LiteralCatchMessage.Text = "<div class='alert alert-danger msg'><b>" 
                    + Application["pokemonName"] + 
                    "</b> is way too strong. Try again or return when you are more experienced ..</div>";
            }
        }
    }
}