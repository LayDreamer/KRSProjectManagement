using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.DingTalk.Dto
{
    [JsonObject]
    public class DingTalkOrganizationResult
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("result")]
        public List<DingTalkOrganizationItemResult> Result { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }

    [JsonObject]
    public class DingTalkOrganizationItemResult
    {
        [JsonProperty("dept_id")]
        public long DepId {  get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent_id")]
        public long ParentId {  get; set; }
    }
}
