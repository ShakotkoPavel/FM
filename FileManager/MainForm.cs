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
        public bool leftStatusShowHidden = false;   //отображаються или нет скрытые файлы
        public bool rightStatusShowHidden = false;

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
            labelPathLeft.Text = driveInfo.RootDirectory.FullName;

            ShowInformation(driveLeft, driveInfo, infoDriveLeft, leftList, labelPathLeft.Text, labelPathLeft, leftStatusShowHidden);
        }

        private void driveRight_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo driveInfo = (DriveInfo)arrayDrivesInfo.GetValue(((ComboBox)sender).SelectedIndex);
            labelPathRight.Text = driveInfo.RootDirectory.FullName;

            ShowInformation(driveRight, driveInfo, infoDriveRight, rightList, labelPathRight.Text, labelPathRight, rightStatusShowHidden);
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
                list.Items.Clear();
                if(path != Directory.GetDirectoryRoot(path)) //добавляем root-овую директорию если это не самый корень
                {
                    addRootDirectory(list);
                }
                pathLabel.Text = path;
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
            if (leftList.Focused)
            {
                leftList.View = view;
            }
            else if (rightList.Focused)
            {
                rightList.View = view;
            }
        }

        private void addRootDirectory(ListView list)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
            lvi.Text = "..";
            lvi.ImageIndex = 4;
            size.Text = "<папка>";
            lvi.SubItems.Add(size);
            list.Items.Add(lvi);
        }

        //Click`s
        private void listLeft_DoubleClick(object sender, EventArgs e)
        {
            if(((ListView)sender).FocusedItem.Text == "..")
            {
                ShowFoldersAndFiles(leftList, Directory.GetParent(labelPathLeft.Text).FullName, leftStatusShowHidden, labelPathLeft);
            }
            else if (Directory.Exists(Path.Combine(labelPathLeft.Text, ((ListView)sender).FocusedItem.Text)))
            {
                ShowFoldersAndFiles(leftList, Path.Combine(labelPathLeft.Text, ((ListView)sender).FocusedItem.Text), leftStatusShowHidden, labelPathLeft);
            }
            else if (File.Exists(Path.Combine(labelPathLeft.Text, ((ListView)sender).FocusedItem.Text) + leftList.FocusedItem.SubItems[1].Text))
            {
                Process.Start(Path.Combine(labelPathLeft.Text, ((ListView)sender).FocusedItem.Text) + leftList.FocusedItem.SubItems[1].Text);
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
            if (leftList.Focused)
            {
                leftStatusShowHidden = !leftStatusShowHidden;
                ShowFoldersAndFiles(leftList, labelPathLeft.Text, leftStatusShowHidden, labelPathLeft);
            }
            if (rightList.Focused)
            {
                rightStatusShowHidden = !rightStatusShowHidden;
                ShowFoldersAndFiles(rightList, labelPathRight.Text, rightStatusShowHidden, labelPathRight);
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

        private void toolStripRAR_Click(object sender, EventArgs e)
        {
            bool isCompressed = File.GetAttributes(Path.Combine(labelPathLeft.Text, leftList.FocusedItem.Text) + leftList.FocusedItem.SubItems[1].Text).HasFlag(FileAttributes.Compressed);

            if (isCompressed)
            {

            } 
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            if(labelPathLeft.Text != String.Empty)
            {
                ShowFoldersAndFiles(leftList, labelPathLeft.Text, leftStatusShowHidden, labelPathLeft);
            }
            if (labelPathRight.Text != String.Empty)
            {
                ShowFoldersAndFiles(rightList, labelPathRight.Text, rightStatusShowHidden, labelPathRight);
            }
        }

        private void rightList_DoubleClick(object sender, EventArgs e)
        {
            if (((ListView)sender).FocusedItem.Text == "..")
            {
                ShowFoldersAndFiles(rightList, Directory.GetParent(labelPathRight.Text).FullName, rightStatusShowHidden, labelPathRight);
            }
            else if (Directory.Exists(Path.Combine(labelPathRight.Text, ((ListView)sender).FocusedItem.Text)))
            {
                ShowFoldersAndFiles(rightList, Path.Combine(labelPathRight.Text, ((ListView)sender).FocusedItem.Text), rightStatusShowHidden, labelPathRight);
            }
            else if (File.Exists(Path.Combine(labelPathRight.Text, ((ListView)sender).FocusedItem.Text) + rightList.FocusedItem.SubItems[1].Text))
            {
                Process.Start(Path.Combine(labelPathRight.Text, ((ListView)sender).FocusedItem.Text) + rightList.FocusedItem.SubItems[1].Text);
            }
        }
    }
}