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

 

