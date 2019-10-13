import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import Home from './Welcome';
import Customer from '../containers/Customer';
import AdditionalField from '../containers/AdditionalField';


const Router = (): JSX.Element => {
    return (
        <Switch>
            <Route exact path="/" component={Home}/>
            <Route  path="/Customers" component={Customer}/>
            <Route  path="/AdditionalFields" component={AdditionalField}/>
        </Switch>

    )
}

export default Router;