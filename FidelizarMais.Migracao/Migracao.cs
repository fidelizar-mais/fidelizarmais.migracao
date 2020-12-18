using FidelizarMais.Migracao.Models;
using FidelizarMais.Migracao.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FidelizarMais.Migracao
{
    public partial class Migracao : Form
    {
        private readonly XtechService _xtechService = new XtechService();
        private readonly ClienteService _clienteService = new ClienteService();
        private FiltroModel filtroModel;
        private List<ClienteModel> clienteModels;

        public Migracao()
        {
            InitializeComponent();
        }

        private void cbParceiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = cbParceiro.SelectedItem.ToString();
            bool ativo = !string.IsNullOrWhiteSpace(valor);
            if (valor == "Xtech Commerce")
            {
                txtChaveAPIXtech.Enabled = ativo;
                txtSubdominioXtech.Enabled = ativo;
            }
            else
            {
                txtChaveAPIXtech.Enabled = !ativo;
                txtSubdominioXtech.Enabled = !ativo;
            }

            txtChaveAPILI.Enabled = ativo;
            txtDominioLI.Enabled = ativo;
            btnMigrar.Enabled = !ativo;
            btnBuscarCliente.Enabled = ativo;
        }

        private void btnMigrar_Click(object sender, EventArgs e)
        {
            btnMigrar.Enabled = false;

            foreach (var item in clienteModels)
            {
                try
                {
                    _clienteService.Adicionar(item, filtroModel.ChaveAPILI);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            MessageBox.Show("Migração concluida com sucesso!");
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            filtroModel = new FiltroModel
            {
                ChaveAPILI = txtChaveAPILI.Text,
                DominioAPILI = txtDominioLI.Text,
                ChaveAPIXtech = txtChaveAPIXtech.Text,
                SubdominioAPIXtech = txtSubdominioXtech.Text,
                Tipo = cbParceiro.SelectedItem.ToString(),
            };

            clienteModels = new List<ClienteModel>(0);

            btnBuscarCliente.Text = "Aguarde...";
            btnBuscarCliente.Enabled = false;

            List<ClienteXtechViewModel> clienteXtechViewModels = _xtechService.Clientes(filtroModel.ChaveAPIXtech, filtroModel.SubdominioAPIXtech);
            List<PedidoXtechViewModel> pedidoXtechViewModels = _xtechService.Pedidos(filtroModel.ChaveAPIXtech, filtroModel.SubdominioAPIXtech);

            foreach (var item in clienteXtechViewModels)
            {
                ClienteModel cliente = _clienteService.Adicionar(item, pedidoXtechViewModels);
                if (cliente == null)
                {
                    continue;
                }
                clienteModels.Add(cliente);
            }

            dgResultado.DataSource = clienteModels;
            dgResultado.Refresh();
            btnBuscarCliente.Text = "Buscar";
            btnMigrar.Enabled = true;

            MessageBox.Show("Clientes exportados com sucesso, clique em 'Concluir Migração' para finalizar o processo.");
        }
    }
}
