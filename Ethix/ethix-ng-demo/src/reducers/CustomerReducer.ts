import ActionTypes from '../actions/ActionTypes';
import InitiState from '../models/InitialState';

const state: InitiState = {
    Customer: [{ branchName: '', custmerName: '', customerId: 0, openDate: '' }],
    ClassCodeList: [{ acc_Type: '', class_Code: '', classCodeId: 0 }],
    CustomerAccList: {
        customer: { branchName: '', custmerName: '', customerId: 0, openDate: '' }, customerAccountList: [{
            accId: 0,
            Acc_Type: '',
            Acc_Number: '',
            Class_Code: '',
            openning_Bal: 0.00,
            IsClosed: false,
            currencyId: 0,
            CustomerId: 0,
            currency: 0,
            currDecimal:0
        }]
    },
    StaticCustomerList: [{ branchName: '', custmerName: '', customerId: 0, openDate: '' }]
}

const CustomerReducer = (InitiState = state, action: any) => {
    switch (action.type) {
        case ActionTypes.GET_All_CUSTOMERS:
            return {
                ...InitiState,
                Customer: action.customers,
                ClassCodeList: InitiState.ClassCodeList,
                CustomerAccList: InitiState.CustomerAccList,
                StaticCustomerList: action.customers
            }

        case ActionTypes.GET_Customer_BY_ID:
            return {
                ...InitiState,
                Customer: InitiState.Customer,
                ClassCodeList: InitiState.ClassCodeList,
                CustomerAccList: action.CustAcc,
                StaticCustomerList: InitiState.StaticCustomerList
            }
        case ActionTypes.GET_SEARCH_RESULT:
            if (action.Search_Input == "" || action.Search_Input == undefined) {
                //if (InitiState.Customer.length == 0) {
                return {
                    ...InitiState,
                    Customer: InitiState.StaticCustomerList,
                    ClassCodeList: InitiState.ClassCodeList,
                    CustomerAccList: InitiState.CustomerAccList,
                    StaticCustomerList: InitiState.StaticCustomerList
                }
            }
            else {
                let result = InitiState.StaticCustomerList.filter((c: any) => c.custmerName.toLowerCase().includes(action.Search_Input.toLowerCase()) || c.customerId == action.Search_Input);
                return {
                    ...InitiState,
                    Customer: result,
                    ClassCodeList: InitiState.ClassCodeList,
                    CustomerAccList: InitiState.CustomerAccList,
                    StaticCustomerList: InitiState.StaticCustomerList
                }
            }
        case ActionTypes.FILL_CLASS_CODE_DDL:
            return {
                ...InitiState,
                Customer: InitiState.Customer,
                ClassCodeList: action.classCode,
                CustomerAccList: InitiState.CustomerAccList,
                StaticCustomerList: InitiState.StaticCustomerList
            }
        case ActionTypes.ADD_ACCOUNT:
            InitiState.CustomerAccList.customerAccountList.push(action.acc);
            return {
                ...InitiState,
                Customer: InitiState.Customer,
                ClassCodeList: InitiState.ClassCodeList,
                CustomerAccList:{...InitiState.CustomerAccList,customerAccountList: InitiState.CustomerAccList.customerAccountList,customer:InitiState.CustomerAccList.customer},
                StaticCustomerList: InitiState.StaticCustomerList
            }
        case ActionTypes.UPDATE_ACCOUNT_STATE:
        let index = InitiState.CustomerAccList.customerAccountList.findIndex(ac=>ac.accId == action.Id);
        InitiState.CustomerAccList.customerAccountList.splice(index,1);
            return {
                ...InitiState,
                Customer: InitiState.Customer,
                ClassCodeList: InitiState.ClassCodeList,
                CustomerAccList:{...InitiState.CustomerAccList,customerAccountList: InitiState.CustomerAccList.customerAccountList,customer:InitiState.CustomerAccList.customer},
                StaticCustomerList: InitiState.StaticCustomerList
            }
        default:
            return InitiState;
    }
}


export default CustomerReducer;