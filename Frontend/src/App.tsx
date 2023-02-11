import ResponsiveAppBar from "./components/ResponsiveAppBar";
import React from "react";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Homepage from "./routes/Homepage";
import Flowers from "./routes/Flowers";


function App() {
  return (
    <ResponsiveAppBar></ResponsiveAppBar>
  )
}

export default App;
