import { useAppSelector } from "../hooks/redux";
import { LessonItem } from "./LessonItem";

export const LessonList = () => {
    const lessons = useAppSelector(state => state.lessons.lessons);

    return (
        !lessons.length ? <h2>Здесь пока ничего нет!</h2> 
        : <ul>
            {
                lessons.map(lesson => (
                    <LessonItem 
                        key={lesson.id}
                        {...lesson}
                    />
                ))
            }
        </ul>
    )
}
