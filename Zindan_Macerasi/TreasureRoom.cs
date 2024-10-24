namespace Zindan_Macerasi
{
    public class TreasureRoom : Room
    {
        private Item _treasure;
        public TreasureRoom(string name, Item treasure) : base(name)
        {
            _treasure = treasure;
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[HAZİNE] Gözleriniz parladı {Name} de {_treasure.Name} adında bir hazine sandığı buldunuz!", ConsoleColor.Yellow);
            hero.AddItemToInventory(_treasure);

        }
    }
}
