import * as React from 'react';
import '../App.css';
import CustomerAccount from '../models/CustomerAccount';
import { Currencies } from 'ts-money';
import { BigNumber } from 'bignumber.js';
import * as moment from 'moment';

const CustomerInfo = (props: any): JSX.Element => {
    let date = new Date(props.CustomerDetails.customer.openDate).toLocaleDateString();

    let total = 0;
    //props.CustomerDetails.customerAccountList.map((acconut:CustomerAccount)=>total=total+acconut.openning_Bal);
    props.CustomerDetails.customerAccountList.map((acc: CustomerAccount) => {
        let rate = props.exRate.filter((ex: any) => ex.fromCurrency == acc.currencyId && ex.toCurrency == 5008);
        if (rate.length > 0) {
            let amount = rate[0].operator == "M" ? rate[0].amount * acc.openning_Bal : acc.openning_Bal / rate[0].amount;
            total = total + amount;
        }
        else if(acc.currencyId == 5008){
            total = total + acc.openning_Bal;
        }
    })

    let amount = new BigNumber(total.toFixed(2));
    return (
        <div className="mt-3 card bg-light p-3">
            <div>
                <label>Customer Name       : </label>  <span>{props.CustomerDetails.customer.custmerName} </span>
            </div>
            {/* <br /> */}
            <div>
                <label>Calculated Balance  : </label>  <span>   {amount.toFormat(2)}  </span> <span>{Currencies.EGP.symbol}</span>
            </div>
            {/* <br /> */}
            <div>
                <label>Open Date           : </label> <span> {moment(date, "MM-DD-YYYY").format("DD-MM-YYYY")} </span>
            </div>
            {/* <br /> {props.CustomerDetails.customer.openDate} */}
        </div>
    )
}

//{Number((total).toFixed(2))}
//{new Intl.DateTimeFormat('en-US', {year: 'numeric', month: 'numeric',day: 'numeric'}).format(date)}


/* let dd = date.getDate();
    let mm = date.getMonth() + 1; //January is 0!
    let yyyy = date.getFullYear();
    let day="";
    let month="";

    day = dd < 10 ? '0' + dd :dd.toString();
    month = mm < 10 ? '0' + mm :mm.toString();
    var openDate = day + '-' + month + '-' + yyyy; */
  
    export default CustomerInfo;