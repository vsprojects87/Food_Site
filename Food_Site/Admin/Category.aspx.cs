using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Site.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {

            string actioName= string.Empty, imagePath= string.Empty, fileExtention= string.Empty;
            bool isValidToExecute = false;
            int CategoryId = Convert.ToInt32(hdnId.Value);
            con = new SqlConnection(Connection.GetConnectionString());
            cmd= new SqlCommand("Category_Crud", con);
            cmd.Parameters.AddWithValue("@Action", CategoryId = 0 ? "INSERT" : "UPDATE");
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            cmd.Parameters.AddWithValue("@Name",txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@IsActive", cbIsActive.Checked);
            if(fuCategoryImage.HasFile)
            {
                if(Utils.IsValidExtention(fuCategoryImage.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtention = Path.GetExtension(fuCategoryImage.FileName);
                    imagePath= "Images/Category/" + obj.ToString() + fileExtention;
                    fuCategoryImage.PostedFile.SaveAs(Server.MapPath("~/Images/Category") + obj.ToString() + fileExtention);
                    cmd.Parameters.AddWithValue("@ImageUrl", imagePath);
                    isValidToExecute = true;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please select .jpg, .jpeg or .png images";
                    lblMsg.CssClass = "alert alert-danger";
                    isValidToExecute= false;
                }
            }
            else
            {
                isValidToExecute= true;
            }

            if (isValidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actioName = CategoryId == 0 ? "inserted" : "updated";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Category" + actioName + "successfully";
                    lblMsg.CssClass = "alert alert-danger";
                    getCategories();
                    clear();
                }
                catch(Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error-" + ex.Message;
                    lblMsg.CssClass= "alert alert-danger";
                }
                finally
                {
                    con.Close();
                } 
            }
































        }
    }
}