using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        private HashSet<string> conjuntoA = new HashSet<string>();
        private HashSet<string> conjuntoB = new HashSet<string>();
        private HashSet<string> unionAB = new HashSet<string>();
        private HashSet<string> interseccionAB = new HashSet<string>();
        private HashSet<string> diferenciaAB = new HashSet<string>();
        private HashSet<string> diferenciaBA = new HashSet<string>();

        ConjuntoDoble conjunto;

        public Form2()
        {
            InitializeComponent();
        }

        public void obtenerElementosConjuntoA()
        {
            for (int i = 0; i < this.txtConjuntoA.Lines.Count(); i++)
            {
                this.conjuntoA.Add(this.txtConjuntoA.Lines[i]);
            }
        }

        public void obtenerElementosConjuntoB()
        {
            for (int i = 0; i < this.txtConjuntoB.Lines.Count(); i++)
            {
                this.conjuntoB.Add(this.txtConjuntoB.Lines[i]);
            }
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            obtenerElementosConjuntoA();
            obtenerElementosConjuntoB();

            this.txtConjuntoA.Enabled = false;
            this.txtConjuntoB.Enabled = false;

            conjunto = new ConjuntoDoble(this.conjuntoA, this.conjuntoB);
            unionAB = conjunto.operarUnion();
            interseccionAB = conjunto.operarInterseccion();
            diferenciaAB = conjunto.operarDiferenciaAB();
            diferenciaBA = conjunto.operarDiferenciaBA();
            igualdades();
            mostrarResultados();
            this.btnOperar.Enabled = false;
        }

        public void mostrarResultados()
        {


            if (unionAB.Count == 0)
            {
                this.txtUnionAB.Text = "Conjunto Vacio";

            }
            else
            {
                foreach (string elemento in unionAB)
                {
                    this.txtUnionAB.Text += (elemento + ", ");
                }
            }

            if (interseccionAB.Count == 0)
            {
                this.txtInterseccionAB.Text = "Conjunto Vacio";
            }
            else
            {
                foreach (string elemento in interseccionAB)
                {
                    this.txtInterseccionAB.Text += (elemento + ", ");
                }
            }

            if (diferenciaAB.Count == 0)
            {
                this.txtDiferenciaAB.Text = "Conjunto Vacio";
            }
            else
            {
                foreach (string elemento in diferenciaAB)
                {
                    this.txtDiferenciaAB.Text += (elemento + ", ");
                }
            }

            if (diferenciaBA.Count == 0)
            {
                this.txtDiferenciaBA.Text = "Conjunto Vacio";
            }
            else
            {
                foreach (string elemento in diferenciaBA)
                {
                    this.txtDiferenciaBA.Text += (elemento + ", ");
                }
            }



            if (conjuntoA.SetEquals(conjuntoB))
            {
                label4.Text = "Los elementos de ambos conjuntos son iguales";
            }
            else
            {

                label4.Text = "Los elementos de ambos conjuntos son diferentes";
            }





        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            this.txtConjuntoA.Clear();
            this.txtConjuntoB.Clear();
            this.txtUnionAB.Clear();
            this.txtInterseccionAB.Clear();
            this.txtDiferenciaAB.Clear();
            this.txtDiferenciaBA.Clear();
            this.txtConjuntoA.Enabled = true;
            this.txtConjuntoB.Enabled = true;
            this.btnOperar.Enabled = true;
            this.conjuntoA.Clear();
            this.conjuntoB.Clear();
            this.unionAB.Clear();
            this.txtConjuntoA.Focus();
            this.label4.Text = "";
            this.txtPotenciaA.Clear();
            this.txtPotenciaB.Clear();
            txtTamañoA.Text = "";
            txtTamañoB.Text = "";
        }

        void igualdades()
        {
            int diferentesA = 0;
            int similitudes = 0;
            int diferentesB = 0;
            String[] difA = new string[20];
            String[] difB = new string[20];

            for (int i = 0; i < this.conjuntoA.Count; i++)
            {
                Boolean igualdad = false;
                for (int j = 0; j < i; j++)
                {
                    if (conjuntoA.ElementAt(i).Equals(conjuntoA.ElementAt(j)))
                    {
                        igualdad = true;
                    }
                }
                if (igualdad == false)
                {
                    difA[diferentesA] = conjuntoA.ElementAt(i);
                    diferentesA++;
                }
            }


            for (int i = 0; i < this.conjuntoB.Count; i++)
            {
                Boolean igualdad = false;
                for (int j = 0; j < i; j++)
                {
                    if (conjuntoB.ElementAt(i).Equals(conjuntoB.ElementAt(j)))
                    {
                        igualdad = true;
                    }
                }
                if (igualdad == false)
                {
                    difB[diferentesB] = conjuntoB.ElementAt(i);
                    diferentesB++;
                }
            }

            for (int i = 0; i < diferentesA; i++)
            {
                Boolean igualdad = false;
                for (int j = 0; j < diferentesB; j++)
                {
                    if (difA.ElementAt(i) != null)
                    {
                        if (difA.ElementAt(i) != null)
                        {
                            if (difA.ElementAt(i).Equals(difB.ElementAt(j)))
                            {
                                igualdad = true;
                            }
                        }
                    }

                }
                if (igualdad == true)
                {
                    similitudes++;
                }
            }

            if (diferentesB == diferentesA && diferentesA == similitudes)
            {
                txtPotenciaA.Text = "Los conjuntos son IGUALES";
            }
            else
            {
                txtPotenciaA.Text = "Los conjuntos NO son IGUALES";
            }

            txtTamañoA.Text = " " + diferentesA;
            txtTamañoB.Text = " " + diferentesB;

            String A2 = "(0)";
            if (diferentesA == 1)
            {
                A2 = "(0) (" + difA[0] + ")";
            }
            if (diferentesA == 2)
            {
                A2 = "(0) (" + difA[0] + "," + difA[1] + ") (" + difA[0] + ") (" + difA[1] + ")";
            }
            if (diferentesA == 3)
            {
                A2 = "(0) (" + difA[0] + "," + difA[1] + "," + difA[2] + ") (" + difA[0] + "," + difA[1] + ") (" + difA[0] + "," + difA[2] + ") (" + difA[1] + "," + difA[2] + ") (" + difA[0] + ") (" + difA[1] + ") (" + difA[2] + ")";
            }

            if (diferentesA == 4)
            {
                A2 = "(0) (" + difA[0] + "," + difA[1] + "," + difA[2] + "," + difA[3] + ") (" + difA[0] + "," + difA[1] + "," + difA[2] + ")  (" + difA[0] + "," + difA[1] + "," + difA[3] + ") (" + difA[0] + "," + difA[2] + "," + difA[3] + ") (" + difA[1] + "," + difA[2] + "," + difA[3] + ") (" + difA[0] + "," + difA[1] + ") (" + difA[0] + "," + difA[2] + ") (" + difA[0] + "," + difA[3] + ") (" + difA[1] + "," + difA[2] + ") (" + difA[1] + "," + difA[3] + ") (" + difA[2] + "," + difA[3] + ") (" + difA[0] + ") (" + difA[1] + ") (" + difA[2] + ") (" + difA[3] + ")";
            }

            if (diferentesA == 5)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          //  11
                A2 = "(0) (" + difA[0] + "," + difA[1] + "," + difA[2] + "," + difA[3] + "," + difA[4] + ") (" + difA[0] + "," + difA[1] + "," + difA[2] + "," + difA[3] + ")  (" + difA[0] + "," + difA[1] + "," + difA[2] + "," + difA[4] + ") (" + difA[0] + "," + difA[1] + "," + difA[3] + "," + difA[4] + ") (" + difA[0] + "," + difA[2] + "," + difA[3] + "," + difA[4] + ") (" + difA[1] + "," + difA[2] + "," + difA[3] + "," + difA[4] + ") (" + difA[0] + "," + difA[1] + "," + difA[2] + ") (" + difA[0] + "," + difA[1] + "," + difA[3] + ") (" + difA[0] + "," + difA[1] + "," + difA[4] + ") (" + difA[0] + "," + difA[2] + "," + difA[3] + ") (" + difA[0] + "," + difA[2] + "," + difA[4] + ") (" + difA[0] + "," + difA[3] + "," + difA[4] + ") (" + difA[1] + "," + difA[2] + "," + difA[3] + ") (" + difA[1] + "," + difA[2] + "," + difA[4] + ") (" + difA[1] + "," + difA[3] + "," + difA[4] + ") (" + difA[2] + "," + difA[3] + "," + difA[4] + ") (" + difA[0] + "," + difA[1] + ") (" + difA[0] + "," + difA[2] + ") (" + difA[0] + "," + difA[3] + ") (" + difA[0] + "," + difA[4] + ") (" + difA[1] + "," + difA[2] + ") (" + difA[1] + "," + difA[3] + ") (" + difA[1] + "," + difA[4] + ") (" + difA[2] + "," + difA[3] + ") (" + difA[2] + "," + difA[4] + ") (" + difA[3] + "," + difA[4] + ") (" + difA[0] + ") (" + difA[1] + ") (" + difA[2] + ") (" + difA[3] + ") (" + difA[4] + ")";
            }
            txtPotenciaA.Text = A2;
            //MessageBox.Show("Diferenes en A: " + diferentesA + " -- Diferentes B: " + diferentesB + " -- Similitudes: " + similitudes);
            String B2 = "(0)";
            if (diferentesB == 1)
            {
                B2 = "(0) (" + difB[0] + ")";
            }
            if (diferentesB == 2)
            {
                B2 = "(0) (" + difB[0] + "," + difB[1] + ") (" + difB[0] + ") (" + difB[1] + ")";
            }
            if (diferentesB == 3)
            {
                B2 = "(0) (" + difB[0] + "," + difB[1] + "," + difB[2] + ") (" + difB[0] + "," + difB[1] + ") (" + difB[0] + "," + difB[2] + ") (" + difB[1] + "," + difB[2] + ") (" + difB[0] + ") (" + difB[1] + ") (" + difB[2] + ")";
            }

            if (diferentesB == 4)
            {
                B2 = "(0) (" + difB[0] + "," + difB[1] + "," + difB[2] + "," + difB[3] + ") (" + difB[0] + "," + difB[1] + "," + difB[2] + ")  (" + difB[0] + "," + difB[1] + "," + difB[3] + ") (" + difB[0] + "," + difB[2] + "," + difB[3] + ") (" + difB[1] + "," + difB[2] + "," + difB[3] + ") (" + difB[0] + "," + difB[1] + ") (" + difB[0] + "," + difB[2] + ") (" + difB[0] + "," + difB[3] + ") (" + difB[1] + "," + difB[2] + ") (" + difB[1] + "," + difB[3] + ") (" + difB[2] + "," + difB[3] + ") (" + difB[0] + ") (" + difB[1] + ") (" + difB[2] + ") (" + difB[3] + ")";
            }

            if (diferentesB == 5)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          //  11
                B2 = "(0) (" + difB[0] + "," + difB[1] + "," + difB[2] + "," + difB[3] + "," + difB[4] + ") (" + difB[0] + "," + difB[1] + "," + difB[2] + "," + difB[3] + ")  (" + difB[0] + "," + difB[1] + "," + difB[2] + "," + difB[4] + ") (" + difB[0] + "," + difB[1] + "," + difB[3] + "," + difB[4] + ") (" + difB[0] + "," + difB[2] + "," + difB[3] + "," + difB[4] + ") (" + difB[1] + "," + difB[2] + "," + difB[3] + "," + difB[4] + ") (" + difB[0] + "," + difB[1] + "," + difB[2] + ") (" + difB[0] + "," + difB[1] + "," + difB[3] + ") (" + difB[0] + "," + difB[1] + "," + difB[4] + ") (" + difB[0] + "," + difB[2] + "," + difB[3] + ") (" + difB[0] + "," + difB[2] + "," + difB[4] + ") (" + difB[0] + "," + difB[3] + "," + difB[4] + ") (" + difB[1] + "," + difB[2] + "," + difB[3] + ") (" + difB[1] + "," + difB[2] + "," + difB[4] + ") (" + difB[1] + "," + difB[3] + "," + difB[4] + ") (" + difB[2] + "," + difB[3] + "," + difB[4] + ") (" + difB[0] + "," + difB[1] + ") (" + difB[0] + "," + difB[2] + ") (" + difB[0] + "," + difB[3] + ") (" + difB[0] + "," + difB[4] + ") (" + difB[1] + "," + difB[2] + ") (" + difB[1] + "," + difB[3] + ") (" + difB[1] + "," + difB[4] + ") (" + difB[2] + "," + difB[3] + ") (" + difB[2] + "," + difB[4] + ") (" + difB[3] + "," + difB[4] + ") (" + difB[0] + ") (" + difB[1] + ") (" + difB[2] + ") (" + difB[3] + ") (" + difB[4] + ")";
            }
            txtPotenciaB.Text = B2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
    
}
