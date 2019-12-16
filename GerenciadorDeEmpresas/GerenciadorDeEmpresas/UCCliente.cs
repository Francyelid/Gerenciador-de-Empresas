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
    public partial class UCCliente : UserControl
    {
        int iCodCliente;
        GerenciaEmpresa gerenciaEmpresa;
        List<Cliente> lAux = new List<Cliente>();
        CadCliente cadCliente;
        Pesquisa formPesquisa;
        public UCCliente(GerenciaEmpresa gerenciadorDeEmpresa, int codCliente, CadCliente cad, Pesquisa form)
        {
            formPesquisa = form;
            iCodCliente = codCliente;
            cadCliente = cad;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void UCCliente_Load(object sender, EventArgs e)
        {
            lAux = gerenciaEmpresa.lCliente.Where(x => x.iCodCliente == iCodCliente).ToList();
            lblCodigo.Text = iCodCliente.ToString();
            lblNome.Text = lAux[0].sNome;
            lblEndereco.Text = lAux[0].iCodEndereco.ToString();
            lblContato.Text = lAux[0].iCodContato.ToString();
            if (formPesquisa == null && cadCliente == null)
            {
                btnSelecionar.Visible = false;
                btnSelecionar.Enabled = false;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if(cadCliente != null)
            {
                cadCliente.txtCod.Text = iCodCliente.ToString();
                cadCliente.txtContato.Text = lblContato.Text;
                cadCliente.txtEndereco.Text = lblEndereco.Text;
                cadCliente.txtNome.Text = lblNome.Text;
                cadCliente.CarregarPnlContato(Convert.ToInt16(lblContato.Text));
                cadCliente.CarregarPnlEndereco(Convert.ToInt16(lblEndereco.Text));
            }
        }
    }
}
