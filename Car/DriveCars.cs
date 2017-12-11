using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Car
{
    class DriveCars : INotifyPropertyChanged
    {
        private List<string> carMake = new List<string>() { "Volkswagen Golf GTI", "Ford Focus ST", "VANTAGE GT4" };
        private List<uint> carYear = new List<uint>() { 2017, 2017, 2014 };
        private List<decimal> carTopSpeed = new List<decimal>() { 130m, 154m, 190m };    //in mph: Miles per Hour
        private List<Car> cars;
        private Random r;
        private const int NBR_OF_CARS = 3;
        private const int ZERO = 0;

        #region Constructor: Create a car list
        public DriveCars()
        {
            r = new Random();
            cars = new List<Car>();

            for (int i = 0; i < NBR_OF_CARS; i++)
                cars.Add(new Car(carTopSpeed[i], carYear[i], carMake[i]));  //create car objects
        }
        #endregion

        #region Enum CarID
        public enum CarID
        {
            ONE,
            TWO,
            THREE
        };
        #endregion

        #region Enum Actions
        public enum Actions
        {
            ONE = 1,    //Accelerate
            TWO     //Brake
        };
        #endregion

        #region Speed
        public decimal Speedometer1
        {
            get { return cars[(int)CarID.ONE].speed; }
            set { cars[(int)CarID.ONE].speed = value; OnPropertyChanged(); }
        }
        public decimal Speedometer2
        {
            get { return cars[(int)CarID.TWO].speed; }
            set { cars[(int)CarID.TWO].speed = value; OnPropertyChanged(); }
        }
        public decimal Speedometer3
        {
            get { return cars[(int)CarID.THREE].speed; }
            set { cars[(int)CarID.THREE].speed = value; OnPropertyChanged(); }
        }
        #endregion

        #region RaceFormulaOne
        public int RaceFormulaOne(int actionId)
        {
            int carId = r.Next(ZERO, NBR_OF_CARS);     //Car number: 0, 1 or 2

            //Accelerate or brake
            switch (actionId)
            {
                case (int)Actions.ONE:
                    cars.ElementAt(carId).Accelerate();
                    break;
                case (int)Actions.TWO:
                    cars.ElementAt(carId).Brake();
                    break;
            }

            //Change speed
            switch (carId)
            {
                case (int)CarID.ONE:
                    Speedometer1 = cars[carId].speed;
                    break;
                case (int)CarID.TWO:
                    Speedometer2 = cars[carId].speed;
                    break;
                case (int)CarID.THREE:
                    Speedometer3 = cars[carId].speed;
                    break;
            }

            return carId;
        }
        #endregion

        #region Reset
        public void Reset()
        {
            Speedometer1 = ZERO;
            Speedometer2 = ZERO;
            Speedometer3 = ZERO;
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion
    }
}
