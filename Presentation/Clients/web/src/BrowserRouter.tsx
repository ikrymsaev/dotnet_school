import { createBrowserRouter } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./Pages/Home";
import { Lessons } from "./Pages/Lessons";
import { Lesson } from "./Pages/Lesson";
import { CreateLesson } from "./Pages/CreateLesson";

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,
    children: [
      {
        path: '',
        element: <Home />,
      },
      {
        path: 'lessons',
        element: <Lessons />,
      },
      {
        path: 'lesson/:id',
        element: <Lesson />,
      },
      {
        path: 'createlesson',
        element: <CreateLesson />,
      },
    ]
  }
]);
