import React from 'react';
import ReactDOM from 'react-dom';
import { ToastProvider } from 'react-toast-notifications';
import Login from '../login';

import { act } from 'react-dom/test-utils';

it('Verifica se esta mostrando o texto CodeTur', () => {
    const div = document.createElement('div')
    ReactDOM.render(<ToastProvider><Login /></ToastProvider>, div)
    expect(div).toMatchSnapshot();
})