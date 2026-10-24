# DOCS 0-INTRODUCTION

欢迎来到 Corn Kit 的官方文档！🌽<br>
Corn Kit提供了一套可以用于搭建社区平台的框架和 api

## 基本信息
- 通信：
  - TCP TLS
  - WebSocket
  - Cala 通信格式 [CALA](https://github.com/deplayerct/cornkit/tree/main/docs/std/COMMUNICATION-FORMAT.md)

> [!NOTE]
> **关于WebSocket不易过某些云厂商防火墙，真的假的？**<br>
> 如果作为一名多年C/S应用工程开发经验的开发者，让他**凭经验判断**，会告诉你：既不是真，也不是假，是片面。<br>
> WebSocket 有两种:<br>
> `ws://(明文,端口常是自定义)`← 这种是容易被打的,因为明文 特征明显，且 端口不常见。<br>
> `wss://(TLS 加密,一般端口 443)`← 这种和正常 HTTPS 长得一模一样,通常照常放行。<br>
> 当然，上述这两种放行规律也不太准确。所以只能求云服务器厂商的那个防火墙风水好一点了:(<br>
> 不过更有经验的会告诉你：防火墙从不对WebSocket这个协议动手,它只对流量特征动手。所以真正该问的不是"WebSocket 容不容易被拦",而是"你的 WebSocket 跑出来的流量特征符不符合云厂商防火墙胃口"。
> <br>但是即使不合胃口，顶多也就是被审查或者被限速，很少有被直接拦截的，除非你的端口数字选择不在他们公开提供的范围。如果你认为被审查或被限速就是被拦，那当我没说刚才这句。
> <br>这么说吧，如果你听不懂，那么就选默认端口443或者云厂商允许使用的公开端口，然后直接无脑的选择wss，很多情况下都能过防火墙。

- 平台模块(`platform` - 平台模块API集合)：
  - 账号系统
  - 聊天频道
  - 论坛系统
  - 动态系统
  - 博客系统
  - 视频平台
  - 直播系统
  - 社区邮件
  - 文件系统

- 社区基底(`community` - 社区基底API集合)：
  - Cala Protocol
  - Cala Format
  - 通讯与推送
  - 安全验证
  - 交互会话
  - 加密通讯
  - 日志系统
  - 用户管理
  - 权限管理
  - 资源管理
  - 数据库管理
  
- 测试集合(`Test` - 测试集合API集合)

各个平台模块和社区基底的API集合都可以单独使用，也可以组合使用。<br>
各个平台模块的底层都是社区基层API集合的实现，所以如果你想要自定义平台模块，可以直接使用社区基底的API集合来实现。

## 平台模块说明

每一个平台模块分为两个部分：客户端与服务端。即：<br>
```tree
<platform-module>
  ├── client
  └── server
```
一般情况下，只需要`CommunityCapi`/`CommunitySapi`就可以实现平台模块的功能了。<br>
所以调试的时候可以重点观察`CommunityCapi`/`CommunitySapi`。<br>

## 社区基底说明

除 `CommunityCapi`/`CommunitySapi`、Cala Format 和 Cala Protocol 外，其他API集合不明确区分客户端/服务端部分。<br>
`CommunityCapi`/`CommunitySapi`由其他社区基底API构成。<br>