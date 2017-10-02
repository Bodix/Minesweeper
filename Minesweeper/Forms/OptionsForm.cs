using System;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public partial class OptionsForm : Form
    {
        GameForm gameForm;
        public OptionsForm(GameForm form)
        {
            InitializeComponent();
            gameForm = form;
            KeyPreview = true;
        }
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            // Fill optionsDataGridView.
            if (optionsDataGridView.Rows.Count == 0)
            {
                optionsDataGridView.Rows.Add(true, "Beginner", "9", "9", "10");
                optionsDataGridView.Rows.Add(false, "Intermediate", "16", "16", "40");
                optionsDataGridView.Rows.Add(false, "Expert", "30", "16", "99");
                optionsDataGridView.Rows.Add(false, "Custom", "", "", "");
            }

            // Make new style and editable several cells.
            for (int i = 2; i <= 4; i++)
            {
                optionsDataGridView.Rows[3].Cells[i].ReadOnly = false;
                optionsDataGridView.Rows[3].Cells[i].Style.BackColor = Color.LightGray;
                optionsDataGridView.Rows[3].Cells[i].Style.SelectionBackColor = Color.LightGray;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < optionsDataGridView.Rows.Count; i++)
            {
                if (optionsDataGridView[0, i].Value.ToString() == "True")
                {
                    switch (i)
                    {
                        case (0):
                            gameForm.fieldWidth = 9;
                            gameForm.fieldHeight = 9;
                            gameForm.amountOfBombs = 10;
                            break;
                        case (1):
                            gameForm.fieldWidth = 16;
                            gameForm.fieldHeight = 16;
                            gameForm.amountOfBombs = 40;
                            break;
                        case (2):
                            gameForm.fieldWidth = 30;
                            gameForm.fieldHeight = 16;
                            gameForm.amountOfBombs = 99;
                            break;
                        case (3):
                            if (optionsDataGridView[2, 3].Value.ToString() != "")
                                gameForm.fieldWidth = Convert.ToInt16(optionsDataGridView[2, 3].Value);
                            else
                            {
                                MessageBox.Show("Вы ввели не все параметры для пользовательской настройки уровня сложности");
                                return;
                            }
                            if (optionsDataGridView[3, 3].Value.ToString() != "")
                                gameForm.fieldHeight = Convert.ToInt16(optionsDataGridView[3, 3].Value);
                            else
                            {
                                MessageBox.Show("Вы ввели не все параметры для пользовательской настройки уровня сложности");
                                return;
                            }
                            if (optionsDataGridView[4, 3].Value.ToString() != "")
                                if (Convert.ToInt16(optionsDataGridView[4, 3].Value) <=
                                    (Convert.ToInt16(optionsDataGridView[2, 3].Value) *
                                    Convert.ToInt16(optionsDataGridView[3, 3].Value)))
                                    gameForm.amountOfBombs = Convert.ToInt16(optionsDataGridView[4, 3].Value);
                                else
                                {
                                    MessageBox.Show("Количество бомб больше, чем размер поля");
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Вы ввели не все параметры для пользовательской настройки уровня сложности");
                                return;
                            }
                            break;
                    }
                }
            }

            if (soundsCheckBox.Checked == true) gameForm.sounds = true;
            else gameForm.sounds = false;
            Hide();
        }
        private void optionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Hide();
        }
        private void optionsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                foreach (DataGridViewRow row in optionsDataGridView.Rows)
                {
                    if (row.Index == e.RowIndex)
                        row.Cells[0].Value = true;
                    else row.Cells[0].Value = false;
                }
                optionsDataGridView.BeginEdit(false);
        }
        private void optionsDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(optionsDataGridView_KeyPress);
            TextBox cell = e.Control as TextBox;
            if (cell != null)
            {
                cell.KeyPress += new KeyPressEventHandler(optionsDataGridView_KeyPress);
            }
        }
        private void optionsDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void optionsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && optionsDataGridView[2, e.RowIndex].Value.ToString() != "")
                if (Convert.ToInt16(optionsDataGridView[2, e.RowIndex].Value) > 40)
                    optionsDataGridView[2, e.RowIndex].Value = 40;
            if (e.ColumnIndex == 3 && optionsDataGridView[3, e.RowIndex].Value.ToString() != "")
                if (Convert.ToInt16(optionsDataGridView[3, e.RowIndex].Value) > 20)
                    optionsDataGridView[3, e.RowIndex].Value = 20;
            if (e.ColumnIndex == 4 && optionsDataGridView[4, e.RowIndex].Value.ToString() != "")
                if (Convert.ToInt16(optionsDataGridView[4, e.RowIndex].Value) > 800)
                    optionsDataGridView[4, e.RowIndex].Value = 800;
        }
    }
}
