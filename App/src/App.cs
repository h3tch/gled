﻿using OpenTK.Graphics.OpenGL4;
using ScintillaNET;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace App
{
    public partial class App : Form
    {
        public static CultureInfo culture = new CultureInfo("en");
        public CodeEditor compiledEditor = null;

        public App()
        {
            InitializeComponent();
        }

        #region App Control
        private void App_Load(object sender, EventArgs e)
        {
            // select 'float' as the default buffer value type
            comboBufType.SelectedIndex = 8;

            // place splitters by percentage
            splitCodeError.SplitterDistance = (int)(0.7 * splitCodeError.Height);
            splitDebug.SplitterDistance = (int)(0.55 * splitDebug.Width);

            // link property viewer to debug settings
            GLDebugger.Instantiate();
            debugProperty.SelectedObject = GLDebugger.settings;
            debugProperty.CollapseAllGridItems();
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check if there are any files with changes
            foreach (TabPage tab in this.tabSource.TabPages)
            {
                if (!tab.Text.EndsWith("*"))
                    continue;
                // ask user whether he/she wants to save those files
                DialogResult answer = MessageBox.Show(
                    "Do you want to save files with changes before closing them?",
                    "Save file changes", MessageBoxButtons.YesNoCancel);
                // if so, save all files with changes
                if (answer == DialogResult.Yes)
                    toolBtnSaveAll_Click(sender, null);
                else if (answer == DialogResult.Cancel)
                    e.Cancel = true;
            }

            // delete OpenGL objects
            glControl.ClearScene();
        }

        private void App_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    // Compile and run
                    toolBtnRunDebug_Click(sender, null);
                    break;
                case Keys.F6:
                    // Compile and run
                    toolBtnRunDebug_Click(toolBtnDbg, null);
                    break;
                case Keys.S:
                    if (e.Control && e.Shift)
                        // Save all tabs
                        toolBtnSaveAll_Click(sender, null);
                    else if (e.Control)
                        // Save active tab
                        toolBtnSave_Click(sender, null);
                    else if (e.Alt)
                        // Save active tab as
                        toolBtnSaveAs_Click(sender, null);
                    break;
                case Keys.O:
                    if (e.Control)
                        // Open tech files
                        toolBtnOpen_Click(sender, null);
                    break;
            }
        }
        #endregion

        #region glControl Events
        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            // if pick tool button is checked, set
            // the fragment debug position to that pixel
            if (toolBtnPick.Checked)
            {
                GLDebugger.settings.fs_FragCoord[0] = e.X;
                GLDebugger.settings.fs_FragCoord[1] = glControl.Height - e.Y;
                debugProperty.Refresh();
                toolBtnPick.Checked = false;
                glControl.Cursor = Cursors.Default;
            }

            // on mouse up, render and debug the
            // program, because there could be changes
            DebugRender();
        }
        #endregion

        #region Tool Buttons
        private void toolBtnNew_Click(object sender, EventArgs e)
        {
            AddSourceTab(null);
            tabSource.SelectedIndex = tabSource.TabPages.Count-1;
        }

        private void toolBtnOpen_Click(object sender, EventArgs e)
        {
            // create file dialog
            var openDlg = new OpenFileDialog();
            openDlg.Filter = "Text Files (.tech)|*.tech|All Files (*.*)|*.*";
            openDlg.FilterIndex = 1;
            openDlg.Multiselect = true;

            // open file dialog
            if (openDlg.ShowDialog() != DialogResult.OK)
                return;
            
            // open tabs
            foreach (var path in openDlg.FileNames)
            {
                int i = tabSource.TabPages.IndexOf(path);
                if (i < 0)
                {
                    i = tabSource.TabPages.Count;
                    AddSourceTab(path);
                }
                tabSource.SelectedIndex = i;
            }
        }

        private void toolBtnRunDebug_Click(object sender, EventArgs e)
        {
            // if no tab page is selected nothing needs to be compiled
            var sourceTab = (TabPage)tabSource.SelectedTab;
            if (sourceTab == null)
                return;
            compiledEditor = (CodeEditor)sourceTab.Controls[0];
            
            // save code
            toolBtnSave_Click(sender, null);

            // clear scene and output
            output.Rows.Clear();
            glControl.ClearScene();

            // get include directory
            var includeDir = (sourceTab.filepath != null
                ? Path.GetDirectoryName(sourceTab.filepath)
                : Directory.GetCurrentDirectory()) + '\\';

            // get code text form tab page
            // generate debug information?
            var debugging = sender == toolBtnDbg;

            // remove comments
            var linePos = CodeEditor.GetLinePositions(compiledEditor.Text);
            var code = CodeEditor.IncludeFiles(compiledEditor.Text, includeDir, linePos);
            code = CodeEditor.RemoveComments(code);
            code = CodeEditor.RemoveNewLineIndicators(code);
            code = CodeEditor.ResolvePreprocessorDefinitions(code, linePos);

            // FIND PROTOGL CLASS BLOCKS (find "TYPE name { ... }")
            var blocks = CodeEditor.GetBlocks(code);

            // INSTANTIATE THE CLASS WITH THE SPECIFIED ARGUMENTS (collect all errors)
            var ex = blocks
                .Catch(x => glControl.AddObject(x.text, x.pos, includeDir, debugging))
                .ToArray();

            // show errors
            var exc = from x in ex
                      where x is CompileException || x.InnerException is CompileException
                      select (x is CompileException ? x : x.InnerException) as CompileException;
            var err = from x in exc from y in x select y;
            var lineIdx = err.Select(x => linePos.IndexOf(y => y >= x.Pos));
            err.Zip(lineIdx, (x, idx) => AddOutputItem(x.File, idx, x.Msg));

            // underline all debug errors
            var ranges = lineIdx.Select(x => new[] {
                compiledEditor.Lines[x].Position,
                compiledEditor.Lines[x].EndPosition
            });
            compiledEditor.ClearIndicators(CodeEditor.DebugIndicatorIndex);
            compiledEditor.AddIndicators(CodeEditor.DebugIndicatorIndex, ranges);

            // SHOW SCENE
            glControl.Render();

            // also add externally created textures to the scene
            var internID = from x in glControl.Scene
                           where x.Value is GLImage || x.Value is GLTexture
                           select x.Value.glname;
            var externID = from x in Enumerable.Range(0, 64)
                           where !internID.Contains(x) && GL.IsTexture(x)
                           select x;
            externID
                .Select(x => new GLImage(new GLParams($"GLTex{x}: {GLImage.GetLable(x)}", "tex"), x))
                .Do(x => glControl.Scene.Add(x.name, x));

            // also add externally created buffers to the scene
            internID = from x in glControl.Scene
                       where x.Value is GLBuffer
                       select x.Value.glname;
            externID = from x in Enumerable.Range(0, 64)
                       where !internID.Contains(x) && GL.IsBuffer(x)
                       select x;
            externID
                .Select(x => new GLBuffer(new GLParams($"GLBuf{x}: {GLBuffer.GetLable(x)}", "buf"), x))
                .Do(x => glControl.Scene.Add(x.name, x));

            // UPDATE DEBUG DATA
            comboBuf.Items.Clear();
            comboImg.Items.Clear();
            comboProp.Items.Clear();
            glControl.Scene.Where(x => x.Value is GLBuffer).Do(x => comboBuf.Items.Add(x.Value));
            glControl.Scene.Where(x => x.Value is GLImage).Do(x => comboImg.Items.Add(x.Value));
            glControl.Scene.Where(x => x.Value is GLInstance).Do(x => comboProp.Items.Add(x.Value));

            // UPDATE DEBUG INFORMATION IF NECESSARY
            if (debugging)
                UpdateDebugListView(compiledEditor);
        }

        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            TabPage tab = (TabPage)tabSource.SelectedTab;
            if (!tab.Text.EndsWith("*"))
                return;
            SaveTabPage(tab, false);
            tab.Text = tab.Text.Substring(0, tab.Text.Length - 1);
        }

        private void toolBtnSaveAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabSource.TabPages)
            {
                if (!tab.Text.EndsWith("*"))
                    continue;
                SaveTabPage(tab, false);
                tab.Text = tab.Text.Substring(0, tab.Text.Length - 1);
            }
        }

        private void toolBtnSaveAs_Click(object sender, EventArgs e)
            => SaveTabPage((TabPage)tabSource.SelectedTab, true);

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            if (tabSource.SelectedIndex < 0 || tabSource.SelectedIndex >= tabSource.TabPages.Count)
                return;
            TabPage tabSourcePage = (TabPage)tabSource.SelectedTab;
            if (tabSourcePage.Text.EndsWith("*"))
            {
                DialogResult answer = MessageBox.Show(
                    "Do you want to save the file before closing it?",
                    "File changed", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                    SaveTabPage(tabSourcePage, false);
            }
            tabSource.TabPages.RemoveAt(tabSource.SelectedIndex);
        }

        private void toolBtnPick_CheckedChanged(object sender, EventArgs e)
        {
            if (toolBtnPick.Checked)
                glControl.Cursor = Cursors.Cross;
            else
                glControl.Cursor = Cursors.Default;
        }
        #endregion
        
        #region UTIL
        private void SaveTabPage(TabPage tabPage, bool newfile)
        {
            var editor = (CodeEditor)tabPage.Controls[0];

            if (tabPage.filepath == null || newfile)
            {
                var saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Text Files (.tech)|*.tech|All Files (*.*)|*.*";
                saveDlg.FilterIndex = 1;

                var result = saveDlg.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                tabPage.filepath = saveDlg.FileName;
                tabPage.Text = Path.GetFileName(saveDlg.FileName);
            }

            File.WriteAllText(tabPage.filepath, editor.Text);
        }

        private void AddSourceTab(string path)
        {
            // load file
            string filename = path != null ? Path.GetFileName(path) : "unnamed.tech";
            string text = path != null ? File.ReadAllText(path) : "// Unnamed ProtoGL file";

            // create new tab objects
            var tabSourcePage = new TabPage(path);
            var editor = new CodeEditor(text);
            editor.UpdateUI += new EventHandler<UpdateUIEventArgs>(editor_UpdateUI);
            editor.MouseMove += new MouseEventHandler(editor_MouseMove);

            // tabSourcePage
            tabSourcePage.Controls.Add(editor);
            tabSourcePage.Location = new Point(4, 31);
            tabSourcePage.Margin = new Padding(0);
            tabSourcePage.Padding = new Padding(3);
            tabSourcePage.TabIndex = 0;
            tabSourcePage.Text = filename;
            tabSourcePage.AllowDrop = true;

            // add tab
            tabSource.Controls.Add(tabSourcePage);
            
        }

        private CodeEditor GetSelectedEditor()
        {
            var sourceTab = (TabPage)tabSource.SelectedTab;
            if (sourceTab == null)
                return null;
            return (CodeEditor)sourceTab.Controls[0];
        }
        #endregion
    }
}
