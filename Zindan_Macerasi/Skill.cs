namespace Zindan_Macerasi
{
    public abstract class Skill
    {
        public string Name { get; }
        public int MPCost { get; }

        protected Skill(string name, int mpCost)
        {
            Name = name;
            MPCost = mpCost;
        }

        public abstract int Use(Character user, ICharacter target);
    }
}
