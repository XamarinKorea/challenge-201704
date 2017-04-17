using Challenge201704.XamarinKorea.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge201704.XamarinKorea.Models;
using Challenge201704.XamarinKorea.DataServices.Base;

namespace Challenge201704.XamarinKorea.DataServices
{
    /// <summary>
    /// 사용자 정보 관련 Service class
    /// </summary>
    public class UserService : IUserService
    {
        private IRequestProvider requestProvider;
        public UserService(IRequestProvider provider)
        {
            requestProvider = provider;
        }

        /// <summary>
        /// 사용자 리스트 가져오기(페이지 단위)
        /// </summary>
        /// <param name="page">페이지 번호</param>
        /// <param name="results">사용자 리스트 반환갯수</param>
        /// <param name="seed">seed : seed 값이 동일한 경우 동일한 결과를 반환</param>
        /// <param name="isIncludeInfo">json 결과값에 includeinfo 포함 여부 : <c>true</c> includeinfo 포함; otherwise <c>false</c> includeinfo 제외 </param>
        /// <returns>사용자 리스트 </returns>
        public async Task<IList<User>> GetUsersAsync(int? page = 1, int? results = 10, string seed = "xamarinkorea", bool? isIncludeInfo = false)
        {
            var builder = new UriBuilder(AppSettings.UsersApiServer);
            builder.Path = "api/";
            string noinfo = (isIncludeInfo ?? false) ? "&noinfo" : string.Empty;
            string param =  $@"?page={page}&results={results}&seed={seed}" + noinfo;

            var uri = builder.ToString() + param;
            var users = await requestProvider.GetAsync<Users>(uri);
            return users.Results;
        }
    }
}
