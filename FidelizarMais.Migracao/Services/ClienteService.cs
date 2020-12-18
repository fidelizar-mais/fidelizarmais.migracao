using FidelizarMais.Migracao.Models;
using FidelizarMais.Packages.Common.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace FidelizarMais.Migracao.Services
{
    public class ClienteService : BaseService
    {
        public static string Url { get { return "https://api.awsli.com.br/v1/"; } }
        public static string ChaveAplicacao { get { return "2ccd148c-4546-4fee-b66e-8e94e46b961e"; } }

        public ClienteModel Adicionar(ClienteXtechViewModel item, List<PedidoXtechViewModel> pedidos)
        {
            int eCnpj = 0;
            int count = 0;
            int semEndereco = 0;

            string cpf = item.Cpf.ToReplaceCpfCnpj();
            cpf = !string.IsNullOrWhiteSpace(cpf) ? cpf : null;
            cpf = !string.IsNullOrWhiteSpace(cpf) ? cpf.PadLeft(11, '0') : cpf;

            string cnpj = item.Cnpj.ToReplaceCpfCnpj();
            cnpj = !string.IsNullOrWhiteSpace(cnpj) ? cnpj : null;
            cnpj = !string.IsNullOrWhiteSpace(cnpj) ? cnpj.PadLeft(14, '0') : cnpj;

            if (string.IsNullOrWhiteSpace(cpf) && string.IsNullOrWhiteSpace(cnpj))
            {
                return null;
            }

            PedidoXtechViewModel pedido = pedidos?.FirstOrDefault(x => x.CustomerCpf == cpf);
            if (pedido == null)
            {
                pedido = pedidos?.FirstOrDefault(x => x.CustomerCnpj == cnpj);
                if (pedido == null)
                {
                    eCnpj++;
                    return null;
                }
            }

            item.Phone = item.Phone.ToReplaceCpfCnpj();

            string nome = string.Concat(item.Firstname, " ", item.Lastname);
            nome = string.IsNullOrWhiteSpace(nome) ? item.Company : nome;
            string company = !string.IsNullOrWhiteSpace(item.Company) ? item.Company : null;

            company = string.IsNullOrWhiteSpace(company) ? nome : company;

            if (string.IsNullOrWhiteSpace(cpf) && string.IsNullOrWhiteSpace(cnpj))
                return null;

            var tipo = ValidationHelper.IsCpf(cpf) ? "PF" : "PJ";
            if (tipo == "PJ")
                tipo = ValidationHelper.IsCnpj(cnpj) ? "PJ" : null;

            if (string.IsNullOrWhiteSpace(tipo))
            {
                eCnpj++;
                return null;
            }

            ClienteModel clienteModel = new ClienteModel
            {
                nome = nome,
                aceita_newsletter = (!string.IsNullOrWhiteSpace(item.NewsletterSubscription) && item.NewsletterSubscription == "1"),
                cpf = (tipo == "PF" && ValidationHelper.IsCpf(cpf)) ? cpf : null,
                cnpj = (tipo == "PJ" && ValidationHelper.IsCnpj(cnpj)) ? cnpj : null,
                id = long.Parse(item.Id),
                tipo = tipo,
                razao_social = (tipo == "PJ" && ValidationHelper.IsCnpj(cnpj)) ? company : null,
                data_nascimento = (!string.IsNullOrWhiteSpace(item.Birthday) && Util.IsDate(item.Birthday)) ? Util.ToDate(item.Birthday).ToString("yyyy-MM-dd") : null,
                email = Util.ToLower(item.Email),
                sexo = (item.Sex == "0") ? "m" : (item.Sex == "1") ? "f" : null,
                grupo = new GrupoClienteModel
                {
                    id = 1,
                    nome = "Padrão",
                    padrao = true,
                    resource_uri = "/api/v1/grupo/1/",
                },
                ie = (!string.IsNullOrWhiteSpace(cnpj) && cnpj.Length >= 14) ? "isento" : null,
                rg = null,
                telefone_celular = !string.IsNullOrWhiteSpace(item.Phone) ? item.Phone : pedido.CustomerPhone,
                telefone_principal = pedido.CustomerPhone,
                telefone_comercial = null,
                newsletter = (!string.IsNullOrWhiteSpace(item.NewsletterSubscription) && item.NewsletterSubscription == "1"),
                data_criacao = Util.DataHoraBrasilia.ToString("yyyy-MM-dd"),
            };

            if (string.IsNullOrWhiteSpace(clienteModel.telefone_celular))
                return clienteModel;

            if (pedido.ShipZip == "23095450")
            {

            }
            if (!string.IsNullOrWhiteSpace(pedido.ShipAddress1) && !string.IsNullOrWhiteSpace(pedido.ShipDistrict) &&
                !string.IsNullOrWhiteSpace(pedido.ShipCity) && !string.IsNullOrWhiteSpace(pedido.ShipZone) &&
                !string.IsNullOrWhiteSpace(pedido.ShipZip))
            {
                clienteModel.enderecos.Add(new EnderecoClienteModel
                {
                    nome = clienteModel.nome,
                    endereco = pedido.ShipAddress1,
                    complemento = pedido.ShipAddress2,
                    numero = (!string.IsNullOrWhiteSpace(pedido.ShipAnumber) && pedido.ShipAnumber.Length > 10) ? pedido.ShipAnumber.Substring(0, 10) : pedido.ShipAnumber,
                    bairro = pedido.ShipDistrict,
                    cidade = pedido.ShipCity,
                    estado = pedido.ShipZone,
                    cep = pedido.ShipZip,

                    pais = "Brasil",
                    principal = true,
                });
            }

            if (!clienteModel.enderecos.Any())
            {
                semEndereco++;
                Console.WriteLine(count + " Sem endereço");
                return clienteModel;
            }

            Console.WriteLine(clienteModel.nome + " - " + pedido.ShipAddress1 + ", " + pedido.ShipAddress2 + ", " + pedido.ShipDistrict + " - " + pedido.ShipCity + " - " + pedido.ShipZone + " - " + pedido.ShipZip);
            return clienteModel;
        }

        public bool Adicionar(ClienteModel clienteModel, string apiKey)
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                RestClient client = new RestClient($"{Url?.TrimStart('/')}cliente?chave_api={apiKey}&chave_aplicacao={ChaveAplicacao}");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(clienteModel), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    if ((int)response.StatusCode == 429)
                    {
                        Thread.Sleep(15000);
                        return Adicionar(clienteModel, apiKey);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Thread.Sleep(300000);
                        return Adicionar(clienteModel, apiKey);
                    }

                    return JsonConvert.DeserializeObject<dynamic>(response.Content);
                }

                return true;
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
                return false;
            }
        }
    }
}
