# 🛒 GadgetStore — Configuration Manager

![C#](https://img.shields.io/badge/Language-C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/Platform-.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Design Patterns](https://img.shields.io/badge/Patterns-Singleton%20%7C%20SOLID-blue?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

## Description

**GadgetStore** is a C# console application that demonstrates the **Singleton** design pattern combined with **SOLID** principles in the context of a retail store configuration system.

- **Motivation:** Managing shared application state (like store settings and tax rates) across multiple parts of a system is a common real-world challenge. This project explores how to do it correctly and safely.
- **Why this project?** Inconsistent configuration state can cause subtle, hard-to-debug bugs — especially when multiple components read and write settings concurrently. This project provides a clean, proven solution.
- **Problem it solves:** Ensures only one `ConfigurationManager` instance ever exists at runtime, guaranteeing a single source of truth for store configuration data. It also separates concerns using two focused interfaces, so consumers only access the data they need.
- **What I learned:** How to implement a thread-safe Singleton in C#, how to use interface segregation to expose different views of the same object, and how Dependency Inversion keeps calling code decoupled from concrete implementations.

---

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Architecture](#architecture)
- [Design Patterns & SOLID Principles](#design-patterns--solid-principles)
- [Features](#features)
- [Credits](#credits)
- [License](#license)

---

## Installation

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download) installed on your machine.

### Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/GadgetStore.git
   cd GadgetStore
   ```

2. **Build the project:**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

---

## Usage

When you run the application, it will:

1. Retrieve the singleton `ConfigurationManager` instance via two different interface views.
2. Display the initial store configuration (name, currency, and tax rate).
3. Update the tax rate through the `ITaxConfig` interface.
4. Display the updated configuration.
5. Confirm that both references point to the **same** singleton instance.

### Expected Output

```
Store Name: Gadget Galaxy
Currency: ZAR
Tax Rate: 15%

After Tax Update:
Store Name: Gadget Galaxy
Currency: ZAR
Tax Rate: 18%

Are both instances the same?
True
```

---

## Architecture

```
GadgetStore/
├── GadgetStore.sln
├── GadgetStore.csproj
├── Program.cs               # Entry point — wires up and exercises the singleton
├── IConfiguration.cs        # Interface: exposes StoreName and Currency
├── ITaxConfig.cs            # Interface: exposes TaxRate and UpdateTaxRate()
└── ConfigurationManager.cs  # Singleton implementation of both interfaces
```

### Class Diagram

```
         ┌─────────────────┐       ┌──────────────┐
         │  IConfiguration  │       │  ITaxConfig  │
         │─────────────────│       │──────────────│
         │ + StoreName      │       │ + TaxRate    │
         │ + Currency       │       │ + UpdateTaxRate() │
         └────────┬────────┘       └──────┬───────┘
                  │                        │
                  └──────────┬─────────────┘
                             │  implements
                  ┌──────────▼────────────┐
                  │   ConfigurationManager │
                  │  (Singleton, sealed)   │
                  │────────────────────────│
                  │ - _instance            │
                  │ - _lock                │
                  │ + StoreName            │
                  │ + Currency             │
                  │ + TaxRate              │
                  │ + Instance (static)    │
                  │ + UpdateTaxRate()      │
                  └────────────────────────┘
```

---

## Design Patterns & SOLID Principles

### 🔒 Singleton Pattern
`ConfigurationManager` uses a **thread-safe, lazy-initialized Singleton** via a `lock` statement. This guarantees:
- Only one instance is ever created, regardless of concurrent access.
- All parts of the application share the same configuration state.

### ✅ SOLID Principles Applied

| Principle | How it's applied |
|---|---|
| **S** — Single Responsibility | `ConfigurationManager` is only responsible for holding and updating configuration state. |
| **O** — Open/Closed | New configuration concerns can be added via new interfaces without modifying existing consumers. |
| **L** — Liskov Substitution | `ConfigurationManager` fully satisfies both `IConfiguration` and `ITaxConfig` contracts. |
| **I** — Interface Segregation | `IConfiguration` and `ITaxConfig` are separate, focused interfaces — consumers only depend on what they use. |
| **D** — Dependency Inversion | `Program.cs` depends on abstractions (`IConfiguration`, `ITaxConfig`), not on the concrete `ConfigurationManager` class. |

---

## Features

- ✅ Thread-safe Singleton using `lock`
- ✅ Interface Segregation — two purpose-built interfaces over one concrete class
- ✅ Dependency Inversion — `Program.cs` never references `ConfigurationManager` directly in method signatures
- ✅ Mutable tax rate with an update method, immutable store identity
- ✅ ZAR (South African Rand) currency support out of the box

---

## Credits

- Design pattern reference: [Refactoring Guru — Singleton](https://refactoring.guru/design-patterns/singleton)
- SOLID principles reference: [Microsoft C# Docs](https://learn.microsoft.com/en-us/dotnet/csharp/)

---

## License

This project is licensed under the [MIT License](https://choosealicense.com/licenses/mit/).

---

## Author

**Kyle Pillay**

*Final-year Application Development Student | Cloud Development Tutor | Emeris*

<br/>

[![Email](https://img.shields.io/badge/Email-kylepillay017%40gmail.com-D14836?style=flat-square&logo=gmail&logoColor=white)](mailto:kylepillay017@gmail.com)
[![Student Email](https://img.shields.io/badge/Student-ST10451194-0078D4?style=flat-square&logo=microsoftoutlook&logoColor=white)](mailto:ST10451194@vcconnect.edu.za)
[![GitHub](https://img.shields.io/badge/GitHub-KylePillay2006-181717?style=flat-square&logo=github&logoColor=white)](https://github.com/KylePillay2006)
[![YouTube](https://img.shields.io/badge/YouTube-%40ByteSizedCode123-FF0000?style=flat-square&logo=youtube&logoColor=white)](https://www.youtube.com/@ByteSizedCode123)
[![Portfolio](https://img.shields.io/badge/Portfolio-kylepillay2006.github.io-0A66C2?style=flat-square&logo=githubpages&logoColor=white)](https://kylepillay2006.github.io)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Kyle%20Pillay-0A66C2?style=flat-square&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/kyle-pillay)

<br/>

© 2026 Kyle Pillay • All Rights Reserved

</div>
