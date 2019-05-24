/// <reference path="../util/mensagens.js" />
var Caracteristica = new Object();

Caracteristica.URLObterTodos = '';
Caracteristica.URLFiltrar = '';
Caracteristica.URLEdit = '';
Caracteristica.URLGravar = '';
Caracteristica.URLExcluir = '';
Caracteristica.URLAutoComplete = '';

$(document).ready(function ()
{
    Caracteristica.MontarTabela();
    Caracteristica.URLObterTodos = $("#URLObterTodos").val();
    Caracteristica.URLFiltrar = $("#URLFiltrar").val();
    Caracteristica.URLEdit = $("#URLEdit").val();
    Caracteristica.URLGravar = $("#URLGravar").val();
    Caracteristica.URLExcluir = $("#URLExcluir").val();
    Caracteristica.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var situacao = $("#PesquisarSituacao").val();
        var nome = $("#PesquisarNome").val();

        Caracteristica.Pesquisar(situacao,nome);
    });

    $("#Gravar").click(function ()
    {
        Caracteristica.Gravar();
    });

    $("#Novo").click(function ()
    {
        Caracteristica.LimparForm();
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

    Caracteristica.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Caracteristica.LimparForm();
    Caracteristica.Edit(id);
    $("#modalEdicao").modal('show');
}

Caracteristica.MontarTabela = function ()
{
    $('#TableCaracteristica').DataTable({
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

Caracteristica.Pesquisar = function (situacao,nome)
{
    location.href = Caracteristica.URLFiltrar + '/' + situacao + '/' + nome;
}

Caracteristica.PesquisarTodos = function ()
{
    location.href = Caracteristica.URLObterTodos;
}

Caracteristica.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
}

Caracteristica.Edit = function (codigo)
{

    $.get(Caracteristica.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {
        var dataObj = eval(response);
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
    })
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error);
    });

}

Caracteristica.Gravar = function ()
{
    if (Caracteristica.Consistir())
    {
        var caracterstica = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        caracteristica.Codigo = $("#Codigo").val();
        caracteristica.Descricao = $("#Descricao").val();
     
        $.ajax({
            type: 'POST',
            url: Caracteristica.URLGravar,
            dataType: 'json',
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            headers: headers,
            async: false,
            data: JSON.stringify(caracteristica),
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
                    Caracteristica.LimparForm();
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

Caracteristica.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: Caracteristica.URLExcluir,
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
                Caracteristica.LimparForm();
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

Caracteristica.Consistir = function (nome)
{
    var mensagemErro = '';
    if(nome === '')
    {
        mensagemErro = 'O Campo Nome é Obrigatório';
    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


