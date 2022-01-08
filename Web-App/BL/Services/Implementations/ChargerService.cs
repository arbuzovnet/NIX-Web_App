using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using DL.EF;
using DL.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BL.Services.Implementations
{
    public class ChargerService : ProductService, ICharger
    {
        public ChargerService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
            : base(applicationContext, loggerFactory, mapper)
        { }

        public IEnumerable<ChargerDTO> GetChargerByCableType(string chargerCableType)
        {
            if (!string.IsNullOrEmpty(chargerCableType))
            {
                return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.Cable == chargerCableType));
            }
            else
                return new List<ChargerDTO>();
        }

        public IEnumerable<ChargerDTO> GetChargerByConnector(string chargerConnector)
        {
            if (!string.IsNullOrEmpty(chargerConnector))
            {
                return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.Connector == chargerConnector));
            }
            else
                return new List<ChargerDTO>();
        }

        public IEnumerable<ChargerDTO> GetChargerByType(string chargerType)
        {
            if (!string.IsNullOrEmpty(chargerType))
            {
                return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.Type == chargerType));
            }
            else
                return new List<ChargerDTO>();
        }

        public IEnumerable<ChargerDTO> GetChargerWithFastCharging()
        {
            return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.FastCharging == true));
        }
    }
}
