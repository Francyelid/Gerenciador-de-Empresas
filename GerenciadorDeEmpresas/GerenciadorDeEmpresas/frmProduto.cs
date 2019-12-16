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
    public partial class frmProduto : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        INumber number;
        public frmProduto(GerenciaEmpresa gerenciadorDeEmpresa, INumber numberClass)
        {
            number = numberClass;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtDescricao.Text = "";
            txtNome.Text = "";
            txtValor.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Novo
                if (txtCod.Text == "")
                {
                    gerenciaEmpresa.lComInumber[3] = number.gerarProduto();
                    MessageBox.Show(gerenciaEmpresa.Adicionar<Produto>(new Produto(gerenciaEmpresa.lComInumber[3], txtNome.Text, txtDescricao.Text, Convert.ToDouble(txtValor.Text))));
                    FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
                }
                //Salvar modificação
                else
                {
                    int aux;
                    aux = gerenciaEmpresa.lProduto.IndexOf(gerenciaEmpresa.lProduto.Find(x => x.iCodProduto == Convert.ToInt16(txtCod.Text)));
                    MessageBox.Show(gerenciaEmpresa.Atualizar<Produto>(new Produto(gerenciaEmpresa.lComInumber[3], txtNome.Text, txtDescricao.Text, Convert.ToDouble(txtValor.Text)), aux));
                    FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
                }

                //recarreca painel
                pnlProduto.Controls.Clear();
                int i = 0;
                foreach (var a in gerenciaEmpresa.lProduto)
                {
                    var b = new UCProduto(gerenciaEmpresa, a.iCodProduto, null, null, this);
                    b.Location = new Point(0, b.Size.Height * i);
                    pnlProduto.Controls.Add(b);
                    i++;
                    //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
                }
                txtCod.Text = "";
                txtDescricao.Text = "";
                txtNome.Text = "";
                txtValor.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int aux;
                aux = gerenciaEmpresa.lProduto.IndexOf(gerenciaEmpresa.lProduto.Find(x => x.iCodProduto == Convert.ToInt16(txtCod.Text)));
                MessageBox.Show(gerenciaEmpresa.Excluir<Produto>(new Produto(Convert.ToInt16(txtCod.Text), txtNome.Text, txtDescricao.Text, Convert.ToDouble(txtValor.Text)), aux));
                FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
                pnlProduto.Controls.Clear();
                int i = 0;
                foreach (var a in gerenciaEmpresa.lProduto)
                {
                    var b = new UCProduto(gerenciaEmpresa, a.iCodProduto, null, null, this);
                    b.Location = new Point(0, b.Size.Height * i);
                    pnlProduto.Controls.Add(b);
                    i++;
                    //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
                }
                txtCod.Text = "";
                txtDescricao.Text = "";
                txtNome.Text = "";
                txtValor.Text = "";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var a in gerenciaEmpresa.lProduto)
            {
                var b = new UCProduto(gerenciaEmpresa, a.iCodProduto, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlProduto.Controls.Add(b);
                i++;
                //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
            }
            txtCod.Text = "";
            txtDescricao.Text = "";
            txtNome.Text = "";
            txtValor.Text = "";
        }
    }
}
