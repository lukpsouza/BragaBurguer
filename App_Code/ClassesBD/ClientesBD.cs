using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descrição resumida de ClientesBD
/// </summary>
public class ClientesBD
{

    public static int Inserir(Clientes cli)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "INSERT INTO cliente(cli_nome, cli_telefone, cli_endereco, cli_quantidade) VALUES( ?nome, ?telefone, ?endereco, ?quantidade);";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", cli.Nome));
            objComando.Parameters.Add(Mapped.Parameter("?telefone", cli.Telefone));
            objComando.Parameters.Add(Mapped.Parameter("?endereco", cli.Endereco));
            objComando.Parameters.Add(Mapped.Parameter("?quantidade", cli.Quantidade));
            objComando.ExecuteNonQuery();
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();

        }
        catch (Exception ex)
        {
            erro = -2;
        }

        return erro;
    }

    public static Clientes Clientes (string nome, string telefone)
    {
        try
        {
            Clientes cli = null;
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader ObjDataReader;
            objConexao = Mapped.Connection();
            string sql = "Select * from cliente where cli_nome = ?nome and cli_telefone = ?telefone;";
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", nome));
            objComando.Parameters.Add(Mapped.Parameter("?telefone", telefone));
            ObjDataReader = objComando.ExecuteReader();
            while (ObjDataReader.Read())
            {
                cli = new Clientes
                {
                    Codigo = Convert.ToInt32(ObjDataReader["cli_codigo"]),
                    Nome = Convert.ToString(ObjDataReader["cli_nome"]),
                    Telefone = Convert.ToString(ObjDataReader["cli_telefone"]),
                    Endereco = Convert.ToString(ObjDataReader["cli_endereco"]),
                    Quantidade = Convert.ToString(ObjDataReader["cli_quantidade"])
                };
            }
            ObjDataReader.Close();
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            ObjDataReader.Dispose();
            return cli;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataSet SelecionarTodos()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter adapter;

        string sql = "SELECT cli_codigo, cli_nome, cli_telefone, cli_endereco, ";
        sql += "(SELECT COUNT(*) FROM pedido WHERE pedido.cli_codigo = cliente.cli_codigo) cli_quantidade ";
        sql += "FROM cliente";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);
        adapter = Mapped.Adapter(objComando);
        adapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectId(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;

        IDataAdapter objDataAdapter;

        string sql = "select * from cliente where cli_cliente = ?id";
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?id", id));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConnection.Close();
        objConnection.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static int Delete(int id)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "delete from cliente where cli_codigo = ?id";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));
            objCommand.ExecuteNonQuery();
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();

        }
        catch (Exception e)
        {

            retorno = -2;
        }
        return retorno;
    }


    public static int Update(Clientes c)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "UPDATE cliente SET cli_nome = ?nome, cli_telefone = ?telefone, cli_endereco = ?endereco, cli_quantidade = ?quantidade WHERE cli_codigo = ?codigo;";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?nome", c.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?telefone", c.Telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?endereco", c.Endereco));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", c.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?quantidade", c.Quantidade));

            objCommand.ExecuteNonQuery();
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
        }
        catch (Exception e)
        {

            retorno = -2;
        }
        return retorno;
    }

}