using BL.DTO;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface ISmartphone : IProduct<SmartphoneDTO>
    {
        IEnumerable<SmartphoneDTO> GetSmartphoneByBuiltMemory(int builtMemory);           // Получить смартфоны по количеству встроенной памяти
        IEnumerable<SmartphoneDTO> GetSmartphoneByRAM(int ram);                           // Получить смартфоны по количесту ОЗУ
        IEnumerable<SmartphoneDTO> GetSmartphoneByMatrixType(string matrixType);          // Получить смартфоны по типу матрицы
        IEnumerable<SmartphoneDTO> GetSmartphoneByResolution(string resolution);          // Получить смартфоны по разрешению экрана
        IEnumerable<SmartphoneDTO> GetSmartphoneByOS(string os);                          // Получить смартфоны по типу ОС
    }
}
