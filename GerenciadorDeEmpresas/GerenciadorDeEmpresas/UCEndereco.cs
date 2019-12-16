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
    public partial class UCEndereco : UserControl
    {
        int iCodEndereco;
        GerenciaEmpresa gerenciaEmpresa;
        List<Endereco> lAux = new List<Endereco>();
        CadCliente cadCliente;
        Pesquisa formPesquisa;
        frmEndereco endereco;
        public UCEndereco(GerenciaEmpresa gerenciadorDeEmpresa, int codEndereco, CadCliente cad, Pesquisa form,frmEndereco enderec)
        {
            gerenciaEmpresa = gerenciadorDeEmpresa;
            iCodEndereco = codEndereco;
            cadCliente = cad;
            formPesquisa = form;
            endereco = enderec;
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (cadCliente != null)
            {
                cadCliente.txtEndereco.Text = lblCodigo.Text;
                cadCliente.CarregarPnlEndereco(iCodEndereco);
                if(formPesquisa != null)
                    formPesquisa.Close();
            }else if(endereco != null)
            {
                endereco.txtCod.Text = lblCodigo.Text;
                endereco.txtCep.Text = lblCep.Text;
                endereco.txtCidade.Text = lblCidade.Text;
                endereco.txtEstado.Text = lblEstado.Text;
                endereco.txtNumero.Text = lblNumero.Text;
                endereco.txtPais.Text = lblPais.Text;
                endereco.txtRua.Text = lblRua.Text;
            }
        }

        private void UCEndereco_Load(object sender, EventArgs e)
        {
            lAux = gerenciaEmpresa.lEndereco.Where(x => x.iCodEndereco == iCodEndereco).ToList();
            lblCep.Text = lAux[0].sCep;
            lblCidade.Text = lAux[0].sCidade;
            lblCodigo.Text = iCodEndereco.ToString();
            lblEstado.Text = lAux[0].sEstado;
            lblNumero.Text = lAux[0].sNumero;
            lblPais.Text = lAux[0].sPais;
            lblRua.Text = lAux[0].sRua;
            if (formPesquisa == null && endereco == null)
            {
                btnSelecionar.Visible = false;
                btnSelecionar.Enabled = false;
            }
        }
    }
}
