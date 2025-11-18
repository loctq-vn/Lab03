using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bai1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LogEvent(string eventName)
        {
            string logEntry = $"{DateTime.Now:HH:mm:ss.fff} - {eventName}";
            LogListBox.Items.Add(logEntry);

            if (LogListBox.Items.Count > 0)
            {
                LogListBox.ScrollIntoView(LogListBox.Items[LogListBox.Items.Count - 1]);
            }
        }
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            LogEvent("SourceInitialized");
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            LogEvent("Initialized");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LogEvent("Loaded");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LogEvent("Activated");
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            LogEvent("Deactivated");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            LogEvent("Closed");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LogEvent("Closing");
        }
        private void btn_NewForm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cửa sổ mới nè!");
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}