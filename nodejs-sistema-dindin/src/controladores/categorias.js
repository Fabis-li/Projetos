const pool = require("../conexao");

const listarCategorias = async (req, res) => {
    
    try {
        const { rows: categorias } = await pool.query("select * from categorias");           
        return res.status(200).json(categorias);
    } catch (error) {
        return res.status(400).json({mensagen: "Categoria não encontrada."});
    }
}

module.exports = {
    listarCategorias
}