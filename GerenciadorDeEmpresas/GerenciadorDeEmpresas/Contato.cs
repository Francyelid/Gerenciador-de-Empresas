using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GerenciadorDeEmpresas
{
[Serializable]
    public class Contato
    {
        public int iCodContato;
        public string sTelefone;
        public string sCelular;
        public string sEmail;

        public Contato(int codContato, string telefone, string celular, string email)
        {
            iCodContato = codContato;
            sTelefone = telefone;
            sCelular = celular;
            sEmail = email;
        }

        public static void AtualizarContato(int iCodContato)
        {
            //Salvar alterações de contato
        }
    }
}
