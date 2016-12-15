using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Ratuj_ludzi2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startBbutton_Click(object sender, RoutedEventArgs e)
        {
            AddEnemy();
        }

        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl();
            enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
            AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, "(Canvas.Left)");
            AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100),
                random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");
            playArea.Children.Add(enemy);
        }

        private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToAnimate)
        {
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
            };
            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
