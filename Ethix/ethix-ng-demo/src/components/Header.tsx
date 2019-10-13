import * as React from 'react';
import { Link } from 'react-router-dom';


const Header = (): JSX.Element => {
    return (
        <header>
            <nav className="navbar navbar-expand-md navbar-light bg-light">
                <div className="container">
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav">
                            <li className="nav-item"><Link className="nav-link" to="/">Home</Link></li>
                            <li className="nav-item"><Link className="nav-link" to="/Customers">Customers</Link></li>
                            <li className="nav-item"><Link className="nav-link" to="/AdditionalFields">Additional Fields</Link></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    )
}

export default Header;