import React from 'react';
import Menu from '../../componentes/menu';
import Rodape from '../../componentes/rodape';
import {Container} from 'react-bootstrap';

 const NaoEncontrada = () => {
    return (
        <div>
            <Menu />
            <Container className='form-height'>
                <h1>404</h1>
            </Container>
            <Rodape />
        </div>
    )

}

export default NaoEncontrada;