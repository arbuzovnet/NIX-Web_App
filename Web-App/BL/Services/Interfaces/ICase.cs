using BL.DTO;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface ICase : IProduct<CaseDTO>
    {
        IEnumerable<CaseDTO> GetCaseByType(string caseType);            // Получить чехол по типу
        IEnumerable<CaseDTO> GetCaseByColor(string caseColor);          // Получить чехол по цвету
        IEnumerable<CaseDTO> GetCaseByMaterial(string caseMaterial);    // Получить чехол по материалу
        IEnumerable<CaseDTO> GetCaseByModel(string caseModel);          // Получить чехол по совместимости с моделью
    }
}
