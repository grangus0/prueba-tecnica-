using System;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenú Principal");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Listar Tareas");
                Console.WriteLine("3. Marcar Tarea como Completada");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTaskMenu(taskManager);
                        break;
                    case "2":
                        taskManager.ListTasks();
                        break;
                    case "3":
                        MarkTaskAsCompletedMenu(taskManager);
                        break;
                    case "4":
                        RemoveTaskMenu(taskManager);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        private static void AddTaskMenu(TaskManager taskManager)
        {
            Console.Write("Descripción de la tarea: ");
            string description = Console.ReadLine();

            Console.Write("Fecha límite (dd/MM/yyyy) o deje en blanco: ");
            string deadlineInput = Console.ReadLine();

            DateTime? deadline = null;
            if (!string.IsNullOrWhiteSpace(deadlineInput))
            {
                if (DateTime.TryParseExact(deadlineInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    deadline = parsedDate;
                }
                else
                {
                    Console.WriteLine("Formato de fecha inválido. No se establecerá una fecha límite.");
                }
            }

            taskManager.AddTask(description, deadline);
            Console.WriteLine("Tarea agregada.");
        }

        private static void MarkTaskAsCompletedMenu(TaskManager taskManager)
        {
            Console.Write("Índice de la tarea a marcar como completada: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                taskManager.MarkTaskAsCompleted(index - 1);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debe ser un número.");
            }
        }

        private static void RemoveTaskMenu(TaskManager taskManager)
        {
            Console.Write("Índice de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                taskManager.RemoveTask(index - 1);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debe ser un número.");
            }
        }
    }
}
