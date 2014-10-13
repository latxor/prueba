
namespace System
{
    /// <summary>
    /// Extencion para opereciones de Fecha y hora
    /// </summary>
    public static class ExtFechaHora
    {
       
        
        /// <summary>
        /// Retorna el ultimo dia del mes. Formato[dd/MM/yyyy]
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string UltimoDiaDelMes(this DateTime date)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1).ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Retorna el ultimo dia del mes indicado
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formato"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string UltimoDiaDelMes(this DateTime date, string formato)
        {
            if (string.IsNullOrEmpty(formato))
                throw new ArgumentException("El valor del parametro formato no debe ser null o Empty");

            return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1).ToString(formato);
        }

        /// <summary>
        /// Indica el ultimo dia del mes enviados como pararmetro 
        /// </summary>
        /// <param name="date">Fecha que desea ser consultada</param>
        /// <returns></returns>
        public static int UltimoDiaDelMesAEntero(this DateTime date)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1).Day;
        }
    }

   
}
