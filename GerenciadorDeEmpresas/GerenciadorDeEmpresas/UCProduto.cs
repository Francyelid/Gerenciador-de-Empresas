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
    public partial class UCProduto : UserControl
    {
        int iCodProduto;
        GerenciaEmpresa gerenciaEmpresa;
        List<Produto> lAux = new List<Produto>();
        CadCliente cadCliente;
        Pesquisa formPesquisa;
        frmProduto produto;
        public UCProduto(GerenciaEmpresa gerenciadorDeEmpresa, int codProduto, CadCliente cad, Pesquisa form, frmProduto prod)
        {
            gerenciaEmpresa = gerenciadorDeEmpresa;
            iCodProduto = codProduto;
            cadCliente = cad;
            formPesquisa = form;
            produto = prod;
            InitializeComponent();
        }

        private void UCProduto_Load(object sender, EventArgs e)
        {
            lAux = gerenciaEmpresa.lProduto.Where(x => x.iCodProduto == iCodProduto).ToList();
            lblCod.Text = lAux[0].iCodProduto.ToString();
            lblDescricao.Text = lAux[0].sDescricao;
            lblNome.Text = lAux[0].sNome;
            lblValor.Text = lAux[0].iValor.ToString();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            produto.txtCod.Text = iCodProduto.ToString();
            produto.txtDescricao.Text = lblDescricao.Text;
            produto.txtNome.Text = lblNome.Text;
            produto.txtValor.Text = lblValor.Text;
        }
    }
}
