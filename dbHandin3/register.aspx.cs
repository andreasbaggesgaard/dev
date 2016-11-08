using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace dbHandin3
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string myDb()
        {
            database db = new database();
            return db.dbConnection();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                SqlConnection conn = new SqlConnection(myDb());
                SqlDataAdapter da = null;
                DataSet ds = null;
                DataTable dt = null;
                SqlCommand cmd = null;
                string sqlsel = "select * from pokehunters";
                string sqlins = "insert into pokehunters values (@firstname, @lastname, @alias, @gender, @age, @email, @password)";

                try
                {
                    da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(sqlsel, conn);

                    ds = new DataSet();
                    da.Fill(ds, "newUser");
                    dt = ds.Tables["newUser"];

                    string firstName = String.IsNullOrWhiteSpace(TextBoxName.Text) ? null : TextBoxName.Text;
                    string lastName = String.IsNullOrWhiteSpace(TextBoxLastname.Text) ? null : TextBoxLastname.Text;
                    string alias = String.IsNullOrWhiteSpace(TextBoxAlias.Text) ? null : TextBoxAlias.Text;
                    string password = String.IsNullOrWhiteSpace(TextBoxPassword.Text) ? null : TextBoxPassword.Text;
                    string passwordConfirm = String.IsNullOrWhiteSpace(TextBoxPasswordConfirm.Text) ? null : TextBoxPasswordConfirm.Text;

                    DataRow newrow = dt.NewRow();
                    newrow["firstname"] = firstName;
                    newrow["lastname"] = lastName;
                    newrow["alias"] = alias;
                    newrow["gender"] = RadioButtonListGender.SelectedItem.Value;
                    newrow["age"] = TextBoxAge.Text;
                    newrow["email"] = password;
                    newrow["password"] = passwordConfirm;
                    dt.Rows.Add(newrow);

                    cmd = new SqlCommand(sqlins, conn);
                    cmd.Parameters.Add("@firstname", SqlDbType.Text, 50, "firstname");
                    cmd.Parameters.Add("@lastname", SqlDbType.Text, 50, "lastname");
                    cmd.Parameters.Add("@alias", SqlDbType.Text, 50, "alias");
                    cmd.Parameters.Add("@gender", SqlDbType.Text, 10, "gender");
                    cmd.Parameters.Add("@age", SqlDbType.Int, 200, "age");
                    cmd.Parameters.Add("@email", SqlDbType.Text, 200, "email");
                    cmd.Parameters.Add("@password", SqlDbType.Text, 200, "password");

                    da.InsertCommand = cmd;
                    da.Update(ds, "newUser");
                    LabelMessage.Text = "Welcome " + TextBoxAlias.Text + "- You've now been added!";

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
        }
    }
}