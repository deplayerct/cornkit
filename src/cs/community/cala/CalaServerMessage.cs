// @path: src/cs/community/cala/CalaServerMessage.cs
/*MIT License

Copyright (c) 2026 Deplayer

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Text.Json.Serialization;

namespace DeplayerCT.Corn.kit.community.cala;

/// <summary>
/// 服务端 → 客户端 的 CALA 通讯消息模型。<br/>
///
/// 示例格式：<br/>
/// <code><br/>
/// { "sdata": {<br/>
///     "response_code": "SC_LOGIN",<br/>
///     "response_status": "ST_OK",<br/>
///     "response_param": {...},<br/>
///     "response_message": { "message": "..." },<br/>
///     "sid_key": "...",<br/>
///     "this_uuid": "..."<br/>
/// } }<br/>
/// </code><br/>
///
/// 字段说明:<br/>
///  - Response Code   : 响应码, 见 <see cref="CalaCode"/>。<br/>
///  - Response Status : 响应状态(成功/失败/具体错误), 见 <see cref="CalaCode.StatusOk"/> 等。<br/>
///  - Response Params : 响应参数(如登录成功后回传的 cid_key、频道列表等)。<br/>
///  - Response Message        : 响应消息体(人类可读的提示文本, 或业务数据)。<br/>
///  - SID-KEY         : 服务端通讯验证码。用于客户端反过来确认"服务端身份非冒充"以及增强双向校验。<br/>
///  - CSM-UUID       : 本条响应唯一标识。<br/>
/// </summary>
public sealed partial class CalaServerMessage
{
    /// <summary>外部 JSON 字段名(对你而言固定): "sdata"。</summary>
    public const string JsonRootKey = "sdata";

    [JsonPropertyName("response_code")]
    public string ResponseCode { get; set; } = string.Empty;

    [JsonPropertyName("response_status")]
    public string ResponseStatus { get; set; } = string.Empty;

    [JsonPropertyName("response_param")]
    public Dictionary<string, string> ResponseParams { get; set; } = new();

    [JsonPropertyName("response_message")]
    public MessageBody? ResponseMessage { get; set; }

    [JsonPropertyName("sid_key")]
    public string SidKey { get; set; } = string.Empty;

    [JsonPropertyName("this_uuid")]
    public string ThisUuid { get; set; } = string.Empty;

    /// <summary>消息体({ "message": "..." })。</summary>
    public sealed class MessageBody
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }

    /// <summary>
    /// AOT 用 JSON 源生成上下文 (NativeAOT 下必须走这里, 不能用反射序列化)。
    /// </summary>
    [JsonSerializable(typeof(CalaServerMessage))]
    [JsonSourceGenerationOptions(WriteIndented = false)]
    internal partial class CalaServerMessageContext : JsonSerializerContext
    {
    }
}
