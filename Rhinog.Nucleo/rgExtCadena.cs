
namespace System
{
    /// <summary>
    /// Extencion para operaciones con cadenas de caracteres
    /// </summary>
    public static class ExtCadena
    {
        /// <summary>
        /// Convierte la primera letra de la cadena en Mayuscula
        /// </summary>
        /// <param name="source">Texto que se desea cambiar</param>
        /// <returns></returns>        
        public static string PrimeraLetraEnMayuscula(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // Convertimos la cadena en un arreglo de letras
            char[] letras = source.ToCharArray();
            
            // Cambiamos la primera letra del arreglo en mayuscula
            letras[0] = char.ToUpper(letras[0]);
            
            // Convertimos el arreglo de letras en una cadena y lo retornamos
            return new string(letras);

        }
    }
}