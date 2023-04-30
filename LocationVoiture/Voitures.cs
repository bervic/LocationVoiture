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
    public partial class Voitures : Form
    {
        Main Con;
        public Voitures()
        {
            InitializeComponent();
            Con = new Main();
            AfficherVoiture();
        }

        private void AfficherVoiture()
        {
            string Requete = "select * from VoitureTbl";
            VoituresListe.DataSource = Con.RecupererData(Requete);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EnregistrerBtn_Click(object sender, EventArgs e)
        {
            if(PlaqueTb.Text == "" || ModeleTb.Text == "" || MarqueCb.SelectedIndex == -1 || PrixTb.Text == "" || StatutCb.SelectedIndex == -1)
            {
                MessageBox.Show("Information Incomplete!!!");
            }
            else
            {
                try
                {
                    string Plaque = PlaqueTb.Text;
                    string Marque = MarqueCb.SelectedItem.ToString();
                    string Modele = ModeleTb.Text;
                    string Statut = StatutCb.SelectedItem.ToString();
                    int Prix = Convert.ToInt32(PrixTb.Text);

                    string Req = "insert into VoitureTbl values('{0}', '{1}', '{2}', '{3}', {4})";
                    Req = string.Format(Req, Plaque, Marque, Modele, Statut, Prix);
                    Con.EnvoyerData(Req);
                    AfficherVoiture();
                    MessageBox.Show("Véhicule Enregistré!!!");
                    PlaqueTb.Text = "";
                    ModeleTb.Text = "";
                    MarqueCb.SelectedIndex = -1;
                    PrixTb.Text = "";
                    StatutCb.SelectedIndex = -1;


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        string Cle = "";
        private void VoituresListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MarqueCb.Text = VoituresListe.SelectedRows[0].Cells[1].Value.ToString();
            ModeleTb.Text = VoituresListe.SelectedRows[0].Cells[2].Value.ToString();
            StatutCb.Text = VoituresListe.SelectedRows[0].Cells[3].Value.ToString();
            PrixTb.Text = VoituresListe.SelectedRows[0].Cells[4].Value.ToString();
            if(ModeleTb.Text == "")
            {
                Cle = "";
            }
            else
            {
                Cle = VoituresListe.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            if (Cle == "" || ModeleTb.Text == "" || MarqueCb.SelectedIndex == -1 || PrixTb.Text == "" || StatutCb.SelectedIndex == -1)
            {
                MessageBox.Show("Information Incomplete!!!");
            }
            else
            {
                try
                {
                    string Plaque = PlaqueTb.Text;
                    string Marque = MarqueCb.SelectedItem.ToString();
                    string Modele = ModeleTb.Text;
                    string Statut = StatutCb.SelectedItem.ToString();
                    int Prix = Convert.ToInt32(PrixTb.Text);

                    string Req = "update VoitureTbl set Marque = '{0}', Modele = '{1}', Statut = '{2}', Prix = {3} where Numplaque = '{4}')";
                    Req = string.Format(Req, Marque, Modele, Statut, Prix, Cle);
                    Con.EnvoyerData(Req);
                    AfficherVoiture();
                    MessageBox.Show("Véhicule Modifié!!!");
                    PlaqueTb.Text = "";
                    ModeleTb.Text = "";
                    MarqueCb.SelectedIndex = -1;
                    PrixTb.Text = "";
                    StatutCb.SelectedIndex = -1;


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            if (Cle == "")
            {
                MessageBox.Show("Information Incomplete!!!");
            }
            else
            {
                try
                {
                    string Plaque = PlaqueTb.Text;
                    string Marque = MarqueCb.SelectedItem.ToString();
                    string Modele = ModeleTb.Text;
                    string Statut = StatutCb.SelectedItem.ToString();
                    int Prix = Convert.ToInt32(PrixTb.Text);

                    string Req = "delete from VoitureTbl where Numplaque = '{0}')";
                    Req = string.Format(Req, Cle);
                    Con.EnvoyerData(Req);
                    AfficherVoiture();
                    MessageBox.Show("Véhicule Supprimé!!!");
                    PlaqueTb.Text = "";
                    ModeleTb.Text = "";
                    MarqueCb.SelectedIndex = -1;
                    PrixTb.Text = "";
                    StatutCb.SelectedIndex = -1;


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void RetourLbl_Click(object sender, EventArgs e)
        {
            Menu Obj = new Menu();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Menu Obj = new Menu();
            Obj.Show();
            this.Hide();
        }
    }
}
