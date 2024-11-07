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
    public partial class GastoLocalForm : Form
    {
            private TextBox txtDescripcionGasto;
            private DateTimePicker dtpFechaGasto;
            private TextBox txtValorGasto;
            private Button btnAgregarGasto;
            private DataGridView dgvGastos;
            private Label lblTotalGasto;
            private float totalGastos = 0;

            public GastoLocalForm()
            {
                InitializeComponent();
                this.Text = "Gastos de la Casa";
                this.Size = new Size(800, 600);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackgroundImage = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\image.png");  // Cambia la ruta según tu imagen
                this.BackgroundImageLayout = ImageLayout.Stretch;

                // Inicialización de componentes
                InitializeFormComponents();
            }

            private void InitializeFormComponents()
            {
                // Descripción del Gasto
                txtDescripcionGasto = new TextBox();
                txtDescripcionGasto.Size = new Size(300, 30);
                txtDescripcionGasto.Location = new Point(50, 50);
                txtDescripcionGasto.Font = new Font("Arial", 12);
                //txtDescripcionGasto.PlaceholderText = "Descripción del gasto";
                this.Controls.Add(txtDescripcionGasto);

                // Fecha del Gasto
                dtpFechaGasto = new DateTimePicker();
                dtpFechaGasto.Size = new Size(150, 30);
                dtpFechaGasto.Location = new Point(400, 50);
                dtpFechaGasto.Font = new Font("Arial", 12);
                this.Controls.Add(dtpFechaGasto);

                // Valor del Gasto
                txtValorGasto = new TextBox();
                txtValorGasto.Size = new Size(150, 30);
                txtValorGasto.Location = new Point(400, 100);
                txtValorGasto.Font = new Font("Arial", 12);
                //txtValorGasto.PlaceholderText = "Valor del gasto";
                this.Controls.Add(txtValorGasto);

                // Botón para agregar gasto
                btnAgregarGasto = new Button();
                btnAgregarGasto.Text = "Agregar";
                btnAgregarGasto.Font = new Font("Arial", 12, FontStyle.Bold);
                btnAgregarGasto.Size = new Size(120, 40);
                btnAgregarGasto.Location = new Point(50, 100);
                btnAgregarGasto.BackColor = Color.Black;
                btnAgregarGasto.ForeColor = Color.White;
                btnAgregarGasto.Click += new EventHandler(AgregarGasto_Click);
                this.Controls.Add(btnAgregarGasto);

                // DataGridView para mostrar los gastos agregados
                dgvGastos = new DataGridView();
                dgvGastos.Size = new Size(700, 300);
                dgvGastos.Location = new Point(50, 200);
                dgvGastos.ColumnCount = 3;
                dgvGastos.Columns[0].Name = "Descripción del Gasto";
                dgvGastos.Columns[1].Name = "Fecha";
                dgvGastos.Columns[2].Name = "Valor";
                dgvGastos.Font = new Font("Arial", 12);
                dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar tamaño de columnas
                dgvGastos.RowTemplate.Height = 30;
                dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvGastos.AllowUserToAddRows = false;  // Evitar que el usuario agregue filas manualmente
                this.Controls.Add(dgvGastos);

                // Label para mostrar el valor total de los gastos
                lblTotalGasto = new Label();
                lblTotalGasto.Text = "Valor total del gasto: $0";
                lblTotalGasto.Font = new Font("Arial", 14, FontStyle.Bold);
                lblTotalGasto.ForeColor = Color.White;
                lblTotalGasto.AutoSize = true;
                lblTotalGasto.Location = new Point(50, 520);
                this.Controls.Add(lblTotalGasto);

                // Botón para generar informe
                Button btnGenerarInforme = new Button();
                btnGenerarInforme.Text = "Generar Informe";
                btnGenerarInforme.Font = new Font("Arial", 12, FontStyle.Bold);
                btnGenerarInforme.Size = new Size(150, 40);
                btnGenerarInforme.Location = new Point(600, 520);
                btnGenerarInforme.BackColor = Color.OrangeRed;
                btnGenerarInforme.ForeColor = Color.White;
                btnGenerarInforme.Click += BtnGenerarInforme_Click;  // Agregar funcionalidad al botón si es necesario
                this.Controls.Add(btnGenerarInforme);
            }

            private void AgregarGasto_Click(object sender, EventArgs e)
            {
                // Validación de campos
                if (string.IsNullOrWhiteSpace(txtDescripcionGasto.Text) || string.IsNullOrWhiteSpace(txtValorGasto.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de agregar el gasto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtValorGasto.Text, out float valorGasto))
                {
                    MessageBox.Show("El valor del gasto debe ser un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar el gasto al DataGridView
                dgvGastos.Rows.Add(txtDescripcionGasto.Text, dtpFechaGasto.Value.ToShortDateString(), valorGasto.ToString("C"));

                // Actualizar el total de gastos
                totalGastos += valorGasto;
                lblTotalGasto.Text = $"Valor total del gasto: {totalGastos:C}";

                // Limpiar los campos de entrada
                txtDescripcionGasto.Clear();
                txtValorGasto.Clear();
                dtpFechaGasto.Value = DateTime.Now;
            }

            private void BtnGenerarInforme_Click(object sender, EventArgs e)
            {
                // Aquí puedes agregar la lógica para generar un informe si es necesario
                MessageBox.Show("Informe generado (funcionalidad pendiente).", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

