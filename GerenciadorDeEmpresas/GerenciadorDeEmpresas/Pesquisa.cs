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
    public partial class Pesquisa : Form
    {
        GerenciaEmpresa gerenciaEmpresa;
        int iTipo;
        CadCliente cadCliente;
        public Pesquisa(GerenciaEmpresa gerenciadorDeEmpresa,int tipo, CadCliente cad)
        {
            cadCliente = cad;
            iTipo = tipo;
            gerenciaEmpresa = gerenciadorDeEmpresa;
            InitializeComponent();
        }

        private void Pesquisa_Load(object sender, EventArgs e)
        {
            int i = 0;
            //Contato
            if(iTipo == 1)
            {
                foreach(var a in gerenciaEmpresa.lContato)
                {
                    var b = new UCContato(gerenciaEmpresa, a.iCodContato, cadCliente, this, null);
                    b.Location = new Point(0, b.Size.Height * i);
                    pnlPesquisa.Controls.Add(b);
                    i++;
                }
                
            }else if(iTipo == 2){
                foreach (var a in gerenciaEmpresa.lEndereco)
                {
                    var b = new UCEndereco(gerenciaEmpresa, a.iCodEndereco, cadCliente, this, null);
                    b.Location = new Point(0, b.Size.Height * i);
                    pnlPesquisa.Controls.Add(b);
                    i++;
                }
            }
        }

    }
}
