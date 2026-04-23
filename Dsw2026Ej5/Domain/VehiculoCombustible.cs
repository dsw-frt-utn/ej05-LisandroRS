using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej5.Domain;

/*Los vehículos a combustible recorren una determinada cantidad de kilómetros
por litro de combustible, pero si tienen más de 5 años de antigüedad se les suma
una determinada cantidad de litros extra cada 15 km recorridos*/

public class VehiculoCombustible: Vehiculo
{
    private double kilometrosPorLitro;
    private double litrosExtra;

    public VehiculoCombustible(string patente, string marca, string modelo, int anio, double capacidadCarga, 
        Sucursal sucursal, double kilometrosPorLitro, double litrosExtra) : base(VehiculoTipo.Combustible, patente, marca, modelo, anio, capacidadCarga, sucursal)
    {
        this.kilometrosPorLitro = kilometrosPorLitro;
        this.litrosExtra = litrosExtra;
    }

    public double GetKilometrosPorLitro()
    {
        return kilometrosPorLitro;
    }

    public double GetLitrosExtra()
    {
        return litrosExtra;
    }

    public override double CalcularConsumo(double kilometros)
    {
        DateTime fechaActual = DateTime.Now;
        int antiguedad = fechaActual.Year - GetAnio();
        double consumo = 0;

        if (antiguedad > 5)
        {
            consumo = (kilometros / kilometrosPorLitro) + ((kilometros / 15) * litrosExtra);
        }
        else
        {
            consumo = kilometros / kilometrosPorLitro;
        }

        return consumo;
    }
}
