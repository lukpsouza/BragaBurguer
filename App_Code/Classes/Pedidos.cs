using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Pedidos
/// </summary>
public class Pedidos
{
    private int ped_codigo;
    private string ped_data;
    private string ped_frete;
    private string ped_tempo;
    private Clientes cli_codigo;
    private Usuarios usu_codigo;

    public int Ped_codigo
    {
        get
        {
            return ped_codigo;
        }

        set
        {
            ped_codigo = value;
        }
    }

    public string Ped_data
    {
        get
        {
            return ped_data;
        }

        set
        {
            ped_data = value;
        }
    }

    public string Ped_frete
    {
        get
        {
            return ped_frete;
        }

        set
        {
            ped_frete = value;
        }
    }


    public string Ped_tempo
    {
        get
        {
            return ped_tempo;
        }

        set
        {
            ped_tempo = value;
        }
    }

    public global::Clientes Cli_codigo
    {
        get
        {
            return cli_codigo;
        }

        set
        {
            cli_codigo = value;
        }
    }

    public global::Usuarios Usu_codigo
    {
        get
        {
            return usu_codigo;
        }

        set
        {
            usu_codigo = value;
        }
    }
}