import { getTasks, createTask, updateTask, deleteTask } from '../Services/ToDoApi';
import { useState, useEffect } from 'react';

export const useTasks = () => {

const [tasks, setTasks] = useState([]);
const [loading, setLoading] = useState(true);
const [error, setError] = useState(null);

const loadTasks = async () => {
    getTasks()
      .then((res) => {
        setTasks(res);
      })
      .catch((err) => {
        setError(err);
      })
      .finally(() => {
        setLoading(false);
      });
}

useEffect(() => {
  loadTasks();
}, []);

const addTask = async (taskName) =>{
  if (!taskName.trim()) {
    alert("No se puede agregar una tarea vacía");
    return;
  }

  createTask({ name: taskName})
    .then(() => {
      loadTasks();
    })
    .catch((err) => {
      setError(err);
    });
}
 
  const handleUpdate = async (id) => {
    const task = tasks.find(t => t.id === id);
    if (!task) {
      alert("No se puede actualizar una tarea que no existe");
      return;
    }
    updateTask(id, { isCompleted: !task.isCompleted })
      .then(() => {
        loadTasks();
      })
      .catch((err) => {
        setError(err);
      });
  }


  const handleDelete = async (id) => {
    if (!tasks.some(t => t.id === id)) {
      alert("No se puede eliminar una tarea que no existe");
      return;
    }
    deleteTask(id)
      .then(() => {
        loadTasks();
      })
      .catch((err) => {
        setError(err);
      });
  }
  return {tasks,  handleUpdate, addTask, handleDelete, loading, error};
}
