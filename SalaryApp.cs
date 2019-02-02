using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKPO_KP
{
    public partial class SalaryApp : Form
    {
        public SalaryApp()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserInfo uf = new UserInfo();
            uf.ShowDialog();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserAccess ua = new UserAccess();
            ua.ShowDialog();
        }

        private void linkSysParameters_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SysParameters sysp = new SysParameters();
            sysp.ShowDialog();
        }

        private void linkBankAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BankAccount ba = new BankAccount();
            ba.ShowDialog();
        }

        private void linkEmployees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Employee empl = new Employee();
            empl.ShowDialog();
        }

        private void linkEmplBankAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EmplBankAccount eba = new EmplBankAccount();
            eba.ShowDialog();
        }

        private void linkPaymTrans_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymTrans pt = new PaymTrans();
            pt.ShowDialog();
        }

        private void SalaryApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
