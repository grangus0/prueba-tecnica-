using System;

namespace ToDoApp
{
    /// <summary>
    /// Representa una tarea en la lista de tareas.
    /// </summary>
    public class TaskItem
    {
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsCompleted { get; private set; }

        public TaskItem(string description, DateTime? deadline = null)
        {
            Description = description;
            Deadline = deadline;
            IsCompleted = false;
        }

        /// <summary>
        /// Marca la tarea como completada.
        /// </summary>
        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        /// <summary>
        /// Devuelve una representación en cadena de la tarea.
        /// </summary>
        public override string ToString()
        {
            string status = IsCompleted ? "Completada" : "Pendiente";
            string deadlineInfo = Deadline.HasValue ? $" | Fecha límite: {Deadline.Value.ToShortDateString()}" : "";
            return $"{Description} | Estado: {status}{deadlineInfo}";
        }
    }
}
