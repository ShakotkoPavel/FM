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
        public string leftPath;
        public string rightPath;
        public bool statusShowHiddenLeft = false;   //отображаються или нет скрытые файлы
        public bool statusShowHiddenRight = false;

        public MainForm()
        {
            InitializeComponent();
            arrayDrivesInfo = DriveInfo.GetDrives();
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
            ShowInformation(driveLeft, driveInfo, infoDriveLeft, listLeft, leftPath, labelPathLeft, statusShowHiddenLeft);
        }

        private void driveRight_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo driveInfo = (DriveInfo)arrayDrivesInfo.GetValue(((ComboBox)sender).SelectedIndex);
            rightPath = driveInfo.RootDirectory.FullName;
            labelPathRight.Text = rightPath;

            ShowInformation(driveRight, driveInfo, infoDriveRight, listRight, rightPath, labelPathRight, statusShowHiddenRight);
        }

        private void ShowInformation(ComboBox cbDrive, DriveInfo driveInfo, Label infoDrive, ListView list, string path, Label pathLabel, bool showHidden)
        {
            if (driveInfo.IsReady)
            {
                ShowInfoOfSpace(infoDrive, driveInfo);
                ShowFoldersAndFiles(list, path, showHidden, pathLabel);
            }
            else
            {
                list.Items.Clear();
                infoDrive.Text = String.Empty;
                pathLabel.Text = String.Empty;
                cbDrive.SelectedIndex = -1;
                MessageBox.Show("Устройство не готово! \nВыберите другое устройство", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInfoOfSpace(Label label, DriveInfo driveInfo)
        {
            string volumeLabel = driveInfo.VolumeLabel != String.Empty ? $"[{driveInfo.VolumeLabel}]" : "[_нет_]";
            label.Text = volumeLabel + $"\t свободно " + GetKbytesToString(driveInfo.TotalFreeSpace)
                                                    + " Kб из " + GetKbytesToString(driveInfo.TotalSize) + " Kб";
        }

        private void ShowFoldersAndFiles(ListView list, string path, bool showHiddenAndSystem, Label pathLabel)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo[] directories = dirInfo.GetDirectories();
                FileInfo[] files = dirInfo.GetFiles();
                pathLabel.Text = path;
                leftPath = path;
                list.Items.Clear();
                foreach (DirectoryInfo dir in directories)
                {
                    if (showHiddenAndSystem || !(dir.Attributes.HasFlag(FileAttributes.Hidden) | dir.Attributes.HasFlag(FileAttributes.System)))
                    {
                        addFolderToList(dir, list);
                    }
                }
                foreach (FileInfo file in files)
                {
                    if (showHiddenAndSystem || !(file.Attributes.HasFlag(FileAttributes.Hidden) | file.Attributes.HasFlag(FileAttributes.System)))
                    {
                        addFileToList(file, list);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addFolderToList(DirectoryInfo dir, ListView list)
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

        private void addFileToList(FileInfo file, ListView list)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem type = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
            lvi.Text = Path.GetFileNameWithoutExtension(file.Name);
            lvi.ForeColor = file.Attributes.HasFlag(FileAttributes.Hidden) ? SystemColors.ControlDark : SystemColors.WindowText;
            lvi.ImageIndex = file.Attributes.HasFlag(FileAttributes.System) ? 3 : 2;
            type.Text = file.Extension;
            size.Text = GetKbytesToString(file.Length) + " Kб";
            lvi.SubItems.Add(type);
            lvi.SubItems.Add(size);
            list.Items.Add(lvi);
        }

        private string GetKbytesToString(long bytes)
        {
            return string.Format("{0:N0}", bytes / 1024);
        }

        private void ChangeListView(View view)
        {
            if (listLeft.Focused)
            {
                listLeft.View = view;
            }
            else if (listRight.Focused)
            {
                listRight.View = view;
            }
        }

        //Click`s
        private void listLeft_DoubleClick(object sender, EventArgs e)
        {
            if (Directory.Exists(Path.Combine(leftPath, ((ListView)sender).FocusedItem.Text)))
            {
                ShowFoldersAndFiles(listLeft, Path.Combine(leftPath, ((ListView)sender).FocusedItem.Text), statusShowHiddenLeft, labelPathLeft);
            }
            else if (File.Exists(Path.Combine(leftPath, ((ListView)sender).FocusedItem.Text) + listLeft.FocusedItem.SubItems[1].Text))
            {
                Process.Start(Path.Combine(leftPath, ((ListView)sender).FocusedItem.Text) + listLeft.FocusedItem.SubItems[1].Text);
            }
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

        private void toolViewHiddenFiles_Click(object sender, EventArgs e)
        {
            if (listLeft.Focused)
            {
                statusShowHiddenLeft = !statusShowHiddenLeft;
                ShowFoldersAndFiles(listLeft, leftPath, statusShowHiddenLeft, labelPathLeft);
            }
            if (listRight.Focused)
            {
                statusShowHiddenRight = !statusShowHiddenRight;
                ShowFoldersAndFiles(listRight, rightPath, statusShowHiddenRight, labelPathRight);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}