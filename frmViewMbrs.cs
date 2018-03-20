using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemberHeaven //Kodat av Sebastian Sabel och Kabrini Sarkis, DE11, Högskolan i Borås
{
    public partial class frmViewMbrs : frmBase //Form som hanterar visning av Members i DGV med sortering.
    {
        TECHNICAL.clsDB clsDB = new TECHNICAL.clsDB();

        public frmViewMbrs()
        {
            InitializeComponent();
        }

        private void frmViewMbrs_Load(object sender, EventArgs e) //Vad fönstret gör när det poppar upp är att ladda in alla Members i DGV.
        {
            dgvViewMbrs.DataSource = TECHNICAL.clsDB.dbConnect("SELECT * FROM Members");
        }

        private void btnSort_Click(object sender, EventArgs e) //Sorteringsfunktion utifrån SQL-sats på Namn.
        {
            dgvViewMbrs.DataSource = TECHNICAL.clsDB.dbConnect("SELECT * FROM Members ORDER BY Name");
        }

        private void button1_Click(object sender, EventArgs e) //Sorteringsfunktion utifrån SQL-sats på ID.
        {
            this.dgvViewMbrs.DataSource = TECHNICAL.clsDB.dbConnect("SELECT * FROM Members ORDER BY MemberID");

        }

        private void addMembersToolStripMenuItem_Click(object sender, EventArgs e) //I View-formet ska man även kunna få upp Add members/Remove members formet.
        {
            frmAddMbrs fam = new frmAddMbrs();
            fam.ShowDialog();
        }

        
    }
}
