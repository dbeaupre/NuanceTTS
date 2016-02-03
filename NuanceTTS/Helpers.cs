using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuanceTTS
{
    public static class Helpers
    {
        public static class URL
        {
            //TODO: mettre en configs
            private static string _voice = "Samantha"; // "Tom";
            private static string _language = "fr_ca";
            private static string _url = @"https://tts.nuancemobility.net/NMDPTTSCmdServlet/tts";

            private static string _appId = @"NMDPTRIAL_dominic_beaupre_gmail_com20150825190219";
            private static string _appKey = @"4638455ad3220bf41de0fdc999d6d70b9fda4e912eb5e2baaec3fa72ad0369f33bae4e0ed05903ed3900b7d3d68ede75682c0696e1e8518fab4b01584e6a4c89";

            public static string NuanceURL
			{
				get {
                    if (!string.IsNullOrEmpty(_language))
                        {
                        return string.Format("{0}?appId={1}&appKey={2}&id={3}&ttsLang={4}",
                    _url, _appId, _appKey, Guid.NewGuid().ToString(), _language);
                    }
                    return string.Format("{0}?appId={1}&appKey={2}&id={3}&voice={4}",
                       _url, _appId, _appKey, Guid.NewGuid().ToString(), _voice);
                }
			}
            }

        }
    }

