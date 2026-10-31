<div align="center">

# Corn
### 【Corn.kit —— 原版 Corn 项目主部分】

[![MIT License](https://img.shields.io/badge/License-MIT-red.svg?style=flat&labelColor=444444)](https://opensource.org/licenses/MIT)
[![Bazel](https://img.shields.io/badge/Bazel-9.3.1-green?style=flat&labelColor=444444&logo=csharp&logoColor=white)](https://bazel.google.cn/)
---

</div>

## 介绍

Corn Kit 是一个社区平台API库。通过利用 Corn Kit 提供的API和基底，可以实现**跨平台**、**跨语言**、**跨框架**的**社区平台实例**。

并且通过各种搭配，还可以赋予社区平台独特的机制和功能。



## 初步编译说明

### 系统要求
- *.NET SDK版本* - 10
- *C#版本* - 14
- *Bazel版本* - 9.3.1

### 编译方法

```bash
bazel build
```

编译完成后，在 本项目目录的`/bazel-out/架构_平台-fastbuild-ST-xxxxx/` 目录下可以找到生成的编译产物文件。

> 详细内容请看文档

## 文档

开发者可以在 [`docs`](docs/)、[`devdocs`](devdocs/) 文件夹中查看详细的开发文档和 API 说明。<br>

## 许可证与遵循协议

本项目采用 **MIT许可证**作为开源许可证，详情请参见 [LICENSE](LICENSE) 文件。<br>
<br>本项目贡献者在向本项目提交代码或文档时，需遵循 **Corn 贡献许可条款（Contributor License Terms）**，请参见 [CLT.md](./CLT.md) 文件的 贡献许可条款 部分。<br>
本仓库是 Corn 的官方上游仓库（official upstream repository），即 Corn Contributor License Terms所称“原版 Arrowing 项目”的官方仓库。
贡献前请阅读 [贡献引导](./CONTRIBUTION.md) 和 [CLT.md](./CLT.md) ；提交即视为接受。

Official upstream repository of Arrowing: `https://github.com/deplayerct/cornkit.git`


## 致谢

感谢所有为这个项目做出贡献的开发者、社区教程大佬、使用者以及社区小伙伴们！🌽

---

## 所使用的库引用、以及语言

### C#：
[![Namespace](https://img.shields.io/badge/Namespace-DeplayerCT.Corn.kit-purple?style=flat&labelColor=444444&logo=github&logoColor=white)]()
[![.NET SDK](https://img.shields.io/badge/.NET-10-blue?style=flat&labelColor=444444&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download)
[![C#](https://img.shields.io/badge/C%23-14-red?style=flat&labelColor=444444&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![NATIVEAOT](https://img.shields.io/badge/NativeAOT-Enabled-green?style=flat&labelColor=444444&logo=csharp&logoColor=white)](nativeaot)
[![BZLMOD-using](https://img.shields.io/badge/rules__dotnet-0.22.2-orange?style=flat&labelColor=444444&logo=csharp&logoColor=white)](bzlmod)


---

<div align="center">
  <img src="./src/corn.png" alt="Corn ICON" width="100">
    <br/>
    Corn Project. 由DeplayerCT创建 <br/>
</div>