using System.Collections.Generic;

namespace Day02 
{
    public class Game
    {
        private readonly int _id;

        private readonly IList<Pull> _pulls;

        public int Id => _id;

        public IList<Pull> Pulls => _pulls;

        public Game(int id)
        {
            _id = id;
            _pulls = new List<Pull>();
        }

        public void Pull(Pull pull)
        {
            _pulls.Add(pull);
        }

        public bool IsValid(Pull reference) 
        {
            return _pulls.All(p => 
                p.Red <= reference.Red &&
                p.Blue <= reference.Blue &&
                p.Green <= reference.Green
            );
        }

        public int GetPower()
        {
            var red = 1;
            var blue = 1;
            var green = 1;

            foreach (var pull in _pulls) 
            {
                red = int.Max(red, pull.Red);
                blue = int.Max(blue, pull.Blue);
                green = int.Max(green, pull.Green);
            }

            // return new Pull(red, blue, green);
            return red * green * blue;
        }
    }
}