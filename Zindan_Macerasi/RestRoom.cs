namespace Zindan_Macerasi
{
    public class RestRoom : Room
    {
        public RestRoom(string name) : base(name)
        {
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[DİNLENME] {Name}, Huzurlu bir oda! Burada biraz kestirseniz iyi olacak.", ConsoleColor.Green);
            hero.HP = hero.MaxHP;
            hero.MP = hero.MaxMP;

            ConsoleHelper.WriteLineColored($"[İYİLEŞME] kısa bit şekerleme yaptınız. HP ve MP değerleriniz tamamen yenilendi.", ConsoleColor.Green);
        }
    }
}
