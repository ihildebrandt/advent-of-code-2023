
using Day02;

// Setup
var maxPullReference = new Pull(12, 14, 13);

// Parse
string[]? parts = null;
var lines = Console.In.ReadToEnd().Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
var games = new Game[lines.Length];

for (var i = 0; i < lines.Length; i++) 
{
    parts = lines[i].Split(':');
    var info = parts[1];
    
    parts = parts[0].Split(' ');
    var game = new Game(int.Parse(parts[1]));

    var pulls = info.Split(';');
    foreach (var pull in pulls)
    {
        int red = 0;
        int blue = 0;
        int green = 0;

        var balls = pull.Split(',');
        foreach (var ball in balls) {
            parts = ball.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (parts[1]) 
            {
                case "red":
                    red = int.Parse(parts[0]);
                    break;
                case "blue":
                    blue = int.Parse(parts[0]);
                    break;
                case "green": 
                    green = int.Parse(parts[0]);
                    break;
            }
        }
    
        game.Pull(new Pull(red, blue, green));
    }

    

    games[i] = game;
}

// Process
var accumulator = 0;
foreach (var game in games) 
{
    /*

    if (!game.IsValid(maxPullReference)) 
    {
        Console.Write("!! ");
    } 
    else 
    {
        Console.Write("   ");
        accumulator += game.Id;
    }

    */
    Console.Write($"Game {game.Id}: ");
    foreach (var pull in game.Pulls) 
    {
        Console.Write($"{pull.Red} red, {pull.Blue} blue, {pull.Green} green; ");
    }
    Console.WriteLine();
    Console.WriteLine(game.GetPower());

    accumulator += game.GetPower();
}

Console.WriteLine(accumulator);
