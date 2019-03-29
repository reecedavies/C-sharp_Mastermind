using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {

            bool winGame = false;   // Terminating condition
            int n;                  // n = Number of positions to guess
            int m;                  // m = Number of colours to choose from
            int[] computerArray;    // Array to store mastermind code
            int[] userArray;        // Array to store user guesses
            int blackPiece;         // Used to show number of digits correct number & correct placement
            int whitePiece;         // Used to show number of digits correct number but wrong placement
            Random randomNumber = new Random(); // To randomly generate numbers
            int numAttempts = 12;   // Used to dictate number of attempts that user is given
            bool isPlaying = true;  // Boolean for when they are asked to play again
            int playAgain;          // Terminating condition of whole game

            string[] historyArray; ;// Array that stores string values of all previous attempts
            string historyValues;   // String dedicated to transferring values of each attempt to historyArray

            // Introduction
            Console.WriteLine("********** Welcome to Mastermind! **********");
            Console.WriteLine();

            // Asking for user input

            while (isPlaying == true)
            {

                // User inputs n (number of positions to guess)
                Console.Write("Please input number of positions required to guess:      ");
                n = Convert.ToInt32(Console.ReadLine());

                // User inputs m (number of colours to choose from)
                Console.Write("Please input number of available digits to choose from:  ");
                m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // Declaring the arrays with n length
                computerArray = new int[n];
                userArray = new int[n];

                // Sets history array to number of attempts
                historyArray = new string[12];


                // Loop that creates the random numbers for the user to guess
                for (int i = 0; i < n; i++)
                {
                    computerArray[i] = randomNumber.Next(1, m + 1);
                }

                // Print info that allows the user to understand more about the game
                Console.WriteLine("A {0}-digit code has been chosen. It may contains numbers ranging from 1-{1}.", n, m);
 
                for (int u = 0; u < n; u++)
                {
                    // Console.Write(computerArray[u] + " ");  <-Shows exact numbers chosen
                    Console.Write("X ");
                }

                Console.WriteLine();
                Console.WriteLine();


                // Loop to play the game. Breaks if they get all the digits correct in their guess
                for (int z = 1; z <= numAttempts; z++)
                {

                    // Resets history values (back) to nothing
                    historyValues = " ";

                    // Sets the black and white pieces (back) to 0
                    blackPiece = 0;
                    whitePiece = 0;

                    Console.WriteLine("Please input your guess.");


                    // Loop that reads user input and compares values
                    for (int x = 0; x < n; x++)
                    {
                        // Read user input
                        Console.Write("Input {0}:   ", x + 1);
                        userArray[x] = Convert.ToInt32(Console.ReadLine());

                        // If the number is correct AND in correct position
                        if (userArray[x] == computerArray[x])
                        {
                            // Increment black piece
                            blackPiece++;
                        }
                        else // If not, a loop checks if it is the right number in the wrong position
                        {
                            for (int a = 0; a < n; a++)
                            {
                                if (userArray[x] == computerArray[a])
                                {
                                    // Increment white piece
                                    whitePiece++;
                                }
                            }
                        }
                    }

                    Console.WriteLine();
                    Console.Write("Your guess: ");

                    // Loop dedicated to user's guesses
                    for (int b = 0; b < n; b++)
                    {
                        
                        // Prints user's guess
                        Console.Write(userArray[b] + " ");

                        // Adds users nth guess to the historyValues string variable
                        historyValues = historyValues + userArray[b] + " ";
                    }
                    Console.WriteLine();

                    // Sets specific array address with one complete guess
                    historyArray[z - 1] = historyValues;

                    // States statistics of game
                    Console.WriteLine("Black pieces: {0}", blackPiece);
                    Console.WriteLine("White pieces: {0}", whitePiece);
                    Console.WriteLine("Number of guesses remaining: {0}", numAttempts - z);
                    Console.WriteLine("___________________________________");
                    Console.WriteLine();

                    // Break if all pieces are in correct position
                    if (blackPiece == n)
                    {
                        // Changes bool to determine what to print
                        winGame = true;
                        break;
                    }


                }


                // Print x, dependant on whether wingame is true or false
                if (winGame == true)
                {
                    Console.WriteLine("************* YOU WIN *************");
                }
                else if (winGame == false)
                {
                    Console.WriteLine("************* YOU LOSE *************");
                }
                Console.WriteLine();


                Console.Write("The correct code was: ");

                // Print what the correct code was
                for (int q = 0; q < n; q++)
                {
                    Console.Write(computerArray[q] + " ");
                }


                

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Your guesses were:");
                
                // Loop that prints all user's guesses
                for (int v = 0; v < 12; v++)
                {

                    if (historyArray[v] != null)
                    {
                        Console.Write("Guess {0}:   ", (v + 1));
                        Console.WriteLine(historyArray[v]);
                    }

                }


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                // Asking the user if they want to play again
                Console.WriteLine("Do you want to play again? (YES = 1, NO = 0)");
                playAgain = Convert.ToInt32(Console.ReadLine());

                // If playAgain is 1, the while loop continues
                // But if playAgain is 0, the while loop stops
                if (playAgain == 0)
                {
                    isPlaying = false;
                }

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }
    }
}
