using System;

namespace FanDuel
{
    public class Player:IEquatable<Player>
    {
        public string Number { get; set; } //unique
        public string Name { get; set; }

        public Player(string number, string name)
        {
            Number = number;
            Name = name;
        }

        public bool Equals(Player other)
        {
            if (other == null) return false;
            if (other.Number.Equals(Number)) 
                return true;
            return false;
        }
    }
}
