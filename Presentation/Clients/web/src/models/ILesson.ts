interface ILesson {
    id: string;
    title: string;
    description: string;
}

export interface ActionPayloadAddLesson {
    title: string;
    description: string;
}

export interface LessonState {
    lessons: ILesson[];
    isLoading: boolean;
    error: string;
}