import ActionTypes from '../actions/ActionTypes';
import CurrencyExchange from '../models/CurrencyExchangeRate';

const InitiState: CurrencyExchange = {
    currency: [{
        currencyId: 0, currency: '', decimal_Digits: 0, iSO_Code: ''
    }],
    exchangeRate: [{
        id: 0,
        operator: '',
        amount: 0,
        fromCurrency: 0,
        toCurrency: 0
    }]
}
//,ExchangeRate[]

const CurrencyReducer = (state = InitiState, action: any) => {
    switch (action.type) {
        case ActionTypes.FILL_CURRENCY:
            return {...state,currency: action.Currency};
        case ActionTypes.GET_EXCHANGE_RATES:
            return {...state,exchangeRate: action.ExchangeRate} ;
        default:
            return state;
    }
}

export default CurrencyReducer;