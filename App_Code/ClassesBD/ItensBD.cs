using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descrição resumida de ClientesBD
/// </summary>
public class ItensBD
{

    public static int Inserir(Itens it)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "INSERT INTO produtos_pedido(pro_ped_valor, pro_ped_quantidade, pro_codigo, ped_codigo) VALUES( ?pro_ped_valor, ?pro_ped_quantidade, ?pro_codigo, ?ped_codigo);";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pro_ped_valor", it.Pro_ped_valor));
            objComando.Parameters.Add(Mapped.Parameter("?pro_ped_quantidade", it.Pro_ped_valor));
            objComando.Parameters.Add(Mapped.Parameter("?pro_codigo", it.Pro_codigo.Codigo));
            objComando.Parameters.Add(Mapped.Parameter("?ped_codigo", it.Ped_codigo.Ped_codigo));
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

    public static Itens Itens(string valor, string quantidade)
    {
        try
        {
            Itens it = null;
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader ObjDataReader;
            objConexao = Mapped.Connection();
            string sql = "Select * from itens where pro_ped_valor = ?valor and pro_ped_quantidade = ?pro_ped_quantidade;";
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pro_ped_valor", valor));
            objComando.Parameters.Add(Mapped.Parameter("?pro_ped_quantidade", quantidade));
            ObjDataReader = objComando.ExecuteReader();
            while (ObjDataReader.Read())
            {
                it = new Itens
                {
                    Pro_ped_codigo = Convert.ToInt32(ObjDataReader["pro_ped_codigo"]),
                    Pro_ped_valor = Convert.ToDouble(ObjDataReader["pro_ped_valor"]),
                    Pro_ped_quantidade = Convert.ToInt32(ObjDataReader["pro_ped_codigo"]),
                };
            }
            ObjDataReader.Close();
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            ObjDataReader.Dispose();
            return it;
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
        string sql = "select * from produtos_pedido";
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
        string sql = "Select p.pro_codigo, p.ped_codigo, p.pro_ped_codigo, p.pro_ped_valor, p.pro_ped_quantidade, pro.pro_nome from produtos_pedido p inner join produto pro on p.pro_codigo = pro.pro_codigo;";
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

        string sql = "select * from produtos_pedido where pro_ped_codigo = ?id";
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

            string sql = "delete from produtos_pedido where pro_ped_codigo = ?id";
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


    public static int Update(Itens it)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "UPDATE produtos_pedido SET pro_ped_valor = ?pro_ped_valor, pro_ped_quantidade = ?pro_ped_quantidade, pro_codigo = ?pro_codigo, ped_codigo = ?ped_codigo WHERE pro_ped_codigo = ?pro_ped_codigo;";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pro_ped_valor", it.Pro_ped_valor));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_ped_quantidade", it.Pro_ped_quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", it.Pro_codigo.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_codigo", it.Ped_codigo.Ped_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_ped_codigo", it.Pro_ped_codigo));
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