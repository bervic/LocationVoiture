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
    public partial class Chargement : Form
    {
        public Chargement()
        {
            InitializeComponent();
            timer1.Start();
        }
        int Debut = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Debut += 1;
            progresse.Value = Debut;
            PourcentageLbl.Text = Debut + "%";
            if(progresse.Value == 100)
            {
                progresse.Value = 0;
                timer1.Stop();
                Connexion Obj = new Connexion();
                Obj.Show();
                this.Hide();
            }
        }

    }
}
