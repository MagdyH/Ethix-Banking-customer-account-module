import * as React from 'react';
import { BrowserRouter } from 'react-router-dom';
import Header from './components/Header';
import Router from './components/Route';

const App = ():JSX.Element => {
  return (
    <BrowserRouter>
    <div>
      <Header />
      <Router />
      </div>
    </BrowserRouter>
  );

}

export default App;
