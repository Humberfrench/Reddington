/// <reference path="../plugins/fullcalendar/moment.min.js" />
/// <reference path="../util/mensagens.js" />
var Responsavel = new Object();

Responsavel.URLObterTodos = '';
Responsavel.URLFiltrar = '/Responsavel/Filtrar';
Responsavel.URLEdit = '';
Responsavel.URLGravar = '';
Responsavel.URLExcluir = '';
Responsavel.URLAutoComplete = '';

$(document).ready(function ()
{
    Responsavel.MontarTabela();
    Responsavel.URLObterTodos = $("#URLObterTodos").val();
    Responsavel.URLFiltrar = '/Responsavel/Filtrar';
    Responsavel.URLEdit = $("#URLEdit").val();
    Responsavel.URLGravar = $("#URLGravar").val();
    Responsavel.URLExcluir = $("#URLExcluir").val();
    Responsavel.URLAutoComplete = $("#URLAutoComplete").val();          

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();

        Responsavel.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Responsavel.Gravar();
    });

    $("#Novo").click(function ()
    {
        Responsavel.LimparForm();
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

    Responsavel.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Responsavel.LimparForm();
    Responsavel.Edit(id);
    $("#modalEdicao").modal('show');
}

Responsavel.MontarTabela = function ()
{
    $('#TableResponsavel').DataTable({
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

Responsavel.Pesquisar = function (nome)
{
    location.href = Responsavel.URLFiltrar + '/' + nome;
}

Responsavel.PesquisarTodos = function ()
{
    location.href = Responsavel.URLObterTodos;
}

Responsavel.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Responsavel1").val('');
    $("#Responsavel2").val('');
    $("#Documento").val('');
    $("#Telefone").val('');
    $("#Celular1").val('');
    $("#Celular2").val('');
    $("#Endereco").val('');
    $("#Cep").val('');
    $("#Bairro").val('');
    $("#Cidade").val('');
    $("#UF").val('');

}

Responsavel.Edit = function (codigo)
{
    Responsavel.LimparForm();

    $.get(Responsavel.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {
        var dataObj = eval(response);

        $("#Codigo").val(codigo);
        $("#Responsavel1").val(dataObj.Responsavel1);
        $("#Responsavel2").val(dataObj.Responsavel2);
        $("#Documento").val(dataObj.Documento);
        $("#Telefone").val(dataObj.Telefone);
        $("#Celular1").val(dataObj.Celular1);
        $("#Celular2").val(dataObj.Celular2);
        $("#Endereco").val(dataObj.Endereco);
        $("#Cep").val(dataObj.Cep);
        $("#Bairro").val(dataObj.Bairro);
        $("#Cidade").val(dataObj.Cidade);
        $("#UF").val(dataObj.Uf);

    })
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error);
    });

}

Responsavel.Gravar = function ()
{
    if (Responsavel.Consistir())
    {
        var responsavel = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        responsavel.Codigo = $("#Codigo").val();
        responsavel.Responsavel1 = $("#Responsavel1").val();
        responsavel.Responsavel2 = $("#Responsavel2").val();
        responsavel.Documento = $("#Documento").val();
        responsavel.Telefone = $("#Telefone").val();
        responsavel.Celular1 = $("#Celular1").val();
        responsavel.Celular2 = $("#Celular2").val();
        responsavel.Endereco = $("#Endereco").val();
        responsavel.Cep = $("#Cep").val();
        responsavel.Bairro = $("#Bairro").val();
        responsavel.Cidade = $("#Cidade").val();
        responsavel.UF = $("#UF").val();

        $.ajax({
            type: 'POST',
            url: Responsavel.URLGravar,
            dataType: 'json',
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            headers: headers,
            async: false,
            data: JSON.stringify(responsavel),
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
                    Responsavel.LimparForm();
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

Responsavel.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: Responsavel.URLExcluir,
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
                Responsavel.LimparForm();
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

Responsavel.Consistir = function ()
{
    var mensagemErro = '';
    if ($("#Responsavel1").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Nome do Primeiro Responsável é Obrigatório <br />';
    }
    if ($("#Celular1").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Celular é Obrigatório <br />';
    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


