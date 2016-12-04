using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace dbHandin3
{
    public partial class sponsors : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdatePage();
            }
            else
            {
                if (DropDownListSponsors.SelectedIndex != 0)
                {
                    ds = new DataSet();
                    ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                    dt = ds.Tables["Sponsor"];

                    foreach (DataRow r in dt.Select("SponsorID = " + Convert.ToInt32(DropDownListSponsors.SelectedValue)))
                    {
                        TextBoxId.Text = r["SponsorID"].ToString();
                        TextBoxCompany.Text = r["Companyname"].ToString();
                        TextBoxWebsite.Text = r["Website"].ToString();
                        //TextboxLogo = r["Logo"].ToString();
                    }

                    LabelMessages.Text = TextBoxCompany.Text + " has been selected";

                    DropDownListSponsors.SelectedIndex = 0;

                    ButtonCreate.Enabled = false;
                    ButtonUpdate.Enabled = true;
                    ButtonDelete.Enabled = true;
                }
            }
        }

        public void UpdatePage()
        {
            DropDownListSponsors.AutoPostBack = true;
            DropDownListSponsors.Items.Clear();
            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                dt = ds.Tables["Sponsor"];
                DropDownListSponsors.DataSource = dt;
                DropDownListSponsors.DataTextField = dt.Columns[1].ToString();
                DropDownListSponsors.DataValueField = dt.Columns[0].ToString();
                DropDownListSponsors.DataBind();

                RepeaterSponsors.DataSource = dt;
                RepeaterSponsors.DataBind();

               //DropDownListSponsors.Items.Insert(0, "You can choose a sponsor");
            }
            catch
            {
                MakeNewDataSetAndDataTable();
            }
            finally
            {
                RepeaterSponsors.DataSource = dt;
                RepeaterSponsors.DataBind();

                DropDownListSponsors.Items.Insert(0, "You can choose a sponsor");
            }

            TextBoxId.Text = "";
            TextBoxCompany.Text = "";
            TextBoxWebsite.Text = "";
            ButtonCreate.Enabled = true;
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
        }

        public void MakeNewDataSetAndDataTable()
        {
            ds = new DataSet("Sponsors");
            dt = ds.Tables.Add("Sponsor");
            dt.Columns.Add("SponsorID", typeof(Int32));
            dt.Columns.Add("Companyname", typeof(string));
            dt.Columns.Add("Website", typeof(string));
            dt.Columns.Add("Logo", typeof(string));
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
                dt = ds.Tables["Sponsor"];
            }
            catch
            {
                MakeNewDataSetAndDataTable();
            }

            int maxSponsorId = 0;
            if (dt == null)
            {
                MakeNewDataSetAndDataTable();
            }
            else
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (Convert.ToInt32(r["SponsorID"].ToString()) > maxSponsorId) maxSponsorId = Convert.ToInt32(r["SponsorID"].ToString());
                }
            }

            string filename = string.Empty;
            filename = Path.GetFileName(fileUpload.PostedFile.FileName);
            fileUpload.PostedFile.SaveAs(Server.MapPath("~/images/" + filename));

            //LabelMessages.Text = "You have succesfully uploaded " + fileUpload.FileName + " to the folder <b>Files<b/>";

            DataRow newRow = dt.NewRow();
            newRow["SponsorID"] = maxSponsorId + 1;
            newRow["Companyname"] = TextBoxCompany.Text;
            newRow["Website"] = TextBoxWebsite.Text;
            newRow["Logo"] = fileUpload.FileName;
            dt.Rows.Add(newRow);

            ds.WriteXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            UpdatePage();

            LabelMessages.Text = TextBoxCompany.Text + " has been created with Sponsor id " + (maxSponsorId + 1);
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            dt = ds.Tables["Sponsor"];

            foreach (DataRow r in dt.Select("SponsorID = " + TextBoxId.Text))
            {
                r["SponsorID"] = Convert.ToInt32(TextBoxId.Text);
                r["Companyname"] = TextBoxCompany.Text;
                r["Website"] = TextBoxWebsite.Text;
                r["Logo"] = fileUpload.FileName;
            }

            ds.WriteXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            LabelMessages.Text = TextBoxCompany.Text + " has been changed";
            UpdatePage();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            dt = ds.Tables["Sponsor"];

            foreach (DataRow r in dt.Select("SponsorID = " + TextBoxId.Text))
            {
                r.Delete();
            }

            ds.WriteXml(Server.MapPath("~/XMLFile/XMLSponsors.xml"));
            LabelMessages.Text = TextBoxCompany.Text + " has been deleted";
            UpdatePage();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            LabelMessages.Text = "Input fields has been cleared";
            UpdatePage();
        }

        

            

    }
}