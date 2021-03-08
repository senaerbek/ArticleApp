import "../../App.css";
import Dashboard from "./Dashboard";
import { Route, Switch } from "react-router-dom";
import AddArticle from "../Articles/AddArticle";
import Navigation from "../Navigation/Navigation";
import HomePage from "../Auth/HomePage";
import ArticleDetails from "../Articles/ArticleDetails";
import ProfileInfo from "../Profile/ProfileInfo";

function App() {
  return (
    <div>
      <Switch>
        <Route path="/" exact component={HomePage} />
        <Route path="/details/:id" exact component={ArticleDetails} />
        <Route path="/profile/:id" exact component={ProfileInfo} />
        <Route path="/dashboard" exact component={Dashboard} />
        <Route path="/addArticle" component={AddArticle} />
      </Switch>
    </div>
  );
}

export default App;
