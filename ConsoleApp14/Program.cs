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
                            bool isMaxHealthParseSuccess = float.TryParse(Console.ReadLine(), out float maxHealth);

                            if (isMaxHealthParseSuccess)
                            {
                                Console.WriteLine("Please input current health");
                                bool isParseCurrentHealthSuccess = float.TryParse(Console.ReadLine(), out float currentHealth);

                                if (isParseCurrentHealthSuccess && maxHealth >= currentHealth)
                                {
                                    Console.WriteLine("Please input damage");
                                    bool isParseDamageSuccess = float.TryParse(Console.ReadLine(), out float damage);

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
                else if (userInput == 2)
                {
                    if (characters.Count > 1)
                    {
                        Console.WriteLine("Input name of character which will do damage");
                        string nameOfDamager = Console.ReadLine();
                        var findedDamager = GetCharacterByName(nameOfDamager, characters);

                        if (findedDamager != null && findedDamager.IsAlive == true)
                        {
                            Console.WriteLine("Enter name of character which will be damaged");
                            string nameOfDamagedCharacter = Console.ReadLine();
                            var findedDamagedCharacter = GetCharacterByName(nameOfDamagedCharacter, characters);

                            if ( findedDamagedCharacter != null && findedDamagedCharacter.IsAlive == true)
                            {
                                if (findedDamagedCharacter.CurrentHealth > findedDamager.Damage)
                                {
                                    findedDamagedCharacter.CurrentHealth -= findedDamager.Damage;
                                    findedDamager.XP += (int)findedDamager.Damage;
                                    Console.WriteLine("Success");
                                }
                                else if (findedDamagedCharacter.CurrentHealth <= findedDamager.Damage)
                                {
                                    findedDamagedCharacter.CurrentHealth = 0;
                                    findedDamagedCharacter.IsAlive = false;
                                    findedDamager.XP += (int)findedDamagedCharacter.CurrentHealth;

                                    Console.WriteLine($"\"{findedDamagedCharacter.Name}\" has died after getting damaged");
                                }
                            }
                            else if (findedDamagedCharacter == null)
                            {
                                Console.WriteLine($"\"{nameOfDamagedCharacter}\" is not exists");
                            }
                            else if (findedDamagedCharacter.IsAlive == false)
                            {
                                Console.WriteLine($"\"{nameOfDamagedCharacter}\" is dead so they cant get damage");
                            }
                        }
                        else if (findedDamager == null)
                        {
                            Console.WriteLine($"\"{nameOfDamager}\" is not exists");
                        }
                        else if (findedDamager.IsAlive == false)
                        {
                            Console.WriteLine($"\"{nameOfDamager}\" is dead so they cant do damage");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Atleast 2 characters needed");
                    }
                }
                else if (userInput == 3)
                {
                    if (characters.Count > 0)
                    {
                        foreach (Character character in characters)
                        {
                            if (character.XP >= 100)
                            {
                                character.Lvl = character.XP / 100;
                            }
                        }

                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("There is no characters yet");
                    }
                }
            }
        }

        static void PrintInfo()
        {
            Console.WriteLine("Enter 1 to add new character");
            Console.WriteLine("Enter 2 to damage someone");
            Console.WriteLine("Enter 3 to update lvls of characters");
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
