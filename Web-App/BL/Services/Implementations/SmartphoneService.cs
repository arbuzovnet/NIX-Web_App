using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using DL.EF;
using DL.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BL.Services.Implementations
{
    public class SmartphoneService : ProductService, ISmartphone
    {
        public SmartphoneService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
            :base(applicationContext, loggerFactory, mapper)
        {        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByBuiltMemory(int builtMemory)
        {
            if (builtMemory > 0)
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.BuiltMemory == builtMemory));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByMatrixType(string matrixType)
        {
            if (!string.IsNullOrEmpty(matrixType))
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.Matrix == matrixType));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByOS(string os)
        {
            if (!string.IsNullOrEmpty(os))
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.OS == os));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByRAM(int ram)
        {
            if (ram > 0)
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.RAM == ram));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByResolution(string resolution)
        {
            if (!string.IsNullOrEmpty(resolution))
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.Resolution == resolution));
            }
            else
                return new List<SmartphoneDTO>();
        }
    }
}
