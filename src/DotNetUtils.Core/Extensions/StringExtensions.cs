// <copyright file="StringExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DotNetUtils.Core.Extensions
{
    using System.Globalization;
    using System.Net.Mail;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extensiones para la clase String que proporcionan funcionalidades comunes de validación,
    /// formateo y manipulación de cadenas de texto.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Valida si la cadena de texto es una dirección de email válida.
        /// </summary>
        /// <param name="email">La cadena de texto a validar como email.</param>
        /// <returns>True si el email es válido; de lo contrario, false.</returns>
        /// <example>
        /// <code>
        /// var email = "usuario@ejemplo.com";
        /// bool esValido = email.IsValidEmail(); // Retorna true
        /// var emailInvalido = "email-sin-arroba";
        /// bool esInvalido = emailInvalido.IsValidEmail(); // Retorna false
        /// </code>
        /// </example>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Usar MailAddress para validación robusta
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida si la cadena de texto es una URL válida.
        /// </summary>
        /// <param name="url">La cadena de texto a validar como URL.</param>
        /// <returns>True si la URL es válida; de lo contrario, false.</returns>
        /// <example>
        /// <code>
        /// var url = "https://www.ejemplo.com";
        /// bool esValida = url.IsValidUrl(); // Retorna true
        /// var urlInvalida = "no-es-una-url";
        /// bool esInvalida = urlInvalida.IsValidUrl(); // Retorna false
        /// </code>
        /// </example>
        public static bool IsValidUrl(this string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            return Uri.TryCreate(url, UriKind.Absolute, out Uri? result) &&
                   (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Convierte la cadena de texto a formato Title Case (Primera Letra De Cada Palabra En Mayúscula).
        /// </summary>
        /// <param name="input">La cadena de texto a convertir.</param>
        /// <returns>La cadena convertida a Title Case, o null si la entrada es null.</returns>
        /// <example>
        /// <code>
        /// var texto = "hola mundo";
        /// string titulo = texto.ToTitleCase(); // Retorna "Hola Mundo"
        /// var textoMixto = "hELLo WoRLd";
        /// string tituloMixto = textoMixto.ToTitleCase(); // Retorna "Hello World"
        /// </code>
        /// </example>
        public static string? ToTitleCase(this string? input)
        {
            if (input == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLowerInvariant());
        }

        /// <summary>
        /// Remueve todos los caracteres especiales de la cadena, manteniendo solo letras, números y espacios.
        /// </summary>
        /// <param name="input">La cadena de texto a limpiar.</param>
        /// <returns>La cadena sin caracteres especiales, o null si la entrada es null.</returns>
        /// <example>
        /// <code>
        /// var textoSucio = "Hola!@# Mundo$%^";
        /// string limpio = textoSucio.RemoveSpecialCharacters(); // Retorna "Hola Mundo"
        /// var soloEspeciales = "!@#$%";
        /// string vacio = soloEspeciales.RemoveSpecialCharacters(); // Retorna ""
        /// </code>
        /// </example>
        public static string? RemoveSpecialCharacters(this string? input)
        {
            if (input == null)
            {
                return null;
            }

            // Regex que mantiene solo letras, números y espacios
            return Regex.Replace(input, @"[^a-zA-Z0-9\s]", string.Empty);
        }

        /// <summary>
        /// Determina si la cadena de texto representa un valor numérico válido.
        /// </summary>
        /// <param name="input">La cadena de texto a validar.</param>
        /// <returns>True si la cadena representa un número; de lo contrario, false.</returns>
        /// <example>
        /// <code>
        /// var numero = "123.45";
        /// bool esNumero = numero.IsNumeric(); // Retorna true
        /// var texto = "abc123";
        /// bool noEsNumero = texto.IsNumeric(); // Retorna false
        /// var negativo = "-456.78";
        /// bool esNegativo = negativo.IsNumeric(); // Retorna true
        /// </code>
        /// </example>
        public static bool IsNumeric(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Trunca la cadena de texto a la longitud máxima especificada.
        /// </summary>
        /// <param name="input">La cadena de texto a truncar.</param>
        /// <param name="maxLength">La longitud máxima permitida.</param>
        /// <returns>La cadena truncada, o null si la entrada es null.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando maxLength es negativo.</exception>
        /// <example>
        /// <code>
        /// var texto = "Esta es una cadena muy larga";
        /// string truncado = texto.Truncate(10); // Retorna "Esta es un"
        /// var textoCorto = "Corto";
        /// string sinCambios = textoCorto.Truncate(10); // Retorna "Corto"
        /// </code>
        /// </example>
        public static string? Truncate(this string? input, int maxLength)
        {
            if (maxLength < 0)
            {
                throw new ArgumentException("Max length cannot be negative.", nameof(maxLength));
            }

            if (input == null)
            {
                return null;
            }

            if (maxLength == 0)
            {
                return string.Empty;
            }

            return input.Length <= maxLength ? input : input[..maxLength];
        }

        /// <summary>
        /// Trunca la cadena de texto a la longitud máxima especificada, añadiendo puntos suspensivos (...)
        /// al final si la cadena fue truncada.
        /// </summary>
        /// <param name="input">La cadena de texto a truncar.</param>
        /// <param name="maxLength">La longitud máxima permitida, incluyendo los puntos suspensivos.</param>
        /// <returns>La cadena truncada con puntos suspensivos si fue necesario, o null si la entrada es null.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando maxLength es menor a 3.</exception>
        /// <example>
        /// <code>
        /// var texto = "Esta es una cadena muy larga para mostrar";
        /// string conPuntos = texto.TruncateWithEllipsis(20); // Retorna "Esta es una caden..."
        /// var textoCorto = "Corto";
        /// string sinCambios = textoCorto.TruncateWithEllipsis(20); // Retorna "Corto"
        /// </code>
        /// </example>
        public static string? TruncateWithEllipsis(this string? input, int maxLength)
        {
            if (maxLength < 3)
            {
                throw new ArgumentException("Max length must be at least 3 to accommodate ellipsis.", nameof(maxLength));
            }

            if (input == null)
            {
                return null;
            }

            if (input.Length <= maxLength)
            {
                return input;
            }

            return input[.. (maxLength - 3)] + "...";
        }
    }
}