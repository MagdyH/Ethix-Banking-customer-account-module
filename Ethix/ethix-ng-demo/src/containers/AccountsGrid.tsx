import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import API from '../api/CustomerAPI';
import Actions from '../actions/EthixActions';
import Pagination from '../components/Pagination';
import {BigNumber} from 'bignumber.js';

export const Grid = (props: any) => {
    let pageSize = props.pageSize;
    let pageNumber = props.pageIndex;

    let startIndex = (pageNumber - 1) * pageSize;
    let endIndex = startIndex + pageSize;

    const dataPage = props.CustomerAccounts.customerAccountList.filter((a: any, index: number) => index >= startIndex && [index] < endIndex);

    return <div className="mt-3">
        <table className="table table-bordered">
            <GridHeader  />
            <tbody>
                { dataPage.length > 0 && dataPage[0].accId != 0 ?dataPage.map((account: any) => <GridRow id={account.accId} key={account.accId} /* actions={props.actions}*/ api={props.api}  {...account} />):<tr key={0}><td colSpan={7} className="text-center">No Account found</td></tr>}
            </tbody>
        </table>
        <Pagination actions={props.Actions} pageSize={props.pageSize} count={props.count} listofIndex={props.listofIndex} />
    </div>
}

export const GridHeader = () => {
    return <thead>
        <tr>
            <th>#</th>
            <th>Account Type</th>
            <th>Class Code</th>
            <th>Account Number</th>
            <th>Balance</th>
            <th>Currency</th>
            <th>    </th>
        </tr>
    </thead>
}


export class GridRow extends React.Component<any, any> {
    constructor(props: any) {
        super(props)

        this.state = { isEdit: false, editobj: 0, show: false, confirmed: false }
    }

    handleEditdata(obj: any, e: any) {
        this.setState({ isEdit: true });
    }

    handleDeletedata(obj: any, e: any) {

        this.setState({ show: false, confirmed: true });
        //if (this.state.confirmed) {
        this.props.api.updateAccountState(obj);
        //}
    }


    render(): JSX.Element {
        let amount = new BigNumber((this.props.openning_Bal).toFixed(this.props.currDecimal));
        
        return <tr id={this.props.accId}>
            <td key={this.props.accId + "0"}>{this.props.accId}</td>
            <td key={this.props.accId + "1"}>{this.props.acc_Type}</td>
            <td key={this.props.accId + "2"}>{this.props.class_Code}</td>
            <td key={this.props.accId + "3"}>{this.props.acc_Number}</td>
            <td key={this.props.accId + "4"}>{this.props.openning_Bal == undefined ? "" :  amount.toFormat(this.props.currDecimal) }</td>  
            <td key={this.props.accId + "5"}>{this.props.currency}</td>
            <td key={this.props.accId + "6"}>
                <button className='btn-md btn-danger' onClick={this.handleDeletedata.bind(this, this.props.accId)}>
                    <span className='glyphicon glyphicon-remove'></span> Remove
                                                                </button>
                {/* <SweetAlert
                show={this.state.show}
                title="Remove"
                text="Do you want to remove this user ?"
                onConfirm={()=>{this.setState({ show: false,confirmed: true }); this.props.api.deleteUser(this.props.userId);}} 
                
                />*/}
            </td>
        </tr>
    }
}
//{Math.round(this.props.openning_Bal)}
//Number((this.props.openning_Bal).toFixed(1)) - 
function mapStateToProps(state: any, ownProps: any) {
    return {
        pageSize: state.Grid.pageSize,
        pageIndex: state.Grid.pageIndex,
        count: state.Grid.count,
        listofIndex: state.Grid.listofIndex

    }
}


function mapDispatcherToProps(dispatch: any) {
    return {
        API: bindActionCreators(API, dispatch),
        Actions: bindActionCreators(Actions, dispatch)
    }

}

export default connect(mapStateToProps, mapDispatcherToProps)(Grid);



