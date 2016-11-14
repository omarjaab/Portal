using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class pnbfileupload : System.Web.UI.Page
    {
        Controllers.DefaultController dp = new Controllers.DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Controllers.login.data != null)
                Controllers.login.ConstructNavigator(Navigator);
            else { Response.Redirect("Logon.aspx"); }
        }

        protected void radioTest_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ListDirectory(TreeView1, @"\\fsses204.posten.local\E$\FileShareQA");
            }
        }
        protected void radioDev_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ListDirectory(TreeView1, @"\\fsses204.posten.local\E$\FileShareDev");
            }
        }
        protected void radioProd_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ListDirectory(TreeView1, @"\\fsses204.posten.local\E$\FileShareProd");
                //this.PopulateTreeView(rootInfo, null);
            }
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name, directoryInfo.FullName, "Images/ikon.jpg");
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.ChildNodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.ChildNodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }


        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string sourceFile = Server.MapPath("~/" + FileUploadControl.PostedFile.FileName);
                    string DestinationFile = TreeView1.SelectedNode.Value;
                    FileUploadControl.PostedFile.SaveAs(DestinationFile + "\\" + FileUploadControl.FileName);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
        


    }
}