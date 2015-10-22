using System;
using System.Collections.Generic;
using System.Text;

namespace roulette
{
    public class TableFullException : Exception
    {
    }
    public class TooManyChipsException : Exception
    {
    }

    public class RouletteTable
    {

        private readonly IList<Bet> EMPTY = new List<Bet>();
        private const int MAX_PLAYERS = 8;
        private IDictionary<int, List<Bet>> betsByFields = new Dictionary<int, List<Bet>>();

        private int maxChipsOnTable;

        private IDictionary<Player, Colour> players = new Dictionary<Player, Colour>();

        public void PlaceBet(Player p, int field, int value)
        {
            if (CurrentChipsOnTable() + value > maxChipsOnTable) throw new TooManyChipsException();
            if (!players.ContainsKey(p) && players.Count == MAX_PLAYERS) throw new TableFullException();
            if (!players.ContainsKey(p)) players.Add(p, (Colour)Enum.GetValues(typeof(Colour)).GetValue(players.Count));
            if (!betsByFields.ContainsKey(field))
            {
                betsByFields.Add(field, new List<Bet>());
            }
            betsByFields[field].Add(new Bet(p, value));
        }
        private int CurrentChipsOnTable()
        {
            int total = 0;
            foreach (List<Bet> bets in betsByFields.Values)
            {
                foreach (Bet bet in bets)
                {
                    total = total + bet.Value;
                }
            }
            return total;
        }
        public IList<Bet> BetsByField(int field)
        {
            if (!betsByFields.ContainsKey(field)) return EMPTY;
            return betsByFields[field];
        }
        public RouletteTable(int maxChipsOnTable)
        {
            this.maxChipsOnTable = maxChipsOnTable;
        }
        public IDictionary<Player, Colour> Colour
        {
            get { return players; }
        }
    }
}
