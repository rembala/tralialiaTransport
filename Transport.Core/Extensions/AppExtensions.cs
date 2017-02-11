using System;
using System.Collections.Generic;
using System.Linq;
using Transport.Core.Validation;

namespace Transport.Core.Extensions
{
    public static class AppExtensions
    {
        /// <summary>
        /// Jei NULL ar DbNullValue tai true
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this Object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Grazina objekta sukonvertuota i stringa, isvengiam null erroro
        /// </summary>
        public static string ToSafeString(this object obj)
        {
            return (obj ?? string.Empty).ToString();
        }


        /// <summary>
        /// Jei stringas tuscias, tai true;
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            if (str == null || str.Trim() == "")
                return true;
            else
                return false;
        }




        /// <summary>
        /// jei reiksme tuscia, grazina DBNull.Value, kitu atveju reiksme
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetDbParamObject(this string obj)
        {
            return obj.IsEmpty() ? (object)DBNull.Value : obj;
        }

        /// <summary>
        /// jei reiksme tuscia, grazina DBNull.Value, kitu atveju reiksme
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetDbParamObject(this int? obj)
        {
            return !obj.HasValue ? (object)DBNull.Value : obj;
        }

        /// <summary>
        /// jei reiksme tuscia, grazina DBNull.Value, kitu atveju reiksme
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetDbParamObject(this decimal? obj)
        {
            return !obj.HasValue ? (object)DBNull.Value : obj;
        }

        /// <summary>
        /// jei reiksme tuscia, grazina DBNull.Value, kitu atveju reiksme
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetDbParamObject(this DateTime? obj)
        {
            return !obj.HasValue ? (object)DBNull.Value : obj;
        }



        public static List<ValidationErrorRow> GetErrorList(this System.Web.Mvc.ModelStateDictionary modelState)
        {
            var result = (
                        from key in modelState.Keys
                        from err in modelState[key].Errors
                                    .GroupBy(z => z)
                                    .Where(z => z.Count() > 0 && (z.Key.ErrorMessage != null))
                                    .Select(z => z.Key.ErrorMessage)
                        select new ValidationErrorRow
                        {
                            ColumnName = key,
                            Message = err
                        }
                      ).ToList();

            return result ?? new List<ValidationErrorRow>();
        }
    }
}
