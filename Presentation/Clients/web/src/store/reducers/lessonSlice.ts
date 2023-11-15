import { PayloadAction, createSlice } from '@reduxjs/toolkit';
import { ActionPayloadAddLesson, LessonState } from '../../models/ILesson';

const initialState: LessonState = {
    lessons: [],
    isLoading: false,
    error: ''
}

const lessonSlice = createSlice({
    name: 'lessons',
    initialState,
    reducers: {
        addLesson(state, action: PayloadAction<ActionPayloadAddLesson>) {
            state.lessons.push({
                id: new Date().toISOString(),
                title: action.payload.title,
                description: action.payload.description,
            })
        },
        removeLesson(state, action: PayloadAction<string>) {
            state.lessons = state.lessons.filter(item => item.id !== action.payload)
        },
    },
});

export const { addLesson, removeLesson } = lessonSlice.actions; 

export default lessonSlice.reducer;