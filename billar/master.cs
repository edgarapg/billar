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
    public partial class master : Form
    {
        private Panel panelMenu;
        private Panel panelContent;

       public master()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del Formulario principal
            this.Text = "Billiard Master Page";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            // Panel izquierdo (menú)
            panelMenu = new Panel();
            panelMenu.Size = new Size(250, this.ClientSize.Height);
            panelMenu.BackColor = Color.Black;
            panelMenu.Dock = DockStyle.Left;
            panelMenu.BackgroundImage = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\pitchten.jpg");
            panelMenu.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(panelMenu);

            // Panel derecho (contenido dinámico)
            panelContent = new Panel();
            panelContent.Size = new Size(this.ClientSize.Width - panelMenu.Width, this.ClientSize.Height);
            panelContent.Dock = DockStyle.Fill;
            panelContent.BackgroundImage = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\imagenes\\pitchfive.jpg");
            panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(panelContent);

            // Agregar botones al menú
            AddMenuButtons();

            // Mostrar el contenido inicial
            ShowInitialContent();
        }

        private void AddMenuButtons()
        {
            // Crear y agregar botones al panel del menú
            string[] buttonNames = { "Inicio", "Clientes Vip", "Pagares", "Reportes", "Inventarios", "Cerrar sesión" };

            for (int i = 0; i < buttonNames.Length; i++)
            {
                Button menuButton = new Button();
                menuButton.Text = buttonNames[i];
                menuButton.BackColor = Color.FromArgb(50, 50, 50);
                menuButton.ForeColor = Color.White;
                menuButton.FlatStyle = FlatStyle.Flat;
                menuButton.FlatAppearance.BorderSize = 0;
                menuButton.Size = new Size(200, 50);
                menuButton.Location = new Point(25, 50 + (i * 60));
                menuButton.Font = new Font("Arial", 12, FontStyle.Bold);
                menuButton.Click += MenuButton_Click;
                panelMenu.Controls.Add(menuButton);
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            // Limpiar el contenido del panel derecho
            panelContent.Controls.Clear();

            // Obtener el botón que fue presionado
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Mostrar diferentes contenidos en función del botón presionado
                switch (clickedButton.Text)
                {
                    case "Inicio":
                        ShowInitialContent();
                        break;
                    case "Clientes Vip":
                        ShowClientesVip();
                        break;
                    case "Pagares":
                        ShowPagares();
                        break;
                    case "Reportes":
                        ShowReportes();
                        break;
                    case "Inventarios":
                        ShowInventarios();
                        break;
                    case "Cerrar sesión":
                        this.Close();
                        break;
                }
            }
        }

        private void ShowInitialContent()
        {
            // Mostrar "Mostrar mesas" y "Cuenta libre"
            Label lblMesas = new Label();
            lblMesas.Text = "Mostrar mesas";
            lblMesas.Font = new Font("Arial", 18, FontStyle.Bold);
            lblMesas.ForeColor = Color.Yellow;
            lblMesas.AutoSize = true;
            lblMesas.Location = new Point((panelContent.Width - lblMesas.Width) / 2, 100);
            panelContent.Controls.Add(lblMesas);

            Button btnMesas = new Button();
            btnMesas.Text = "Abrir";
            btnMesas.BackColor = Color.Black;
            btnMesas.ForeColor = Color.Yellow;
            btnMesas.FlatStyle = FlatStyle.Flat;
            btnMesas.FlatAppearance.BorderSize = 1;
            btnMesas.Location = new Point((panelContent.Width - btnMesas.Width) / 2, 150);
            btnMesas.Size = new Size(100, 40);
            panelContent.Controls.Add(btnMesas);

            Label lblCuentaLibre = new Label();
            lblCuentaLibre.Text = "Cuenta libre";
            lblCuentaLibre.Font = new Font("Arial", 18, FontStyle.Bold);
            lblCuentaLibre.ForeColor = Color.Yellow;
            lblCuentaLibre.AutoSize = true;
            lblCuentaLibre.Location = new Point((panelContent.Width - lblCuentaLibre.Width) / 2, 250);
            panelContent.Controls.Add(lblCuentaLibre);

            Button btnCuentaLibre = new Button();
            btnCuentaLibre.Text = "Abrir";
            btnCuentaLibre.BackColor = Color.Black;
            btnCuentaLibre.ForeColor = Color.Yellow;
            btnCuentaLibre.FlatStyle = FlatStyle.Flat;
            btnCuentaLibre.FlatAppearance.BorderSize = 1;
            btnCuentaLibre.Location = new Point((panelContent.Width - btnCuentaLibre.Width) / 2, 300);
            btnCuentaLibre.Size = new Size(100, 40);
            panelContent.Controls.Add(btnCuentaLibre);
        }

        // Ejemplos de funciones para mostrar diferentes contenidos según los botones del menú
        private void ShowClientesVip()
        {
            Label lbl = new Label();
            lbl.Text = "Clientes VIP";
            lbl.Font = new Font("Arial", 24, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point((panelContent.Width - lbl.Width) / 2, 150);
            panelContent.Controls.Add(lbl);
        }

        private void ShowPagares()
        {
            Label lbl = new Label();
            lbl.Text = "Pagares";
            lbl.Font = new Font("Arial", 24, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point((panelContent.Width - lbl.Width) / 2, 150);
            panelContent.Controls.Add(lbl);
        }

        private void ShowReportes()
        {
            // Crear una instancia del formulario de reportes
            ReportesForm reportesForm = new ReportesForm();

            // Mostrar el formulario de reportes dentro del panelContent
            LoadFormInPanel(reportesForm);
        }

        private void ShowInventarios()
        {
            Label lbl = new Label();
            lbl.Text = "Inventarios";
            lbl.Font = new Font("Arial", 24, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point((panelContent.Width - lbl.Width) / 2, 150);
            panelContent.Controls.Add(lbl);
        }

        private void LoadFormInPanel(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }
    }
}
