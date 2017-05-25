using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace FileManager
{
    public partial class MainForm : Form
    {
        public DriveInfo[] arrayDrivesInfo;
        public string leftPath = "*.*";
        public string rightPath = "*.*";

        public MainForm()
        {
            InitializeComponent();
            arrayDrivesInfo = DriveInfo.GetDrives();
        }
        private void toolStripNoterpad_Click(object sender, EventArgs e)
        {
            string path = @"C:\Windows\System32\notepad.exe";
            try
            {
                if (File.Exists(path))
                {
                    Process.Start(path);
                }
                else
                {
                    throw new FileNotFoundException("File not found!", path);
                }
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           foreach(DriveInfo drive in arrayDrivesInfo)
            {
                driveLeft.Items.Add($"[{drive.Name}]");
                driveRight.Items.Add($"[{drive.Name}]");
            }
        }

        private void driveLeft_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo driveInfo = (DriveInfo)arrayDrivesInfo.GetValue(((ComboBox)sender).SelectedIndex);
            leftPath = driveInfo.RootDirectory.FullName;
            labelPathLeft.Text = leftPath;

            ShowInformation(driveLeft, driveInfo, infoDriveLeft, listLeft, leftPath);
        }

        private void driveRight_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo driveInfo = (DriveInfo)arrayDrivesInfo.GetValue(((ComboBox)sender).SelectedIndex);
            rightPath = driveInfo.RootDirectory.FullName;
            labelPathRight.Text = rightPath;

            ShowInformation(driveRight, driveInfo, infoDriveRight, listRight, rightPath);
        }

        private void ShowInformation(ComboBox cbDrive, DriveInfo driveInfo, Label infoDrive, ListView list, string path)
        {
            if (driveInfo.IsReady)
            {
                ShowInfoOfSpace(infoDrive, driveInfo);
                ShowFolders(list, path, driveInfo, false);
                ShowFiles(list, path, driveInfo, false);
            }
            else
            {
                MessageBox.Show("Устройство не готово! \nВыберите другое устройство", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDrive.SelectedIndex = -1;
                infoDrive.Text = String.Empty;
            }
        }

        private void ShowInfoOfSpace(Label label, DriveInfo driveInfo)
        {
            string volumeLabel = driveInfo.VolumeLabel != String.Empty ? $"[{driveInfo.VolumeLabel}]" : "[_нет_]";
            label.Text = volumeLabel + $"\t свободно " + GetMegabyteToString(driveInfo.TotalFreeSpace)
                                                    + " Мб из " + GetMegabyteToString(driveInfo.TotalSize) + " Мб";
        }

        private void ShowFolders(ListView list, string path, DriveInfo driveInfo, bool showHiddenAndSystem)
        {
            list.Items.Clear();

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if((dir.Attributes.HasFlag(FileAttributes.Hidden) | dir.Attributes.HasFlag(FileAttributes.System)) == showHiddenAndSystem)
                {
                    ListViewItem lvi = new ListViewItem();
                    ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
                    lvi.Text = dir.Name;
                    lvi.ForeColor = dir.Attributes.HasFlag(FileAttributes.Hidden) ? SystemColors.ControlDark : SystemColors.WindowText;
                    lvi.ImageIndex = dir.Attributes.HasFlag(FileAttributes.System) ? 1 : 0;
                    size.Text = "<папка>";
                    lvi.SubItems.Add(size);
                    list.Items.Add(lvi);
                }
            }
        }

        private void ShowFiles(ListView list, string path, DriveInfo driveInfo, bool showHiddenAndSystem)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
           
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if ((file.Attributes.HasFlag(FileAttributes.Hidden) | file.Attributes.HasFlag(FileAttributes.System)) == showHiddenAndSystem)
                {
                    ListViewItem lvi = new ListViewItem();
                    ListViewItem.ListViewSubItem type = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
                    lvi.Text = Path.GetFileNameWithoutExtension(file.Name);
                    lvi.ForeColor = file.Attributes.HasFlag(FileAttributes.Hidden) ? SystemColors.ControlDark : SystemColors.WindowText;
                    lvi.ImageIndex = file.Attributes.HasFlag(FileAttributes.System) ? 3 : 2;
                    type.Text = file.Extension;
                    size.Text = GetMegabyteToString(file.Length) + " Mб";
                    lvi.SubItems.Add(type);
                    lvi.SubItems.Add(size);
                    list.Items.Add(lvi);
                }
            }
        }
        private string GetMegabyteToString(long bytes)
        {
            return string.Format("{0:N0}", bytes / 1024 / 1024);
        }

        private void listLeft_DoubleClick(object sender, EventArgs e)
        {

        }

        private void toolDetails_Click(object sender, EventArgs e)
        {
            ChangeListView(View.Details);
        }

        private void toolList_Click(object sender, EventArgs e)
        {
            ChangeListView(View.List);
        }

        private void toolSmall_Click(object sender, EventArgs e)
        {
            ChangeListView(View.SmallIcon);
        }

        private void toolLarge_Click(object sender, EventArgs e)
        {
            ChangeListView(View.LargeIcon);
        }

        private void ChangeListView(View view)
        {
            if (listLeft.SelectedItems.Count > 0)
            {
                listLeft.View = view;
            }
            else if (listRight.SelectedItems.Count > 0)
            {
                listRight.View = view;
            }
        }

        private void toolViewHiddenFiles_Click(object sender, EventArgs e)
        {

        }
    }
}
