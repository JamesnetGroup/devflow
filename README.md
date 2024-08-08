# DevFlow [![英文](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![中文](https://img.shields.io/badge/Language-中文-red.svg)](README.zh-CN.md) [![韩文](https://img.shields.io/badge/Language-한국어-green.svg)](README.ko.md)

A modular, widget-style WPF application for advanced learning and experimentation

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Stars](https://img.shields.io/github/stars/jamesnet214/devflow.svg)](https://github.com/jamesnet214/devflow/stargazers)
[![Issues](https://img.shields.io/github/issues/jamesnet214/devflow.svg)](https://github.com/jamesnet214/devflow/issues)

## Project Overvie

DevFlow is an innovative WPF application designed to showcase advanced techniques and architectural patterns in WPF development. Inspired by macOS's menu bar, it features a movable QuickSlot interface that launches widget-like windows for various development tools.

<img src="https://github.com/user-attachments/assets/2fdfc823-e196-4422-b70c-343ea32b770d" width="49%"/>
<img src="https://github.com/user-attachments/assets/695147a5-0cb4-44d9-bf93-9a69d7c6c60b" width="49%"/>
<img src="https://github.com/user-attachments/assets/f00376d7-b332-45e9-b576-e5e06c5935d3" width="49%"/>
<img src="https://github.com/user-attachments/assets/e02dc0aa-529b-4001-9b4d-bdd001bd5e9e" width="49%"/>

## Key Technologies and Implementations
#### 1. Modular Architecture
- [x] Prism library integration for loose coupling and modularity
- [x] Dependency injection for flexible and maintainable code structure
- [x] Project distribution with no direct references between modules

#### 2. Advanced UI Design
- [x] Custom QuickSlot menu inspired by macOS menu bar
- [x] Widget-style windows for individual tools (Explorer, Color Picker, Theme Selector, Localization)
- [x] Fully customized controls for a unique user experience

#### 3. WPF Mastery Showcase
- [x] Extensive use of MVVM pattern across all modules
- [x] Custom control development for specialized functionality
- [x] Advanced styling and theming capabilities

#### 4. Multi-language Support
- [x] Integrated localization system for multiple language support
- [x] Dynamic language switching without application restart

#### 5. Developer Tools Integration
- [x] Built-in file explorer for quick access to project files
- [x] Color picker tool with advanced color manipulation features
- [x] Theme selector for real-time application styling changes

## Technology Stack
- .NET 8.0
- WPF (Windows Presentation Foundation)
- Prism Library for MVVM and Modularity
- C# 10.0

## Project Structure
The solution is organized into three main categories:
- **01. BASE**: Core functionalities and data handling
- **02. UI**: User interface components and styling
- **03. APP**: Main application and entry point

Key projects include:
- **DevFlow.Menus**: Implementation of the QuickSlot interface
- **DevFlow.Main**: Core application window and navigation
- **DevFlow.Colors, DevFlow.Finders, etc.**: Individual tool modules

## Getting Started
### Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK

### Installation and Execution
#### 1. Clone the repository:

```
git clone https://github.com/jamesnet214/devflow.git
```

#### 2. Open the solution
- [x] Visual Studio
- [x] Visual Studio Code
- [x] JetBrains Rider

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

#### 3. Build and Run
- [x] Set DevFlow as the startup project
- [x] Press F5 or click the Run button
- [x] Windows 11 recommended

## Learning Opportunities

DevFlow offers a rich learning experience for WPF developers:
1. **Modular Architecture**: Understand how to build loosely coupled, maintainable WPF applications
2. **Custom Controls**: Learn to create and style custom WPF controls
3. **MVVM in Practice**: See real-world implementation of MVVM pattern in a complex application
4. **Prism and DI**: Explore the use of Prism library and dependency injection in WPF
5. **Multi-window Management**: Learn techniques for managing multiple windows in a cohesive application

## Contributing
Contributions to DevFlow are welcome! Please feel free to submit pull requests, create issues or spread the word.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
- Website: https://jamesnet.dev
- Email: james@jamesnet.dev, vickyqu115@hotmail.com

Dive into advanced WPF development with DevFlow and elevate your skills to the next level!
