using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualBasic;
//using ICSharpCode.SharpZipLib.Zip;

namespace FileFoxManager
{
    public partial class MainForm : Form
    {
        DriveInfo[] ArrayDrivesInfo { get; set; }
        bool LeftStatusShowHidden { get; set; } = false; //отображаються или нет скрытые файлы
        bool RightStatusShowHidden { get; set; } = false;
        ItemComparer LeftItemComparer { get; set; } //сортировка столбцов
        ItemComparer RightItemComparer { get; set; }

        public MainForm()
        {
            InitializeComponent();
            ArrayDrivesInfo = DriveInfo.GetDrives();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LeftItemComparer = new ItemComparer();
            leftList.ListViewItemSorter = LeftItemComparer;

            RightItemComparer = new ItemComparer();
            rightList.ListViewItemSorter = RightItemComparer;

            Text = $"{Environment.UserName} - {Text}";
            foreach (DriveInfo drive in ArrayDrivesInfo)
            {
                driveLeft.Items.Add($"[{drive.Name}]");
                driveRight.Items.Add($"[{drive.Name}]");
                if (drive.IsReady)
                {
                    if (driveLeft.SelectedItem == null)
                    {
                        driveLeft.SelectedItem = $"[{drive.Name}]";
                        ShowInformation(driveLeft, drive, infoDriveLeft, leftList, drive.Name, labelPathLeft, LeftStatusShowHidden);
                    }
                    if (driveRight.SelectedItem == null)
                    {
                        driveRight.SelectedItem = $"[{drive.Name}]";
                        ShowInformation(driveRight, drive, infoDriveRight, rightList, drive.Name, labelPathRight, RightStatusShowHidden);
                    }
                }
            }
        }

        private void DriveLeft_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo driveInfo = (DriveInfo)ArrayDrivesInfo.GetValue(((ComboBox)sender).SelectedIndex);
            labelPathLeft.Text = driveInfo.RootDirectory.FullName;

            ShowInformation(driveLeft, driveInfo, infoDriveLeft, leftList, labelPathLeft.Text, labelPathLeft, LeftStatusShowHidden);
        }

        private void DriveRight_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DriveInfo driveInfo = (DriveInfo)ArrayDrivesInfo.GetValue(((ComboBox)sender).SelectedIndex);
            labelPathRight.Text = driveInfo.RootDirectory.FullName;

            ShowInformation(driveRight, driveInfo, infoDriveRight, rightList, labelPathRight.Text, labelPathRight, RightStatusShowHidden);
        }

        //+++ Common methods
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
                if (path != Directory.GetDirectoryRoot(path)) //добавляем root-овую директорию если это не самый корень
                {
                    AddRootDirectory(list);
                }
                pathLabel.Text = path;
                foreach (DirectoryInfo dir in directories)
                {
                    if (showHiddenAndSystem || !(dir.Attributes.HasFlag(FileAttributes.Hidden) | dir.Attributes.HasFlag(FileAttributes.System)))
                    {
                        AddFolderToList(dir, list);
                    }
                }
                foreach (FileInfo file in files)
                {
                    if (showHiddenAndSystem || !(file.Attributes.HasFlag(FileAttributes.Hidden) | file.Attributes.HasFlag(FileAttributes.System)))
                    {
                        AddFileToList(file, list);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddFolderToList(DirectoryInfo dir, ListView list)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem type = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
            lvi.Text = $"[{dir.Name}]";
            lvi.ForeColor = dir.Attributes.HasFlag(FileAttributes.Hidden) ? SystemColors.ControlDark : SystemColors.WindowText;
            lvi.ImageIndex = dir.Attributes.HasFlag(FileAttributes.System) ? 1 : 0;
            type.Text = "";
            size.Text = "<папка>";
            lvi.SubItems.Add(type);
            lvi.SubItems.Add(size);
            list.Items.Add(lvi);
        }

        private void AddFileToList(FileInfo file, ListView list)
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

        private void AddRootDirectory(ListView list)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem type = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
            lvi.Text = "[..]";
            lvi.ImageIndex = 4;
            size.Text = "";
            type.Text = "";
            lvi.SubItems.Add(type);
            lvi.SubItems.Add(size);
            list.Items.Add(lvi);
        }

        private void OpenFolderOrFile(ListView list, string path, string extension, Label label, bool showHidden)
        {
            if (path == "..")
            {
                ShowFoldersAndFiles(list, Directory.GetParent(label.Text).FullName, showHidden, label);
            }
            else if (Directory.Exists(Path.Combine(label.Text, path)))
            {
                ShowFoldersAndFiles(list, Path.Combine(label.Text, path), showHidden, label);
            }
            else if (File.Exists(Path.Combine(label.Text, path) + extension))
            {
                try
                {
                    Process.Start(Path.Combine(label.Text, path) + extension);
                }
                catch (Win32Exception e)
                {
                    //ничего не делаем, просто перехватываем ex, чтобы не падало приложение
                }
            }
        }

        private void ZipUnZip(bool Zip)
        {
            string commonPath = "",
                   nameFolderOrFile = "",
                   extension = "";
            List<string> listPaths = new List<string>();
            ListView list = null;

            if (leftList.Focused)
            {
                list = leftList;
                commonPath = labelPathLeft.Text;
            }
            else if (rightList.Focused)
            {
                list = rightList;
                commonPath = labelPathRight.Text;
            }
            if (list != null && commonPath != String.Empty)
                foreach (ListViewItem item in list.SelectedItems)
                {
                    nameFolderOrFile = item.Text.Trim(new char[] { '[', ']' });
                    extension = item.SubItems[1].Text;
                    if (nameFolderOrFile != "..")
                    {
                        listPaths.Add(Path.Combine(commonPath, nameFolderOrFile + extension));
                    }
                }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
                Description = "Выберите каталог",
                ShowNewFolderButton = true
            };
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (string path in listPaths)
                {
                    if (Zip)
                    {
                        string nameZip = Interaction.InputBox("Введите имя архива", "Ввод имени архива");
                        if(nameZip != String.Empty)
                        {
                            ZipFile.CreateFromDirectory(commonPath, DeleteInvalidCharInFileName(nameZip), CompressionLevel.Fastest, false, Encoding.GetEncoding(866));
                        }
                    }
                    else
                    {
                        using (ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Read, Encoding.GetEncoding(866)))
                        {

                            foreach (ZipArchiveEntry zipEntry in zip.Entries)
                            {
                                zipEntry.ExtractToFile(Path.Combine(folderBrowserDialog.SelectedPath, zipEntry.FullName), true);
                            }
                        }
                    }
                }
            }
        }

        private string DeleteInvalidCharInFileName(string fileName)
        {
            char[] invalidFileChars = Path.GetInvalidFileNameChars();
            foreach (char ch in invalidFileChars)
            {
                fileName = fileName.Replace(ch, ' ');
            }
            return fileName;
        }
        //---

        //+++ Click`s
        private void ListLeft_DoubleClick(object sender, EventArgs e)
        {
            string pathToFolderOrFile = ((ListView)sender).FocusedItem.Text.Trim(new char[] { '[', ']' });
            string extensionFile = ((ListView)sender).FocusedItem.SubItems[1].Text;

            OpenFolderOrFile(leftList, pathToFolderOrFile, extensionFile, labelPathLeft, LeftStatusShowHidden);
        }

        private void RightList_DoubleClick(object sender, EventArgs e)
        {
            string pathToFolderOrFile = ((ListView)sender).FocusedItem.Text.Trim(new char[] { '[', ']' });
            string extensionFile = ((ListView)sender).FocusedItem.SubItems[1].Text;

            OpenFolderOrFile(rightList, pathToFolderOrFile, extensionFile, labelPathRight, RightStatusShowHidden);
        }

        private void ToolDetails_Click(object sender, EventArgs e)
        {
            ChangeListView(View.Details);
        }

        private void ToolList_Click(object sender, EventArgs e)
        {
            ChangeListView(View.List);
        }

        private void ToolSmall_Click(object sender, EventArgs e)
        {
            ChangeListView(View.SmallIcon);
        }

        private void ToolLarge_Click(object sender, EventArgs e)
        {
            ChangeListView(View.LargeIcon);
        }

        private void ToolViewHiddenFiles_Click(object sender, EventArgs e)
        {
            if (leftList.Focused)
            {
                LeftStatusShowHidden = !LeftStatusShowHidden;
                ShowFoldersAndFiles(leftList, labelPathLeft.Text, LeftStatusShowHidden, labelPathLeft);
            }
            if (rightList.Focused)
            {
                RightStatusShowHidden = !RightStatusShowHidden;
                ShowFoldersAndFiles(rightList, labelPathRight.Text, RightStatusShowHidden, labelPathRight);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripNoterpad_Click(object sender, EventArgs e)
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

        private void ToolStripRefresh_Click(object sender, EventArgs e)
        {
            //if(labelPathLeft.Text != String.Empty)
            //{
                ShowFoldersAndFiles(leftList, labelPathLeft.Text, LeftStatusShowHidden, labelPathLeft);
            //}
            //if (labelPathRight.Text != String.Empty)
            //{
                ShowFoldersAndFiles(rightList, labelPathRight.Text, RightStatusShowHidden, labelPathRight);
            //}
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.ShowDialog();
            if(oFD.FileName != String.Empty)
            {
                Process.Start(oFD.FileName);
            }
        }

        private void LeftList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pathToFolderOrFile = ((ListView)sender).FocusedItem.Text.Trim(new char[] { '[', ']' });
                string extensionFile = ((ListView)sender).FocusedItem.SubItems[1].Text;

                OpenFolderOrFile(leftList, pathToFolderOrFile, extensionFile, labelPathLeft, LeftStatusShowHidden);
            }
        }

        private void RightList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pathToFolderOrFile = ((ListView)sender).FocusedItem.Text.Trim(new char[] { '[', ']' });
                string extensionFile = ((ListView)sender).FocusedItem.SubItems[1].Text;

                OpenFolderOrFile(rightList, pathToFolderOrFile, extensionFile, labelPathRight, RightStatusShowHidden);
            }
        }

        private void ToolStripZIP_Click(object sender, EventArgs e)
        {
            ZipUnZip(true);
        }

        private void ToolStripUnZip_Click(object sender, EventArgs e)
        {
            ZipUnZip(false);
        }

        private void LeftList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LeftItemComparer.ColumnIndex = e.Column;
            ((ListView)sender).Sort();
        }

        private void RightList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            RightItemComparer.ColumnIndex = e.Column;
            ((ListView)sender).Sort();
        }

    }
}