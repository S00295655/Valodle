using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    // Modèle de données pour un agent
    public class Agent
    {
        public string Name { get; set; }
        public string RoleKey { get; set; } 
        public string Emoji { get; set; }     
    }

    public partial class AgentSelectionWindow : Window
    {
        private Agent _selectedAgent;
        private List<Agent> _allAgents;

        public AgentSelectionWindow()
        {
            InitializeComponent();
            LoadAgents();
        }

        private void LoadAgents()
        {
            _allAgents = new List<Agent>
            {
                // ── DUELISTS ─────────────────────────────────────
                new Agent { Name = "Jett",   RoleKey = "Duelist", Emoji = "."},
                new Agent { Name = "Reyna",  RoleKey = "Duelist", Emoji = "." },
                new Agent { Name = "Phoenix",  RoleKey = "Duelist", Emoji = "."},
                new Agent { Name = "Raze",  RoleKey = "Duelist", Emoji = ".",},
                new Agent { Name = "Yoru",  RoleKey = "Duelist", Emoji = "."},
                new Agent { Name = "Neon", RoleKey = "Duelist", Emoji = "."},
                new Agent { Name = "Iso",  RoleKey = "Duelist", Emoji = "." },
                new Agent { Name = "Waylay", RoleKey = "Duelist", Emoji = ".",},

                // ── INITIATORS ────────────────────────────────────
                new Agent { Name = "Sova",  RoleKey = "Initiator", Emoji = ".",},
                new Agent { Name = "Breach",   RoleKey = "Initiator", Emoji = "." },
                new Agent { Name = "Skye",    RoleKey = "Initiator", Emoji = "." },
                new Agent { Name = "KAY/O",   RoleKey = "Initiator", Emoji = "."},
                new Agent { Name = "Fade",    RoleKey = "Initiator", Emoji = "."},
                new Agent { Name = "Gekko",   RoleKey = "Initiator", Emoji = "."},
                new Agent { Name = "Tejo",    RoleKey = "Initiator", Emoji = "."},

                // ── CONTROLLERSS ────────────────────────────────────
                new Agent { Name = "Brimstone",  RoleKey = "Controller", Emoji = ".",},
                new Agent { Name = "Omen",      RoleKey = "Controller", Emoji = ".", },
                new Agent { Name = "Viper",     RoleKey = "Controller", Emoji = ".",  },
                new Agent { Name = "Astra",      RoleKey = "Controller", Emoji = ".", },
                new Agent { Name = "Harbor",   RoleKey = "Controller", Emoji = ".", },
                new Agent { Name = "Clove",     RoleKey = "Controller", Emoji = ".",  },

                // ── SENTINELS ────────────────────────────────────
                new Agent { Name = "Sage",     RoleKey = "Sentinel", Emoji = ".", },
                new Agent { Name = "Cypher",    RoleKey = "Sentinel", Emoji = ".", },
                new Agent { Name = "Killjoy", RoleKey = "Sentinel", Emoji = ".", },
                new Agent { Name = "Chamber",   RoleKey = "Sentinel", Emoji = ".",},
                new Agent { Name = "Deadlock", RoleKey = "Sentinel", Emoji = ".", },
                new Agent { Name = "Vyse",      RoleKey = "Sentinel", Emoji = "."},
            };

            AgentsGrid.ItemsSource = _allAgents;
        }

     
        private void AgentCard_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string agentName)
            {
                _selectedAgent = _allAgents.FirstOrDefault(a => a.Name == agentName);
                if (_selectedAgent != null)
                {
                   
                   
                }
            }
        }

     
       

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAgent != null)
            {
                MessageBox.Show(
                    $"You selected : {_selectedAgent.Name}\n",
                    "Agent chosen",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
