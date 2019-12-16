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

    public partial class frmFuncionario : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        INumber number;
        public frmFuncionario(GerenciaEmpresa gerenciadorDeEmpresa, INumber numberClass)
        {
            number = numberClass;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtContato.Text = "";
            txtEndereco.Text = "";
            txtFuncao.Text = "";
            txtNome.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var a in gerenciaEmpresa.lFuncionario)
            {
                var b = new UCFuncionario(gerenciaEmpresa, a.iCodEndereco, null, null,this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlFuncionario.Controls.Add(b);
                i++;
                //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtEndereco.Text != "" && txtContato.Text != "")
            {
                //Novo
                if (txtCod.Text == "")
                {
                    gerenciaEmpresa.lComInumber[4] = number.gerarEndereco();
                    MessageBox.Show(gerenciaEmpresa.Adicionar<Funcionario>(new Funcionario(gerenciaEmpresa.lComInumber[4], txtNome.Text, txtFuncao.Text, Convert.ToInt16(txtContato.Text), Convert.ToInt16(txtEndereco.Text))));
                    FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
                }
                //Salvar modificação
                else
                {
                    int aux;
                    aux = gerenciaEmpresa.lFuncionario.IndexOf(gerenciaEmpresa.lFuncionario.Find(x => x.iCodEndereco == Convert.ToInt16(txtCod.Text)));
                    MessageBox.Show(gerenciaEmpresa.Atualizar<Funcionario>(new Funcionario(Convert.ToInt16(txtCod.Text), txtNome.Text, txtFuncao.Text, Convert.ToInt16(txtContato.Text), Convert.ToInt16(txtEndereco.Text)), aux));
                    FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);
                }

                //recarreca painel
                pnlFuncionario.Controls.Clear();
                int i = 0;
                foreach (var a in gerenciaEmpresa.lFuncionario)
                {
                    var b = new UCFuncionario(gerenciaEmpresa, a.iCodEndereco, null, null, this);
                    b.Location = new Point(0, b.Size.Height * i);
                    pnlFuncionario.Controls.Add(b);
                    i++;
                    //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
                }
                txtCod.Text = "";
                txtContato.Text = "";
                txtEndereco.Text = "";
                txtFuncao.Text = "";
                txtNome.Text = "";
            }
            else
            {
                MessageBox.Show("Preencher contato e endereco como numerico");
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int aux;
            aux = gerenciaEmpresa.lFuncionario.IndexOf(gerenciaEmpresa.lFuncionario.Find(x => x.iCodEndereco == Convert.ToInt16(txtCod.Text)));
            MessageBox.Show(gerenciaEmpresa.Excluir<Funcionario>(new Funcionario(Convert.ToInt16(txtCod.Text), txtNome.Text, txtFuncao.Text, Convert.ToInt16(txtContato.Text), Convert.ToInt16(txtEndereco.Text)), aux));
            FileSaveRead.SaveBinary<GerenciaEmpresa>("configuration.bin", gerenciaEmpresa);

            //recarreca painel
            pnlFuncionario.Controls.Clear();
            int i = 0;
            foreach (var a in gerenciaEmpresa.lFuncionario)
            {
                var b = new UCFuncionario(gerenciaEmpresa, a.iCodEndereco, null, null, this);
                b.Location = new Point(0, b.Size.Height * i);
                pnlFuncionario.Controls.Add(b);
                i++;
                //pnlEndereco.Controls.Add(new UCEndereco(gerenciaEmpresa, a.iCodEndereco, null, null,this));
            }
            txtCod.Text = "";
            txtContato.Text = "";
            txtEndereco.Text = "";
            txtFuncao.Text = "";
            txtNome.Text = "";
        }
    }
}
