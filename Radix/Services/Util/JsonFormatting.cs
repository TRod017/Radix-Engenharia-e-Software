using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services.Util
{
    /// <summary>
    /// Manipual Json
    /// </summary>
    public class JsonFormatting
    {

        /// <summary>
        /// Recebe uma string e retorna um Json identado
        /// </summary>
        /// <param name="json">string no formato json sem identação</param>
        /// <returns>string no formato json identada</returns>
        public static string Ident(string json)
        {
            using (var sr = new StringReader(json))
            using (var sw = new StringWriter())
            {
                var jr = new JsonTextReader(sr);
                var jw = new JsonTextWriter(sw) { Formatting = Formatting.Indented };
                jw.WriteToken(jr);
                return sw.ToString();
            }
        }
    }
}
