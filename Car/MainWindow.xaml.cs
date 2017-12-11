using Car;
using System.Windows;

namespace CarSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DriveCars vmCar;
        private int gridColWidth;
        private const int DISTANCE_INC = 20;
        private const int INITIAL_DISTANCE = 5;
        private const int IMAGE_WIDTH = 80;

        public MainWindow()
        {
            InitializeComponent();
            vmCar = new DriveCars();
            DataContext = vmCar;

            gridColWidth = (int)GrdMain.ColumnDefinitions[1].Width.Value - IMAGE_WIDTH - INITIAL_DISTANCE;    //get the remaining width
        }

        #region BtnAccelerate_Click: Accelerate, move cars, and show winner
        private void BtnAccelerate_Click(object sender, RoutedEventArgs e)
        {
            int currDist, distance;

            switch (vmCar.RaceFormulaOne((int)DriveCars.Actions.ONE))
            {
                case ((int)DriveCars.CarID.ONE):
                    currDist = (int)ImgCar1.Margin.Left;
                    distance = currDist + DISTANCE_INC;
                    ImgCar1.Margin = new Thickness { Left = (distance >= gridColWidth) ? gridColWidth : distance };

                    if (distance >= gridColWidth)
                        ImgStatus1.Visibility = Visibility.Visible;
                    break;
                case ((int)DriveCars.CarID.TWO):
                    currDist = (int)ImgCar2.Margin.Left;
                    distance = currDist + DISTANCE_INC;
                    ImgCar2.Margin = new Thickness { Left = (distance >= gridColWidth) ? gridColWidth : distance };

                    if (distance >= gridColWidth)
                        ImgStatus2.Visibility = Visibility.Visible;
                    break;
                case ((int)DriveCars.CarID.THREE):
                    currDist = (int)ImgCar3.Margin.Left;
                    distance = currDist + DISTANCE_INC;
                    ImgCar3.Margin = new Thickness { Left = (distance >= gridColWidth) ? gridColWidth : distance };

                    if (distance >= gridColWidth)
                        ImgStatus3.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion

        #region BtnBrake_Click: Brake
        private void BtnBrake_Click(object sender, RoutedEventArgs e)
        {
            vmCar.RaceFormulaOne((int)DriveCars.Actions.TWO);            //Action 2: Brake
        }
        #endregion

        #region Reset All
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ImgCar1.Margin = new Thickness { Left = INITIAL_DISTANCE };
            ImgCar2.Margin = new Thickness { Left = INITIAL_DISTANCE };
            ImgCar3.Margin = new Thickness { Left = INITIAL_DISTANCE };

            ImgStatus1.Visibility = Visibility.Hidden;
            ImgStatus2.Visibility = Visibility.Hidden;
            ImgStatus3.Visibility = Visibility.Hidden;

            vmCar.Reset();
        }
        #endregion
    }
}
