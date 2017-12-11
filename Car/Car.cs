using System;

namespace Car
{
    class Car
    {
        private uint year;
        private string make;
        private decimal topSpeed;
        public decimal speed;
        private const int INITIAL_SPEED = 0;
        private const int ACC_BRAKE_SPEED = 5;

        #region Constructor: car’s year and make as arguments.
        public Car(decimal tSpeed, uint prodYear, string makeName)
        {
            year = prodYear;
            make = makeName;
            speed = INITIAL_SPEED;
            topSpeed = tSpeed;
        }
        #endregion

        #region Accelerate Method
        public void Accelerate()
        {
            if (speed + ACC_BRAKE_SPEED < topSpeed)
                speed += ACC_BRAKE_SPEED;
            else
                speed = topSpeed;
        }
        #endregion

        #region Brake Method
        public void Brake()
        {
            if (speed - ACC_BRAKE_SPEED > INITIAL_SPEED)
                speed -= ACC_BRAKE_SPEED;
            else
                speed = INITIAL_SPEED;
        }
        #endregion
    }
}
