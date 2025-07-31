# DotNetUtils.Core

[![Build Status](https://github.com/TomDiem/dotnet-utils-tdd/workflows/CI%2FCD%20Pipeline/badge.svg)](https://github.com/TomDiem/dotnet-utils-tdd/actions)
[![NuGet Version](https://img.shields.io/nuget/v/DotNetUtils.Core.svg)](https://www.nuget.org/packages/DotNetUtils.Core/)
[![Coverage](https://codecov.io/gh/TomDiem/dotnet-utils-tdd/branch/main/graph/badge.svg)](https://codecov.io/gh/TomDiem/dotnet-utils-tdd)

Un conjunto completo de utilidades para .NET desarrolladas con Test-Driven Development (TDD).

## 🚀 Instalación

```bash
dotnet add package DotNetUtils.Core
```

## 📝 Uso Básico

```csharp
using DotNetUtils.Core.Extensions;

// String Extensions
var email = "test@example.com";
if (email.IsValidEmail())
{
    Console.WriteLine("Email válido!");
}

// Collection Extensions
var numbers = new[] { 1, 2, 3, 4, 5 };
var pagedResults = numbers.Paginate(page: 1, pageSize: 3);
```

## 🏗️ Desarrollo

Este proyecto sigue estrictamente Test-Driven Development (TDD):

1. **Red**: Escribir test que falle
2. **Green**: Implementar código mínimo para pasar
3. **Refactor**: Mejorar manteniendo tests verdes

### Requisitos

- .NET 8.0 SDK
- Git

### Setup Local

```bash
git clone https://github.com/your-username/dotnet-utils-tdd.git
cd dotnet-utils-tdd
dotnet restore
dotnet build
dotnet test
```

## 📊 Métricas de Calidad

- ✅ 100% Code Coverage
- ✅ Cyclomatic Complexity < 10
- ✅ Maintainability Index > 80
- ✅ Zero technical debt

## 🤝 Contribuciones

Las contribuciones son bienvenidas! Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/amazing-feature`)
3. Sigue TDD estrictamente
4. Mantén 100% de coverage
5. Commit tus cambios (`git commit -m 'Add amazing feature'`)
6. Push a la rama (`git push origin feature/amazing-feature`)
7. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

## 🎯 Roadmap

- [x] String Extensions básicas
- [x] Collection Extensions
- [x] DateTime Extensions
- [ ] Validation Helpers
- [ ] Crypto Helpers
- [ ] JSON Helpers
- [ ] Configuration Helpers
