using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Diagnostics;

namespace ExamenParcial3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch;
        TimeSpan tiempoAnterior;
        public MainWindow()
        {
            InitializeComponent();
            miCanvas.Focus();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            tiempoAnterior = stopwatch.Elapsed;
            ThreadStart threadStart = new ThreadStart(moverEnemigos);
            Thread threadMoverEnemigos = new Thread(threadStart);
            threadMoverEnemigos.Start();
        }
        void moverEnemigos()
        {
            while (true)
            {
                Dispatcher.Invoke(
                () => {
                    var tiempoActual = stopwatch.Elapsed;
                    var deltaTime = tiempoActual - tiempoAnterior;

                    double leftHuevo1Actual = Canvas.GetLeft(imgHuevo1);
                    Canvas.SetLeft(imgHuevo1, leftHuevo1Actual + 90 * deltaTime.TotalSeconds);
                    if (Canvas.GetLeft(imgHuevo1) >= 850)
                    {
                        Canvas.SetLeft(imgHuevo1, -100);
                    }

                    double leftHuevo2Actual = Canvas.GetLeft(imgHuevo2);
                    Canvas.SetLeft(imgHuevo2, leftHuevo2Actual + 50 * deltaTime.TotalSeconds);
                    if (Canvas.GetLeft(imgHuevo2) >= 850)
                    {
                        Canvas.SetLeft(imgHuevo2, -100);
                    }

                    double leftHuevo3Actual = Canvas.GetLeft(imgHuevo3);
                    Canvas.SetLeft(imgHuevo3, leftHuevo3Actual + 120 * deltaTime.TotalSeconds);
                    if (Canvas.GetLeft(imgHuevo3) >= 850)
                    {
                        Canvas.SetLeft(imgHuevo3, -100);
                    }

                    double leftHuevo4Actual = Canvas.GetLeft(imgHuevo4);
                    Canvas.SetLeft(imgHuevo4, leftHuevo4Actual + 100 * deltaTime.TotalSeconds);
                    if (Canvas.GetLeft(imgHuevo4) >= 850)
                    {
                        Canvas.SetLeft(imgHuevo4, -100);
                    }

                    double leftHuevo5Actual = Canvas.GetLeft(imgHuevo5);
                    Canvas.SetLeft(imgHuevo5, leftHuevo5Actual + 70 * deltaTime.TotalSeconds);
                    if (Canvas.GetLeft(imgHuevo5) >= 850)
                    {
                        Canvas.SetLeft(imgHuevo5, -100);
                    }

                    tiempoAnterior = tiempoActual;
                }
                );
            }
        }
        private void miCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.W)
            {
                double topGalloActual = Canvas.GetTop(imgGallo);
                Canvas.SetTop(imgGallo, topGalloActual - 15);
            }
            if (e.Key == Key.Down || e.Key == Key.S)
            {
                double topGalloActual = Canvas.GetTop(imgGallo);
                Canvas.SetTop(imgGallo, topGalloActual + 15);
            }
        }
    }
}
