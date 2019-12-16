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
    public partial class CadCliente : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        INumber number;
        public CadCliente(GerenciaEmpresa gerenciadorDeEmpresa, INumber numberClass)
        {
            number = numberClass;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CadCliente_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var a in gerenciaEmpresa.lCliente)
            {
                var b = new UCCliente(gerenciaEmpresa, a.iCodCliente, this, null);
                b.Location = new Point(0, b.Size.Height * i);
                pnlCliente.Controls.Add(b);
                i++;
            }
        }

        private void btnAdicionarContato_Click(object sender, EventArgs e)
        {
            Pesquisa pesquisa = new Pesquisa(gerenciaEmpresa, 1,this);
            pesquisa.ShowDialog();
        }
        
        public void CarregarPnlContato(int iCodContato)
        {
            if(txtContato.Text != "")
            {
                pnlContato.Controls.Clear();
                pnlContato.Controls.Add(new UCContato(gerenciaEmpresa, iCodContato, this, null,null));
            }
        }

        public void CarregarPnlEndereco(int iCodEndereco)
        {
            if (txtEndereco.Text != "")
            {
                pnlEndereco.Controls.Clear();
                pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, iCodEndereco, this, null,null));
            }
        }

        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            Pesquisa pesquisa = new Pesquisa(gerenciaEmpresa, 2, this);
            pesquisa.ShowDialog();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Novo
            if(txtCod.Text == "")
            {
                if(txtEndereco.Text == "" || txtContato.Text == "")
                {
                    MessageBox.Show("Atribua um contato ou endereço para ser possivel salvar.");
                    
                }else
                {
                    gerenciaEmpresa.lComInumber[0] = number.gerarCliente();
                    MessageBox.Show(gerenciaEmpresa.Adicionar<Cliente>(new Cliente(gerenciaEmpresa.lComInumber[0], txtNome.Text, Convert.ToInt16(txtContato.Text), Convert.ToInt16(txtEndereco.Text))));
                    FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
                }
            }
            //Salvar modificação
            else
            {
                int aux;
                aux = gerenciaEmpresa.lCliente.IndexOf(gerenciaEmpresa.lCliente.Find(x => x.iCodCliente == Convert.ToInt16(txtCod.Text)));
                MessageBox.Show(gerenciaEmpresa.Atualizar<Cliente>(new Cliente(Convert.ToInt16(txtCod.Text), txtNome.Text, Convert.ToInt16(txtContato.Text), Convert.ToInt16(txtEndereco.Text)),aux));
                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            }

            //recarrega painel
            pnlCliente.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lCliente)
            {
                var b = new UCCliente(gerenciaEmpresa, a.iCodCliente, this, null);
                b.Location = new Point(0, b.Size.Height * i);
                pnlCliente.Controls.Add(b);
                i++;
            }
            pnlContato.Controls.Clear();
            pnlEndereco.Controls.Clear();

            txtCod.Text = "";
            txtNome.Text = "";

            txtEndereco.Text = "";
            txtContato.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pnlContato.Controls.Clear();
            pnlEndereco.Controls.Clear();

            txtCod.Text = "";
            txtNome.Text = "";

            txtEndereco.Text = "";
            txtContato.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int aux;
            aux = gerenciaEmpresa.lCliente.IndexOf(gerenciaEmpresa.lCliente.Find(x => x.iCodCliente == Convert.ToInt16(txtCod.Text)));
            MessageBox.Show(gerenciaEmpresa.Excluir<Cliente>(new Cliente(Convert.ToInt16(txtCod.Text), txtNome.Text, Convert.ToInt16(txtContato.Text), Convert.ToInt16(txtEndereco.Text)), aux));
            FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            //recarrega painel
            pnlCliente.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lCliente)
            {
                var b = new UCCliente(gerenciaEmpresa, a.iCodCliente, this, null);
                b.Location = new Point(0, b.Size.Height * i);
                pnlCliente.Controls.Add(b);
                i++;
            }
            pnlContato.Controls.Clear();
            pnlEndereco.Controls.Clear();

            txtCod.Text = "";
            txtNome.Text = "";

            txtEndereco.Text = "";
            txtContato.Text = "";
        }
    }
}
