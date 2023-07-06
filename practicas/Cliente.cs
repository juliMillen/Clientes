using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicas
{
    class Cliente
    {
        private double costoBase;
        public int NroCliente { get; set; }
        public int HorasTotalesTrabajadas { get; set; }
        public int CantidadDeServicios { get; set; }
        public double CostoTotal { get; set; }

        public Cliente(int nro, double costoBase)
        {
            NroCliente = nro;
            this.costoBase = costoBase;
            //incializo variables
            HorasTotalesTrabajadas = 0;
            CantidadDeServicios = 0;
            CostoTotal = 0;
        }

        public void AgregarServicio(int horas, int empleados)
        {
            if (CantidadDeServicios <= 5)
            {
                if (horas <= 2)
                {
                    HorasTotalesTrabajadas += horas;
                    CostoTotal += costoBase + (450 * horas);
                }
                else if (horas > 2 && horas <= 4)
                {
                    HorasTotalesTrabajadas += horas;
                    CostoTotal += costoBase + (400 * horas) + (empleados * 0.84);
                }
                else
                {
                    HorasTotalesTrabajadas += horas;
                    CostoTotal += costoBase + (380 * horas) + (empleados * 0.73);
                }
            }
            CantidadDeServicios++;
        }

        public bool TieneServiciosRealizados()
        {
            bool tieneServicio = false;
            if (CantidadDeServicios > 0)
            {
              tieneServicio = true;
            }
            return tieneServicio;
        }

        public double PromedioHorasTrabajadas()
        {
            if (CantidadDeServicios == 0)
            {
                return 0;
            }
            else
            {
                return HorasTotalesTrabajadas / CantidadDeServicios;       //salvo division por 0
            }
            
        }
    }
}
