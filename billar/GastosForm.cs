using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace billar
{
    public partial class GastosForm : Form
    {
        private Panel panelContent;

        public GastosForm()
        {
            InitializeComponent();
            this.Text = "Información de Gastos";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Fondo (se ajusta desde aquí)
            this.BackgroundImage = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\image.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Crear panel de contenido
            panelContent = new Panel();
            panelContent.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            panelContent.Dock = DockStyle.Fill;
            panelContent.BackColor = Color.Transparent;
            this.Controls.Add(panelContent);

            // Título
            Label titulo = new Label();
            titulo.Text = "INFORMACIÓN DE GASTOS";
            titulo.Font = new Font("Arial", 28, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.AutoSize = true;
            titulo.Location = new Point((panelContent.Width - titulo.Width) / 2, 20);
            panelContent.Controls.Add(titulo);

            // Agregar iconos y etiquetas
            AddGastosCategories();
        }

        private void AddGastosCategories()
        {
            // Crear iconos y etiquetas para cada categoría de gastos
            string[] categories = { "Gastos del local", "Gastos de la casa", "Gastos de Banco", "Gastos personales", "Gastos de la Administradora", "Gastos de Brian" };
            string[] iconPaths = {
                "C:\\Users\\edgar\\Pictures\\billar\\billar\\contabilidad.png",
                "C:\\Users\\edgar\\Pictures\\billar\\billar\\perfil-del-cliente.png",
                "C:\\Users\\edgar\\Pictures\\billar\\billar\\cuenta-bancaria.png",
                "C:\\Users\\edgar\\Pictures\\billar\\billar\\acuerdo-de-contribuyente.png",
                "C:\\Users\\edgar\\Pictures\\billar\\billar\\nina.png",
                "C:\\Users\\edgar\\Pictures\\billar\\billar\\hombre.png"
            };

            // Formularios que abrirán los clics en los iconos
            Form[] forms = {
                new GastoLocalForm(),
                new GastoCasaForm(),
                new GastoBancoForm(),
                new GastoPersonalForm(),
                new GastoAdminForm(),
                new GastoBrianForm()
            };

            // Posición inicial para colocar los iconos y etiquetas
            int xPos = 50;
            int yPos = 100;
            int iconSize = 100;

            for (int i = 0; i < categories.Length; i++)
            {
                // Crear PictureBox para el icono
                PictureBox icono = new PictureBox();
                icono.Image = Image.FromFile(iconPaths[i]);
                icono.SizeMode = PictureBoxSizeMode.StretchImage;
                icono.Size = new Size(iconSize, iconSize);
                icono.Location = new Point(xPos, yPos);
                icono.Cursor = Cursors.Hand;  // Cambia el cursor a "mano" al pasar sobre el icono
                panelContent.Controls.Add(icono);

                // Asociar el evento de clic para abrir el formulario correspondiente
                int formIndex = i;  // Capturar el índice en una variable local
                icono.Click += (sender, e) => {
                    forms[formIndex].ShowDialog();
                };

                // Crear Label para la categoría
                Label lblCategoria = new Label();
                lblCategoria.Text = categories[i];
                lblCategoria.Font = new Font("Arial", 16, FontStyle.Bold);
                lblCategoria.ForeColor = Color.White;
                lblCategoria.AutoSize = true;
                lblCategoria.Location = new Point(xPos + iconSize + 10, yPos + (iconSize / 4));
                panelContent.Controls.Add(lblCategoria);

                // Ajustar la posición Y para la siguiente fila de iconos
                yPos += iconSize + 40;

                // Si es necesario, reiniciar la posición X para hacer una segunda columna
                if (i == (categories.Length / 2) - 1)
                {
                    xPos = this.ClientSize.Width / 2 + 50;
                    yPos = 100;
                }
            }
        }
    }
}
