using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class Cliente
    {
        public int iCodCliente;
        public string sNome;
        public int iCodContato;
        public int iCodEndereco;

        public Cliente(int codCliente, string nome, int codContato, int codEndereco)
        {
            iCodCliente = codCliente;
            sNome = nome;
            iCodContato = codContato;
            iCodEndereco = codEndereco;
        }

        public static void AtualizarCliente(int codCliente)
        {
            //Salvar alterações do cliente
        }
    }
}
