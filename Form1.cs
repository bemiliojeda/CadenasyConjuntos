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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un valor para cadena 1");
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Ingrese un valor para cadena 2");
            }
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Ingrese el algun valor para potencia");
            }
            else
            {
                string low = textBox1.Text.ToLower();
                low = low.Replace(" ", "");


                string cadena1 = textBox1.Text.Replace(" ", "");
                string cadena2 = textBox2.Text.Replace(" ", "");
                textBox3.Text = textBox1.Text + textBox2.Text;
                textBox5.Text = Convert.ToString(cadena1.Length);
                textBox6.Text = Convert.ToString(cadena2.Length);
                textBox7.Text = Convert.ToString(cadena1.Length + cadena2.Length);
                if (cadena1 == cadena2)
                {
                    textBox4.Text = "Son iguales";
                }
                else
                {
                    textBox4.Text = "No son iguales";
                }

                string repetida = "";
                for (int indice = 0; indice < Convert.ToInt32(textBox9.Text); indice++)
                {
                    repetida += cadena1;
                }

                textBox5.Text = Convert.ToString(cadena1.Length);
                textBox8.Text = repetida;


                //Sufijo
                int lcadena1 = Convert.ToInt32(cadena1.Length);
                int d = lcadena1 - 2;
                int f = 2;
                string sufijo = cadena1.Substring(lcadena1 - 1, 1);
                string caracter2;

                while (f <= lcadena1)
                {
                    caracter2 = cadena1.Substring(d, f);
                    sufijo = sufijo + "," + caracter2;
                    d--;
                    f++;
                }

                textBox10.Text = "ε, " + sufijo;

                //Prefijo
                //cu = cadena1

                int c = 2;
                string prefijo = cadena1.Substring(0, 1);
                string caracter;
                while (c <= lcadena1)
                {
                    caracter = cadena1.Substring(0, c);
                    prefijo = prefijo + ", " + caracter;
                    c++;
                }
                textBox11.Text = "ε, " + prefijo;

                //Subcadena
                string s1 = textBox1.Text;
                string s2 = textBox2.Text;

                if (s1.Contains(s2))
                {
                    textBox12.Text = "Verdadero";
                }
                else
                {
                    textBox12.Text = "Falso";
                }

                //Invertir cadena
                string c1 = textBox1.Text;
                string c2 = textBox2.Text;
                string Transponer(string cadena)
                {
                    string cadenaInvertida = "";
                    // Recorrer cadena letra por letra
                    foreach (char letra in cadena)
                    {
                        // Anteponer la letra a la cadena invertida
                        cadenaInvertida = letra + cadenaInvertida;
                    }
                    return cadenaInvertida;
                }
                textBox13.Text = Transponer(c1);
                textBox14.Text = Transponer(c2);

                //palindromo
                int i = 0, startchar, lastchar;

                char[] character = new char[100];
                character = low.ToCharArray();
                startchar = 0;
                lastchar = character.Length - 1;
                while (startchar < lastchar)
                {
                    if (character[startchar] == character[lastchar])
                    {
                        startchar++;
                        lastchar--;
                    }
                    else
                    {
                        textBox15.Text = "No es un Palindromo";
                        i = 2;
                        break;
                    }
                }
                if (i < 2)
                {
                    textBox15.Text = "Es un Palindromo";

                }
                else
                {
                    i = 0;
                }

                /////////////////////////////////////////
            }
        

    }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
