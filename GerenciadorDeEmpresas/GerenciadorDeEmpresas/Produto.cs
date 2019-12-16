using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class Produto
    {
        public int iCodProduto;
        public string sNome;
        public string sDescricao;
        public double iValor;

        public Produto(int codProduto, string nome, string descricao, double valor)
        {
            iCodProduto = codProduto;
            sNome = nome;
            sDescricao = descricao;
            iValor = valor;
        }

        public static void AtualizarProduto(int codProduto)
        {
            //Salvar alterações do produto
        }
    }
}
