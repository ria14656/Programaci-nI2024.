using System.Drawing;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

public class MiFormulario : Form
{
    private Button miBoton;
    private Label miEtiqueta;

    public MiFormulario()
    {
        this.Width = 800;
        this.Height = 600;
        this.Text = "Mi Formulario";

        // Creación y configuración del botón
        miBoton = new Button();
        miBoton.Size = new Size(100, 50); // Tamaño del botón
        miBoton.Location = new Point(350, 250); // Posición del botón
        miBoton.Text = "Haz clic"; // Texto del botón
        miBoton.Click += new EventHandler(MiBoton_Click); // Evento de clic

        // Creación y configuración de la etiqueta
        miEtiqueta = new Label();
        miEtiqueta.Size = new Size(200, 50); // Tamaño de la etiqueta
        miEtiqueta.Location = new Point(300, 150); // Posición de la etiqueta
        miEtiqueta.Text = "¡Hola, Windows Forms!"; // Texto de la etiqueta

        // Agregar controles al formulario
        this.Controls.Add(miBoton);
        this.Controls.Add(miEtiqueta);
    }

    public int Width { get; private set; }
    public int Height { get; private set; }
    public string Text { get; private set; }

    private void MiBoton_Click(object sender, EventArgs e)
    {
        miEtiqueta.Text = "Botón presionado"; // Cambiar texto de la etiqueta
    }
}

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        object value = Application.Run(new MiFormulario()); // Ejecutar el formulario
    }
}
