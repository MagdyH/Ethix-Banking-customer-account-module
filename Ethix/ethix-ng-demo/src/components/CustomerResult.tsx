import * as React from 'react';
import CustomerCard from '../components/CustomerCard';
import Customer from '../models/Customer';
import CustomerInfo from '../components/CustomerInfo';
import CustomerAccounts from '../components/CustomerAccounts';
import '../App.css';

class CustomerResult extends React.Component<any, any>{
    constructor(props: any) {
        super(props);
        this.state = { Selected: false, activeIndex: 0 }

        this.handleSelected = this.handleSelected.bind(this);
    }

    handleSelected(id: number) {
        /* if (this.state.selected) {
            this.setState({ selected: false,activeIndex:id })

        } else { */
        this.setState({ selected: true, activeIndex: id })

        //}
    }

    render(): JSX.Element {

        let list = this.props.Customers.map((customer: Customer, index: number) => <CustomerCard key={index} api={this.props.api} active={this.state.selected && this.state.activeIndex == customer.customerId} selected={this.handleSelected} {...customer} />)
        let str = this.state.selected && this.state.activeIndex > 0 ? 'show' : 'hide';
        return (
            <div className="row">
                <div className="mt-2 col-md-3 Scrollable ">
                    {list}
                </div>
                <div className={"col-md-9 " + str} >
                    <CustomerInfo exRate={this.props.exRate} CustomerDetails={this.props.CustomerDetails} />
                    <CustomerAccounts CustomerID={this.props.CustomerDetails.customer.customerId} CustomerAccounts={this.props.CustomerDetails} api={this.props.api} ClassCode={this.props.ClassCode} Currency={this.props.Currency} />
                </div>
            </div>
        )
    }
}
export default CustomerResult;