import { useParams } from 'react-router-dom'
import './../App.css'

export const Lesson = () => {
    const { id } = useParams();

  return (
    <div><h1>Lesson № {id}</h1></div>
  )
}
