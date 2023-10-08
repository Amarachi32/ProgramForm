using ProgramFormCore.Interfaces;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFormInfrastructure.Services
{
    public class PreviewService : IPreviewService
    {
        private readonly IRepository<Preview> _previewService;

        public PreviewService(IRepository<Preview> previewService)
        {
            _previewService = previewService;
        }

        public async Task<IEnumerable<Preview>> GetAllPreviewAsync()
        {
            return await _previewService.GetAllAsync();
        }

        public async Task<Preview> GetPreviewIdAsync(string id)
        {
            return await _previewService.GetByIdAsync(id);
        }
    }
}
