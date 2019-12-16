using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class INumber
    {
        public static int idNumberCliente;
        public static int idNumberContato;
        public static int idNumberEndereco;
        public static int idNumberProduto;
        public static int idNumberVenda;
        public static int idNumberFuncionario;

        public INumber()
        {
            //idNumberCliente = 0;
            //idNumberContato = 0;
            //idNumberEndereco = 0;
        }
        public int gerarFuncionario()
        {
            idNumberFuncionario = idNumberFuncionario + 1;
            return idNumberFuncionario;
        }
        public int gerarProduto()
        {
            idNumberProduto = idNumberProduto + 1;
            return idNumberProduto;
        }
        public int gerarVenda()
        {
            idNumberVenda = idNumberVenda + 1;
            return idNumberVenda;
        }
        public int gerarCliente()
        {
            idNumberCliente = idNumberCliente + 1;
            return idNumberCliente;
        }
        public int gerarEndereco()
        {
            idNumberEndereco = idNumberEndereco + 1;
            return idNumberEndereco;
        }
        public int gerarContato()
        {
            idNumberContato = idNumberContato + 1;
            return idNumberContato;
        }
    }
}
