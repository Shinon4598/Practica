import { useState } from 'react'
import './App.css'
import Task from './components/Task';

function App() {
  const [tasks, setTasks] = useState("");
  return (
    <div className='ToDo'>
      <h1>To-Do list 📑</h1>
      <form>
          <input type="text"  id='taskInput' placeholder='Ingrese una tarea'/>
          <button type='submit'>Agregar</button>
      </form>
      <ul className='tasks'>
        <Task task="Tarea 1" deleteTask={() => {}} />
        <Task task="Tarea 2" deleteTask={() => {}} />
      </ul>
    </div>
  )
}

export default App
