using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;
using marketplace.Data.UnitOfWorkPattern;
using marketplace.DTO.Common;
using Microsoft.Extensions.Configuration;

namespace marketplace.Services.Common
{
    public class ImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(HinhAnh image)
        {
            try
            {
                await _unitOfWork.HinhAnhRepository.AddAsync(image);   
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}