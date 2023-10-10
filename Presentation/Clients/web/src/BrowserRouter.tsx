import { createBrowserRouter } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./Pages/Home";
import { ListLessons } from "./Pages/ListLessons";
import { Lesson } from "./Pages/Lesson";

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
        path: 'listLessons',
        element: <ListLessons />,
      },
      {
        path: 'listLessons/:id',
        element: <Lesson />,
      },
    ]
  }
]);
