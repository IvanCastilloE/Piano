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

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Piano
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WaveOut waveOut;
        private MixingSampleProvider mixer;
        public MainWindow()
        {
            InitializeComponent();waveOut = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;

            if (e.Key == Key.Z)
            {
                Button_Click(this, null);
            }
            if(e.Key == Key.X)
            {
                BtnRe_Click(this, null);
            }
            if(e.Key == Key.S)
            {
                BtnDoSos_Click(this, null);
            }
            if (e.Key == Key.D)
            {
                BtnReSos_Click(this, null);
            }
            if (e.Key == Key.C)
            {
                BtnMi_Click(this, null);
            }
            if (e.Key == Key.V)
            {
                BtnFa_Click(this, null);
            }
            if (e.Key == Key.G)
            {
                BtnFaSos_Click(this, null);
            }
            if (e.Key == Key.B)
            {
                BtnSol_Click(this, null);
            }
            if (e.Key == Key.H)
            {
                BtnSolSos_Click(this, null);
            }
            if (e.Key == Key.N)
            {
                BtnLa_Click(this, null);
            }
            if (e.Key == Key.J)
            {
                BtnLaSos_Click(this, null);
            }
            if (e.Key == Key.M)
            {
                BtnSi_Click(this, null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nota_do = new SignalGenerator(44100,1)
            {
                Gain = 20.8,
                Frequency = 261.626,
                Type = SignalGeneratorType.Sin            
            }.Take(TimeSpan.FromMilliseconds(250));
            mixer.AddMixerInput(nota_do);
        }

        private void BtnDoSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_doSos = DoModificado(1.0 / 12.0);
            mixer.AddMixerInput(nota_doSos);
        }

        private ISampleProvider NotaDo()
        {
            var nota_do = new SignalGenerator(44100, 1)
            {
                Gain = 20.8,
                Frequency = 261.626,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(250));
            return nota_do;
        }

        private void BtnRe_Click(object sender, RoutedEventArgs e)
        {
            var nota_re = DoModificado(2.0 / 12.0);
            mixer.AddMixerInput(nota_re);
        }
        private SmbPitchShiftingSampleProvider DoModificado(double exponente)
        {
            var nota_do = NotaDo();
            var nota_modificada = new SmbPitchShiftingSampleProvider(nota_do);
            //(2^(y/12))*x
            nota_modificada.PitchFactor = (float)Math.Pow(2.0, exponente);
            return nota_modificada;
        }

        private void BtnReSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_reSos = DoModificado(3.0 / 12.0);
            mixer.AddMixerInput(nota_reSos);
        }

        private void BtnMi_Click(object sender, RoutedEventArgs e)
        {
            var nota_mi = DoModificado(4.0 / 12.0);
            mixer.AddMixerInput(nota_mi);
        }

        private void BtnFa_Click(object sender, RoutedEventArgs e)
        {
            var nota_fa = DoModificado(5.0 / 12.0);
            mixer.AddMixerInput(nota_fa);
        }

        private void BtnFaSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(6.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }

        private void BtnSol_Click(object sender, RoutedEventArgs e)
        {
            var nota_sol = DoModificado(7.0 / 12.0);
            mixer.AddMixerInput(nota_sol);
        }

        private void BtnSolSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_solSos = DoModificado(8.0 / 12.0);
            mixer.AddMixerInput(nota_solSos);
        }

        private void BtnLa_Click(object sender, RoutedEventArgs e)
        {
            var nota_la = DoModificado(9.0 / 12.0);
            mixer.AddMixerInput(nota_la);
        }

        private void BtnLaSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_laSos = DoModificado(10.0 / 12.0);
            mixer.AddMixerInput(nota_laSos);
        }

        private void BtnSi_Click(object sender, RoutedEventArgs e)
        {
            var nota_si = DoModificado(11.0 / 12.0);
            mixer.AddMixerInput(nota_si);
        }
    }
}
