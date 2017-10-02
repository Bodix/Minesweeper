namespace Minesweeper
{
    // TO DO: Bug testing. Link to my profile in "About".

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Media;
    using System.Windows.Forms;

    public partial class GameForm : Form
    {
        Cell cell;
        OptionsForm optionsForm;
        AboutForm aboutForm;
        public GameForm()
        {
            InitializeComponent();
            cell = new Cell(this);
            optionsForm = new OptionsForm(this);
            aboutForm = new AboutForm();
        }

        public Cell[,] field;
        public int fieldWidth = 9, fieldHeight = 9;
        public int amountOfBombs = 10;
        public int amountOfBombsForLabel;
        public int percentageOfBombs = 0;
        public int counterForWin = 0;
        public int time = 1;
        public bool sounds = true;
        public bool gameOver = false;

        private void newGameButton_Click(object sender, EventArgs e)
        {
            cell.NewGame(this);
        }
        private void optionsButton_Click(object sender, EventArgs e)
        {
            optionsForm.ShowDialog();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cell.NewGame(this);
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsForm.ShowDialog();
        }
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Плоское игровое поле разделено на ячейки, некоторые из которых «заминированы», количество «заминированных» ячеек известно.\n \nЦелью игры является открытие всех ячеек, не содержащих мины. Игрок открывает ячейки, стараясь не открыть ячейку с миной. Если под открытой ячейкой мины нет, то в ней появляется число, показывающее, сколько ячеек, соседствующих с только что открытой, «заминировано» (в квадрате 3х3, где центр - открытая ячейка). Используя эти числа, игрок пытается рассчитать расположение мин, однако иногда даже в середине и в конце игры некоторые ячейки всё же приходится открывать наугад. Если под соседними ячейками тоже нет мин, то открывается некоторая «не заминированная» область до ячеек, в которых есть цифры. «Заминированные» ячейки игрок может пометить флажком (на правую кнопку мыши), чтобы случайно не открыть их. \n \nОткрыв ячейку с миной, игрок проигрывает. Открыв все «не заминированные» ячейки, игрок выигрывает.");
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm.Show();
        }
        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R) cell.NewGame(this);
            if (e.KeyCode == Keys.Escape) optionsForm.ShowDialog();
            if (e.KeyCode == Keys.F1) MessageBox.Show("Плоское игровое поле разделено на ячейки, некоторые из которых «заминированы», количество «заминированных» ячеек известно.\n \nЦелью игры является открытие всех ячеек, не содержащих мины. Игрок открывает ячейки, стараясь не открыть ячейку с миной. Если под открытой ячейкой мины нет, то в ней появляется число, показывающее, сколько ячеек, соседствующих с только что открытой, «заминировано» (в квадрате 3х3, где центр - открытая ячейка). Используя эти числа, игрок пытается рассчитать расположение мин, однако иногда даже в середине и в конце игры некоторые ячейки всё же приходится открывать наугад. Если под соседними ячейками тоже нет мин, то открывается некоторая «не заминированная» область до ячеек, в которых есть цифры. «Заминированные» ячейки игрок может пометить флажком (на правую кнопку мыши), чтобы случайно не открыть их. \n \nОткрыв ячейку с миной, игрок проигрывает. Открыв все «не заминированные» ячейки, игрок выигрывает.");
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = TimerText(time);
            time++;
        }
        private string TimerText(int time)
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }

    public class Cell : Button
    {
        GameForm gameForm;
        SoundPlayer clickSound, flagSound, bombSound;
        public Cell(GameForm form)
        {
            gameForm = form;
            Size = new Size(33, 33);
            SetStyle(ControlStyles.Selectable, false);
            Text = string.Empty;
            Font = new Font("OldSansBlack", 18, FontStyle.Bold);
            MouseUp += new MouseEventHandler(ClickOnCell);
            MouseMove += new MouseEventHandler(MouseMoveEvent);
            LoadSounds();
        }
        private void LoadSounds()
        {
            clickSound = new SoundPlayer(Properties.Resources.clickSound);
            flagSound = new SoundPlayer(Properties.Resources.flagSound);
            bombSound = new SoundPlayer(Properties.Resources.bombSound);
        }

        private int BombsAround { get; set; }
        private bool Mined { get; set; }
        private bool Flagged { get; set; }

        public void NewGame(GameForm form)
        {
            // Clear form.
            form.timer.Stop();
            form.time = 1;
            form.logoPictureBox.Dispose();
            List<Button> buttons = form.Controls.OfType<Button>().ToList();
            foreach (Button button in buttons)
            {
                button.MouseUp -= new MouseEventHandler(ClickOnCell);
                Controls.Remove(button);
                button.Dispose();
            }
            form.gameOver = false;
            form.counterForWin = 0;

            // Fill form.
            form.field = GetField(form.fieldWidth, form.fieldHeight, form.percentageOfBombs);
            form.Width = (Size.Width - 3) * form.fieldWidth + 13;
            form.Height = (Size.Height - 3) * form.fieldHeight
                + form.menuStrip.Height + form.statusLabel.Height + 35;

            // Set label's.
            form.amountOfBombsLabel.Location = new Point
                (2, form.field[1, form.fieldHeight - 1].Location.Y + form.menuStrip.Height + 8);
            form.amountOfBombsForLabel = form.amountOfBombs;
            form.amountOfBombsLabel.Text = "Bombs: " + form.amountOfBombsForLabel;
            form.timerLabel.Location = new Point
                (form.field[form.fieldWidth - 1, 1].Location.X - 38,
                form.field[1, form.fieldHeight - 1].Location.Y + form.menuStrip.Height + 8);
            form.timerLabel.Text = "00:00:00";
            form.statusLabel.Location = new Point(form.Width / 2 - form.statusLabel.Width / 2 + 6,
                form.field[form.fieldWidth - 1, form.fieldHeight - 1].Location.Y + form.menuStrip.Height + 8);
            form.statusLabel.Text = "";
        }
        private void WinGame(GameForm form)
        {
            form.gameOver = true;
            form.timer.Stop();

            // Set flags on mined cells.
            foreach (Cell cell in form.field)
            {
                if (cell.Mined && !cell.Flagged)
                {
                    Flag(cell);
                }
            }

            // Set "You Win!" label.
            form.statusLabel.ForeColor = Color.Green;
            form.statusLabel.Text = "You win!";

            if (gameForm.sounds)
            {
                for (int i = 0; i < 2; i++)
                    clickSound.PlaySync();
                flagSound.Play();
            }
        }
        private void GameOver(GameForm form)
        {
            form.gameOver = true;
            form.timer.Stop();

            // Show bombs and wrong flags.
            foreach (Cell cell in form.field)
            {
                if (cell != null)
                {
                    if (cell.Mined && !cell.Flagged)
                    {
                        cell.Enabled = false;
                        cell.BackgroundImage = Properties.Resources.bomb_little;
                        cell.BackgroundImageLayout = ImageLayout.Center;
                    }
                    if (!cell.Mined && cell.Flagged)
                    {
                        cell.Paint += Cell_PaintX;
                        cell.Invalidate();
                    }
                }
            }

            // Set "Boom!" label.
            form.statusLabel.ForeColor = Color.Red;
            form.statusLabel.Text = "Boom!";

            if (gameForm.sounds)
                bombSound.Play();
        }
        private Cell[,] GetField(int x, int y, int percentageOfBombs)
        {
            // Creating field.
            Cell[,] field = new Cell[x, y];
            gameForm.counterForWin = x * y;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    field[i, j] = new Cell(gameForm);
                    field[i, j].Location = new Point((Size.Width - 3) * i + 2,
                        (Size.Height - 3) * j + gameForm.menuStrip.Height + 2);
                    field[i, j].Tag = new Point(i, j);
                    field[i, j].Name = field[i, j].Tag.ToString();
                    gameForm.Controls.Add(field[i, j]);
                }

            // Mining.
            Random random = new Random();
            if (percentageOfBombs == 0)
            {
                int tempX = 0, tempY = 0;
                int tempBombsCounter = 0;
                do
                {
                    tempX = random.Next(x);
                    tempY = random.Next(y);
                    if (field[tempX, tempY].Mined != true)
                    {
                        field[tempX, tempY].Mined = true;
                        // For debug.
                        // field[tempX, tempY].BackColor = Color.Red;
                        tempBombsCounter++;
                        gameForm.counterForWin--;
                    }
                }
                while (tempBombsCounter != gameForm.amountOfBombs);
            }
            else
            {
                double[,] randomID = new double[x, y];
                for (int i = 0; i < x; i++)
                    for (int j = 0; j < y; j++)
                    {
                        randomID[i, j] = random.Next(1, 100);
                        if (Math.Truncate(randomID[i, j]) <= percentageOfBombs)
                        {
                            field[i, j].Mined = true;
                            // For debug.
                            // field[a, b].BackColor = Color.Red;
                            gameForm.counterForWin--;
                        }
                    }
            }

            // Counting bombs around cells.
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    field[i, j].BombsAround = CountBombs(field[i, j]);
                }

            return gameForm.field = field;
        }
        private int CountBombs(object sender)
        {
            Cell checkingCell = (Cell)sender;
            Point checkingPoint = (Point)checkingCell.Tag;
            Cell cell;
            Point point;
            int bombCounter = 0;
            for (int dx = -1; dx < 2; dx++)
                for (int dy = -1; dy < 2; dy++)
                {
                    point = new Point(checkingPoint.X + dx, checkingPoint.Y + dy);
                    cell = (Cell)gameForm.Controls[point.ToString()];
                    if (cell != null && cell.Mined)
                    {
                        bombCounter++;
                    }
                }
            return bombCounter;
        }
        private void ClickOnCell(object sender, MouseEventArgs e)
        {
            Cell cell = (Cell)sender;
            if (gameForm.gameOver == false)
            {
                gameForm.timer.Enabled = true;
                if (e.Button == MouseButtons.Left)
                {
                    if (!cell.Flagged)
                    {
                        if (cell.Mined)
                        {
                            cell.BackColor = Color.Red;
                            GameOver(gameForm);
                        }
                        else
                        {
                            OpenCell(cell);
                            if (gameForm.counterForWin == 0) WinGame(gameForm);
                            else if (gameForm.sounds) clickSound.Play();
                        }
                    }
                    else if (gameForm.sounds) flagSound.Play();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Flag(cell);
                    if (gameForm.sounds)
                        flagSound.Play();
                }
            }
        }
        private void Flag(object sender)
        {
            Cell cell = (Cell)sender;
            if (cell.BackgroundImage != null)
            {
                cell.BackgroundImage = null;
                cell.Flagged = false;
                gameForm.amountOfBombsForLabel += 1;
                gameForm.amountOfBombsLabel.Text = "Bombs: " + (gameForm.amountOfBombsForLabel);
            }
            else if (cell.BackgroundImage == null)
            {
                cell.BackgroundImage = Properties.Resources.flag;
                cell.BackgroundImageLayout = ImageLayout.Stretch;
                cell.Flagged = true;
                gameForm.amountOfBombsForLabel -= 1;
                gameForm.amountOfBombsLabel.Text = "Bombs: " + (gameForm.amountOfBombsForLabel);
            }
        }
        private void OpenCell(object sender)
        {
            Cell cell = (Cell)sender;
            if (cell.Enabled && !cell.Flagged)
            {
                cell.Enabled = false;
                if (cell.BombsAround != 0) cell.Paint += Cell_PaintNumber;
                else OpenAroundCells(sender);
                gameForm.counterForWin--;
            }
        }
        private void OpenAroundCells(object sender)
        {
            Cell checkingCell = (Cell)sender;
            Point checkingPoint = (Point)checkingCell.Tag;
            Cell cell;
            Point point;
            for (int dx = -1; dx < 2; dx++)
                for (int dy = -1; dy < 2; dy++)
                {
                    point = new Point(checkingPoint.X + dx, checkingPoint.Y + dy);
                    cell = (Cell)gameForm.Controls[point.ToString()];
                        if (point.X >= 0 
                            && point.X < gameForm.fieldWidth 
                            && point.Y >= 0 
                            && point.Y < gameForm.fieldHeight 
                            && cell.Enabled == true)
                            OpenCell(cell);
                }
        }
        private void Cell_PaintNumber(object sender, PaintEventArgs e)
        {
            Cell cell = (Cell)sender;
            switch (cell.BombsAround)
            {
                case (1):
                    cell.ForeColor = Color.Blue;
                    break;
                case (2):
                    cell.ForeColor = Color.Green;
                    break;
                case (3):
                    cell.ForeColor = Color.Red;
                    break;
                case (4):
                    cell.ForeColor = Color.DarkBlue;
                    break;
                case (5):
                    cell.ForeColor = Color.Brown;
                    break;
                case (6):
                    cell.ForeColor = Color.Turquoise;
                    break;
                case (7):
                    cell.ForeColor = Color.Black;
                    break;
                case (8):
                    cell.ForeColor = Color.Gray;
                    break;
            }
            TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(e.Graphics, cell.BombsAround.ToString(),
                cell.Font, e.ClipRectangle, cell.ForeColor, flags);
        }
        private void Cell_PaintX(object sender, PaintEventArgs e)
        {
            Cell cell = (Cell)sender;
            Pen myPen = new Pen(Color.Red, 3);
            e.Graphics.DrawLine(myPen, 5, 5, 27, 27);
            e.Graphics.DrawLine(myPen, 5, 27, 27, 5);
        }
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Control focusedControl = FindControlAtCursor(gameForm);
            Cell cell = focusedControl as Cell;
            if (cell != null && cell.Enabled == true)
            {
                if (Cursor.Position == cell.Location) cell.Capture = true;
                else cell.Capture = false;
            }
        }
        private static Control FindControlAtPoint(Control container, Point pos)
        {
            Control child;
            foreach (Control control in container.Controls)
            {
                if (control.Visible && control.Bounds.Contains(pos))
                {
                    child = FindControlAtPoint(control, new Point
                        (pos.X - control.Left, pos.Y - control.Top));
                    if (child == null) return control;
                    else return child;
                }
            }
            return null;
        }
        private static Control FindControlAtCursor(GameForm form)
        {
            Point point = Cursor.Position;
            if (form.Bounds.Contains(point))
                return FindControlAtPoint(form, form.PointToClient(point));
            return null;
        }
    }
}

