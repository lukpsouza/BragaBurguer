using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Descrição resumida de UsuariosBD
/// </summary>
public class UsuariosBD
{

    public static int Inserir(Usuarios usu)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "INSERT INTO usuario(usu_nome, usu_senha, usu_ativo, usu_email)  VALUES( ?nome, ?senha, ?ativo, ?email);";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", usu.Nome));
            objComando.Parameters.Add(Mapped.Parameter("?senha", usu.Senha));
            objComando.Parameters.Add(Mapped.Parameter("?ativo", usu.Ativo));
            objComando.Parameters.Add(Mapped.Parameter("?email", usu.Email));
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

    public static Usuarios Login(string email, string senha)
    {
        try
        {
            Usuarios usu = null;
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader ObjDataReader;
            objConexao = Mapped.Connection();
            string sql = "Select * from usuario where usu_email = ?email and usu_senha = ?senha;";
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?senha", senha));
            objComando.Parameters.Add(Mapped.Parameter("?email", email));
            ObjDataReader = objComando.ExecuteReader();
            while (ObjDataReader.Read())
            {
                usu = new Usuarios
                {
                    Ativo = Convert.ToInt32(ObjDataReader["usu_ativo"]),
                    Codigo = Convert.ToInt32(ObjDataReader["usu_codigo"]),
                    Email = Convert.ToString(ObjDataReader["usu_email"]),
                    Nome = Convert.ToString(ObjDataReader["usu_nome"]),
                    Senha = Convert.ToString(ObjDataReader["usu_senha"])
                };
            }
            ObjDataReader.Close();
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            ObjDataReader.Dispose();
            return usu;
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
        string sql = "select * from usuario order by usu_nome";
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

        string sql = "select * from usuario where usu_codigo = ?id";
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

            string sql = "delete from usuario where usu_codigo = ?id";
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


    public static int Update(Usuarios u)
    {
        int retorno = 0; // OK

        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "UPDATE usuario SET usu_nome = ?nome, usu_email = ?email, usu_senha = ?senha WHERE usu_codigo = ?codigo;";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?nome", u.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?email", u.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", u.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", u.Codigo));
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