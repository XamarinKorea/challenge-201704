/*
 * 소스코드 참조 : https://github.com/Microsoft/BikeSharing360_MobileApps/blob/master/src/BikeSharing.Clients.Core/DataServices/Base/RequestProvider.cs
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.DataServices.Base
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings serializerSettings;

        public RequestProvider()
        {
            //Json Serialize 초기값 설정
            serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            serializerSettings.Converters.Add(new StringEnumConverter());
        }

        /// <summary>
        /// 결과 값 가져오기
        /// </summary>
        /// <typeparam name="TResult">return type</typeparam>
        /// <param name="uri">Api uri</param>
        /// <returns>Json 결과를 TResult로 리턴</returns>
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, serializerSettings));

            return result;
        }

        /// <summary>
        /// HttpClient 초기화
        /// </summary>
        /// <returns>HttpClient Instance</returns>
        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        /// <summary>
        /// 네트웍 에러 핸들링
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(content);
            }
        }
    }
}
