namespace SpaceInvaders
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.accList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.insertAccName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addAccount = new System.Windows.Forms.Button();
            this.startGame = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.accList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 529);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // accList
            // 
            this.accList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accList.BackColor = System.Drawing.Color.CornflowerBlue;
            this.accList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accList.FormattingEnabled = true;
            this.accList.ItemHeight = 20;
            this.accList.Location = new System.Drawing.Point(3, 3);
            this.accList.Name = "accList";
            this.accList.Size = new System.Drawing.Size(323, 504);
            this.accList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Controls.Add(this.insertAccName);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.addAccount);
            this.groupBox1.Controls.Add(this.startGame);
            this.groupBox1.Location = new System.Drawing.Point(332, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 523);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create/Select Account";
            // 
            // insertAccName
            // 
            this.insertAccName.Location = new System.Drawing.Point(66, 218);
            this.insertAccName.Name = "insertAccName";
            this.insertAccName.Size = new System.Drawing.Size(185, 20);
            this.insertAccName.TabIndex = 0;
            this.insertAccName.Validating += new System.ComponentModel.CancelEventHandler(this.insertAccName_Validating);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(162, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete Account";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addAccount
            // 
            this.addAccount.BackColor = System.Drawing.Color.White;
            this.addAccount.ForeColor = System.Drawing.Color.Navy;
            this.addAccount.Location = new System.Drawing.Point(66, 253);
            this.addAccount.Name = "addAccount";
            this.addAccount.Size = new System.Drawing.Size(95, 23);
            this.addAccount.TabIndex = 1;
            this.addAccount.Text = "Create Account";
            this.addAccount.UseVisualStyleBackColor = false;
            this.addAccount.Click += new System.EventHandler(this.addAccount_Click);
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.White;
            this.startGame.ForeColor = System.Drawing.Color.Navy;
            this.startGame.Location = new System.Drawing.Point(66, 282);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(185, 23);
            this.startGame.TabIndex = 2;
            this.startGame.Text = "Play";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(658, 529);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Space Invaders";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.ListBox accList;
        public System.Windows.Forms.TextBox insertAccName;
        public System.Windows.Forms.Button startGame;
        public System.Windows.Forms.Button addAccount;
        public System.Windows.Forms.Button button1;
    }
}

