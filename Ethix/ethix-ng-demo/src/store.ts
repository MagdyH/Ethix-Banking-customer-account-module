import { createStore,applyMiddleware} from 'redux';
import combined from './reducers/CombinedReducer';
import paginationMiddleware from './actions/middlewares';
import thunk from 'redux-thunk';

const store = createStore(combined,applyMiddleware(paginationMiddleware,thunk));

export default store;