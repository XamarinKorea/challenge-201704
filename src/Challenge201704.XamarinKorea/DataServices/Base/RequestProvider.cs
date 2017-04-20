/*
 * 소스코드 참조 : https://github.com/Microsoft/BikeSharing360_MobileApps/blob/master/src/BikeSharing.Clients.Core/DataServices/Base/RequestProvider.cs
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ModernHttpClient;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
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
            //HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (var httpClient = CreateHttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(20);
                    var cancelTokenSource = new CancellationTokenSource();
                    var cancelToken = cancelTokenSource.Token;

                    response = await httpClient.GetAsync(uri, cancelToken).ConfigureAwait(false);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error in: {ex}");
            }

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
            /*
                Mono 에서 SSL/TLS 관련 호출시 
                System.IO.IOException: The authentication or decryption has failed. 
                ---> Mono.Security.Protocol.Tls.TlsException: The authentication or decryption has failed. 에러 발생할 수 있음
                관련 이슈 : http://stackoverflow.com/questions/4926676/mono-https-webrequest-fails-with-the-authentication-or-decryption-has-failed
                
                ModernHttpClient 패키지 추가 > NativeMessageHandler 추가
                
                참조 : IOS 프로젝트 > 속성 > IOS 빌드 > 고급 Tab > SSL/TLS implementation , HttpClient implementation 선택
                       Android 프로젝트 > 속성 > Andorid 옵션 > 고급 Tab > SSL/TLS implementation , HttpClient implementation 선택
                       https://developer.xamarin.com/guides/cross-platform/transport-layer-security/
            */
            var httpClient = new HttpClient(new NativeMessageHandler());

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
