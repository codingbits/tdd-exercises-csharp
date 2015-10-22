using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public interface RandomNumberGenerator
    {
        int Generate(int from, int to);
    }
}
