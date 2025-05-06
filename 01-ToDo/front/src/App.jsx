import './App.css'
import { useTasks} from './CustomHooks/useTasks';
import ToDo from './components/ToDo';
function App() {

  const {loading, error} = useTasks();
  return (
    <>
      {loading && <h1>Loading...</h1>}
      {error && <h1>{error}</h1>}
      {!loading && !error && <ToDo />}
    </>
  )
}

export default App
