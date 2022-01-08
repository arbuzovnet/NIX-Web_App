using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using DL.EF;
using DL.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BL.Services.Implementations
{
    public class HeadphonesService : ProductService, IHeadphones
    {
        public HeadphonesService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
            : base(applicationContext, loggerFactory, mapper)
        { }

        public IEnumerable<HeadphonesDTO> GetHeadphonesByConnectionType(string connectionType)
        {
            if (!string.IsNullOrEmpty(connectionType))
            {
                return mapper.Map<IEnumerable<Headphones>, IEnumerable<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.Find(n => n.Connection == connectionType));
            }
            else
                return new List<HeadphonesDTO>();
        }

        public IEnumerable<HeadphonesDTO> GetHeadphonesByFasteningType(string fasteningType)
        {
            if (!string.IsNullOrEmpty(fasteningType))
            {
                return mapper.Map<IEnumerable<Headphones>, IEnumerable<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.Find(n => n.Fastening == fasteningType));
            }
            else
                return new List<HeadphonesDTO>();
        }

        public IEnumerable<HeadphonesDTO> GetHeadphonesByType(string headType)
        {
            if (!string.IsNullOrEmpty(headType))
            {
                return mapper.Map<IEnumerable<Headphones>, IEnumerable<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.Find(n => n.Kind == headType));
            }
            else
                return new List<HeadphonesDTO>();
        }
    }
}
