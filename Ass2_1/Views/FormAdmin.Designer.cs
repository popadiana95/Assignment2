using System.Windows.Forms;

namespace Furniture
{
    partial class FormAdmin
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
            this.labelEmplID = new System.Windows.Forms.Label();
            this.labelEmplName = new System.Windows.Forms.Label();
            this.labelEmplTitle = new System.Windows.Forms.Label();
            this.textBoxEmplID = new System.Windows.Forms.TextBox();
            this.textBoxEmplName = new System.Windows.Forms.TextBox();
            this.textBoxEmplTitle = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.idEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonReport = new System.Windows.Forms.Button();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.textBoxStartDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxEndDate = new System.Windows.Forms.DateTimePicker();
            this.buttonView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEmplID
            // 
            this.labelEmplID.AutoSize = true;
            this.labelEmplID.Location = new System.Drawing.Point(32, 32);
            this.labelEmplID.Name = "labelEmplID";
            this.labelEmplID.Size = new System.Drawing.Size(67, 13);
            this.labelEmplID.TabIndex = 0;
            this.labelEmplID.Text = "Employee ID";
            // 
            // labelEmplName
            // 
            this.labelEmplName.AutoSize = true;
            this.labelEmplName.Location = new System.Drawing.Point(32, 63);
            this.labelEmplName.Name = "labelEmplName";
            this.labelEmplName.Size = new System.Drawing.Size(82, 13);
            this.labelEmplName.TabIndex = 1;
            this.labelEmplName.Text = "Employee name";
            // 
            // labelEmplTitle
            // 
            this.labelEmplTitle.AutoSize = true;
            this.labelEmplTitle.Location = new System.Drawing.Point(32, 93);
            this.labelEmplTitle.Name = "labelEmplTitle";
            this.labelEmplTitle.Size = new System.Drawing.Size(76, 13);
            this.labelEmplTitle.TabIndex = 2;
            this.labelEmplTitle.Text = "Employee Title";
            // 
            // textBoxEmplID
            // 
            this.textBoxEmplID.Location = new System.Drawing.Point(133, 29);
            this.textBoxEmplID.Name = "textBoxEmplID";
            this.textBoxEmplID.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmplID.TabIndex = 3;
            // 
            // textBoxEmplName
            // 
            this.textBoxEmplName.Location = new System.Drawing.Point(133, 63);
            this.textBoxEmplName.Name = "textBoxEmplName";
            this.textBoxEmplName.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmplName.TabIndex = 4;
            // 
            // textBoxEmplTitle
            // 
            this.textBoxEmplTitle.Location = new System.Drawing.Point(133, 93);
            this.textBoxEmplTitle.Name = "textBoxEmplTitle";
            this.textBoxEmplTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmplTitle.TabIndex = 5;
            // 
            // c
            // 
            this.c.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.c.Location = new System.Drawing.Point(665, 74);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(108, 23);
            this.c.TabIndex = 6;
            this.c.Text = "Add Employee";
            this.c.UseVisualStyleBackColor = true;
            //this.c.Click += new System.EventHandler(this.c_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Update Employee";
            this.button1.UseVisualStyleBackColor = true;
            //this.button1.Click += OnUpdateButtonClick;
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete Employee";
            this.button2.UseVisualStyleBackColor = true;
           // this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.AllowUserToResizeColumns = false;
            this.dataGridViewEmployees.AllowUserToResizeRows = false;
            this.dataGridViewEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmployee,
            this.name,
            this.title});
            this.dataGridViewEmployees.Location = new System.Drawing.Point(275, 26);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(349, 179);
            this.dataGridViewEmployees.TabIndex = 38;
            this.dataGridViewEmployees.SelectionChanged += new System.EventHandler(this.dataGridViewEmployees_SelectionChanged);
            // 
            // idEmployee
            // 
            this.idEmployee.DataPropertyName = "idEmployee";
            this.idEmployee.HeaderText = "idEmployee";
            this.idEmployee.Name = "idEmployee";
            this.idEmployee.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // priceUnit
            // 
            this.priceUnit.Name = "priceUnit";
            // 
            // priceDetail
            // 
            this.priceDetail.Name = "priceDetail";
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(259, 268);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(108, 23);
            this.buttonReport.TabIndex = 39;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            //this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(59, 251);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(55, 13);
            this.labelStartDate.TabIndex = 40;
            this.labelStartDate.Text = "Start Date";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(56, 278);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(52, 13);
            this.labelEndDate.TabIndex = 41;
            this.labelEndDate.Text = "End Date";
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textBoxStartDate.Location = new System.Drawing.Point(133, 251);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartDate.TabIndex = 42;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textBoxEndDate.Location = new System.Drawing.Point(133, 278);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndDate.TabIndex = 43;
            // 
            // buttonView
            // 
            this.buttonView.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.buttonView.Location = new System.Drawing.Point(665, 32);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(108, 23);
            this.buttonView.TabIndex = 44;
            this.buttonView.Text = "View Employees";
            this.buttonView.UseVisualStyleBackColor = true;
           // this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 465);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.textBoxEndDate);
            this.Controls.Add(this.textBoxStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.textBoxEmplTitle);
            this.Controls.Add(this.textBoxEmplName);
            this.Controls.Add(this.textBoxEmplID);
            this.Controls.Add(this.labelEmplTitle);
            this.Controls.Add(this.labelEmplName);
            this.Controls.Add(this.labelEmplID);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEmplID;
        private System.Windows.Forms.Label labelEmplName;
        private System.Windows.Forms.Label labelEmplTitle;
        private System.Windows.Forms.TextBox textBoxEmplID;
        private System.Windows.Forms.TextBox textBoxEmplName;
        private System.Windows.Forms.TextBox textBoxEmplTitle;
        public System.Windows.Forms.Button c;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idEmployee;
        public DataGridView dataGridViewEmployees;
        private DataGridViewTextBoxColumn idEmpl;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn priceUnit;
        private DataGridViewTextBoxColumn priceDetail;
        private Button buttonReport;
        private Label labelStartDate;
        private Label labelEndDate;
        private DateTimePicker textBoxStartDate;
        private DateTimePicker textBoxEndDate;
        public Button buttonView;
    }
}