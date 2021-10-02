using System;

namespace csharp_spaceman_starting
{

    class Game{
        //Atributos -----------------------------------------------

        private string codeWord;
        private string currentWord;
        private int totalTries;
        private int actualTries;
        private string[] codeWords;
        private Ufo ovni;

        //Constructores -------------------------------------------

        public Game(){
            Random rand = new Random();
            this.CodeWords = new string[] {"space", "galaxy", "chinatown", "hola", "oye", "chiniwini"};
            this.Ovni = new Ufo();
            this.CodeWord = this.CodeWords[rand.Next(0,this.CodeWords.Length)];
            this.TotalTries = 5;
            this.ActualTries = 0;
            this.CurrentWord = "";
            for(int i = 0; i < CodeWord.Length ; i++){
                CurrentWord += "_";
            }
        }

        //Getters y setters --------------------------------------

        public string CodeWord {get; set;}
        public string CurrentWord {get; set;}
        public int TotalTries {get; set;}
        public int ActualTries {get; set;}
        public string[] CodeWords {get; set;}
        public Ufo Ovni {get; set;}

        //Metodos -------------------------------------------------

        //Da la bienvenida.
        public void Greet(){
            Console.WriteLine("Welcome, player");
        }

        //Devuelve true si ha ganado.
        public bool DidWin(){
            if(this.CurrentWord.Equals(this.CodeWord)){
                return true;
            }else{
                return false;
            }
        }

        //Devuelve true si ha perdido.
        public bool DidLose(){
            if(this.ActualTries > this.TotalTries){
                return true;
            }else{
                return false;
            }
        }

        //Escribe en pantalla información, el muñeco, el progreso en la palabra y el numero de intentos.
        public void Display(){
            this.Ovni.Stringify();
            Console.WriteLine(this.CurrentWord);
            Console.WriteLine($"Number of fails remaining: {this.TotalTries-this.ActualTries}");
        }

        //Lógica del juego
        public void Ask(){
            //Pide, recibe y procesa la respuesta del jugador
            Console.WriteLine("Try to guess a letter");
            string strGuess = Console.ReadLine();
            int check = strGuess.Length;
            strGuess = strGuess.ToLower();
            //Comprueba si es o no un solo caracter.
            if(check != 1){
                Console.WriteLine("Please, input a letter at a time");
            }else{
                //Si es un solo caracter lo guarda como tal y comprueba si existe en la palabra que tiene que adivinar.
                char guess = char.Parse(strGuess);
                if(this.CodeWord.Contains(guess)){
                    //Si existe en la palabra que tiene que adivinar, divide la palabra en un array de caracteres, busca donde va,
                    //substituye el guión por el caracter, lo vuelve a juntar en un string y actualiza el string el jugador.
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
                    //Si no existe le resta un intento, avanza el dibujo y le informa que ha fallado.
                    this.ActualTries++;
                    ovni.AddPart();
                    Console.WriteLine("That letter isn't in the word.");
                }
            }
        }
    }

}