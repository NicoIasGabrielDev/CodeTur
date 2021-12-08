import http from '../utils/http-axios';

const listar = () => {
    return http.get('pacotes', {
        headers : {
            'authorization' : `Bearer ${localStorage.getItem('token-codetur')}`
        }
    });
}

const cadastrar = dados => {
    return http.post('pacotes', JSON.stringify(dados), {
        headers : {
            'authorization' : `Bearer ${localStorage.getItem('token-codetur')}`
        }
    });
}

const alterar = dados => {
    return http.put(`pacotes/${dados.id}`, JSON.stringify(dados), {
        headers : {
            'authorization' : `Bearer ${localStorage.getItem('token-codetur')}`
        }
    });
}

const alterarStatus = dados => {
    return http.put(`pacotes/${dados.id}/status`, JSON.stringify(dados), {
        headers : {
            'authorization' : `Bearer ${localStorage.getItem('token-codetur')}`
        }
    });
}

const buscarPorId = id => {
    return http.get(`pacotes/${id}`, {
        headers : {
            'authorization' : `Bearer ${localStorage.getItem('token-codetur')}`
        }
    });
}

export default {
    listar,
    cadastrar,
    buscarPorId,
    alterar,
    alterarStatus
}
