import ActionTypes from './ActionTypes';
import CustomerAccount from '../models/CustomerAccount';
import Customer from '../models/Customer';
import CustomerAccounts from '../models/CustomerAccView';
import Currency from '../models/Currency';
import ClassCode from '../models/ClassCode';
import ExchangeRate from '../models/ExchangeRate';

const EthixActions:any={
    addAccount:(acc:CustomerAccount)=>{
        return{type:ActionTypes.ADD_ACCOUNT,acc}
    },
    getCustomerById:(CustAcc:CustomerAccounts)=>{
        return{type:ActionTypes.GET_Customer_BY_ID,CustAcc}
    },
    updateAccState:(Id:number)=>{
        return{type:ActionTypes.UPDATE_ACCOUNT_STATE,Id}
    },
    fillClassCodeDDL:(classCode:ClassCode[])=>{
        return{type:ActionTypes.FILL_CLASS_CODE_DDL,classCode}
    },
    getSearchResult:(Search_Input:string)=>{
        return{type:ActionTypes.GET_SEARCH_RESULT,Search_Input}
    },
    getAllResult:(customers:Customer[])=>{
        return{type:ActionTypes.GET_All_CUSTOMERS,customers}
    },
    GetIndex: (index:number,size:number,count:number)=>{
        return {type:ActionTypes.GET_INDEX,index,size,count}
        },
    applyChange:(index:number,size:number,count:number)=>{
        return {type:ActionTypes.APPLY_CHANGE,index,size,count}
    },
    fillCurrency:(Currency:Currency[])=>{
        return {type:ActionTypes.FILL_CURRENCY,Currency}
    },
    getExchangeRates:(ExchangeRate:ExchangeRate[])=>{
        return {type:ActionTypes.GET_EXCHANGE_RATES,ExchangeRate}
    }
}

export default EthixActions;