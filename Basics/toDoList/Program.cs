using System.IO;
namespace toDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            List<string> toDoList = new List<string>();

            if (File.Exists("tasks.txt"))
            {
                toDoList = File.ReadAllLines("tasks.txt").ToList();
            }

            while (isOpen)
            {
                menu();

            }

            void menu()
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("--- Меню ---\n\n1. Добавить задачу.\n2. Удалить задачу.\n3. Показать список задач.\n4. Выйти.\n");
                Console.Write("Введите команду: ");
                string choose = Console.ReadLine();
                
                Console.SetCursorPosition(0, 10);
                switch (choose)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Введите задачу:\n");
                            string task = Console.ReadLine();
                            addTask(task);
                            File.WriteAllLines("tasks.txt", toDoList);
                            break;
                        }
                    case "2":
                        {
                            bool isTrue = true;
                            Console.Clear();
                            if (toDoList.Count == 0)
                            {
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("Нечего удалять!");
                                isTrue = false;
                                Console.ReadLine();
                            }

                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("Список задач:");
                            for (int i = 0; i < toDoList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {toDoList[i]}");
                            }
                            Console.SetCursorPosition(0, 0);
                            while (isTrue)
                            {
                                Console.Write("Введите номер задачи, которую хотите удалить: ");
                                string answer = Console.ReadLine();
                                if (int.TryParse(answer, out int task))
                                {
                                    
                                    if (task <= 0 || task > toDoList.Count())
                                    {
                                        Console.WriteLine("Неверное значение!");
                                        
                                    }
                                    isTrue = false;
                                    removeTask(task - 1);
                                    File.WriteAllLines("tasks.txt", toDoList);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Неверное значение! Повторите ввод!");
                                    Console.SetCursorPosition(0, 5);
                                    Console.WriteLine("Список задач:");
                                    for (int i = 0; i < toDoList.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {toDoList[i]}");
                                    }
                                    Console.SetCursorPosition(0, 0);
                                }

                            }
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            for (int i = 0; i < toDoList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {toDoList[i]}");
                            }
                            Console.WriteLine("\n Нажмите любую клавишу, чтобы продолжить.");
                            Console.ReadLine();
                            break;
                        }
                    default:
                        {
                            isOpen = false;
                            break;
                        }
                }

            }

            void addTask(string task)
            {
                toDoList.Add(task);
            }
            void removeTask(int i)
            {
                toDoList.RemoveAt(i);
            }


        }


    }
}
