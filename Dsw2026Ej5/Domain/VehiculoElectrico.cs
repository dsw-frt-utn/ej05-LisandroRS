using System;
using System.Collections.Generic;
using System.Text;

/*Los vehículos eléctricos en promedio consumen 16 kWh cada 100 km recorridos.
Además, si su capacidad de carga supera los 1200 kg, debe sumarse un 15%
adicional al consumo. El valor promedio a futuro podría cambiar para nuevos
modelos.
*/

namespace Dsw2026Ej5.Domain;

public class VehiculoElectrico : Vehiculo
{
    private double kwhBase;

    public VehiculoElectrico(string patente, string marca, string modelo, int anio, double capacidadCarga, 
        Sucursal sucursal, double kwhBase) : base(VehiculoTipo.Electrico, patente, marca, modelo, anio, capacidadCarga, sucursal)
    {
        this.kwhBase = kwhBase;
    }

    public double GetKwhBase()
    {
        return kwhBase;
    }

    public override double CalcularConsumo(double kilometros)
    {
        double consumo = 0;

        if (GetCapacidadCarga() > 1200)
        {   
            consumo = kilometros* (kwhBase / 100);     
            consumo = consumo + (consumo * 0.15);
        } else
        {
            consumo = kilometros * (kwhBase / 100);
        }

        return consumo;
    }
}
