using System;
using System.ComponentModel;

Console.Title = "Pokémon: consoleapp editie";
TitleMenu();

// Lijst van Pokémon maken
List<Pokémon> lijst = new List<Pokémon>();
lijst = FileOperations.LeesPokémon();
// Lijst van Pokémon drukken
Console.WriteLine(Environment.NewLine + "Kies een pokémon!" + Environment.NewLine);
for (int i = 0; i < lijst.Count; i++)
{
    Console.WriteLine($"{i}. {lijst[i]}");
}

// Kies een pokémon
Console.WriteLine();
int index = LeesGetalMinMax($"Kies een Pokémon (van 0 tot {lijst.Count - 1}): ", 0, lijst.Count - 1);

// Zoek de geselecteerde pokémon in de lijst
Pokémon selectedPokemon = lijst[index];
Console.WriteLine($"Je hebt {selectedPokemon.Naam} gekozen!");

AsciiArtDrukken(selectedPokemon);

// Lijst van Trainers maken
List<Trainer> trainerLijst = new List<Trainer>();
trainerLijst = FileOperations.LeesTrainers();
// Lijst van Trainers drukken
Console.WriteLine(Environment.NewLine + "Kies een Trainer om tegen te vechten!" + Environment.NewLine);
for (int i = 0; i < trainerLijst.Count; i++)
{
    Console.WriteLine($"{i}. {trainerLijst[i]}");
}

// Kies een Trainer
Console.WriteLine();
int indexTrainer = LeesGetalMinMax($"Kies een Pokémon (van 0 tot {trainerLijst.Count - 1}): ", 0, trainerLijst.Count - 1);

// Zoek de geselecteerde pokémon in de lijst
Trainer selectedTrainer = trainerLijst[indexTrainer];
Console.WriteLine($"Je hebt {selectedTrainer.Naam} gekozen!");

// Battle
Battle(selectedTrainer);






Console.ReadKey();
// Methodes
void TitleMenu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("                                  ,'\\\r\n    _.----.        ____         ,'  _\\   ___    ___     ____\r\n_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\r\n\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\r\n \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\r\n   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\r\n    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\r\n     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\r\n      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\r\n       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\r\n        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\r\n                                `'                            '-._|");
    Console.WriteLine();
    Console.WriteLine("Klik op een toets om te beginnen!");
    Console.ReadKey();
    Console.Beep();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
}

void AsciiArtDrukken(Pokémon geselecteerdePokémon)
{
    // Sprite drukken
    // \r en \n bruikbaar maken
    string sprite = geselecteerdePokémon.Sprite.Replace("\\r", "\r").Replace("\\n", "\n");
    Console.WriteLine($"Sprite:{Environment.NewLine}{sprite}{Environment.NewLine}");
}

void Battle(Trainer trainer)
{
    Console.WriteLine($"{trainer.Naam} wants to battle!\n{trainer.Naam} sends out {trainer.Pokémon}!");

    // Zoek de geselecteerde Pokémon van de trainer in de lijst
    string trainerPokemonNaam = trainer.Pokémon;

    // Zoek de Pokémon met dezelfde naam in de lijst
    Pokémon trainerPokemon = lijst.Find(pokemon => pokemon.Naam == trainerPokemonNaam);

    // Controleer of de Pokémon is gevonden
    if (trainerPokemon != null)
    {
        // verdere acties toe met de trainerPokemon
        AsciiArtDrukken(trainerPokemon);
        BattleKeuzes(trainerPokemon);
    }
    else
    {
        Console.WriteLine($"ERROR: Pokémon met de naam '{trainerPokemonNaam}' niet gevonden in de lijst.");
    }
}

void BattleKeuzes(Pokémon trainerPokémon)
{
    string[] menu = new string[] { "Fight", "Pokémon", "Item", "Run" };
    int battleoptie = KiesMenu(menu);
    while (!(battleoptie == 4))
    {
        switch (battleoptie)
        {
            case 1:
                // TODO : Meer moves toevoegen
                trainerPokémon.Tackle(trainerPokémon);
                Console.WriteLine($"{trainerPokémon.Naam} Heeft nu {trainerPokémon.Hp} HP");
                break;
            case 2:
                // TODO : Meerdere Pokémon voor de speler
                break;
            case 3:
                // TODO : Item menu
                break;
            case 4:
                Console.WriteLine("Je bent weg gelopen!");
                break;
        }
        battleoptie = KiesMenu(menu);
    }

}


// Hulp methodes
string LeesStringNietLeeg(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));
    return invoer;
}

string LeesStringMetOptie(string vraag, string[] opties)
{
    string invoer;
    do
    {
        invoer = LeesStringNietLeeg(vraag).ToUpper();
    } while (!opties.Contains(invoer));

    return invoer;
}

int LeesGetal(string vraag)
{
    string invoer;
    int getal;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (!int.TryParse(invoer, out getal));

    return getal;
}

int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal < min || getal > max);

    return getal;
}

int KiesMenu(string[] menu)
{
    // Printen
    for (int i = 1; i <= menu.Length; i++)
    {
        // - 1 omdat computer begint te tellen van 0
        Console.WriteLine($"{i}. {menu[i - 1]}");
    }

    // Inlezen van keuze (getal tussen 1 en lengte van mijn menu)
    int keuze = LeesGetalMinMax("Kies een optie: ", 1, menu.Length);

    return keuze;
}