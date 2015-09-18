﻿using System;

namespace App
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.splitRenderCoding = new System.Windows.Forms.SplitContainer();
            this.glControl = new OpenTK.GLControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCode = new System.Windows.Forms.TabPage();
            this.splitCodeError = new System.Windows.Forms.SplitContainer();
            this.tabCodeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.tabSource = new System.Windows.Forms.TabControl();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolBtnRun = new System.Windows.Forms.ToolStripButton();
            this.codeError = new System.Windows.Forms.RichTextBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.tabData = new System.Windows.Forms.TabControl();
            this.tabDataImg = new System.Windows.Forms.TabPage();
            this.tableLayoutImages = new System.Windows.Forms.TableLayoutPanel();
            this.comboImg = new System.Windows.Forms.ComboBox();
            this.panelImg = new System.Windows.Forms.Panel();
            this.pictureImg = new System.Windows.Forms.PictureBox();
            this.tabDataBuf = new System.Windows.Forms.TabPage();
            this.tableLayoutBufferDef = new System.Windows.Forms.TableLayoutPanel();
            this.tableBuf = new System.Windows.Forms.DataGridView();
            this.tableLayoutBuffers = new System.Windows.Forms.TableLayoutPanel();
            this.comboBuf = new System.Windows.Forms.ComboBox();
            this.comboBufType = new System.Windows.Forms.ComboBox();
            this.textBufDim = new System.Windows.Forms.TextBox();
            this.numImgLayer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitRenderCoding)).BeginInit();
            this.splitRenderCoding.Panel1.SuspendLayout();
            this.splitRenderCoding.Panel2.SuspendLayout();
            this.splitRenderCoding.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCodeError)).BeginInit();
            this.splitCodeError.Panel1.SuspendLayout();
            this.splitCodeError.Panel2.SuspendLayout();
            this.splitCodeError.SuspendLayout();
            this.tabCodeTableLayout.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabDataImg.SuspendLayout();
            this.tableLayoutImages.SuspendLayout();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImg)).BeginInit();
            this.tabDataBuf.SuspendLayout();
            this.tableLayoutBufferDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableBuf)).BeginInit();
            this.tableLayoutBuffers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImgLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitRenderCoding
            // 
            this.splitRenderCoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRenderCoding.Location = new System.Drawing.Point(0, 0);
            this.splitRenderCoding.Name = "splitRenderCoding";
            // 
            // splitRenderCoding.Panel1
            // 
            this.splitRenderCoding.Panel1.Controls.Add(this.glControl);
            // 
            // splitRenderCoding.Panel2
            // 
            this.splitRenderCoding.Panel2.Controls.Add(this.tabControl);
            this.splitRenderCoding.Size = new System.Drawing.Size(1343, 739);
            this.splitRenderCoding.SplitterDistance = 700;
            this.splitRenderCoding.TabIndex = 0;
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(700, 739);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCode);
            this.tabControl.Controls.Add(this.tabDebug);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(639, 739);
            this.tabControl.TabIndex = 1;
            // 
            // tabCode
            // 
            this.tabCode.Controls.Add(this.splitCodeError);
            this.tabCode.Location = new System.Drawing.Point(4, 24);
            this.tabCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCode.Name = "tabCode";
            this.tabCode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCode.Size = new System.Drawing.Size(631, 711);
            this.tabCode.TabIndex = 0;
            this.tabCode.Text = "Code";
            this.tabCode.UseVisualStyleBackColor = true;
            // 
            // splitCodeError
            // 
            this.splitCodeError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCodeError.Location = new System.Drawing.Point(2, 2);
            this.splitCodeError.Margin = new System.Windows.Forms.Padding(0);
            this.splitCodeError.Name = "splitCodeError";
            this.splitCodeError.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCodeError.Panel1
            // 
            this.splitCodeError.Panel1.Controls.Add(this.tabCodeTableLayout);
            this.splitCodeError.Panel1MinSize = 75;
            // 
            // splitCodeError.Panel2
            // 
            this.splitCodeError.Panel2.Controls.Add(this.codeError);
            this.splitCodeError.Panel2MinSize = 75;
            this.splitCodeError.Size = new System.Drawing.Size(627, 707);
            this.splitCodeError.SplitterDistance = 464;
            this.splitCodeError.SplitterWidth = 3;
            this.splitCodeError.TabIndex = 0;
            // 
            // tabCodeTableLayout
            // 
            this.tabCodeTableLayout.ColumnCount = 1;
            this.tabCodeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabCodeTableLayout.Controls.Add(this.toolStripContainer, 0, 0);
            this.tabCodeTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCodeTableLayout.Location = new System.Drawing.Point(0, 0);
            this.tabCodeTableLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCodeTableLayout.Name = "tabCodeTableLayout";
            this.tabCodeTableLayout.RowCount = 1;
            this.tabCodeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabCodeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tabCodeTableLayout.Size = new System.Drawing.Size(627, 464);
            this.tabCodeTableLayout.TabIndex = 1;
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.tabSource);
            this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(594, 444);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(2, 2);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolStripContainer.Name = "toolStripContainer";
            // 
            // toolStripContainer.RightToolStripPanel
            // 
            this.toolStripContainer.RightToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.Size = new System.Drawing.Size(623, 460);
            this.toolStripContainer.TabIndex = 1;
            this.toolStripContainer.Text = "toolStripContainer2";
            // 
            // tabSource
            // 
            this.tabSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSource.Location = new System.Drawing.Point(0, 0);
            this.tabSource.Margin = new System.Windows.Forms.Padding(0);
            this.tabSource.Name = "tabSource";
            this.tabSource.SelectedIndex = 0;
            this.tabSource.Size = new System.Drawing.Size(594, 444);
            this.tabSource.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnClose,
            this.toolBtnNew,
            this.toolBtnOpen,
            this.toolBtnSave,
            this.toolBtnSaveAll,
            this.toolBtnSaveAs,
            this.toolBtnRun});
            this.toolStrip.Location = new System.Drawing.Point(0, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(29, 204);
            this.toolStrip.TabIndex = 0;
            // 
            // toolBtnClose
            // 
            this.toolBtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnClose.Image = global::App.Properties.Resources.ImgClose;
            this.toolBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnClose.Name = "toolBtnClose";
            this.toolBtnClose.Size = new System.Drawing.Size(27, 28);
            this.toolBtnClose.Text = "Close Tab";
            this.toolBtnClose.Click += new System.EventHandler(this.toolBtnClose_Click);
            // 
            // toolBtnNew
            // 
            this.toolBtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnNew.Image = global::App.Properties.Resources.ImgNew;
            this.toolBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnNew.Name = "toolBtnNew";
            this.toolBtnNew.Size = new System.Drawing.Size(27, 28);
            this.toolBtnNew.Text = "New";
            this.toolBtnNew.Click += new System.EventHandler(this.toolBtnNew_Click);
            // 
            // toolBtnOpen
            // 
            this.toolBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnOpen.Image = global::App.Properties.Resources.ImgOpen;
            this.toolBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnOpen.Name = "toolBtnOpen";
            this.toolBtnOpen.Size = new System.Drawing.Size(27, 28);
            this.toolBtnOpen.Text = "Open (Ctrl + O)";
            this.toolBtnOpen.Click += new System.EventHandler(this.toolBtnOpen_Click);
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(27, 4);
            this.toolBtnSave.Text = "Save (Ctrl + S)";
            this.toolBtnSave.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // toolBtnSaveAll
            // 
            this.toolBtnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSaveAll.Image = global::App.Properties.Resources.ImgSaveAll;
            this.toolBtnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSaveAll.Name = "toolBtnSaveAll";
            this.toolBtnSaveAll.Size = new System.Drawing.Size(27, 28);
            this.toolBtnSaveAll.Text = "Save all (Ctrl + Shift + S)";
            this.toolBtnSaveAll.Click += new System.EventHandler(this.toolBtnSaveAll_Click);
            // 
            // toolBtnSaveAs
            // 
            this.toolBtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSaveAs.Image = global::App.Properties.Resources.ImgSaveAs;
            this.toolBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSaveAs.Name = "toolBtnSaveAs";
            this.toolBtnSaveAs.Size = new System.Drawing.Size(27, 28);
            this.toolBtnSaveAs.Text = "Save as (Alt + S)";
            this.toolBtnSaveAs.Click += new System.EventHandler(this.toolBtnSaveAs_Click);
            // 
            // toolBtnRun
            // 
            this.toolBtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnRun.Image = global::App.Properties.Resources.ImgRun;
            this.toolBtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRun.Name = "toolBtnRun";
            this.toolBtnRun.Size = new System.Drawing.Size(27, 28);
            this.toolBtnRun.Text = "Run (F5)";
            this.toolBtnRun.Click += new System.EventHandler(this.toolBtnRun_Click);
            // 
            // codeError
            // 
            this.codeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeError.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeError.ForeColor = System.Drawing.SystemColors.WindowText;
            this.codeError.Location = new System.Drawing.Point(0, 0);
            this.codeError.Margin = new System.Windows.Forms.Padding(0);
            this.codeError.Name = "codeError";
            this.codeError.Size = new System.Drawing.Size(627, 240);
            this.codeError.TabIndex = 0;
            this.codeError.Text = "";
            this.codeError.WordWrap = false;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.tabData);
            this.tabDebug.Location = new System.Drawing.Point(4, 24);
            this.tabDebug.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDebug.Size = new System.Drawing.Size(631, 711);
            this.tabDebug.TabIndex = 1;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.tabDataImg);
            this.tabData.Controls.Add(this.tabDataBuf);
            this.tabData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabData.Location = new System.Drawing.Point(2, 2);
            this.tabData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabData.Name = "tabData";
            this.tabData.SelectedIndex = 0;
            this.tabData.Size = new System.Drawing.Size(627, 707);
            this.tabData.TabIndex = 0;
            // 
            // tabDataImg
            // 
            this.tabDataImg.Controls.Add(this.tableLayoutImages);
            this.tabDataImg.Location = new System.Drawing.Point(4, 24);
            this.tabDataImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDataImg.Name = "tabDataImg";
            this.tabDataImg.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDataImg.Size = new System.Drawing.Size(619, 679);
            this.tabDataImg.TabIndex = 0;
            this.tabDataImg.Text = "Images";
            this.tabDataImg.UseVisualStyleBackColor = true;
            // 
            // tableLayoutImages
            // 
            this.tableLayoutImages.ColumnCount = 2;
            this.tableLayoutImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutImages.Controls.Add(this.comboImg, 0, 0);
            this.tableLayoutImages.Controls.Add(this.panelImg, 0, 1);
            this.tableLayoutImages.Controls.Add(this.numImgLayer, 1, 0);
            this.tableLayoutImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutImages.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutImages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutImages.Name = "tableLayoutImages";
            this.tableLayoutImages.RowCount = 2;
            this.tableLayoutImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutImages.Size = new System.Drawing.Size(615, 675);
            this.tableLayoutImages.TabIndex = 0;
            // 
            // comboImg
            // 
            this.comboImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboImg.FormattingEnabled = true;
            this.comboImg.Location = new System.Drawing.Point(2, 2);
            this.comboImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboImg.Name = "comboImg";
            this.comboImg.Size = new System.Drawing.Size(511, 23);
            this.comboImg.TabIndex = 1;
            this.comboImg.SelectedIndexChanged += new System.EventHandler(this.comboImg_SelectedIndexChanged);
            // 
            // panelImg
            // 
            this.panelImg.AutoScroll = true;
            this.tableLayoutImages.SetColumnSpan(this.panelImg, 2);
            this.panelImg.Controls.Add(this.pictureImg);
            this.panelImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImg.Location = new System.Drawing.Point(2, 28);
            this.panelImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(611, 645);
            this.panelImg.TabIndex = 2;
            // 
            // pictureImg
            // 
            this.pictureImg.Location = new System.Drawing.Point(0, 0);
            this.pictureImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureImg.Name = "pictureImg";
            this.pictureImg.Size = new System.Drawing.Size(410, 353);
            this.pictureImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureImg.TabIndex = 0;
            this.pictureImg.TabStop = false;
            this.pictureImg.Click += new System.EventHandler(this.pictureImg_Click);
            // 
            // tabDataBuf
            // 
            this.tabDataBuf.Controls.Add(this.tableLayoutBufferDef);
            this.tabDataBuf.Location = new System.Drawing.Point(4, 24);
            this.tabDataBuf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDataBuf.Name = "tabDataBuf";
            this.tabDataBuf.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDataBuf.Size = new System.Drawing.Size(619, 679);
            this.tabDataBuf.TabIndex = 1;
            this.tabDataBuf.Text = "Buffers";
            this.tabDataBuf.UseVisualStyleBackColor = true;
            // 
            // tableLayoutBufferDef
            // 
            this.tableLayoutBufferDef.ColumnCount = 1;
            this.tableLayoutBufferDef.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBufferDef.Controls.Add(this.tableBuf, 0, 1);
            this.tableLayoutBufferDef.Controls.Add(this.tableLayoutBuffers, 0, 0);
            this.tableLayoutBufferDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBufferDef.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutBufferDef.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutBufferDef.Name = "tableLayoutBufferDef";
            this.tableLayoutBufferDef.RowCount = 2;
            this.tableLayoutBufferDef.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutBufferDef.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBufferDef.Size = new System.Drawing.Size(615, 675);
            this.tableLayoutBufferDef.TabIndex = 0;
            // 
            // tableBuf
            // 
            this.tableBuf.AllowUserToAddRows = false;
            this.tableBuf.AllowUserToDeleteRows = false;
            this.tableBuf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableBuf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBuf.Location = new System.Drawing.Point(2, 28);
            this.tableBuf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableBuf.Name = "tableBuf";
            this.tableBuf.ReadOnly = true;
            this.tableBuf.RowTemplate.Height = 28;
            this.tableBuf.Size = new System.Drawing.Size(611, 662);
            this.tableBuf.TabIndex = 1;
            // 
            // tableLayoutBuffers
            // 
            this.tableLayoutBuffers.ColumnCount = 3;
            this.tableLayoutBuffers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutBuffers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutBuffers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutBuffers.Controls.Add(this.comboBuf, 0, 0);
            this.tableLayoutBuffers.Controls.Add(this.comboBufType, 1, 0);
            this.tableLayoutBuffers.Controls.Add(this.textBufDim, 2, 0);
            this.tableLayoutBuffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBuffers.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBuffers.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBuffers.Name = "tableLayoutBuffers";
            this.tableLayoutBuffers.RowCount = 1;
            this.tableLayoutBuffers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBuffers.Size = new System.Drawing.Size(615, 26);
            this.tableLayoutBuffers.TabIndex = 2;
            // 
            // comboBuf
            // 
            this.comboBuf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBuf.FormattingEnabled = true;
            this.comboBuf.Location = new System.Drawing.Point(2, 2);
            this.comboBuf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBuf.Name = "comboBuf";
            this.comboBuf.Size = new System.Drawing.Size(365, 23);
            this.comboBuf.TabIndex = 0;
            this.comboBuf.SelectedIndexChanged += new System.EventHandler(this.comboBuf_SelectedIndexChanged);
            // 
            // comboBufType
            // 
            this.comboBufType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBufType.FormattingEnabled = true;
            this.comboBufType.Items.AddRange(new object[] {
            "byte",
            "short",
            "ushort",
            "int",
            "uint",
            "long",
            "ulong",
            "float",
            "double"});
            this.comboBufType.Location = new System.Drawing.Point(371, 2);
            this.comboBufType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBufType.Name = "comboBufType";
            this.comboBufType.Size = new System.Drawing.Size(119, 23);
            this.comboBufType.TabIndex = 1;
            this.comboBufType.SelectedIndexChanged += new System.EventHandler(this.comboBufType_SelectedIndexChanged);
            // 
            // textBufDim
            // 
            this.textBufDim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBufDim.Location = new System.Drawing.Point(494, 2);
            this.textBufDim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBufDim.Name = "textBufDim";
            this.textBufDim.Size = new System.Drawing.Size(119, 21);
            this.textBufDim.TabIndex = 2;
            this.textBufDim.Text = "4";
            this.textBufDim.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBufDim_KeyUp);
            // 
            // numImgLayer
            // 
            this.numImgLayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numImgLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numImgLayer.Location = new System.Drawing.Point(517, 3);
            this.numImgLayer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numImgLayer.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numImgLayer.Name = "numImgLayer";
            this.numImgLayer.Size = new System.Drawing.Size(96, 21);
            this.numImgLayer.TabIndex = 3;
            this.numImgLayer.ValueChanged += new System.EventHandler(this.numImgLayer_ValueChanged);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 739);
            this.Controls.Add(this.splitRenderCoding);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProtoGL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.App_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.App_KeyUp);
            this.splitRenderCoding.Panel1.ResumeLayout(false);
            this.splitRenderCoding.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRenderCoding)).EndInit();
            this.splitRenderCoding.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabCode.ResumeLayout(false);
            this.splitCodeError.Panel1.ResumeLayout(false);
            this.splitCodeError.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCodeError)).EndInit();
            this.splitCodeError.ResumeLayout(false);
            this.tabCodeTableLayout.ResumeLayout(false);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.RightToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabDataImg.ResumeLayout(false);
            this.tableLayoutImages.ResumeLayout(false);
            this.panelImg.ResumeLayout(false);
            this.panelImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImg)).EndInit();
            this.tabDataBuf.ResumeLayout(false);
            this.tableLayoutBufferDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableBuf)).EndInit();
            this.tableLayoutBuffers.ResumeLayout(false);
            this.tableLayoutBuffers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImgLayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitRenderCoding;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCode;
        private System.Windows.Forms.SplitContainer splitCodeError;
        private System.Windows.Forms.RichTextBox codeError;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.TabControl tabData;
        private System.Windows.Forms.TabPage tabDataImg;
        private System.Windows.Forms.TabPage tabDataBuf;
        private System.Windows.Forms.TableLayoutPanel tableLayoutImages;
        private System.Windows.Forms.PictureBox pictureImg;
        private System.Windows.Forms.ComboBox comboImg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBufferDef;
        private System.Windows.Forms.ComboBox comboBuf;
        private System.Windows.Forms.DataGridView tableBuf;
        private System.Windows.Forms.TableLayoutPanel tabCodeTableLayout;
        private System.Windows.Forms.Panel panelImg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBuffers;
        private System.Windows.Forms.ComboBox comboBufType;
        private System.Windows.Forms.TextBox textBufDim;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.TabControl tabSource;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnOpen;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripButton toolBtnSaveAll;
        private System.Windows.Forms.ToolStripButton toolBtnRun;
        private System.Windows.Forms.ToolStripButton toolBtnNew;
        private System.Windows.Forms.ToolStripButton toolBtnSaveAs;
        private System.Windows.Forms.ToolStripButton toolBtnClose;
        private System.Windows.Forms.NumericUpDown numImgLayer;
    }
}