import { useState } from 'react'
import './../App.css'
import { InputField } from '../components/InputField';
import { addLesson } from '../store/reducers/lessonSlice'
import { useAppDispatch } from '../hooks/redux';
import { useNavigate } from 'react-router-dom';

export const CreateLesson = () => {
const [title, setName] = useState('');
const [description, setDescription] = useState('');

const dispatch = useAppDispatch();
const navigate = useNavigate();
const goLessonList = () => navigate('/lessons');

const addTask = () => {
    dispatch(addLesson({title, description}));
    setName('');
    setDescription('');
    goLessonList();
}; 

  return (
    <div>
        <h1>Создать урок</h1>
        <InputField text={title} description={description} handleInput={setName} handleSubmit={addTask} handleSetDescription={setDescription}/>
    </div>
  )
}