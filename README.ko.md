# DevFlow [![English](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![한국어](https://img.shields.io/badge/Language-한국어-red.svg)](README.ko.md)

고급 학습 및 실험을 위한 모듈식, 위젯 스타일의 WPF 애플리케이션

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Stars](https://img.shields.io/github/stars/jamesnet214/devflow.svg)](https://github.com/jamesnet214/devflow/stargazers)
[![Issues](https://img.shields.io/github/issues/jamesnet214/devflow.svg)](https://github.com/jamesnet214/devflow/issues)

## 프로젝트 개요

DevFlow는 WPF 개발에서의 고급 기술과 아키텍처 패턴을 선보이기 위해 설계된 혁신적인 WPF 애플리케이션입니다. macOS의 메뉴 바에서 영감을 받아, 다양한 개발 도구를 위한 위젯 스타일 창을 실행하는 이동 가능한 QuickSlot 인터페이스를 특징으로 합니다.

<img src="https://github.com/user-attachments/assets/2fdfc823-e196-4422-b70c-343ea32b770d" width="49%"/>
<img src="https://github.com/user-attachments/assets/695147a5-0cb4-44d9-bf93-9a69d7c6c60b" width="49%"/>
<img src="https://github.com/user-attachments/assets/f00376d7-b332-45e9-b576-e5e06c5935d3" width="49%"/>
<img src="https://github.com/user-attachments/assets/e02dc0aa-529b-4001-9b4d-bdd001bd5e9e" width="49%"/>

## 주요 기술 및 구현 사항
#### 1. 모듈식 아키텍처
- [x] 느슨한 결합과 모듈성을 위한 Prism 라이브러리 통합
- [x] 유연하고 유지보수 가능한 코드 구조를 위한 의존성 주입
- [x] 모듈 간 직접적인 참조 없는 프로젝트 분산

#### 2. 고급 UI 디자인
- [x] macOS 메뉴 바에서 영감을 받은 사용자 정의 QuickSlot 메뉴
- [x] 개별 도구를 위한 위젯 스타일 창 (탐색기, 색상 선택기, 테마 선택기, 현지화)
- [x] 독특한 사용자 경험을 위한 완전 사용자 정의 컨트롤

#### 3. WPF 마스터리 쇼케이스
- [x] 모든 모듈에 걸친 MVVM 패턴의 광범위한 사용
- [x] 전문화된 기능을 위한 사용자 정의 컨트롤 개발
- [x] 고급 스타일링 및 테마 기능

#### 4. 다국어 지원
- [x] 다중 언어 지원을 위한 통합 현지화 시스템
- [x] 애플리케이션 재시작 없이 동적 언어 전환

#### 5. 개발자 도구 통합
- [x] 프로젝트 파일에 빠르게 접근할 수 있는 내장 파일 탐색기
- [x] 고급 색상 조작 기능을 갖춘 색상 선택 도구
- [x] 실시간 애플리케이션 스타일 변경을 위한 테마 선택기

## 기술 스택
- .NET 8.0
- WPF (Windows Presentation Foundation)
- MVVM 및 모듈성을 위한 Prism 라이브러리
- C# 10.0

## 프로젝트 구조
솔루션은 세 가지 주요 카테고리로 구성되어 있습니다:
- **01. BASE**: 핵심 기능 및 데이터 처리
- **02. UI**: 사용자 인터페이스 컴포넌트 및 스타일링
- **03. APP**: 메인 애플리케이션 및 진입점

주요 프로젝트 포함:
- **DevFlow.Menus**: QuickSlot 인터페이스 구현
- **DevFlow.Main**: 핵심 애플리케이션 창 및 내비게이션
- **DevFlow.Colors, DevFlow.Finders 등**: 개별 도구 모듈

## 시작하기
### 필요 조건
- Visual Studio 2022 이상
- .NET 8.0 SDK

### 설치 및 실행
#### 1. 리포지토리 클론:

```
git clone https://github.com/jamesnet214/devflow.git
```

#### 2. 솔루션 열기
- [x] Visual Studio
- [x] Visual Studio Code
- [x] JetBrains Rider

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

#### 3. 빌드 및 실행
- [x] DevFlow를 시작 프로젝트로 설정
- [x] F5를 누르거나 실행 버튼 클릭
- [x] Windows 11 권장

## 학습 기회

DevFlow는 WPF 개발자들에게 풍부한 학습 경험을 제공합니다:
1. **모듈식 아키텍처**: 느슨하게 결합되고 유지보수 가능한 WPF 애플리케이션을 구축하는 방법 이해
2. **사용자 정의 컨트롤**: 사용자 정의 WPF 컨트롤을 생성하고 스타일링하는 방법 학습
3. **실전 MVVM**: 복잡한 애플리케이션에서 MVVM 패턴의 실제 구현 사례 확인
4. **Prism 및 DI**: WPF에서 Prism 라이브러리 및 의존성 주입 사용법 탐구
5. **다중 창 관리**: 일관된 애플리케이션에서 여러 창을 관리하는 기술 학습

## 기여하기
DevFlow에 대한 기여를 환영합니다! 풀 리퀘스트를 제출하거나, 이슈를 생성하거나, 프로젝트를 홍보해 주세요.

## 라이선스
이 프로젝트는 MIT 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE](LICENSE) 파일을 참조하세요.

## 연락처
- 웹사이트: https://jamesnet.dev
- 이메일: james@jamesnet.dev, vickyqu115@hotmail.com

DevFlow와 함께 고급 WPF 개발을 탐험하고 여러분의 기술을 한 단계 높여보세요!
