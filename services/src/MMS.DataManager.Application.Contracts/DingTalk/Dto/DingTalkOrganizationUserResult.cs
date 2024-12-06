using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.DingTalk.Dto
{
    [JsonObject]
    public class DingTalkOrganizationUserResult
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("result")]
        public DingTalkOrganizationUserItemResult Result { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }

    [JsonObject]
    public class DingTalkOrganizationUserItemResult
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public int Next {  get; set; }

        [JsonProperty("list")]
        public List<DingTalkOrganizationUserItemListResult> Lists { get; set; }
    }

    public class DingTalkOrganizationUserItemListResult
    {
        [JsonProperty("userid")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
