export default function TaskForm({ addTask }) {
    const handleSubmit = (event) => {
        event.preventDefault();
        const taskInput = document.getElementById('taskInput');
        const taskName = taskInput.value;
        addTask(taskName);
        taskInput.value = "";
      };
    return (
    <form onSubmit={handleSubmit}>
          <input type="text"  id='taskInput' placeholder='Ingrese una tarea'/>
          <button type='submit'>Agregar</button>
      </form>
    )
}