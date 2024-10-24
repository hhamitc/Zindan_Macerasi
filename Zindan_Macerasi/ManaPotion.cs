namespace Zindan_Macerasi
{
    public class ManaPotion : Item
    {
        public ManaPotion() : base("Mana İksiri")
        {

        }

        public override void Use(Character character)
        {
            int manaAmount = 20;
            character.MP = Math.Min(character.MaxHP, character.MP + manaAmount);
            ConsoleHelper.WriteLineColored($"[MANA] {character.Name} Mana iksirini içti ve beyni elektriklenmiş gibi hisstti! {manaAmount} MP yenilendi", ConsoleColor.Blue);
        }
    }
}
