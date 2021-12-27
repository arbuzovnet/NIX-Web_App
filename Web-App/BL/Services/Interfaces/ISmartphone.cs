using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    public interface ISmartphone : IProduct
    {
        IEnumerable<Product> GetSmartphoneByBuiltMemory(int builtMemory);           // Получить смартфоны по количеству встроенной памяти
        IEnumerable<Product> GetSmartphoneByRAM(int ram);                           // Получить смартфоны по количесту ОЗУ
        IEnumerable<Product> GetSmartphoneByMatrixType(string matrixType);          // Получить смартфоны по типу матрицы
        IEnumerable<Product> GetSmartphoneByResolution(string resolution);          // Получить смартфоны по разрешению экрана
        IEnumerable<Product> GetSmartphoneByOS(string os);                          // Получить смартфоны по типу ОС
    }
}
