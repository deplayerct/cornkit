// @path: src/cs/community/cala/CalaClientMessage.cs
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
/// 客户端 → 服务端 的 CALA 通讯消息模型。<br/>
///
/// 示例格式:<br/>
/// <code><br/>
/// { "cdata": {<br/>
///     "request_code": "RK_LOGIN",<br/>
///     "request_param": {...},<br/>
///     "request_message": { "message": "..." },<br/>
///     "cid_key": "...",<br/>
///     "this_uuid": "..."<br/>
/// } }<br/>
/// </code><br/>
///
/// 字段说明(对应 CALA 通信格式):<br/>
///  - Request Code   : 请求码, 见 <see cref="CalaCode"/>。<br/>
///  - Request Params : 请求参数, 语义随请求码而变(登录时放账号/密码, 发消息时放目标频道等)。<br/>
///  - Request Message       : 请求消息体, 一段自由文本(如聊天天内容)。<br/>
///  - CID-KEY        : 会话凭证。由服务端登录后签发, 客户端此后每次请求都携带。<br/>
///  - CCM-UUID      : 本条消息的唯一标识, 用于幂等/去重/对账。<br/>
/// </summary>
public sealed partial class CalaClientMessage
{
    /// <summary>外部 JSON 字段名: "cdata"。</summary>
    public const string JsonRootKey = "cdata";

    [JsonPropertyName("request_code")]
    public string RequestCode { get; set; } = string.Empty;

    [JsonPropertyName("request_param")]
    public Dictionary<string, string> RequestParams { get; set; } = new();

    [JsonPropertyName("request_message")]
    public MessageBody? RequestMessage { get; set; }

    [JsonPropertyName("cid_key")]
    public string CidKey { get; set; } = string.Empty;

    [JsonPropertyName("this_uuid")]
    public string ThisUuid { get; set; } = string.Empty;

    /// <summary>消息体({ "message": "..." })。</summary>
    public sealed class MessageBody
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }

    /// <summary>
    /// AOT 用 JSON 源生成上下文。
    /// NativeAOT 下禁止反射, 序列化必须走这里, 不能 <c>JsonSerializer.Serialize(obj)</c> 直接反射。
    /// </summary>
    [JsonSerializable(typeof(CalaClientMessage))]
    [JsonSourceGenerationOptions(WriteIndented = false)]
    internal partial class CalaClientMessageContext : JsonSerializerContext
    {
    }
}
