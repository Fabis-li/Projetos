# DEVinCourses-m3p2-back-end

Uso de fluent validations no projeto<br>
<h3>Beneficios</h3>
Concentração das validações em classes,<br>
Entidades como DTO`S e Models limpas,<br>
Facilitação para testes unitarios realcionados as validações.<br>
<br>
Construindo com Fluente Validations<br>
Por exemplo para validarmos a classe CarDTO,<br>
temos campos que são obrigatorio e com criterio,<br>
por exemplo o nome, que deve ser requirido junto com um tamanho minimo e maximo,<br>

<img src=https://user-images.githubusercontent.com/37316110/201797018-4993a76a-fe26-4244-ae7e-3ecca3be4ca5.png alt="Image" height="250" width="350">
<br>
Para isso criamos uma classe de validação,com o mesmo nome seguida do sufixo Validators para padronização do projeto<br>
onde chamaremos de CarDTOValidators<br>
<br>

<img src=https://user-images.githubusercontent.com/37316110/201799032-0e3cab74-9a9a-4442-92a2-ab984e640ef9.png alt="Image" height="450" width="650">

As regras mais comum são:<br>
NotNull,<br>
Null<br>
NotEmpty<br><br>
Empty<br>
NotEqual<br>
Equal<br>
MaxLength<br>
MinLenght<br>
Less Than<br>
Credit Card<br>
Email<br>
Emuitas mais no link -> https://docs.fluentvalidation.net/en/latest/built-in-validators.html <br>
Podendo ser criada validações personalizadas...<br>
<br>
Nossos testes de validação acabam sendo mais facilitados <br>


<img src=https://user-images.githubusercontent.com/37316110/201800954-0708018c-5c23-4d9c-b977-0e763510baa2.png alt="Image" height="750" width="750">
<Apos importarmos a classe que se deseja testar<br>
criamos uma propriedade de nosso CarDTOValidators como mostra a linha 13 chamada de validator<br>
depois passamos ela via construtor que no caso é o nosso Setup que quem faz o papel de construtor <br>
para podermos usar em nossos testes de forma que seja que instanciada <br>
então criamos um testCase e passamos como parametro para dentro do metodo testador validar nossa validação<br>

*****************************************************************************************************************************

O uso do Etheral.email para testar os serviços de SMTP <br>

1º entre no site do Etheral https://ethereal.email/  <br>
2º Clique em criar nova conta (Create Ethereal Account)<br>
3º Copie o nome de usuario gerado <br>
4º cole este nome em email from no serviceMail que esta em infra  email.From = new MailAddress("cole aqui o email");<br>
5º cole tambem no smtp.autenticate("cole aqui o email ", "cole aqui o password" )<br>
feito isso esta pronto seu smtp <br>
agora voçe pode verificar seus e-mails na proppria caixa do ethereal no botão (open mailbox)<br>
para saber mais fiz um video curto no link do you tube -> https://youtu.be/1SG6tyDQ9IM?t=8  <br>





    
