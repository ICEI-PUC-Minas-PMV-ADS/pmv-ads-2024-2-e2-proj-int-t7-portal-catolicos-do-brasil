# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso). <br><br>



| **Caso de Teste** 	| **CT-01 – Pesquisar igrejas e horários de missas por geolocalização** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - A aplicação deve implementar uma funcionalidade de busca que permita aos usuários encontrar igrejas e horários de missas baseados na geolocalização. |
|Resultado do teste | Teste executado com erro - Na opção "Missas" do menu principal não há um filtro para pesquisar as missas (como na página inícial), ao acessamos essa opção á página retorna a mensagem "Nenhuma igreja encontrada com os critérios informados." / O filtro da página inícial consegue fazer a consulta com sucesso, porém o Botão "Ver no Mapa" não está funcionando; / Um outro ponto de melhoria seria um espaçamento maior entre os cards com os resultados e não repetir os dias de missa para cada horário. O ídeal seria retornar o dia uma vez com todos os horário para aquela dia. Ex.: Domingo - 07:00, 09:00, 18:00 e 19:00 |
|Registro de evidência | [Vídeo do teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Teste%20busca%20Igrejas%20e%20Missas.mp4)|

| **Caso de Teste** 	| **CT-02 – Trazer informações de Liturgia e homilia do dia** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-002 - A aplicação deve permitir a exibição diaria das informações de liturgia e homilia do dia, obtidas por meio de uma API confiável. |
|Resultado do teste | Teste executado com êxito - O teste foi realizado corretamente. A 1ª Leitura, o Salmo, a 2ª Leitura e o Evangelho estão sendo exibidos de forma adequada, conforme o dia em que o usuário está acessando, retornando o conteúdo correto a cada dia. A Homilia apresenta um vídeo fixo, integrado ao YouTube, funcionando perfeitamente.  |
|Registro de evidência | [Vídeo do teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/aabdac5a03d2cd8f2f37d372fb7b77fa2300182b/presentation/Teste%20exibir%20Homilia%20e%20Liturgia.mp4) |

| **Caso de Teste** 	| **CT-03 – Pesquisar eventos paroquiais cadastrados pelas igrejas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-003 - A aplicação deve permitir aos usuários ter acesso aos eventos paroquiais das igrejas que os cadastrarem para serem divulgados. |
|Resultado do teste | Teste executado com erro - No teste realizado, foram identificados os seguintes erros: os dropdowns de estado e cidade não retornam as opções corretamente, o botão "Buscar" não redireciona pois não recupera os dados selecionados, o botão "Pesquisar por minha localização" está desabilitado devido à ausência de localização geográfica, e os cards não seguem o layout padrão da aplicação, apresentando problemas em bordas arredondadas, fontes e dimensões. |
|Registro de evidência | [Vídeo teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Teste%20Pesquisa%20Eventos.mp4) |

| **Caso de Teste** 	| **CT-04 – Disponibilizar espaços para publicidades pagas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-004 - A aplicação apresentar espaços para exibição de publicidades pagas, com um CRUD para gerenciar tais inserções. |
|Resultado do teste | Teste executado com êxito - O teste foi realizado corretamente. As páginas necessárias contém suas devidas seções de publicidade. |
|Registro de evidência | [Vídeo teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Teste%20Publicidades.mp4) |

| **Caso de Teste** 	| **CT-05 – Enviar formulário para Cadastro de Paróquias e Missas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - A aplicação deve fornecer um formulário para as igrejas enviarem seus dados como nome, endereço, telefone, bem como dia e horário de suas missas, com um CRUD para gerenciamento dessas informações que deverá ser feito pelos administradores do site. |
|Resultado do teste | Teste executado com êxito |
|Registro de evidência | [Vídeo teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Teste%20formul%C3%A1rio%20para%20cadastro%20de%20par%C3%B3quias%20e%20missas.mp4) |

| **Caso de Teste** 	| **CT-06 – Enviar formulário sobre os eventos das paróquias** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-006 - A aplicação deve fornecer um formulário para as igrejas divulgarem seus eventos pastorais com um CRUD para gerenciamento dessas informações que deverá ser gerenciado pelos administradores do site. |
|Resultado do teste | Teste executado com erro - A mascara de cadastro do telefone não está permitindo a inserção de telefone fixo, apresentando erro, só sendo possível o envio caso seja inserido o número "9" na frente / O ícone de localização do botão "Ver no mapa" está com as cores invertidas. O ícone deveria ser branco e fundo transparente ou da cor do botão |
|Registro de evidência | [Vídeo do Teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Teste%20Cadastro%20Eventos.mp4) |

| **Caso de Teste** 	| **CT-07 – Gerenciar informações do portal** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-007 - A aplicação deve fornecer um módulo simples para que gestores/desenvolvedores possam gerenciar todas as informações do portal, incluindo usuários, conteúdos, anúncios e eventos. |
|Resultado do teste | Teste executado com êxito |
|Registro de evidência | [Vídeo do teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Apresenta%C3%A7%C3%A3o%20Gerenciador%20Banco%20de%20Dados.mp4)|

| **Caso de Teste** 	| **CT-08 – Trazer informações do Santo do dia** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-008 - A aplicação deve Exibir os santos celebrados no dia correspondente à data da pesquisa.|
|Resultado do teste | Classificar "Teste executado com êxito" ou "Teste executado com erro (especificar o erro)" |
|Registro de evidência | Colocar o link do vídeo do teste (Estevão) |

| **Caso de Teste** 	| **CT-09 – Trazer Publicações de temas relevantes do cenário católico** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-009 - A aplicação deve Exibir matérias relevantes do cenário Católico.|
|Resultado do teste | Teste executado com êxito |
|Registro de evidência | [Video do teste](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-2-e2-proj-int-t7-portal-catolicos-do-brasil/blob/main/presentation/Teste%20Publica%C3%A7%C3%B5es.mp4) |

<br><br>

## Avaliação

Os testes dos casos CT-01, CT-03 e CT-06 apresentaram falhas. No CT-01, problemas foram identificados na funcionalidade de filtro de missas e no botão "Ver no Mapa". No CT-03, os dropdowns não funcionaram corretamente, e houve falhas no layout e nos botões de busca. No CT-06, a máscara de telefone não permite números fixos, e o ícone de localização apresenta cores invertidas.

Os casos CT-02, CT-04, CT-05, CT-07, CT-09 e CT-08 foram executados com sucesso, atendendo às especificações funcionais. Destaca-se a exibição correta de liturgia, homilia, publicidades, e o funcionamento adequado dos formulários de cadastro e gerenciamento do portal.

<!--
> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
-->
