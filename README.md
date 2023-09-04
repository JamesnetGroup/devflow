## DevFlow

> 템플릿 작업을 위해 수정중입니다. 
> TBD...

DevFlow는 개발자를 위한 유용한 기능들을 제공하는 프로그램입니다. <br />

이 앱은 <code>WPF</code>와 <code>C#</code>을 기반으로 하고 있으며, 거의 모든 코드가 외부 라이브러리 없이 <code>.NET Framework</code>로만 개발되었습니다. 

 
| Star | License | Activity |
|:----:|:-------:|:--------:|
| <a href="https://github.com/devncore/devflow/stargazers"><img src="https://img.shields.io/github/stars/devncore/devflow" alt="Github Stars"></a> | <img src="https://img.shields.io/github/license/devncore/devflow" alt="License"> | <a href="https://github.com/devncore/devflow/pulse"><img src="https://img.shields.io/github/commit-activity/m/devncore/devflow" alt="Commits-per-month"></a> |

<br />

## Table of Contents
- [Application](#application)
- [QuickSlot](#quickslot)
- [ColorSpoid](#colorspoid)
- [Finder](#finder)

<br />

## Application

```csharp
using System;
using System.Windows;
using DevFlow.Data.Theme;
using DevFlow.Main.Views;
using DevFlow.Windowbase.Flowbase;

namespace DevFlow
{
    public class App : FlowApp
    {
        protected override ThemeType OnSetDefaultTheme(ThemeType type) => ThemeType.Dark;

        protected override void OnApplyThemeManager()
        {
            AddTheme(ThemeType.Dark, "Generic.Dark.xaml");
            AddTheme(ThemeType.White, "Generic.White.xaml");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            bool dialogResult = true;

            while (dialogResult)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                main = new MainView();
                main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }
            Environment.Exit(0);
        }
    }
}
```

<br />

## _QuickSlot_

> **QuickSlot : Widget**
> - ContentTemplate
<img src="https://user-images.githubusercontent.com/52397976/121200753-f11ce700-c8ae-11eb-95f0-1932818f87de.png" width="300">

<br />

## _Gith Graph_

![image](https://github.com/jamesnet214/devflow/assets/52397976/72f87532-a37f-4544-ac33-5dfb69bc9a02)
