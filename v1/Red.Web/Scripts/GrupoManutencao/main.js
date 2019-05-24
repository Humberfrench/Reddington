/// <reference path="../util/mensagens.js" />
var GrupoManutencao = new Object();

GrupoManutencao.URLObterTodos = '';
GrupoManutencao.URLFiltrar = '';
GrupoManutencao.URLEdit = '';
GrupoManutencao.URLGravar = '';
GrupoManutencao.URLExcluir = '';
GrupoManutencao.URLAutoComplete = '';

$(document).ready(function ()
{
    GrupoManutencao.MontarTabela();
    GrupoManutencao.URLObterTodos = $("#URLObterTodos").val();
    GrupoManutencao.URLFiltrar = $("#URLFiltrar").val();
    GrupoManutencao.URLEdit = $("#URLEdit").val();
    GrupoManutencao.URLGravar = $("#URLGravar").val();
    GrupoManutencao.URLExcluir = $("#URLExcluir").val();
    GrupoManutencao.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var situacao = $("#PesquisarSituacao").val();
        var nome = $("#PesquisarNome").val();

        GrupoManutencao.Pesquisar(situacao,nome);
    });

    $("#Gravar").click(function ()
    {
        GrupoManutencao.Gravar();
    });

    $("#Novo").click(function ()
    {
        GrupoManutencao.LimparForm();
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

    GrupoManutencao.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    GrupoManutencao.LimparForm();
    GrupoManutencao.Edit(id);
    $("#modalEdicao").modal('show');
}

GrupoManutencao.MontarTabela = function ()
{
    $('#TableGrupoManutencao').DataTable({
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
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": false }
    ]    });
}

GrupoManutencao.Pesquisar = function (situacao,nome)
{
    location.href = GrupoManutencao.URLFiltrar + '/' + situacao + '/' + nome;
}

GrupoManutencao.PesquisarTodos = function ()
{
    location.href = GrupoManutencao.URLObterTodos;
}

GrupoManutencao.LimparForm = function ()
{
    $("#GrupoManutencaoId").val('0');
    $("#Nome").val('');
    $("#Descricao").val('');
    $("#Status").val('1');
    $("#Status").prop('disabled', 'disabled');
}

GrupoManutencao.Edit = function (codigo)
{

    $.get(GrupoManutencao.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {
        var dataObj = eval(response);
        $("#GrupoManutencaoId").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#Descricao").val(dataObj.Descricao);
        $("#Status").prop('disabled', '');
        $("#Status").val('0');
        if (dataObj.Status === true)
        {
            $("#Status").val('1');
        }
    })
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error);
    });

}

GrupoManutencao.Gravar = function ()
{
    if (GrupoManutencao.Consistir())
    {
        var status = null;
        if ($("#Status").val() === '1')
        {
            status = true;
        }
        else if ($("#Status").val() === '0')
        {
            status = false;
        }

        var grupoManutencao = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        grupoManutencao.GrupoManutencaoId = $("#GrupoManutencaoId").val();
        grupoManutencao.Nome = $("#Nome").val();
        grupoManutencao.Descricao = $("#Descricao").val();
        grupoManutencao.Status = status;
        grupoManutencao.GrupoManutecaoEmpresaAplicacaos = null;
        grupoManutencao.GrupoManutecaoUsuarios = null;
     
        $.ajax({
            type: 'POST',
            url: GrupoManutencao.URLGravar,
            dataType: 'json',
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            headers: headers,
            async: false,
            data: JSON.stringify(grupoManutencao),
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
                    GrupoManutencao.LimparForm();
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

GrupoManutencao.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: GrupoManutencao.URLExcluir,
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
                GrupoManutencao.LimparForm();
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

GrupoManutencao.Consistir = function (nome)
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


