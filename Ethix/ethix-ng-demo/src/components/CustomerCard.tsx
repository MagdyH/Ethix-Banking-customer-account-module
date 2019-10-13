import * as React from 'react';


class CustomerCard extends React.Component<any, any>{

    constructor(props: any) {
        super(props);
        this.state = { isActive: false, activeIndex: 0 }

        //this.handleActive = this.handleActive.bind(this);
    }
    handleActive(id: number, e: any): void {
        if (this.state.isActive) {
            this.setState({ isActive: false })
        }
        else {
            this.setState({ isActive: true, activeIndex: id })
        }
        this.props.selected(id);
        this.props.api.getCustomerDetailsByID(id);
    }


    render(): JSX.Element {

        const str = this.props.active ? "active" : ""; //this.state.isActive && this.state.activeIndex==this.props.customerId ? "active" : "";

        return (
            <div>
                <div className={'card p-1 tab-header ' + str} >
                    <a href="#" className="aDisabled" onClick={this.handleActive.bind(this, this.props.customerId)} >
                        <div className="card-body">
                            <h4 className="card-title">{this.props.custmerName}</h4>
                            <h6 className="card-subtitle mb-2 text-muted">{this.props.customerId}</h6>
                            <p className="card-text">{this.props.branchName}</p>
                        </div>
                    </a>
                </div>
            </div>


        )
    }
}
export default CustomerCard;