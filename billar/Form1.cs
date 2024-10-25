using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace billar
{
    public partial class Form1 : Form
    {
        TextBox txtUsuario;
        TextBox txtPassword;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Inicio de sesión";
            this.Size = new Size(800, 500); // Tamaño del formulario
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\536b177c-3017-42f2-96f3-650a57c48f3a.jpeg"); // Coloca la ruta de tu imagen aquí
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(120, 0, 0, 0); // Transparencia (A=120)
            panel.Size = new Size(300, 400);

            // Centramos el panel
            panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2);

            // Nos aseguramos de que se centre cuando se redimensione la ventana
            this.Controls.Add(panel);
            this.Resize += (s, e) =>
            {
                panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2);
            };

            // Etiqueta de "Iniciar sesión"
            Label lblTitle = new Label();
            lblTitle.Text = "INICIAR SESIÓN";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(40, 130);
            panel.Controls.Add(lblTitle);

            // Caja de texto para el usuario
            TextBox txtUsuario = new TextBox();
            txtUsuario.Text = "Ingresar usuario";
            txtUsuario.ForeColor = Color.Gray;
            txtUsuario.Location = new Point(50, 180);
            txtUsuario.Size = new Size(200, 30);
            panel.Controls.Add(txtUsuario);

            // Evento Enter para quitar placeholder
            txtUsuario.Enter += (sender, e) =>
            {
                if (txtUsuario.Text == "Ingresar usuario")
                {
                    txtUsuario.Text = "";
                    txtUsuario.ForeColor = Color.Black;
                }
            };

            // Evento Leave para restaurar placeholder
            txtUsuario.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    txtUsuario.Text = "Ingresar usuario";
                    txtUsuario.ForeColor = Color.Gray;
                }
            };

            // Caja de texto para la contraseña
            TextBox txtPassword = new TextBox();
            txtPassword.Text = "Contraseña";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(50, 220);
            txtPassword.Size = new Size(200, 30);
            panel.Controls.Add(txtPassword);

            // Evento Enter para la caja de contraseña
            txtPassword.Enter += (sender, e) =>
            {
                if (txtPassword.Text == "Contraseña")
                {
                    txtPassword.Text = "";
                    txtPassword.ForeColor = Color.Black;
                    txtPassword.UseSystemPasswordChar = true;
                }
            };

            // Evento Leave para la caja de contraseña
            txtPassword.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.Text = "Contraseña";
                    txtPassword.ForeColor = Color.Gray;
                }
            };

            // Botón de Ingresar
            Button btnLogin = new Button();
            btnLogin.Text = "Ingresar";
            btnLogin.BackColor = Color.Black;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(100, 270);
            btnLogin.Size = new Size(100, 30);
            panel.Controls.Add(btnLogin);

            // Evento del botón Ingresar
            btnLogin.Click += BtnLogin_Click;

            // Crear íconos de usuario y contraseña
            PictureBox iconUser = new PictureBox();
            iconUser.Image = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\usuario.png");
            iconUser.Size = new Size(30, 30);
            iconUser.Location = new Point(15, 170);
            iconUser.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(iconUser);

            PictureBox iconPass = new PictureBox();
            iconPass.Image = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\candado.png");
            iconPass.Size = new Size(30, 30);
            iconPass.Location = new Point(15, 220);
            iconPass.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(iconPass);

            PictureBox iconInicio = new PictureBox();
            iconInicio.Image = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\palo-de-taco.png");
            iconInicio.Size = new Size(30, 30);
            iconInicio.Location = new Point(15, 130);
            iconInicio.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(iconInicio);

            PictureBox iconLogin = new PictureBox();
            iconLogin.Image = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\piscina-8-bolas.png");
            iconLogin.Size = new Size(100, 100);
            iconLogin.Location = new Point(100, 20);
            iconLogin.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(iconLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
                // Si el usuario y contraseña son correctos, abrir el formulario principal (Master Page)
                master mainForm = new master();
                mainForm.Show();

                // Ocultar el formulario de inicio de sesión
                this.Hide();
            
            
        }
    }
}
