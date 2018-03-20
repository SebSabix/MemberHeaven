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
    public partial class frmBase : Form //Base-formet som gör att alla andra forms härifrån kan ärva.
    {
        public frmBase()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) //Trevlig close-form kod.
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit what you're doing here?", "Member Heaven", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();

            }
            else if (dialogResult == DialogResult.No)
            {
                //Gör så att man stannar kvar i programmet.          
            }
        }

        private void frmBase_Load(object sender, EventArgs e) //Vad som skall ärva igenom i alla andra former vid öppnande av dem.
        {
            
            this.Size = new Size(1000, 600); 
            this.MaximumSize = new Size(1000, 600); 
            this.MinimumSize = new Size(1000, 600); 
            this.AutoScroll = true;
            this.Text = "Member Heaven"; 

            foreach (Control x in this.Controls) //Hanterar så att varje kontroll i alla former ärver färg.
            {
                if (x is LinkLabel) 
                {
                    ((LinkLabel)x).LinkColor = Color.Red;
                }
                else if (x is TextBox) 
                {
                    ((TextBox)x).BackColor = Color.Cornsilk;

                }
                else if (x is Button) 
                {
                    ((Button)x).BackColor = Color.FloralWhite;


                }
                else if (x is DataGridView) 
                {
                    ((DataGridView)x).AllowUserToResizeRows = false;
                    ((DataGridView)x).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    
                }
            }
        }

    }
}

