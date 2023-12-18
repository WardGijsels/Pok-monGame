using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Pokémon
    {
        // Attributen
        private string _naam;
        private string _type;
        private int _hp;
        private string _sprite;

        // Properties
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

        public int Hp
        {
            get 
            {
                if (_hp <= 0)
                {
                    return _hp = 0;
                }
                else
                {
                    return _hp;
                }
            }
            set { _hp = value; }
        }

        public string Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        // Constructor
        public Pokémon(string naam, string type, int hp, string sprite)
        {
            this.Naam = naam;
            this.Type = type;
            this.Hp = hp;
            this.Sprite = sprite;
        }

        // Methodes
        public void Tackle(Pokémon pokemon)
        {
            pokemon.Hp -= 1;
        }

        public override string ToString()
        {
            return $"{this.Naam} - {this.Type} - {this.Hp} HP";
        }
    }
}
