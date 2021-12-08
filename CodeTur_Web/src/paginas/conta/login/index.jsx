import React from 'react';
import { useFormik } from 'formik';

import Menu from '../../../componentes/menu';
import Rodape from '../../../componentes/rodape';
import {Container, Form, Button} from 'react-bootstrap';
import './index.css';
import ContaServico from '../../../services/contaServico';
import { useToasts } from 'react-toast-notifications';
import  { useHistory } from 'react-router-dom';

 const Login = () => {
    const { addToast } = useToasts();
    const history = useHistory();

    const formik = useFormik({
        initialValues: {
          email: '',
          senha: ''
        },
        onSubmit: (values, { setSubmitting }) => {
          ContaServico.logar(values)
            .then(resultado => {
                console.log(`Resultado ${resultado.data}`)
                setSubmitting(false);
                if(resultado.data.sucesso){
                    //mensagem
                    addToast(resultado.data.mensagem, {
                        appearance: 'success',
                        autoDismiss: true,
                    })
                    //salvar local storage
                    localStorage.setItem('token-codetur', resultado.data.data.token)
                    //redirecionar tela admin
                    history.push('/admin');
                } else {
                    addToast(resultado.data.mensagem, {
                        appearance: 'error',
                        autoDismiss: true,
                    })
                }
            })
            .catch(error => console.error(error));
        },
    });

    return (
        <div>
            <Menu />
            <Container className='form-height'>
                <Form className='form-signin' onSubmit={formik.handleSubmit}>
                    <h1>Login</h1>
                    <small>Informe os dados Abaixo</small>
                        
                    <hr/>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email </Form.Label>
                        <Form.Control type="email" placeholder="Informe o email" name="email" onChange={formik.handleChange} value={formik.values.email} required/>
                    </Form.Group>

                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Senha</Form.Label>
                        <Form.Control type="password" placeholder="Senha" name="senha" onChange={formik.handleChange} value={formik.values.senha} required/>
                    </Form.Group>
                    <Button variant="primary" type="submit" disabled={!formik.isValid || formik.isSubmitting}>
                        Enviar
                    </Button>
                    <br/><br/>
                    <a href='/conta/resetar-senha' style={{ marginTop :'30px'}}>Esqueci a senha!</a>
                    <a href='/conta/cadastro' style={{ marginLeft :'30px'}}>Não tenho conta!</a>
                </Form>
                
            </Container>
            <Rodape />
        </div>
    )

}

export default Login;