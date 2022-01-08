using BL.DTO;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface IHeadphones : IProduct
    {
        IEnumerable<HeadphonesDTO> GetHeadphonesByType(string headType);                  // Получить наушники по их типу
        IEnumerable<HeadphonesDTO> GetHeadphonesByConnectionType(string connectionType);  // Получить наушники по типу подключения
        IEnumerable<HeadphonesDTO> GetHeadphonesByFasteningType(string fasteningType);    // Получить наушники по типу крепления
    }
}
