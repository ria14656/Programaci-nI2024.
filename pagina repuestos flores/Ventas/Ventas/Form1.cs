using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas
{
    public partial class Form1 : Form
    {
        double precio = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToString("d");
            lblPrecio.Text = (0).ToString("c");
        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboProductos.Text;

            if (producto.Equals("Agujas y accesorios de carburador")) precio = 25;
            if (producto.Equals("Aislador de carburador")) precio = 12;
            if (producto.Equals("Aguja de gasolina")) precio = 25;
            if (producto.Equals("Argolla de cobre")) precio = 8;
            if (producto.Equals("Aro indicador de cambios")) precio = 15;
            if (producto.Equals("Arrancador de Motores")) precio = 40;
            if (producto.Equals("Bace para botones y tablero")) precio = 18;
            if (producto.Equals("Balin de eje principal")) precio = 40;
            if (producto.Equals("Barillas traseras")) precio = 200;
            if (producto.Equals("Barillas laterales")) precio = 35;
            if (producto.Equals("Base de discos")) precio = 55;
            if (producto.Equals("Base de ventilador")) precio = 25;
            if (producto.Equals("Bateria de motor")) precio = 220;


            lblPrecio.Text = precio.ToString("C");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Validando
            if (cboProductos.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un producto...!!!");
            else if (txtCantidad.Text == "")
                MessageBox.Show("Debe ingresar una cantidad...!!!");
            else if(cboTipo.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un tipo de pago...!!!");
            else
            {
                //Capturando datos
                string producto = cboProductos.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string tipo = cboTipo.Text;

                //Procesar calculos
                double subtotal = cantidad * precio;

                double descuento = 0, recargo = 0;
                if (tipo.Equals("Contado"))
                    descuento = 0.05 * subtotal;
                else
                    recargo = 0.1 * subtotal;
                double precioFinal = subtotal - descuento + recargo;

                //Impresion de resultados
                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo);
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());

                lvVenta.Items.Add(fila);
                btnCancelar_Click(sender, e);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboProductos.Text = "(Seleccione producto)";
            cboTipo.Text = "(Seleccione tipo de pago)";
            txtCantidad.Clear();
            lblPrecio.Text = (0).ToString("C");
            cboProductos.Focus();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
