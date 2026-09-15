using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1_B
{
    public interface IRentable
    {
        bool IsAvailable { get; }

        void Rent();
    }
}
