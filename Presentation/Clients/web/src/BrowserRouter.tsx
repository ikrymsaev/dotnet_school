import { Route, createBrowserRouter, createRoutesFromElements } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./Pages/Home";
import { ListLessons } from "./Pages/ListLessons";
import { Lesson } from "./Pages/Lesson";


export const router = createBrowserRouter(createRoutesFromElements(
    <Route path='/' element={<Layout />}>
      <Route index element={<Home />} />
      <Route path='listLessons' element={<ListLessons />}/>
      <Route path='listLessons/:id' element={<Lesson />}/>
    </Route>
))
