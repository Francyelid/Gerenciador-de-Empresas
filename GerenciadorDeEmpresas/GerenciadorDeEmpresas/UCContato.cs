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
    public partial class UCContato : UserControl
    {
        int iCodContato;
        GerenciaEmpresa gerenciaEmpresa;
        List<Contato> lAux = new List<Contato>();
        CadCliente cadCliente;
        Pesquisa formPesquisa;
        frmContato contato;
        public UCContato(GerenciaEmpresa gerenciadorDeEmpresa,int codContato,CadCliente cad, Pesquisa form, frmContato contact)
        {
            formPesquisa = form;
            iCodContato = codContato;
            cadCliente = cad;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            contato = contact;
            InitializeComponent();
        }

        private void UCContato_Load(object sender, EventArgs e)
        {
            lAux = gerenciaEmpresa.lContato.Where(x => x.iCodContato == iCodContato).ToList();
            lblCelular.Text = lAux[0].sCelular;
            lblTelefone.Text = lAux[0].sTelefone;
            lblEmail.Text = lAux[0].sEmail;
            lblCodigo.Text = iCodContato.ToString();
            if(formPesquisa == null && contato == null)
            {
                btnSelecionar.Visible = false;
                btnSelecionar.Enabled = false;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (cadCliente != null)
            {
                cadCliente.txtContato.Text = lblCodigo.Text;
                cadCliente.CarregarPnlContato(iCodContato);
                if (formPesquisa != null)
                    formPesquisa.Close();
            }else if(contato != null)
            {
                contato.txtCod.Text = lblCodigo.Text;
                contato.txtCelular.Text = lblCelular.Text;
                contato.txtEmail.Text = lblEmail.Text;
                contato.txtTelefone.Text = lblTelefone.Text;
            }
        }
    }
}
