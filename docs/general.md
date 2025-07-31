# dotnet-utils-tdd: Guía Completa con Mejores Prácticas

## 📋 Resumen del Proyecto

**dotnet-utils-tdd** es una biblioteca de utilidades para .NET desarrollada completamente con Test-Driven Development (TDD), enfocada en proporcionar helpers robustos y bien probados para proyectos .NET modernos.

## 🎯 Objetivos del Proyecto

- Crear utilidades confiables probadas al 100% con TDD
- Seguir las mejores prácticas de desarrollo .NET 2025
- Proporcionar un paquete NuGet de alta calidad para la comunidad
- Establecer un estándar de desarrollo para futuros proyectos

## 🏗️ Arquitectura y Estructura

### Estructura del Proyecto

```
dotnet-utils-tdd/
├── src/
│   └── DotNetUtils.Core/           # Biblioteca principal
│       ├── Extensions/             # Métodos de extensión
│       ├── Helpers/               # Clases helper
│       ├── Utilities/             # Utilidades específicas
│       └── Common/                # Funcionalidades comunes
├── tests/
│   └── DotNetUtils.Core.Tests/    # Tests unitarios
├── docs/                          # Documentación
├── samples/                       # Ejemplos de uso
├── .github/                       # GitHub Actions
└── tools/                         # Scripts y herramientas

```

### Tecnologías y Frameworks

**Framework Base:**

- .NET 8 (LTS) para compatibilidad y rendimiento
- .NET Standard 2.1 para máxima compatibilidad

**Testing Stack:**

- xUnit: Framework de testing moderno y eficiente
- Moq: Mocking framework para dependencies
- FluentAssertions: Assertions más legibles
- Coverlet: Code coverage analysis

**Calidad de Código:**

- SonarAnalyzer.CSharp: Análisis estático
- StyleCop.Analyzers: Consistencia de estilo
- Microsoft.CodeAnalysis.NetAnalyzers: Análisis de código

## 🧪 Metodología TDD

### Ciclo Red-Green-Refactor

**1. RED (Escribir test que falle)**

```csharp
[Fact]
public void StringExtensions_IsValidEmail_ShouldReturnTrue_WhenEmailIsValid()
{
    // Arrange
    var email = "test@example.com";

    // Act
    var result = email.IsValidEmail();

    // Assert
    result.Should().BeTrue();
}
```

**2. GREEN (Implementar mínimo código para pasar)**

```csharp
public static bool IsValidEmail(this string email)
{
    return email?.Contains("@") == true;
}
```

**3. REFACTOR (Mejorar la implementación)**

```csharp
public static bool IsValidEmail(this string email)
{
    if (string.IsNullOrWhiteSpace(email))
        return false;

    try
    {
        var addr = new MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}
```

### Mejores Prácticas de Testing

**Estructura AAA (Arrange-Act-Assert)**

```csharp
[Fact]
public void CollectionHelper_Paginate_ShouldReturnCorrectPage()
{
    // Arrange
    var source = Enumerable.Range(1, 100);
    var pageSize = 10;
    var pageNumber = 2;

    // Act
    var result = source.Paginate(pageNumber, pageSize);

    // Assert
    result.Should().HaveCount(10);
    result.First().Should().Be(11);
    result.Last().Should().Be(20);
}
```

**Naming Convention**

- Formato: `MethodName_Scenario_ExpectedBehavior`
- Ejemplos:
  - `Parse_ValidInput_ReturnsCorrectObject`
  - `Validate_NullInput_ThrowsArgumentNullException`

## 📦 Configuración del Paquete NuGet

### Metadatos del Paquete (en .csproj)

```xml
<PropertyGroup>
  <PackageId>DotNetUtils.Core</PackageId>
  <Version>1.0.0</Version>
  <Authors>Tu Nombre</Authors>
  <Company>Tu Organización</Company>
  <Description>Conjunto de helpers útiles para .NET desarrollados con TDD</Description>
  <PackageTags>dotnet;utilities;helpers;tdd;extensions</PackageTags>
  <RepositoryUrl>https://github.com/tu-usuario/dotnet-utils-tdd</RepositoryUrl>
  <RepositoryType>git</RepositoryType>
  <PackageReadmeFile>README.md</PackageReadmeFile>
  <PackageLicenseExpression>MIT</PackageLicenseExpression>
  <PackageIcon>icon.png</PackageIcon>
  <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
  <IncludeSymbols>true</IncludeSymbols>
  <SymbolPackageFormat>snupkg</SymbolPackageFormat>
</PropertyGroup>

<ItemGroup>
  <None Include="README.md" Pack="true" PackagePath="\"/>
  <None Include="icon.png" Pack="true" PackagePath="\"/>
</ItemGroup>
```

### Versionado Semántico (SemVer)

- **MAJOR.MINOR.PATCH**
- **1.0.0**: Primera versión estable
- **1.1.0**: Nuevas funcionalidades (backward compatible)
- **1.0.1**: Bug fixes
- **2.0.0**: Breaking changes

## 🚀 Pipeline CI/CD

### GitHub Actions Workflow

```yaml
name: CI/CD Pipeline

on:
  push:
    branches: [main, develop]
  pull_request:
    branches: [main]

jobs:
  test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: 8.0.x

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore

      - name: Test
        run: dotnet test --no-build --verbosity normal --collect:"XPlat Code Coverage"

      - name: Upload coverage to Codecov
        uses: codecov/codecov-action@v3

  pack-and-publish:
    needs: test
    runs-on: ubuntu-latest
    if: github.ref == 'refs/heads/main'
    steps:
      - name: Pack NuGet
        run: dotnet pack --configuration Release

      - name: Publish to NuGet
        run: dotnet nuget push **/*.nupkg --api-key ${{ secrets.NUGET_API_KEY }} --source https://api.nuget.org/v3/index.json
```

## 🗺️ Roadmap de Desarrollo

### Fase 1: Fundación (Semanas 1-2)

**Objetivo:** Establecer la base sólida del proyecto

**Tareas:**

1. **Configuración Inicial**

   - [ ] Crear repositorio GitHub con template .NET
   - [ ] Configurar estructura de proyecto
   - [ ] Setup de herramientas de calidad de código
   - [ ] Configurar GitHub Actions básico

2. **Primeras Utilidades Core**

   - [ ] String Extensions (IsValidEmail, IsValidUrl, ToTitleCase)
   - [ ] DateTime Extensions (IsWeekend, GetAge, ToUnixTimestamp)
   - [ ] Collection Extensions (IsNullOrEmpty, SafeAny, Paginate)

3. **Testing Foundation**
   - [ ] Configurar xUnit + Moq + FluentAssertions
   - [ ] Establecer convenciones de naming
   - [ ] Crear primeros tests ejemplares

**Criterios de Éxito:**

- 100% code coverage en utilities implementadas
- CI/CD pipeline funcionando
- Documentación básica

### Fase 2: Expansión Core (Semanas 3-4)

**Objetivo:** Añadir funcionalidades más complejas

**Tareas:**

1. **Helpers Avanzados**

   - [ ] JsonHelper (safe serialization/deserialization)
   - [ ] ConfigurationHelper (appsettings management)
   - [ ] CryptoHelper (hashing, encryption basics)
   - [ ] ValidationHelper (common validations)

2. **Performance Utilities**

   - [ ] CacheHelper (memory caching utilities)
   - [ ] BatchProcessor (batch processing utilities)
   - [ ] RetryPolicyHelper (resilience patterns)

3. **Testing Avanzado**
   - [ ] Integration tests para helpers complejos
   - [ ] Performance benchmarks con BenchmarkDotNet
   - [ ] Property-based testing con FsCheck

**Criterios de Éxito:**

- Mantener 100% code coverage
- Performance benchmarks documentados
- Primera versión alpha (0.1.0-alpha)

### Fase 3: Calidad y Publicación (Semanas 5-6)

**Objetivo:** Preparar para producción

**Tareas:**

1. **Calidad de Código**

   - [ ] Code review completo
   - [ ] Refactoring basado en métricas
   - [ ] Documentación XML completa
   - [ ] README detallado con ejemplos

2. **Packaging y Distribución**

   - [ ] Configurar metadatos NuGet completos
   - [ ] Crear samples de uso
   - [ ] Setup de changelog automático
   - [ ] Preparar documentación para NuGet.org

3. **Release Management**
   - [ ] Primera release candidate (1.0.0-rc1)
   - [ ] Testing en proyectos reales
   - [ ] Release estable (1.0.0)

**Criterios de Éxito:**

- Paquete publicado en NuGet.org
- Documentación completa
- Feedback positivo de early adopters

### Fase 4: Expansión y Mantenimiento (Ongoing)

**Objetivo:** Evolución continua

**Backlog de Funcionalidades:**

- **Web Utilities**: HTTP helpers, API client utilities
- **Data Utilities**: CSV/Excel helpers, data transformation
- **Logging Utilities**: Structured logging extensions
- **Security Utilities**: Authentication/authorization helpers
- **Cloud Utilities**: Azure/AWS integration helpers

## 📚 Utilidades Sugeridas para Implementar

### 1. String Extensions

```csharp
public static class StringExtensions
{
    public static bool IsValidEmail(this string email);
    public static bool IsValidUrl(this string url);
    public static string ToTitleCase(this string input);
    public static string RemoveSpecialCharacters(this string input);
    public static bool IsNumeric(this string input);
    public static string Truncate(this string input, int maxLength);
}
```

### 2. Collection Extensions

```csharp
public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source);
    public static bool SafeAny<T>(this IEnumerable<T> source, Func<T, bool> predicate = null);
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page, int pageSize);
    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize);
}
```

### 3. DateTime Extensions

```csharp
public static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime date);
    public static int GetAge(this DateTime birthDate);
    public static long ToUnixTimestamp(this DateTime dateTime);
    public static DateTime FromUnixTimestamp(this long unixTimestamp);
    public static bool IsBusinessDay(this DateTime date);
}
```

### 4. Validation Helpers

```csharp
public static class ValidationHelper
{
    public static ValidationResult ValidateEmail(string email);
    public static ValidationResult ValidatePhoneNumber(string phoneNumber);
    public static ValidationResult ValidatePassword(string password, PasswordPolicy policy);
    public static bool IsValidCreditCard(string cardNumber);
}
```

## 🔧 Setup del Proyecto

### 1. Crear la Estructura Inicial

```bash
dotnet new sln -n dotnet-utils-tdd
cd dotnet-utils-tdd

# Crear proyecto principal
dotnet new classlib -n DotNetUtils.Core -f net8.0
dotnet sln add src/DotNetUtils.Core/DotNetUtils.Core.csproj

# Crear proyecto de tests
dotnet new xunit -n DotNetUtils.Core.Tests -f net8.0
dotnet sln add tests/DotNetUtils.Core.Tests/DotNetUtils.Core.Tests.csproj

# Referenciar el proyecto principal desde tests
dotnet add tests/DotNetUtils.Core.Tests reference src/DotNetUtils.Core
```

### 2. Configurar Dependencias de Testing

```xml
<!-- En DotNetUtils.Core.Tests.csproj -->
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="Moq" Version="4.20.69" />
<PackageReference Include="coverlet.collector" Version="6.0.0" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
<PackageReference Include="xunit" Version="2.6.1" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.5.3" />
```

### 3. Configurar Análisis de Código

```xml
<!-- En DotNetUtils.Core.csproj -->
<PackageReference Include="SonarAnalyzer.CSharp" Version="9.12.0.78982">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
</PackageReference>
<PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
</PackageReference>
```

## 📊 Métricas de Calidad

### Objetivos de Calidad

- **Code Coverage**: 100%
- **Cyclomatic Complexity**: < 10 por método
- **Maintainability Index**: > 80
- **Technical Debt Ratio**: < 5%

### Herramientas de Monitoreo

- **SonarQube/SonarCloud**: Análisis continuo de calidad
- **Codecov**: Coverage tracking
- **Dependabot**: Security updates automáticas
- **CodeClimate**: Maintainability metrics

## 🔒 Consideraciones de Seguridad

### Security Best Practices

1. **Dependency Scanning**: Usar Dependabot y Snyk
2. **SAST Analysis**: Integrar herramientas de análisis estático
3. **Secrets Management**: Nunca hardcodear secrets
4. **Input Validation**: Validar todas las entradas
5. **Secure Defaults**: Configuraciones seguras por defecto

### Security Testing

```csharp
[Fact]
public void CryptoHelper_HashPassword_ShouldNotReturnPlaintext()
{
    // Arrange
    var password = "sensitivePassword123";

    // Act
    var hash = CryptoHelper.HashPassword(password);

    // Assert
    hash.Should().NotBe(password);
    hash.Should().NotBeNullOrEmpty();
}
```

## 📖 Documentación

### README.md Template

````markdown
# DotNetUtils.Core

[![NuGet Version](https://img.shields.io/nuget/v/DotNetUtils.Core.svg)](https://www.nuget.org/packages/DotNetUtils.Core/)
[![Build Status](https://github.com/tu-usuario/dotnet-utils-tdd/workflows/CI/badge.svg)](https://github.com/tu-usuario/dotnet-utils-tdd/actions)
[![Code Coverage](https://codecov.io/gh/tu-usuario/dotnet-utils-tdd/branch/main/graph/badge.svg)](https://codecov.io/gh/tu-usuario/dotnet-utils-tdd)

## Instalación

```bash
dotnet add package DotNetUtils.Core
```
````

## Uso Básico

```csharp
using DotNetUtils.Core.Extensions;

var email = "test@example.com";
if (email.IsValidEmail())
{
    Console.WriteLine("Email válido");
}
```

### Documentación XML

```csharp
/// <summary>
/// Validates if the specified string is a valid email address.
/// </summary>
/// <param name="email">The email string to validate.</param>
/// <returns>True if the email is valid; otherwise, false.</returns>
/// <exception cref="ArgumentNullException">Thrown when email is null.</exception>
/// <example>
/// <code>
/// var email = "test@example.com";
/// var isValid = email.IsValidEmail(); // Returns true
/// </code>
/// </example>
public static bool IsValidEmail(this string email)
```

## 🎉 Próximos Pasos

1. **Crear el repositorio** en GitHub con la estructura propuesta
2. **Implementar las primeras utilidades** siguiendo TDD estrictamente
3. **Configurar CI/CD** con GitHub Actions
4. **Escribir documentación** detallada
5. **Publicar primera versión alpha** para feedback temprano

## 💡 Tips para el Éxito

### Development Workflow

1. **Siempre escribir el test primero** (Red)
2. **Implementar el mínimo código** para pasar (Green)
3. **Refactorizar con confianza** (Refactor)
4. **Commitear frecuentemente** con mensajes descriptivos
5. **Code review** para cada feature

### Team Collaboration

- Usar **conventional commits** para changelog automático
- **Pair programming** para funcionalidades complejas
- **Regular retrospectives** para mejorar el proceso
- **Documentation-driven development** para APIs públicas

¡Este roadmap te dará una base sólida para crear un proyecto de utilidades .NET de alta calidad usando TDD! ¿Te gustaría que profundice en alguna fase específica o ayude con la implementación de alguna utilidad en particular?
