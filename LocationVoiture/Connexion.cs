using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationVoiture
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void SeConnecterBtn_Click(object sender, EventArgs e)
        {
            if(NomTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Information Incomplete!!!");
            }
            else
            {
                if(NomTb.Text == "admin" && PassTb.Text == "admin")
                {
                    Menu Obj = new Menu();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Le nom d'utilisateur ou/et le mot de passe est/sont Incorrect(s)!!!");
                }
            }
        }
    }
}
