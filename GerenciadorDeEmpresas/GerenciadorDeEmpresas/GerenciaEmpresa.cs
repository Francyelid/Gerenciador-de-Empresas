using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GerenciadorDeEmpresas
{
    [Serializable]
    public class GerenciaEmpresa
    {
        public List<Funcionario> lFuncionario;
        public List<Produto> lProduto;
        public List<Venda> lVendas;
        public List<Cliente> lCliente;
        public List<Contato> lContato;
        public List<Endereco> lEndereco;
        public List<int> lComInumber;

        public GerenciaEmpresa()
        {
            //lFuncionario = new List<Funcionario>();
            //lProduto = new List<Produto>();
            //lVendas = new List<Venda>();
            //lCliente = new List<Cliente>();
            //lContato = new List<Contato>();
            //lEndereco = new List<Endereco>();
        }

        public string Adicionar <T>(T objecto)
        {
            string mensagem = "";
            try
            {
                if(objecto.GetType().Equals(typeof(Cliente)))
                {
                    lCliente.Add(objecto as Cliente);
                }
                else if (objecto.GetType().Equals(typeof(Produto)))
                {
                    lProduto.Add(objecto as Produto);
                }
                else if (objecto.GetType().Equals(typeof(Venda)))
                {
                    lVendas.Add(objecto as Venda);
                }
                else if (objecto.GetType().Equals(typeof(Funcionario)))
                {
                    lFuncionario.Add(objecto as Funcionario);
                }
                else if (objecto.GetType().Equals(typeof(Endereco)))
                {
                    lEndereco.Add(objecto as Endereco);
                }
                else if (objecto.GetType().Equals(typeof(Contato)))
                {
                    lContato.Add(objecto as Contato);
                }
            }
            catch(Exception ex)
            {
                mensagem = ex.ToString();
                
            }
            return (mensagem == ""? "Inserido com sucesso!":mensagem).ToString();
        }
        
        public string Atualizar<T>(T objecto, int index)
        {
            string mensagem = "";
            try
            {
                if (objecto.GetType().Equals(typeof(Cliente)))
                {
                    lCliente[index] = (objecto as Cliente);
                }
                else if (objecto.GetType().Equals(typeof(Produto)))
                {
                    lProduto[index] = (objecto as Produto);
                }
                else if (objecto.GetType().Equals(typeof(Venda)))
                {
                    lVendas[index] = (objecto as Venda);
                }
                else if (objecto.GetType().Equals(typeof(Funcionario)))
                {
                    lFuncionario[index] = (objecto as Funcionario);
                }
                else if (objecto.GetType().Equals(typeof(Endereco)))
                {
                    lEndereco[index] = (objecto as Endereco);
                }
                else if (objecto.GetType().Equals(typeof(Contato)))
                {
                    lContato[index] = (objecto as Contato);
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.ToString();

            }
            return (mensagem == "" ? "Atualizado com sucesso!" : mensagem).ToString();
        }

        public string Excluir<T>(T objecto, int index)
        {
            string mensagem = "";
            try
            {
                if (objecto.GetType().Equals(typeof(Cliente)))
                {
                    lCliente.RemoveAt(index);
                }
                else if (objecto.GetType().Equals(typeof(Produto)))
                {
                    lProduto.RemoveAt(index);
                }
                else if (objecto.GetType().Equals(typeof(Venda)))
                {
                    lVendas.RemoveAt(index);
                }
                else if (objecto.GetType().Equals(typeof(Funcionario)))
                {
                    lFuncionario.RemoveAt(index);
                }
                else if (objecto.GetType().Equals(typeof(Endereco)))
                {
                    lEndereco.RemoveAt(index);
                }
                else if (objecto.GetType().Equals(typeof(Contato)))
                {
                    lContato.RemoveAt(index);
                }

            }
            catch (Exception ex)
            {
                mensagem = ex.ToString();

            }
            return (mensagem == "" ? "Excluído com sucesso!" : mensagem).ToString();
        }

    }
}
