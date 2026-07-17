using static System.Net.Mime.MediaTypeNames;

int playerHP = 100;
int enemyHP = 80;
Random rand = new Random();
bool isTrue = true;

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
        Console.WriteLine("\n\n-- Ваш ход --\n1. Атака.\n2. Лечение.");
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
        turn = true;
    }
    if (playerHP <=0)
    {
        Console.WriteLine("\n\nВы проиграли!");
        break;
    }
    if (enemyHP <= 0)
    {
        Console.WriteLine("\n\nВы победили!");
        break;
    }
    
    Console.WriteLine($"\nХп игрока: {playerHP}. Хп соперника: {enemyHP}");
}


void enemyAttack()
{
    int damage = rand.Next(7, 30);
    playerHP -= damage;
    Console.WriteLine($"\nПротивник наносит {damage} урона!");
}
void playerAttack()
{
    int damage = rand.Next(10, 20);
    enemyHP -= damage;
    Console.WriteLine($"Вы нанесли {damage} урона противнику!");
}
void playerHeal()
{
    int heal = rand.Next(5, 25);
    playerHP += heal;
    Console.WriteLine($"Вы восстановили {heal} единиц здоровья!");
}
