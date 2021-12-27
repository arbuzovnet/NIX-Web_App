using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    public interface ICharger : IProduct
    {
        IEnumerable<Product> GetChargerByType(string chargerType);             // Получить зарядки по типу
        IEnumerable<Product> GetChargerByCableType(string chargerCableType);   // Получить зарядки по типу кабеля
        IEnumerable<Product> GetChargerByConnector(string chargerConnector);   // Получить заряки по типу кабеля
        IEnumerable<Product> GetChargerWithFastCharging();                     // Получить зарядки, поддерживающие быструю зарядку
    }
}
