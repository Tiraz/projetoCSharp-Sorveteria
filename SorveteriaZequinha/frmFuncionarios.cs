using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorveteriaZequinha
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
            //executando o metódo desabilitar campos
            desabilitarCampos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarFuncionario abrir = new frmPesquisarFuncionario();
            abrir.Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        } 
        //desabilitando os componentes
        public void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCidade.Enabled = false;
            txtComplemento.Enabled = false;
            txtEmail.Enabled = false;
            txtLogradouro.Enabled = false;  
            mskCep.Enabled = false;
            mskCpf.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            cbbFuncao.Enabled = false;
            cbbUf.Enabled = false;
            dtpDataNascimento.Enabled = false;

            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        //habilitando os componentes
        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtCidade.Enabled = true;
            txtComplemento.Enabled = true;
            txtEmail.Enabled = true;
            txtLogradouro.Enabled = true;
            mskCep.Enabled = true;
            mskCpf.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            cbbFuncao.Enabled = true;
            cbbUf.Enabled = true;
            dtpDataNascimento.Enabled = true;

            btnCadastrar.Enabled = true;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;

            txtNome.Focus();
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Equals("")
                || txtEmail.Equals("")
                || mskCep.Text.Equals("   .   .   -")
                || cbbFuncao.Text.Equals("")
                || mskTelefone.Text.Equals("    -")
                || mskCep.Text.Equals("     -")
                || txtLogradouro.Text.Equals("")
                || txtCidade.Text.Equals("")
                || cbbEstado.Text.Equals("")
                || cbbUf.Text.Equals("")
                || txtComplemento.Text.Equals("")
                )

            {
                MessageBox.Show("Favor inserir valores");
            }
            else {
                MessageBox.Show("Cadastrado com sucesso!!!!");
                desabilitarCampos();
            }
        }
    }
}
