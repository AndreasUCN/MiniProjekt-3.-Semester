using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1_B
{
    public class Car : IRentable, IServiceable
    {
        private int mileageAtLastService;

        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int Mileage { get; set; }
        public bool NeedsService { get; set; }
        public int ServiceIntervalInKilometers { get; set; }
        public int TopSpeed { get; set; }

        public Car(string description, int topSpeed, int mileage = 0)
        {
            Description = description;
            TopSpeed = topSpeed;
            Mileage = mileage;

            IsAvailable = true;

            mileageAtLastService = mileage;
            ServiceIntervalInKilometers = 10000;
            NeedsService = false;
        }

        public void Drive(int distance)
        {
            Mileage += distance;

            if (Mileage - mileageAtLastService >= ServiceIntervalInKilometers)
            {
                NeedsService = true;
                IsAvailable = false;
            }
        }

        public void Rent()
        {
            IsAvailable = false;
        }

        public void ResetNeedForService()
        {
            mileageAtLastService = Mileage;
            NeedsService = false;
        }
    }
}
