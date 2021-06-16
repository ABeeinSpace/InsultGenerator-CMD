using System;
using System.Collections;

namespace RandomInsultGeneratorProj
{
    static class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            string userInputString = "";
            ArrayList generatedInsults = new ArrayList();
            
            do {
                // PRINTING MENU
                Console.WriteLine("SHAKESPEAREAN INSULT GENERATOR-INATOR\n");
                Console.WriteLine("   1. Generate an Insult");
                Console.WriteLine("   2. Display Previously Generated Insults");
                Console.WriteLine("   3. Exit");
                Console.WriteLine();
                Console.Write("Please choose an option: ");

                // READING USER INPUT
                userInputString = Console.ReadLine();
                Console.WriteLine();
                // VALIDATING USER INPUT
                bool isUserInputValid = IsDigitsOnly(userInputString);
                //Try - catch to prevent a crash if the user passes a carriage return
                try
                {
                    // This line can throw a FormatException if the user presses Enter at the "Please choose an option: " prompt.
                    var userInput = int.Parse(userInputString);

                    // Actually doing what the user asked us to
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("   Your insult is: {0}\n", InsultGeneratorInator(rng, generatedInsults));
                            Console.Write("Press any key to continue...  ");
                            Console.ReadKey();
                            Console.WriteLine();
                            break;
                        case 2:
                            DisplayGeneratedInsults(generatedInsults);
                            break;
                        case 3:
                            break;
                    }
                }
                // Handling a FormatException
                catch (FormatException)
                {
                    Console.Error.WriteLine("   Invalid input entered! (ONLY enter the number 1, 2, or 3). Please try again\n");
                }
                // Handling any other exceptions that may occur. I do not know how there could be another exception, this program is pretty simple. Either way, it gets handled. 
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: An unknown error has occured. Unforunately, we cannot continue from this error and the program must exit. \nStack trace as follows: ");
                    Console.WriteLine(ex.StackTrace);
                    // I exit here for safety's sake. Because of the simplicity of this program, if this exception block gets executed something must have gone catastrophically wrong somewhere. If things have gone sideways to that degree, the safest option to preserve sanity is to bail.
                    Environment.Exit(1);
                }

            } while (userInputString.Equals("3") == false);
            // Printing a nice message before we exit
            Console.WriteLine("   Have an excellent rest of your day!");

        }

        // IsDigitsOnly()
        // Parameters: string str
        // Returns: Boolean
        // Description: Iterates through ever character of a string. If one character is not 0 - 9, the method immediately returns false. If the method reaches the end of the string, it must be a valid number, so true is returned

        // Note: This method is technically not required anymore, since the try/catch block on line 29 could technically do what this method is designed to do all by itself. However, I'm the programmer and this is a personal project to get more comfortable with C#, so cry more.
        private static bool IsDigitsOnly(string str) {
            foreach (char c in str)
            {
                if (c < '0' || c > '3')
                    return false;
            }

            return true;
        }

        // DisplayGeneratedInsult()
        // Parameters: ArrayList generatedInsult
        // Returns: N/A (void)
        // Description: First checks if there are any insults in the generatedInsults list. If there are none, this method prints an error and returns. If there are insults, they get printed.
        private static void DisplayGeneratedInsults(ArrayList generatedInsults) {
            Console.WriteLine("DISPLAYING GENERATED INSULTS\n");
            if (generatedInsults.Count == 0) {
                Console.Error.WriteLine(" ERROR: There are no insults to be displayed! (Did you use option 1 to generate an insult?)");
                Console.WriteLine();
            } else {
                foreach (var item in generatedInsults)
                {
                    Console.WriteLine("   {0}\n", item);
                }

                Console.Write("   Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine(); 
            }
        }

        // InsultGeneratorInator()
        // Parameters: Random rng, ArrayList generatedInsult
        // Returns: string insult
        // Description: Generates an insult from three ArrayLists of possible values, saves it to the generatedInsults ArrayList so we can reference it later, and then returns the generated insult so that we can print it to the user.
        private static string InsultGeneratorInator(Random rng, ArrayList generatedInsults) {
            string[] firstHalfOfInsultArray = new string[] {"warped", "rougish", "fobbing", "babbling"};
            string[] middleOfInsultArray = new string[] {"swag-bellied", "sheep-biting", "puke-stockinged", "hag-born"};
            string[] finalBitOfInsultArray = new string[] {"ruinous-butt!", "tyrant!", "misbegotten-divel!", "coward!"};

            string beginningOfInsult = (string)firstHalfOfInsultArray.GetValue(rng.Next(4));
            string middleOfInsult = (string)middleOfInsultArray.GetValue(rng.Next(4));
            string endOfInsult = (string)finalBitOfInsultArray.GetValue(rng.Next(4));

            var insult = $"Thou {beginningOfInsult} {middleOfInsult} {endOfInsult}";

            generatedInsults.Add(insult);   
            return insult;

        }
    }
}
