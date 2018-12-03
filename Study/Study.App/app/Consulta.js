var React = require('react');
var CreateReactClass = require('create-react-class');

var Consulta = CreateReactClass({

    getInitialState: function () {
        return {
            nome: '', preco: 0, quantidade: 0,
            produtos: [],
            produto: {},
            mensagem: ''
        }
    },

    consultarProdutos: function () {
        this.setState({ mensagem: "Processando consulta..." })

        $.ajax({
            type: "GET",
            url: "http://localhost:50427/study/produto/listartodosprodutos",
            data: {},
            success: function (d) {
                this.setState({
                    mensagem: '',
                    produtos: d
                });
            }
        })
    },

    obterProduto: function (id) {
        $.ajax({
            type: "GET",
            url: "http://localhost:50427/study/produto/listarprodutoporid",
            data: { "idProduto": id },
            success: function (d) {
                this.setState({
                    produto: d,
                    nome: d.Nome,
                    preco: d.Preco,
                    quantidade: d.Quantidade
                });
            }.bind(this),
            error: function (e) {
                this.setState({ mensagem: "Erro: " + e.status });
            }.bind(this)
        });
    },

    excluirProduto: function (id) {
        $.ajax({
            type: "DELETE",
            url: "http://localhost:50427/study/produto/excluirproduto?idProduto=" + id + "",
            data: {},
            success: function (d) {
                this.consultarProdutos();
                alert(d);
            }.bind(this),
            error: function (e) {
                this.setState({ mensagem: "Erro: " + e.status });
            }.bind(this)
        });
    },

    lerNome: function (e) {
        this.setState({ nome: e.target.value });
    },

    lerPreco: function (e) {
        this.setState({ preco: e.target.value });
    },

    lerQuantidade: function (e) {
        this.setState({ quantidade: e.target.value });
    },

    atualizarProduto: function () {
        $.ajax({
            type: "PUT",
            url: "http://localhost:50427/study/produto/atualizarproduto",
            data: {
                IdProduto: this.state.produto.IdProduto,
                Nome: this.state.nome,
                Preco: this.state.preco,
                Quantidade: this.state.quantidade
            },
            success: function (d) {
                this.consultarProdutos();
                alert(d);
            }.bind(this),
            error: function (e) {
                this.setState({ mensagem: "Erro: " + e.status });
            }
        });
    },

    componentDidMount: function () {
        this.consultarProdutos();
    },

    render: function () {

        var self = this;

        return (
            <div>
                <table className="table table-bordered">
                    <thead>
                        <tr>
                            <th>Código</th>
                            <th>Nome</th>
                            <th>Preço</th>
                            <th>Quantidade</th>
                            <th>Total</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            self.state.produtos.map(
                                function (p, i) {
                                    return (
                                        <tr>
                                            <td>{p.IdProduto}</td>
                                            <td>{p.Nome}</td>
                                            <td>{p.Preco}</td>
                                            <td>{p.Quantidade}</td>
                                            <td>{p.Quantidade} * {p.Preco}</td>
                                            <td>
                                                <button className="btn btn-primary btn-sm"
                                                    data-target="#janelaedicao"
                                                    data-toggle="modal"
                                                    onClick={() => self.obterProduto(p.IdProduto)}>
                                                    Atualizar
                                                </button>
                                                &nbsp;
                                                <button className="btn btn-danger btn-sm"
                                                    data-target="#janelaexclusao"
                                                    data-toggle="modal"
                                                    onClick={() => self.obterProduto(p.IdProduto)}>
                                                    Excluir
                                                </button>
                                            </td>
                                        </tr>
                                    )
                                }
                            )

                        }
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colSpan="6">Quantidade de Registros: {self.state.produtos.length}</td>
                        </tr>
                    </tfoot>
                </table>

                <div id="janelaedicao" className="modal fade">
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header bg-primary">
                                <h3 className="text-white">Atualizar Produto</h3>
                            </div>
                            <div className="modal-body">
                                <label>Nome do Produto:</label>
                            </div>
                            <input type="text"
                                className="form-control"
                                placeholder="Informe o nome"
                                onChange={self.lerNome}
                                value={self.state.nome} />

                            <br />

                            <label>Preço:</label>
                            <input type="text"
                                className="form-control"
                                placeholder="Informe o preço"
                                onChange={self.lerPreco}
                                value={self.state.preco} />

                            <br />

                            <label>Quantidade:</label>
                            <input type="text"
                                className="form-control"
                                placeholder="Informe a quantidade"
                                onChange={self.lerQuantidade}
                                value={self.state.quantidade} />

                            <br />

                            <input type="submit"
                                value="Atualizar Produto"
                                className="btn btn-primary"
                                data-dismiss="modal"
                                onClick={() => self.atualizarProduto()} />
                        </div>
                    </div>
                </div>
            </div>

            
        );
    }
});

module.exports = Consulta;