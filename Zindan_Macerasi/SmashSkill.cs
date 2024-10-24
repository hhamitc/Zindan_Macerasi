namespace Zindan_Macerasi
{
    public class SmashSkill : Skill
    {
        public SmashSkill() : base("Ezici Darbe", 8)
        {

        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 7;
        }
    }
}
