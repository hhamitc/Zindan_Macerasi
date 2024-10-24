namespace Zindan_Macerasi
{
    public class HealthPotion : Item
    {
        public HealthPotion() : base("Can İksiri")
        {

        }

        public override void Use(Character character)
        {
            int healAmount = 30;
            character.HP = Math.Min(character.MaxHP, character.HP + healAmount);
            ConsoleHelper.WriteLineColored($"[İYİLEŞME] {character.Name} can iksirini kafasına dikti! Vücuduna sıcak bir his yayıldı ve {healAmount} HP yenilendi", ConsoleColor.Green);
        }
    }
}
