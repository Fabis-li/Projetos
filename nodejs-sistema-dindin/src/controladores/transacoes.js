const pool = require("../conexao");

const listarTransacoes = async (req, res) => {
  const { id } = req.usuario.rows[0];
  const { filtro } = req.query;

  let queryFiltro =
    "select t.*, c.descricao as categoria_nome  from transacoes t inner join categorias c on t.categoria_id = c.id where c.descricao ilike any ($1) and usuario_id=$2;";

  let params = [filtro, id];

  if (!filtro) {
    queryFiltro = "select * from transacoes where usuario_id=$1";
    params = [id];
  }

  try {
    const filtroCategoria = await pool.query(queryFiltro, params);

    return res.status(200).json(filtroCategoria.rows);
  } catch (error) {
    return res.status(500).json({ Mensagem: "Erro interno do servidor." });
  }
};

const detalharTransacao = async (req, res) => {
  const { id: idUsuario } = req.usuario.rows[0];
  const { id: idTransacao } = req.params;

  if (!idTransacao || isNaN(idTransacao)) {
    return res
      .status(400)
      .json({ Mensagem: "Número de transação inexistente ou inválido." });
  }

  try {
    const transacaoDetalhada = await pool.query(
      "select * from transacoes where id = $1 and usuario_id = $2;",
      [idTransacao, idUsuario]
    );

    if (transacaoDetalhada.rowCount === 0) {
      return res.status(400).json({ Mensagem: "Transação não encontrada." });
    }

    return res.status(200).json(transacaoDetalhada.rows);
  } catch (error) {
    return res.status(500).json({ Mensagem: "Erro interno do servidor" });
  }
};

const cadastrarTransacao = async (req, res) => {
  const { id: idUsuario } = req.usuario.rows[0];
  const { descricao, valor, data, categoria_id, tipo } = req.body;

  if (!descricao || !valor || !data || !categoria_id || !tipo) {
    return res.status(400).json({
      Mensagem:
        "Os campos descricao, valor, data, categoria_id e tipo são obrigatórios.",
    });
  }

  if (tipo !== "entrada" && tipo !== "saida") {
    return res
      .status(400)
      .json({ Mensagem: `O campo tipo deve ser entrada ou saida.` });
  }

  try {
    const verificarCategoria = await pool.query(
      "select * from categorias where id = $1;",
      [categoria_id]
    );

    if (verificarCategoria.rowCount === 0) {
      return res.status(404).json({
        Mensagem: "Esta categoria não existe. Por favor, informe outra.",
      });
    }

    try {
      const cadastroTransacao = await pool.query(
        "insert into transacoes (descricao, valor, data, categoria_id, tipo, usuario_id) values ($1, $2, $3, $4, $5, $6) returning *;",
        [descricao, valor, data, categoria_id, tipo, idUsuario]
      );

      const nomeCategoria = await pool.query(
        "select * from categorias where id=$1;",
        [categoria_id]
      );

      return res.status(201).json({
        id: cadastroTransacao.rows[0].id,
        tipo,
        descricao,
        valor,
        data,
        usuario_id: idUsuario,
        categoria_id,
        categoria_nome: nomeCategoria.rows[0].descricao,
      });
    } catch (error) {
      console.log(error.message);
      return res.status(500).json({ Mensagem: "Erro ao cadastrar transação." });
    }
  } catch (error) {
    return res.status(500).json({ Mensagem: "Erro interno do servidor." });
  }
};

const atualizarTransacao = async (req, res) => {
  const { id: IdUsuario } = req.usuario.rows[0];
  const { id } = req.params;
  const { descricao, valor, data, categoria_id, tipo } = req.body;

  if (!descricao || !valor || !data || !categoria_id || !tipo) {
    return res.status(400).json({
      Mensagem: "Todos os campos obrigatórios devem ser informados.",
    });
  }

  if (!id || isNaN(id)) {
    return res
      .status(400)
      .json({ Mensagem: "Número de transação inexistente ou inválido." });
  }

  if (tipo !== "entrada" && tipo !== "saida") {
    return res
      .status(400)
      .json({ Mensagem: "O campo tipo deve ser entrada ou saida." });
  }

  try {
    const transacao = await pool.query(
      "select * from transacoes where id = $1 and usuario_id = $2;",
      [id, IdUsuario]
    );

    if (!transacao.rowCount === 0) {
      return res.status(404).json({ Mensagem: "Transação não encontrada." });
    }

    const verificarCategoria = await pool.query(
      "select * from categorias where id = $1;",
      [categoria_id]
    );

    if (verificarCategoria.rowCount === 0) {
      return res.status(404).json({
        Mensagem: "Esta categoria não existe. Por favor, informe outra.",
      });
    }

    try {
      const atualizaTransacao = await pool.query(
        "update transacoes set descricao = $1, valor = $2, data = $3, categoria_id = $4, tipo = $5 where id = $6 and usuario_id = $7 returning *;",
        [descricao, valor, data, categoria_id, tipo, id, IdUsuario]
      );

      return res.status(200).json({
        mensagem: "Transação atualizada com sucesso.",
      });
    } catch (error) {
      return res.status(500).json({ Mensagem: "Erro ao atualizar transação." });
    }
  } catch (error) {
    return res.status(500).json({ Mensagem: "Erro interno do servidor." });
  }
};

const excluirTransacao = async (req, res) => {
  const { id } = req.usuario.rows[0];
  const { id: idTransacao } = req.params;

  if (!idTransacao || isNaN(idTransacao)) {
    return res
      .status(400)
      .json({ Mensagem: "Número de transação inexistente ou inválido." });
  }

  try {
    const transacao = await pool.query(
      "select * from transacoes where id = $1 and usuario_id = $2;",
      [idTransacao, id]
    );

    if (transacao.rowCount === 0) {
      return res.status(404).json({ Mensagem: "Transação não encontrada." });
    }

    try {
      await pool.query("delete from transacoes where id = $1;", [idTransacao]);

      return res.status(200).json({ Mensagem: "Transação deletada." });
    } catch (error) {
      return res.status(500).json({ Mensagem: "Erro ao deletar transação." });
    }
  } catch (error) {
    return res.status(500).json({ Mensagem: "Erro interno do servidor." });
  }
};

const extratoUsuario = async (req, res) => {
  const { id: idUser } = req.usuario.rows[0];

  try {
    const entrada = await pool.query(
      "select sum(valor) from transacoes where usuario_id = $1 and tipo = 'entrada';",
      [idUser]
    );

    let entradaSoma = Number(entrada.rows[0].sum);
    if (entrada.rowCount === 0) {
      entradaSoma = 0;
    }

    const saida = await pool.query(
      "select sum(valor) from transacoes where usuario_id = $1 and tipo = 'saida';",
      [idUser]
    );

    let saidaSoma = Number(saida.rows[0].sum);

    if (saida.rowCount === 0) {
      saidaSoma = 0;
    }

    return res.status(200).json({ entrada: entradaSoma, saida: saidaSoma });
  } catch (error) {
    console.log(error.message);
    return res.status(500).json({ Mensagem: "Erro interno do servidor." });
  }
};

module.exports = {
  listarTransacoes,
  detalharTransacao,
  cadastrarTransacao,
  atualizarTransacao,
  excluirTransacao,
  extratoUsuario,
};
