/// <reference path="../util/mensagens.js" />
var AtividadePreferida = new Object();

AtividadePreferida.URLObterTodos = '';
AtividadePreferida.URLFiltrar = '';
AtividadePreferida.URLEdit = '';
AtividadePreferida.URLGravar = '';
AtividadePreferida.URLExcluir = '';
AtividadePreferida.URLAutoComplete = '';

$(document).ready(function ()
{
    AtividadePreferida.MontarTabela();
    AtividadePreferida.URLObterTodos = $("#URLObterTodos").val();
    AtividadePreferida.URLFiltrar = $("#URLFiltrar").val();
    AtividadePreferida.URLEdit = $("#URLEdit").val();
    AtividadePreferida.URLGravar = $("#URLGravar").val();
    AtividadePreferida.URLExcluir = $("#URLExcluir").val();
    AtividadePreferida.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var situacao = $("#PesquisarSituacao").val();
        var nome = $("#PesquisarNome").val();

        AtividadePreferida.Pesquisar(situacao,nome);
    });

    $("#Gravar").click(function ()
    {
        AtividadePreferida.Gravar();
    });

    $("#Novo").click(function ()
    {
        AtividadePreferida.LimparForm();
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

    AtividadePreferida.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    AtividadePreferida.LimparForm();
    AtividadePreferida.Edit(id);
    $("#modalEdicao").modal('show');
}

AtividadePreferida.MontarTabela = function ()
{
    $('#TableAtividadePreferida').DataTable({
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

AtividadePreferida.Pesquisar = function (situacao,nome)
{
    location.href = AtividadePreferida.URLFiltrar + '/' + situacao + '/' + nome;
}

AtividadePreferida.PesquisarTodos = function ()
{
    location.href = AtividadePreferida.URLObterTodos;
}

AtividadePreferida.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
}

AtividadePreferida.Edit = function (codigo)
{

    $.get(AtividadePreferida.URLEdit,
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

AtividadePreferida.Gravar = function ()
{
    if (AtividadePreferida.Consistir())
    {
        var caracterstica = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        atividadePreferida.Codigo = $("#Codigo").val();
        atividadePreferida.Descricao = $("#Descricao").val();
     
        $.ajax({
            type: 'POST',
            url: AtividadePreferida.URLGravar,
            dataType: 'json',
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            headers: headers,
            async: false,
            data: JSON.stringify(atividadePreferida),
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
                    AtividadePreferida.LimparForm();
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

AtividadePreferida.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: AtividadePreferida.URLExcluir,
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
                AtividadePreferida.LimparForm();
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

AtividadePreferida.Consistir = function (nome)
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


