const jwt = require("jsonwebtoken");
const chaveSecreta = require("../chaveSecreta");
const pool = require("../conexao");

const autenticarUsuario = async (req, res, next) => {
  const { authorization } = req.headers;

  if (!authorization) {
    return res
      .status(401)
      .json({ Mensagem: "Token inválido ou usuário não tem permissão" });
  }

  const token = authorization.split(" ")[1];

  try {
    const tokenDescriptografado = jwt.verify(token, chaveSecreta);

    const { id } = tokenDescriptografado;

    const usuarioLogado = await pool.query(
      "select * from usuarios where id = $1;",
      [id]
    );

    if (usuarioLogado.rowCount === 0) {
      return res.status(400).json({
        Mensagem: "Este usuário não existe.",
      });
    }

    req.usuario = usuarioLogado;

    next();
  } catch (error) {
    return res.status(401).json({ Mensagem: "Token inválido ou expirado." });
  }
};

module.exports = autenticarUsuario;
