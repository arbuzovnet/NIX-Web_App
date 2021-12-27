using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    public interface IHeadphones : IProduct
    {
        IEnumerable<Product> GetHeadphonesByType(string headType);                  // Получить наушники по их типу
        IEnumerable<Product> GetHeadphonesByConnectionType(string connectionType);  // Получить наушники по типу подключения
        IEnumerable<Product> GetHeadphonesByFasteningType(string fasteningType);    // Получить наушники по типу крепления
    }
}
