namespace Zindan_Macerasi
{
    public class FireballSkill : Skill
    {
        public FireballSkill() : base("Ateş Topu", 5)
        {

        }
        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 3;
        }
    }
}
