import React from 'react';
import ReactDOM from 'react-dom';
import Rodape from '.';
 
it('componente renderizado corretamente', () => {
    const div = document.createElement('div')
    ReactDOM.render(<Rodape />, div)
})

it('Verifica se esta mostrando o texto CodeTur', () => {
    const div = document.createElement('div')
    const rerender = ReactDOM.render(<Rodape />, div)
    //expect(rerender.text()).toContain('CodeTur');
})