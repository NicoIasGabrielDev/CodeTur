import React from 'react'
import  { useHistory } from 'react-router-dom';

import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import jwt from 'jwt-decode';

const Menu = () => {
    const history = useHistory();

    const sair = (event) => {
        event.preventDefault();
        localStorage.removeItem('token-codetur');
        history.push('/');
    }
    const menuTipoUsuario = () => {
        const token = localStorage.getItem('token-codetur');
        if(token !== null){
            return (
                <Nav>
                    <Nav.Link href="/admin">DashBoard</Nav.Link>
                    <Nav.Link href="/admin/pacotes">Pacotes</Nav.Link>
                    <NavDropdown title={token === undefined ? "" : jwt(token).family_name} id="basic-nav-dropdown">
                        <NavDropdown.Item href="/perfil">Perfil</NavDropdown.Item>
                        <NavDropdown.Divider />
                        <NavDropdown.Item  onClick={ event => sair(event)}>Sair</NavDropdown.Item>
                    </NavDropdown>
                </Nav>
            )
        }
    }

    return (

        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Navbar.Brand href="/">CODETUR</Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="mr-auto">
                   
                </Nav>
                { menuTipoUsuario() }
            </Navbar.Collapse>
        </Navbar>
    )
}

export default Menu