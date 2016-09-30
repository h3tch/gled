﻿using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    [System.ComponentModel.ToolboxItem(false)]
    public class FXTabStyleProvider : TabStyleRoundedProvider
    {
        public FXTabStyleProvider(FXTabControl tabControl) : base(tabControl)
        {
            radius = 1;
            showTabCloser = false;

            // Must set after the _Radius as this is used in the calculations of the actual padding
            Padding = new Drawing.Point(8, 3);
        }

        protected override void DrawTabCloser(int index, Graphics g)
        {
            if (showTabCloser)
            {
                var closerRect = tabControl.GetTabCloserRect(index);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                if (closerRect.Contains(tabControl.MousePosition))
                {
                    using (var closerPath = GetCloserButtonPath(closerRect))
                    {
                        g.FillPath(Brushes.White, closerPath);
                        g.DrawPath(CloserColorPen, closerPath);
                    }
                    using (var closerPath = GetCloserPath(closerRect))
                    {
                        CloserColorActivePen.Width = 2;
                        g.DrawPath(CloserColorActivePen, closerPath);
                    }
                }
                else
                {
                    if (index == tabControl.SelectedIndex)
                    {
                        using (GraphicsPath closerPath = GetCloserPath(closerRect))
                        {
                            CloserColorPen.Width = 2;
                            g.DrawPath(CloserColorPen, closerPath);
                        }
                    }
                    else if (index == tabControl.ActiveIndex)
                    {
                        using (GraphicsPath closerPath = GetCloserPath(closerRect))
                        {
                            CloserColorPen.Width = 2;
                            g.DrawPath(CloserColorPen, closerPath);
                        }
                    }
                }
            }
        }

        private static GraphicsPath GetCloserButtonPath(Rectangle closerRect)
        {
            var closerPath = new GraphicsPath();
            closerPath.AddLine(closerRect.X - 1, closerRect.Y - 2, closerRect.Right + 1, closerRect.Y - 2);
            closerPath.AddLine(closerRect.Right + 2, closerRect.Y - 1, closerRect.Right + 2, closerRect.Bottom + 1);
            closerPath.AddLine(closerRect.Right + 1, closerRect.Bottom + 2, closerRect.X - 1, closerRect.Bottom + 2);
            closerPath.AddLine(closerRect.X - 2, closerRect.Bottom + 1, closerRect.X - 2, closerRect.Y - 1);
            closerPath.CloseFigure();
            return closerPath;
        }
    }
}
