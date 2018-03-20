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
    public partial class frmAddMbrs : frmBase //Form som hanterar skapande av Members men även borttagning av dem.
    {
        TECHNICAL.clsDB clsDB = new TECHNICAL.clsDB(); //Hittar till klassen clsDB som hanterar koppling till databas.

        public frmAddMbrs()
        {
            InitializeComponent();
        }

        private void frmAddMbrs_Load(object sender, EventArgs e) //Vid öppning av form tömmer loaden alla txtBoxes.
        {
            tbName.Clear();
            txtphon.Clear();
            txtstr.Clear();
            txtpos.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || txtstr.Text == "" || txtpos.Text == "" || cbcity.Text == "" || txtphon.Text == "") //Om någon eller några textBoxar är tomma.
            {
                MessageBox.Show("You need to insert all values to save a member!"); //Ger den oss ett felmeddelande.
            
            }
            else //Annars sparas en member korrekt.
	        {
	            clsDB.InsertStuff(); //Hämtar metod från clsDB.

                SqlCeCommand comm = new SqlCeCommand();
                comm.Connection = TECHNICAL.clsDB.conn;
                comm.CommandText = "INSERT INTO Members(Name, StreetName, PostCode, City, PhoneNumber) VALUES(@Name, @StreetName, @PostCode, @City, @PhoneNumber)";
                comm.Parameters.AddWithValue("@Name", tbName.Text);
                comm.Parameters.AddWithValue("@StreetName", txtstr.Text);
                comm.Parameters.AddWithValue("@PostCode", txtpos.Text);
                comm.Parameters.AddWithValue("@City", cbcity.Text);
                comm.Parameters.AddWithValue("@PhoneNumber", txtphon.Text);

                try
                {
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Kontakta IT-support");


                }

                MessageBox.Show(tbName.Text + " added.", "Added"); //Ger oss ett meddelande att member är tillagd.
                tbName.Clear();
                txtphon.Clear();
                txtstr.Clear();
                txtpos.Clear();
	        }
        }

        private void viewMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewMbrs famv = new frmViewMbrs();
            famv.Show();
        }

        private void btRem_Click(object sender, EventArgs e) //Hanterar borttagning av en member. Notera! Denna borttagning kan endast göras på Namn/Name.
        {
            if (tbDel.Text != "") //Om textBox INTE är tom.
            {
                clsDB.InsertStuff(); //Hämtar metod från clsDB.

                SqlCeCommand del = new SqlCeCommand();
                del.Connection = TECHNICAL.clsDB.conn;

                del.CommandText = "DELETE FROM Members WHERE Name='" + tbDel.Text + "' AND MemberID ='"+ tbID.Text +"'"; //SQL-sats som tar bort medlem vid namn.

                MessageBox.Show("Member deleted!");

                try
                {
                    del.ExecuteNonQuery();
                }
                catch
                {

                    MessageBox.Show("Contact IT-support!");
                }
            }
            else
            {
                MessageBox.Show("No member deleted! Check if member exists or if you perchance typed in wrong!"); //Om man skrivit in fel eller inget alls i textBoxen.

            }

        }

        private void lblDel_MouseHover(object sender, EventArgs e) //Lite extra information.
        {
            MessageBox.Show("In order to know which member to delete, simply open up the View members form in the Menu Strip.");
        }

    }
}
