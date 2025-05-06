import Task from './Task';
import TaskForm from './TaskForm';
import { useTasks } from '../CustomHooks/useTasks';
export default function ToDo(){
  const { tasks, addTask, handleUpdate, handleDelete } = useTasks();

  return (
    <div className='ToDo'>
      <h1>To-Do list 📑</h1>
      <TaskForm addTask={addTask}></TaskForm>
      <ul className='tasks'>
        {
          tasks && tasks.map
          (t => 
          (<Task key={t.id} title={t.name} isCompleted={t.isCompleted} id={t.id} onUpdate={handleUpdate} onDelete={handleDelete}></Task> )
          )
        }
      </ul>
    </div>
  )
}