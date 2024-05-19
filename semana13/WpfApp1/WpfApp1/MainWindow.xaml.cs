using System.IO;
using System.Windows;
using WpfApp1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.InitializeComponent();
    }

    private void CargarButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string filePath = txtRutaArchivo.Text; 

            List<Juego> juegos = [];

            
            foreach (string line in File.ReadLines(filePath))
            {
                Juego juego = ParsearLinea(line);
                juegos.Add(juego);
            }

            // Actualizar fuente de datos del ListBox
            lstJuegos.ItemsSource = juegos;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    // Clase Juego (similar al ejemplo)
    public class Juego
    {
        public string Eq1 { get; set; }
        public string Eq2 { get; set; }
        public int Puntaje1 { get; set; }
        public int Puntaje2 { get; set; }
        public int Progreso { get; set; }
    }

   
    private static Juego ParsearLinea(string line)
    {
       
        string[] valores = line.Split(',');
        return new Juego
        {
            Eq1 = valores[0],
            Eq2 = valores[1],
            Puntaje1 = int.Parse(valores[2]),
            Puntaje2 = int.Parse(valores[3]),
            Progreso = int.Parse(valores[4])
        };
    }

    static void Main()
    {
        Application application = new()
        {
            MainWindow = new MainWindow()
        };
        application.Run();
    }
}

internal class lstJuegos
{
    internal static List<MainWindow.Juego> ItemsSource;
}

namespace WpfApp1
{
    class txtRutaArchivo
    {
        public static string Text { get; internal set; }
    }
}