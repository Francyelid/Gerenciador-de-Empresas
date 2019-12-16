using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeEmpresas
{
    public partial class Form1 : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        INumber number;
        public Form1()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadCliente cliente = new CadCliente(gerenciaEmpresa,number);
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Carregando as configurações de numero sequencial e a classe gerenciadora
            //try
            //{
            //    number.numb = FileSaveRead.ReadBinary<int[]>("conf.bin");
            //}
            //catch(System.IO.FileNotFoundException ex)
            //{
                number = new INumber();
            //    FileSaveRead.SaveBinary<int[]>("conf.bin", number.numb);
            //}

            try
            {
                int a = 0;
                gerenciaEmpresa = FileSaveRead.ReadBinary<GerenciaEmpresa>("configuration.bin");
                while (gerenciaEmpresa.lComInumber[0] > a)
                {
                    a = number.gerarCliente();
                }
                while (gerenciaEmpresa.lComInumber[1] > a)
                {
                    a = number.gerarContato();
                }
                while (gerenciaEmpresa.lComInumber[2] > a)
                {
                    a = number.gerarEndereco();
                }
                while (gerenciaEmpresa.lComInumber[3] > a)
                {
                    a = number.gerarProduto();
                }
                while (gerenciaEmpresa.lComInumber[4] > a)
                {
                    a = number.gerarFuncionario();
                }
                while (gerenciaEmpresa.lComInumber[5] > a)
                {
                    a = number.gerarVenda();
                }

            }
            catch (System.IO.FileNotFoundException ex)
            {
                gerenciaEmpresa = new GerenciaEmpresa();

                gerenciaEmpresa.lCliente = new List<Cliente>();
                gerenciaEmpresa.lContato = new List<Contato>();
                gerenciaEmpresa.lEndereco = new List<Endereco>();
                gerenciaEmpresa.lFuncionario = new List<Funcionario>();
                gerenciaEmpresa.lProduto = new List<Produto>();
                gerenciaEmpresa.lVendas = new List<Venda>();
                gerenciaEmpresa.lComInumber = new List<int>();
                gerenciaEmpresa.lComInumber.Add(0);
                gerenciaEmpresa.lComInumber.Add(0);
                gerenciaEmpresa.lComInumber.Add(0);
                gerenciaEmpresa.lComInumber.Add(0);
                gerenciaEmpresa.lComInumber.Add(0);
                gerenciaEmpresa.lComInumber.Add(0);

                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            }
        }

        private void endereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEndereco endereco = new frmEndereco(gerenciaEmpresa, number);
            endereco.MdiParent = this;
            endereco.Show();
        }

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContato contato = new frmContato(gerenciaEmpresa, number);
            contato.MdiParent = this;
            contato.Show();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionario func = new frmFuncionario(gerenciaEmpresa, number);
            func.MdiParent = this;
            func.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto prod = new frmProduto(gerenciaEmpresa, number);
            prod.MdiParent = this;
            prod.Show();
        }
    }
}
