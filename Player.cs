using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectWebForms
{
    /// <summary>
    /// classes contain properties, interfaces, methods, inheritance and other fun stuff like scope
    /// </summary>
    public class Player
    {
        public string PlayerName = "";
        public string TeamName = "";
        public int TotalScores = 0;
        private int TotalGameFouls = 0;
        public int Health = 10;

        public Player(string playername, string teamname, int totalscores)
        {
            this.PlayerName = playername;
            this.TeamName = teamname;
            this.TotalScores = totalscores;
        }
        public Player()
        {

        }

        public void Shoot(int powerLevel, int direction)
        {
            //do something with the ball
            //animate it!
        }

        public void Foul(Player whoWasFouled, int howhard)
        {
            this.TotalGameFouls++;
            if(!this.CheckCanStillPlay())
            {
                //substitute
            }

            whoWasFouled.ReduceHealth(howhard);
            //animate it!
        }

        public void Score(int teamId, int minute)
        {
            //Game.LogScore(this.PlayerName, teamId, minute)
        }

        public bool CheckCanStillPlay()
        {
            return (this.TotalGameFouls <= 5);
            //if(this.TotalGameFouls > 5)
            //{
            //    return false;
            //}
            //return true;
        }

        public void ReduceHealth(int howhard)
        {
            this.Health--;
        }
    }
}