import * as React from 'react';
import AccountsGrid from '../containers/AccountsGrid';
import AddAccount from '../components/AddAccountForm';
import '../App.css';

const CustomerAccounts = (props: any): JSX.Element => {
    return (
        <div>
            <AccountsGrid CustomerAccounts={props.CustomerAccounts} api={props.api} />
            <ul className="nav nav-tabs" role="tablist">
                <li className="nav-item">
                    <a className="nav-link aDisabled active" data-toggle="tab" href="#Add">Add New Account</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link aDisabled" data-toggle="tab" href="#field">Additional Fields</a>
                </li>
            </ul>
            <div className="tab-content">
                <div id="Add" className="container tab-pane active"><br />
                    <AddAccount CustomerID={props.CustomerID} Currency={props.Currency} api={props.api} ClassCode={props.ClassCode} />
                </div>
                <div id="field" className="container tab-pane fade"><br />
                    <div >Additional</div>

                </div>
            </div>
        </div>
    )
}


export default CustomerAccounts;


