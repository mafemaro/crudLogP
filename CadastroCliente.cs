using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdloja
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        ConexaoCliente bd = new ConexaoCliente();
        string tabela = "clientes";

        private void btnpesq_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }

        public void ExibirDados()
        {
            string dados = $"SELECT * FROM {tabela}";
            DataTable dt = bd.ExecutarConsulta(dados);
            dtgcliente.DataSource = dt.AsDataView();
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            string inserir;
            string nome = txtnome.Text;
            string loga = txtlog.Text;
            string bairro = txtbairro.Text;
            string cidade = txtcid.Text;
            string estado = txtesta.Text;
            int numero;

            if (txtnome.Text != "" && int.TryParse(txtnum.Text, out numero))
            {
                inserir = $"INSERT INTO {tabela} VALUES(NULL, '{txtnome.Text}', '{loga}', '{numero}', '{bairro}', '{cidade}', '{estado}'); ";
                int resultado = bd.ExecutarComandos(inserir);
                if (resultado == 1)
                {
                    MessageBox.Show("Dado inserido com sucesso");
                    LimparCampos();
                    ExibirDados();
                }
                else
                {
                    MessageBox.Show("Erro ao inserir dado");
                }
            }
            else
            {
                MessageBox.Show("Valor inválido");
            }
        }

        public void LimparCampos()
        {
            lblid.Text = "";
            txtnome.Clear();
            txtnum.Clear();
            txtlog.Clear();
            txtesta.Clear();
            txtbairro.Clear();
            txtcid.Clear();
        }


        private void dtgcliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblid.Text = dtgcliente.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtnome.Text = dtgcliente.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlog.Text = dtgcliente.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtnum.Text = dtgcliente.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbairro.Text = dtgcliente.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtcid.Text = dtgcliente.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtesta.Text = dtgcliente.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        //id, nome, logradouro, numero, bairro, cidade e estado.

        private void btnatua_Click(object sender, EventArgs e)
        {
            string atualizar;
            string nome = txtnome.Text;
            string loga = txtlog.Text;
            string bairro = txtbairro.Text;
            string cidade = txtcid.Text;
            string estado = txtesta.Text;
            int numero;
            if (txtnome.Text != "" && int.TryParse(txtnum.Text, out numero))
            {
                atualizar = $"UPDATE {tabela} set nome = '{nome}', logradouro = '{loga}', numero = '{numero}', bairro = '{bairro}', cidade = '{cidade}', estado = '{estado}' WHERE id = '{lblid.Text}'";
                int resultado = bd.ExecutarComandos(atualizar);
                if (resultado == 1)
                {
                    MessageBox.Show("Dado atualizados com sucesso");
                    LimparCampos();
                    ExibirDados();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar dado");
                }
            }
            else
            {
                MessageBox.Show("Valor inválido");
            }
        }

        private void txtcid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgcliente_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Clique aqui para preencher os campos!";
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btndelet_Click(object sender, EventArgs e)
        {
            string deletar;
            if (lblid.Text != "")
            {
                deletar = $"DELETE FROM {tabela} WHERE id = {lblid.Text}";
                int resultado = bd.ExecutarComandos(deletar);
                if (resultado == 1)
                {
                    MessageBox.Show("Dado excluído com sucesso");
                    LimparCampos();
                    ExibirDados();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir dado");
                }
            }
            else
            {
                MessageBox.Show("ID inválido");
            }
        }
    }
}
