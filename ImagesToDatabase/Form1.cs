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
        DB.ImagesToDatabaseEntities _EF = new ImagesToDatabaseEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                //Add items in the listview
                string[] arr = new string[2];
                ListViewItem listViewItem;

                folderBrowserDialog1.ShowDialog();
                txtSelectedFolder.Text = folderBrowserDialog1.SelectedPath;
                foreach (string fileName in Directory.EnumerateFiles(txtSelectedFolder.Text.Trim(), "*.*", SearchOption.AllDirectories))
                {
                    arr[0] = fileName;
                    arr[1] = Path.GetFileName(fileName);
                    listViewItem = new ListViewItem(arr);

                    bool isImageExists = _EF.Images.Any(r => r.FilePath == fileName);
                    if(isImageExists)
                    {
                        listViewItem.Checked = false;
                        listViewItem.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        listViewItem.Checked = false;
                    }
                    listView1.Items.Add(listViewItem);
                    var dd3 = from im in _EF.Images select im;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public byte[] GetImageData(string filePath)
        {
            FileStream fsImageStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] bImageData = new byte[fsImageStream.Length];
            fsImageStream.Read(bImageData, 0, System.Convert.ToInt32(fsImageStream.Length));
            fsImageStream.Close();
            return bImageData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem lstItem in listView1.Items)
            {
                if(lstItem.Checked)
                {
                    ImageDb newImage = new ImageDb();
                    newImage.DateCreated = DateTime.Now;
                    newImage.FileName = lstItem.SubItems[1].Text;
                    newImage.FilePath = lstItem.SubItems[0].Text;
                    newImage.ImageBytes = GetImageData(newImage.FilePath);
                    _EF.Images.Add(newImage);
                    _EF.SaveChanges();
                }
            }
        }
    }
}
