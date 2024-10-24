namespace Zindan_Macerasi
{
    public abstract class Room
    {
        public string Name { get; protected set; }
        public event Action<Hero> OnEnter;
        public event Action<Hero> OnEnxit;

        protected Room(string name)
        {
            Name = name;
        }

        public virtual void Enter(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[ODA] {hero.Name}, {Name} odasına giriyor.", ConsoleColor.Cyan);
            OnEnter?.Invoke(hero);
            PerformAction(hero);
            OnEnxit?.Invoke(hero);
        }

        protected abstract void PerformAction(Hero hero);



    }
}
