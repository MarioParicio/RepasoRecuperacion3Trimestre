namespace RR3Trim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadBDCreateXML = new System.Windows.Forms.Button();
            this.btnInsertBDFromXML = new System.Windows.Forms.Button();
            this.txtPrueba = new System.Windows.Forms.TextBox();
            this.btnReadXML = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLinq = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dG = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadBDCreateXML
            // 
            this.btnReadBDCreateXML.Location = new System.Drawing.Point(12, 12);
            this.btnReadBDCreateXML.Name = "btnReadBDCreateXML";
            this.btnReadBDCreateXML.Size = new System.Drawing.Size(174, 47);
            this.btnReadBDCreateXML.TabIndex = 0;
            this.btnReadBDCreateXML.Text = "ReadBDCreateXML";
            this.btnReadBDCreateXML.UseVisualStyleBackColor = true;
            this.btnReadBDCreateXML.Click += new System.EventHandler(this.btnReadBDCreateXML_Click);
            // 
            // btnInsertBDFromXML
            // 
            this.btnInsertBDFromXML.Location = new System.Drawing.Point(12, 118);
            this.btnInsertBDFromXML.Name = "btnInsertBDFromXML";
            this.btnInsertBDFromXML.Size = new System.Drawing.Size(174, 41);
            this.btnInsertBDFromXML.TabIndex = 1;
            this.btnInsertBDFromXML.Text = "InsertBDFromXML";
            this.btnInsertBDFromXML.UseVisualStyleBackColor = true;
            this.btnInsertBDFromXML.Click += new System.EventHandler(this.btnInsertBDFromXML_Click);
            // 
            // txtPrueba
            // 
            this.txtPrueba.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtPrueba.Location = new System.Drawing.Point(2, 0);
            this.txtPrueba.Multiline = true;
            this.txtPrueba.Name = "txtPrueba";
            this.txtPrueba.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrueba.Size = new System.Drawing.Size(708, 728);
            this.txtPrueba.TabIndex = 2;
            // 
            // btnReadXML
            // 
            this.btnReadXML.Location = new System.Drawing.Point(12, 65);
            this.btnReadXML.Name = "btnReadXML";
            this.btnReadXML.Size = new System.Drawing.Size(174, 47);
            this.btnReadXML.TabIndex = 4;
            this.btnReadXML.Text = "MostrarXMLSerializado";
            this.btnReadXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadXML.UseVisualStyleBackColor = true;
            this.btnReadXML.Click += new System.EventHandler(this.btnReadXML_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLinq
            // 
            this.btnLinq.Location = new System.Drawing.Point(12, 165);
            this.btnLinq.Name = "btnLinq";
            this.btnLinq.Size = new System.Drawing.Size(174, 41);
            this.btnLinq.TabIndex = 5;
            this.btnLinq.Text = "Linq";
            this.btnLinq.UseVisualStyleBackColor = true;
            this.btnLinq.Click += new System.EventHandler(this.btnLinq_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.Location = new System.Drawing.Point(192, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dG);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPrueba);
            this.splitContainer1.Size = new System.Drawing.Size(1495, 728);
            this.splitContainer1.SplitterDistance = 781;
            this.splitContainer1.TabIndex = 6;
            // 
            // dG
            // 
            this.dG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG.Dock = System.Windows.Forms.DockStyle.Right;
            this.dG.Location = new System.Drawing.Point(3, 0);
            this.dG.Name = "dG";
            this.dG.RowTemplate.Height = 28;
            this.dG.Size = new System.Drawing.Size(778, 728);
            this.dG.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 728);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnLinq);
            this.Controls.Add(this.btnReadXML);
            this.Controls.Add(this.btnInsertBDFromXML);
            this.Controls.Add(this.btnReadBDCreateXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnReadBDCreateXML;
        private Button btnInsertBDFromXML;
        private TextBox txtPrueba;
        private Button btnReadXML;
        private OpenFileDialog openFileDialog1;
        private Button btnLinq;
        private SplitContainer splitContainer1;
        private DataGridView dG;
    }
}