namespace Zindan_Macerasi
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; set; }
        int MaxHP { get; }
        int MP { get; set; }
        int MaxMP { get; }
        int Level { get; }

        void Attack(ICharacter target);
        void TakeDamage(int damage);
    }
}


