using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    public interface ICase : IProduct
    {
        IEnumerable<Product> GetCaseByType(string caseType);            // Получить чехол по типу
        IEnumerable<Product> GetCaseByColor(string caseColor);          // Получить чехол по цвету
        IEnumerable<Product> GetCaseByMaterial(string caseMaterial);    // Получить чехол по материалу
        IEnumerable<Product> GetCaseByModel(string caseModel);          // Получить чехол по совместимости с моделью
    }
}
