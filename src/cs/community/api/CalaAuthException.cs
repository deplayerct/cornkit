// @path: src/cs/community/api/CalaAuthException.cs
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

namespace DeplayerCT.Corn.kit.community.api;

/// <summary>
/// CALA 鉴权失败异常。<br/>
///
/// 用途: 当登录校验或会话鉴权失败(<br/>
/// 账号密码错误、会话过期、被吊销等)时抛出, 携带对应的响应状态码,<br/>
/// 由上层(消息分发/传输循环)捕获并转成 <see cref="cala.CalaServerMessage"/><br/>
/// 带CSM Response Status的应答返回给客户端。<br/>
/// </summary>
public sealed class CalaAuthException : Exception
{
    /// <summary>对应 CALA 响应状态(如 ST_AUTH_FAILED / ST_SESSION_EXPIRED)。</summary>
    public string StatusCode { get; }

    public CalaAuthException(string message, string statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
