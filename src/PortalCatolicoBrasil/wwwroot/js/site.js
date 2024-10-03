/*-----------------INÍCIO LITURGIA-----------------*/

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

    try {
        const response = await fetch('/liturgia');
        if (!response.ok) {
            throw new Error('Erro ao buscar a liturgia');
        }
        const data = await response.text();
        container.innerHTML = data;
    } catch (error) {
        console.error('Erro:', error);
        container.innerHTML = '<p>Erro ao carregar a liturgia.</p>';
    }
}

window.onload = function () {
    obterLiturgia();
};

/*-----------------FIM LITURGIA-----------------*/
