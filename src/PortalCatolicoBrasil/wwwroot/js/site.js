//import { carregarSantoDia } from './santo.js';

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
		primeiraLeituraReferenciaText: `<p>Primeira Leitura (${dados.primeiraLeitura.referencia})</p>`,
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


/*-----------------INICIO HOME INDEX-----------------*/
//GET ESTADOS API
async function carregarEstadosAPI() {
	try {
		const response = await $.getJSON("/APIEstadoCidade/GetEstadosAPI");
		response.sort((a, b) => a.nome.localeCompare(b.nome));

		$('#EstadoAPI').empty().append('<option value="" disabled selected>Selecione o estado</option>');
		response.forEach(estado => {
			$('#EstadoAPI').append(`<option value="${estado.id}">${estado.nome}</option>`);
		});

		$('#EstadoAPI').change(carregarCidadesAPI);

	} catch (error) {
		alert('Erro ao carregar os estados. Tente novamente mais tarde.');
	}
}

//GET CIDADES API
function carregarCidadesAPI() {
	const estadoId = $('#EstadoAPI').val();
	if (estadoId) {
		$.getJSON(`/APIEstadoCidade/GetCidadesPorEstadoAPI?estadoId=${estadoId}`)
			.done(function (data) {
				$('#CidadeAPI').empty().append('<option value="" disabled selected>Selecione a cidade</option>');
				data.forEach(cidade => {
					$('#CidadeAPI').append(`<option value="${cidade.id}">${cidade.nome}</option>`);
				});
			})
			.fail(function () {
				alert('Erro ao carregar as cidades. Tente novamente mais tarde.');
			});
	} else {
		$('#CidadeAPI').empty().append('<option value="" disabled selected>Selecione a cidade</option>');
	}
}

$(document).ready(function () {
	carregarEstadosAPI();
});


/*----------------------------------------------------------------------------------------------------*/

//GET ESTADOS BANCO
async function carregarEstados() {
	try {
		const response = await $.getJSON(`/Igreja/GetEstados`);
		$('#Estado').empty().append('<option value="" disabled selected>Estado</option>');
		response.forEach(estado => {
			$('#Estado').append(`<option value="${estado}">${estado}</option>`);
		});
	} catch (error) {
		alert('Erro ao carregar os estados. Tente novamente mais tarde.');
	}
}

$(document).ready(function () {
	carregarEstados();
});

//GET CIDADES BANCO
function carregarCidades() {
	const estado = $('#Estado').val();
	console.log(estado);
	if (estado) {
		$.getJSON(`/Igreja/GetCidadesPorEstado?estado=${estado}`)
		.done(function (data) {
			$('#Cidade').empty().append('<option value="" disabled selected>Cidade</option>');
			$.each(data, function (index, cidade) {
				$('#Cidade').append(`<option value="${cidade}">${cidade}</option>`);
			});
		})
		.fail(function () {
			alert('Erro ao carregar as cidades. Tente novamente mais tarde.');
		});
	} else {
		$('#Cidade').empty().append('<option value="" disabled selected>Cidade</option>');
	}
}

$('#Cidade').change(function () {
	carregarBairros();
});

//GET BAIRROS BANCO
function carregarBairros() {
	const cidade = $('#Cidade').val();
	console.log(cidade);
	if (cidade) {
		$.getJSON(`/Igreja/GetBairrosPorCidade?cidade=${cidade}`)
		.done(function (data) {
			$('#Bairro').empty().append('<option value="" disabled selected>Bairro</option>');
			$.each(data, function (index, bairro) {
				$('#Bairro').append(`<option value="${bairro}">${bairro}</option>`);
			});
		})
		.fail(function () {
			alert('Erro ao carregar os bairros. Tente novamente mais tarde.');
		});
	} else {
		$('#Bairro').empty().append('<option value="" disabled selected>Bairro</option>');
	}
}

$('#Bairro').change(function () {
	carregarIgrejaPorBairro();
});

//GET IGREJAS BANCO
function carregarIgrejaPorBairro() {
	const bairro = $('#Bairro').val();

	if (bairro) {
		let url = `/Igreja/BuscarIgrejas`;
		$.post(url, { estado: $('#Estado').val(), cidade: $('#Cidade').val(), bairro: bairro }, function (data) {
			$('#Igreja').empty().append('<option value="" disabled selected>Selecione uma igreja</option>');
			if (data.length > 0) {
				$.each(data, function (index, igreja) {
					$('#Igreja').append(`<option value="${igreja.id}">${igreja.nomeIgreja}</option>`);
				});
			} else {
				$('#Igreja').append('<option value="" disabled>Nenhuma igreja encontrada</option>');
			}
		}).fail(function () {
			alert('Erro ao carregar as igrejas. Tente novamente mais tarde.');
		});
	} else {
		$('#Igreja').empty().append('<option value="" disabled selected>Selecione uma igreja</option>');
	}
}

$('#botaoBuscar').click(function (e) {
	e.preventDefault();

	const igrejaId = $('#Igreja').val();
	console.log('ID da igreja selecionada:', igrejaId);

	if (igrejaId) {
		$.post(`/Igreja/BuscarIgrejaPorId?igrejaId=${igrejaId}`, { igrejaId: igrejaId }, function (data) { // TODO: MODIFICAR PARA GET PASSANDO UMA URL SOMENTE COM Igreja/igrejaId E MANIPULAR O OBJETO/JSON QUE É RETORNADO DA CONTROLLER (como foi feito com o resultado da api da liturgia)
			console.log(data);
			$('body').html(data);
		}).fail(function (xhr, status, error) {
			console.log('Erro:', status, error);
			alert('Erro ao buscar a igreja. Tente novamente mais tarde.');
		});
	} else {
		alert('Por favor, selecione uma igreja.');
	}
});

function validarFormularioPesquisa() {
	var estado = document.getElementById("Estado").value;
	var cidade = document.getElementById("Cidade").value;

	if (estado === "" || cidade === "") {
		alert("Por favor, preencha os campos de Estado e Cidade antes de buscar.");
		return false;
	}
	return true;
}

document.querySelector('.pesqgps').addEventListener('click', function () {
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(function (position) {
			var lat = position.coords.latitude;
			var lon = position.coords.longitude;
			alert("Sua localização atual é: Latitude: " + lat + ", Longitude: " + lon);
			// lógica pra pegar pelo endereço do usuário
		}, function () {
			alert("Não foi possível obter sua localização.");
		});
	} else {
		alert("Geolocalização não é suportada pelo seu navegador.");
	}
});

//document.querySelector('.pesqgps').addEventListener('click', function () {
//	if (navigator.geolocation) {
//		navigator.geolocation.getCurrentPosition(function (position) {
//			var lat = position.coords.latitude;
//			var lon = position.coords.longitude;

//			// Enviar a latitude e longitude para o servidor
//			fetch('/Igreja/BuscarPorLocalizacao', {
//				method: 'POST',
//				headers: {
//					'Content-Type': 'application/json'
//				},
//				body: JSON.stringify({
//					latitude: lat,
//					longitude: lon
//				})
//			})
//				.then(response => response.json())
//				.then(data => {
//					// Exibir os resultados das igrejas
//					console.log(data);
//					// Aqui você pode manipular o DOM para exibir as igrejas encontradas
//				})
//				.catch(error => {
//					console.error('Erro ao buscar igrejas:', error);
//				});
//		}, function () {
//			alert("Não foi possível obter sua localização.");
//		});
//	} else {
//		alert("Geolocalização não é suportada pelo seu navegador.");
//	}
//});



function abrirMapa(endereco) {
	const url = `https://www.google.com/maps/search/?api=1&query=${encodeURIComponent(endereco)}`;
	window.open(url, '_blank');
}

/*-----------------FIM HOME INDEX-----------------*/


/*-----------------INICIO CIDADES E ESTADOS EVENTO-----------------*/
    document.addEventListener("DOMContentLoaded", function() {
    const estadoSelect = document.getElementById("estado");
    const cidadeSelect = document.getElementById("cidade");

    // Carregar estados
    fetch("https://servicodados.ibge.gov.br/api/v1/localidades/estados")
        .then(response => response.json())
        .then(estados => {
        estados.forEach(estado => {
            const option = document.createElement("option");
            option.value = estado.sigla;
            option.text = estado.nome;
            estadoSelect.appendChild(option);
        });
        });

    // Atualizar cidades quando um estado é selecionado
    estadoSelect.addEventListener("change", function() {
        const estadoSigla = estadoSelect.value;

    // Limpar cidades anteriores
    cidadeSelect.innerHTML = '<option selected>Escolha...</option>';

    if (estadoSigla) {
        fetch(`https://servicodados.ibge.gov.br/api/v1/localidades/estados/${estadoSigla}/municipios`)
            .then(response => response.json())
            .then(cidades => {
                cidades.forEach(cidade => {
                    const option = document.createElement("option");
                    option.value = cidade.nome;
                    option.text = cidade.nome;
                    cidadeSelect.appendChild(option);
                });
            });
        }
    });
});
/*-----------------FIM CIDADES E ESTADOS EVENTO-----------------*/


/*-----------------Inicio Filtro Pesquisa Eventos-----------------*/
function filtrarEventos()
{
    const estado = document.getElementById('estado').value
    const cidade = document.getElementById('cidade').cidade
    const bairro = document.getElementById('bairro').bairro
    const ResultadoPesquisa = document.getElementById("EventosResultados");
    const MensagemResultado = document.getElementById("MensagemResultado")


    fetch(`/Eventos/Buscar?estado=${estado}||cidade=${cidade}||bairro=${bairro}`)
        .then(response => response.json())
        .then(data => {
            ResultadoPesquisa.innerHTML = '';
            MensagemResultado.classList.add('hidden');
            if (data.length === 0) {
                MensagemResultado.classList.remove('hidden')
            }
            else
            {
                data.forEach(evento => {
                    const eventoDiv = document.createElement('div');
                    eventoDiv.classList.add('evento');

                    eventoDiv.innerHTML = `
                            <h2>${evento.TituloEvento}</h2>
                            <p><strong>Data:</strong> ${evento.DataInicio}</p>
                            <p><strong>Local:</strong> ${evento.Logradouro}, ${evento.Numero} - ${evento.Bairro}, ${evento.Cidade} - ${evento.Estado}</p>
                        `;
                    ResultadoPesquisa.appendChild(eventoDiv)
                });
            }

        })
        .catch(error => {
            console.error('Erro ao buscar eventos:', error);
            mensagemResultado.innerHTML = 'Ocorreu um erro ao buscar os eventos. Tente novamente mais tarde.';
            mensagemResultado.classList.remove('hidden');
        });
}
/*-----------------Fim Filtro Pesquisa Eventos-----------------*/

function mascaraCNPJ(campo) {
	// Remove qualquer caractere que não seja número
	let cnpj = campo.value.replace(/\D/g, "");

	// Aplica a máscara ao CNPJ
	if (cnpj.length <= 14) {
		cnpj = cnpj.replace(/^(\d{2})(\d)/, "$1.$2");
		cnpj = cnpj.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");
		cnpj = cnpj.replace(/\.(\d{3})(\d)/, ".$1/$2");
		cnpj = cnpj.replace(/(\d{4})(\d)/, "$1-$2");
	}

	// Define o valor formatado no campo de input
	campo.value = cnpj;
}

function mascaraTelefone(campo) {
	// Remove qualquer caractere que não seja número
	let telefone = campo.value.replace(/\D/g, "");

	// Aplica a máscara de telefone conforme a quantidade de dígitos
	if (telefone.length <= 10) {
		// Formato para números fixos com 8 dígitos (ex: (00) 0000-0000)
		telefone = telefone.replace(/^(\d{2})(\d)/, "($1) $2");
		telefone = telefone.replace(/(\d{4})(\d)/, "$1-$2");
	} else {
		// Formato para números móveis com 9 dígitos (ex: (00) 00000-0000)
		telefone = telefone.replace(/^(\d{2})(\d)/, "($1) $2");
		telefone = telefone.replace(/(\d{5})(\d)/, "$1-$2");
	}

	// Atualiza o campo com a máscara aplicada
	campo.value = telefone;
}

function mascaraCEP(campo) {
	// Remove qualquer caractere que não seja número
	let cep = campo.value.replace(/\D/g, "");

	// Aplica a máscara de CEP (ex: 00000-000)
	cep = cep.replace(/^(\d{5})(\d)/, "$1-$2");

	// Atualiza o campo com a máscara aplicada
	campo.value = cep;
}



window.onload = function () {
	preencherLiturgia();
	addBorderIcon();
	validarFormularioPesquisa();
};