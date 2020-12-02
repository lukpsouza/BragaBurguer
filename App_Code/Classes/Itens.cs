using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Itens
/// </summary>
public class Itens
{
    private int pro_ped_codigo;
    private Double pro_ped_valor;
    private int pro_ped_quantidade;

    private Produtos pro_codigo;
    private Pedidos ped_codigo;

    public int Pro_ped_codigo
    {
        get
        {
            return pro_ped_codigo;
        }

        set
        {
            pro_ped_codigo = value;
        }
    }

    public double Pro_ped_valor
    {
        get
        {
            return pro_ped_valor;
        }

        set
        {
            pro_ped_valor = value;
        }
    }

    public int Pro_ped_quantidade
    {
        get
        {
            return pro_ped_quantidade;
        }

        set
        {
            pro_ped_quantidade = value;
        }
    }

    public global::Produtos Pro_codigo
    {
        get
        {
            return pro_codigo;
        }

        set
        {
            pro_codigo = value;
        }
    }

    public global::Pedidos Ped_codigo
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
}