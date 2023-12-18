using System;
using System.Globalization;

namespace consoleapp.Models
{
    public static class FileOperations
    {
        // Attr
        public static string BestandPokémon = "pokémonlijst.txt";
        public static string BestandTrainers = "trainers.txt";
        public static string BestandMoves = "moves.txt";

        // Pokémon inlezen
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

        // Trainers inlezen
        public static List<Trainer> LeesTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            if (!File.Exists(BestandTrainers))
            {
                return trainers;
            }

            using (StreamReader reader = new StreamReader(BestandTrainers))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] data = record.Split('#');
                    string naam = data[0];
                    string pokémon = data[1];

                    Trainer trainer = new Trainer(naam, pokémon);
                    trainers.Add(trainer);
                }
            }

            return trainers;
        }

        // Moves inlezen
        public static List<Moves> LeesMoves()
        {
            List<Moves> movesLijst = new List<Moves>();

            if (!File.Exists(BestandMoves))
            {
                return movesLijst;
            }

            using (StreamReader reader = new StreamReader(BestandMoves))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] data = record.Split('#');
                    string naam = data[0];
                    string type = data[1];
                    int power = int.Parse(data[2]);
                    int accuracy = int.Parse(data[3]);

                    Moves move = new Moves(naam, type, power, accuracy);
                    movesLijst.Add(move);
                }
            }

            return movesLijst;
        }
    }
}
