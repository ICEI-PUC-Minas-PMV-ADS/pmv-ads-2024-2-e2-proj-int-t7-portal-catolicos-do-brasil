<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 43f1f0a4ea46c157e62612e0a05ad09cf03429b0
﻿/*-----------------INÍCIO LITURGIA-----------------*/

const buttons = document.querySelectorAll(".btn--group button");
buttons.forEach(button => {
    button.addEventListener("click", function () {
        buttons.forEach(btn => btn.classList.remove("active"));
        this.classList.add("active")
    });
});

async function obterLiturgia() {
    const container = document.getElementById('liturgia-container');
    container.classList.add('liturgia--text');
    container.innerHTML = '<p>Carregando...</p>';
<<<<<<< HEAD
=======
=======
/*-----------------INÍCIO LITURGIA-----------------*/
const buttons = document.querySelectorAll(".btn--group button");
const contents = {
    '1ª LEITURA': document.getElementById('primeiraLeituraContent'),
    'SALMO': document.getElementById('salmoContent'),
    '2ª LEITURA': document.getElementById('segundaLeituraContent'),
    'EVANGELHO': document.getElementById('evangelhoContent')
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

async function obterLiturgia() {
    const container = document.getElementById('liturgiaText');

    container.classList.add('poppins-regular');
    container.innerHTML = '<p>Carregando a liturgia...</p>';
>>>>>>> dc9fda35176c673ccf55f90f1df00d5f12eb0564
>>>>>>> 43f1f0a4ea46c157e62612e0a05ad09cf03429b0

    try {
        const response = await fetch('/liturgia');
        if (!response.ok) {
            throw new Error('Erro ao buscar a liturgia');
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 43f1f0a4ea46c157e62612e0a05ad09cf03429b0
        const data = await response.text();
        container.innerHTML = data;
    } catch (error) {
        console.error('Erro:', error);
        container.innerHTML = '<p>Erro ao carregar a liturgia.</p>';
<<<<<<< HEAD
=======
=======
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
        liturgiaText: dados.liturgia,
        corLiturgia: "COR LITÚRGICA: " + dados.cor.toUpperCase(),
        primeiraLeituraReferenciaText: dados.primeiraLeitura.referencia,
        primeiraLeituraTituloText: dados.primeiraLeitura.titulo,
        primeiraLeituraTextoText: dados.primeiraLeitura.texto,
        segundaLeituraReferenciaText: dados.segundaLeitura.referencia,
        segundaLeituraTituloText: dados.segundaLeitura.titulo,
        segundaLeituraTextoText: dados.segundaLeitura.texto,
        salmoReferenciaText: dados.salmo.referencia,
        salmoRefraoText: dados.salmo.refrao,
        salmoTextoText: dados.salmo.texto,
        evangelhoReferenciaText: "Evangelho ${dados.evangelho.referencia}",
        evangelhoTituloText: dados.evangelho.titulo,
        evangelhoTextoText: `
            <p><strong>— Aleluia, Aleluia, Aleluia.</strong></p>
            <p>— Convertei-vos e crede no Evangelho, pois o Reino de Deus está chegando!</p>
            <p><em>Proclamação do Evangelho de Jesus Cristo + segundo ${dados.evangelho.autor}</em></p>
            <p><strong>— Glória a vós, Senhor.</strong></p>
            <p>${dados.evangelho.texto}</p>
            <p><strong>— Palavra da Salvação.</strong></p>
        `,
    };

    for (const [fieldId, value] of Object.entries(fieldsMapping)) { //TODO: Verificar o fillForm do evangelho (alternância dos textos)
        const field = document.getElementById(fieldId);
        if (field) {
            if (fieldId === 'evangelhoTextoText') {
                field.innerHTML = value;
            } else {
                field.textContent = value;
            }
        }


    }
    liturgiaText.classList.add('tituloLiturgia poppins-semibold');

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
                cor = 'black';
        }
        liturgiaIcon.style.color = cor;
>>>>>>> dc9fda35176c673ccf55f90f1df00d5f12eb0564
>>>>>>> 43f1f0a4ea46c157e62612e0a05ad09cf03429b0
    }
}

window.onload = function () {
<<<<<<< HEAD
    obterLiturgia();
};

=======
<<<<<<< HEAD
    obterLiturgia();
};

=======
    preencherLiturgia();
};
>>>>>>> dc9fda35176c673ccf55f90f1df00d5f12eb0564
>>>>>>> 43f1f0a4ea46c157e62612e0a05ad09cf03429b0
/*-----------------FIM LITURGIA-----------------*/
