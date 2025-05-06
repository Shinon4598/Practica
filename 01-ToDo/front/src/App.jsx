import { useEffect, useState } from 'react'
import './App.css'
import Task from './components/Task';
import { getTasks, createTask, updateTask, deleteTask } from './Api/ToDoApi';
function App() {
  
  return (
    <div className='ToDo'>
      <h1>To-Do list 📑</h1>
      <form onSubmit={handleSubmit}>
          <input type="text"  id='taskInput' placeholder='Ingrese una tarea'/>
          <button type='submit'>Agregar</button>
      </form>
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

export default App
