using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descrição resumida de ClientesBD
/// </summary>
public class PedidosBD
{

    public static int Inserir(Pedidos ped)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "INSERT INTO pedido( ped_data, ped_frete, ped_tempo, usu_codigo, cli_codigo) VALUES( ?ped_data, ?ped_frete, ?ped_tempo, ?usu_codigo, ?cli_codigo);";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?ped_data", ped.Ped_data));
            objComando.Parameters.Add(Mapped.Parameter("?ped_frete", ped.Ped_frete));
            objComando.Parameters.Add(Mapped.Parameter("?ped_tempo", ped.Ped_tempo));
            objComando.Parameters.Add(Mapped.Parameter("?usu_codigo", ped.Usu_codigo.Codigo));
            objComando.Parameters.Add(Mapped.Parameter("?cli_codigo", ped.Cli_codigo.Codigo));
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

    public static Pedidos Pedidos(string data, string frete)
    {
        try
        {
            Pedidos ped = null;
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader ObjDataReader;
            objConexao = Mapped.Connection();
            string sql = "Select * from pedidos where ped_data = ?data and ped_frete = ?frete;";
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?data", data));
            objComando.Parameters.Add(Mapped.Parameter("?frete", frete));
            ObjDataReader = objComando.ExecuteReader();
            while (ObjDataReader.Read())
            {
                ped = new Pedidos
                {
                    Ped_codigo = Convert.ToInt32(ObjDataReader["ped_codigo"]),
                    Ped_data = Convert.ToString(ObjDataReader["ped_data"]),
                    Ped_frete = Convert.ToString(ObjDataReader["ped_frete"]),
                    Ped_tempo = Convert.ToString(ObjDataReader["ped_tempo"])
                };
            }
            ObjDataReader.Close();
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            ObjDataReader.Dispose();
            return ped;
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
        string sql = "select * from pedido";
        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);
        adapter = Mapped.Adapter(objComando);
        adapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectJoinUsuario()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter adapter;
        string sql = "Select p.ped_codigo, p.ped_data, p.ped_frete, p.ped_tempo, p.cli_codigo, p.usu_codigo, u.usu_nome, c.cli_nome from usuario u inner join pedido p on p.usu_codigo = u.usu_codigo inner join cliente c on p.cli_codigo = c.cli_codigo;";
        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);
        adapter = Mapped.Adapter(objComando);
        adapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }
    public static int Delete(int id)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "delete from pedido where ped_codigo = ?id";
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


    public static int Update(Pedidos pe)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "UPDATE pedido SET ped_data = ?ped_data, ped_frete = ?ped_frete, usu_codigo = ?usu_codigo, cli_codigo = ?cli_codigo, ped_tempo = ?ped_tempo WHERE ped_codigo = ?ped_codigo;";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?ped_data", pe.Ped_data));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_frete", pe.Ped_frete));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", pe.Usu_codigo.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?cli_codigo", pe.Cli_codigo.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_tempo", pe.Ped_tempo));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_codigo", pe.Ped_codigo));


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