using System;
using System.Collections;
using System.Windows.Forms;

namespace ATMProject
{
    public partial class Form1 : Form
    {

        Customer currentCustomer = new Customer(1);
        ArrayList accountList = new ArrayList();
        Account selectedAccount;
        Account selectedAccount2; //only for transfer money
        double machineCash = 1000000;
        int withdrawCode = -1;
        int depositCode = -1;
        int transferCode = -1;

        public Form1()
        {
            InitializeComponent();
            accountList = Account.retrieveAccounts(currentCustomer.getID());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //==================PIN MENU==================

        private void button1_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "1";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "2";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "3";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "4";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "5";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "6";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "7";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "8";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "9";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text == "PIN")
                pinLabel.Text = "0";
            else if (pinLabel.Text.Length <= 3)
                pinLabel.Text = pinLabel.Text + "0";
        }

        private void pinBackspaceButton_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text.Length == 1)
                pinLabel.Text = "PIN";
            else if (pinLabel.Text.Length > 0 && pinLabel.Text != "PIN")
                pinLabel.Text = pinLabel.Text.Substring(0,pinLabel.Text.Length - 1);
        }

        private void pinSubmitButton_Click(object sender, EventArgs e)
        {
            if (pinLabel.Text.Length != 4)
                label1.Text = "PIN must be 4 digits";
            else
            {
                int pin = int.Parse(pinLabel.Text);
                currentCustomer = new Customer(pin);
                pinTableLayoutPanel.Visible = false;
                menuTableLayoutPanel.Visible = true;
            }
        }
        private void pinExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //==================MENU==================

        private void transferMenuButton_Click(object sender, EventArgs e)
        {
            menuTableLayoutPanel.Visible = false;
            transfer1TableLayoutPanel.Visible = true;

            transfer1ListBox.Items.Clear();

            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                transfer1ListBox.Items.Add(tempAccount.getAccountNum());
            }
        }

        private void withdrawMenuButton_Click(object sender, EventArgs e)
        {
            menuTableLayoutPanel.Visible = false;
            withdraw1TableLayoutPanel.Visible = true;

            withdraw1ListBox.Items.Clear();

            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                withdraw1ListBox.Items.Add(tempAccount.getAccountNum());
            }
        }

        private void checkMenuButton_Click(object sender, EventArgs e)
        {
            menuTableLayoutPanel.Visible = false;
            check1TableLayoutPanel.Visible = true;

            check1ListBox.Items.Clear();

            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                check1ListBox.Items.Add(tempAccount.getAccountNum());
            }
        }

        private void depositMenuButton_Click(object sender, EventArgs e)
        {
            menuTableLayoutPanel.Visible = false;
            deposit1TableLayoutPanel.Visible = true;

            deposit1ListBox.Items.Clear();

            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                deposit1ListBox.Items.Add(tempAccount.getAccountNum());
            }
        }

        private void exitMenuButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //==================WITHDRAW==================

        private void Withdraw1SelectButton_Click(object sender, EventArgs e)
        {
            if (withdraw1ListBox.SelectedIndex >= 0) //if item is selected change scene
            {
                selectedAccount = (Account)accountList[withdraw1ListBox.SelectedIndex];
                if (selectedAccount.checkDailyTransaction() == false)
                {
                    errorLabel.Text = "Error: This account has exceeded its daily transaction limit";
                    withdraw1TableLayoutPanel.Visible = false;
                    errorTableLayoutPanel.Visible = true;
                }
                else
                {
                    withdraw1TableLayoutPanel.Visible = false;
                    withdraw2TableLayoutPanel.Visible = true;
                    withdrawAmtLabel.Text = "0";
                }
            }
        }

        private void Withdraw1BackButton_Click(object sender, EventArgs e)
        {
            withdraw1TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void withdraw2SubmitButton_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text != "0")
            {
                double amount = Double.Parse(withdrawAmtLabel.Text);
                withdrawCode = selectedAccount.withdrawMoney(amount, machineCash);
                if (withdrawCode == 0)
                {
                    withdrawCodeLabel.Text = "Please take the money.\n Transaction number: "
                        + selectedAccount.getNewTransaction().getTransNum() + "\n" + "Withdrawal amount: $"
                        + selectedAccount.getNewTransaction().getAmount() + "\n" + "From account: "
                        + selectedAccount.getAccountNum();
                }
                else if (withdrawCode == 1)
                {
                    withdrawCodeLabel.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                        + "Please select another account.";
                }
                else if (withdrawCode == 2)
                {
                    withdrawCodeLabel.Text = "The amount will make the transactions of this account exceed the max limit $3000 for today.\n"
                        + "Please enter a smaller amount.";
                }
                else if (withdrawCode == 3)
                {
                    withdrawCodeLabel.Text = "The amount you entered is greater than the balance of the selected account.\n"
                        + "Please enter a smaller amount.";
                }
                else if (withdrawCode == 4)
                {
                    withdrawCodeLabel.Text = "The machince doesn't have enough cash for your withdrawal.\n"
                        + "Please enter a smaller amount.";
                }
                withdraw2TableLayoutPanel.Visible = false;
                withdrawCodeTableLayoutPanel.Visible = true;
            }
        }

        private void withdraw2CancelButton_Click(object sender, EventArgs e)
        {
            withdraw2TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void withdraw2BackspaceButton_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text.Length <= 1)
                withdrawAmtLabel.Text = "0";
            else
                withdrawAmtLabel.Text = withdrawAmtLabel.Text.Substring(0, withdrawAmtLabel.Text.Length - 1);
        }

        private void withdrawCodeConfirmButton_Click(object sender, EventArgs e)
        {
            withdrawCodeTableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void withdrawAmtButton1_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "1";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "1";
        }

        private void withdrawAmtButton2_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "2";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "2";
        }

        private void withdrawAmtButton3_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "3";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "3";
        }

        private void withdrawAmtButton4_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "4";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "4";
        }

        private void withdrawAmtButton5_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "5";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "5";
        }

        private void withdrawAmtButton6_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "6";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "6";
        }

        private void withdrawAmtButton7_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "7";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "7";
        }

        private void withdrawAmtButton8_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "8";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "8";
        }

        private void withdrawAmtButton9_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "9";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "9";
        }

        private void withdrawAmtButton0_Click(object sender, EventArgs e)
        {
            if (withdrawAmtLabel.Text == "0")
                withdrawAmtLabel.Text = "0";
            else if (withdrawAmtLabel.Text.Length <= 3)
                withdrawAmtLabel.Text = withdrawAmtLabel.Text + "0";
        }

        //==================DEPOSIT==================

        private void deposit1SelectButton_Click(object sender, EventArgs e)
        {
            if (deposit1ListBox.SelectedIndex >= 0) //if item is selected change scene
            {
                selectedAccount = (Account)accountList[deposit1ListBox.SelectedIndex];
                if (selectedAccount.checkDailyTransaction() == false)
                {
                    errorLabel.Text = "Error: This account has exceeded its daily transaction limit";
                    deposit1TableLayoutPanel.Visible = false;
                    errorTableLayoutPanel.Visible = true;
                }
                else
                {
                    deposit1TableLayoutPanel.Visible = false;
                    deposit2TableLayoutPanel.Visible = true;
                    depositAmtLabel.Text = "0";
                }
            }
        }

        private void deposit1BackButton_Click(object sender, EventArgs e)
        {
            deposit1TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void deposit2SubmitButton_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text != "0")
            {
                double amount = Double.Parse(depositAmtLabel.Text);
                depositCode = selectedAccount.depositMoney(amount);
                if (depositCode == 0)
                {
                    depositCodeLabel.Text = "Please deposit the money.\n Transaction number: "
                        + selectedAccount.getNewTransaction().getTransNum() + "\n" + "Deposit amount: $"
                        + selectedAccount.getNewTransaction().getAmount() + "\n" + "To account: "
                        + selectedAccount.getAccountNum();
                }
                else if (depositCode == 1)
                {
                    depositCodeLabel.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                        + "Please select another account.";
                }
                else if (depositCode == 2)
                {
                    depositCodeLabel.Text = "The amount will make the transactions of this account exceed the max limit $3000 for today.\n"
                        + "Please enter a smaller amount.";
                }
                deposit2TableLayoutPanel.Visible = false;
                depositCodeTableLayoutPanel.Visible = true;
            }
        }

        private void deposit2BackspaceButton_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text.Length <= 1)
                depositAmtLabel.Text = "0";
            else
                depositAmtLabel.Text = depositAmtLabel.Text.Substring(0, depositAmtLabel.Text.Length - 1);
        }

        private void deposit2CancelButton_Click(object sender, EventArgs e)
        {
            deposit2TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void depositCodeConfirmButton_Click(object sender, EventArgs e)
        {
            depositCodeTableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void depositAmtButton1_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "1";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "1";
        }

        private void depositAmtButton2_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "2";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "2";
        }

        private void depositAmtButton3_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "3";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "3";
        }

        private void depositAmtButton4_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "4";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "4";
        }

        private void depositAmtButton5_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "5";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "5";
        }

        private void depositAmtButton6_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "6";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "6";
        }

        private void depositAmtButton7_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "7";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "7";
        }

        private void depositAmtButton8_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "8";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "8";
        }

        private void depositAmtButton9_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "9";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "9";
        }

        private void depositAmtButton0_Click(object sender, EventArgs e)
        {
            if (depositAmtLabel.Text == "0")
                depositAmtLabel.Text = "0";
            else if (depositAmtLabel.Text.Length <= 3)
                depositAmtLabel.Text = depositAmtLabel.Text + "0";
        }

        //==================CHECK BALANCE==================

        private void check1SelectButton_Click(object sender, EventArgs e)
        {
            if (check1ListBox.SelectedIndex >= 0) //if item is selected change scene
            {
                check1TableLayoutPanel.Visible = false;
                check2TableLayoutPanel.Visible = true;
                selectedAccount = (Account)accountList[check1ListBox.SelectedIndex];
                check2Label.Text = "Account number: " + selectedAccount.getAccountNum() + 
                    "\nBalance: $" + selectedAccount.getBalance();
            }
        }

        private void check1BackButton_Click(object sender, EventArgs e)
        {
            check1TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void check2ConfirmButton_Click(object sender, EventArgs e)
        {
            check2TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        //==================TRANSFER==================

        private void transfer1SelectButton_Click(object sender, EventArgs e)
        {
            if (transfer1ListBox.SelectedIndex >= 0) //if item is selected change scene
            {
                selectedAccount = (Account)accountList[transfer1ListBox.SelectedIndex];
                if (selectedAccount.checkDailyTransaction() == false)
                {
                    errorLabel.Text = "Error: This account has exceeded its daily transaction limit";
                    transfer1TableLayoutPanel.Visible = false;
                    errorTableLayoutPanel.Visible = true;
                }
                else
                {
                    transfer2ListBox.Items.Clear();

                    Account tempAccount;
                    Console.WriteLine("number of account: " + accountList.Count);
                    for (int i = 0; i < accountList.Count; i++)
                    {
                        tempAccount = (Account)accountList[i];
                        transfer2ListBox.Items.Add(tempAccount.getAccountNum());
                    }

                    transfer1TableLayoutPanel.Visible = false;
                    transfer2TableLayoutPanel.Visible = true;
                }
            }
        }

        private void transfer1CancelButton_Click(object sender, EventArgs e)
        {
            transfer1TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void transfer2SelectButton_Click(object sender, EventArgs e)
        {
            if (transfer2ListBox.SelectedIndex >= 0) //if item is selected change scene
            {
                selectedAccount2 = (Account)accountList[transfer2ListBox.SelectedIndex];
                if (selectedAccount2.checkDailyTransaction() == false)
                {
                    errorLabel.Text = "Error: This account has exceeded its daily transaction limit";
                    transfer2TableLayoutPanel.Visible = false;
                    errorTableLayoutPanel.Visible = true;
                }
                else if(selectedAccount2.getAccountNum() == selectedAccount.getAccountNum())
                {
                    errorLabel.Text = "Error: You can't transfer from an account to itself";
                    transfer2TableLayoutPanel.Visible = false;
                    errorTableLayoutPanel.Visible = true;
                }
                else
                {
                    transfer2TableLayoutPanel.Visible = false;
                    transfer3TableLayoutPanel.Visible = true;
                    transferAmtLabel.Text = "0";
                }
            }
        }

        private void transfer2CancelButton_Click(object sender, EventArgs e)
        {
            transfer2TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void transfer3SubmitButton_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text != "0")
            {
                double amount = Double.Parse(transferAmtLabel.Text);
                transferCode = selectedAccount.transferMoney(amount, selectedAccount, selectedAccount2);
                
                if (transferCode == 0)
                {
                    transferCodeLabel.Text = "Transfer successful!\n Transaction number: "
                        + selectedAccount.getNewTransaction().getTransNum() + "\n" + "Transfer amount: $"
                        + selectedAccount.getNewTransaction().getAmount() + "\n" + "From account:"
                        + selectedAccount.getAccountNum() + "\n" + "To account: "
                        + selectedAccount2.getAccountNum();
                }
                else if (transferCode == 1)
                {
                    transferCodeLabel.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                        + "Please select another account.";
                }
                else if (transferCode == 2)
                {
                    transferCodeLabel.Text = "The amount will make the transactions of this account exceed the max limit $3000 for today.\n"
                        + "Please enter a smaller amount.";
                }
                else if (transferCode == 3)
                {
                    transferCodeLabel.Text = "The amount you entered is greater than the balance of the selected account.\n"
                        + "Please enter a smaller amount.";
                }
                else if (transferCode == 4)
                {
                    transferCodeLabel.Text = "The machince doesn't have enough cash for your withdrawal.\n"
                        + "Please enter a smaller amount.";
                }

                transfer3TableLayoutPanel.Visible = false;
                transferCodeTableLayoutPanel.Visible = true;
            }
        }

        private void transfer3BackspaceButton_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text.Length <= 1)
                transferAmtLabel.Text = "0";
            else
                transferAmtLabel.Text = transferAmtLabel.Text.Substring(0, transferAmtLabel.Text.Length - 1);
        }

        private void transfer3CancelButton_Click(object sender, EventArgs e)
        {
            transfer3TableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void transferCodeConfirmButton_Click(object sender, EventArgs e)
        {
            transferCodeTableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }

        private void transferAmtButton1_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "1";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "1";
        }

        private void transferAmtButton2_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "2";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "2";
        }

        private void transferAmtButton3_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "3";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "3";
        }

        private void transferAmtButton4_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "4";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "4";
        }

        private void transferAmtButton5_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "5";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "5";
        }

        private void transferAmtButton6_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "6";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "6";
        }

        private void transferAmtButton7_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "7";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "7";
        }

        private void transferAmtButton8_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "8";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "8";
        }

        private void transferAmtButton9_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "9";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "9";
        }

        private void transferAmtButton0_Click(object sender, EventArgs e)
        {
            if (transferAmtLabel.Text == "0")
                transferAmtLabel.Text = "0";
            else if (transferAmtLabel.Text.Length <= 3)
                transferAmtLabel.Text = transferAmtLabel.Text + "0";
        }

        //==================ERROR PAGE==================

        private void errorConfirmButton_Click(object sender, EventArgs e)
        {
            errorTableLayoutPanel.Visible = false;
            menuTableLayoutPanel.Visible = true;
        }
    }
}
