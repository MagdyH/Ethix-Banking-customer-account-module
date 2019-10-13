import * as React from 'react';
import CustomerSearch from '../components/CustomerSearch';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import API from '../api/CustomerAPI';
import Actions from '../actions/EthixActions';
//import InitiState from '../models/InitialState';
//import InitiState from '../models/InitialState';
import CustomerResult from '../components/CustomerResult';


const Customer = (props: any): JSX.Element => {
    return (
        <div className="container">
            <CustomerSearch Actions={props.Actions} />
            <div>
                <h2><span className="badge badge-secondary">{props.customer.length}</span></h2>
            </div>
            <CustomerResult Customers={props.customer} api={props.API} Currency={props.Currency} ClassCode={props.ClassCodes} exRate={props.ExchangeRates} CustomerDetails={props.CustomerAccountList} />
        </div>
    )
}



function mapStateToProps(state: any, ownProps: any) {
    return {
        customer: state.Customer.Customer,
        ClassCodes: state.Customer.ClassCodeList,
        CustomerAccountList: state.Customer.CustomerAccList,
        Currency: state.Currency.currency,
        ExchangeRates: state.Currency.exchangeRate

    }
}


function mapDispatcherToProps(dispatch: any) {
    return {
        API: bindActionCreators(API, dispatch),
        Actions: bindActionCreators(Actions, dispatch)
    }

}

export default connect(mapStateToProps, mapDispatcherToProps)(Customer);