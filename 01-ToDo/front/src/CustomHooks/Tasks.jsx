export const useTasks = () => {}

const [tasks, setTasks] = useState([]);

const loadTasks = () => {
    getTasks()
      .then((res) => {
        setTasks(res);
      })
      .catch((err) => {
        console.error(err);
      });
  }
  useEffect(() => {
    loadTasks();
  }, []);

  

  const addTask = async (event) =>{
    event.preventDefault();

    const taskInput = event.target.elements.taskInput;
    const value = taskInput.value.trim();

    if (value === "") {
      alert("No se puede agregar una tarea vacía");
      return;
    }

    createTask({ name: value })
      .then(() => {
        loadTasks();
        taskInput.value = "";
      })
      .catch((err) => {
        console.error(err);
      });
  }

  async function handleUpdate(id) {
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
        console.error(err);
      });
  }


  async function handleDelete(id) {
    const task = tasks.find(t => t.id === id);
    if (!task) {
      alert("No se puede eliminar una tarea que no existe");
      return;
    }
    deleteTask(id)
      .then(() => {
        loadTasks();
      })
      .catch((err) => {
        console.error(err);
      });

      return {tasks, handleUpdate, addTask, handleDelete, loadTasks };
  }

