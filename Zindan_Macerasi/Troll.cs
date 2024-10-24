namespace Zindan_Macerasi
{
    public class Troll : Enemy
    {
        public Troll(string name) : base(name, 100, 20, 3, 100, 20)
        {
            Skills.Add(new SmashSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLineColored($"{Name} güçlü bir ezme saldırısı yapıyor.", ConsoleColor.Red);
            Skills[0].Use(this, target);
        }
    }
}
