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
        private IDictionary<Field, List<Bet>> betsByFields = new Dictionary<Field, List<Bet>>();

        private int maxChipsOnTable;

        private IDictionary<Player, Colour> players = new Dictionary<Player, Colour>();

        public void PlaceBet(Player p, int field, int value)
        {
            PlaceBet(p, new Field[] { Field.ForNumber(field) }, value);
        }
        public void PlaceBet(Player p, Field field, int value)
        {
            PlaceBet(p, new Field[] { field }, value);
        }
        public void PlaceBet(Player p, Field[] fields, int value)
        {
            if (CurrentChipsOnTable() + value > maxChipsOnTable) throw new TooManyChipsException();
            if (!players.ContainsKey(p) && players.Count == MAX_PLAYERS) throw new TableFullException();
            if (!players.ContainsKey(p)) players.Add(p, (Colour)Enum.GetValues(typeof(Colour)).GetValue(players.Count));
            foreach (Field field in fields)
            {
                if (!betsByFields.ContainsKey(field))
                {
                    betsByFields.Add(field, new List<Bet>());
                }
                betsByFields[field].Add(new Bet(p, value, GetBetType(fields)));
            }
        }
        private BetType GetBetType(Field[] fields)
        {
            if (fields.Length== 1) return BetType.SINGLE;
            if (fields.Length == 2) return BetType.SPLIT;
            throw new ArgumentException("Unsupported bet type for " + fields + " fields");
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
            return BetsByField(Field.ForNumber(field));
        }
        public IList<Bet> BetsByField(Field field)
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
