import * as React from 'react';
import '../App.css';

const SelectOption = (props: any): JSX.Element => {
    return (
            <option value={props.currencyId}>
               {props.currency} - {props.isO_Code}
            </option>
    )
}


export default SelectOption;