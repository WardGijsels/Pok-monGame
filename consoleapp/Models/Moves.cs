using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Moves
    {
        // Attr
        private string _naam;
        private string _type;
        private int _power;
        private int _accuracy;

        // Props
        public string Naam 
        { 
            get { return _naam; } 
            set { _naam = value; } 
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public int Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

        // Constructor
        public Moves(string naam, string type, int power, int accuracy)
        {
            this.Naam = naam;
            this.Type = type;
            this.Power = power;
            this.Accuracy = accuracy;
        }

        // Methodes
        public void Aanval(Pokémon pokemon, Moves moves)
        {
            pokemon.Hp -= moves.Power;
        }

        public override string ToString()
        {
            return $"{this.Naam} - {this.Type} - Power: {this.Power} - Accuracy: {this.Accuracy}";
        }

    }
}
