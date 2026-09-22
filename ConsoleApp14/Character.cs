using System.Xml.XPath;

namespace ConsoleApp14
{
    internal class Character
    {
        public Character(string name, float currentHealth, float startFullHealth, float startDamage)
        {
            Name = name;
            CurrentHealth = currentHealth;
            StartFullHealth = startFullHealth;
            StartDamage = startDamage;
            UpgradedFullHealth = startFullHealth;
            UpgradedDamage = startDamage;
        }
        public string Name { get; set; }

        public float CurrentHealth { get; set; }

        public float UpgradedFullHealth { get; set; }

        public float StartFullHealth { get; set; }

        public int XP { get; set; }

        public float StartDamage { get; set; }

        public float UpgradedDamage { get; set; }

        public int Lvl { get; set; }

        public float Currency { get; set; }

        public bool IsAlive { get; set; } = true;
    }
}
