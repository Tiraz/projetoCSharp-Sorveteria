using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorveteriaZequinha
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String nome, senha;
            nome = txtUsuario.Text.Trim();
            senha = txtSenha.Text.Trim();

            if (nome.Equals("Etecia") && senha.Equals("senha"))
            {
                frmMenuPrincipal abrir = new frmMenuPrincipal();
                abrir.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Usuário ou senha inválidos!", "Mensagem do Sistema", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //executando o metodo limpar campos
                limparCampos();
            }
           
        }

        //criando metodo limpar campos
        public void limparCampos()
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnEntrar.Focus();  
            }
        }
    }
}
