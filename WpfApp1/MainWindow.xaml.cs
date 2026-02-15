using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Bouton "Play Now" → ouvre la fenêtre de sélection d'agent
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var agentWindow = new AgentSelectionWindow();
            agentWindow.Owner = this;
            agentWindow.ShowDialog();
        }

        
    }
}
