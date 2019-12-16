using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class Funcionario
    {
        public int iCodFuncionario;
        public string sNome;
        public string sFuncao;
        public int iCodContato;
        public int iCodEndereco;

        public Funcionario(int codFuncionario, string nome, string funcao, int codContato, int codEndereco)
        {
            iCodFuncionario = codFuncionario;
            sNome = nome;
            sFuncao = funcao;
            iCodContato = codContato;
            iCodEndereco = codEndereco;
        }
    }
}
