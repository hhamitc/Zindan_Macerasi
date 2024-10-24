namespace Zindan_Macerasi
{
    public class DragonBreathSkill : Skill
    {
        public DragonBreathSkill() : base("Ejderha Nefesi", 20)
        {

        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 6 + new Random().Next(10, 40);
        }
    }
}
