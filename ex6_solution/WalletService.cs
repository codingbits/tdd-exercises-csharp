using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public interface WalletService
    {
        void AdjustBalance(Player p, int amount);

        bool IsAvailable(Player p, int amount);
 
    }
}
