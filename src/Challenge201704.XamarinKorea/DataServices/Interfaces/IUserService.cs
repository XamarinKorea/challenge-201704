using Challenge201704.XamarinKorea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.DataServices.Interfaces
{
    /// <summary>
    /// UserService Interfce
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 사용자 리스트 가져오기(페이지 단위)
        /// </summary>
        /// <param name="page">페이지 번호</param>
        /// <param name="results">사용자 리스트 반환갯수</param>
        /// <param name="seed">seed : seed 값이 동일한 경우 동일한 결과를 반환</param>
        /// <param name="isIncludeInfo">json 결과값에 includeinfo 포함 여부 : <c>true</c> includeinfo 포함; otherwise <c>false</c> includeinfo 제외 </param>
        /// <returns>사용자 리스트 </returns>
        Task<IList<User>> GetUsersAsync(int? page = 1, int? results = 10,string seed = "xamarinkorea", bool? isIncludeInfo = false);
    }
}
