using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public interface WinningStrategy
    {
        bool WinsOn(int wheelPosition);
    }
}
