using System;

namespace csharp_spaceman_starting
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Greet();
            do{
                game.Display();
                game.Ask();
            }while(!(game.DidWin()||game.DidLose()));
        }
    }
}
