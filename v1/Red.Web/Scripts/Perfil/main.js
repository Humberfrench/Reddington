var Perfil = new Object();

Perfil.URLObterTodos = '';
Perfil.URLFiltrar = '';
Perfil.URLEdit = '';
Perfil.URLGravar = '';
Perfil.URLExcluir = '';


$(document).ready(function ()
{
    Perfil.MontarTabela();
    Perfil.URLObterTodos = $("#URLObterTodos").val();
    Perfil.URLFiltrar = $("#URLFiltrar").val();
    Perfil.URLEdit = $("#URLEdit").val();
    Perfil.URLGravar = $("#URLGravar").val();
    Perfil.URLExcluir = $("#URLExcluir").val();

    $("#Pesquisar").click(function ()
    {
        var situacao = $("#Situacao").val();
        var nome = $("#PesquisarNome").val();

        Perfil.Pesquisar(situacao,nome);
    });

    $("#Gravar").click(function ()
    {
        Perfil.Gravar();
    });

    $("#Novo").click(function ()
    {
        Perfil.LimparForm();
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

    Perfil.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Perfil.LimparForm();
    Perfil.Edit(id);
    $("#modalEdicao").modal('show');
}

Perfil.MontarTabela = function ()
{
    $('#TablePerfil').DataTable({
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

Perfil.Pesquisar = function (situacao,nome)
{
    location.href = Perfil.URLFiltrar + situacao + '/' + nome;
}

Perfil.PesquisarTodos = function ()
{
    location.href = Perfil.URLObterTodos;
}

Perfil.LimparForm = function ()
{
    $("#PerfilId").val('0');
    $("#Nome").val('');
    $("#Descricao").val('');
    $("#Status").val('1');
    $("#Status").prop('disabled', 'disabled');
}

Perfil.Edit = function (codigo)
{

    $.get(Perfil.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {
        var dataObj = eval(response);
        $("#PerfilId").val(codigo);
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

Perfil.Gravar = function ()
{
    if (Perfil.Consistir())
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

        var perfil = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        perfil.PerfilId = $("#PerfilId").val();
        perfil.Nome = $("#Nome").val();
        perfil.Descricao = $("#Descricao").val();
        perfil.Status = status;
        perfil.GrupoManutecaoEmpresaAplicacaos = null;
        perfil.GrupoManutecaoUsuarios = null;

        $.ajax({
            type: 'POST',
            url: Perfil.URLGravar,
            dataType: 'json',
            headers: headers,
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            async: false,
            data:  JSON.stringify(perfil),
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
                    Perfil.LimparForm();
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

Perfil.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: Perfil.URLExcluir,
        dataType: 'json',
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        async: false,
        data: JSON.stringify({ "id": codigo }),
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
                Perfil.LimparForm();
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

Perfil.Consistir = function (nome)
{
    var mensagemErro = '';
    if (nome === '')
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

