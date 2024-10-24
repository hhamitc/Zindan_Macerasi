namespace Zindan_Macerasi
{
    public class ThunderStrikeSkill : Skill
    {
        public ThunderStrikeSkill() : base("Yıldırım Çarpması", 15)
        {
        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 5 + new Random().Next(1, 10);
        }
    }
}
