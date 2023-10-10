import { RouterProvider } from 'react-router-dom'
import './App.css'
import { router } from './BrowserRouter'

const App = ()  => {

  return <RouterProvider router={router} />
  
}

export default App
