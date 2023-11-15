import { combineReducers, configureStore } from "@reduxjs/toolkit";
import lessonReducer from './reducers/lessonSlice';

const rootReducer = combineReducers({
    lessons: lessonReducer,
})

export const setupStore = () => {
    return configureStore({
        reducer: rootReducer
    });
}

export type RootState = ReturnType<typeof rootReducer>
export type AppStore = ReturnType<typeof setupStore>
export type AppDispatch = AppStore['dispatch']
