<div align="center">

# 🌽 Corn 🌽 大玉米 🌽
### 【Corn.kit —— 原版 Corn 项目主部分】

[![MIT License](https://img.shields.io/badge/License-MIT-red.svg?style=flat&labelColor=444444)](https://opensource.org/licenses/MIT)
[![Bazel](https://img.shields.io/badge/Bazel-9.3.1-green?style=flat&labelColor=444444&logo=csharp&logoColor=white)](https://bazel.google.cn/)
---

</div>

## 🎈 介绍

> [!WARNING]
> 本项目采用 **"框架 - 发行版"开发模式**，本项目作为**框架**，而其他基于本核心的项目作为**发行版**。<br>
> **本项目默认以类库形式编译为 Native 库（NativeAOT）**，无法独立运行，必须借助这些发行版才能运行。<br>
> 发行版可能会添加自定义功能，但请一定选择**正规且最好是开源**的发行版。

Corn Kit 是一个社区平台框架库。通过利用框架提供的API，Corn可以实现**跨平台**、**跨语言**、**跨框架**的**社区平台实例**。



## 📦 安装、初步编译说明

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

### 安装步骤

#### 对于使用者
下载 DeplayerCT.Corn.kit 的可运行编译产物，他们的文件名通常为 Native 库（`.dll` / `.so`）。<br>
然后寻找一个基于本核心的发行版，并按照他们给出的安装方法使用。

#### 对于开发者
1. 下载合适 DeplayerCT.Corn.kit 版本的源码
2. 解压合并入自己的源码内，以该语言使用外部 Native 库的方式将本核心链接到自己的项目
3. 参考文档进行适用开发

## 📚 文档

开发者可以在 [`docs`](docs/)、[`devdocs`](devdocs/) 文件夹中查看详细的开发文档和 API 说明。<br>
构建与发布流程请参见 [CAKEBUILD.md](CAKEBUILD.md)。

## 📄 许可证与遵循协议

本项目采用 **MIT许可证**作为开源许可证，详情请参见 [LICENSE](LICENSE) 文件。<br>
<br>本项目贡献者在向本项目提交代码或文档时，需遵循 **Corn 贡献许可条款（Contributor License Terms）**，请参见 [CONTRIBUTING.md](CONTRIBUTING.md) 文件的 贡献许可条款 部分。

## 🙏 致谢

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
