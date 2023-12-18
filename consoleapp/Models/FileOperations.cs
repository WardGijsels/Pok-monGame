using System;
using System.Globalization;

namespace consoleapp.Models
{
    public static class FileOperations
    {
        // Attr
        public static string BestandPokémon = "pokémonlijst.txt";


        public static List<Pokémon> LeesPokémon()
        {
            List<Pokémon> pokémonlijst = new List<Pokémon>();

            if (!File.Exists(BestandPokémon))
            {
                return pokémonlijst;
            }

            using (StreamReader reader = new StreamReader(BestandPokémon))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] data = record.Split('#');
                    string naam = data[0];
                    string type = data[1];
                    int hp = int.Parse(data[2]);
                    string sprite = data[3];

                    Pokémon pokémon = new Pokémon(naam, type, hp, sprite);
                    pokémonlijst.Add(pokémon);
                }
            }

            return pokémonlijst;
        }
    }
}
