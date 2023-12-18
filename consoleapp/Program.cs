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

string keuze = LeesStringMetOptie($"Tegen wie wil je vechten?(Red of Blue) ", new string[] { "R", "B" });
if (keuze == "R")
{
    Pokémon redPokémon = lijst[5];
    Console.WriteLine("Red wants to battle!\nRed send out charizard");
    Console.ForegroundColor = ConsoleColor.Red;
    AsciiArtDrukken(redPokémon);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Wat wil je doen?");

    string[] menu = new string[] { "Tackle", "Niks","Run Away"};
    int battleoptie = KiesMenu(menu);

    while (!(battleoptie == 3))
    {
        switch (battleoptie)
        {
            case 1:
                Console.WriteLine($"{selectedPokemon.Naam} gebruikte tackle op {redPokémon.Naam}");
                redPokémon.Tackle(redPokémon);
                Console.WriteLine($"{redPokémon.Naam} heeft nu nog {redPokémon.Hp} HP");
                break;
            case 2:
                break;
        }

        battleoptie = KiesMenu(menu);
    }
}
else
{
    Pokémon bluePokémon = lijst[8];
    Console.WriteLine("Blue wants to battle!\nBlue send out Blastoise");
    Console.ForegroundColor = ConsoleColor.Blue;
    AsciiArtDrukken(bluePokémon);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Wat wil je doen?");

    string[] menu = new string[] { "Tackle", "Niks", "Run Away" };
    int battleoptie = KiesMenu(menu);

    while (!(battleoptie == 3))
    {
        switch (battleoptie)
        {
            case 1:
                Console.WriteLine($"{selectedPokemon.Naam} gebruikte tackle op {bluePokémon.Naam}");
                bluePokémon.Tackle(bluePokémon);
                Console.WriteLine($"{bluePokémon.Naam} heeft nu nog {bluePokémon.Hp} HP");
                break;
            case 2:
                break;
        }

        battleoptie = KiesMenu(menu);
    }
}

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