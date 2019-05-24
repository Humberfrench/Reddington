var Usuario = new Object();

Usuario.URLObterTodos = '';
Usuario.URLFiltrar = '';
Usuario.URLEdit = '';
Usuario.URLGravar = '';
Usuario.URLExcluir = '';
Usuario.URLObterUsuarioViaAD = '';


$(document).ready(function ()
{
    Usuario.MontarTabela();
    Usuario.URLObterTodos = $("#URLObterTodos").val();
    Usuario.URLFiltrar = $("#URLFiltrar").val();
    Usuario.URLEdit = $("#URLEdit").val();
    Usuario.URLGravar = $("#URLGravar").val();
    Usuario.URLExcluir = $("#URLExcluir").val();
    Usuario.URLObterUsuarioViaAD = $("#URLObterUsuarioViaAD").val();

    $("#Pesquisar").click(function ()
    {
        var situacao = $("#Situacao").val();
        var nome = $("#PesquisarNome").val();

        Usuario.Pesquisar(situacao,nome);
    });

    $("#Gravar").click(function ()
    {
        Usuario.Gravar();
    });

    $("#ValidarUsuarioAD").click(function ()
    {
        var login = $("#LoginAD").val();
        Usuario.ObterUsuarioViaAD(login);
    });

    $("#Novo").click(function ()
    {
        Usuario.LimparForm();
        $("#modalEdicao").modal('show');
    });


});

function ExcluirConfirmar(codigo, nome, login)
{
    $("#spnCodigo").html(codigo);
    $("#spnNome").html(nome);
    $("#spnLogin").html(login);
    $("#codigoExclusao").val(codigo);
    $("#modalExclusao").modal('show');

}

function Excluir()
{
    if ($("#codigoExclusao").val() === '')
    {
        return false;
    }

    Usuario.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Usuario.LimparForm();
    Usuario.Edit(id);
    $("#modalEdicao").modal('show');
}

Usuario.MontarTabela = function ()
{
    $('#TableUsuario').DataTable({
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
            { "aTargets": [4], "bSortable": true },
            { "aTargets": [5], "bSortable": true },
            { "aTargets": [6], "bSortable": false }
    ]    });
}

Usuario.Pesquisar = function (situacao,nome)
{
    location.href = Usuario.URLFiltrar + '/' + situacao + '/' + nome;
}

Usuario.PesquisarTodos = function ()
{
    location.href = Usuario.URLObterTodos;
}

Usuario.LimparForm = function ()
{
    $("#UsuarioId").val('0');
    $("#Nome").val('');
    $("#LoginAD").val('');
    $("#Dominio").val('');
    $("#Perfil").val('-1');
    $("#Status").val('1');
    $("#Status").prop('disabled', 'disabled');
    $("#ValidarUsuarioAD").prop('disabled', '');
}

Usuario.Edit = function (codigo)
{

    $.get(Usuario.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {
        var dataObj = eval(response);
        $("#UsuarioId").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#LoginAD").val(dataObj.LoginAD);
        $("#Dominio").val(dataObj.Dominio);
        $("#Perfil").val(dataObj.PerfilId);
        $("#Status").prop('disabled', '');
        $("#Status").val('0');
        $("#ValidarUsuarioAD").prop('disabled', 'disabled');
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

Usuario.ObterUsuarioViaAD = function (login)
{

    $.get(Usuario.URLObterUsuarioViaAD,
    {
        login: login
    })
    .done(function (response)
    {
        var dataObj = eval(response);
        $("#UsuarioId").val(0);
        $("#Nome").val(dataObj.Nome);
        $("#LoginAD").val(dataObj.LoginAD);
        $("#Dominio").val(dataObj.Dominio);
        $("#PerfilId").val(dataObj.Perfil);
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

Usuario.Gravar = function ()
{
    if (Usuario.Consistir())
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

        var usuario = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        usuario.UsuarioId = $("#UsuarioId").val();
        usuario.Nome = $("#Nome").val();
        usuario.LoginAD = $("#LoginAD").val();
        usuario.Dominio = $("#Dominio").val();
        usuario.PerfilId = $("#Perfil").val();
        usuario.Status = status;
        usuario.GrupoManutecaoEmpresaAplicacaos = null;
        usuario.GrupoManutecaoUsuarios = null;

        $.ajax({
            type: 'POST',
            url: Usuario.URLGravar,
            dataType: 'json',
            cache: 'false',
            headers: headers,
            contentType: 'application/json; charset=utf-8',
            async: false,
            data: JSON.stringify(usuario),
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
                    Usuario.LimparForm();
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

Usuario.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: Usuario.URLExcluir,
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
                Usuario.LimparForm();
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

Usuario.Consistir = function ()
{
    var mensagemErro = '';

    if ($("#Nome").val() === '')
    {
        mensagemErro = mensagemErro + ' - O Campo Nome é Obrigatório<br />';
    }

    if ($("#LoginAD").val() === '')
    {
        mensagemErro = mensagemErro + ' - O Campo Login do A.D. é Obrigatório<br />';
    }

    if ($("#Dominio").val() === '')
    {
        mensagemErro = mensagemErro + ' - O Campo Dominio é Obrigatório<br />';
    }

    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }

    return true;

}


