namespace Minesweeper
{
    partial class OptionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveButton = new System.Windows.Forms.Button();
            this.optionsDataGridView = new System.Windows.Forms.DataGridView();
            this.CheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BombsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.optionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(173, 117);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(57, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // optionsDataGridView
            // 
            this.optionsDataGridView.AllowUserToAddRows = false;
            this.optionsDataGridView.AllowUserToDeleteRows = false;
            this.optionsDataGridView.AllowUserToResizeColumns = false;
            this.optionsDataGridView.AllowUserToResizeRows = false;
            this.optionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.optionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.optionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.optionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckColumn,
            this.LevelColumn,
            this.WidthColumn,
            this.HeightColumn,
            this.BombsColumn});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.optionsDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.optionsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.optionsDataGridView.Name = "optionsDataGridView";
            this.optionsDataGridView.RowHeadersVisible = false;
            this.optionsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.optionsDataGridView.Size = new System.Drawing.Size(218, 103);
            this.optionsDataGridView.TabIndex = 15;
            this.optionsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.optionsDataGridView_CellClick);
            this.optionsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.optionsDataGridView_CellEndEdit);
            this.optionsDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.optionsDataGridView_EditingControlShowing);
            // 
            // CheckColumn
            // 
            this.CheckColumn.FalseValue = "0";
            this.CheckColumn.Frozen = true;
            this.CheckColumn.HeaderText = "";
            this.CheckColumn.Name = "CheckColumn";
            this.CheckColumn.ReadOnly = true;
            this.CheckColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckColumn.TrueValue = "1";
            this.CheckColumn.Width = 5;
            // 
            // LevelColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.LevelColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.LevelColumn.Frozen = true;
            this.LevelColumn.HeaderText = "Level ";
            this.LevelColumn.Name = "LevelColumn";
            this.LevelColumn.ReadOnly = true;
            this.LevelColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LevelColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LevelColumn.Width = 42;
            // 
            // WidthColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.WidthColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.WidthColumn.Frozen = true;
            this.WidthColumn.HeaderText = "Width";
            this.WidthColumn.MaxInputLength = 2;
            this.WidthColumn.Name = "WidthColumn";
            this.WidthColumn.ReadOnly = true;
            this.WidthColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.WidthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WidthColumn.Width = 41;
            // 
            // HeightColumn
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.HeightColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.HeightColumn.Frozen = true;
            this.HeightColumn.HeaderText = "Height";
            this.HeightColumn.MaxInputLength = 2;
            this.HeightColumn.Name = "HeightColumn";
            this.HeightColumn.ReadOnly = true;
            this.HeightColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HeightColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HeightColumn.Width = 44;
            // 
            // BombsColumn
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.BombsColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.BombsColumn.Frozen = true;
            this.BombsColumn.HeaderText = "Bombs";
            this.BombsColumn.MaxInputLength = 3;
            this.BombsColumn.Name = "BombsColumn";
            this.BombsColumn.ReadOnly = true;
            this.BombsColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BombsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BombsColumn.Width = 45;
            // 
            // soundsCheckBox
            // 
            this.soundsCheckBox.AutoSize = true;
            this.soundsCheckBox.Checked = true;
            this.soundsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soundsCheckBox.Location = new System.Drawing.Point(12, 121);
            this.soundsCheckBox.Name = "soundsCheckBox";
            this.soundsCheckBox.Size = new System.Drawing.Size(96, 17);
            this.soundsCheckBox.TabIndex = 16;
            this.soundsCheckBox.Text = "Enable sounds";
            this.soundsCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 149);
            this.Controls.Add(this.soundsCheckBox);
            this.Controls.Add(this.optionsDataGridView);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.optionsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.optionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView optionsDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WidthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BombsColumn;
        private System.Windows.Forms.CheckBox soundsCheckBox;
    }
}