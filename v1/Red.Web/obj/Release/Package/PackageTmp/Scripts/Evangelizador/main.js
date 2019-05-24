/// <reference path="../util/mensagens.js" />
var Evangelizador = new Object();

Evangelizador.URLObterTodos = '';
Evangelizador.URLFiltrar = '';
Evangelizador.URLEdit = '';
Evangelizador.URLGravar = '';
Evangelizador.URLExcluir = '';
Evangelizador.URLAutoComplete = '';

$(document).ready(function ()
{
    Evangelizador.MontarTabela();
    Evangelizador.URLObterTodos = $("#URLObterTodos").val();
    Evangelizador.URLFiltrar = $("#URLFiltrar").val();
    Evangelizador.URLEdit = $("#URLEdit").val();
    Evangelizador.URLGravar = $("#URLGravar").val();
    Evangelizador.URLExcluir = $("#URLExcluir").val();
    Evangelizador.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var situacao = $("#PesquisarSituacao").val();
        var nome = $("#PesquisarNome").val();

        Evangelizador.Pesquisar(situacao,nome);
    });

    $("#Gravar").click(function ()
    {
        Evangelizador.Gravar();
    });

    $("#Novo").click(function ()
    {
        Evangelizador.LimparForm();
        $("#modalEdicao").modal('show');
    });

});

function ExcluirConfirmar(codigo, nome)
{
    $("#spnCodigo").html(codigo);
    $("#spnNome").html(nome);
    $("#codigoExclusao").val(codigo);
    $("#modalExclusao").modal('show');
}

function Excluir()
{
    if ($("#codigoExclusao").val() === '')
    {
        return false;
    }

    Evangelizador.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Evangelizador.LimparForm();
    Evangelizador.Edit(id);
    $("#modalEdicao").modal('show');
}

Evangelizador.MontarTabela = function ()
{
    $('#TableEvangelizador').DataTable({
        "searching": false,
        "autoWidth": false,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "<div class='col-xs-12 tabela-contas no-pad'>Nenhum registro encontrado</div>",
            "sSearchPlaceholder": "Busque pelo nome da empresa, agencia e conta, CNPJ ou apelido."
        },
        "classes": {
            "sFilterInput": "form-control campo-busca",
            "sInfo": "num-pag col-xs-12 text-right no-pad hidden-xs",
            "sEmptyTable": "num-pag col-xs-12 text-right no-pad hidden-xs",
            "sPaging": "text-center",
            "sPageButtonActive": "active"
        },
        "dom": '<"top"li>rt<"bottom"p><"clear">',
        "pagingType": "numbers",
        "aoColumnDefs": [
            { "aTargets": [0], "asSorting": ["asc"], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": false }
    ]    });
}

Evangelizador.Pesquisar = function (situacao,nome)
{
    location.href = Evangelizador.URLFiltrar + '/' + situacao + '/' + nome;
}

Evangelizador.PesquisarTodos = function ()
{
    location.href = Evangelizador.URLObterTodos;
}

Evangelizador.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#Contato").val('');
    $("#EMail").val('');
}

Evangelizador.Edit = function (codigo)
{

    $.get(Evangelizador.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {                                        
        var dataObj = eval(response);
        $("#Codigo").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#Contato").val(dataObj.Contato);
        $("#EMail").val(dataObj.Email);
    })
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error);
    });

}

Evangelizador.Gravar = function ()
{
    if (Evangelizador.Consistir())
    {
        var evangelizador = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        evangelizador.Codigo = $("#Codigo").val();
        evangelizador.Nome = $("#Nome").val();
        evangelizador.Contato = $("#Contato").val();
        evangelizador.EMail = $("#EMail").val();

        $.ajax({
            type: 'POST',
            url: Evangelizador.URLGravar,
            dataType: 'json',
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            headers: headers,
            async: false,
            data: JSON.stringify(evangelizador),
            success: function (data, textStatus, xhr)
            {
                var dataObj = eval(data);
                if (dataObj.Erro)
                {
                    Mensagens.Erro(dataObj.Mensagem);
                }
                else
                {
                    Mensagens.Sucesso(dataObj.Mensagem);
                    Evangelizador.LimparForm();
                    $("#modalEdicao").modal('hide');
                    location.reload();
                }
            },
            error: function (xhr, msg, e)
            {
                Mensagens.Erro(e);
            }
        });

    }
}

Evangelizador.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: Evangelizador.URLExcluir,
        dataType: 'json',
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        async: false,
        data: JSON.stringify({"id" : codigo }) ,
        success: function (data, textStatus, xhr)
        {
            var dataObj = eval(data);
            if (dataObj.Erro)
            {
                Mensagens.Erro(dataObj.Mensagem);
            }
            else
            {
                Mensagens.Sucesso(dataObj.Mensagem);
                Evangelizador.LimparForm();
                $("#modalEdicao").modal('hide');
                location.reload();
            }
        },
        error: function (xhr, msg, e)
        {
            Mensagens.Erro(e);
        }
    });
}

Evangelizador.Consistir = function ()
{
    var mensagemErro = '';
    if ($("#Nome").val() === '')
    {
        mensagemErro = 'O Campo Nome é Obrigatório';
    }
    if ($("#Contato").val() === '')
    {
        mensagemErro = 'O Campo Contato é Obrigatório';
    }
    if ($("#EMail").val() === '')
    {
        mensagemErro = 'O Campo E-Mail é Obrigatório';
    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


