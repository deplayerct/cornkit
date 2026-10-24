# CALA COMMUNICATION FORMAT
这是玉米所使用的通信消息格式。

## 样式

### CALA FORMAT VERSION 1

```json5
{// Cala Client Message
  "cdata": {
    "request_code" : "string",// Request Code请求码，标识请求类型
    "request_param" : {"param":"string"},// Request Params请求参数，标识请求参数
    "request_message" :
    {
      "message" : "string"// Request Message请求消息体，标识请求消息体
    },
    "cid_key" : "**********************",// CID-KEY客户端通讯验证码，验证客户端并非冒充身份
    "this_uuid" : "***********************"// CCM-UUID 此通讯消息于客户端的唯一标识码
  }
}

// *部分在会话交互过程中，不需要用到的元素可省略
// *CID-KEY在会话创建成功后才需要，创建会话前的消息可无此元素
```

```json5
{// Cala Server Message
  "sdata": {
    "response_code" : "string",// Response Code响应码，标识响应类型
    "response_status" : "string",// Response Status响应状态，标识响应状态
    "response_param" : {"param":"string"},// Response Params响应参数，标识响应参数
    "response_message" :
    {
      "message" : "string"// Response Message响应消息体，标识响应消息体
    },
    "sid_key" : "**********************",// SID-KEY服务端通讯验证码，验证服务端并非冒充身份
    "this_uuid" : "***********************"// CSM-UUID 此通讯消息于服务端的唯一标识码
  }
}
// *部分在会话交互过程中，不需要用到的元素可省略
// *SID-KEY在会话创建成功后才需要，创建会话前的消息可无此元素

```