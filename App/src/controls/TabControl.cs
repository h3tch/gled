﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace System.Windows.Forms
{
    public class TabControlEx : TabControl
    {
        #region FIELDS
        public new Color ForeColor { get; set; }
        public new Color BackColor { get; set; }
        public Color HighlightForeColor { get; set; }
        public Color WorkspaceColor { get; set; }
        internal Brush ForeBrush;
        internal Brush BackBrush;
        internal Brush HighlightForeBrush;
        internal Brush WorkspaceBrush;
        internal StringFormat textFormat;
        internal PointF[] poly;
        const int TabMarginL = 8;
        const int TabMarginR = 2;
        #endregion

        public TabControlEx()
        {
            // set relevant control settings to enable custom tab controls
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
            // set the tabs text style
            textFormat = new StringFormat();
            textFormat.Alignment = StringAlignment.Center;
            textFormat.LineAlignment = StringAlignment.Center;

            // set style to current theme
            ForeColor = Theme.ForeColor;
            BackColor = Theme.BackColor;
            HighlightForeColor = Theme.HighlightForeColor;
            WorkspaceColor = Theme.Workspace;
            ForeBrush = new SolidBrush(ForeColor);
            BackBrush = new SolidBrush(BackColor);
            HighlightForeBrush = new SolidBrush(HighlightForeColor);
            WorkspaceBrush = new SolidBrush(WorkspaceColor);
            poly = Enumerable.Repeat(new PointF(), 6).ToArray();
        }

        protected override void OnPaint(PaintEventArgs e) => DrawControl(e.Graphics);

        internal void DrawControl(Graphics g)
        {
            if (!Visible)
                return;

            var client = ClientRectangle;
            var tabs = DisplayRectangle;
            var clip = g.Clip;
            
            // fill client area
            g.FillRectangle(BackBrush, client);

            // DRAW TABS
            for (int i = 0; i < TabCount; i++)
                DrawTab(g, TabPages[i], i);

            // reset clip space
            g.Clip = clip;
        }

        internal void DrawTab(Graphics g, TabPage tab, int nIndex)
        {
            Rectangle tabRect = GetTabRect(nIndex);
            RectangleF textRect = tabRect;
            LinearGradientBrush polyBrush, borderBrush;

            // tab background polygon
            if (Alignment == TabAlignment.Top)
            {
                poly[2].X = (poly[0].X = poly[1].X = tabRect.Left) + 3;
                poly[3].X = (poly[4].X = poly[5].X = tabRect.Right) - 3;
                poly[1].Y = poly[4].Y = (poly[2].Y = poly[3].Y = tabRect.Top + 1) + 3;
                poly[0].Y = poly[5].Y = tabRect.Bottom - 1;
                polyBrush = new LinearGradientBrush(tabRect, WorkspaceColor, BackColor, LinearGradientMode.Vertical);
                borderBrush = new LinearGradientBrush(tabRect, ForeColor, BackColor, LinearGradientMode.Vertical);
            }
            else
            {
                poly[2].X = (poly[0].X = poly[1].X = tabRect.Left) + 3;
                poly[0].Y = poly[5].Y = tabRect.Top + 1;
                poly[1].Y = poly[4].Y = (poly[2].Y = poly[3].Y = tabRect.Bottom - 1) - 3;
                poly[3].X = (poly[4].X = poly[5].X = tabRect.Right) - 3;
                polyBrush = new LinearGradientBrush(tabRect, BackColor, WorkspaceColor, LinearGradientMode.Vertical);
                borderBrush = new LinearGradientBrush(tabRect, BackColor, ForeColor, LinearGradientMode.Vertical);
            }
            var pen = new Pen(borderBrush, 1);

            // draw tab background
            if (SelectedIndex == nIndex)
            {
                // fill this tab with background color
                g.FillPolygon(polyBrush, poly);
                g.DrawLines(pen, poly);
            }
            else
            {
                g.DrawLine(pen, poly[0].X, poly[0].Y, poly[1].X, poly[1].Y);
                g.DrawLine(pen, poly[4].X, poly[4].Y, poly[5].X, poly[5].Y);
            }

            // draw tab icon
            if (tab.ImageIndex >= 0 && ImageList?.Images[tab.ImageIndex] != null)
            {
                var img = ImageList.Images[tab.ImageIndex];
                var imgRect = new Rectangle(
                    tabRect.X + TabMarginL, tabRect.Y + 1,
                    img.Width, img.Height);

                // adjust rectangles
                var nAdj = (float)(TabMarginL + img.Width + TabMarginR);

                imgRect.Y += (tabRect.Height - img.Height) / 2;
                textRect.X += nAdj;
                textRect.Width -= nAdj;

                // draw icon
                g.DrawImage(img, imgRect);
            }
            
            // draw string
            g.DrawString(tab.Text, Font, ForeBrush, textRect, textFormat);

            // clean up
            pen.Dispose();
            polyBrush.Dispose();
            borderBrush.Dispose();
        }
    }
}
