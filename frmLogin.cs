using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace MemberHeaven //Kodat av Sebastian Sabel och Kabrini Sarkis, DE11, Högskolan i Borås
{
    public partial class frmLogin : frmBase //Form som hanterar Login-funktion.
    {
        TECHNICAL.clsDB db = new TECHNICAL.clsDB(); //Hämtar connection string från clsDB.
        LOGICAL.clsValidation clsVal = new LOGICAL.clsValidation(); //Gör det möjligt att använda vår metod för validering från clsValidering.

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLog_Click(object sender, EventArgs e) //Vad som sker om man klickar Login.
        {

            string controlCheck = clsVal.BoxValidation(txtUse.Text); //En variabel skapas som hämtar metod för validering.
            string controlCheck2 = clsVal.BoxValidation(txtPas.Text); //En variabel skapas som hämtar metod för validering.

            if (controlCheck == "WRONG" || controlCheck2 == "WRONG") //Om textBoxar är tomma eller bara en textBox har värden inmatade.
            {
                MessageBox.Show("Enter both Username and Password!"); //Ge felmeddelande.
         
            }

            else //Annars körs denna kod som loggar in en User.
            {
                db.InsertStuff(); //Hämta metod från clsDB.

                SqlCeCommand comm = new SqlCeCommand();
                comm.Connection = TECHNICAL.clsDB.conn;

                string cmdStr = "select count(*) from Users where Username='" + txtUse.Text + "'";
                SqlCeCommand CheckUser = new SqlCeCommand(cmdStr, TECHNICAL.clsDB.conn);

                int temp = Convert.ToInt32(CheckUser.ExecuteScalar().ToString());

                if (temp == 1)
                {
                    string cmdStr2 = "select Password from Users where Username='" + txtUse.Text + "'";
                    SqlCeCommand pass = new SqlCeCommand(cmdStr2, TECHNICAL.clsDB.conn);
                    string password = pass.ExecuteScalar().ToString();
                    TECHNICAL.clsDB.conn.Close();

                    if (password == txtPas.Text)
                    {
                        frmFirstPage frmPg = new frmFirstPage();
                        frmPg.ShowDialog();


                    }
                    else if (password != txtPas.Text)
                    {
                        MessageBox.Show("You have inserted the wrong password or wrong username!");


                    }
                } 
            }
        }

        private void lLblCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Ger oss in i Create User-formet.
        {
            frmUser frmUs = new frmUser();
            frmUs.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e) // Tömmer textBoxes.
        {
            txtPas.Clear();
            txtUse.Clear();
        }
    }
}
