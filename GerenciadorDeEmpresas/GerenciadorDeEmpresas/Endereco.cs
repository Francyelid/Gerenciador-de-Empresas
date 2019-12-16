using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class Endereco
    {
        public int iCodEndereco;
        public string sRua;
        public string sCidade;
        public string sEstado;
        public string sPais;
        public string sCep;
        public string sNumero;

        public Endereco(int codEndereco, string rua, string cidade, string estado, string pais, string cep, string numero)
        {
            iCodEndereco = codEndereco;
            sRua = rua;
            sCidade = cidade;
            sEstado = estado;
            sPais = pais;
            sCep = cep;
            sNumero = numero;
        }

        public static void AtualizarEndereco(int iCodEndereco)
        {
            //Salvar alterações do endereco
        }
    }
}
