using System.Xml.XPath;

namespace ConsoleApp14
{
    internal class Character
    {
        public Character(string name, float currentHealth, int fullHealth, float damage)
        {
            Name = name;
            CurrentHealth = currentHealth;
            FullHealth = fullHealth;
            Damage = damage;
        }
        public string Name { get; set; }

        public float CurrentHealth { get; set; }

        public float FullHealth { get; set; }

        public int XP { get; set; }

        public float Damage { get; set; }

        public int Lvl { get; set; }

        public int Currency { get; set; }

        public bool IsAlive { get; set; } = true;
    }
}
