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
    public partial class frmEndereco : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        INumber number;
        public frmEndereco(GerenciaEmpresa gerenciadorDeEmpresa, INumber numberClass)
        {
            number = numberClass;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEndereco_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var a in gerenciaEmpresa.lEndereco)
            {
                var b = new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlEndereco.Controls.Add(b);
                i++;
                //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtNumero.Text = "";
            txtPais.Text = "";
            txtRua.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Novo
            if (txtCod.Text == "")
            {
                gerenciaEmpresa.lComInumber[2] = number.gerarEndereco();
                MessageBox.Show(gerenciaEmpresa.Adicionar<Endereco>(new Endereco(gerenciaEmpresa.lComInumber[2], txtRua.Text,txtCidade.Text,txtEstado.Text,txtPais.Text,txtCep.Text,txtNumero.Text)));
                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            }
            //Salvar modificação
            else
            {
                int aux;
                aux = gerenciaEmpresa.lEndereco.IndexOf(gerenciaEmpresa.lEndereco.Find(x => x.iCodEndereco == Convert.ToInt16(txtCod.Text)));
                MessageBox.Show(gerenciaEmpresa.Atualizar<Endereco>(new Endereco(Convert.ToInt16(txtCod.Text), txtRua.Text, txtCidade.Text, txtEstado.Text, txtPais.Text, txtCep.Text, txtNumero.Text), aux));
                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            }

            //recarreca painel
            pnlEndereco.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lEndereco)
            {
                var b = new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlEndereco.Controls.Add(b);
                i++;
                //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
            }
            txtCod.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtNumero.Text = "";
            txtPais.Text = "";
            txtRua.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int aux;
            aux = gerenciaEmpresa.lEndereco.IndexOf(gerenciaEmpresa.lEndereco.Find(x => x.iCodEndereco == Convert.ToInt16(txtCod.Text)));
            MessageBox.Show(gerenciaEmpresa.Excluir<Endereco>(new Endereco((txtCod.Text ==  "" ? 0 : Convert.ToInt16(txtCod.Text)), txtRua.Text, txtCidade.Text, txtEstado.Text, txtPais.Text, txtCep.Text, txtNumero.Text), aux));
            FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            //recarreca painel
            pnlEndereco.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lEndereco)
            {
                var b = new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlEndereco.Controls.Add(b);
                i++;
                //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
            }
            txtCod.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtNumero.Text = "";
            txtPais.Text = "";
            txtRua.Text = "";
        }

        private void pnlEndereco_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
