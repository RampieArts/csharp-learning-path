using static System.Net.Mime.MediaTypeNames;

int playerHP = 150, maxPlayerHP = 150;
int playerMana = 50, maxPlayerMana = 50;
int enemyHP = 120;
Random rand = new Random();
bool isTrue = true;
bool isCrit = false;

bool turn = rand.Next(2) > 0;
string attackerName;



if (turn == true) attackerName = "Игрок";
else attackerName = "Соперник";

Console.WriteLine($"\nХп игрока: {playerHP}. Хп соперника: {enemyHP}.\nБой начался.\n\nПервым ходит: {attackerName}.\n");

while (isTrue)
{
    if (turn == true)
    {
        int action;
        
        Console.WriteLine("\n\n-- Ваш ход --\n1. Атака.\n2. Лечение.\n3. Огненный шар.");
        Console.Write("Выберите действие: ");
        if (int.TryParse(Console.ReadLine(), out action))
        {
            Console.WriteLine($"Вы ввели число: {action}");
        }
        else
        {
            Console.WriteLine("Введено неверное значение! Повторите попытку");
        }
        
        switch (action)
        {
            case 1:
                {
                    playerAttack();
                    turn = false;
                    break;
                }
            case 2:
                {
                    playerHeal();
                    turn = false;
                    break;
                }
            case 3:
                {
                    if (playerMana >= 20)
                    {
                        playerCastFireball();
                        turn = false;
                        
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно маны!");
                        break;
                    }
                    break;
                }
            default:
                {
                    Console.WriteLine("Нет такой команды!");
                    break;
                }

        }
        
    }
    else
    {
        enemyAttack();
        playerMana = Math.Min(playerMana + 5, maxPlayerMana);
        turn = true;
    }

    if (playerHP <= 0)
    {
        Console.WriteLine("\n\nВы проиграли!");
        break;
    }
    if (enemyHP <= 0)
    {
        Console.WriteLine("\n\nВы победили!");
        break;
    }

    Console.WriteLine($"\nХп игрока: {playerHP}. Остаток маны: {playerMana}\n Хп соперника: {enemyHP}");
}


void enemyAttack()
{
    isCrit = rand.Next(101) <= 20;
    int damage = rand.Next(7, 30);
    if (isCrit == true)
    {
        damage *= 2;
        Console.WriteLine("КРИТИЧЕСКИЙ УДАР!");
    }
    playerHP -= damage;
    Console.WriteLine($"\nПротивник наносит {damage} урона!");
}
void playerAttack()
{
    isCrit = rand.Next(101) <= 20;
    int damage = rand.Next(10, 20);
    if (isCrit == true)
    {
        damage *= 2;
        Console.WriteLine("КРИТИЧЕСКИЙ УДАР!");
    }
    enemyHP -= damage;
    Console.WriteLine($"Вы нанесли {damage} урона противнику!");
}
void playerHeal()
{
    int heal = rand.Next(5, 25);
    playerHP = Math.Min(playerHP + heal, maxPlayerHP);
    Console.WriteLine($"Вы восстановили {heal} единиц здоровья!");
}
void playerCastFireball()
{
    isCrit = rand.Next(101) <= 20;
    int damage = rand.Next(15, 30);
    playerMana -= 20;
    if (isCrit == true)
    {
        damage *= 2;
        Console.WriteLine("КРИТИЧЕСКИЙ УДАР!");
    }
    enemyHP -= damage;
    Console.WriteLine($"Вы нанесли {damage} урона противнику огненным шаром!");
}