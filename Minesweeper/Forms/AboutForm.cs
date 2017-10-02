using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class AboutForm : Form
    {
        bool moving;
        int logoX = 131, logoY = 30;
        int logodX = 1, logodY = 1;
        int cursorX, cursorY;
        #region Import MouseEventFlags
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        #endregion
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            logoPictureBox.Location = new Point(logoX, logoY);

            if (logoX < 0)
            {
                logodX = -logodX;
            }
            else if (logoX + logoPictureBox.Width > ClientSize.Width)
            {
                logodX = -logodX;
            }

            if (logoY < 0)
            {
                logodY = -logodY;
            }
            else if (logoY + logoPictureBox.Height > ClientSize.Height)
            {
                logodY = -logodY;
            }

            if (logoPictureBox.Right >= aboutLabel.Left && logoPictureBox.Bottom >= aboutLabel.Top && logoPictureBox.Top <= aboutLabel.Bottom && logoPictureBox.Left <= aboutLabel.Right)
            {
                if (logoPictureBox.Bottom == aboutLabel.Top | logoPictureBox.Top == aboutLabel.Bottom) logodY = -logodY;
                else if (logoPictureBox.Right == aboutLabel.Left | logoPictureBox.Left == aboutLabel.Right) logodX = -logodX;
            }

            logoX += logodX;
            logoY += logodY;
        }
        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            animationTimer.Enabled = false;
            cursorX = e.X;
            cursorY = e.Y;
        }
        private void logoPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving == true)
            {
                Point pos = new Point(Cursor.Position.X - cursorX, Cursor.Position.Y - cursorY);
                logoPictureBox.Location = PointToClient(pos);
                if (logoPictureBox.Left == 1)
                {
                    UpLeftMouse();
                }
                else if (logoPictureBox.Right == ClientSize.Width - 1)
                {
                    UpLeftMouse();
                }

                if (logoPictureBox.Top == 1)
                {
                    UpLeftMouse();
                }
                else if (logoPictureBox.Bottom == ClientSize.Height - 1)
                {
                    UpLeftMouse();
                }

                if (logoPictureBox.Right >= aboutLabel.Left - 1 && logoPictureBox.Bottom >= aboutLabel.Top - 1 && logoPictureBox.Top <= aboutLabel.Bottom + 1 && logoPictureBox.Left <= aboutLabel.Right + 1)
                {
                    UpLeftMouse();
                }
            }
        }
        private void logoPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            logoX = logoPictureBox.Location.X;
            logoY = logoPictureBox.Location.Y;
            //if (logoPictureBox.Location.X < 0 | logoPictureBox.Location.X > ClientSize.Width | logoPictureBox.Location.Y < 0 | logoPictureBox.Location.Y > ClientSize.Height) logoX = 150; logoY = 150;
            animationTimer.Enabled = true;
        }
        private void UpLeftMouse()
        {
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

    }
}
