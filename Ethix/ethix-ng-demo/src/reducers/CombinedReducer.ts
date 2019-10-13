import { combineReducers } from "redux";
import Customer from "../reducers/CustomerReducer";
import Grid from "../reducers/GridReducer";
import Currency from '../reducers/CurrencyReducer';

const combined = combineReducers({ Customer, Grid, Currency });


export default combined;