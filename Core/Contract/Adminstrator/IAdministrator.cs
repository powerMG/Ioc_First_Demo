using Core.InputModel;
using Core.ViewModel;
using Hesint.Lib.Models.ResultModel;
using Models;
using System.Threading.Tasks;

namespace Core.Contract
{
    /// <summary>
    /// 管理员信息
    /// </summary>
    public interface IAdministrator
    {
         Task<OpreationResult<Administrator>> LoginAsync(AdminLoginViewModel model);

        Task<OpreationResult> CreateOrUpdate(AdministratorDto dto);
    }
}
