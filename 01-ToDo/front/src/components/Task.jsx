export default function Task({title, isCompleted, id, onDelete, onUpdate}) {

    return (
        <li className='task'>
            <label>
                <input className='checkbox' type="checkbox"  checked={isCompleted || false} onChange={()=>onUpdate(id)} />
                <span className='checkboxText'></span>
            </label>
            <p>{title}</p>
            <button className='deleteButton' onClick={()=>onDelete(id)}>✖️</button>
        </li>
    )
}