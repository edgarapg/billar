using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        private SqlConnection cnx;

        public GastoLocalForm()
        {
            InitializeComponent();
            this.Text = "Gastos del Local";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile("C:\\Users\\edgar\\Pictures\\billar\\billar\\image.png");  // Cambia la ruta según tu imagen
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Inicialización de la conexión
            cnx = new SqlConnection("data source=LAPTOP-VHK1MAKD\\CONEXION; Initial Catalog=gestion_gastos; integrated security=SSPI");

            // Inicialización de componentes
            InitializeFormComponents();

            // Cargar los gastos existentes
            CargarGastos();
        }

        private void InitializeFormComponents()
        {
            // Descripción del Gasto
            txtDescripcionGasto = new TextBox();
            txtDescripcionGasto.Size = new Size(300, 30);
            txtDescripcionGasto.Location = new Point(50, 50);
            txtDescripcionGasto.Font = new Font("Arial", 12);
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
            dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGastos.RowTemplate.Height = 30;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.AllowUserToAddRows = false;
            this.Controls.Add(dgvGastos);

            // Label para mostrar el valor total de los gastos
            lblTotalGasto = new Label();
            lblTotalGasto.Text = "Valor total del gasto: $0";
            lblTotalGasto.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTotalGasto.ForeColor = Color.Black;
            lblTotalGasto.AutoSize = true;
            lblTotalGasto.Location = new Point(50, 520);
            this.Controls.Add(lblTotalGasto);
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

            // Inserción en la base de datos
            try
            {
                cnx.Open();
                string query = "INSERT INTO local (descripcion, fecha, precio, total) VALUES (@descripcion, @fecha, @precio, @total)";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcionGasto.Text);
                cmd.Parameters.AddWithValue("@fecha", dtpFechaGasto.Value);
                cmd.Parameters.AddWithValue("@precio", valorGasto);
                cmd.Parameters.AddWithValue("@total", valorGasto);  // Puedes ajustar según tus necesidades
                cmd.ExecuteNonQuery();

                // Actualizar el DataGridView
                dgvGastos.Rows.Add(txtDescripcionGasto.Text, dtpFechaGasto.Value.ToShortDateString(), valorGasto.ToString("C"));

                // Actualizar el total de gastos
                totalGastos += valorGasto;
                lblTotalGasto.Text = $"Valor total del gasto: {totalGastos:C}";

                // Limpiar los campos
                txtDescripcionGasto.Clear();
                txtValorGasto.Clear();
                dtpFechaGasto.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el gasto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnx.Close();
            }
        }

        private void CargarGastos()
        {
            // Cargar los gastos desde la base de datos al DataGridView
            try
            {
                cnx.Open();
                string query = "SELECT descripcion, fecha, precio FROM local";
                SqlCommand cmd = new SqlCommand(query, cnx);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string descripcion = reader["descripcion"].ToString();
                    string fecha = Convert.ToDateTime(reader["fecha"]).ToShortDateString();
                    float valor = float.Parse(reader["precio"].ToString());

                    dgvGastos.Rows.Add(descripcion, fecha, valor.ToString("C"));
                    totalGastos += valor;
                }

                lblTotalGasto.Text = $"Valor total del gasto: {totalGastos:C}";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los gastos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnx.Close();
            }
        }
    }
}
