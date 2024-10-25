using billar;
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
    public partial class ReportesForm : Form
    {
        private Panel panelMenu;
        private Panel panelContent;
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

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

           

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Generación de Reportes";
            lblTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.AutoSize = true;

            // Cambiamos la posición del título hacia la derecha
            lblTitulo.Location = new Point(this.Width - lblTitulo.Width - 50, 20);
            this.Controls.Add(lblTitulo);

            // Botón de ejemplo (puede ser para generar reporte)
            Button btnGenerar = new Button();
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.BackColor = Color.Black;
            btnGenerar.ForeColor = Color.White;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Size = new Size(150, 40);

            // Cambiamos la posición del botón hacia la derecha
            btnGenerar.Location = new Point(this.Width - btnGenerar.Width - 50, 100);
            this.Controls.Add(btnGenerar);

            // Otros controles que quieras agregar
            Label lblFecha = new Label();
            lblFecha.Text = "Seleccione Fecha:";
            lblFecha.Font = new Font("Arial", 12, FontStyle.Regular);
            lblFecha.ForeColor = Color.Black;
            lblFecha.AutoSize = true;

            // Cambiamos la posición de la etiqueta hacia la derecha
            lblFecha.Location = new Point(this.Width - lblFecha.Width - 50, 160);
            this.Controls.Add(lblFecha);

            // DatePicker para seleccionar una fecha (puede ser para reportes por rango de fechas)
            DateTimePicker datePicker = new DateTimePicker();
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Size = new Size(150, 30);

            // Cambiamos la posición del DateTimePicker hacia la derecha
            datePicker.Location = new Point(this.Width - datePicker.Width - 50, 190);
            this.Controls.Add(datePicker);
        }
    }
}

