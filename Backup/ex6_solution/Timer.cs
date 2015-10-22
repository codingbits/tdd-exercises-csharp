using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public delegate void TimerCallBack();
    public interface Timer
    {
        void CallBack(long howMuchLaterInMillis, TimerCallBack what);

        long TimeInMillis { get; }
 
    }
}
