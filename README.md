# DotNetUtils.Core

[![Build Status](https://github.com/TomDiem/dotnet-utils-tdd/workflows/CI%2FCD%20Pipeline/badge.svg)](https://github.com/TomDiem/dotnet-utils-tdd/actions)

Un conjunto completo de utilidades para .NET desarrolladas con Test-Driven Development (TDD).

## 📦 Instalación

```bash
dotnet add package DotNetUtils.Core
```

## 🛠️ Funcionalidades Incluidas

### String Extensions

- `IsValidEmail()` - Validación de emails
- `IsValidUrl()` - Validación de URLs
- `ToTitleCase()` - Formateo de texto
- `RemoveSpecialCharacters()` - Limpieza de strings
- `IsNumeric()` - Verificación numérica
- `Truncate()` - Recorte de texto

### Collection Extensions

- `IsNullOrEmpty<T>()` - Verificación segura de colecciones
- `SafeAny<T>()` - Verificación sin excepciones
- `Paginate<T>()` - Paginación de listas
- `Batch<T>()` - Procesamiento por lotes

### DateTime Extensions

- `IsWeekend()` - Verificación de fin de semana
- `GetAge()` - Cálculo de edad
- `ToUnixTimestamp()` - Conversión Unix
- `FromUnixTimestamp()` - Conversión desde Unix
- `IsBusinessDay()` - Verificación de día laboral

### Validation Helpers

- `ValidateEmail()` - Validación avanzada de email
- `ValidatePhoneNumber()` - Validación de teléfonos
- `ValidatePassword()` - Validación con políticas
- `IsValidCreditCard()` - Validación de tarjetas

### Crypto Helpers (Planificado)

- `HashPassword()` - Hash seguro de contraseñas
- `GenerateSalt()` - Generación de salt
- `EncryptString()` - Encriptación básica

### JSON Helpers (Planificado)

- `SafeSerialize<T>()` - Serialización segura
- `SafeDeserialize<T>()` - Deserialización segura
- `TryParseJson()` - Parsing con validación

## 🏗️ Filosofía del Proyecto

### Desarrollo con TDD

Cada funcionalidad sigue el ciclo **Red-Green-Refactor**:

1. **🔴 Red**: Escribir test que falle
2. **🟢 Green**: Implementar código mínimo
3. **🔵 Refactor**: Mejorar manteniendo tests verdes

### Código para Compartir

- **API Limpia**: Métodos intuitivos y bien nombrados
- **Documentación Completa**: XML docs para IntelliSense
- **Versionado Semántico**: Actualizaciones predecibles
- **Backward Compatibility**: Preservar compatibilidad entre versiones

## 🚀 Casos de Uso Ideales

- **Aplicaciones Web**: Validación de formularios, formateo de datos
- **APIs REST**: Helpers comunes para responses y requests
- **Microservicios**: Utilidades compartidas entre servicios
- **Bibliotecas de Dominio**: Base para reglas de negocio
- **Aplicaciones de Consola**: Procesamiento de datos y archivos

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
