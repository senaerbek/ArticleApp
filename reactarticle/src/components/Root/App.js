import "../../App.css";
import Dashboard from "./Dashboard";
import { Route, Switch } from "react-router-dom";
import AddArticle from "../Articles/AddArticle";
import Navigation from "../Navigation/Navigation";
import HomePage from "../Auth/HomePage";

function App() {
  return (
    <div>
      <Switch>
        <Route path="/" exact component={HomePage} />
        <Route path="/dashboard" exact component={Dashboard} />
        <Route path="/addArticle" component={AddArticle} />
      </Switch>
    </div>
  );
}

export default App;
