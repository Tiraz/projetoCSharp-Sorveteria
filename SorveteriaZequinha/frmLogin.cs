﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace SorveteriaZequinha
{
    public partial class frmLogin : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String nome, senha;
            nome = txtUsuario.Text.Trim();
            senha = txtSenha.Text.Trim();

            if (validarUsuarios(nome, senha))
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        //criando o método validar usuário
        public bool validarUsuarios(string usuario, string senha) 
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "SELECT * FROM tbusuarios WHERE nome = @nome and senha = @senha;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = usuario;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 12).Value = senha;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR=comm.ExecuteReader();
            DR.Read();
            bool resp = DR.HasRows;

            Conexao.fecharConexao();

            return resp;
        }

    }
}
