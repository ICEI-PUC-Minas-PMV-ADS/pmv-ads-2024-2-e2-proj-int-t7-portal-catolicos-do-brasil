# Plano de Testes de Software

Aqui está sendo apresentado o plano de testes do Portal Católico do Brasil, baseados nos requisitos funcionais apresentados na <a href="docs/02-Especificação do Projeto.md"> Especificação do Projeto</a></span> e no <a href="docs/04-Projeto de Interface.md"> Projeto de Interface<a/>;

 
| **Caso de Teste - 001** 	| **Pesquisar igrejas e horários de missas por geolocalização** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - A aplicação deve implementar uma funcionalidade de busca que permita aos usuários encontrar igrejas e horários de missas baseados na geolocalização. |
| Objetivo do Teste 	| Verificar se o usuário consegue efetuar a busca de igrejas e respectivos dados de endereço, telefone, dias e horários de missas, bem como ao clicar no botão "ver no mapa", ser direcionado para a página/aplicativo do google maps com o respectivo endereço. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - filtrar no formulário "Pesquisar igrejas e missas" (utilizando os campos disponíveis) <br> - Clicar em "Buscar" |
|Critério de Êxito | - Ser direcionado para a página https://aindavamoshospedar.html onde será apresentado os cards com as igrejas resultantes da pesquisa com o botões de "ver no mapa" que ao ser clicado direcionará o usuário para a página/aplicativo do google maps com o respectivo endereço . |
|  	|  	|


| **Caso de Teste - 002** 	| **Trazer informações de Liturgia e homilia do dia** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-002 - A aplicação deve permitir a exibição diaria das informações de liturgia e homilia do dia, obtidas por meio de uma API confiável.|
| Objetivo do Teste 	| Verificar se o usuário consegue ter acesso às liturgias e homilias do dia de forma atualizada, considerando a data que está acessando. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - no menu principal clicar em  "LITURGIA" <br> - Ser direcionado para a página https://aindavamoshospedar.html, onde encontrará todas as leituras do dia em que acessar, bem como a homilia; |
|Critério de Êxito | - O usuário deve encontrar na página em questão, todas as leituras e homilia do dia correspondente a data em que estiver acessando. |
|  	|  	|


| **Caso de Teste - 003** 	| **Pesquisar eventos paroquiais cadastrados pelas igrejas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-003 - A aplicação deve permitir aos usuários ter acesso aos eventos paroquiais das igrejas que os cadastrarem para serem divulgados.|
| Objetivo do Teste 	| Verificar se o usuário consegue efetuar a busca dos eventos paroquiais cadastrados pelas igrejas e respectivos dados de endereço, telefone, dias e horários, bem como ao clicar no botão "ver no mapa", ser direcionado para a página/aplicativo do google maps com o respectivo endereço. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - no menu principal clicar em  "EVENTOS" <br> - Ser direcionado para a página https://aindavamoshospedar.html, onde deverá encontrar a relação de eventos ao preencher o filtro disponivel; |
|Critério de Êxito | - Após clicar no botão "Buscar" a página deverá apresentar a relação de eventos cadastrados de acordo com o filtro de busca; |
|  	|  	|



| **Caso de Teste - 004** 	| **Disponibilizar espaços para publicidades pagas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-004 - A aplicação apresentar espaços para exibição de publicidades pagas, com um CRUD para gerenciar tais inserções.|
| Objetivo do Teste 	| Verificar se os anúncios foram publicados corretamente. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - conferirir se os anúncios foram publicados em todas as páginas, exceto as páginas de Liturgia e Santo do Dia |
|Critério de Êxito | - O usuário deve conseguir visualizar corretamente os anúncios inseridos; |
|  	|  	|


| **Caso de Teste - 005** 	| **Enviar formulário para Cadastro de Paróquias e Missas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - A aplicação deve fornecer um formulário para as igrejas enviarem seus dados como nome, endereço, telefone, bem como dia e horário de suas missas, com um CRUD para gerenciamento dessas informações que deverá ser feito pelos administradores do site. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html e no Footer clicar em "Cadstre aqui" |
|Critério de Êxito | - O usuário deve conseguir preencher e enviar seus dados pelo formulário clicando no botão enviar; <br> - Essas informações deverão ser armazenadas no banco de dados para então serem validadas e inseridas na página missas; |
|  	|  	|



| **Caso de Teste - 006** 	| **Enviar formulário sobre os eventos das paróquias** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-006 - A aplicação deve fornecer um formulário para as igrejas divulgarem seus eventos pastorais com um CRUD para gerenciamento dessas informações que deverá ser gerenciado pelos administradores do site.|
| Objetivo do Teste 	| Verificar se o formulário disponiblizado na página https://aindavamoshospedar.html está recebendo e enviando corretamente as informações dos eventos cadastrados pelas igrejas. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - no menu principal clicar em  "EVENTOS" <br> - Ser direcionado para a página https://aindavamoshospedar.html, onde encontrará o link "Cadastre aqui"<br> - Ao clicar será direcionado para a página https://aindavamoshospedar.html onde encontrará o formulário; |
|Critério de Êxito | - O usuário deve conseguir preencher o formulário e enviar as informações clicando no botão enviar; <br> - Essas informações deverão ser armazenadas no banco de dados para então serem validadas e inseridas na página Eventos; |
|  	|  	|

| **Caso de Teste - 007** 	| **Gerenciar informações do portal** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-007 - A aplicação deve fornecer um módulo simples para que gestores/desenvolvedores possam gerenciar todas as informações do portal, incluindo usuários, conteúdos, anúncios e eventos.|
| Objetivo do Teste 	| Verificar se a aplicação oferece uma forma de gerenciar as informações e CRUD's presentes no site. |
| Passos 	| - Acessar o servidor e implementar os CRUD's <br> - Verificar se as mudanças foram efetuadas na aplicação; |
|Critério de Êxito | - As mudanças implementadas deverão ter sido efetuadas na aplicação; |
|  	|  	|


| **Caso de Teste - 008** 	| **Trazer informações do Santo do dia** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-008 - A aplicação deve Exibir os santos celebrados no dia correspondente à data da pesquisa.|
| Objetivo do Teste 	| Verificar se o usuário consegue ter acesso às informações do Santo do dia de forma atualizada, considerando a data que está acessando. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - no menu principal clicar em  "SANTO DO DIA" <br> - Ser direcionado para a página https://aindavamoshospedar.html, onde encontrará a informações do Santo do dia em que está acessando; |
|Critério de Êxito | - O usuário deve encontrar na página em questão, as informações do Santo do dia correspondente a data em que estiver acessando. |
|  	|  	|


| **Caso de Teste - 009** 	| **Trazer Publicações de temas relevantes do cenário católico** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-009 - A aplicação deve Exibir matérias relevantes do cenário Católico.|
| Objetivo do Teste 	| Verificar se o usuário consegue ter acesso às materias publicadas com visualização correta e otimizada e com funcionamento correto dos links. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://aindavamoshospedar.html<br> - no menu principal clicar em  "PUBLICAÇÕES" <br> - Ser direcionado para a página https://aindavamoshospedar.html, onde encontrará a relação de todas as publicações presentes no site; <br> - clicando no "leia mais" o usuário deverá ser direcionado para a página da matéria correspondente; |
|Critério de Êxito | - O usuário deve encontrar na página em questão, as matérias e ao clicar no "leia mais" deverá ser direcionado para a página da matéria completa. |
|  	|  	|
