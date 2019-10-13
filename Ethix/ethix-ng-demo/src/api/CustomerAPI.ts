import axios/*, { AxiosResponse }*/ from 'axios';
import actions from '../actions/EthixActions';
import CustomerAccount from '../models/CustomerAccount';
import { Dispatch } from 'react-redux';

const CustomerAPI = {

    getAllResult: () => {
        return (dispatch: Dispatch<any>) => {
            axios.get("http://localhost:57380/api/Customers",
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(
                    (response: any) => {
                        dispatch(actions.getAllResult(response.data))
                    }).catch((err) => { console.log(err) }

                    )
        };
    },

    getCustomerDetailsByID: (Id: number) => {
        return (dispatch: Dispatch<any>) => {
            axios.get("http://localhost:57380/api/Customers/getById/" + Id,
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(
                    (response: any) => {
                        dispatch(actions.getCustomerById(response.data))
                    }).catch((err) => { console.log(err) }

                    )
        };
    },
    getCurrencyDDL: () => {
        return (dispatch: Dispatch<any>) => {
            axios.get("http://localhost:57380/api/Customers/getCurrency",
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(
                    (response: any) => {
                        dispatch(actions.fillCurrency(response.data))
                    }).catch((err) => { console.log(err) }

                    )
        };
    },
    getClassCodeByAccType: (Acc_Type: string) => {
        return (dispatch: Dispatch<any>) => {
            if (Acc_Type != "") {
                axios.get("http://localhost:57380/api/Customers/getClassCode/" + Acc_Type,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(
                        (response: any) => {
                            dispatch(actions.fillClassCodeDDL(response.data))
                        }).catch((err) => { console.log(err) }

                        )
            }
        };
    },
    addNewCustomerAccount: (account: CustomerAccount) => {
        if (account.openning_Bal <=0) {
            alert("Can't add new account with balance 0");
        }
        else if (account.Acc_Number.length < 12 || account.Acc_Number.length > 12) {
            alert("Account Number must be exact 12 digits");
        }
        return (dispatch: Dispatch<any>) => {
            axios({
                url: "http://localhost:57380/api/Customers/",
                method:"POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(account)
            }).then(
                (response: any) => {
                    if (response.data.accId == 0) {
                        alert("add new account has failed");
                    }
                    else{
                        dispatch(actions.addAccount(response.data))
                    }
                }).catch((err) => { console.log(err) }

                )

        };
    },
    updateAccountState: (Id: number) => {
        return (dispatch: Dispatch<any>) => {
            axios({
                url: "http://localhost:57380/api/Customers/UpdateAcc/"+Id,
                method:"POST",
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(
                (response: any) => {
                    dispatch(actions.updateAccState(Id))
                }).catch((err) => { console.log(err) }

                )

        };
    },
    getExchangeRates: () => {
        return (dispatch: Dispatch<any>) => {
            axios.get("http://localhost:57380/api/Customers/getExRates",{
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(
                (response: any) => {
                    dispatch(actions.getExchangeRates(response.data))
                }).catch((err) => { console.log(err) }

                )

        };
    }
}





export default CustomerAPI;