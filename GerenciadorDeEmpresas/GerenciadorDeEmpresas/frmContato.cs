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
    public partial class frmContato : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        INumber number;
        public frmContato(GerenciaEmpresa gerenciadorDeEmpresa, INumber numberClass)
        {
            number = numberClass;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Novo
            if (txtCod.Text == "")
            {
                gerenciaEmpresa.lComInumber[1] = number.gerarContato();
                MessageBox.Show(gerenciaEmpresa.Adicionar<Contato>(new Contato(gerenciaEmpresa.lComInumber[1], txtTelefone.Text,txtCelular.Text,txtEmail.Text)));
                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            }
            //Salvar modificação
            else
            {
                int aux;
                aux = gerenciaEmpresa.lContato.IndexOf(gerenciaEmpresa.lContato.Find(x => x.iCodContato == Convert.ToInt16(txtCod.Text)));
                MessageBox.Show(gerenciaEmpresa.Atualizar<Contato>(new Contato(Convert.ToInt16(txtCod.Text), txtTelefone.Text, txtCelular.Text, txtEmail.Text), Convert.ToInt16(txtCod.Text)));
                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
            }
            //recarregar painel
            pnlContato.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lContato)
            {
                var b = new UCContato(gerenciaEmpresa, a.iCodContato, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlContato.Controls.Add(b);
                i++;
            }
            txtCod.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int aux;
            aux = gerenciaEmpresa.lContato.IndexOf(gerenciaEmpresa.lContato.Find(x => x.iCodContato == Convert.ToInt16(txtCod.Text)));
            MessageBox.Show(gerenciaEmpresa.Excluir<Contato>(new Contato(Convert.ToInt16(txtCod.Text), txtTelefone.Text, txtCelular.Text, txtEmail.Text), aux));
            FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);

            //recarregar painel
            pnlContato.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lContato)
            {
                var b = new UCContato(gerenciaEmpresa, a.iCodContato, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlContato.Controls.Add(b);
                i++;
            }
            txtCod.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }

        private void frmContato_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var a in gerenciaEmpresa.lContato)
            {
                var b = new UCContato(gerenciaEmpresa, a.iCodContato, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlContato.Controls.Add(b);
                i++;
            }
        }
    }
}
