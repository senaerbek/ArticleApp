import '../../App.css';
import Dashboard from './Dashboard';
import { Route, Switch } from "react-router-dom";
import AddArticle from '../Articles/AddArticle';
import Navigation from '../Navigation/Navigation';

function App() {
  return (
    <div>
       <Navigation/>
      <Switch>
      <Route path="/" exact component={Dashboard} />
       <Route path="/addArticle" component={AddArticle}/>
      </Switch>
    </div>
  );
}

export default App;
