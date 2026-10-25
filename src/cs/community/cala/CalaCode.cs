// @path: src/cs/community/cala/CalaRequCode.cs
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

namespace DeplayerCT.Corn.kit.community.cala;

/// <summary>
/// CALA 通讯协议的请求码枚举定义<br/>
/// </summary>
public sealed class CalaRequCode : IEquatable<CalaRequCode>
{
    
    private readonly string _value;
    
    private CalaRequCode(string value)
    {
        _value = value;
    }
    
    /// <summary>
    /// 从字符串创建 CalaRequCode 自定义请求码实例。<br/>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static CalaRequCode FromString(string value)
    {
        return new CalaRequCode(value);
    }
    
    // =====================================================================
    // 请求码(RequestCode 的字符串载体)
    // =====================================================================

    /// <summary>登录请求: 客户端用账号/密码换取 cid_key(会话凭证)。</summary>
    public const string RequestLogin = "RK_LOGIN";

    /// <summary>登出请求: 使当前 cid_key 失效。</summary>
    public const string RequestLogout = "RK_LOGOUT";

    /// <summary>心跳请求: 保持长连接存活,并携带最近会话活动。</summary>
    public const string RequestHeartbeat = "RK_HEARTBEAT";

    /// <summary>发送消息请求。</summary>
    public const string RequestSendMessage = "RK_SEND_MSG";

    /// <summary>拉取消息历史请求。</summary>
    public const string RequestGetHistory = "RK_GET_HISTORY";

    /// <summary>推送事件请求(客户端向服务器订阅事件 / 服务器向客户端推送事件共用)。</summary>
    public const string RequestPush = "RK_PUSH";
    
    // 隐式转换
    public static implicit operator string(CalaRequCode code) => code._value;
    public static explicit operator CalaRequCode(string value) => FromString(value);

    public bool Equals(CalaRequCode? other) => other is not null && _value == other._value;
    public override bool Equals(object? obj) => obj is CalaRequCode code && Equals(code);
    public override int GetHashCode() => _value.GetHashCode();
    public override string ToString() => _value;
}


/// <summary>
/// CALA 通讯协议的响应码枚举定义<br/>
/// </summary>
public sealed class CalaRespCode : IEquatable<CalaRespCode>
{
    private readonly string _value;
    
    private CalaRespCode(string value)
    {
        _value = value;
    }
    
    public static CalaRespCode FromString(string value)
    {
        return new CalaRespCode(value);
    }
    
    // =====================================================================
    // 响应码(ResponseCode 的字符串载体)
    // 表示"这条服务端应答对应哪一种请求"。
    // =====================================================================

    /// <summary>对 Login 的应答。</summary>
    public const string ResponseLogin = "SC_LOGIN";

    /// <summary>对 Logout 的应答。</summary>
    public const string ResponseLogout = "SC_LOGOUT";

    /// <summary>对 Heartbeat 的应答。</summary>
    public const string ResponseHeartbeat = "SC_HEARTBEAT";

    /// <summary>对 SendMessage / 消息广播的应答(含服务器主动推送的新消息)。</summary>
    public const string ResponseMessage = "SC_MSG";

    /// <summary>对 GetHistory 的应答。</summary>
    public const string ResponseHistory = "SC_HISTORY";

    /// <summary>对 Push 的应答(服务器主动推送)。</summary>
    public const string ResponsePush = "SC_PUSH";
    
    // 隐式转换
    public static implicit operator string(CalaRespCode code) => code._value;
    public static explicit operator CalaRespCode(string value) => FromString(value);

    public bool Equals(CalaRespCode? other) => other is not null && _value == other._value;
    public override bool Equals(object? obj) => obj is CalaRespCode code && Equals(code);
    public override int GetHashCode() => _value.GetHashCode();
    public override string ToString() => _value;
}

/// <summary>
/// CALA 通讯协议的响应状态码枚举定义<br/>
/// </summary>
public sealed class CalaStatCode : IEquatable<CalaStatCode>
{
    private readonly string _value;
    
    private CalaStatCode(string value)
    {
        _value = value;
    }
    
    public static CalaStatCode FromString(string value)
    {
        return new CalaStatCode(value);
    }
    
    // =====================================================================
    // 响应状态(ResponseStatus 的字符串载体)
    // 每个响应都会带一个 status 表示成功/失败/具体错误类别。
    // =====================================================================

    public const string StatusOk = "ST_OK";                                  // 成功
    public const string StatusAuthFailed = "ST_AUTH_FAILED";                 // 鉴权失败(账号/密码错误,或 cid_key 无效)
    public const string StatusSessionExpired = "ST_SESSION_EXPIRED";         // 会话已过期,需重新登录
    public const string StatusSessionRevoked = "ST_SESSION_REVOKED";         // 会话被吊销(如已在别处登出)
    public const string StatusBadRequest = "ST_BAD_REQUEST";                 // 请求格式错误/参数缺失
    public const string StatusServerError = "ST_SERVER_ERROR";               // 服务器内部错误
    public const string StatusForbidden = "ST_FORBIDDEN";                    // 无权限执行该操作
    public const string StatusRateLimited = "ST_RATE_LIMITED";               // 触发频率限制
    
    // 隐式转换
    public static implicit operator string(CalaStatCode code) => code._value;
    public static explicit operator CalaStatCode(string value) => FromString(value);

    public bool Equals(CalaStatCode? other) => other is not null && _value == other._value;
    public override bool Equals(object? obj) => obj is CalaStatCode code && Equals(code);
    public override int GetHashCode() => _value.GetHashCode();
    public override string ToString() => _value;
}
