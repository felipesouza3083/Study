var React = require('react');
var ReactDOM = require('react-dom');

var Cadastro = require('./Cadastro');

var Consulta = require('./Consulta');

ReactDOM.render(
    <Cadastro />,
    document.getElementById('componente_cadastro')
);

ReactDOM.render(
    <Consulta />,
    document.getElementById('componente_consulta')
);