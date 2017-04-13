using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprendendoStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("arquivo.txt"))
            {
                using (Stream entrada = File.Open("arquivo.txt", FileMode.Open))
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    string conteudo = leitor.ReadToEnd();
                    textBox1.AppendText(conteudo);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Stream saida = File.Open("arquivo.txt", FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(saida))
            {
                IEnumerable pessoas = from p in textBox1.Lines
                                        select new Pessoa { nome = p, tamanhoNome = p.Length };

                foreach (Pessoa pessoa in pessoas)
                {
                    escritor.Write(pessoa.nome + " - " + pessoa.tamanhoNome);
                }
            }
        }
    }

    public class Pessoa
    {
        public string nome { get; set; }
        public int tamanhoNome { get; set; }

    }
}