/*-----------------INÍCIO LITURGIA-----------------*/
const buttons = document.querySelectorAll(".btn--group button");
const contents = {
    '1ª LEITURA': document.getElementById('primeiraLeituraContent'),
    'SALMO': document.getElementById('salmoContent'),
    '2ª LEITURA': document.getElementById('segundaLeituraContent'),
    'EVANGELHO': document.getElementById('evangelhoContent'),
    'HOMILIA': document.getElementById('homiliaContent')
};

buttons.forEach(button => {
    button.addEventListener("click", function () {
        buttons.forEach(btn => btn.classList.remove("active"));
        this.classList.add("active");

        Object.values(contents).forEach(content => {
            content.style.display = 'none';
        });

        const key = this.innerText;
        if (contents[key]) {
            contents[key].style.display = 'block';
        }
    });
});

function formatarData(data) {
    const mesesAbreviados = [
        "Jan.", "Fev.", "Mar.", "Abr.", "Mai.", "Jun.",
        "Jul.", "Ago.", "Set.", "Out.", "Nov.", "Dez."
    ];

    const dataObj = new Date(data);
    const dia = String(dataObj.getDate()).padStart(2, '0');
    const mes = mesesAbreviados[dataObj.getMonth()];
    const ano = String(dataObj.getFullYear()).slice(-2);

    return `${dia} ${mes} ${ano}`;
}

function converterDiaSemana(input) {
    const regex = /(\d+ª feira)/;

    return input.replace(regex, (match) => {
        const diaNumerico = match.charAt(0);
        const diasSemana = {
            '2': 'Segunda-feira',
            '3': 'Terça-feira',
            '4': 'Quarta-feira',
            '5': 'Quinta-feira',
            '6': 'Sexta-feira',
        };

        return diasSemana[diaNumerico] || match;
    });
}

async function obterLiturgia() {
    const container = document.getElementById('liturgiaText');
    container.classList.add('poppins-regular');
    container.innerHTML = '<p>Carregando a liturgia...</p>';

    try {
        const dados = await $.getJSON("/Liturgia/GetLiturgiaAPI");
        console.log('Dados da liturgia:', dados);
        return dados;
    } catch (error) {
        console.error('Erro ao carregar a liturgia:', error);
        container.innerHTML = '<p>Erro ao carregar a liturgia.</p>';
        return null;
    }
}

$(document).ready(function () {
    preencherLiturgia();
});

async function preencherLiturgia() {
    try {
        const liturgia = await obterLiturgia();
        if (liturgia) {
            fillFormWithData(liturgia);
            atualizarCorLiturgica(liturgia.cor);
        }
    } catch (error) {
        console.error('Erro ao preencher o formulário:', error);
    }
}

function fillFormWithData(dados) {
    const fieldsMapping = {
        liturgiaData: formatarData(new Date()),
        liturgiaText: `<p>${converterDiaSemana(dados.liturgia)}</p>`,
        corLiturgia: "COR LITÚRGICA: " + dados.cor.toUpperCase(),
        primeiraLeituraReferenciaText: `<p class="poppins-regular fs-5">${dados.dia}</p><br> <p>Primeira Leitura (${dados.primeiraLeitura.referencia})</p>`,
        primeiraLeituraTituloText: `<p>${dados.primeiraLeitura.titulo}</p>`,
        primeiraLeituraTextoText: `
            <p>${dados.primeiraLeitura.texto.replace(/(\d+)(?=[a-zA-Z])/g, '$1 ').replace(/\b\d+\b/g, '<span class="poppins-medium">$& </span>')}</p>
            <p>— Palavra do Senhor.</p>
            <p class="poppins-medium">— Graças a Deus.</p>`,
        salmoReferenciaText: `<p>Responsório (${dados.salmo.referencia})</p>`,
        salmoRefraoText: `<p class="poppins-light">— ${dados.salmo.refrao}</p><p>— ${dados.salmo.refrao}</p>`,
        salmoTextoText: dados.salmo.texto
            ? `<p>${dados.salmo.texto.replace(/([—])\s*/g, '<br><br> $1 ')}.</p>`
            : `<p>Salmo não disponível.</p>`,
        segundaLeituraReferenciaText: dados.segundaLeitura?.referencia
            ? `<p>Segunda Leitura (${dados.segundaLeitura.referencia})</p>`
            : `<p class="poppins-regular-italic">Não há segunda leitura hoje!</p>`,
        segundaLeituraTituloText: dados.segundaLeitura?.titulo
            ? `<p>${dados.segundaLeitura.titulo}</p>`
            : ``,
        segundaLeituraTextoText: dados.segundaLeitura?.texto
            ? `<p>${dados.segundaLeitura.texto.replace(/(\d+)(?=[a-zA-Z])/g, '$1 ').replace(/\b\d+\b/g, '<span class="poppins-medium">$& </span>')}</p>
               <p>— Palavra do Senhor.</p>
               <p class="poppins-medium">— Graças a Deus.</p>`
            : ``,
        evangelhoReferenciaText: `<p>Evangelho (${dados.evangelho.referencia})</p>`,
        evangelhoTituloText: `<p class="poppins-medium">— Aleluia, Aleluia, Aleluia.</p><p>${dados.evangelho.titulo}<p>`,
        evangelhoTextoText: `
            <p class="poppins-medium">— Glória a vós, Senhor.</p>
            <p>${dados.evangelho.texto.replace(/(\d+)(?=[a-zA-Z])/g, '$1 ').replace(/\b\d+\b/g, '<span class="poppins-medium">$& </span>')}</p>
            <p>— Palavra da Salvação.</p>
            <p class="poppins-medium">— Glória a vós, Senhor.</p>`,
    };

    for (const [fieldId, value] of Object.entries(fieldsMapping)) {
        const field = document.getElementById(fieldId);
        if (field) {
            field.innerHTML = value;
        }
    }
}

function atualizarCorLiturgica(corLiturgica) {
    const liturgiaIcon = document.querySelector('.liturgia-icon');
    if (liturgiaIcon) {
        let cor;
        switch (corLiturgica.toLowerCase()) {
            case 'verde':
                cor = 'green';
                break;
            case 'vermelho':
                cor = 'red';
                break;
            case 'roxo':
                cor = 'purple';
                break;
            case 'branco':
                cor = 'lightgray';
                break;
            case 'rosa':
                cor = 'pink';
                break;
            default:
                cor = 'lightgray';
        }
        liturgiaIcon.style.color = cor;
    }
}

function addBorderIcon() {
    const liturgiaIcon = document.querySelector('.liturgia-icon');
    //let border = document.getElementsByClassName('liturgia-icon');
    if (atualizarCorLiturgica(corLiturgica.cor) == 'branco') {
        iconCorLiturgica.classList.add('borda-icon-liturgia');
    } else {
        mostrar.classList.remove('borda-icon-liturgia');
    }
}
/*-----------------FIM LITURGIA-----------------*/






/*-----------------INÍCIO GET ESTADOS E CIDADE API-----------------*/
async function carregarEstadosAPI() {
    try {
        const response = await $.getJSON("/APIEstadoCidade/GetEstadosAPI");
        response.sort((a, b) => a.nome.localeCompare(b.nome));

        // Para cada seletor de estado na página
        $('.estado-select').each(function () {
            const $estadoSelect = $(this);
            const cidadeSelectId = $estadoSelect.data('cidade');
            const hiddenFieldId = $estadoSelect.data('hidden');

            $estadoSelect.empty().append('<option value="" disabled selected>Selecione o estado</option>');
            response.forEach(estado => {
                $estadoSelect.append(`<option value="${estado.id}" data-nome="${estado.nome}" data-sigla="${estado.sigla}">${estado.nome}</option>`);
            });

            // Evento de mudança no estado
            $estadoSelect.change(function () {
                const estadoSelecionado = $estadoSelect.find("option:selected");
                const nomeEstado = estadoSelecionado.data('nome'); // Captura o nome do estado

                // Atualizar campo oculto com o nome do estado
                if (hiddenFieldId) {
                    $(`#${hiddenFieldId}`).val(nomeEstado); // Agora armazena o nome do estado no campo oculto
                }

                // Carregar cidades para o estado selecionado
                carregarCidadesAPI($estadoSelect, cidadeSelectId);
            });
        });
    } catch (error) {
        alert('Erro ao carregar os estados. Tente novamente mais tarde.');
    }
}

function carregarCidadesAPI($estadoSelect, cidadeSelectId) {
    const estadoId = $estadoSelect.val();
    const $cidadeSelect = $(`#${cidadeSelectId}`);

    if (estadoId) {
        $.getJSON(`/APIEstadoCidade/GetCidadesPorEstadoAPI?estadoId=${estadoId}`)
            .done(function (data) {
                $cidadeSelect.empty().append('<option value="" disabled selected>Selecione a cidade</option>');
                data.forEach(cidade => {
                    $cidadeSelect.append(`<option value="${cidade.nome}">${cidade.nome}</option>`);
                });
            })
            .fail(function () {
                alert('Erro ao carregar as cidades. Tente novamente mais tarde.');
            });
    } else {
        $cidadeSelect.empty().append('<option value="" disabled selected>Selecione a cidade</option>');
    }
}

$(document).ready(function () {
    carregarEstadosAPI();
});
/*-----------------FIM GET ESTADOS E CIDADE API-----------------*/






/*-----------------INÍCIO FORMATAÇÃO CNPJ / TELEFONE / CEP-----------------*/
function formatarCNPJ(cnpj) {
    cnpj = cnpj.replace(/\D/g, ""); // Remove qualquer coisa que não seja número
    cnpj = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$/, "$1.$2.$3/$4-$5"); // Formata o CNPJ
    return cnpj;
}
function formatarCEP(cep) {
    cep = cep.replace(/\D/g, ""); // Remove qualquer coisa que não seja número
    cep = cep.replace(/^(\d{5})(\d{3})$/, "$1-$2"); // Formata o CEP
    return cep;
}
function formatarCelular(celular) {
    celular = celular.replace(/\D/g, ""); // Remove qualquer coisa que não seja número
    celular = celular.replace(/^(\d{2})(\d{5})(\d{4})$/, "($1) $2-$3"); // Formata o celular
    return celular;
}

// CADASTRO EVENTO
document.addEventListener("DOMContentLoaded", function () {
    const cnpjInput = document.querySelector("input[name='viewModel.Igreja.CNPJ']");
    const cepInput = document.querySelector("input[name='viewModel.Igreja.CEP']");
    const celularInput = document.querySelector("input[name='viewModel.Igreja.Telefone']");

    cnpjInput.addEventListener("input", function () {
        this.value = formatarCNPJ(this.value);
    });

    cepInput.addEventListener("input", function () {
        this.value = formatarCEP(this.value);
    });

    celularInput.addEventListener("input", function () {
        this.value = formatarCelular(this.value);
    });
});

// CADASTRO EVENTO
document.addEventListener("DOMContentLoaded", function () {
    const cnpjInputEvento = document.querySelector("input[name='viewModel.Evento.CNPJ']");
    const cepInputEvento = document.querySelector("input[name='viewModel.Evento.CEP']");
    const celularInputEvento = document.querySelector("input[name='viewModel.Evento.Telefone']");

    cnpjInputEvento.addEventListener("input", function () {
        this.value = formatarCNPJ(this.value);
    });

    cepInputEvento.addEventListener("input", function () {
        this.value = formatarCEP(this.value);
    });

    celularInputEvento.addEventListener("input", function () {
        this.value = formatarCelular(this.value);
    });
});
/*-----------------FIM FORMATAÇÃO CNPJ / TELEFONE / CEP-----------------*/












/*-----------------INÍCIO GET ESTADOS / CIDADE / BAIRRO / IGREJAS / IGREJA / EVENTOS / EVENTO BANCO-----------------*/
// ESTADOS
$(document).ready(function () {
    carregarEstados();
    carregarEstadosEventos();
});

// ESTADOS DAS IGREJAS CADASTRADAS
async function carregarEstados() {
    try {
        const response = await $.getJSON(`/Igreja/GetEstados`);
        console.log(response);
        $('#Estado').empty().append('<option value="" disabled selected>Estado</option>');
        response.forEach(estado => {
            $('#Estado').append(`<option value="${estado}">${estado}</option>`);
        });
        $('#Estado').on('change', carregarCidades);
    } catch (error) {
        alert('Erro ao carregar os estados. Tente novamente mais tarde.');
    }
}

// ESTADOS DOS EVENTOS CADASTRADOS
async function carregarEstadosEventos() {
    try {
        const response = await $.getJSON(`/Evento/GetEstadosEventos`);
        console.log(response);
        $('#EstadoEvento').empty().append('<option value="" disabled selected>Estado</option>');
        response.forEach(estado => {
            $('#EstadoEvento').append(`<option value="${estado}">${estado}</option>`);
        });
        $('#EstadoEvento').on('change', carregarCidadesEventos);
    } catch (error) {
        alert('Erro ao carregar os estados. Tente novamente mais tarde.');
    }
}
/*----------------------------------------------------------------------------------------------------*/
// CIDADES

// CIDADES DAS IGREJAS CADASTRADAS
function carregarCidades() {
    const estado = $('#Estado').val();
    console.log(estado);

    $('#Cidade').empty().append('<option value="" disabled selected>Cidade</option>');
    $('#Bairro').empty().append('<option value="" disabled selected>Bairro</option>');
    $('#Igreja').empty().append('<option value="" disabled selected>Igreja</option>');

    if (estado) {
        $.getJSON(`/Igreja/GetCidadesPorEstado?estado=${estado}`)
            .done(function (data) {
                $('#Cidade').empty().append('<option value="" disabled selected>Cidade</option>');
                $.each(data, function (index, cidade) {
                    $('#Cidade').append(`<option value="${cidade}">${cidade}</option>`);
                });
                $('#Cidade').on('change', carregarBairros);
            })
            .fail(function () {
                alert('Erro ao carregar as cidades. Tente novamente mais tarde.');
            });
    } else {
        $('#Cidade').empty().append('<option value="" disabled selected>Cidade</option>');
    }
}

// CIDADES DOS EVENTOS CADASTRADOS
function carregarCidadesEventos() {
    const estado = $('#EstadoEvento').val();
    console.log(estado);

    $('#CidadeEvento').empty().append('<option value="" disabled selected>Cidade</option>');
    $('#BairroEvento').empty().append('<option value="" disabled selected>Bairro</option>');
    $('#Evento').empty().append('<option value="" disabled selected>Evento</option>');


    if (estado) {
        $.getJSON(`/Evento/GetCidadesPorEstadoEventos?estado=${estado}`)
            .done(function (data) {
                $('#CidadeEvento').empty().append('<option value="" disabled selected>Cidade</option>');
                $.each(data, function (index, cidade) {
                    $('#CidadeEvento').append(`<option value="${cidade}">${cidade}</option>`);
                });
                $('#CidadeEvento').on('change', carregarBairrosEventos);
            })
            .fail(function () {
                alert('Erro ao carregar as cidades. Tente novamente mais tarde.');
            });
    } else {
        $('#CidadeEvento').empty().append('<option value="" disabled selected>Cidade</option>');
    }
}
/*----------------------------------------------------------------------------------------------------*/
// BAIRROS

// BAIRROS DAS IGREJAS CADASTRADAS
function carregarBairros() {
    const cidade = $('#Cidade').val();
    console.log(cidade);

    $('#Bairro').empty().append('<option value="" disabled selected>Bairro</option>');
    $('#Igreja').empty().append('<option value="" disabled selected>Igreja</option>');

    if (cidade) {
        $.getJSON(`/Igreja/GetBairrosPorCidade?cidade=${cidade}`)
            .done(function (data) {
                $('#Bairro').empty().append('<option value="" disabled selected>Bairro</option>');
                $.each(data, function (index, bairro) {
                    $('#Bairro').append(`<option value="${bairro}">${bairro}</option>`);
                });

                $('#Bairro').on('change', carregarIgrejaPorBairro);
            })
            .fail(function () {
                alert('Erro ao carregar os bairros. Tente novamente mais tarde.');
            });
    } else {
        $('#Bairro').empty().append('<option value="" disabled selected>Bairro</option>');
    }
}

// BAIRROS DOS EVENTOS CADASTRADOS
function carregarBairrosEventos() {
    const cidade = $('#CidadeEvento').val();
    console.log(cidade);

    $('#BairroEvento').empty().append('<option value="" disabled selected>Bairro</option>');
    $('#Evento').empty().append('<option value="" disabled selected>Evento</option>');

    if (cidade) {
        $.getJSON(`/Evento/GetBairrosPorCidadeEventos?cidade=${cidade}`)
            .done(function (data) {
                $('#BairroEvento').empty().append('<option value="" disabled selected>Bairro</option>');
                $.each(data, function (index, bairro) {
                    $('#BairroEvento').append(`<option value="${bairro}">${bairro}</option>`);
                });

                $('#BairroEvento').on('change', carregarEventosPorBairro);
            })
            .fail(function () {
                alert('Erro ao carregar os bairros. Tente novamente mais tarde.');
            });
    } else {
        $('#BairroEvento').empty().append('<option value="" disabled selected>Bairro</option>');
    }
}
/*----------------------------------------------------------------------------------------------------*/
// IGREJAS E EVENTOS

let requisicaoEmAndamento = false;
// IGREJAS CADASTRADAS
function carregarIgrejaPorBairro() {
    const estado = $('#Estado').val();
    const cidade = $('#Cidade').val();
    const bairro = $('#Bairro').val();
    console.log("Estado: ", estado, ", Cidade: ", cidade, ", Bairro: ", bairro);

    // Verifica se uma requisição já está em andamento
    if (requisicaoEmAndamento) {
        console.log("Requisição já em andamento.");
        return;  // Evita fazer outra requisição
    }

    // Marca que a requisição está em andamento
    requisicaoEmAndamento = true;

    $('#Igreja').empty().append('<option value="" disabled selected>Igreja</option>');

    if (bairro) {
        $.post(`/Igreja/BuscarIgrejas`, { estado: estado, cidade: cidade, bairro: bairro })
            .done(function (data) {
                if (data.length > 0) {
                    $.each(data, function (index, igreja) {
                        $('#Igreja').append(`<option value="${igreja.id}">${igreja.nomeIgreja}</option>`);
                    });
                } else {
                    $('#Igreja').append('<option value="" disabled>Nenhuma igreja encontrada</option>');
                }
            })
            .fail(function () {
                alert('Erro ao carregar as igrejas. Tente novamente mais tarde.');
            })
            .always(function () {
                // Marca que a requisição terminou
                requisicaoEmAndamento = false;
            });
    }
}

// EVENTOS CADASTRADOS
function carregarEventosPorBairro() {
    const estado = $('#EstadoEvento').val();
    const cidade = $('#CidadeEvento').val();
    const bairro = $('#BairroEvento').val();
    console.log("Estado: ", estado, ", Cidade: ", cidade, ", Bairro: ", bairro);

    // Verifica se uma requisição já está em andamento
    if (requisicaoEmAndamento) {
        console.log("Requisição já em andamento.");
        return;  // Evita fazer outra requisição
    }

    // Marca que a requisição está em andamento
    requisicaoEmAndamento = true;

    $('#Evento').empty().append('<option value="" disabled selected>Evento</option>');

    if (bairro) {
        $.post(`/Evento/BuscarEventos`, { estado: estado, cidade: cidade, bairro: bairro })
            .done(function (data) {
                if (data.length > 0) {
                    $.each(data, function (index, evento) {
                        $('#Evento').append(`<option value="${evento.id}">${evento.tituloEvento}</option>`);
                    });
                } else {
                    $('#Evento').append('<option value="" disabled>Nenhum evento encontrado</option>');
                }
            })
            .fail(function () {
                alert('Erro ao carregar os eventos. Tente novamente mais tarde.');
            })
            .always(function () {
                // Marca que a requisição terminou
                requisicaoEmAndamento = false;
            });
    }
}
/*----------------------------------------------------------------------------------------------------*/
// BOTÕES
// FILTRO EVENTOS
$('#buscarEventos').click(function (e) {
    e.preventDefault();

    const eventoId = $('#Evento').val();
    console.log('ID do evento selecionado:', eventoId);

    // Caso o usuário tenha selecionado uma igreja específica
    if (eventoId) {
        // Realiza a requisição POST para buscar os dados da igreja
        $.post(`/Evento/BuscarEventoPorId?eventoId=${eventoId}`, { eventoId: eventoId })
            .done(function (data) {
                console.log(data);
                $('body').html(data);

                setTimeout(() => {
                    const resultados = document.getElementById('search-results');
                    if (resultados) {
                        resultados.scrollIntoView({ behavior: 'smooth', block: 'start' });
                    } else {
                        console.warn('Seção de resultados não encontrada!');
                    }
                }, 100); // Ajusta o delay, se necessário
            })
            .fail(function () {
                console.error('Erro ao buscar o evento.');
                alert('Erro ao buscar o evento. Tente novamente mais tarde.');
            });
    } else {
        // Caso contrário, pega os filtros de bairro, cidade e estado
        const bairro = $('#BairroEvento').val();
        const cidade = $('#CidadeEvento').val();
        const estado = $('#EstadoEvento').val();

        // Faz o redirecionamento e usa sessionStorage para armazenar a intenção de rolar
        sessionStorage.setItem('scrollToResults', 'true');
        window.location.href = `/Evento/Index?estado=${estado}&cidade=${cidade}&bairro=${bairro}`;
    }
});

// FILTRO INDEX
$('#botaoBuscar').click(function (e) { //
    e.preventDefault();

    const igrejaId = $('#Igreja').val();
    console.log('ID da igreja selecionada:', igrejaId);

    // Caso o usuário tenha selecionado uma igreja específica
    if (igrejaId) {
        // Redireciona para a página de resultados com a igreja selecionada
        $.post(`/Igreja/BuscarIgrejaPorId?igrejaId=${igrejaId}`, { igrejaId: igrejaId }, function (data) { // TODO: MODIFICAR PARA GET PASSANDO UMA URL SOMENTE COM Igreja/igrejaId E MANIPULAR O OBJETO/JSON QUE É RETORNADO DA CONTROLLER (como foi feito com o resultado da api da liturgia)
            console.log(data);
            $('body').html(data);

            setTimeout(() => {
                const resultados = document.getElementById('search-results');
                if (resultados) {
                    resultados.scrollIntoView({ behavior: 'smooth', block: 'start' });
                } else {
                    console.warn('Seção de resultados não encontrada!');
                }
            }, 100);
        })
            .fail(function () {
                console.error('Erro ao buscar a igreja.');
                alert('Erro ao buscar a igreja. Tente novamente mais tarde.');
            });
    } else {
        // Caso contrário, pega os filtros de bairro, cidade e estado
        const bairro = $('#Bairro').val();
        const cidade = $('#Cidade').val();
        const estado = $('#Estado').val();

        // Redireciona para a página de resultados com os filtros de bairro/cidade/estado
        sessionStorage.setItem('scrollToResults', 'true');
        window.location.href = `/Igreja/ResultadoPesquisa?estado=${estado}&cidade=${cidade}&bairro=${bairro}`;
    }
});

// FILTRO MISSAS
$('#buscar').click(function (e) {
    e.preventDefault();

    const igrejaId = $('#Igreja').val();
    console.log('ID da igreja selecionada:', igrejaId);

    // Caso o usuário tenha selecionado uma igreja específica
    if (igrejaId) {
        // Realiza a requisição POST para buscar os dados da igreja
        $.post(`/Igreja/BuscarIgrejaPorId?igrejaId=${igrejaId}`, { igrejaId: igrejaId })
            .done(function (data) {
                console.log(data);
                $('body').html(data);

                setTimeout(() => {
                    const resultados = document.getElementById('search-results');
                    if (resultados) {
                        resultados.scrollIntoView({ behavior: 'smooth', block: 'start' });
                    } else {
                        console.warn('Seção de resultados não encontrada!');
                    }
                }, 100);
            })
            .fail(function () {
                console.error('Erro ao buscar a igreja.');
                alert('Erro ao buscar a igreja. Tente novamente mais tarde.');
            });
    } else {
        // Caso contrário, pega os filtros de bairro, cidade e estado
        const bairro = $('#Bairro').val();
        const cidade = $('#Cidade').val();
        const estado = $('#Estado').val();

        // Faz o redirecionamento e usa sessionStorage para armazenar a intenção de rolar
        sessionStorage.setItem('scrollToResults', 'true');
        window.location.href = `/Igreja/ResultadoPesquisa?estado=${estado}&cidade=${cidade}&bairro=${bairro}`;
    }
});

// Verifica a intenção de rolagem após o redirecionamento
$(document).ready(function () {
    if (sessionStorage.getItem('scrollToResults') === 'true') {
        sessionStorage.removeItem('scrollToResults');

        // Rola para a seção de resultados, se existir
        const resultados = document.getElementById('search-results');
        if (resultados) {
            resultados.scrollIntoView({ behavior: 'smooth', block: 'start' });
        } else {
            console.warn('Seção de resultados não encontrada!');
        }
    }
});

/*-----------------FIM GET ESTADOS / CIDADE / BAIRRO / IGREJAS / IGREJA / EVENTOS / EVENTO BANCO-----------------*/



window.onload = function () {
    obterLiturgia();
    preencherLiturgia();
    addBorderIcon();
    validarFormularioPesquisa();
};