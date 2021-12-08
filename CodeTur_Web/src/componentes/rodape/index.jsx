import React from 'react';

const Rodape = ({texto}) => {
    return (
        <footer className="text-center" style={{ marginTop : '70px'}}>
                <h1>{texto === undefined ? "CodeTur" : texto}</h1>
                <small>Desenvolvido por <a href="https:/github.com/nicolasgabrieloficial">Nicolas Gabriel</a></small>
        </footer>
    )
}

export default Rodape;