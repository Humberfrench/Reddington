var Turma = new Object;

$(function ()
{
    var ano = $("#Ano").val();
    var evangelizdor = $("#Evangelizador").val();
    Turma.Obter(evangelizdor, ano);

    //carregar dados
    $("#Pesquisar").click(function ()
    {
        Turma.ObterDados(true);
    });
    $("#Gravar").click(function ()
    {
        var ano = $("#Ano").val();
        var evangelizador = $("#Evangelizador").val();
        var nome = $("#Descricao").val();
        Turma.Gravar(nome, ano, evangelizador);
    });

    $("#GravarAlunosLivres").click(function ()
    {
        $('#TableAlunoLivre').DataTable().destroy();
        var checks = $('input:checkbox[name=Aluno]:checked').length;
        var turma = $("#TurmaId").val();
        var alunos = "";

        if (turma === '' || turma === '0' || turma === undefined)
        {
            Mensagens.Erro("Turma Inexistente", "Erro");
            return false;
        }
        if (checks === 0)
        {
            Mensagens.Erro("Não foi selecionado nenhuma Aplicação", "Erro");
            return false;
        }

        $("input:checkbox[name=Aluno]:checked").each(function ()
        {
            alunos = alunos + $(this).val() + ',';
        });

        alunos = alunos.substring(0, (alunos.length - 1));

        Turma.GravarAlunos(turma, alunos);
        $('#TableAlunoLivre').DataTable(Turma.ConfigDataTableAlunosLivres).draw();
    });

    $("#AdicionarAluno").click(function ()
    {
        if ($("#TurmaId").val() === '0')
        {
            Mensagens.Erro('Turma não encontrada/selecionada', 'Atenção');
            return false;
        }


        var ano = $("#Ano").val();
        Turma.AdicionarAlunoPopUp(ano);
    });
});

Turma.ObterDados = function (buscarAlunos)
{
    var ano = $("#Ano").val();
    var evangelizador = $("#Evangelizador").val();

    Turma.ObterTurma(evangelizador, ano);

    if (buscarAlunos)
    {
        Turma.Obter(evangelizador, ano);
    }
}

Turma.Obter = function (evangelizador, ano)
{
    var url = '/Turma/ObterAlunosTurma/';
    var dadoEnvio = new Object;
    var callBackSuccess = function (response)
    {

        $("#divTurmas").html(response);
        $('#TableAluno').DataTable(Turma.ConfigDataTable);

    };

    dadoEnvio.idEvangelizador = evangelizador;
    dadoEnvio.ano = ano;

    Ajax.Get(url, dadoEnvio, callBackSuccess);
}

Turma.ConfigDataTable =
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
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": false }
        ]
    }
Turma.ConfigDataTableAlunosLivres =
    {
        "searching": false,
        "autoWidth": false,
        "lengthMenu": [[6, 12, 20], [6, 12, 20]],
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
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true }
        ]
    }

Turma.AdicionarAluno = function (idEvangelizador, ano)
{
    $("#modalAlunos").modal('show');

}

Turma.AdicionarAlunoPopUp = function (ano)
{
    var url = '/Turma/ObterAlunosLivres/';
    var dadoEnvio = new Object;
    var callBackSuccess = function (response)
    {

        $("#divAlunos").html(response);
        $('#TableAlunoLivre').DataTable(Turma.ConfigDataTableAlunosLivres);
        $("#modalAlunos").modal('show');
    };

    dadoEnvio.ano = ano;

    Ajax.Get(url, dadoEnvio, callBackSuccess);

}

Turma.Gravar = function (nome, ano, evangelizador)
{
    var url = '/Turma/Gravar/';
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
            Turma.ObterDados(false);
        }
    };

    dadoEnvio.nome = nome;
    dadoEnvio.ano = ano;
    dadoEnvio.evangelizador = evangelizador;

    Ajax.Post(url, dadoEnvio, callBackSuccess);
}

Turma.ObterTurma = function (evangelizador, ano)
{
    var url = '/Turma/ObterTurma/';
    var dadoEnvio = new Object;
    var callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Codigo === 0)
        {
            Mensagens.Erro('Turma não encontrada', 'Atenção');
            $("#AdicionarAluno").prop('disabled', 'disabled');
            $("#TurmaId").val(dataObj.Codigo);
            return false;
        }
        $("#AdicionarAluno").prop('disabled', '');
        $("#Descricao").val(dataObj.NomeSala);
        $("#TurmaId").val(dataObj.Codigo);
    };

    dadoEnvio.idEvangelizador = evangelizador;
    dadoEnvio.ano = ano;

    Ajax.Get(url, dadoEnvio, callBackSuccess);
}

Turma.RemoverAluno =  function (turma, aluno)
{
    var url = '/Turma/ExcluirAluno/';
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
            location.reload();
        }
    };

    dadoEnvio.turma = turma;
    dadoEnvio.aluno = aluno;

    Ajax.Get(url, dadoEnvio, callBackSuccess);
}


Turma.GravarAlunos = function (turma, alunos)
{
    var url = '/Turma/AdicionarAlunos/';
    var dadoEnvio = new Object;
    var callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            Mensagens.Erro(dataObj.Mensagem);
            //$('#TableAlunoLivre').DataTable(Turma.ConfigDataTableAlunosLivres).draw();
        }
        else
        {
            Mensagens.Sucesso(dataObj.Mensagem);
            location.reload();
        }
    };

    dadoEnvio.turma = turma;
    dadoEnvio.alunos = alunos;

    Ajax.Post(url, dadoEnvio, callBackSuccess);

}