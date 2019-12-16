using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeEmpresas
{
    public partial class UCFuncionario : UserControl
    {
        int iCodFuncionario;
        GerenciaEmpresa gerenciaEmpresa;
        List<Funcionario> lAux = new List<Funcionario>();
        CadCliente cadCliente;
        Pesquisa formPesquisa;
        frmFuncionario funcionario;
        public UCFuncionario(GerenciaEmpresa gerenciadorDeEmpresa, int codFuncionario, CadCliente cad, Pesquisa form, frmFuncionario func)
        {
            gerenciaEmpresa = gerenciadorDeEmpresa;
            iCodFuncionario = codFuncionario;
            cadCliente = cad;
            formPesquisa = form;
            funcionario = func;
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            funcionario.txtCod.Text = lblCodigo.Text;
            funcionario.txtContato.Text = lblContato.Text;
            funcionario.txtEndereco.Text = lblEndereco.Text;
            funcionario.txtFuncao.Text = lblFuncao.Text;
            funcionario.txtNome.Text = lblNome.Text;
        }

        private void UCFuncionario_Load(object sender, EventArgs e)
        {
            lAux = gerenciaEmpresa.lFuncionario.Where(x => x.iCodFuncionario == iCodFuncionario).ToList();
            lblCodigo.Text = iCodFuncionario.ToString();
            lblContato.Text = lAux[0].iCodContato.ToString();
            lblEndereco.Text = lAux[0].iCodEndereco.ToString();
            lblFuncao.Text = lAux[0].sFuncao;
            lblNome.Text = lAux[0].sNome;
        }
    }
}
