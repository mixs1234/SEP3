using System.Collections.Generic;
using System.Threading.Tasks;
using web.Model;

namespace web.Services;

public interface IArchiveStatusService
{
    Task<List<ArchiveStatus>> GetArchiveStatusesAsync();
}