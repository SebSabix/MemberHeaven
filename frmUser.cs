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
    public partial class frmUser : frmBase //Form som hanterar User-skapande.
    {
        TECHNICAL.clsDB clsDB = new TECHNICAL.clsDB();
        LOGICAL.clsValidation clsVal = new LOGICAL.clsValidation();

        public frmUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) //Kod som körs om man klickar Save.
        {
            string controlCheck = clsVal.BoxValidation(txtUser.Text);
            string controlCheck2 = clsVal.BoxValidation(txtPass.Text);

            if (controlCheck == "WRONG" || controlCheck2 == "WRONG") //Om textBoxar är tomma eller bara en textBox har värden inmatade.
            {
                MessageBox.Show("Enter both Username and Password!");

            }

            else
            {
                clsDB.InsertStuff(); //Hämtar metod från clsDB.

                SqlCeCommand comm = new SqlCeCommand();
                comm.Connection = TECHNICAL.clsDB.conn;
                comm.CommandText = "INSERT INTO Users(Username, Password) VALUES(@Username, @Password)";
                comm.Parameters.AddWithValue("@Username", txtUser.Text);
                comm.Parameters.AddWithValue("@Password", txtPass.Text);

                try
                {
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Kontakta IT-support");
                }

                MessageBox.Show(txtUser.Text + " added. Now simply close the windows and login!", "Members");
                txtUser.Clear();
                txtPass.Clear();
            }
        }

        private void btnClr_Click(object sender, EventArgs e) //Tömmer textBoxar.
        {
            txtUser.Clear();
            txtPass.Clear();
        }
    }
}
