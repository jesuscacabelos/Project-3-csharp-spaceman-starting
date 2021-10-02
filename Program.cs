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
            if(game.DidLose()){
                Console.WriteLine("You lost, you couldn't save him.");
            }else{
                Console.WriteLine("You won! You saved him!");
            }
        }
    }
}
