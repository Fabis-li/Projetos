const pool = require("../conexao");
const bcrypt = require("bcrypt");

const cadastrarUsuario = async (req, res) => {
  const { nome, email, senha } = req.body;

  if (!nome || !email || !senha) {
    return res
      .status(400)
      .json({ Mensagem: "Os campos nome, email e senha são obrigatórios." });
  }

  try {
    const verificarEmailExiste = await pool.query(
      "select * from usuarios where email = $1",
      [email]
    );

    if (verificarEmailExiste.rowCount > 0) {
      return res.status(400).json({
        Mensagem: "Este email já existe. Por favor, cadastre outro email.",
      });
    }

    try {
      const senhaCriptografada = await bcrypt.hash(senha, 10);

      const resultadoUsuario = await pool.query(
        "insert into usuarios (nome, email, senha) values ($1, $2,$3) returning *",
        [nome, email, senhaCriptografada]
      );

      const { senha: senhaUsuario, ...usuarioCadastrado } =
        resultadoUsuario.rows[0];

      return res.status(201).json(usuarioCadastrado);
    } catch (error) {
      console.log(error.message);
      return res
        .status(500)
        .json({ Mensagem: "Erro interno ao cadastrar usuário no servidor" });
    }
  } catch (error) {
    return res
      .status(500)
      .json({ Mensagem: "Erro de conexão com o banco de dados." });
  }
};

const detalharUsuario = (req, res) => {
  const usuario = req.usuario;

  const { senha, ...usuarioDetalhado } = usuario.rows[0];

  return res.status(200).json(usuarioDetalhado);
};

const editarUsuario = async (req, res) => {
  const usuario = req.usuario;
  const { id } = usuario.rows[0];

  const { nome, email, senha } = req.body;

  if (!nome || !email || !senha) {
    return res
      .status(400)
      .json({ Mensagem: "Nome, email e senha são obrigatórios." });
  }

  try {
    const verificarEmailExiste = await pool.query(
      "select * from usuarios where email = $1 and id != $2",
      [email, id]
    );

    if (verificarEmailExiste.rowCount > 0) {
      return res.status(200).json({
        Mensagem:
          "Este email já está cadastrado em outro usuário. Por favor, cadastre outro email.",
      });
    }

    const senhaCriptografada = await bcrypt.hash(senha, 10);

    try {
      const usuarioAtualizado = await pool.query(
        "update usuarios set nome = $1, email = $2, senha = $3 where id = $4 returning *;",
        [nome, email, senhaCriptografada, id]
      );

      return res.status(200).json();
    } catch (error) {
      return res
        .status(500)
        .json({ Mensagem: "Erro ao atualizar dados do usuário." });
    }
  } catch (error) {
    return res.status(500).json({ Mensagem: "Erro interno do servidor." });
  }
};

module.exports = { cadastrarUsuario, detalharUsuario, editarUsuario };
