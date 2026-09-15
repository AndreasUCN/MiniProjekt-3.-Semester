using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1_B
{
    public interface IServiceable
    {
        bool NeedsService { get; }

        void ResetNeedForService();
    }
}