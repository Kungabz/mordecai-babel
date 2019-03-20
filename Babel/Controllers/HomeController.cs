using Google.Cloud.Translation.V2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Babel.Controllers
{
    public class Trans
    {
        public string Text { get; set; }

        public string Code { get; set; }
    }
    public class Lang
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    public class HomeController : Controller
    {

        public ActionResult Index()

        {

            TranslationClient client = TranslationClient.Create();
            var response1 = client.ListLanguages();
            List<Lang> langs = new List<Lang>();
            foreach(Language L in response1)
            {
                Lang m = new Lang();
                m.Code = L.Code;
                m.Name = Getname(L.Code);
                langs.Add(m);
            }
            ViewData["Languages"] = langs;

            return View(new Trans());
        }

        [HttpPost]
        public ActionResult Index(Trans model)
        {
          TranslationClient client = TranslationClient.Create();
            var response1 = client.ListLanguages();
            List<Lang> langs = new List<Lang>();
            foreach (Language L in response1)
            {
                Lang m = new Lang();
                m.Code = L.Code;
                m.Name = Getname(L.Code);
                langs.Add(m);
            }
            ViewData["Languages"] = langs;
            if (model.Code == null)
            {
                model.Code = "fr";
            }
           var response = client.TranslateText(model.Text, model.Code);
            ViewBag.Message = response.TranslatedText+" - "+Getname( response.TargetLanguage);

            return View();
        }

        public ActionResult About()
        {
            TranslationClient client = TranslationClient.Create();
            var response1 = client.ListLanguages();
            string languages = JsonConvert.SerializeObject(response1);
            var response = client.TranslateText("Hello my name is Mordecai.", "ha");
            ViewBag.Message = languages+" "+ response.TranslatedText;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Getname(string code)
        {
            switch (code)
            {

                case "af":
                    return "afrikaans";
                case "am":
                    return "amharic";
                case "ar":
                    return "arabic";
                case "az":
                    return "azerbaijani";
                case "be":
                    return "byelorussian";
                case "bg":
                    return "bulgarian";
                case "bn":
                    return "bengali";
                case "bs":
                    return "bosnian";
                case "ca":
                    return "catalan";
                case "ceb":
                    return "cebuano";
                case "co":
                    return "corsican";
                case "cs":
                    return "czech";
                case "cy":
                    return "welsh";
                case "da":
                    return "danish";
                case "de":
                    return "deutsch(german)";
                case "el":
                    return "greek";
                case "en":
                    return "english";
                case "eo":
                    return "esperanto";
                case "es":
                    return "spanish";
                case "et":
                    return "estonian";
                case "eu":
                    return "basque";
                case "fa":
                    return "farsi(persian)";
                case "fi":
                    return "finnish";
                case "fr":
                    return "french";
                case "fy":
                    return "frisian";
                case "ga":
                    return "gaelic(irish)";
                case "gd":
                    return "scots gaelic";
                case "gl":
                    return "galician";
                case "gu":
                    return "gujarati";
                case "ha":
                    return "hausa";
                case "haw":
                    return "hawaiian";
                case "hi":
                    return "hindi";
                case "hr":
                    return "croatian";
                case "ht":
                    return "haitian";
                case "hu":
                    return "hungarian";
                case "hy":
                    return "armenian";
                case "id":
                    return "indonesian";
                case "ig":
                    return "igbo";
                case "is":
                    return "icelandic";
                case "it":
                    return "italian";
                case "iw":
                    return "hebrew";
                case "ja":
                    return "japanese";
                case "jw":
                    return "javanese";
                case "ka":
                    return "georgian";
                case "kk":
                    return "kazakh";
                case "km":
                    return "cambodian";
                case "kn":
                    return "kannada";
                case "ko":
                    return "korean";
                case "ku":
                    return "kurdish";
                case "ky":
                    return "kirghiz";
                case "la":
                    return "latin";
                case "lb":
                    return "luxembourgish";
                case "lo":
                    return "laothian";
                case "lt":
                    return "lithuanian";
                case "lv":
                    return "lettish";
                case "mg":
                    return "malagasy";
                case "mi":
                    return "maori";
                case "mk":
                    return "macedonian";
                case "ml":
                    return "malayalam";
                case "mn":
                    return "mongolian";
                case "mr":
                    return "marathi";
                case "ms":
                    return "malay";
                case "mt":
                    return "maltese";
                case "my":
                    return "burmese";
                case "ne":
                    return "nepali";
                case "nl":
                    return "dutch(netherlands)";
                case "no":
                    return "norwegian";
                case "ny":
                    return "chichewa";
                case "pa":
                    return "punjabi";
                case "pl":
                    return "polish";
                case "ps":
                    return "pashto";
                case "pt":
                    return "portuguese";
                case "ro":
                    return "romanian";
                case "ru":
                    return "russian";
                case "sd":
                    return "sindhi";
                case "si":
                    return "singhalese";
                case "sk":
                    return "slovak";
                case "sl":
                    return "slovenian";
                case "sm":
                    return "samoan";
                case "sn":
                    return "shona";
                case "so":
                    return "somali";
                case "sq":
                    return "albanian";
                case "sr":
                    return "serbian";
                case "st":
                    return "sesotho";
                case "su":
                    return "sundanese";
                case "sv":
                    return "swedish";
                case "sw":
                    return "swahili";
                case "ta":
                    return "tamil";
                case "te":
                    return "telugu";
                case "tg":
                    return "tajik";
                case "th":
                    return "thai";
                case "tl":
                    return "tagalog";
                case "tr":
                    return "turkish";
                case "uk":
                    return "ukrainian";
                case "ur":
                    return "urdu";
                case "uz":
                    return "uzbek";
                case "vi":
                    return "vietnamese";
                case "xh":
                    return "xhosa";
                case "yi":
                    return "yiddish";
                case "yo":
                    return "yoruba";
                case "zh":
                    return "chinese";
                case "zh-TW":
                    return "chinese traditional";
                case "zu":
                    return "zulu";

                default:
                    return code;

            }

        }
    }
}