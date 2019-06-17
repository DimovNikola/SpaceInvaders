using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        private AccountDoc accDoc;
        //List<Account> accounts = new List<Account>();
        private String FileName;

        public Form1()
        {
            InitializeComponent();
            newDoc();
        }

        private void newDoc()
        {
            accDoc = new AccountDoc();
            FileName = "Untitled";
        }        

        private void saveFile()
        {
            if (FileName == "Untitled")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Accounts doc file (*.acc)|*.acc";
                saveFileDialog.Title = "Save accounts doc";
                saveFileDialog.FileName = FileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using(FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, accDoc);
                }
            }
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Accounts doc file (*.acc)|*.acc";
            openFileDialog.Title = "Open accounts doc file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        accDoc = (AccountDoc)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                
            }

        }

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
            GameMap gameMap = new GameMap(accDoc.accounts[accList.SelectedIndex].score);
            gameMap.Show();
        }
        
        private void addAccount_Click(object sender, EventArgs e)
        {
            addAccountClicked = true;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show(insertAccName.Text, "Account created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Account account = new Account(insertAccName.Text, 0);
             
                accDoc.addAccount(account);
                accList.Items.Add(account.ToString());
                saveFile();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                accList.Items.Remove(accList.Items[accList.SelectedIndex]);
                accDoc.removeAccount((Account)accList.Items[accList.SelectedIndex]);

            }
            catch(ArgumentOutOfRangeException)
            {
                 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (accList.Size != null) {
                openFile();
            }
            foreach (Account acc in accDoc.getAccList())
            {
                accList.Items.Add(acc.ToString());
            }
        }
    }
}
