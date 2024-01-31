namespace Assignment_work
{
    partial class ComissionForm
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
            this.btnBonus = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBonusWeek = new System.Windows.Forms.NumericUpDown();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudNumberOfProperties = new System.Windows.Forms.NumericUpDown();
            this.nudWeek = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxEmployee = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalComission = new System.Windows.Forms.Label();
            this.lblTotalNumberOfProperties = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonusWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBonus
            // 
            this.btnBonus.BackColor = System.Drawing.Color.MistyRose;
            this.btnBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBonus.Location = new System.Drawing.Point(614, 511);
            this.btnBonus.Name = "btnBonus";
            this.btnBonus.Size = new System.Drawing.Size(115, 50);
            this.btnBonus.TabIndex = 21;
            this.btnBonus.Text = "Apply bonus";
            this.btnBonus.UseVisualStyleBackColor = false;
            this.btnBonus.Click += new System.EventHandler(this.btnBonus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 480);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Week:";
            // 
            // nudBonusWeek
            // 
            this.nudBonusWeek.Location = new System.Drawing.Point(609, 474);
            this.nudBonusWeek.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.nudBonusWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBonusWeek.Name = "nudBonusWeek";
            this.nudBonusWeek.Size = new System.Drawing.Size(120, 22);
            this.nudBonusWeek.TabIndex = 19;
            this.nudBonusWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Beige;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInsert.Location = new System.Drawing.Point(394, 324);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(120, 60);
            this.btnInsert.TabIndex = 18;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Week:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Number of properties:";
            // 
            // nudNumberOfProperties
            // 
            this.nudNumberOfProperties.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.nudNumberOfProperties.Location = new System.Drawing.Point(230, 378);
            this.nudNumberOfProperties.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfProperties.Name = "nudNumberOfProperties";
            this.nudNumberOfProperties.Size = new System.Drawing.Size(120, 22);
            this.nudNumberOfProperties.TabIndex = 15;
            this.nudNumberOfProperties.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudWeek
            // 
            this.nudWeek.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.nudWeek.Location = new System.Drawing.Point(230, 344);
            this.nudWeek.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.nudWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeek.Name = "nudWeek";
            this.nudWeek.Size = new System.Drawing.Size(120, 22);
            this.nudWeek.TabIndex = 14;
            this.nudWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Employee:";
            // 
            // cmbxEmployee
            // 
            this.cmbxEmployee.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxEmployee.FormattingEnabled = true;
            this.cmbxEmployee.Location = new System.Drawing.Point(229, 301);
            this.cmbxEmployee.Name = "cmbxEmployee";
            this.cmbxEmployee.Size = new System.Drawing.Size(121, 24);
            this.cmbxEmployee.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(75, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(654, 257);
            this.dataGridView1.TabIndex = 11;
            // 
            // lblTotalComission
            // 
            this.lblTotalComission.AutoSize = true;
            this.lblTotalComission.Location = new System.Drawing.Point(72, 474);
            this.lblTotalComission.Name = "lblTotalComission";
            this.lblTotalComission.Size = new System.Drawing.Size(105, 16);
            this.lblTotalComission.TabIndex = 22;
            this.lblTotalComission.Text = "Total comission:";
            // 
            // lblTotalNumberOfProperties
            // 
            this.lblTotalNumberOfProperties.AutoSize = true;
            this.lblTotalNumberOfProperties.Location = new System.Drawing.Point(72, 511);
            this.lblTotalNumberOfProperties.Name = "lblTotalNumberOfProperties";
            this.lblTotalNumberOfProperties.Size = new System.Drawing.Size(170, 16);
            this.lblTotalNumberOfProperties.TabIndex = 23;
            this.lblTotalNumberOfProperties.Text = "Total number of properties: ";
            // 
            // ComissionForm
            // 
            this.ClientSize = new System.Drawing.Size(911, 571);
            this.Controls.Add(this.lblTotalNumberOfProperties);
            this.Controls.Add(this.lblTotalComission);
            this.Controls.Add(this.btnBonus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudBonusWeek);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudNumberOfProperties);
            this.Controls.Add(this.nudWeek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxEmployee);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ComissionForm";
            this.Load += new System.EventHandler(this.ComissionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBonusWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBonus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBonusWeek;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNumberOfProperties;
        private System.Windows.Forms.NumericUpDown nudWeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxEmployee;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalComission;
        private System.Windows.Forms.Label lblTotalNumberOfProperties;
    }
}