## 开发约定

为了更好的方便开发者之间的协作，减少冲突和重复工作，本项目采用以下开发约定：

- 对于每一个项目源码文件，都请在文件头部第一行使用SPDX-License-Identifier的方式标注LICENSE，例如：`// SPDX-License-Identifier: MIT`。
  该约定仅适用于项目源码文件，不适用于文档、配置文件、资源文件等非源码文件。
- 对于每一个项目源码文件，都请在文件头部第二行写明其在 `src` 目录中的位置，例如：`// @path: src/api/???.cs`
- 对于每一个项目源码文件，都请在文件头部第三行开始使用`/**/`写明版权信息和Authors信息，例如：
    ```
        /*
        * Copyright (c) 2026 DeplayerCT
        * Author : Deplayer515 <deplayer515@hotmail.com>
        */
    ```
----------------------------
- **请务必使用GPG/PGP等等的提交签名方式签名您的提交，否则，一律禁止推送，合并也会被拒绝。**<br>
  其配置并不难，请参考 [GitHub官方文档(从此章节开始一直往下看)](https://docs.github.com/zh/authentication/managing-commit-signature-verification/about-commit-signature-verification)。<br>
  如果还看不懂，请参考这个速通文档：[GPG/PGP Github配置速通](https://blog.dejavu.moe/posts/gpg-verified-github/)。
- **禁止Force Push**。
- **请务必按以下方式整理和创建源码目录**： `src/<language>/<part>/<subpart>/`，其中 `<part>` 为项目的主要部分，例如 `api`、`core`、`launcher` 等，一般可以为模块或基底； `<subpart>` 为 `<part>` 下的子模块或子目录，例如 `api` 下的 `user`、`auth` 等；
- **本项目使用MIT许可证，并有CLT。** 在您开始贡献前，请务必阅读 [CLT.md (Corn 贡献许可条例)](./CLT.md) ；提交即视为接受。

## 文档存放位置说明

- **外部引导性文档**（如本文件）：放在源代码根目录
- **开发文档**：请写入开发者指南文档于 `docs/` 内，内部开发文档于 `devdocs/` 内。

## 提交通用约定

### 提交消息格式

```
<类型>(<作用域>): <简短描述>

[可选的详细描述]

[可选的关联信息]

//同一提交的其他内容，但不能为主要内容
<类型>(<作用域>): <简短描述>

[可选的详细描述]

[可选的关联信息]

...
```

### 类型说明

| 类型         | 说明             | 示例                     |
|------------|----------------|------------------------|
| `feat`     | 新功能            | `feat(gui): 添加按钮组件`    |
| `fix`      | 修复bug          | `fix(core): 修复渲染异常`    |
| `docs`     | 文档更新           | `docs(readme): 更新安装说明` |
| `style`    | 代码格式调整（不影响功能）  | `style(format): 统一代码缩进` |
| `refactor` | 重构代码           | `refactor(ui): 优化组件架构` |
| `perf`     | 性能优化           | `perf(render): 提升渲染性能` |
| `test`     | 测试相关           | `test(button): 添加单元测试` |
| `chore`    | 构建过程或辅助工具变动    | `chore(workflow): 更新依赖版本` |
| `ci`       | CI配置相关         | `ci(workflow): 修改构建流程` |
| `release`  | 发布版本的标志提交      | `release(版本号): 修改版本号以便发布` |

### 作用域说明

常用的作用域包括：
- `devdocs` : 内部开发文档
- `docs` : 文档
- `readme` : README文件
- `contributing` : CONTRIBUTING文件
- `codeofconduct` : CODE_OF_CONDUCT文件
- `build` : 构建相关
- `workflow` : CI/CD 工作流
- `tools` : 工具
- `other` : 其他

还有几种特定作用域，依据被修改的源码所属的主要部分来命名作用域。

## 版本标签规范

- 采用这种较为特殊的方式标记在发布页面、版记显示页面的版本号：`v年份.版本号.阶段号.修订号[-发布标识]`

  比如：`v26.1.1.1d`
  - `26.1.1` - 主要版本标识
    - 发布标识分为r（发布）、dr（开发发布）、d（开发阶段）、s（稳定发布）、t（测试阶段）、f（阶段首版本）。按开发顺序，应该以如下顺序发布版本：

      - `f` - 阶段首版本
      - `d` - 开发阶段
      - `dr` - 开发发布
      - `t` - 测试阶段
      - `r` - 发布
      - `s` - 稳定发布
    - 阶段号和修订号用于标识开发进度和版本
    - 当首次发布该阶段号时，修订号可以不写
    - 稳定发布的版本可以简写为`26.1.1s1`，表示这是第26年，第1个主要版本的第1个稳定发布版本
    - 也可用于标记模块/基底版本号，但需在版本后前加上其名称


- 采用以发布次数累积方式标记改内部版本信息的版本号

  例如：`15`

  不标明任何其他东西，仅仅是一个数字，表示这是第n次发布的版本。

## 联系社区团队

Deplayer515（Repo管理员、创建人）

`deplayer515@hotmail.com`

DeplayerCT社区主管团队

`dctcss@outlook.com`