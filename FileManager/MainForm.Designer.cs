﻿namespace FileManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.файлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlPanel = new System.Windows.Forms.ToolStrip();
            this.toolViewHiddenFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLarge = new System.Windows.Forms.ToolStripButton();
            this.toolSmall = new System.Windows.Forms.ToolStripButton();
            this.toolList = new System.Windows.Forms.ToolStripButton();
            this.toolDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RunNoterpad = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.driveLeft = new System.Windows.Forms.ComboBox();
            this.infoDriveLeft = new System.Windows.Forms.Label();
            this.listLeft = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageFolders = new System.Windows.Forms.ImageList(this.components);
            this.labelPathLeft = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.driveRight = new System.Windows.Forms.ComboBox();
            this.infoDriveRight = new System.Windows.Forms.Label();
            this.listRight = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelPathRight = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлыToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(887, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "MainMenu";
            // 
            // файлыToolStripMenuItem
            // 
            this.файлыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripSeparator1,
            this.Exit});
            this.файлыToolStripMenuItem.Name = "файлыToolStripMenuItem";
            this.файлыToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.файлыToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.файлыToolStripMenuItem.Text = "Файлы";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.ShortcutKeyDisplayString = "";
            this.Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Exit.Size = new System.Drawing.Size(164, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ControlPanel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ControlPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolViewHiddenFiles,
            this.toolStripSeparator3,
            this.toolLarge,
            this.toolSmall,
            this.toolList,
            this.toolDetails,
            this.toolStripSeparator2,
            this.RunNoterpad});
            this.ControlPanel.Location = new System.Drawing.Point(0, 24);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ControlPanel.Size = new System.Drawing.Size(887, 25);
            this.ControlPanel.TabIndex = 5;
            this.ControlPanel.Text = "toolStrip1";
            // 
            // toolViewHiddenFiles
            // 
            this.toolViewHiddenFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolViewHiddenFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolViewHiddenFiles.Image")));
            this.toolViewHiddenFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolViewHiddenFiles.Name = "toolViewHiddenFiles";
            this.toolViewHiddenFiles.Size = new System.Drawing.Size(23, 22);
            this.toolViewHiddenFiles.Text = "Показать скрытые файлы";
            this.toolViewHiddenFiles.Click += new System.EventHandler(this.toolViewHiddenFiles_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolLarge
            // 
            this.toolLarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLarge.Image = ((System.Drawing.Image)(resources.GetObject("toolLarge.Image")));
            this.toolLarge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLarge.Name = "toolLarge";
            this.toolLarge.Size = new System.Drawing.Size(23, 22);
            this.toolLarge.Text = "Крупные значки";
            this.toolLarge.Click += new System.EventHandler(this.toolLarge_Click);
            // 
            // toolSmall
            // 
            this.toolSmall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSmall.Image = ((System.Drawing.Image)(resources.GetObject("toolSmall.Image")));
            this.toolSmall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSmall.Name = "toolSmall";
            this.toolSmall.Size = new System.Drawing.Size(23, 22);
            this.toolSmall.Text = "Мелкие значки";
            this.toolSmall.Click += new System.EventHandler(this.toolSmall_Click);
            // 
            // toolList
            // 
            this.toolList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolList.Image = ((System.Drawing.Image)(resources.GetObject("toolList.Image")));
            this.toolList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolList.Name = "toolList";
            this.toolList.Size = new System.Drawing.Size(23, 22);
            this.toolList.Text = "Список";
            this.toolList.Click += new System.EventHandler(this.toolList_Click);
            // 
            // toolDetails
            // 
            this.toolDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDetails.Image = ((System.Drawing.Image)(resources.GetObject("toolDetails.Image")));
            this.toolDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDetails.Name = "toolDetails";
            this.toolDetails.Size = new System.Drawing.Size(23, 22);
            this.toolDetails.Text = "Подробно";
            this.toolDetails.Click += new System.EventHandler(this.toolDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // RunNoterpad
            // 
            this.RunNoterpad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunNoterpad.Image = global::FileFoxManager.Properties.Resources.edit_1783;
            this.RunNoterpad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunNoterpad.Name = "RunNoterpad";
            this.RunNoterpad.Size = new System.Drawing.Size(23, 22);
            this.RunNoterpad.Text = "Запустить Блокнот";
            this.RunNoterpad.Click += new System.EventHandler(this.toolStripNoterpad_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(887, 512);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listLeft, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelPathLeft, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(442, 512);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.driveLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.infoDriveLeft, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // driveLeft
            // 
            this.driveLeft.FormattingEnabled = true;
            this.driveLeft.Location = new System.Drawing.Point(3, 3);
            this.driveLeft.Name = "driveLeft";
            this.driveLeft.Size = new System.Drawing.Size(49, 21);
            this.driveLeft.TabIndex = 0;
            this.driveLeft.SelectionChangeCommitted += new System.EventHandler(this.driveLeft_SelectionChangeCommitted);
            // 
            // infoDriveLeft
            // 
            this.infoDriveLeft.AutoSize = true;
            this.infoDriveLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoDriveLeft.Location = new System.Drawing.Point(63, 0);
            this.infoDriveLeft.Name = "infoDriveLeft";
            this.infoDriveLeft.Size = new System.Drawing.Size(370, 27);
            this.infoDriveLeft.TabIndex = 1;
            this.infoDriveLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listLeft
            // 
            this.listLeft.AllowColumnReorder = true;
            this.listLeft.AllowDrop = true;
            this.listLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.Type,
            this.Size});
            this.listLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLeft.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listLeft.FullRowSelect = true;
            this.listLeft.GridLines = true;
            this.listLeft.Location = new System.Drawing.Point(3, 56);
            this.listLeft.Name = "listLeft";
            this.listLeft.ShowItemToolTips = true;
            this.listLeft.Size = new System.Drawing.Size(436, 430);
            this.listLeft.SmallImageList = this.imageFolders;
            this.listLeft.TabIndex = 1;
            this.listLeft.UseCompatibleStateImageBehavior = false;
            this.listLeft.View = System.Windows.Forms.View.Details;
            this.listLeft.DoubleClick += new System.EventHandler(this.listLeft_DoubleClick);
            // 
            // FileName
            // 
            this.FileName.Text = "Имя";
            this.FileName.Width = 230;
            // 
            // Type
            // 
            this.Type.Text = "Тип";
            // 
            // Size
            // 
            this.Size.Text = "Размер";
            this.Size.Width = 142;
            // 
            // imageFolders
            // 
            this.imageFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageFolders.ImageStream")));
            this.imageFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageFolders.Images.SetKeyName(0, "folder_2579.png");
            this.imageFolders.Images.SetKeyName(1, "folder_locked_1187.png");
            this.imageFolders.Images.SetKeyName(2, "unknown_3264.png");
            this.imageFolders.Images.SetKeyName(3, "file_locked_1916.png");
            // 
            // labelPathLeft
            // 
            this.labelPathLeft.AutoSize = true;
            this.labelPathLeft.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelPathLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPathLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPathLeft.Location = new System.Drawing.Point(3, 33);
            this.labelPathLeft.Name = "labelPathLeft";
            this.labelPathLeft.Size = new System.Drawing.Size(436, 20);
            this.labelPathLeft.TabIndex = 2;
            this.labelPathLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listRight, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelPathRight, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(444, 512);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.driveRight, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.infoDriveRight, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(438, 27);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // driveRight
            // 
            this.driveRight.FormattingEnabled = true;
            this.driveRight.Location = new System.Drawing.Point(3, 3);
            this.driveRight.Name = "driveRight";
            this.driveRight.Size = new System.Drawing.Size(49, 21);
            this.driveRight.TabIndex = 0;
            this.driveRight.SelectionChangeCommitted += new System.EventHandler(this.driveRight_SelectionChangeCommitted);
            // 
            // infoDriveRight
            // 
            this.infoDriveRight.AutoSize = true;
            this.infoDriveRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoDriveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoDriveRight.Location = new System.Drawing.Point(63, 0);
            this.infoDriveRight.Name = "infoDriveRight";
            this.infoDriveRight.Size = new System.Drawing.Size(372, 27);
            this.infoDriveRight.TabIndex = 1;
            this.infoDriveRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listRight
            // 
            this.listRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listRight.FullRowSelect = true;
            this.listRight.GridLines = true;
            this.listRight.Location = new System.Drawing.Point(3, 56);
            this.listRight.Name = "listRight";
            this.listRight.Size = new System.Drawing.Size(438, 430);
            this.listRight.SmallImageList = this.imageFolders;
            this.listRight.TabIndex = 2;
            this.listRight.UseCompatibleStateImageBehavior = false;
            this.listRight.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Размер";
            this.columnHeader3.Width = 142;
            // 
            // labelPathRight
            // 
            this.labelPathRight.AutoSize = true;
            this.labelPathRight.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelPathRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPathRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPathRight.Location = new System.Drawing.Point(3, 33);
            this.labelPathRight.Name = "labelPathRight";
            this.labelPathRight.Size = new System.Drawing.Size(438, 20);
            this.labelPathRight.TabIndex = 3;
            this.labelPathRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(887, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "FileFox Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem файлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStrip ControlPanel;
        private System.Windows.Forms.ToolStripButton RunNoterpad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox driveLeft;
        private System.Windows.Forms.Label infoDriveLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox driveRight;
        private System.Windows.Forms.Label infoDriveRight;
        private System.Windows.Forms.ImageList imageFolders;
        private System.Windows.Forms.ToolStripButton toolDetails;
        private System.Windows.Forms.ToolStripButton toolList;
        private System.Windows.Forms.ListView listRight;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripButton toolLarge;
        private System.Windows.Forms.ToolStripButton toolSmall;
        private System.Windows.Forms.ToolStripButton toolViewHiddenFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label labelPathLeft;
        private System.Windows.Forms.Label labelPathRight;
        private System.Windows.Forms.ListView listLeft;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Size;
    }
}

