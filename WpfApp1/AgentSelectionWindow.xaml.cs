using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace WpfApp1
{
    // Modèle de données pour un agent
    public class Agent
    {
        
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Continent { get; set; }
        public string RoleKey { get; set; } 
        public int ReleaseDate { get; set; }     
        public string ImagePath { get; set; }

    }

    public partial class AgentSelectionWindow : Window
    {
        private Agent _selectedAgent;
        private Agent _targetAgent;
        private List<Agent> _allAgents;
        private Random _random = new Random();
        private int _attemptCount = 0;

        private static readonly string[] Columns = { "Name", "Gender", "Role", "Continent", "Release Year" };

        public AgentSelectionWindow()
        {
            InitializeComponent();
            LoadAgents();
            PickRandomTarget();
            BuildHeaderRow();

        }

        private void LoadAgents()
        {
            _allAgents = new List<Agent>
            {
                // ── DUELISTS ─────────────────────────────────────
                new Agent { Name = "Jett",   Gender = "Woman", RoleKey = "Duelist", Continent = "Asia", ReleaseDate = 2020, ImagePath = "Images/Jett.png"},
                new Agent { Name = "Reyna", Gender = "Woman", RoleKey = "Duelist",Continent = "America", ReleaseDate = 2020, ImagePath = "Images/Reyna.png"},
                new Agent { Name = "Phoenix", Gender = "Man", RoleKey = "Duelist",Continent = "Europe", ReleaseDate = 2020, ImagePath = "Images/Phoenix.png"},
                new Agent { Name = "Raze", Gender = "Woman", RoleKey = "Duelist", Continent = "America", ReleaseDate = 2020, ImagePath = "Images/Raze.png"},
                new Agent { Name = "Yoru", Gender = "Man", RoleKey = "Duelist", Continent = "Asia", ReleaseDate = 2021, ImagePath = "Images/Yoru.png"},
                new Agent { Name = "Neon", Gender = "Woman",RoleKey = "Duelist", Continent = "Asia", ReleaseDate = 2022, ImagePath = "Images/Neon.png"},
                new Agent { Name = "Iso", Gender = "Man", RoleKey = "Duelist", Continent = "Asia", ReleaseDate = 2023, ImagePath = "Images/Iso.png"},
                new Agent { Name = "Waylay",Gender = "Woman", RoleKey = "Duelist", Continent = "Asia", ReleaseDate = 2025, ImagePath = "Images/Waylay.png"},

                // ── INITIATORS ────────────────────────────────────
                new Agent { Name = "Sova", Gender = "Man", RoleKey = "Initiator", Continent = "Europe", ReleaseDate = 2020, ImagePath = "Images/Sova.png"},
                new Agent { Name = "Breach",  Gender = "Man", RoleKey = "Initiator",Continent = "", ReleaseDate = 2020, ImagePath = "Images/Breach.png"},
                new Agent { Name = "Skye",   Gender = "Woman", RoleKey = "Initiator",Continent = "Oceania", ReleaseDate = 2020, ImagePath = "Images/Skye.png" },
                new Agent { Name = "KAY/O",  Gender = "Man", RoleKey = "Initiator", Continent = "Asia", ReleaseDate = 2021, ImagePath = "Images/KAYO.png"},
                new Agent { Name = "Fade",   Gender = "Woman", RoleKey = "Initiator", Continent = "Africa", ReleaseDate = 2022, ImagePath = "Images/Fade.png"},
                new Agent { Name = "Gekko",  Gender = "Man", RoleKey = "Initiator", Continent = "America", ReleaseDate = 2023, ImagePath = "Images/Gekko.png"},
                new Agent { Name = "Tejo",   Gender = "Man", RoleKey = "Initiator", Continent = "America", ReleaseDate = 2025, ImagePath = "Images/Tejo.png"},

                // ── CONTROLLERSS ────────────────────────────────────
                new Agent { Name = "Brimstone",  Gender = "Man",RoleKey = "Controller", Continent = "America", ReleaseDate = 2020, ImagePath = "Images/Brimstone.png"},
                new Agent { Name = "Omen",    Gender = "Man",  RoleKey = "Controller", Continent = "Unknown", ReleaseDate = 2020 , ImagePath = "Images/Omen.png"},
                new Agent { Name = "Viper",    Gender = "Woman", RoleKey = "Controller", Continent = "America", ReleaseDate = 2020, ImagePath = "Images/Viper.png"  },
                new Agent { Name = "Astra",    Gender = "Woman",  RoleKey = "Controller", Continent = "Africa", ReleaseDate = 2021, ImagePath = "Images/Astra.png"},
                new Agent { Name = "Harbor",  Gender = "Man", RoleKey = "Controller",Continent = "Asia", ReleaseDate = 2022 , ImagePath = "Images/Harbor.png"},
                new Agent { Name = "Clove",   Gender = "Non Binary",  RoleKey = "Controller", Continent = "Europe", ReleaseDate = 2024 , ImagePath = "Images/Clove.png" },

                // ── SENTINELS ────────────────────────────────────
                new Agent { Name = "Sage",    Gender = "Woman", RoleKey = "Sentinel", Continent = "Asia", ReleaseDate = 2020, ImagePath = "Images/Sage.png" },
                new Agent { Name = "Cypher",  Gender = "Man",  RoleKey = "Sentinel", Continent = "Africa", ReleaseDate = 2020, ImagePath = "Images/Cypher.png" },
                new Agent { Name = "Killjoy", Gender = "Woman",RoleKey = "Sentinel",Continent = "Europe", ReleaseDate = 2020, ImagePath = "Images/Killjoy.png" },
                new Agent { Name = "Chamber",  Gender = "Man", RoleKey = "Sentinel",Continent = "Europe", ReleaseDate = 2021, ImagePath = "Images/Chamber.png"},
                new Agent { Name = "Deadlock", Gender = "Woman",RoleKey = "Sentinel", Continent = "Europe", ReleaseDate = 2023, ImagePath = "Images/Deadlock.png"},
                new Agent { Name = "Vyse",     Gender = "Woman", RoleKey = "Sentinel", Continent = "Unknown", ReleaseDate = 2024, ImagePath = "Images/Vyse.png"},
                new Agent { Name = "Veto",    Gender = "Man",  RoleKey = "Sentinel", Continent = "Africa", ReleaseDate = 2025, ImagePath = "Images/Veto.png"}
            };
            AgentListBox.ItemsSource = _allAgents;
           
        }

        private void PickRandomTarget()
        {
            int index = _random.Next(_allAgents.Count);
            _targetAgent = _allAgents[index];
        }

        private void BuildHeaderRow()
        {

            var header = new Grid { Margin = new Thickness(0, 0, 0, 5) };
            AddColumnsToGrid(header);

            foreach (var cols in Columns)
            {
                int ind = Array.IndexOf(Columns, cols);
                var cell = MakeCell(cols, Brushes.Transparent, Brushes.Gray);
                Grid.SetColumn(cell, ind);
                header.Children.Add(cell);
            }

            GuessPanel.Children.Add(header);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedAgent = AgentListBox.SelectedItem as Agent;
            if (_selectedAgent != null)
            {
                SelectedAgentText.Text = _selectedAgent.Name;
                ConfirmButton.IsEnabled = true;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAgent == null) return;

            AddGuessRow(_selectedAgent);
            _attemptCount++;
            AttemptText.Text = $"{_attemptCount} attempt(s)";

            if (_selectedAgent.Name == _targetAgent.Name)
            {
                MessageBox.Show($"VICTORY !!! You guessed {_targetAgent.Name} in {_attemptCount} attempt(s) !!","", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (_attemptCount > 4)
            {
                MessageBox.Show($"DEFEAT... \n The answer was {_targetAgent.Name} !!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            AgentListBox.SelectedItem = null;
            ConfirmButton.IsEnabled= false; 
            SelectedAgentText.Text= "No Agent chosen";
        }
        private Border MakeNameCell(Agent agent)
        {
            bool nameOk = agent.Name == _targetAgent.Name;
            
            
            var image = new Image
            {
                Width = 40,
                Height = 40,
                Stretch = Stretch.UniformToFill,
                Source = new BitmapImage(new Uri(agent.ImagePath, UriKind.Relative))
            };

            
            var label = new TextBlock
            {
                Text = agent.Name,
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold,
                FontSize = 11,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };

            var stack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            stack.Children.Add(image);
            stack.Children.Add(label);

            return new Border
            {
                Background = nameOk ? Brushes.Green : Brushes.Red,
                CornerRadius = new CornerRadius(6),
                Margin = new Thickness(4),
                Height = 60,
                Child = stack
            };
        }
        private void AddGuessRow(Agent guess)
        {
            var row = new Grid { Margin = new Thickness(0, 0, 0, 4) };
            AddColumnsToGrid(row);

            var nameCell = MakeNameCell(guess);
            Grid.SetColumn(nameCell, 0);
            row.Children.Add(nameCell);

            bool genderOk = guess.Gender == _targetAgent.Gender;
            var genderCell = MakeCell(guess.Gender, genderOk ? Brushes.Green : Brushes.Red, Brushes.White);
            Grid.SetColumn(genderCell, 1);
            row.Children.Add(genderCell);

            bool roleOk = guess.RoleKey == _targetAgent.RoleKey;
            var roleCell = MakeCell(guess.RoleKey, roleOk ? Brushes.Green : Brushes.Red, Brushes.White);
            Grid.SetColumn(roleCell, 2);
            row.Children.Add(roleCell);

            bool contOk = guess.Continent == _targetAgent.Continent;
            var contCell = MakeCell(guess.Continent, contOk ? Brushes.Green : Brushes.Red, Brushes.White);
            Grid.SetColumn(contCell, 3);
            row.Children.Add(contCell);

            bool yearOk = guess.ReleaseDate == _targetAgent.ReleaseDate;
            string yearText = guess.ReleaseDate.ToString();
           
           
            var yearCell = MakeCell(yearText, yearOk ? Brushes.Green : Brushes.Red, Brushes.White);
            Grid.SetColumn(yearCell, 4);
            row.Children.Add(yearCell);

            GuessPanel.Children.Add(row);

        }

        private void AddColumnsToGrid(Grid grid) 
        {

            for (int i = 0; i < Columns.Length; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        private Border MakeCell(string text, Brush background, Brush foreground)
        {
            return new Border
            {
                Background = background,
                CornerRadius = new CornerRadius(6),
                Margin = new Thickness(4),
                Height = 60,
                Child = new TextBlock
                {
                    Text = text,
                    Foreground = foreground,
                    FontWeight = FontWeights.Bold,
                    FontSize = 13,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center
                }
            };
        }
    }
}



     
       

     
       

        