import React from 'react';
import Menu from './index';
import ReactDOM from 'react-dom';
import { act } from 'react-dom/test-utils';

let container;

beforeEach(() => {
    container = document.createElement('div');
    document.body.appendChild(container);
  });
  
  afterEach(() => {
    document.body.removeChild(container);
    container = null;
  });

it('componente renderizado corretamente', () => {
    const div = document.createElement('div')
    ReactDOM.render(<Menu />, div)
})

it('renderiza menu sem autorizacao', () => {
    ReactDOM.render(<Menu />, container);
    const navbar = container.querySelector('.navbar-nav');
    expect(navbar.textContent).toBe('');
})

it('renderiza menu com autorizacao', () => {
    
    act(() => {    
        localStorage.setItem('token-codetur', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmYW1pbHlfbmFtZSI6IkZlcm5hbmRvIEhlbnJpcXVlIiwiZW1haWwiOiJhZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsInJvbGUiOiJBZG1pbiIsImp0aSI6ImVkMGJlNGYxLTkzMGMtNDk2MC1hYmIzLTRjZjZlMDY3NmYyNyIsImV4cCI6MTYxMjc2NTAyNSwiaXNzIjoiY29kZXR1ci5jb20uYnIiLCJhdWQiOiJjb2RldHVyLmNvbS5iciJ9.yHsPFNA6QkXev3Br5JMqQs2t6ihduqnXPd7W_IHuMUA');    
    });

    ReactDOM.render(<Menu />, container);
    const navbar = container.querySelector('.navbar-nav');
    console.log(navbar);
    expect(navbar.textContent).toBe('');
})