import Customer from '../models/Customer';
import ClassCode from '../models/ClassCode';
import CustomerAccView from '../models/CustomerAccView';


class InitialState{
    Customer:Customer[];
    CustomerAccList:CustomerAccView;
    ClassCodeList:ClassCode[];
    StaticCustomerList:Customer[];
}

export default InitialState;