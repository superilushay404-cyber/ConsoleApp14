using System.Xml.XPath;

namespace ConsoleApp14
{
    internal class Character
    {
        public Character(string name, float currentHealth,  int fullHealth, int xp, int lvl)
        {
            Name = name;
            CurrentHealth = currentHealth;
            FullHealth = fullHealth;
            XP = xp;
            Lvl = lvl;
        }
        public string Name { get; set; }

        public float CurrentHealth { get; set; }

        public int FullHealth { get; set; }

        public int XP { get; set; }

        public int Lvl { get; set; }
    }
}
