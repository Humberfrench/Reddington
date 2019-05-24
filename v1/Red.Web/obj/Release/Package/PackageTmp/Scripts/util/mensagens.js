/// <reference path="../plugins/toastr/toastr.min.js" />
/// <reference path="../toastr-configuracao.js" />
var Mensagens = function () { }

Mensagens.Erro = function (mensagem, mensagemTitulo)
{
    toastr["error"](mensagem, mensagemTitulo);
}

Mensagens.Sucesso = function (mensagem, mensagemTitulo)
{
    toastr["success"](mensagem, mensagemTitulo);
}

Mensagens.Info = function (mensagem, mensagemTitulo)
{
    toastr["info"](mensagem, mensagemTitulo);
}
