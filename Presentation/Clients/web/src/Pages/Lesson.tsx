import { useLocation, useNavigate, useParams } from 'react-router-dom'
import './../App.css'
import { Button } from 'antd';
import { useDispatch } from 'react-redux';
import { removeLesson } from '../store/reducers/lessonSlice';

export const Lesson = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const location = useLocation();
    const { id } = useParams();
    const { title, description } = location.state;

    const handleButtonClick = () => {
      id && dispatch(removeLesson(id));
      navigate(-1);
    }

  return (
    <>
      <h2>название урока - {title}</h2>
      <h2>Описание урока - {description}</h2>
      <h2>id № - {id}</h2>
      <Button onClick={handleButtonClick} type='primary' size='large'>удалить урок</Button>
    </>
  )
}
