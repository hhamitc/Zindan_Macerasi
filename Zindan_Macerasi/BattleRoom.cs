namespace Zindan_Macerasi
{
    public class BattleRoom : Room
    {
        private Enemy _enemy;
        public event Func<Hero, Enemy, bool> OnBattle;
        public BattleRoom(string name, Enemy enemy) : base(name)
        {
            _enemy = enemy;
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLineColored($"[SAVAŞ] {Name} odasında gıcırdayan bir kapıyı açtınız ve... Eyvah bir {_enemy.Name} belirdi.", ConsoleColor.Red);

            bool battleResult = OnBattle?.Invoke(hero, _enemy) ?? false;

            if (battleResult)
            {
                ConsoleHelper.WriteLineColored($"[ZAFER] {_enemy.Name} i yendiniz. Büyük bir zafer!", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteLineColored($"[YENİLGİ] {_enemy.Name} karşısında yenildiniz.. ", ConsoleColor.Red);
            }

        }
    }
}
