using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MosaicoSolutions.ViaCep;

namespace SorveteriaZequinha
{
    public partial class frmFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

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
            txtBairro.Enabled = false; 
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        //criando o método busca cep
        public void buscaCEP(string cep) 
        {
            var viaCEPService = ViaCepService.Default();
            var endereco = viaCEPService.ObterEndereco(cep);

            txtLogradouro.Text = endereco.Logradouro;
            txtCidade.Text = endereco.Localidade;
            txtBairro.Text = endereco.Bairro;
            cbbEstado.Text = endereco.UF;
            cbbUf.Text = endereco.UF;
            txtComplemento.Text = endereco.Complemento;
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
            txtBairro.Enabled = true;
            btnCadastrar.Enabled = true;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;

            txtNome.Focus();
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
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
                || txtBairro.Text.Equals("")
                )

            {
                MessageBox.Show("Favor inserir valores");
            }
            else {
                MessageBox.Show("Cadastrado com sucesso!!!!");
                desabilitarCampos();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //executando o método busca cep
                buscaCEP(mskCep.Text);
                txtLogradouro.Focus();
                
            }
        }
    }
}
