/// <reference path="../plugins/fullcalendar/moment.min.js" />
/// <reference path="../util/mensagens.js" />
var Aluno = new Object();

Aluno.URLObterTodos = '';
Aluno.URLFiltrar = '/Aluno/Filtrar';
Aluno.URLEdit = '';
Aluno.URLGravar = '';
Aluno.URLExcluir = '';
Aluno.URLAutoComplete = '';

$(document).ready(function ()
{
    Aluno.MontarTabela();
    Aluno.URLObterTodos = $("#URLObterTodos").val();
    Aluno.URLFiltrar = '/Aluno/Filtrar';
    Aluno.URLEdit = $("#URLEdit").val();
    Aluno.URLGravar = $("#URLGravar").val();
    Aluno.URLExcluir = $("#URLExcluir").val();
    Aluno.URLAutoComplete = $("#URLAutoComplete").val();

    $("#DataNascimento").datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });
    $("#DataNascimento").datepicker('update');


    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();

        Aluno.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Aluno.Gravar();
    });

    $("#Novo").click(function ()
    {
        Aluno.LimparForm();
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

    Aluno.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Aluno.LimparForm();
    Aluno.Edit(id);
    $("#modalEdicao").modal('show');
}

Aluno.MontarTabela = function ()
{
    $('#TableAluno').DataTable({
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

Aluno.Pesquisar = function (nome)
{
    location.href = Aluno.URLFiltrar + '/' + nome;
}

Aluno.PesquisarTodos = function ()
{
    location.href = Aluno.URLObterTodos;
}

Aluno.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#DataNascimento").val('');
    $("#Matriculado").prop('checked','');
    $("#GrupoDeJovens").prop('checked', '');
    $("#status").val('-1');
    $("#Responsavel").val('-1');
}

Aluno.Edit = function (codigo)
{
    Aluno.LimparForm();

    $.get(Aluno.URLEdit,
    {
        id: codigo
    })
    .done(function (response)
    {
        var dataObj = eval(response);
        var dtNasc = moment(dataObj.DataNascimento.toString());
        var matriculado = dataObj.Matriculado ? 'checked' : '';
        var grupoDeJovens = dataObj.GrupodeJovens ? 'checked' : '';

        dtNasc.format("DD/MM/YYYY") ;
        $("#Codigo").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#DataNascimento").datepicker('setDate', dtNasc.format("DD/MM/YYYY"));
        $("#DataNascimento").datepicker('update');
        $("#Matriculado").prop('checked', matriculado);
        $("#GrupoDeJovens").prop('checked', grupoDeJovens);
        $("#Responsavel").val(dataObj.ResponsavelId);
        $("#Status").val(dataObj.StatusId);

    })
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error);
    });

}

Aluno.Gravar = function ()
{
    if (Aluno.Consistir())
    {
        var aluno = new Object();
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};

        headers['__RequestVerificationToken'] = token;

        aluno.Codigo = $("#Codigo").val();
        aluno.Nome = $("#Nome").val();
        aluno.ResponsavelId = $("#Responsavel").val();
        aluno.DataNascimento = $("#DataNascimento").val();
        aluno.Matriculado = $("#Matriculado").val();

        aluno.Matriculado = false;
        aluno.GrupoDeJovens = false;

        if ($("#Matriculado").prop('checked') === true)
        {
            aluno.Matriculado = true;
        }
        if ($("#GrupoDeJovens").prop('checked') === true)
        {
            aluno.GrupoDeJovens = true;
        }

        aluno.StatusId = $("#Status").val();

        $.ajax({
            type: 'POST',
            url: Aluno.URLGravar,
            dataType: 'json',
            cache: 'false',
            contentType: 'application/json; charset=utf-8',
            headers: headers,
            async: false,
            data: JSON.stringify(aluno),
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
                    Aluno.LimparForm();
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

Aluno.Excluir = function (codigo)
{
    $.ajax({
        type: 'POST',
        url: Aluno.URLExcluir,
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
                Aluno.LimparForm();
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

Aluno.Consistir = function (nome)
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


