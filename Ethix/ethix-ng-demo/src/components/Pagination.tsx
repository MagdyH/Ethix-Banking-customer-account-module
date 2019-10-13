import * as  React from 'react';


class Pagination extends React.Component<any, any>{
    constructor(props: any) {
        super(props)

        this.state = { pageIndex: 1 }

        this.handlePaginationClick = this.handlePaginationClick.bind(this);
    }

    handlePaginationClick(event: any) {
        event.preventDefault();
        this.setState({ pageIndex: Number(event.target.innerHTML) })
        this.props.actions.GetIndex(Number(event.target.innerHTML), this.props.pageSize, this.props.count);
    }

    render(): JSX.Element {
        const numberOfpages = this.props.listofIndex.map((page: any) => <li key={page} className="page-link" onClick={this.handlePaginationClick}>{page}</li>)
        return <nav aria-label="Page navigation example">
            <ul className="pagination">
                {numberOfpages}
            </ul>
        </nav>
    }
}


export default Pagination;