using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace TSChecker
{
    static class CustomBorder
    {
        private static Color[] outerBorderColor = new Color[] { Color.FromArgb(0, 0, 0), Color.FromArgb(52, 52, 52) };
        private static Color[] innerBorderColor = new Color[] { Color.FromArgb(34, 34, 34), Color.FromArgb(31, 31, 31), Color.FromArgb(42, 42, 42), Color.FromArgb(6, 7, 9) };
        private static int titleBarHeight = 30;

        /// <summary>
        /// Renders the custom border onto target window.
        /// </summary>
        /// <param name="rectBorder">The border rectangle of the target window</param>
        /// <param name="graphics">Graphics object sent over via PaintEventArgs</param>
        public static void Render(Rectangle rectBorder, Graphics graphics)
        {
            GraphicsPath borderPath = new GraphicsPath();
            
            // Draw the outer border
            for (int outerBorderIdx = 0; outerBorderIdx < outerBorderColor.Length; outerBorderIdx++)
            {
                borderPath = DrawRectangle((RectangleF)rectBorder, 0, 0, 0, 0);
                Pen pen = new Pen(outerBorderColor[outerBorderIdx]);
                graphics.DrawPath(pen, borderPath);
                DeflateRectangle(ref rectBorder);
            }

            rectBorder.Y += titleBarHeight;
            rectBorder.Height -= titleBarHeight;

            for (int innerBorderIdx = 0; innerBorderIdx < innerBorderColor.Length; innerBorderIdx++)
            {
                Pen pen = new Pen(innerBorderColor[innerBorderIdx]);
                graphics.DrawRectangle(pen, rectBorder);
                DeflateRectangle(ref rectBorder);
            }
        }

        /// <summary>
        /// Draws a rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        /// <returns></returns>
        private static GraphicsPath DrawRectangle (RectangleF rect, float s1, float s2, float s3, float s4)
        {
            if (rect.Y < 1)
            {
                rect.Y += 5;
                rect.Height -= 5;
            }

            float x = rect.X;
            float y = rect.Y;
            float w = rect.Width;
            float h = rect.Height;
            var rectPath = new GraphicsPath();
            rectPath.AddBezier(x, y + s1, x, y, x + s1, y, x + s1, y);
            rectPath.AddLine(x + s1, y, x + w - s2, y);
            rectPath.AddBezier(x + w - s2, y, x + w, y, x + w, y + s2, x + w, y + s2);
            rectPath.AddLine(x + w, y + s2, x + w, y + h - s3);
            rectPath.AddBezier(x + w, y + h - s3, x + w, y + h, x + w - s3, y + h, x + w - s3, y + h);
            rectPath.AddLine(x + w - s3, y + h, x + s4, y + h);
            rectPath.AddBezier(x + s4, y + h, x, y + h, x, y + h - s4, x, y + h - s4);
            rectPath.AddLine(x, y + h - s4, x, y + s1);
            return rectPath;
        }

        private static void DeflateRectangle(ref Rectangle rectBorder)
        {
            rectBorder.X += 1;
            rectBorder.Y += 1;
            rectBorder.Width -= 2;
            rectBorder.Height -= 2;
        }
    }
}
