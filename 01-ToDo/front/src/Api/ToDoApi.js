const API_URL = "https://localhost:7294/api/todo";

export async function getTasks() {
  const response = await fetch(`${API_URL}`);
  if (!response.ok) {
    throw new Error("Error fetching tasks");
  }
  return response.json();
}

export async function getTaskById(id) {
  const response = await fetch(`${API_URL}/${id}`);
  if (!response.ok) {
    throw new Error("Error fetching task");
  }
  return response.json();
}
export async function createTask(task){
    const res = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            
        },
        body: JSON.stringify(task)
    })
    if (!res.ok) {
        throw new Error("Error creating task");
    }
}

export async function updateTask(id, task) {
    const res = await fetch(`${API_URL}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(task)
    })
    if (!res.ok) {
        throw new Error("Error updating task");
    }
}
export async function deleteTask(id) {
    const res = await fetch(`${API_URL}/${id}`, {
        method: "DELETE",
    })
    if (!res.ok) {
        throw new Error("Error deleting task");
    }
    return true;
}