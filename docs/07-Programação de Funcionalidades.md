# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

<!--Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Nesta seção, é essencial relacionar os requisitos atendidos com os artefatos criados (código fonte) e com o(s) responsável(is) pelo desenvolvimento de cada artefato a cada etapa. Nesta seção também deverão ser apresentadas, se necessário, as instruções para acesso e verificação da **implementação que deve estar funcional no ambiente de hospedagem obrigatoriamente a partir da Etapa 03**.

Por exemplo: a tabela a seguir deverá ser preenchida considerando os artefatos desenvolvidos.-->

|ID    | Descrição do Requisito  | Artefatos produzidos | Alunos(as) responsáveis |
|------|-----------------------------------------|----|----|
|RF-001| Pesquisar igrejas e horários de missas por geolocalização| \PortalCatolicoBrasil\Controllers\IgrejaController.cs<br>\PortalCatolicoBrasil\Models\Igreja.cs<br>\PortalCatolicoBrasil\wwwroot\js\site.js<br>\PortalCatolicoBrasil\wwwroot\css\site.css<br>\PortalCatolicoBrasil\Views\Home\Index.cshtml<br>\PortalCatolicoBrasil\Views\Igreja\ResultadoPesquisa.cshtml  | Paulo Carvalho e João Leite|
|RF-002| Trazer informações de Liturgia e homilia do dia| \PortalCatolicoBrasil\Controllers\LiturgiaController.cs<br>\PortalCatolicoBrasil\Service\LiturgiaService.cs<br>\PortalCatolicoBrasil\Views\Home\Liturgia.cshtml<br>\PortalCatolicoBrasil\wwwroot\css\site.css<br>\PortalCatolicoBrasil\wwwroot\js\site.js | Paulo Carvalho |
|RF-003| Pesquisar eventos paroquiais cadastrados pelas igrejas | \PortalCatolicoBrasil\Controllers\EventosController.cs<br>\PortalCatolicoBrasil\Models\Evento.cs<br>\PortalCatolicoBrasil\Views\Evento\Create.cshtml<br>\PortalCatolicoBrasil\Views\Evento\Eventos.cshtml<br>\PortalCatolicoBrasil\wwwroot\js\site.js<br>\PortalCatolicoBrasil\wwwroot\css\site.css | Estevão Silva e Gabriel Silva |
|RF-004| Disponibilizar espaços para publicidades pagas | \PortalCatolicoBrasil\Views\Home\Index.cshtml<br>( Adicionado aqui a página principal pois este requisito está presente em 90% das telas desenvolvidas )  | Todos |
|RF-005| Enviar formulário para Cadastro de Paróquias e Missas | \PortalCatolicoBrasil\Controllers\IgrejaController.cs<br>\PortalCatolicoBrasil\Models\Igreja.cs<br>\PortalCatolicoBrasil\wwwroot\js\site.js<br>\PortalCatolicoBrasil\wwwroot\css\site.css<br>\PortalCatolicoBrasil\Views\Igreja\Create.cshtml  | Paulo Carvalho e João Leite |
|RF-006| Enviar formulário sobre os eventos das paróquias| \PortalCatolicoBrasil\Controllers\EventosController.cs<br>\PortalCatolicoBrasil\Models\Evento.cs<br>\PortalCatolicoBrasil\Views\Evento\Create.cshtml<br>\PortalCatolicoBrasil\wwwroot\js\site.js<br>\PortalCatolicoBrasil\wwwroot\css\site.css  | Estevão Silva e Gabriel Silva  |
|RF-008| Trazer informações do Santo do dia| \PortalCatolicoBrasil\Controllers\SantoDiaController.cs<br>\PortalCatolicoBrasil\Models\SantoDia.cs<br>\PortalCatolicoBrasil\Views\Home\SantoDia.cshtml<br>\PortalCatolicoBrasil\wwwroot\js\site.js<br>\PortalCatolicoBrasil\wwwroot\css\site.css | Tobias Domingos |
|RF-009| Trazer Publicações de temas relevantes do cenário católico| \PortalCatolicoBrasil\Views\Home\Publicacoes.cshtml<br>\PortalCatolicoBrasil\Views\Home\PrimeiraPublicacao.cshtml<br>\PortalCatolicoBrasil\Views\Home\SegundaPublicacao.cshtml<br>\PortalCatolicoBrasil\wwwroot\js\site.js<br>\PortalCatolicoBrasil\wwwroot\css\site.css | Thainá Bernardes |



# Instruções de acesso

|ID    | Descrição do Requisito  | Link |
|------|-----------------------------------------|----|
|RF-001| Pesquisar igrejas e horários de missas por geolocalização| Colocar link hospedado  | 
|RF-002| Trazer informações de Liturgia e homilia do dia| Colocar link hospedado | 
|RF-003| Pesquisar eventos paroquiais cadastrados pelas igrejas | Colocar link hospedado  | 
|RF-004| Disponibilizar espaços para publicidades pagas | Colocar link hospedado  | 
|RF-005| Enviar formulário para Cadastro de Paróquias e Missas | Colocar link hospedado  | 
|RF-006| Enviar formulário sobre os eventos das paróquias| Colocar link hospedado  | 
|RF-008| Trazer informações do Santo do dia| Colocar link hospedado | 
|RF-009| Trazer Publicações de temas relevantes do cenário católico| Colocar link hospedado |


<!--Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Se houver usuário de teste, o login e a senha também deverão ser informados aqui (por exemplo: usuário - admin / senha - admin).

O link e o usuário/senha descritos acima são apenas exemplos de como tais informações deverão ser apresentadas.

> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
-->
