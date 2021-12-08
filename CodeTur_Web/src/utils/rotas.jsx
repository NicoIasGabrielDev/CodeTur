

import { BrowserRouter as Router, Redirect, Route, Switch } from "react-router-dom";
import jwt_decode from 'jwt-decode';
import Login from "../paginas/conta/login";
import ResetarSenha from "../paginas/conta/resetarsenha";
import Dashboard from "../paginas/admin/dashboard";
import Pacote from "../paginas/admin/pacote";
import NaoEncontrada from "../paginas/naoencontrada";

const RotaPrivadaAdmin = ({component : Component, ...rest}) => (
    <Route 
      {...rest}
      render = { props => 
          localStorage.getItem('token-codetur') !== null && jwt_decode(localStorage.getItem('token-codetur')).role === 'admin' ? 
            (<Component {...props} />) : 
            (<Redirect to={{ pathname :'/', state :{from : props.location}}} />)
      }
    />
  );
  

const Rotas = (
  <Router>
    <Switch>
      <Route path='/' exact component={Login} />
      <Route path='/conta/resetar-senha' component={ResetarSenha} />
      <RotaPrivadaAdmin path='/admin' exact component={Dashboard} />
      <RotaPrivadaAdmin path='/admin/pacotes' component={Pacote} />
      <Route component={NaoEncontrada} />
    </Switch>
  </Router>
)

export default Rotas;