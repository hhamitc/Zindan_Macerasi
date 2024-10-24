namespace Zindan_Macerasi
{
    public class SneakAttackSkill : Skill
    {
        public SneakAttackSkill() : base("Sinsi Saldırı", 5)
        {
        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 2 + new Random().Next(1, 6);
        }
    }
}
