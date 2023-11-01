
# Dindin

APIRest full com as seguintes funcionalidades:

- Cadastrar Usuário
- Fazer Login
- Detalhar Perfil do Usuário Logado
- Editar Perfil do Usuário Logado
- Listar categorias
- Listar transações
- Detalhar transação
- Cadastrar transação
- Editar transação
- Remover transação
- Obter extrato de transações
- [Extra] Filtrar transações por categoria

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto.

```git
clone o repositório - digite o seguinte comando
$ git clone -n https://github.com/Fabis-li/Projetos.git
```
navegue ate o diretorio baixado "Projetos",
dentro do diretorio digite o comando abaixo:
```git
clone o repositório - digite o seguinte comando
$ git checkout HEAD nodejs-sistema-dindin
```
confira se o projeto esta dentro do diretorio "Projetos"

Para instalar as dependencias use o comando abaixo:
```git
npm install
```

## 🛠 Tecnologias Usadas
- NodeJs 
- Javascript

### Bibliotecas utilizadas
- express
- pg
- bcrypt
- dotenv
- jsonwebtoken
- nodemon

Para usar a API, é necessário autenticar-se. Você deve obter um token JWT válido através do endpoint de login antes de acessar outros recursos. O token JWT deve ser incluído no cabeçalho de autorização de todas as solicitações subsequentes.



