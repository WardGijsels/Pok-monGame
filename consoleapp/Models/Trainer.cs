using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Trainer
    {
        // Attributen
        private string _naam;
        private string _pokémon;

        // Properties
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public string Pokémon
        {
            get { return _pokémon; }
            set { _pokémon = value; }
        }

        // Constructor
        public Trainer(string naam, string pokémon)
        {
            this.Naam = naam;
            this.Pokémon = pokémon;
        }

        // Methodes
        public override string ToString() 
        {
            return $"{this.Naam} - {this.Pokémon}";
        }
    }
}
