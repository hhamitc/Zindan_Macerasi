namespace Zindan_Macerasi
{
    public class Hero : Character
    {
        public Hero(string name, int maxHp, int maxMp, int level, int hp, int mp) : base(name, maxHp, maxMp, level, hp, mp)
        {

        }
        public Hero(string name) : base(name, 100, 50, 1, 100, 50)
        {
            Skills.Add(new FireballSkill());
            Skills.Add(new HealingSkill());
        }
        public List<Item> Inventory { get; } = new List<Item>();

        public int Experience { get; private set; }

        public void AddItemToInventory(Item item)
        {
            Inventory.Add(item);
            ConsoleHelper.WriteLineColored($"[EŞYA] {Name} yeni bir {item.Name} buldu!", ConsoleColor.Green);
        }

        public void UseItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                item.Use(this);
                Inventory.Remove(item);
            }
            else
            {
                ConsoleHelper.WriteLineColored($"[HATA] Hay aksi! {Name} in envanterinde {item.Name} yok.", ConsoleColor.DarkRed);
            }
        }


        public void GainExperience(int exp)
        {
            Experience += exp;
            ConsoleHelper.WriteLineColored($"[DENEYİİM] {Name} {exp} deneyim puanı kazandı. Bilgelik akıyor sanki!", ConsoleColor.Green);
            if (Experience >= 100 * Level)
            {
                LevelUP();
            }
        }

        public void LevelUP()
        {
            Level++;

            if (Level == 5)
            {
                Skills.Add(new ThunderStrikeSkill());

            }

            MaxHP += 20;
            MaxMP += 10;

            HP = MaxMP;
            MP = MaxHP;

            Experience -= 100 * (Level - 1);

            ConsoleHelper.WriteLineColored($"[SEVİYE ATLADI] {Name} seviye atladı!", ConsoleColor.Magenta);
        }


    }
}
