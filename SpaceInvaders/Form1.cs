using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Account> accounts = new List<Account>();

        private bool addAccountClicked = false;

        private void insertAccName_Validating(object sender, CancelEventArgs e)
        {
            //addAccount.Enabled = true;
            if (string.IsNullOrEmpty(insertAccName.Text) && addAccountClicked)
            {
                e.Cancel = true;
                //addAccount.Enabled = false;
                errorProvider1.SetError(insertAccName, "Please eneter an account name!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(insertAccName, null);
            }
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            GameMap gameMap = new GameMap(accounts[accList.SelectedIndex].score);
            gameMap.Show();
        }

        private void addAccount_Click(object sender, EventArgs e)
        {
            addAccountClicked = true;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show(insertAccName.Text, "Account created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Account account = new Account(insertAccName.Text, 0);
                accounts.Add(account);
                accList.Items.Add(account.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                accList.Items.Remove(accList.Items[accList.SelectedIndex]);
                accounts.Remove((Account)accList.Items[accList.SelectedIndex]);
            }
            catch(ArgumentOutOfRangeException)
            {
                 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
