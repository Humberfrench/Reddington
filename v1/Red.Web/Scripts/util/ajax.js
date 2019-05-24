var Ajax = new Object;

Ajax.ExecutePost = function (url, dadoEnvio, callBackSucess)
{

    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        data: dadoEnvio,
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: callBackSucess,
        error: function (xhr, msg, e)
        {
            // stuff
            Mensagens.Erro(e, "Erro");
        }
    });

}

Ajax.ExecuteGet = function (url, dadoEnvio, callBackSucess)
{

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        data: dadoEnvio,
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: callBackSucess,
        error: function (xhr, msg, e)
        {
            // stuff
            Mensagens.Erro(e, "Erro");
        }
    });

}

Ajax.Get = function (url, dadoEnvio, callBackSucess)
{
    $.get(url, dadoEnvio)
    .done(callBackSucess)
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error, "Erro");
    });
}

Ajax.Post = function (url, dadoEnvio, callBackSucess)
{
    $.post(url, dadoEnvio)
    .done(callBackSucess)
    .fail(function (jqxhr, textStatus, error)
    {
        Mensagens.Erro(error, "Erro");
    });
}