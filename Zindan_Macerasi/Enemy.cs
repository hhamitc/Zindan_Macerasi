namespace Zindan_Macerasi
{
    public abstract class Enemy : Character
    {
        protected Enemy(string name, int maxHp, int maxMp, int level, int hp, int mp) : base(name, maxHp, maxMp, level, hp, mp)
        {

        }

        public abstract void SpecialMove(Character target);



    }
}
