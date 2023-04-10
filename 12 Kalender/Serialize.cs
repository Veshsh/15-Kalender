using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Kalender
{

    static class Serializer
    {
        public static Save save=new Save();
        public static List<Save> saves = new List<Save>();
        public static void Serialize<T>(T value)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\source\\repos\\15 Kalender\\12 Kalender\\ster.json", JsonConvert.SerializeObject(value));
        }
        public static T Deserialize<T>()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\source\\repos\\15 Kalender\\12 Kalender\\ster.json"));
        }
    }
}
