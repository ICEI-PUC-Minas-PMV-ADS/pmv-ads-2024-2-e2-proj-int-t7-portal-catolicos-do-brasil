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
        const response = await fetch('/liturgia');
        if (!response.ok) {
            throw new Error('Erro ao buscar a liturgia');
        }
        const dados = await response.json();
        console.log('Dados da liturgia:', dados);
        return dados;
    } catch (error) {
        console.error('Erro:', error);
        container.innerHTML = '<p>Erro ao carregar a liturgia.</p>';
        return null;
    }
}

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

function preencherCampo(field, value) {
    if (field) {
        field.textContent = value;
    }
}

function fillFormWithData(dados) {
    const fieldsMapping = {
        liturgiaData: formatarData(new Date()),
        liturgiaText: `
            <p>${converterDiaSemana(dados.liturgia)}</p>
        `,
        corLiturgia: "COR LITÚRGICA: " + dados.cor.toUpperCase(),
        primeiraLeituraReferenciaText: `
            <p>Primeira Leitura (${dados.primeiraLeitura.referencia})</p>
        `,
        primeiraLeituraTituloText: `
            <p>${dados.primeiraLeitura.titulo}</p>
        `,
        primeiraLeituraTextoText: `
            <p>${dados.primeiraLeitura.texto.replace(/(\d+)(?=[a-zA-Z])/g, '$1 ').replace(/\b\d+\b/g, '<span class="poppins-medium">$& </span>')}</p>
            <p>— Palavra do Senhor.</p>
            <p class="poppins-medium">— Graças a Deus.</p>
        `,
        salmoReferenciaText: `
            <p>Responsório (${dados.salmo.referencia})</p>
        `,
        salmoRefraoText: `
            <p class="poppins-light">— ${dados.salmo.refrao}</p>
            <p>— ${dados.salmo.refrao}</p>
        `,
        salmoTextoText: dados.salmo.texto
            //? `<p>${dados.salmo.texto.replace(/([.!?])\s*/g, '$1 <br><br>')}</p>`
            ? `<p>${dados.salmo.texto.replace(/([—])\s*/g, '<br><br> $1 ')}.</p>`
            //? `<p>${dados.salmo.texto.replace(/—/g, '<br>—')}</p>`
            : `<p>Salmo não disponível.</p>
        `,
        segundaLeituraReferenciaText: dados.segundaLeitura?.referencia
            ? `<p>Segunda Leitura (${dados.segundaLeitura.referencia})</p>`
            : `<p class="poppins-regular-italic">Não há segunda leitura hoje!</p>`,
        segundaLeituraTituloText: dados.segundaLeitura.titulo
            ? `<p>${dados.segundaLeitura.titulo}</p>`
            : ``,
        segundaLeituraTextoText: dados.segundaLeitura.texto
            ? `<p>${dados.segundaLeitura.texto.replace(/(\d+)(?=[a-zA-Z])/g, '$1 ').replace(/\b\d+\b/g, '<span class="poppins-medium">$& </span>')}</p>
            <p>— Palavra do Senhor.</p>
            <p class="poppins-medium">— Graças a Deus.</p>`
            : ``,
        evangelhoReferenciaText: `
            <p>Evangelho (${dados.evangelho.referencia})</p>
        `,
        evangelhoTituloText: `
            <p class="poppins-medium">— Aleluia, Aleluia, Aleluia.</p>
            <p>${dados.evangelho.titulo}<p>
        `,
        evangelhoTextoText: `
            <p class="poppins-medium">— Glória a vós, Senhor.</p>
            <p>${dados.evangelho.texto.replace(/(\d+)(?=[a-zA-Z])/g, '$1 ').replace(/\b\d+\b/g, '<span class="poppins-medium">$& </span>')}</p>
            <p>— Palavra da Salvação.</p>
            <p class="poppins-medium">— Glória a vós, Senhor.</p>
        `,
    };

    for (const [fieldId, value] of Object.entries(fieldsMapping)) {
        const field = document.getElementById(fieldId);
        if (field) {
            if (fieldId === 'evangelhoTextoText', 'evangelhoReferenciaText') {
                field.innerHTML = value;
            } else {
                field.textContent = value;
            }
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
                cor = 'white';
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
    /*let border = document.getElementsByClassName('liturgia-icon');*/
    if (atualizarCorLiturgica(corLiturgica.cor) == 'branco') {
        iconCorLiturgica.classList.add('borda-icon-liturgia');
    } else {
        mostrar.classList.remove('borda-icon-liturgia');
    };
}

window.onload = function () {
    preencherLiturgia();
    addBorderIcon();
};
/*-----------------FIM LITURGIA-----------------*/
