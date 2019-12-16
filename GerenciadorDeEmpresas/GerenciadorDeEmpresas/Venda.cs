using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class Venda
    {
        public int iCodVenda;
        public int iCodFuncionario;
        public int iCodCliente;
        public int iCodProduto;
        public DateTime dData;

        public Venda(int codVenda, int codFuncionario, int codCliente, int codProduto, DateTime data)
        {
            iCodVenda = codVenda;
            iCodFuncionario = codFuncionario;
            iCodCliente = codCliente;
            iCodProduto = codProduto;
            dData = data;
        }

        public static void AtualizarVenda()
        {
            //Salvar
        }
    }
}
