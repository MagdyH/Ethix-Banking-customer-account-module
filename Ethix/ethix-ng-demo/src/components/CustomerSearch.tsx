import * as React from 'react';
import * as $ from 'jquery';

class CustomerSearch extends React.Component <any,any>{

    constructor(props:any){
        super(props)
        this.state= {inputValue:''}
    }

    render():JSX.Element{
        return(
            <div className="mt-4">
                <input id="search" className="form-control" type="text" /*value={this.state.inputValue}*/ onChange={(event)=>{
                    //this.setState({inputValue:$('#search').val()});
                    this.props.Actions.getSearchResult($('#search').val())}} placeholder="Search by Customer RIM / Name"/>
                </div>
        )
    }
}

export default CustomerSearch;