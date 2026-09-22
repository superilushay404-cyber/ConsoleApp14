using System;
using static System.Net.Mime.MediaTypeNames;

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

                            if (isMaxHealthParseSuccess && maxHealth > 0)
                            {
                                Console.WriteLine("Please input current health");
                                bool isParseCurrentHealthSuccess = float.TryParse(Console.ReadLine(), out float currentHealth);

                                if (isParseCurrentHealthSuccess && maxHealth >= currentHealth && currentHealth > 0)
                                {
                                    Console.WriteLine("Please input damage");
                                    bool isParseDamageSuccess = float.TryParse(Console.ReadLine(), out float damage);

                                    if (isParseDamageSuccess && damage > 0)
                                    {
                                        Character character = new Character(nameOfCharacter, currentHealth, maxHealth, damage);
                                        characters.Add(character);

                                        Console.WriteLine("Success");
                                    }
                                    else if (!isParseDamageSuccess)
                                    {
                                        Console.WriteLine("Input is not a number");
                                    }
                                    else if (damage <= 0)
                                    {
                                        Console.WriteLine("Damage cant be 0 or lower");
                                    }
                                }
                                else if (!isParseCurrentHealthSuccess)
                                {
                                    Console.WriteLine("Input is not a number");
                                }
                                else if (currentHealth <= 0)
                                {
                                    Console.WriteLine("Current health cant be 0 or lower");
                                }
                                else if (maxHealth < currentHealth)
                                {
                                    Console.WriteLine("Max health cant be lower than current health");
                                }
                            }
                            else if (!isMaxHealthParseSuccess)
                            {
                                Console.WriteLine("Input is not a number");
                            }
                            else if (maxHealth <= 0)
                            {
                                Console.WriteLine("Max health cant be 0 or lower");
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
                                if (findedDamagedCharacter.CurrentHealth > findedDamager.UpgradedDamage)
                                {
                                    findedDamagedCharacter.CurrentHealth -= findedDamager.UpgradedDamage;
                                    findedDamager.XP += (int)findedDamager.UpgradedDamage;
                                    Console.WriteLine("Success");
                                }
                                else if (findedDamagedCharacter.CurrentHealth <= findedDamager.UpgradedDamage)
                                {
                                    findedDamager.XP += (int)findedDamagedCharacter.CurrentHealth;
                                    findedDamager.Currency += findedDamagedCharacter.CurrentHealth / 10;
                                    findedDamagedCharacter.CurrentHealth = 0;
                                    findedDamagedCharacter.IsAlive = false;

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

                                if (character.Lvl > 0)
                                {
                                    float percentOfInceareByLvl = character.Lvl + 100;
                                    character.UpgradedDamage = character.StartDamage * percentOfInceareByLvl / 100;
                                    character.UpgradedFullHealth = character.StartFullHealth * percentOfInceareByLvl / 100;
                                }
                            }
                        }

                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("There is no characters yet");
                    }
                }
                else if (userInput == 4)
                {
                    if (characters.Count > 0)
                    {
                        Console.WriteLine("Enter name of character to heal");
                        string healingCharacterName = Console.ReadLine();

                        Character findedHealingCharacter = GetCharacterByName(healingCharacterName, characters);

                        if (findedHealingCharacter != null && findedHealingCharacter.CurrentHealth != findedHealingCharacter.UpgradedFullHealth)
                        {
                            float amountOfHeal = findedHealingCharacter.UpgradedFullHealth / 10;
                            float totalHealthAfterHeal = findedHealingCharacter.CurrentHealth + amountOfHeal;

                            if (totalHealthAfterHeal > findedHealingCharacter.UpgradedFullHealth)
                            {
                                float differenceBetweenFullAndCurrentHealth = findedHealingCharacter.UpgradedFullHealth - findedHealingCharacter.CurrentHealth;
                                findedHealingCharacter.CurrentHealth = findedHealingCharacter.UpgradedFullHealth;
                                Console.WriteLine($"\"{findedHealingCharacter.Name}\" has fully healed (by {findedHealingCharacter.UpgradedFullHealth / findedHealingCharacter.CurrentHealth}% or {differenceBetweenFullAndCurrentHealth})");
                            }
                            else
                            {
                                Console.WriteLine($"\"{findedHealingCharacter.Name}\" has healed by 10% of max health ({amountOfHeal})");
                            }

                            if (findedHealingCharacter.IsAlive == false)
                            {
                                findedHealingCharacter.IsAlive = true;
                            }
                        }
                        else if (findedHealingCharacter == null)
                        {
                            Console.WriteLine($"\"{healingCharacterName}\" is not exists");
                        }
                        else if (findedHealingCharacter.CurrentHealth == findedHealingCharacter.UpgradedFullHealth)
                        {
                            Console.WriteLine($"\"{healingCharacterName}\" is already fully healed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no characters to heal");
                    }
                }
                else if (userInput == 5)
                {
                    if (characters.Count > 0)
                    {
                        Console.WriteLine("Enter name of character");
                        string nameOfCharacter = Console.ReadLine();

                        Character findedCharacter = GetCharacterByName(nameOfCharacter, characters);

                        if (findedCharacter != null)
                        {
                            Console.WriteLine($"Name: {findedCharacter.Name}");
                            Console.WriteLine($"Current health: {findedCharacter.CurrentHealth}");
                            Console.WriteLine($"Max health: {findedCharacter.UpgradedFullHealth}");
                            Console.WriteLine($"Damage: {findedCharacter.UpgradedDamage}");
                            Console.WriteLine($"Currency: {findedCharacter.Currency}");
                            Console.WriteLine($"Lvl: {findedCharacter.Lvl}");
                            Console.WriteLine($"Xp: {findedCharacter.XP}");
                            if (findedCharacter.IsAlive == true)
                            {
                                Console.WriteLine("Status: Alive");
                            }
                            else
                            {
                                Console.WriteLine("Status: Dead");
                            }
                        }
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
            Console.WriteLine("Enter 4 to heal or revive");
            Console.WriteLine("Enter 5 to see info about character");
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
