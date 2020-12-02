using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Descrição resumida de Mapped
/// </summary>
public class Mapped
{
    public static IDbConnection Connection()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
        objConexao.Open();
        return objConexao;
    }

    public static IDbCommand Command(string query, IDbConnection ObjConexao)
    {
        IDbCommand command = ObjConexao.CreateCommand();
        command.CommandText = query;
        return command;
    }

    public static IDbDataParameter Parameter(string nomeParametro, object valor)
    {
        return new MySqlParameter(nomeParametro, valor);
    }

    public static IDataAdapter Adapter(IDbCommand command)
    {
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = command;
        return adap;
    }


}