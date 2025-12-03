
using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Drawing;

namespace projectnet
{
    public partial class FormBandwidthChart : Form
    {
        private readonly Func<long> bandwidthProvider;
        private Timer updateTimer;
        private ChartValues<double> bandwidthValues;
        private long lastTotalBytes;
        private Button btnToggle;
        private bool isPaused = false;

        public FormBandwidthChart(Func<long> bandwidthProvider)
        {
            InitializeComponent();
            this.bandwidthProvider = bandwidthProvider;

            bandwidthValues = new ChartValues<double>();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Bandwidth (Kbps)",
                    Values = bandwidthValues,
                    PointGeometry = null,
                    Stroke = System.Windows.Media.Brushes.LightGreen,
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Time (s)",
                LabelsRotation = 0,
                Foreground = System.Windows.Media.Brushes.White
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Kbps",
                LabelFormatter = value => value.ToString("N2"),
                Foreground = System.Windows.Media.Brushes.White
            });

            cartesianChart1.BackColor = Color.FromArgb(30, 30, 30);
            cartesianChart1.ForeColor = Color.White;

            lastTotalBytes = bandwidthProvider();

            updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1 second
            updateTimer.Tick += UpdateChart;
            updateTimer.Start();

            AddToggleButton();
        }

        private void AddToggleButton()
        {
            btnToggle = new Button();
            btnToggle.Text = "Pause";
            btnToggle.Size = new Size(80, 30);
            btnToggle.Location = new Point(10, 10);
            btnToggle.BackColor = Color.DimGray;
            btnToggle.ForeColor = Color.White;
            btnToggle.Click += BtnToggle_Click;
            Controls.Add(btnToggle);
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            btnToggle.Text = isPaused ? "Resume" : "Pause";
        }

        private void UpdateChart(object sender, EventArgs e)
        {
            if (isPaused) return;

            long currentBytes = bandwidthProvider();
            long deltaBytes = currentBytes - lastTotalBytes;
            double Mbps = (deltaBytes * 8.0) / 1_000_000.0; 
            bandwidthValues.Add(Mbps);

            if (bandwidthValues.Count > 30)
                bandwidthValues.RemoveAt(0);

            lastTotalBytes = currentBytes;
        }
    }
}
