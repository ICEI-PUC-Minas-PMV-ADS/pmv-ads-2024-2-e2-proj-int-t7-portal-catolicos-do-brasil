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

//function formatarEvangelho(dados) {
//    const evangelhoContainer = document.getElementById("evangelhoTextoText");
//    evangelhoContainer.innerHTML = `
//        <h3>Evangelho (${dados.evangelho.referencia})</h3>
//        <p><strong>— Aleluia, Aleluia, Aleluia.</strong></p>
//        <p>— Convertei-vos e crede no Evangelho, pois o Reino de Deus está chegando!</p>
//        <p><em>Proclamação do Evangelho de Jesus Cristo + segundo ${dados.evangelho.autor}</em></p>
//        <p><strong>— Glória a vós, Senhor.</strong></p>
//        <p>${dados.evangelho.texto}</p>
//        <p><strong>— Palavra da Salvação.</strong></p>
//    `;
//}


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
        evangelhoReferenciaText: dados.evangelho.referencia,
        evangelhoTituloText: dados.evangelho.titulo,
        // Aqui usamos innerHTML para preservar a formatação do evangelho
        evangelhoTextoText: `
            <h3>Evangelho (${dados.evangelho.referencia})</h3>
            <p><strong>— Aleluia, Aleluia, Aleluia.</strong></p>
            <p>— Convertei-vos e crede no Evangelho, pois o Reino de Deus está chegando!</p>
            <p><em>Proclamação do Evangelho de Jesus Cristo + segundo ${dados.evangelho.autor}</em></p>
            <p><strong>— Glória a vós, Senhor.</strong></p>
            <p>${dados.evangelho.texto}</p>
            <p><strong>— Palavra da Salvação.</strong></p>
        `,
    };

    for (const [fieldId, value] of Object.entries(fieldsMapping)) {
        const field = document.getElementById(fieldId);
        if (field) {
            if (fieldId === 'evangelhoTextoText') {
                field.innerHTML = value; // Utiliza innerHTML para o evangelho
            } else {
                field.textContent = value; // Utiliza textContent para os outros
            }
        }
    }
}


window.onload = function () {
    preencherLiturgia();
};
/*-----------------FIM LITURGIA-----------------*/
