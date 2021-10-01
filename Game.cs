using System;

namespace Spaceman
{

    class Game{
        //Atributos ------------------------------------------

        private string codeWord;
        private string currentWord;
        private int totalTries;
        private int actualTries;
        private string[] codeWords;
        private Ufo ovni; 

        //Constructores ---------------------------------------

        public Game(){
            Random Rand = new Random();
            this.CodeWord = CodeWords[Rand.Next(0,CodeWords.Length)];
            this.TotalTries = 5;
            this.ActualTries = 0;
            this.CurrentWord = "";
            for(int i = 0; i < CodeWord.Length ; i++){
                CurrentWord += "_";
            }
        }

        //Getters y setters ------------------------------------

        public string CodeWord {get; set;}
        public string CurrentWord {get; set;}
        public int TotalTries {get;}
        public int ActualTries {get; set;}
        public string[] CodeWords {get; set;}
        public Ufo Ovni {get; set;}

        //Metodos --------------------------------------------

        public void Greet(){
            Console.WriteLine("Welcome, player");
        }
    }

}