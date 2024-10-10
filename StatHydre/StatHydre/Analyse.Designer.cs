namespace StatHydre
{
    partial class Analyse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyse));
            this.panel1 = new System.Windows.Forms.Panel();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.searchPictureBox = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.countriesListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectedCountriesListBox = new System.Windows.Forms.ListBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.yearEndUpDown = new System.Windows.Forms.NumericUpDown();
            this.regressionCheck = new System.Windows.Forms.CheckBox();
            this.openWindowButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pieCheckList = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.graphStatListBox = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearStartUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.graphPictureBox);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(460, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 681);
            this.panel1.TabIndex = 8;
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPictureBox.Location = new System.Drawing.Point(0, 0);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(804, 681);
            this.graphPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.graphPictureBox.TabIndex = 0;
            this.graphPictureBox.TabStop = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(-308, 189);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(454, 124);
            this.checkedListBox1.TabIndex = 2;
            // 
            // searchPictureBox
            // 
            this.searchPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("searchPictureBox.Image")));
            this.searchPictureBox.Location = new System.Drawing.Point(306, 57);
            this.searchPictureBox.Name = "searchPictureBox";
            this.searchPictureBox.Size = new System.Drawing.Size(20, 20);
            this.searchPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchPictureBox.TabIndex = 6;
            this.searchPictureBox.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(114, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(214, 29);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Please select country";
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // countriesListBox
            // 
            this.countriesListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.countriesListBox.BackColor = System.Drawing.Color.White;
            this.countriesListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countriesListBox.FormattingEnabled = true;
            this.countriesListBox.ItemHeight = 17;
            this.countriesListBox.Location = new System.Drawing.Point(114, 79);
            this.countriesListBox.Name = "countriesListBox";
            this.countriesListBox.Size = new System.Drawing.Size(214, 55);
            this.countriesListBox.TabIndex = 7;
            this.countriesListBox.Visible = false;
            this.countriesListBox.SelectedIndexChanged += new System.EventHandler(this.CountriesListBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.selectedCountriesListBox);
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Controls.Add(this.countriesListBox);
            this.panel2.Controls.Add(this.searchPictureBox);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 134);
            this.panel2.TabIndex = 0;
            // 
            // selectedCountriesListBox
            // 
            this.selectedCountriesListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedCountriesListBox.ItemHeight = 17;
            this.selectedCountriesListBox.Location = new System.Drawing.Point(0, 0);
            this.selectedCountriesListBox.Name = "selectedCountriesListBox";
            this.selectedCountriesListBox.Size = new System.Drawing.Size(108, 123);
            this.selectedCountriesListBox.TabIndex = 0;
            this.selectedCountriesListBox.Visible = false;
            this.selectedCountriesListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedCountriesListBox_SelectedIndexChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTitle.Location = new System.Drawing.Point(130, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(196, 39);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "StatHydre";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPictureBox.Location = new System.Drawing.Point(3, 377);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(454, 301);
            this.mapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapPictureBox.TabIndex = 1;
            this.mapPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mapPictureBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.43316F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.56684F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 681);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.endLabel);
            this.panel3.Controls.Add(this.startLabel);
            this.panel3.Controls.Add(this.yearEndUpDown);
            this.panel3.Controls.Add(this.regressionCheck);
            this.panel3.Controls.Add(this.openWindowButton);
            this.panel3.Controls.Add(this.openButton);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pieCheckList);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.yearStartUpDown);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.graphStatListBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(454, 228);
            this.panel3.TabIndex = 2;
            this.panel3.Visible = false;
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLabel.Location = new System.Drawing.Point(316, 91);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(30, 17);
            this.endLabel.TabIndex = 13;
            this.endLabel.Text = "end";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(316, 44);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(34, 17);
            this.startLabel.TabIndex = 12;
            this.startLabel.Text = "start";
            // 
            // yearEndUpDown
            // 
            this.yearEndUpDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearEndUpDown.Location = new System.Drawing.Point(319, 110);
            this.yearEndUpDown.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.yearEndUpDown.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.yearEndUpDown.Name = "yearEndUpDown";
            this.yearEndUpDown.Size = new System.Drawing.Size(107, 25);
            this.yearEndUpDown.TabIndex = 11;
            this.yearEndUpDown.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // regressionCheck
            // 
            this.regressionCheck.AutoSize = true;
            this.regressionCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regressionCheck.Location = new System.Drawing.Point(319, 141);
            this.regressionCheck.Name = "regressionCheck";
            this.regressionCheck.Size = new System.Drawing.Size(80, 17);
            this.regressionCheck.TabIndex = 10;
            this.regressionCheck.Text = "regression";
            this.regressionCheck.UseVisualStyleBackColor = true;
            // 
            // openWindowButton
            // 
            this.openWindowButton.BackColor = System.Drawing.Color.SteelBlue;
            this.openWindowButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openWindowButton.ForeColor = System.Drawing.Color.White;
            this.openWindowButton.Location = new System.Drawing.Point(210, 192);
            this.openWindowButton.Name = "openWindowButton";
            this.openWindowButton.Size = new System.Drawing.Size(151, 31);
            this.openWindowButton.TabIndex = 9;
            this.openWindowButton.Text = "Open  in new window";
            this.openWindowButton.UseVisualStyleBackColor = false;
            this.openWindowButton.Click += new System.EventHandler(this.OpenWindowButton_Click);
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.SteelBlue;
            this.openButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(114, 192);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 31);
            this.openButton.TabIndex = 8;
            this.openButton.Text = "Open ";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(169, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pie Chart";
            // 
            // pieCheckList
            // 
            this.pieCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pieCheckList.CheckOnClick = true;
            this.pieCheckList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pieCheckList.FormattingEnabled = true;
            this.pieCheckList.Items.AddRange(new object[] {
            "energy produced",
            "energy consumed ",
            "emissions by sector"});
            this.pieCheckList.Location = new System.Drawing.Point(149, 47);
            this.pieCheckList.Name = "pieCheckList";
            this.pieCheckList.Size = new System.Drawing.Size(136, 80);
            this.pieCheckList.TabIndex = 6;
            this.pieCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PieCheckList_ItemCheck);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-3, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 2);
            this.label4.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year";
            // 
            // yearStartUpDown
            // 
            this.yearStartUpDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearStartUpDown.Location = new System.Drawing.Point(319, 63);
            this.yearStartUpDown.Maximum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.yearStartUpDown.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.yearStartUpDown.Name = "yearStartUpDown";
            this.yearStartUpDown.Size = new System.Drawing.Size(107, 25);
            this.yearStartUpDown.TabIndex = 3;
            this.yearStartUpDown.Value = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 2);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type";
            // 
            // graphStatListBox
            // 
            this.graphStatListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.graphStatListBox.CheckOnClick = true;
            this.graphStatListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphStatListBox.FormattingEnabled = true;
            this.graphStatListBox.Items.AddRange(new object[] {
            "emissions",
            "population",
            "pluviometry",
            "temperature",
            "GDP",
            "GDP per capita"});
            this.graphStatListBox.Location = new System.Drawing.Point(3, 47);
            this.graphStatListBox.Name = "graphStatListBox";
            this.graphStatListBox.Size = new System.Drawing.Size(116, 120);
            this.graphStatListBox.TabIndex = 0;
            this.graphStatListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.GraphStatListBox_ItemCheck);
            // 
            // Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Analyse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatHydre";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearStartUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private System.Windows.Forms.PictureBox searchPictureBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox countriesListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox graphStatListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown yearStartUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox pieCheckList;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button openWindowButton;
        private System.Windows.Forms.CheckBox regressionCheck;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.NumericUpDown yearEndUpDown;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox selectedCountriesListBox;
    }
}