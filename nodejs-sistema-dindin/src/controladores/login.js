const pool = require("../conexao");
const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
const chaveSecreta = require("../chaveSecreta");

const login = async (req, res) => {
    try {
        const { email, senha } = req.body;

        if (!email || !senha) {
            return res.status(400).json({mensagem: "Preencha os obrigatórios: email e senha"});
        }

        const usuarioEncontrado = await pool.query("select * from usuarios where email = $1", [email]);
        if (usuarioEncontrado.rowCount === 0) {
            return res.status(400).json({mensagem: "Email e/ou senha inválido(s)."});
        }

        if(!await bcrypt.compare(senha, usuarioEncontrado.rows[0].senha)) {
            return res.status(400).json({mensagem: "Email e/ou senha inválido(s)."});
        }

        const {senha: senhaCriptografada, ...usuario} = usuarioEncontrado.rows[0];
        const token = jwt.sign(usuario, chaveSecreta, {expiresIn: "1d"});       
        
        return res.status(200).json({
            usuario,
            token
        });

    } catch (error) {
        return res.status(400).json({mensagem: "Usuário e/ou senha inválido(s)."});
    }
}

module.exports = {
    login
}