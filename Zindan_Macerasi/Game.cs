namespace Zindan_Macerasi
{
    public class Game
    {
        private Hero _hero;
        private List<Room> _rooms;
        private DragonLord _dragonLord;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _hero = new Hero("Cesur Maceracı");
            _rooms = new List<Room>
            {
                CreateBattleRoom("Karanlık KOridor",new Goblin("Sinsi Goblin")),
                new TreasureRoom("Eski Hazine Odası", new HealthPotion()),
                new RestRoom("Huzurlu Bahçe"),
                CreateBattleRoom("Ateş Çukuru", new Troll("Koca Troll")),
                new TreasureRoom("Gizli Kasa", new ManaPotion()),
                new RestRoom("Şifalı Pınar"),
                CreateBattleRoom("Büyücünün KUlesi", new Wizard("Kötü Büyücü"))
            };
            _dragonLord = new DragonLord("Kızıl Ejderha");
        }

        private BattleRoom CreateBattleRoom(string name, Enemy enemy)
        {
            var battleRoom = new BattleRoom(name, enemy);
            battleRoom.OnBattle += Battle;

            return battleRoom;
        }

        public void Start()
        {
            ConsoleHelper.WriteLineColored($"==== ZİNDAN MACERASINA HOŞ GELDİNİZ ====", ConsoleColor.Magenta);
            ConsoleHelper.WriteLineColored($"Siz {_hero.Name} zindandan çıkmaya çalışcan cesur bir kahramansınız.", ConsoleColor.Cyan);

            foreach (var room in _rooms)
            {
                if (_hero.HP <= 0)
                {
                    ConsoleHelper.WriteLineColored($"[OYUN BİTTİ] Maalesef yenildiniz. Belki bir sonraki sefere!", ConsoleColor.Red);
                    return;
                }

                room.Enter(_hero);
                DisplayHeroStatus();


            }

            if (_hero.HP > 0)
            {
                FinalBossBattle();
            }

        }

        private bool Battle(Hero hero, Enemy enemy)
        {
            while (hero.HP > 0 && enemy.HP > 0)
            {
                PerformTurn(hero, enemy);
                if (enemy.HP > 0)
                {
                    PerformTurn(enemy, hero);
                }
            }

            if (enemy.HP <= 0)
            {
                ConsoleHelper.WriteLineColored($"[ZAFER] {enemy.Name} i yendiniz. Büyük bir zafer kazandınız!", ConsoleColor.Green);
                hero.GainExperience(enemy.Level * 20);
                return true;
            }
            return false;
        }


        private void PerformTurn(ICharacter attacker, ICharacter defender)
        {
            ConsoleHelper.WriteLineColored($"\n[SIRA] {attacker.Name} ın Sırası: ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored($"HP {attacker.HP}/{attacker.MaxHP}, MP {attacker.MP}/{attacker.MaxMP} ", ConsoleColor.Cyan);

            if (attacker is Hero hero)
            {
                PerformHeroTurn(hero, defender);
            }
            else if (attacker is Enemy enemy)
            {
                PerformEnemy(enemy, defender);
            }
        }

        private void PerformHeroTurn(Hero hero, ICharacter enemy)
        {
            ConsoleHelper.WriteLineColored($"Ne yapmak istersinz?", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored($"1. Saldır.", ConsoleColor.White);
            ConsoleHelper.WriteLineColored($"2. Beceri kullan.", ConsoleColor.White);
            ConsoleHelper.WriteLineColored($"3. Eşya kullan.", ConsoleColor.White);

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    hero.Attack(enemy); break;
                case "2":
                    ChooseAndUseSkill(hero, enemy); break;
                case "3":
                    ChooseAndUseItem(hero); break;
                default:
                    ConsoleHelper.WriteLineColored($"[HATA] Geçersiz seçim yaptınız! Heyeacandan ne yapacağınızı şaşırdınız ve saldırdınız.", ConsoleColor.Red);
                    hero.Attack(enemy);
                    break;
            }
        }

        private void PerformEnemy(Enemy enemy, ICharacter hero)
        {
            enemy.SpecialMove(hero as Character);
        }

        private void ChooseAndUseSkill(Hero hero, ICharacter enemy)
        {
            ConsoleHelper.WriteLineColored("Hangi beceriyi kullanmak istersiniz?", ConsoleColor.Yellow);

            for (int i = 0; i < hero.Skills.Count; i++)
            {
                ConsoleHelper.WriteLineColored($"{i + 1}. {hero.Skills[i].Name} (MP Maliyeti: {hero.Skills[i].MPCost})", ConsoleColor.White);
            }

            if (int.TryParse(Console.ReadLine(), out int skillChoice) && skillChoice > 0 && skillChoice <= hero.Skills.Count)
            {
                hero.UseSkill(hero.Skills[skillChoice - 1], enemy);
            }
            else
            {
                ConsoleHelper.WriteLineColored($"[HATA] Geçersiz beceri seçimi. Varsayılan olarak saldırıyorsunuz.", ConsoleColor.DarkRed);
                hero.Attack(enemy);
            }
        }

        private void ChooseAndUseItem(Hero hero)
        {
            if (!hero.Inventory.Any())
            {
                ConsoleHelper.WriteLineColored("[HATA] Eyvah! Çantanız bomboş. Keşke biraz alışveriş yapsaydınız!", ConsoleColor.DarkRed);
                return;
            }

            ConsoleHelper.WriteLineColored("Hangi eşyayı kullanmak istersiniz?", ConsoleColor.Yellow);


            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                ConsoleHelper.WriteLineColored($"{i + 1}.{hero.Inventory[i].Name}", ConsoleColor.White);
            }

            if (int.TryParse(Console.ReadLine(), out int itemChoice) &&
                itemChoice > 0 && itemChoice <= hero.Inventory.Count)
            {
                Item chosenItem = hero.Inventory[itemChoice - 1];
                hero.UseItem(chosenItem);
            }
            else
            {
                ConsoleHelper.WriteLineColored("[HATA] Eşya seçerken hata yaptınız.", ConsoleColor.DarkRed);
            }


        }
        private void DisplayHeroStatus()
        {
            ConsoleHelper.WriteLineColored("\n---- Kahraman Durumu -----.", ConsoleColor.Cyan);
            ConsoleHelper.WriteLineColored($"Seviye: {_hero.Level}", ConsoleColor.White);
            ConsoleHelper.WriteLineColored($"HP: {_hero.HP}/{_hero.MaxHP}", ConsoleColor.Red);
            ConsoleHelper.WriteLineColored($"MP: {_hero.MP}/{_hero.MaxMP}", ConsoleColor.Blue);
            ConsoleHelper.WriteLineColored($"Deneyim: {_hero.Experience}", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored($"Envanter: {string.Join(",", _hero.Inventory.Select(i => i.Name))}", ConsoleColor.Green);

        }
        private void FinalBossBattle()
        {
            ConsoleHelper.WriteLineColored($"[SON BOSS] Son odaya ulaştınız. {_dragonLord.Name} size doğru geliyor.", ConsoleColor.Green);

            bool victorius = Battle(_hero, _dragonLord);

            if (victorius)
            {
                ConsoleHelper.WriteLineColored($"[ZAFER] Tebrikler! {_dragonLord.Name} yendiniz ve zindandan çıktınız. Siz gerçek bir kahramansınız!", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteLineColored($"[OYUN BİTTİ] {_dragonLord.Name} Yenildiniz.. Ama iyi bir mücadeleydi!", ConsoleColor.Red);

            }
        }

    }
}
