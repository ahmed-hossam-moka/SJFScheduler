using System.Windows.Forms;
using System.Drawing;
namespace SJFSchedulerV1
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.txtProcessName = new TextBox();
            this.txtArrivalTime = new TextBox();
            this.txtBurstTime = new TextBox();
            this.btnAddProcess = new Button();
            this.dataGridView1 = new DataGridView();
            this.btnRunScheduler = new Button();
            this.panelGantt = new Panel();
            this.label4 = new Label();
            this.btnClear = new Button();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panelInputs = new Panel();
            this.panelButtons = new Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelInputs.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process Name:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new Size(78, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arrival Time:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new Size(68, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Burst Time:";

            // txtProcessName
            this.txtProcessName.Location = new Point(95, 3);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new Size(120, 23);
            this.txtProcessName.TabIndex = 3;

            // txtArrivalTime
            this.txtArrivalTime.Location = new Point(95, 32);
            this.txtArrivalTime.Name = "txtArrivalTime";
            this.txtArrivalTime.Size = new Size(120, 23);
            this.txtArrivalTime.TabIndex = 4;

            // txtBurstTime
            this.txtBurstTime.Location = new Point(95, 61);
            this.txtBurstTime.Name = "txtBurstTime";
            this.txtBurstTime.Size = new Size(120, 23);
            this.txtBurstTime.TabIndex = 5;

            // btnAddProcess
            this.btnAddProcess.Location = new Point(221, 3);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new Size(90, 23);
            this.btnAddProcess.TabIndex = 6;
            this.btnAddProcess.Text = "Add Process";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(3, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new Size(794, 150);
            this.dataGridView1.TabIndex = 7;

            // btnRunScheduler
            this.btnRunScheduler.Location = new Point(3, 3);
            this.btnRunScheduler.Name = "btnRunScheduler";
            this.btnRunScheduler.Size = new Size(100, 30);
            this.btnRunScheduler.TabIndex = 8;
            this.btnRunScheduler.Text = "Run Scheduler";
            this.btnRunScheduler.UseVisualStyleBackColor = true;
            this.btnRunScheduler.Click += new System.EventHandler(this.btnRunScheduler_Click);

            // panelGantt
            this.panelGantt.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.panelGantt.AutoScroll = true;
            this.panelGantt.BorderStyle = BorderStyle.FixedSingle;
            this.panelGantt.Location = new Point(3, 264);
            this.panelGantt.Name = "panelGantt";
            this.panelGantt.Size = new Size(794, 120);
            this.panelGantt.TabIndex = 9;

            // label4
            this.label4.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new Point(450, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(20, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Gantt Chart";

            // btnClear
            this.btnClear.Location = new Point(109, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(90, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelInputs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelGantt, 0, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 105F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 156F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 13;

            // panelInputs
            this.panelInputs.Controls.Add(this.label1);
            this.panelInputs.Controls.Add(this.txtProcessName);
            this.panelInputs.Controls.Add(this.label2);
            this.panelInputs.Controls.Add(this.btnAddProcess);
            this.panelInputs.Controls.Add(this.label3);
            this.panelInputs.Controls.Add(this.txtBurstTime);
            this.panelInputs.Controls.Add(this.txtArrivalTime);
            this.panelInputs.Dock = DockStyle.Fill;
            this.panelInputs.Location = new Point(3, 3);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new Size(794, 99);
            this.panelInputs.TabIndex = 13;

            // panelButtons
            this.panelButtons.Controls.Add(this.btnRunScheduler);
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.label4);
            this.panelButtons.Dock = DockStyle.Fill;
            this.panelButtons.Location = new Point(3, 264);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(794, 34);
            this.panelButtons.TabIndex = 14;

            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SJF Preemptive Scheduler";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtProcessName;
        private TextBox txtArrivalTime;
        private TextBox txtBurstTime;
        private Button btnAddProcess;
        private DataGridView dataGridView1;
        private Button btnRunScheduler;
        private Panel panelGantt;
        private Label label4;
        private Button btnClear;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelInputs;
        private Panel panelButtons;
    }
}