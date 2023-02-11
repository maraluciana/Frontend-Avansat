import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import ResponsiveAppBar from "./components/ResponsiveAppBar";
import Bonsais from "./routes/Bonsai";
import Flowers from "./routes/Flowers";
import Home from "./routes/Home";
import Login from "./routes/Login";


const router = createBrowserRouter([
  {
    path: "/",
    element: <ResponsiveAppBar />,
    errorElement: <h1>Page not found :(</h1>,
    children: [
      {
        element: <Home/>,
        path: ''
      },
      {
        element: <Flowers/>,
        path: 'Flowers'
      },
      {
        element: <Bonsais/>,
        path: 'Bonsais'
      },
    ]
  },
  {
    path: "/Login",
    element: <Login/>,
    errorElement: <h1>Page not found :(</h1>,
  }
]);

function App() {
  return (
    <RouterProvider router={router} />
  )
}

export default App;
