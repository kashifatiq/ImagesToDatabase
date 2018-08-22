using ImagesToDatabase.DB;
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
using ImageDb = ImagesToDatabase.DB.Image;
namespace ImagesToDatabase
{
    public partial class frmDownload : Form
    {
        ImagesToDatabaseEntities _EF = new ImagesToDatabaseEntities();
        dynamic vrUploadedColor = Color.LightGreen;
        public frmDownload()
        {
            InitializeComponent();
        }

        private void frmDownload_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("File", 500);
            listView1.Columns.Add("File Name", 500);
        }

        private void btnSelectDownloadFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                txtSelectedFolder.Text = fbd.SelectedPath;
                if (!string.IsNullOrEmpty(txtSelectedFolder.Text.Trim()))
                {
                    btnLoadAndVarify.Enabled = true;
                }
                else
                    btnLoadAndVarify.Enabled = false;
                listView1.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadAndVarify_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadAndCompareFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadAndCompareFiles()
        {
            List<ImageDb> vrDatabaseImages = (from results in _EF.Images select results).ToList();
            listView1.Items.Clear();
            string[] arr = new string[2];
            ListViewItem listViewItem;
            var AllFiles = Directory.EnumerateFiles(txtSelectedFolder.Text.Trim(), "*.*", SearchOption.AllDirectories);
            int totAlreadyExists = 0;
            int totNewFiles = 0;
            foreach (ImageDb imageRecord in vrDatabaseImages)
            {
                arr[0] = imageRecord.FilePath;
                arr[1] = imageRecord.FileName;
                listViewItem = new ListViewItem(arr);
                string vrFilePathToSearch = txtSelectedFolder.Text.Trim() + imageRecord.FilePath.Trim().Replace("C:", "").Replace("D:", "").Replace("E:", "").Replace("F:", "").Replace("G:", "");
                bool isImageExists = AllFiles.Contains(vrFilePathToSearch);
                if (isImageExists)
                {
                    totAlreadyExists = totAlreadyExists + 1;
                    listViewItem.BackColor = vrUploadedColor;
                }
                else
                {
                    totNewFiles = totNewFiles + 1;
                }
                listViewItem.Tag = imageRecord.ImageBytes;
                listView1.Items.Add(listViewItem);
            }
            lblAlreadyUploadedFiles.Text = "Files Already Downlaoded: " + totAlreadyExists.ToString();
            lblNewFiles.Text = "New Files: " + totNewFiles.ToString();
            lblTotalFilesFound.Text = "All Files: " + (totAlreadyExists + totNewFiles).ToString();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < listView1.Items.Count; x++)
            {
                if (listView1.Items[x].BackColor != vrUploadedColor)
                    listView1.Items[x].Checked = chkSelectAll.Checked;
            }
        }

        private void btnDownlaodFiles_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lstItem in listView1.Items)
                {
                    if (lstItem.Tag != null && lstItem.Checked)
                    {
                        string fileName = lstItem.SubItems[1].Text.Trim();
                        string completeFilePath = lstItem.SubItems[0].Text.Trim().Replace("C:", "").Replace("D:", "").Replace("E:", "").Replace("F:", "").Replace("G:", "");
                        completeFilePath = txtSelectedFolder.Text.Trim() + completeFilePath;
                        if (!Directory.Exists(completeFilePath.Replace(fileName, "")))
                        {
                            Directory.CreateDirectory(completeFilePath.Replace(fileName, ""));
                        }
                        File.WriteAllBytes(completeFilePath, (byte[])lstItem.Tag);
                    }
                }
                this.DownloadAndCompareFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
