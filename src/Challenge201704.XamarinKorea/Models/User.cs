using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Challenge201704.XamarinKorea.Models
{
    public class Users
    {
        public IList<User> Results { get; set; }
    }
    /// <summary>
    /// 이용자 정보
    /// </summary>
    public class User
    {
        /// <summary>
        /// 성별
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        public UserName Name { get; set; }
        /// <summary>
        /// 주소
        /// </summary>
        [JsonProperty("location")]
        public Address Address { get; set; }
        /// <summary>
        /// 이메일
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 로그인 정보
        /// </summary>
        public LoginInfo Login { get; set; }
        /// <summary>
        /// 생년월일
        /// </summary>
        [JsonProperty("dob")]
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime Registered { get; set; }
        /// <summary>
        /// 집 전화번호
        /// </summary>
        [JsonProperty("phone")]
        public string HomePhoneNumber { get; set; }
        /// <summary>
        /// 휴대폰 번호
        /// </summary>
        [JsonProperty("cell")]
        public string CellPhoneNumber { get; set; }
        /// <summary>
        /// 아이디 정보
        /// </summary>
        public IdInfo Id { get; set; }
        /// <summary>
        /// 사진 Uri 
        /// </summary>
        public Picture Picture { get; set; }
        /// <summary>
        /// 국가 코드
        /// -> AU, BR, CA, CH, DE, DK, ES, FI, FR, GB, IE, IR, NL, NZ, TR, US
        /// </summary>
        [JsonProperty("nat")]
        public string Nationality { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
    }
    /// <summary>
    /// 이름
    /// </summary>
    public class UserName
    {
        /// <summary>
        /// 호칭 
        /// Mr Mrs Ms Miss or etc
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string First { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string Last { get; set; }
    }

    public class Picture
    {
        /// <summary>
        /// Large Image Uri
        /// </summary>
        public string Large { get; set; }
        /// <summary>
        /// Medium Image Uri
        /// </summary>
        public string Medium { get; set; }
        /// <summary>
        /// Thumbnail Image Uri
        /// </summary>
        public string Thumbnail { get; set; }
    }
}
