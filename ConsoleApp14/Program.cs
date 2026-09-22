namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();
            bool continueProgram = true;

            while (continueProgram)
            {
                PrintInfo();
                int.TryParse(Console.ReadLine(), out int userInput);

                if (userInput == 1)
                {
                    Console.WriteLine("Please enter name of character");
                    string nameOfCharacter = Console.ReadLine();
                    bool isThereDublicates = false;

                    if (!string.IsNullOrEmpty(nameOfCharacter))
                    {
                        if (characters.Count > 0)
                        {
                            foreach (Character character in characters)
                            {
                                if (character.Name == nameOfCharacter)
                                {
                                    Console.WriteLine("Unable to create 2 characters with same name");
                                    isThereDublicates = true;
                                }
                            }
                        }
                        if (!isThereDublicates)
                        {
                            Console.WriteLine("Please input max health");
                            bool isMaxHealthParseSuccess = int.TryParse(Console.ReadLine(), out int maxHealth);
                            
                            if (isMaxHealthParseSuccess)
                            {
                                Console.WriteLine("Please input current health");
                                bool isParseCurrentHealthSuccess = int.TryParse(Console.ReadLine(), out int currentHealth);

                                if (isParseCurrentHealthSuccess && maxHealth >= currentHealth)
                                {
                                    Console.WriteLine("Please input damage");
                                    bool isParseDamageSuccess = int.TryParse(Console.ReadLine(), out int damage);

                                    if (isParseDamageSuccess)
                                    {
                                        Character character = new Character(nameOfCharacter, currentHealth, maxHealth, damage);
                                        characters.Add(character);

                                        Console.WriteLine("Success");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input is not a number");
                                    }
                                }
                                else if (!isParseCurrentHealthSuccess)
                                {
                                    Console.WriteLine("Input is not a number");
                                }
                                else if (maxHealth < currentHealth)
                                {
                                    Console.WriteLine("Max health cant be lower than current health");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input is not a number");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty input");
                    }
                }
            }
        }

        static void PrintInfo()
        {
            Console.WriteLine("Enter 1 to add new character");
        }
        static Character GetCharacterByName(string nameOfCharacter, List<Character> characters)
        {
            Character findedCharacter = null;

            foreach (Character character in characters)
            {
                if (character.Name == nameOfCharacter)
                {
                    findedCharacter = character;
                }
            }

            return findedCharacter;
        }
    }
}
