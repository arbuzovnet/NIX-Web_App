using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using DL.EF;
using DL.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BL.Services.Implementations
{
    public class CaseService : ProductService, ICase
    {
        public CaseService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
            : base(applicationContext, loggerFactory, mapper)
        { }

        public IEnumerable<CaseDTO> GetCaseByColor(string caseColor)
        {
            if (!string.IsNullOrEmpty(caseColor))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.Color == caseColor));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCaseByMaterial(string caseMaterial)
        {
            if (!string.IsNullOrEmpty(caseMaterial))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.Material == caseMaterial));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCaseByModel(string caseModel)
        {
            if (!string.IsNullOrEmpty(caseModel))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.CompatibilityByModel == caseModel));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCaseByType(string caseType)
        {
            if (!string.IsNullOrEmpty(caseType))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.Type == caseType));
            }
            else
                return new List<CaseDTO>();
        }
    }
}
