using System;
using System.Collections.Generic;

using MbUnit.Framework;
namespace roulette
{
    [TestFixture]
    public class RouletteTest
    {

        Player p;
        RouletteTable rt;
        [SetUp]
        public void SetUp()
        {
            p = new Player();
            rt = new RouletteTable(10000);
        }
        [Test]
        public void Player_can_place_bets_on_number_fields()
        {
            rt.PlaceBet(p, 17, 200);
            Assert.AreEqual(new Bet(p, 200), rt.BetsByField(17)[0]);
        }
        [Test]
        public void Player_can_place_bets_on_different_fields_and_with_different_values()
        {
            rt.PlaceBet(p, 17, 200);
            rt.PlaceBet(p, 2, 600);
            rt.PlaceBet(p, 30, 1000);
            Assert.AreEqual(new Bet(p, 200), rt.BetsByField(17)[0]);
            Assert.AreEqual(new Bet(p, 600), rt.BetsByField(2)[0]);
            Assert.AreEqual(new Bet(p, 1000), rt.BetsByField(30)[0]);
        }
        [Test]
        public void Total_number_of_chips_is_limited_by_the_table_and_the_table_can_refuse_a_bet_if_there_are_too_many_chips()
        {
            RouletteTable rt = new RouletteTable(300);
            Player p = new Player();
            rt.PlaceBet(p, 17, 200);
            bool exceptionThrown = false;
            try
            {
                rt.PlaceBet(new Player(), 20, 200);
            }
            catch (TooManyChipsException)
            {
                exceptionThrown = true;
            }
            // the following should be true
            Assert.AreEqual(0, rt.BetsByField(20).Count);
            Assert.IsTrue(exceptionThrown);
        }
        [Test]
        [ExpectedException(typeof(TableFullException))]
        public void Up_to_eight_players_can_join_a_game()
        {
            Player[] players = new Player[8];
            for (int i = 0; i < 8; i++)
            {
                players[i] = new Player();
                rt.PlaceBet(players[i], 20, 100);
            }
            Player nine = new Player();
            rt.PlaceBet(nine, 20, 100);
        }
        [Test]
        public void Each_player_is_assigned_a_different_colour()
        {
            Player[] players = new Player[8];
            for (int i = 0; i < 8; i++)
            {
                players[i] = new Player();
                rt.PlaceBet(players[i], 20, 100);
            }
            for (int i = 0; i < players.Length- 1; i++)
                for (int j = i + 1; j < players.Length; j++)
                    Assert.IsTrue(rt.Colour[players[i]] != rt.Colour[players[j]]);
        }
    }
}
