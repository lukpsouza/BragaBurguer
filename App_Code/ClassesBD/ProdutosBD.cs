using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ProdutosBD
{

    public static int Inserir(Produtos pro)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "INSERT INTO produto(pro_codigo, pro_nome, pro_descricao, pro_valor) VALUES(0, ?nome, ?descricao, ?valor);";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", pro.Nome));
            objComando.Parameters.Add(Mapped.Parameter("?descricao", pro.Descricao));
            objComando.Parameters.Add(Mapped.Parameter("?valor", pro.Valor));
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

    public static Produtos Produtos (string nome, string descricao)
    {
        try
        {
            Produtos pro = null;
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader ObjDataReader;
            objConexao = Mapped.Connection();
            string sql = "Select * from produto where pro_nome = ?nome and pro_descricao = ?descricao;";
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", nome));
            objComando.Parameters.Add(Mapped.Parameter("?descricao", descricao));
            ObjDataReader = objComando.ExecuteReader();
            while (ObjDataReader.Read())
            {
                pro = new Produtos
                {
                    Codigo = Convert.ToInt32(ObjDataReader["pro_codigo"]),
                    Nome = Convert.ToString(ObjDataReader["pro_nome"]),
                    Descricao = Convert.ToString(ObjDataReader["pro_descricao"]),
                    Valor = Convert.ToDouble(ObjDataReader["pro_valor"]),
                };
            }
            ObjDataReader.Close();
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            ObjDataReader.Dispose();
            return pro;
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
        string sql = "select * from produto";
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

        string sql = "select * from produto where pro_codigo = ?id";
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

            string sql = "delete from produto where pro_codigo = ?id";
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


    public static int Update(Produtos p)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "UPDATE produto SET pro_nome = ?nome, pro_descricao = ?descricao, pro_valor = ?valor WHERE pro_codigo = ?codigo;";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?nome", p.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", p.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?valor", p.Valor));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", p.Codigo));
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