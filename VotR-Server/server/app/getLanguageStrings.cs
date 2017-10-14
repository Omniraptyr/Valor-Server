using System.Collections.Specialized;
using Anna.Request;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace server.app
{
    class getLanguageStrings : RequestHandler
    {
        public static readonly Dictionary<string, string> languages = new Dictionary<string, string>
        {
            {"de", File.ReadAllText("resources/Languages/de.txt")},
            {"en", File.ReadAllText("resources/Languages/en.txt")},
            {"es", File.ReadAllText("resources/Languages/es.txt")},
            {"fr", File.ReadAllText("resources/Languages/fr.txt")},
            {"it", File.ReadAllText("resources/Languages/it.txt")},
            {"ru", File.ReadAllText("resources/Languages/ru.txt")}
        };

        public override void HandleRequest(RequestContext context, NameValueCollection query)
        {
            string lang;
            byte[] buf;
            if (query.AllKeys.Length > 0)
                if (!languages.TryGetValue(query["languageType"], out lang))
                    buf = Encoding.ASCII.GetBytes("<Error>Invalid langauge type.</Error>");
                else
                    buf = Encoding.ASCII.GetBytes(lang);
            else
                buf = Encoding.ASCII.GetBytes("<Error>Invalid langauge type.</Error>");
            Write(context, buf, true);
        }
    }
}
