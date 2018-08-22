using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImagesToDatabase.DB;
using ImageDb = ImagesToDatabase.DB.Image;
namespace ImagesToDatabase
{
    public partial class Form1 : Form
    {
        ImagesToDatabaseEntities _EF = new ImagesToDatabaseEntities();
        dynamic vrUploadedColor = Color.LightGreen;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowsDialoge = new FolderBrowserDialog();
                folderBrowsDialoge.ShowDialog();
                txtSelectedFolder.Text = folderBrowsDialoge.SelectedPath;
                if (!string.IsNullOrEmpty(txtSelectedFolder.Text.Trim()))
                    LoadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFiles()
        {
            if (string.IsNullOrEmpty(txtSelectedFolder.Text.Trim()))
            {
                MessageBox.Show("File Path Not Provided", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSelectFolder.Focus();
                return;
            }
            listView1.Items.Clear();
            string[] arr = new string[2];
            ListViewItem listViewItem;
            var AllFiles = Directory.EnumerateFiles(txtSelectedFolder.Text.Trim(), "*.*", SearchOption.AllDirectories);

            int totAlreadyExists = 0;
            int totNewFiles = 0;
            foreach (string fileName in AllFiles)
            {
                arr[0] = fileName;
                arr[1] = Path.GetFileName(fileName);
                listViewItem = new ListViewItem(arr);

                bool isImageExists = _EF.Images.Any(r => r.FilePath == fileName);
                if (isImageExists)
                {
                    totAlreadyExists = totAlreadyExists + 1;
                    listViewItem.BackColor = vrUploadedColor;
                }
                else
                {
                    totNewFiles = totNewFiles + 1;
                }
                listView1.Items.Add(listViewItem);
            }
            lblAlreadyUploadedFiles.Text = "Files already uploaded: " + totAlreadyExists.ToString();
            lblNewFiles.Text = "New files: " + totNewFiles.ToString();
            lblTotalFilesFound.Text = "All files: " + (totAlreadyExists + totNewFiles).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("File", 500);
            listView1.Columns.Add("File Name", 500);
        }

        public byte[] ConvertFileToBytes(string filePath)
        {
            FileStream fsImageStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] bImageData = new byte[fsImageStream.Length];
            fsImageStream.Read(bImageData, 0, System.Convert.ToInt32(fsImageStream.Length));
            fsImageStream.Close();
            return bImageData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int filesSavedCounter = 0;
            foreach(ListViewItem lstItem in listView1.Items)
            {
                if(lstItem.Checked)
                {
                    ImageDb newImage = new ImageDb();
                    newImage.DateCreated = DateTime.Now;
                    newImage.FileName = lstItem.SubItems[1].Text;
                    newImage.FilePath = lstItem.SubItems[0].Text;
                    newImage.ImageBytes = ConvertFileToBytes(newImage.FilePath);
                    _EF.Images.Add(newImage);
                    filesSavedCounter = filesSavedCounter + 1;   
                }
            }
            if (filesSavedCounter > 0)
                _EF.SaveChanges();
            MessageBox.Show(filesSavedCounter.ToString() + " Files are now saved in database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadFiles();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < listView1.Items.Count; x++)
            {
                if (listView1.Items[x].BackColor != vrUploadedColor)
                    listView1.Items[x].Checked = chkSelectAll.Checked;
            }
        }

        private void btnDownloadFiles_Click(object sender, EventArgs e)
        {
            frmDownload frmDownload = new frmDownload();
            frmDownload.Show();
        }
    }
}
