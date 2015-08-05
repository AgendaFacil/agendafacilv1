$(function() {

    $('#side-menu').metisMenu();

});

$(function() {
    $(window).bind("load resize", function() {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    var element = $('ul.nav a').filter(function() {
        return this.href == url || url.href.indexOf(this.href) == 0;
    }).addClass('active').parent().parent().addClass('in').parent();
    if (element.is('li')) {
        element.addClass('active');
    }
});

function PesquisarCliente() {
    var Nome = document.getElementById('txtBusca').value;

    var url = "/Cliente/Pesquisar";
    var cliente = { Nome: Nome };
    var json = JSON.stringify(cliente);
    var request = new XMLHttpRequest();

    request.open("Post", url, false);
    request.setRequestHeader("Content-Type", "application/json");
    request.send(json);

    var resposta = request.responseText;
    var lista = JSON.parse(resposta);
    var table = document.getElementById('tabelaCliente');

    var tbody = table.children[0];

    while (tbody.children.length > 1)
        tbody.removeChild(tbody.children[1]);

    for (var i = 0; i < lista.length; i++)
    {
        var NOME = lista[i].NOME;
        var TELEFONE = lista[i].TELEFONE;
        var EMAIL = lista[i].EMAIL;

        var tr = document.createElement("tr");
        var tdNome = document.createElement("td");
        var tdTelefone = document.createElement("td");
        var tdEmail = document.createElement("td");
        var tdBotoes = document.createElement("td");

        var btnEditar = document.createElement("a");
        var btnDetalhes = document.createElement("a");
        var btnBloquear = document.createElement("a");

        var textNodeNome = document.createTextNode(NOME);
        var textNodeTelefone = document.createTextNode(TELEFONE);
        var textNodeEmail = document.createTextNode(EMAIL);

        var textNodeEditar = document.createTextNode("Editar");
        var textNodeDetalhes = document.createTextNode("Detalhes");
        var textNodeBloquear = document.createTextNode("Bloquear");

        tdNome.appendChild(textNodeNome);
        tdTelefone.appendChild(textNodeTelefone);
        tdEmail.appendChild(textNodeEmail);

        btnEditar.appendChild(textNodeEditar);
        btnDetalhes.appendChild(textNodeDetalhes);
        btnBloquear.appendChild(textNodeBloquear);

        tr.appendChild(tdNome);
        tr.appendChild(tdTelefone);
        tr.appendChild(tdEmail);

        btnEditar.href = "/Cliente/Editar?id="+encodeURI(lista[i].ID_CLIENTE);
        btnDetalhes.href = "/Cliente/Detalhes?id="+encodeURI(lista[i].ID_CLIENTE);
        btnBloquear.href = "/Cliente/Bloquear?id="+encodeURI(lista[i].ID_CLIENTE);
        
        btnEditar.className = "btn btn-success btn-xs";
        btnDetalhes.className = "btn btn-warning btn-xs";
        btnBloquear.className = "btn btn-danger btn-xs";

        var textNode = document.createTextNode(" ");
        var textNode2 = document.createTextNode(" ");

        tdBotoes.appendChild(btnEditar);
        tdBotoes.appendChild(textNode);
        tdBotoes.appendChild(btnDetalhes);
        tdBotoes.appendChild(textNode2);
        tdBotoes.appendChild(btnBloquear);

        tr.appendChild(tdBotoes);

        tbody.appendChild(tr);
        
    }
}

function PesquisarProfissional() {
    var Nome = document.getElementById('txtBusca').value;

    var url = "/Profissional/Pesquisar";
    var profissional = { Nome: Nome };
    var json = JSON.stringify(profissional);
    var request = new XMLHttpRequest();

    request.open("Post", url, false);
    request.setRequestHeader("Content-Type", "application/json");
    request.send(json);

    var resposta = request.responseText;
    var lista = JSON.parse(resposta);
    var table = document.getElementById('tabelaProfissional');

    var tbody = table.children[0];

    while (tbody.children.length > 1)
        tbody.removeChild(tbody.children[1]);

    for (var i = 0; i < lista.length; i++) {
        var NOME = lista[i].NOME;
        var TELEFONE = lista[i].TELEFONE;
        var EMAIL = lista[i].EMAIL;

        var tr = document.createElement("tr");
        var tdNome = document.createElement("td");
        var tdTelefone = document.createElement("td");
        var tdEmail = document.createElement("td");
        var tdBotoes = document.createElement("td");

        var btnEditar = document.createElement("a");
        var btnDetalhes = document.createElement("a");
        var btnBloquear = document.createElement("a");

        var textNodeNome = document.createTextNode(NOME);
        var textNodeTelefone = document.createTextNode(TELEFONE);
        var textNodeEmail = document.createTextNode(EMAIL);

        var textNodeEditar = document.createTextNode("Editar");
        var textNodeDetalhes = document.createTextNode("Detalhes");
        var textNodeBloquear = document.createTextNode("Bloquear");

        tdNome.appendChild(textNodeNome);
        tdTelefone.appendChild(textNodeTelefone);
        tdEmail.appendChild(textNodeEmail);

        btnEditar.appendChild(textNodeEditar);
        btnDetalhes.appendChild(textNodeDetalhes);
        btnBloquear.appendChild(textNodeBloquear);

        tr.appendChild(tdNome);
        tr.appendChild(tdTelefone);
        tr.appendChild(tdEmail);

        btnEditar.href = "/Profissional/Editar?id=" + encodeURI(lista[i].ID_PROFISSIONAL);
        btnDetalhes.href = "/Profissional/Detalhes?id=" + encodeURI(lista[i].ID_PROFISSIONAL);
        btnBloquear.href = "/Profissional/Bloquear?id=" + encodeURI(lista[i].ID_PROFISSIONAL);

        btnEditar.className = "btn btn-success btn-xs";
        btnDetalhes.className = "btn btn-warning btn-xs";
        btnBloquear.className = "btn btn-danger btn-xs";

        var textNode = document.createTextNode(" ");
        var textNode2 = document.createTextNode(" ");

        tdBotoes.appendChild(btnEditar);
        tdBotoes.appendChild(textNode);
        tdBotoes.appendChild(btnDetalhes);
        tdBotoes.appendChild(textNode2);
        tdBotoes.appendChild(btnBloquear);

        tr.appendChild(tdBotoes);

        tbody.appendChild(tr);

    }
}

function PesquisarTratamento() {
    var Nome = document.getElementById('txtBusca').value;

    var url = "/Tratamento/Pesquisar";
    var profissional = { Nome: Nome };
    var json = JSON.stringify(profissional);
    var request = new XMLHttpRequest();

    request.open("Post", url, false);
    request.setRequestHeader("Content-Type", "application/json");
    request.send(json);

    var resposta = request.responseText;
    var lista = JSON.parse(resposta);
    var table = document.getElementById('tabelaTratamento');

    var tbody = table.children[0];

    while (tbody.children.length > 1)
        tbody.removeChild(tbody.children[1]);

    for (var i = 0; i < lista.length; i++) {
        var NOME = lista[i].PROFISSIONAL.NOME;
        var DESCRICAO = lista[i].DESCRICAO;

        var tr = document.createElement("tr");
        var tdNome = document.createElement("td");
        var tdDescricao = document.createElement("td");

        var btnEditar = document.createElement("a");
        var btnDetalhes = document.createElement("a");
        var btnBloquear = document.createElement("a");

        var textNodeNome = document.createTextNode(PROFISSIONAL.NOME);
        var textNodeDescricao = document.createTextNode(DESCRICAO);

        var textNodeEditar = document.createTextNode("Editar");
        var textNodeDetalhes = document.createTextNode("Detalhes");
        var textNodeBloquear = document.createTextNode("Bloquear");

        tdNome.appendChild(textNodeNome);
        tdDescricao.appendChild(textNodeDescricao);

        btnEditar.appendChild(textNodeEditar);
        btnDetalhes.appendChild(textNodeDetalhes);
        btnBloquear.appendChild(textNodeBloquear);

        tr.appendChild(tdNome);
        tr.appendChild(tdDescricao);

        btnEditar.href = "/Tratamento/Editar?id=" + encodeURI(lista[i].ID_TRATAMENTO);
        btnDetalhes.href = "/Tratamento/Detalhes?id=" + encodeURI(lista[i].ID_TRATAMENTO);
        btnBloquear.href = "/Tratamento/Bloquear?id=" + encodeURI(lista[i].ID_TRATAMENTO);

        btnEditar.className = "btn btn-success btn-xs";
        btnDetalhes.className = "btn btn-warning btn-xs";
        btnBloquear.className = "btn btn-danger btn-xs";

        var textNode = document.createTextNode(" ");
        var textNode2 = document.createTextNode(" ");

        tdBotoes.appendChild(btnEditar);
        tdBotoes.appendChild(textNode);
        tdBotoes.appendChild(btnDetalhes);
        tdBotoes.appendChild(textNode2);
        tdBotoes.appendChild(btnBloquear);

        tr.appendChild(tdBotoes);

        tbody.appendChild(tr);

    }
}
