import { Link } from 'react-router-dom'
import './../App.css'

export const Lessons = () =>  {

    const mockData = [{name: 'урок №1', id: 1}, {name: 'урок №2', id: 2}, {name: 'урок №3', id: 3}, {name: 'урок №4', id: 4}, {name: 'урок №5', id: 5}]

return (
        <div>   
            <h1>Список уроков</h1>
            <ul>
                {mockData.map((lesson) => <li><Link key={lesson.id} to={`/lesson/${lesson.id}`}>{lesson.name}</Link></li>)}
            </ul>
        </div>
    )
}