namespace Zindan_Macerasi
{
    public class Goblin : Enemy

    {
        public Goblin(string name) : base(name, 30, 10, 1, 30, 10)
        {
            Skills.Add(new SneakAttackSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLineColored($"{Name} sinsi bir saldırı yapıyor", ConsoleColor.Green);
            Skills[0].Use(this, target);
        }
    }
}
