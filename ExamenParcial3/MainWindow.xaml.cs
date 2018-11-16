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

                    double leftHuevo1Actual = Canvas.GetTop(imgHuevo1);
                    Canvas.SetTop(imgHuevo1, leftHuevo1Actual + 90 * deltaTime.TotalSeconds);
                    if (Canvas.GetTop(imgHuevo1) >= 850)
                    {
                        Canvas.SetTop(imgHuevo1, -100);
                    }

                    double leftHuevo2Actual = Canvas.GetTop(imgHuevo2);
                    Canvas.SetTop(imgHuevo2, leftHuevo2Actual + 50 * deltaTime.TotalSeconds);
                    if (Canvas.GetTop(imgHuevo2) >= 850)
                    {
                        Canvas.SetTop(imgHuevo2, -100);
                    }

                    double leftHuevo3Actual = Canvas.GetTop(imgHuevo3);
                    Canvas.SetTop(imgHuevo3, leftHuevo3Actual + 120 * deltaTime.TotalSeconds);
                    if (Canvas.GetTop(imgHuevo3) >= 850)
                    {
                        Canvas.SetTop(imgHuevo3, -100);
                    }

                    double leftHuevo4Actual = Canvas.GetTop(imgHuevo4);
                    Canvas.SetTop(imgHuevo4, leftHuevo4Actual + 100 * deltaTime.TotalSeconds);
                    if (Canvas.GetTop(imgHuevo4) >= 850)
                    {
                        Canvas.SetTop(imgHuevo4, -100);
                    }

                    double leftHuevo5Actual = Canvas.GetTop(imgHuevo5);
                    Canvas.SetTop(imgHuevo5, leftHuevo5Actual + 70 * deltaTime.TotalSeconds);
                    if (Canvas.GetTop(imgHuevo5) >= 850)
                    {
                        Canvas.SetTop(imgHuevo5, -100);
                    }

                    tiempoAnterior = tiempoActual;
                }
                );
            }
        }
        private void miCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.A)
            {
                double topGalloActual = Canvas.GetLeft(imgGallo);
                Canvas.SetLeft(imgGallo, topGalloActual - 15);
            }
            if (e.Key == Key.Right || e.Key == Key.D)
            {
                double topGalloActual = Canvas.GetLeft(imgGallo);
                Canvas.SetLeft(imgGallo, topGalloActual + 15);
            }
        }
    }
}
