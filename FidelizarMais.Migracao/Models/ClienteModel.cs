using System;
using System.Collections.Generic;
using System.Text;

namespace FidelizarMais.Migracao.Models
{
    public class ClienteModel
    {
        public bool aceita_newsletter { get; set; }
        public object cnpj { get; set; }
        public string cpf { get; set; }
        public string data_criacao { get; set; }
        public string data_modificacao { get; set; }
        public string data_nascimento { get; set; }
        public string email { get; set; }
        public IList<EnderecoClienteModel> enderecos { get; set; }
        public GrupoClienteModel grupo { get; set; }
        public long id { get; set; }
        public object ie { get; set; }
        public bool newsletter { get; set; }
        public string nome { get; set; }
        public object razao_social { get; set; }
        public string resource_uri { get; set; }
        public string rg { get; set; }
        public string sexo { get; set; }
        public string telefone_celular { get; set; }
        public string telefone_comercial { get; set; }
        public string telefone_principal { get; set; }
        public string tipo { get; set; }

        public ClienteModel()
        {
            this.enderecos = new List<EnderecoClienteModel>();
            this.grupo = new GrupoClienteModel();
        }
    }

    public class GrupoClienteModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public bool padrao { get; set; }
        public string resource_uri { get; set; }
    }

    public class EnderecoClienteModel
    {
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string cliente { get; set; }
        public string complemento { get; set; }
        public string endereco { get; set; }
        public string estado { get; set; }
        public long id { get; set; }
        public string nome { get; set; }
        public string numero { get; set; }
        public string pais { get; set; }
        public bool principal { get; set; }
        public string referencia { get; set; }
        public string resource_uri { get; set; }
    }
}
