namespace Zindan_Macerasi
{
    public class DragonLord : Enemy
    {
        public DragonLord(string name) : base(name, 500, 200, 10, 500, 200)
        {
            Skills.Add(new DragonBreathSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLineColored($"{Name} korkunç ejderha nefesini püskürtüyüyor!", ConsoleColor.DarkRed);
            Skills[0].Use(this, target);
        }
    }
}
