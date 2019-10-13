import * as React from 'react';
import CustomerAccount from '../models/CustomerAccount';
import Option from '../components/SelectOption';
//import swal from 'sweetalert';

interface MyState extends CustomerAccount{
    formError:{}
}

class AddAccountForm extends React.Component<any, MyState> {
    constructor(props: any) {
        super(props);
        this.state = { accId: 0, Acc_Type: '0', Acc_Number: '', Class_Code: '0', openning_Bal: 0, currencyId: 0, CustomerId: 0, currency: 0, IsClosed: false, currDecimal: 0,formError:{} };

        this.handleAccountType = this.handleAccountType.bind(this);
        this.handleClassCode = this.handleClassCode.bind(this);
        this.handleAccountNumber = this.handleAccountNumber.bind(this);
        this.handleOpeningBalance = this.handleOpeningBalance.bind(this);
        this.handleCurrency = this.handleCurrency.bind(this);


        this.handleSubmit = this.handleSubmit.bind(this);
    }

    public handleAccountType(event: any): void {
        this.props.api.getClassCodeByAccType(event.target.value);
        this.setState({ Acc_Type: event.target.value });
        ;
    }

    public handleClassCode(event: any): void {

        this.setState({ Class_Code: event.target.value });
    }

    public handleAccountNumber(event: any): void {

        this.setState({ Acc_Number: event.target.value });
    }

    public handleOpeningBalance(event: any): void {

        this.setState({ openning_Bal: event.target.value });
    }

    public handleCurrency(event: any): void {

        this.setState({ currencyId: event.target.value });
    }

    public formValidation(): boolean {
        let errors: any = { AccId: 0, Acc_Type: '', Acc_Number: '', Class_Code: '', Openning_Bal: '', CurrencyId: 0, CustomerId: 0, Currency: '', IsClosed: false };
        let isValid = true;

        if (this.state.Acc_Type == '0') {
            /* swal({
                title:'Please select Account Type',
                icon: "warning",           
            }); */
            isValid = false;
            errors.Acc_Type = 'Please Select Account Type';
        }

        if (this.state.Class_Code == '0') {
            /* swal({
                title: 'Please select Class Code',
                icon: "warning",
                buttons: ["OK"]
            }); */
            isValid = false;
            errors.Class_Code = 'Please select Class Code';
        }

        if (this.state.Acc_Number.length < 12 || this.state.Acc_Number.length > 12) {
            /* swal({
                title: 'Account Number must be exact 12 digits',
                icon: "warning",
                buttons: ["OK"]
            }); */
            isValid = false;
            errors.Acc_Number = 'Account Number must be exact 12 digits';
        }

        if (this.state.openning_Bal <= 0) {
           /*  swal({
                title: 'Balance must be greater than zero',
                icon: "warning",
                buttons: ["OK"]
            }); */
            isValid = false;
            errors.Openning_Bal = 'Balance must be greater than zero';
        }
        if (this.state.currencyId == 0) {
            /* swal({
                title: 'Please select Currency',
                icon: "warning",
                buttons: ["OK"]
            }); */
            isValid = false;
            errors.Currency = 'Please select Currency';
        }

        this.setState({ formError: errors });

        return isValid;
    }

    public handleSubmit(event: any) {
        event.preventDefault();

        if (this.formValidation()) {
            let account: CustomerAccount = { accId: 0, Acc_Type: '0', Acc_Number: '', Class_Code: '0', openning_Bal: 0, currencyId: 0, CustomerId: 0, currency: 0, IsClosed: false, currDecimal: 0 };
            account.accId = 0;
            account.Acc_Type = this.state.Acc_Type;
            account.Class_Code = this.state.Class_Code;
            account.Acc_Number = this.state.Acc_Number;
            account.openning_Bal = this.state.openning_Bal;
            account.currencyId = this.state.currencyId;
            account.IsClosed = false;
            account.CustomerId = this.props.CustomerID

            this.props.api.addNewCustomerAccount(account);

            this.setState({ accId: 0, Acc_Type: '0', Acc_Number: '', Class_Code: '0', openning_Bal: 0, currencyId: 0, CustomerId: 0, currency: 0, IsClosed: false });
        }
    }

    public render(): JSX.Element {
        let currencies = this.props.Currency.length > 1 ? this.props.Currency.map((curr: any) => <Option key={curr.currencyId} {...curr} />) : "";
        let str = this.props.ClassCode != undefined && this.props.ClassCode.length <= 1 ? "-- select Account Type first --" : "-- select Class Code --";
        let classCodes = this.props.ClassCode != undefined && this.props.ClassCode.length > 1 ? this.props.ClassCode.map((cc: any) => <option key={cc.classCodeId} value={cc.class_Code}>{cc.class_Code}</option>) : "";
        return <form className="col-12" onSubmit={this.handleSubmit}>
            <div className="row">
                <div className="col-6 form-group">
                    <label> Account Type</label> <select className="form-control" value={this.state.Acc_Type} onChange={this.handleAccountType}>
                        <option value="0">--- select Account Type ---</option>
                        <option value="CK">CK</option>
                        <option value="SV">SV</option>
                        <option value="CD">CD</option>
                    </select>
                    <span style={{ color: 'red' }}>{this.state.formError["Acc_Type"]}</span>
                    <br />
                </div>
                <div className="col-6 form-group">
                    <label>  Class Code </label> <select className="form-control" value={this.state.Class_Code} onChange={this.handleClassCode}>
                        <option value="0">{str}</option>
                        {classCodes}
                    </select>
                    <span style={{ color: 'red' }}>{this.state.formError["Class_Code"]}</span>
                    <br />
                </div>
            </div>
            <div className="row">
                <div className="col-4 form-group">
                    <label>  Account Number </label> <input className="form-control" type="number" maxLength={12} minLength={12} value={this.state.Acc_Number} onChange={this.handleAccountNumber} placeholder="Enter 12 digits" required />
                    <span style={{ color: 'red' }}>{this.state.formError["Acc_Number"]}</span>
                    <br />
                </div>
                <div className="col-4 form-group">
                    <label>  Opening balance </label> <input className="form-control" type="number" value={this.state.openning_Bal.toString()} onChange={this.handleOpeningBalance} required />
                    <span style={{ color: 'red' }}>{this.state.formError["Openning_Bal"]}</span>
                    <br />
                </div>
                <div className="col-4 form-group">
                    <label>  Currency </label> <select className="form-control" value={this.state.currencyId} onChange={this.handleCurrency}>
                        <option value="0">--- select Currency ---</option>
                        {currencies}
                    </select>
                    <span style={{ color: 'red' }}>{this.state.formError["Currency"]}</span>
                    <br />
                </div>
            </div>
            <div className="row">
                <div className="col-12 form-group">
                    <input type="submit" value="Add" className="col-3 form-control btn btn-secondary" required />
                </div>
            </div>
        </form>;
    }
}
export default AddAccountForm;
