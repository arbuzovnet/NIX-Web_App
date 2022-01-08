using BL.DTO;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface ICharger : IProduct
    {
        IEnumerable<ChargerDTO> GetChargerByType(string chargerType);             // Получить зарядки по типу
        IEnumerable<ChargerDTO> GetChargerByCableType(string chargerCableType);   // Получить зарядки по типу кабеля
        IEnumerable<ChargerDTO> GetChargerByConnector(string chargerConnector);   // Получить заряки по типу кабеля
        IEnumerable<ChargerDTO> GetChargerWithFastCharging();                     // Получить зарядки, поддерживающие быструю зарядку
    }
}
