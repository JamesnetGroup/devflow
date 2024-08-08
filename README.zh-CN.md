以下是该文档的中文翻译：

# DevFlow  [![英文](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![中文](https://img.shields.io/badge/Language-中文-red.svg)](README.zh-CN.md) [![韩文](https://img.shields.io/badge/Language-한국어-green.svg)](README.ko.md)

用于高级学习和实验的模块化、小部件风格的 WPF 应用程序
[![许可证: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![星标](https://img.shields.io/github/stars/jamesnet214/devflow.svg)](https://github.com/jamesnet214/devflow/stargazers)
[![问题](https://img.shields.io/github/issues/jamesnet214/devflow.svg)](https://github.com/jamesnet214/devflow/issues)

## 项目概述

DevFlow 是一个创新的 WPF 应用程序，旨在展示 WPF 开发中的高级技术和架构模式。受 macOS 菜单栏的启发，它以可移动的 QuickSlot 界面为特色，可以启动各种开发工具的小部件风格窗口。

<img src="https://github.com/user-attachments/assets/2fdfc823-e196-4422-b70c-343ea32b770d" width="49%"/>
<img src="https://github.com/user-attachments/assets/695147a5-0cb4-44d9-bf93-9a69d7c6c60b" width="49%"/>
<img src="https://github.com/user-attachments/assets/f00376d7-b332-45e9-b576-e5e06c5935d3" width="49%"/>
<img src="https://github.com/user-attachments/assets/e02dc0aa-529b-4001-9b4d-bdd001bd5e9e" width="49%"/>

## 主要技术和实现

#### 1. 模块化架构
- [x] 集成 Prism 库实现松耦合和模块化
- [x] 使用依赖注入实现灵活和可维护的代码结构
- [x] 项目分散，模块之间无直接引用

#### 2. 高级 UI 设计
- [x] 受 macOS 菜单栏启发的自定义 QuickSlot 菜单
- [x] 各个工具的小部件风格窗口（资源管理器、颜色选择器、主题选择器、本地化）
- [x] 完全自定义控件，提供独特的用户体验

#### 3. WPF 精通展示
- [x] 在所有模块中广泛使用 MVVM 模式
- [x] 开发自定义控件以实现专门功能
- [x] 高级样式和主题功能

#### 4. 多语言支持
- [x] 集成本地化系统支持多种语言
- [x] 动态语言切换，无需重启应用程序

#### 5. 开发者工具集成
- [x] 内置文件资源管理器，快速访问项目文件
- [x] 具有高级颜色操作功能的颜色选择工具
- [x] 主题选择器，用于实时更改应用程序样式

## 技术栈
- .NET 8.0
- WPF (Windows Presentation Foundation)
- Prism 库用于 MVVM 和模块化
- C# 10.0

## 项目结构

解决方案由三个主要类别组成：
- **01. BASE**: 核心功能和数据处理
- **02. UI**: 用户界面组件和样式
- **03. APP**: 主应用程序和入口点

主要项目包括：
- **DevFlow.Menus**: QuickSlot 界面实现
- **DevFlow.Main**: 核心应用程序窗口和导航
- **DevFlow.Colors, DevFlow.Finders 等**: 单个工具模块

## 入门指南

### 先决条件
- Visual Studio 2022 或更高版本
- .NET 8.0 SDK

### 安装和运行

#### 1. 克隆仓库：
```
git clone https://github.com/jamesnet214/devflow.git
```

#### 2. 打开解决方案
- [x] Visual Studio
- [x] Visual Studio Code
- [x] JetBrains Rider

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

#### 3. 构建和运行
- [x] 将 DevFlow 设置为启动项目
- [x] 按 F5 或点击运行按钮
- [x] 推荐 Windows 11

## 学习机会

DevFlow 为 WPF 开发者提供了丰富的学习经验：

1. **模块化架构**：理解如何构建松耦合和可维护的 WPF 应用程序
2. **自定义控件**：学习如何创建和样式化自定义 WPF 控件
3. **实际 MVVM**：看到 MVVM 模式在复杂应用程序中的实际实现
4. **Prism 和 DI**：探索如何在 WPF 中使用 Prism 库和依赖注入
5. **多窗口管理**：学习在一个连贯的应用程序中管理多个窗口的技术

## 贡献

欢迎对 DevFlow 做出贡献！提交拉取请求、创建问题或帮助宣传项目。

## 许可证

本项目基于 MIT 许可证发布。详情请参阅 [LICENSE](LICENSE) 文件。

## 联系方式
- 网站：https://jamesnet.dev
- 电子邮件：james@jamesnet.dev, vickyqu115@hotmail.com

与 DevFlow 一起探索高级 WPF 开发，提升您的技能！
