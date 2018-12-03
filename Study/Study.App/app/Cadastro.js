var React = require('react');
var CreateReactClass = require('create-react-class');

var Cadastro = CreateReactClass({

    //função para declarar os dados que serão manipulados
    //pelo componente..
    getInitialState: function () {
        return {
            nome: '',
            preco: 0,
            quantidade: 0,
            mensagem: ''
        }
    },
    //função para ler o valor de cada campo do formulário..
    lerNome: function (e) {
        //armazenar o conteudo do campo na variavel do state..
        this.setState({ nome: e.target.value });
    },

    lerPreco: function (e) {
        //armazenar o conteudo do campo na variavel do state..
        this.setState({ preco: e.target.value });
    },

    lerQuantidade: function (e) {
        //armazenar o conteudo do campo na variavel do state..
        this.setState({ quantidade: e.target.value });
    },

    //função executada pelo formulário..
    cadastrarProduto: function (e) {
        e.preventDefault();
        //atualizar o evento..
        this.setState({ mensagem: "Processando, por favor aguarde." });

        $.ajax({
            type: "POST",
            url: "http://localhost:50427/study/produto/cadastrarproduto",
            data: {
                Nome: this.state.nome,
                Preco: this.state.preco,
                Quantidade: this.state.quantidade
            },
            success: function (d) {
                this.setState({
                    nome: '',
                    preco: 0,
                    quantidade: 0,
                    mensagem: d
                });
            }.bind(this),
            error: function (e) {
                this.setState({ mensagem: "Erro: " + e.status });
            }.bind(this)
        });
    },


    render: function () {
        return (
            <form method="post" onSubmit={this.cadastrarProduto}>

                <label>Nome do Produto:</label>
                <input type="text" className="form-control"
                    placeholder="Informe o nome"
                    onChange={this.lerNome}
                    value={this.state.nome}
                />

                <br />

                <label>Preço:</label>
                <input type="text" className="form-control"
                    placeholder="Informe o preço"
                    onChange={this.lerPreco}
                    value={this.state.preco}
                />

                <br />

                <label>Quantidade:</label>
                <input type="text" className="form-control"
                    placeholder="Informe a quantidade"
                    onChange={this.lerQuantidade}
                    value={this.state.quantidade}
                />

                <br />

                <button type="submit"
                    className="btn btn-success">
                    Cadastrar Produto
                </button>
                <br />
                <br />

                <div>{this.state.mensagem}</div>

            </form>
        )
    }
});

module.exports = Cadastro;
