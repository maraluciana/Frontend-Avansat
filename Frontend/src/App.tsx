import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import ResponsiveAppBar from "./components/ResponsiveAppBar";
import Flowers from "./routes/Flowers";
import Home from "./routes/Home";


const router = createBrowserRouter([
  {
    path: "/",
    element: <ResponsiveAppBar />,
    errorElement: <h1>Page not found :(</h1>,
    children: [
      {
        element: <Home></Home>,
        path: ''
      },
      {
        element: <Flowers></Flowers>,
        path: 'Flowers'
      },
      {
        element: '',
        path: 'Bonsais'
      },
    ]
  },
  {
    path: "/Login",
    element: <div>BunaLogin</div>,
    errorElement: <h1>Page not found :(</h1>,
  }
]);

function App() {
  return (
    <RouterProvider router={router} />
  )
}

export default App;
