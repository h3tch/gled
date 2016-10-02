﻿using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml;

namespace System.Windows.Forms
{
    public class Theme
    {
        #region FIELDS
        internal static Palette palette = new Palette();
        public static string Name => palette.Name;
        public static Color BackColor => palette.BackColor;
        public static Color ForeColor => palette.ForeColor;
        public static Color HighlightBackColor => palette.HighlightBackColor;
        public static Color HighlightForeColor => palette.HighlightForeColor;
        public static Color SelectBackColor => palette.SelectBackColor;
        public static Color SelectForeColor => palette.SelectForeColor;
        public static Color Workspace => palette.Workspace;
        public static Color WorkspaceHighlight => palette.WorkspaceHighlight;
        public static Color TextColor => palette.TextColor;
        #endregion

        /// <summary>
        /// Initialize the dark theme.
        /// </summary>
        public static void DarkTheme()
        {
            palette.Name = "DarkTheme";
            palette.BackColor = Color.FromArgb(255, 45, 45, 50);
            palette.ForeColor = Color.FromArgb(255, 200, 200, 200);
            palette.HighlightBackColor = Color.FromArgb(255, 80, 80, 80);
            palette.HighlightForeColor = Color.FromArgb(255, 240, 240, 240);
            palette.SelectBackColor = Color.FromArgb(255, 50, 80, 70);
            palette.SelectForeColor = Color.FromArgb(255, 200, 170, 240);
            palette.Workspace = Color.FromArgb(255, 30, 30, 30);
            palette.WorkspaceHighlight = Color.FromArgb(255, 60, 60, 60);
            palette.TextColor = Color.FromArgb(255, 220, 220, 220);
        }

        /// <summary>
        /// Initialize the light theme.
        /// </summary>
        public static void LightTheme()
        {
            palette.Name = "LightTheme";
            palette.BackColor = Color.FromArgb(255, 238, 238, 242);
            palette.ForeColor = Color.FromArgb(255, 50, 50, 50);
            palette.HighlightBackColor = Color.FromArgb(255, 198, 198, 202);
            palette.HighlightForeColor = Color.FromArgb(255, 90, 90, 90);
            palette.SelectBackColor = Color.FromArgb(255, 242, 198, 212);
            palette.SelectForeColor = Color.FromArgb(255, 130, 110, 90);
            palette.Workspace = Color.FromArgb(255, 255, 255, 255);
            palette.WorkspaceHighlight = Color.FromArgb(255, 220, 220, 220);
            palette.TextColor = Color.FromArgb(255, 30, 30, 30);
        }

        /// <summary>
        /// Load theme from xml.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Load(string path)
        {
            if (!File.Exists(path))
                return false;
            palette = XmlSerializer.Load<Palette>(path);
            return true;
        }

        /// <summary>
        /// Save current theme colors to xml.
        /// </summary>
        /// <param name="path"></param>
        public static void Save(string path, bool overwrite)
        {
            if (!File.Exists(path) || overwrite)
                XmlSerializer.Save(palette, path);
        }

        /// <summary>
        /// Apply theme to the specified control and its children.
        /// </summary>
        /// <param name="control"></param>
        public static void Apply(Control control)
        {
            var type = control.GetType();
            var method = GetMethod(type, true) ?? GetMethod(type, false);
            if (!(bool)method?.Invoke(null, new object[] { control }))
                return;
            foreach (Control c in control.Controls)
                Apply(c);
        }

        /// <summary>
        /// Find ApplyTo method.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="exact"></param>
        /// <returns></returns>
        internal static MethodInfo GetMethod(Type type, bool exact)
        {
            var methods = typeof(Theme).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                if (method.Name != "ApplyTo")
                    continue;
                var @params = method.GetParameters();
                if (@params.Length == 1 &&
                    exact ? type.IsEquivalentTo(@params[0].ParameterType)
                          : type.IsSubclassOf(@params[0].ParameterType))
                    return method;
            }
            return null;
        }

        #region APPLY THEME TO
        private static bool ApplyTo(PropertyGrid c)
        {
            c.BackColor = BackColor;
            c.CategoryForeColor = ForeColor;
            c.CategorySplitterColor = BackColor;
            c.DisabledItemForeColor = HighlightBackColor;
            c.HelpBackColor = Workspace;
            c.HelpBorderColor = BackColor;
            c.HelpForeColor = ForeColor;
            c.LineColor = BackColor;
            c.SelectedItemWithFocusBackColor = WorkspaceHighlight;
            c.SelectedItemWithFocusForeColor = ForeColor;
            c.ViewBackColor = Workspace;
            c.ViewBorderColor = WorkspaceHighlight;
            c.ViewForeColor = ForeColor;
            return false;
        }

        private static bool ApplyTo(ToolStripEx c)
        {
            c.BackColor = BackColor;
            c.ForeColor = ForeColor;
            return false;
        }


        private static bool ApplyTo(DataGridView c)
        {
            var style = new DataGridViewCellStyle();
            c.BackColor = Workspace;
            c.ForeColor = ForeColor;
            c.BackgroundColor = Workspace;
            c.ColumnHeadersDefaultCellStyle.BackColor = BackColor;
            c.ColumnHeadersDefaultCellStyle.ForeColor = ForeColor;
            c.ColumnHeadersDefaultCellStyle.SelectionBackColor = HighlightBackColor;
            c.ColumnHeadersDefaultCellStyle.SelectionForeColor = HighlightForeColor;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.WrapMode = DataGridViewTriState.False;
            style.BackColor = Workspace;
            style.ForeColor = ForeColor;
            style.SelectionBackColor = WorkspaceHighlight;
            style.SelectionForeColor = HighlightForeColor;
            c.DefaultCellStyle = style;
            c.RowHeadersDefaultCellStyle.BackColor = Workspace;
            c.RowHeadersDefaultCellStyle.ForeColor = ForeColor;
            c.RowHeadersDefaultCellStyle.SelectionBackColor = WorkspaceHighlight;
            c.RowHeadersDefaultCellStyle.SelectionForeColor = HighlightForeColor;
            c.GridColor = WorkspaceHighlight;
            return true;
        }

        private static bool ApplyTo(ComboBoxEx c)
        {
            c.ForeColor = ForeColor;
            c.BackColor = Workspace;
            c.BorderColor = ForeColor;
            return true;
        }

        private static bool ApplyTo(FXTabControl c)
        {
            c.BackColor = BackColor;
            c.ForeColor = ForeColor;
            c.DisplayStyleProvider.BackColor = BackColor;
            c.DisplayStyleProvider.BackColorHot = WorkspaceHighlight;
            c.DisplayStyleProvider.BackColorSelected = Workspace;
            c.DisplayStyleProvider.CloserColorActive = Workspace;
            c.DisplayStyleProvider.CloserColor = ForeColor;
            c.DisplayStyleProvider.TextColor = ForeColor;
            c.DisplayStyleProvider.TextColorSelected = ForeColor;
            c.DisplayStyleProvider.TextColorDisabled = HighlightBackColor;
            c.DisplayStyleProvider.BorderColor = Color.Transparent;
            c.DisplayStyleProvider.BorderColorHot = HighlightBackColor;
            c.DisplayStyleProvider.BorderColorSelected = HighlightBackColor;
            return true;
        }

        private static bool ApplyTo(TabPage c)
        {
            c.BackColor = BackColor;
            c.ForeColor = ForeColor;
            return true;
        }

        private static bool ApplyTo(TabPageEx c)
        {
            c.BackColor = BackColor;
            c.ForeColor = ForeColor;
            return true;
        }

        private static bool ApplyTo(ListView c)
        {
            c.BackColor = Workspace;
            c.ForeColor = ForeColor;
            return true;
        }

        private static bool ApplyTo(NumericUpDown c)
        {
            c.BackColor = Workspace;
            c.ForeColor = ForeColor;
            return false;
        }

        private static bool ApplyTo(ImageViewer c)
        {
            c.BackColor = Workspace;
            c.ForeColor = ForeColor;
            return false;
        }

        private static bool ApplyTo(Control c)
        {
            c.BackColor = BackColor;
            c.ForeColor = ForeColor;
            return true;
        }
        #endregion

        #region INTERNAL
        public struct Palette
        {
            public string Name;
            public XmlColor BackColor;
            public XmlColor ForeColor;
            public XmlColor HighlightBackColor;
            public XmlColor HighlightForeColor;
            public XmlColor SelectBackColor;
            public XmlColor SelectForeColor;
            public XmlColor Workspace;
            public XmlColor WorkspaceHighlight;
            public XmlColor TextColor;
        }

        public class XmlColor
        {
            internal Color color = Color.Black;

            public XmlColor() { }

            public XmlColor(Color c) { color = c; }

            public static implicit operator Color(XmlColor x) => x.color;

            public static implicit operator XmlColor(Color c) => new XmlColor(c);

            [Xml.Serialization.XmlAttribute]
            public string hex
            {
                get { return ColorTranslator.ToHtml(color); }
                set { color = ColorTranslator.FromHtml(value); }
            }
        }
        #endregion
    }
}
