using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public class TestRandomNumberGenerator: RandomNumberGenerator
    {
        public int NextOutcome { get; set;}
    	public int Generate(int from, int to) {
	    	return NextOutcome;
	    }
    }
}
