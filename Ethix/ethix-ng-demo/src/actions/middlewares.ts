
import EthixActions from "../actions/EthixActions";

const PaginationMiddleware:any = (store :any) => (next:any) => (action:any) =>{
      
    let count=0,index=0,size=0;        
    let result = next(action);

     count = store.getState().Customer.CustomerAccList.customerAccountList.length;
     index = store.getState().Grid.pageIndex;
     size = store.getState().Grid.pageSize;

    if (action.type !== "APPLY_CHANGE") {
        store.dispatch(EthixActions.applyChange(index,size,count));
    }
    return result;    
}


export default PaginationMiddleware;