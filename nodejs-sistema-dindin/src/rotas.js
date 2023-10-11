const express = require("express");
const {
  cadastrarUsuario,
  detalharUsuario,
  editarUsuario,
} = require("./controladores/usuarios");
const { login } = require("./controladores/login");
const { listarCategorias } = require("./controladores/categorias");
const {
  listarTransacoes,
  detalharTransacao,
  cadastrarTransacao,
  atualizarTransacao,
  excluirTransacao,
  extratoUsuario,
} = require("./controladores/transacoes");

const rotas = express();

const autenticarUsuario = require("./intermediarios/autenticacao");

rotas.post("/usuario", cadastrarUsuario);
rotas.post("/login", login);

rotas.use(autenticarUsuario);

rotas.get("/usuario", detalharUsuario);
rotas.put("/usuario", editarUsuario);
rotas.get("/categoria", listarCategorias);
rotas.get("/transacao", listarTransacoes);
rotas.get("/transacao/extrato", extratoUsuario);
rotas.get("/transacao/:id", detalharTransacao);
rotas.post("/transacao", cadastrarTransacao);
rotas.put("/transacao/:id", atualizarTransacao);
rotas.delete("/transacao/:id", excluirTransacao);

module.exports = rotas;
