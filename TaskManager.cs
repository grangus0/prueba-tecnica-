using System;
using System.Collections.Generic;

namespace ToDoApp
{
    /// <summary>
    /// Gestiona las tareas de la lista.
    /// </summary>
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        /// <summary>
        /// Agrega una nueva tarea a la lista.
        /// </summary>
        public void AddTask(string description, DateTime? deadline = null)
        {
            tasks.Add(new TaskItem(description, deadline));
        }

        /// <summary>
        /// Lista todas las tareas registradas.
        /// </summary>
        public void ListTasks()
        {
            Console.WriteLine("\nListado de Tareas:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        /// <summary>
        /// Marca una tarea como completada.
        /// </summary>
        public void MarkTaskAsCompleted(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].MarkAsCompleted();
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("Índice de tarea inválido.");
            }
        }

        /// <summary>
        /// Elimina una tarea de la lista.
        /// </summary>
        public void RemoveTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Índice de tarea inválido.");
            }
        }
    }
}
