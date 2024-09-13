# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="01-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

<img src="../docs/img/Persona Portal Católico.png" width="700"/>
<img src="../docs/img/Persona Portal Católico (2).png" width="700"/>
<img src="../docs/img/Persona Portal Católico (3).png" width="700"/>
<br>

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|José Silva |Ter acesso rápido e pratico aos horários das missas mais próximas de mim, em qualquer lugar do Brasil que eu esteja,         | Para programar minha agenda e conseguir participar das celebrações com mais frequência.               |
|Secretário Paroquial     | Poder registrar informações sobre minha paróquia e seus horários de missas                 | Para que os fieis possam acessar as informações de maneira atualizada sobre a paroquia.|
|Lara Carvalho     | Acessar as leituras e a homilia do dia,                | Para que eu possa me manter integrada na vida católica. |
|Maria Helena     |Acessar informações sobre o Santo do Dia,                | Conhecer mais sobre os santos e interceder a eles nas minhas orações diárias. |
|Lara Carvalho    |Acessar artigos de como é feita a eleição do papa e demais temas religiosos,                | Incluir algumas informações na matéria que estou desenvolvendo no meu estágio. |
|Secretário Paroquial   |De um ambiente onde a paroquia possa divulgar de maneira gratuita os seus eventos,                | Que a comunidade possa participar e estar presente nas atividades religiosas e sociais. |
|Gestor de Marketing de uma farmácia   |Divulgar em um portal que haja alta visibilidade do meu publico alvo,                | Que possamos alavancar as vendas do nosso estabelecimento. |
<br>

## Requisitos

As tabelas a seguir detalham os requisitos funcionais, não funcionais e restrições do projeto. Para determinar a prioridade de cada requisito, foi utilizado a técnica MoSCoW, que classifica os requisitos em quatro categorias:

<ul>
    <li>Must have (Essenciais): Requisitos indispensáveis para o sucesso do projeto.</li>
    <li>Should have (Importantes): Requisitos importantes, mas que não são críticos.</li>
    <li>Could have (Desejáveis): Requisitos que agregam valor, mas não são prioritários.</li>
    <li>Won’t have (Não necessários agora): Requisitos que podem ser adiados ou excluídos.</li>
</ul>

Cada requisito foi avaliado e categorizado de acordo com seu impacto no objetivo do projeto e nas necessidades dos usuários. A técnica MoSCoW nos permitiu focar nos requisitos mais críticos, garantindo que o projeto atenda suas metas principais dentro dos recursos e prazos disponíveis.
<br>
<br>

### Requisitos Funcionais

|ID| Descrição                                                                                                                                                                                                                                                                                                                                                      | Prioridade e Justificativa |
|-------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----|
| RF-01 | <strong>Pesquisar igrejas e horários de missas por geolocalização</strong> <p> <li>Implementar uma funcionalidade de busca que permita aos usuários encontrar igrejas e horários de missas baseados na geolocalização.</li> <p> <li>Desenvolver um sistema de CRUD para gerenciamento das informações de igrejas e missas no banco de dados colaborativo.</li> | <strong>Essencial</strong> <p>Principal funcionalidade do portal  | 
| RF-02 | <strong>Trazer informações de Liturgia e homilia do dia</strong> <p> <li>Exibir diariamente as informações de liturgia e homilia do dia, obtidas por meio de uma API confiável.</li>                                                                                                                                                                           | <strong>Essencial</strong> <p>Conteúdo diário importante para os usuários.  |
| RF-03 | <strong>Pesquisar eventos paroquiais cadastrados pelas igrejas</strong> <p> <li>Implementar uma funcionalidade de busca que permita aos usuários encontrar os eventos paroquiais cadastrados pelas igrejas com endereço, data e local dos eventos, bem como link de direcionamento quando houver.</li>                                                                                                                                | <strong>Importante</strong> <p>Funcionalidade útil, mas não crítica para o projeto | 
| RF-04 | <strong>Disponibilizar espaços para publicidades pagas</strong> <p> <li>Desenvolver um espaço para exibição de publicidades pagas, com possibilidade de gerenciar anúncios e relatórios de desempenho.</li>                                                                                                                                                     | <strong>Desejável</strong> <p>Pode gerar receita, mas não é prioritário para o lançamento inicial. |
| RF-05 | <strong>Enviar formulário para Cadastro de Paróquias e Missas</strong> <p> <li>Criar um formulário para que os usuários enviem dados de suas paróquias e horários de missas. As informações serão validadas antes de serem inseridas no banco de dados.</li>                                                                                                   | <strong>Importante</strong> <p>Facilita a expansão do banco de dados de forma colaborativa, com possível suporte da PUC para o fornecimento ou colaboração nas cargas de dados. |
| RF-06 | <strong>Enviar formulário sobre os eventos das paróquias</strong> <p> <li>Disponibilizar um formulário para que as paróquias possam enviar detalhes sobre seus eventos, como festas, novenas e encontros.</li>                                                                                                                                                 | <strong>Importante</strong> <p>Facilita a divulgação de eventos, aumentando o engajamento da comunidade e a utilidade do portal. |
| RF-07 | <strong>Gerenciar informações do portal</strong> <p> <li>Desenvolver um módulo simples para que gestores/desenvolvedores possam gerenciar todas as informações do portal, incluindo usuários, conteúdos, anúncios e eventos.</li>                                                                                                                              | <strong>Essencial</strong> <p>Essencial para a manutenção e administração eficiente do portal, garantindo que todas as informações estejam atualizadas e corretas. |
| RF-08 | <strong>Trazer informações do Santo do dia</strong> <p> <li>Exibir os santos celebrados no dia correspondente à data da pesquisa</li> | <strong>Importante</strong> <p>Relevante para a experiência do usuário, mas não essencial para o funcionamento. |
| RF-09 |  <strong>Trazer Publicações de temas relevantes do cenário católico</strong> <p> <li>Implementar uma área para matérias relevantes com foco em temas católicos.</li> | <strong>Importante</strong> <p>Aumenta o engajamento; | 

**Prioridade: Essencial (Must have) / Importante (Should have) / Desejável (Could have).** 
<br>
<br>


### Requisitos não Funcionais

|ID      | Descrição               | Prioridade e Justificativa |
|--------|-------------------------|----|
| RNF-01 |  <strong>Compatibilidade e responsividade</strong> <p> <li>A aplicação deve ser responsiva, adaptando-se a diferentes tamanhos de tela e dispositivos, como celulares, tablets e desktops.</li> | <strong>Essencial</strong> <p>Garantir que o portal funcione bem em todos os dispositivos é crucial para oferecer uma boa experiência de usuário e atender às expectativas modernas de acessibilidade e usabilidade. |



**Prioridade: Essencial (Must have) / Importante (Should have) / Desejável (Could have).**
<br>
<br>

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir:

ID      | Restrição               |
|--------|-------------------------|
| 01 | Backend desenvolvido em C#.|
| 02 | Frontend desenvolvido com HTML, CSS e Bootstrap.|
| 03 | Necessidade do uso de pelo menos uma API.|
| 04 | Banco de dados MySQL, com implementação de 2 a 3 CRUD’s (por exemplo, para gestão de igrejas, missas e eventos).|
| 05 | Hospedagem na AWS ou Azure, com integração de SGBD (Sistema de Gerenciamento de Banco de Dados).|
| 06 | Conformidade com a LGPD para proteção de dados pessoais.|
| 07 | Autorização para uso de conteúdo externo, como liturgias e notícias.|
<br>
<br>

## Diagrama de Casos de Uso

<img src="../docs/img/Diagrama de Casos de Uso.jpeg">
