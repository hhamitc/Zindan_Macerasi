namespace Zindan_Macerasi
{
    public class Wizard : Enemy
    {
        public Wizard(string name) : base(name, 50, 100, 5, 50, 100)
        {
            Skills.Add(new FireballSkill());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLineColored($"{Name} güçlü bir ateş topu fırlatıyor.", ConsoleColor.Magenta);
            Skills[0].Use(this, target);
        }
    }
}
