using System;

namespace Spaceman
{

    class Game{
        //Atributos ------------------------------------------

        private string codeWord;
        private string currentWord;
        private int totalTries;
        private int actualTries;
        private string[] codeWords = {"space", "galaxy", "chinatown", "hola", "oye", "chiniwini"};
        private Ufo ovni = new Ufo(); 

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

        public bool DidWin(){
            if(this.CurrentWord.Equals(this.CodeWord)){
                return true;
            }else{
                return false;
            }
        }

        public bool DidLose(){
            if(this.ActualTries > this.TotalTries){
                return true;
            }else{
                return false;
            }
        }

        public void Display(){
            this.Ovni.Stringify();
            Console.WriteLine(this.CurrentWord);
            Console.WriteLine($"Number of fails remaining: {this.TotalTries-this.ActualTries}");
        }

        public void Ask(){
            Console.WriteLine("Try to guess a letter");
            string strGuess = Console.ReadLine();
            int check = strGuess.Length;
            strGuess = strGuess.ToLower();
            if(check != 1){
                Console.WriteLine("Please, input a letter at a time");
            }else{
                char guess = char.Parse(strGuess);
                if(this.CodeWord.Contains(guess)){
                    Console.WriteLine("That letter appears in the secret word!");
                    char[] currentWordChar = this.CurrentWord.ToCharArray();
                    char[] codeWordChar= this.CodeWord.ToCharArray();
                    for(int i = 0; i < currentWordChar.Length; i++){
                        if(codeWordChar[i].Equals(guess)){
                            currentWordChar[i] = guess;
                        }
                    }
                    string newCurrentWord = String.Join("",currentWordChar);
                    this.CurrentWord = newCurrentWord;
                    Console.WriteLine(this.CurrentWord);
                }else{
                    this.ActualTries++;
                    ovni.AddPart();
                    Console.WriteLine("That letter isn't in the word.");
                }
            }
        }
    }

}