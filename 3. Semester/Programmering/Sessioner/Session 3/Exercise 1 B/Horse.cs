using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1_B
{
    public class Horse : IRentable
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public bool IsAvailable { get; set; }

        public Horse(string name, string breed)
        {
            Name = name;
            Breed = breed;
            IsAvailable = true;
        }

        public void Rent()
        {
            IsAvailable = false;
        }
    }
}