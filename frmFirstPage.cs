using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace MemberHeaven //Kodat av Sebastian Sabel och Kabrini Sarkis, DE11, Högskolan i Borås
{
    public partial class frmFirstPage : frmBase //Form med ingen egentlig funktionalitet, enbart startsida med information och menu-strip.
    {
        TECHNICAL.clsDB clsDB = new TECHNICAL.clsDB(); //Association till clsDB för att hämta metod.
        

        public frmFirstPage()
        {
            InitializeComponent();                  
        }

        private void frmFirstPage_Load(object sender, EventArgs e)
        {

        }

        private void addMembersToolStripMenuItem_Click(object sender, EventArgs e) //I menu-strip öppnar detta tryck upp Add members/Remove members vyn.
        {
            frmAddMbrs frmAdd = new frmAddMbrs();
            frmAdd.ShowDialog();
        }   

        private void viewMembersToolStripMenuItem_Click(object sender, EventArgs e) //I menu-strip öppnar detta tryck upp View Members-vyn.
        {
            frmViewMbrs frmView = new frmViewMbrs();
            frmView.ShowDialog();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //Vad som sker om man klickar på Close.
        {
            DialogResult dialogResult = MessageBox.Show("Vill du verkligen stänga ned fönstret?", "MemberHeaven", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();

            }
            else if (dialogResult == DialogResult.No)
            {
                //Gör inget, stanna kvar i programmet.            
            }  
        }

        
    }
}
