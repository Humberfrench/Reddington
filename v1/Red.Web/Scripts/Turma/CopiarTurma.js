var TurmaAlunos = new Object;

$(function ()
{
    //carregar dados
    $("#Pesquisar").click(function ()
    {
        var ano = $("#Ano").val();
        var evangelizdor = $("#Evangelizador").val();
        TurmaAlunos.Obter(evangelizdor, ano);
    });

    $("#Gravar").click(function ()
    {
        var ano = $("#AnoNovo").val();
        var turma = $("#TurmaId").val();
        var nome = $("#Descricao").val();
        TurmaAlunos.Copiar(turma, ano, nome);
    });

});

TurmaAlunos.Obter = function(evangelizador, ano)
{
    var url = '/Turma/ObterTurma/';
    var dadoEnvio = new Object;
    var callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        $("#DescricaoAtual").val(dataObj.NomeSala);
        $("#TurmaId").val(dataObj.Codigo);
    };

    dadoEnvio.idEvangelizador = evangelizador;
    dadoEnvio.ano = ano;

    Ajax.Get(url, dadoEnvio, callBackSuccess);
}

TurmaAlunos.Copiar = function(turma, ano, nome)
{
    var url = '/Turma/ExecutaCopia/';
    var dadoEnvio = new Object;
    var callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            Mensagens.Erro(dataObj.Mensagem);
        }
        else
        {
            Mensagens.Sucesso(dataObj.Mensagem);
        }
    };

    dadoEnvio.turma = turma;
    dadoEnvio.ano = ano;
    dadoEnvio.nome = nome;

    Ajax.Post(url, dadoEnvio, callBackSuccess);
}

TurmaAlunos.ConfigDataTable =
    {
        "searching": false,
        "autoWidth": false,
        "lengthMenu": [[10, 25, 50], [10, 25, 50]],
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
        "dom": 'rt<"bottom"p>',
        "pagingType": "numbers",
        "aoColumnDefs": [
            { "aTargets": [0], "aSorting": ["asc"], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": true }
            ]
    }

