using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class frmAhorcado : Form
    {
        int intentos = 3;
        int palabra;
        int x = 10;
        int tamaño;
        string elegida;
        int comprobación = 0;
        int ganar;

        string[] palabras = new string[12];
        TextBox[] aryTxb = new TextBox[10];
        char[] aryPalabra;

        Random rdmPalabra = new Random();

        public frmAhorcado()
        {
            InitializeComponent();

            pcbFace.Visible = false;
            pcbCuerpo.Visible = false;
            pcbBase.Visible = false;

            palabras[0] = audiToolStripMenuItem.Text;
            palabras[1] = fordToolStripMenuItem.Text;
            palabras[2] = nissanToolStripMenuItem.Text;
            palabras[3] = azaleaToolStripMenuItem.Text;
            palabras[4] = girasolToolStripMenuItem.Text;
            palabras[5] = lotoToolStripMenuItem.Text;
            palabras[6] = irapuatoToolStripMenuItem.Text;
            palabras[7] = salamancaToolStripMenuItem.Text;
            palabras[8] = yuririaToolStripMenuItem.Text;
            palabras[9] = manzanaToolStripMenuItem.Text;
            palabras[10] = peraToolStripMenuItem.Text;
            palabras[11] = mangoToolStripMenuItem.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            palabra = rdmPalabra.Next(0, 12);

            tamaño = palabras[palabra].Length;

            for (int i = 0; i < tamaño; i++)
            {
                aryTxb[i] = new TextBox();
                aryTxb[i].Width = 20;
                aryTxb[i].Height = 20;
                aryTxb[i].Enabled = false;
                aryTxb[i].Location = new Point(x, 70);

                this.Controls.Add(aryTxb[i]);

                x = x + 25;
            }

            txbIntentos.Text = Convert.ToString(intentos);

            elegida = palabras[palabra];
            elegida  = elegida.ToLower();
            aryPalabra = elegida.ToCharArray();

            MessageBox.Show(palabras[palabra]);

        }

        private void pcbCara_Click(object sender, EventArgs e)
        {

        }

        private void irapuatoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmAhorcado_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void frmAhorcado_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmAhorcado_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txbLetra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rdbCompleta.Checked == false)
                {
                    for (int i = 0; i < tamaño; i++)
                    {
                        if (aryPalabra[i] == Convert.ToChar(txbLetra.Text))
                        {
                            if (txbLetra.Text != "0")
                            {
                                aryTxb[i].Text = Convert.ToString(aryPalabra[i]);
                                aryPalabra[i] = '0';
                                comprobación++;
                                ganar++;
                            }
                            
                        }
                    }
                    if (comprobación == 0)
                    {
                        intentos--;
                        switch (intentos)
                        {
                            case 2:
                                {
                                    pcbFace.Visible = true;
                                }
                                break;
                            case 1:
                                {
                                    pcbCuerpo.Visible = true;
                                }
                                break;
                            case 0:
                                {
                                    pcbBase.Visible = true;
                                    MessageBox.Show("Has Perdido", "Wasted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txbLetra.Enabled = false;
                                }
                                break;
                            default:
                                break;
                        }
                        
                    }
                    else if (ganar == tamaño)
                    {
                        MessageBox.Show("Has Ganado", "Mission Passed + Respect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbLetra.Enabled = false;
                    }

                    comprobación = 0;
                    txbLetra.Text = "";
                    txbIntentos.Text = Convert.ToString(intentos);
                }
            }
        }

        private void txbCompleta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbCompleta.Text == elegida)
                {
                    tmrCompleta.Stop();

                    for (int i = 0; i < tamaño; i++)
                    {
                        aryTxb[i].Text = Convert.ToString(aryPalabra[i]);
                    }
                    
                    MessageBox.Show("Has Ganado", "Mission Passed + Respect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbLetra.Enabled = false;
                    txbCompleta.Enabled = false;

                    
                }
                else
                {
                    tmrCompleta.Stop();
                    pcbFace.Visible = true;
                    pcbCuerpo.Visible = true;
                    pcbBase.Visible = true;
                    txbIntentos.Text = "0";
                    MessageBox.Show("Has Perdido", "Wasted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbLetra.Enabled = false;
                    txbCompleta.Enabled = false;
                }
                txbCompleta.Text = "";
            }
        }

        private void rdbCompleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompleta.Checked == true)
            {
                tmrCompleta.Start();
                txbCompleta.Visible = true;
            } 
        }

        private void tmrCompleta_Tick(object sender, EventArgs e)
        {
            if (pgbCompleta.Value < 15)
            {
                pgbCompleta.Value++;
            }
            else if (pgbCompleta.Value == 15)
            {
                tmrCompleta.Stop();
                pcbFace.Visible = true;
                pcbCuerpo.Visible = true;
                pcbBase.Visible = true;
                MessageBox.Show("Has Perdido", "Wasted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbLetra.Enabled = false;
                txbCompleta.Enabled = false;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tamaño; i++)
            {
                this.Controls.Remove(aryTxb[i]);
            }

            pgbCompleta.Value = 0;

            pcbFace.Visible = false;
            pcbCuerpo.Visible = false;
            pcbBase.Visible = false;

            txbLetra.Enabled = true;
            txbCompleta.Enabled = true;
            txbCompleta.Visible = false;
            rdbCompleta.Checked = false;

            x = 10;
            intentos = 3;
            ganar = 0;
        }
    }
}