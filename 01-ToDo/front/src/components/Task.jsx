export default function Task({task, deleteTask}) {
    return (
        <li className='task'>
            <label>
                <input className='checkbox' type="checkbox" />
                <span className='checkboxText'></span>
            </label>
            <p>{task}</p>
            <button className='deleteButton' onClick={deleteTask}>✖️</button>
        </li>
    )
}