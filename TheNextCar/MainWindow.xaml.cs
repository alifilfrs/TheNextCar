using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheNextCar.Controller;
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

namespace TheNextCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, OnDoorChanged, OnPowerChanged, OnCarEngineStatusChanged
    {
        private Car nextCar;

        public MainWindow()
        {
            InitializeComponent();
            AccubatteryController accubaterryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);
            nextCar = new Car(accubaterryController, doorController, this);
        }

        public void carEngineStatusChanged(string value, string message)
        {
            Status.Content = message;
            StartButton.Content = value;
        }
        public void doorSecurityChanged(string vale, string message)
        {
            this.LockDoorState.Content = message;
            this.LockDoorButton.Content = vale;
        }
        public void doorStatusChanged(string vale, string message)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButton.Content = vale;
        }
        public void onPowerChangedStatus(string value, string message)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }

        private void OnAccuButtonClicked(object sender,
       RoutedEventArgs e)
        {
            Console.WriteLine("button aki");
            this.nextCar.toggleThePowerButton();
        }
        private void OnDoorOpenButtonClicked(object sender,
        RoutedEventArgs e)
        {
            Console.WriteLine("button pintu");
            this.nextCar.toggleTheDoorButton();
        }
        private void OnLockDoorButtonClicked(object sender,
        RoutedEventArgs e)
        {
            Console.WriteLine("button kunci pintu");
            this.nextCar.toggleTheLoockDoorButton();
        }
        private void OnStartButtonClicked(object sender,
       RoutedEventArgs e)
        {
            Console.WriteLine("button start");
            this.nextCar.toggleStartEngineButton();

        }


    }
}
