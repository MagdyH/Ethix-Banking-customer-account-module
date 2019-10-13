import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import Store from './store';
import { Provider } from 'react-redux';
import CustomerAPI from './api/CustomerAPI';

import '../node_modules/bootstrap/dist/css/bootstrap.css';
import '../node_modules/bootstrap/dist/js/bootstrap';

Store.dispatch(CustomerAPI.getAllResult());
Store.dispatch(CustomerAPI.getCurrencyDDL());
Store.dispatch(CustomerAPI.getExchangeRates());

ReactDOM.render(
  <Provider store={Store}>
    <App />
  </Provider>,
  document.getElementById('root') as HTMLElement
);
registerServiceWorker();
