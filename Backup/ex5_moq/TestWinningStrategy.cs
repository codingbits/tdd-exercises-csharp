using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public class TestWinningStrategy:WinningStrategy
    {
        int expectedPosition;
	    bool expectedOutcome;
	    public TestWinningStrategy(int expectedPosition, bool expectedOutcome) {
		    this.expectedOutcome=expectedOutcome;
		    this.expectedPosition=expectedPosition;
	    }
	    public bool WinsOn(int wheelPosition) {
		    if (wheelPosition==expectedPosition) return expectedOutcome;
		    return false;
	    } 
    }
}
