using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GraphTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\home\dev2010\GraphTesting\";
            XElement formats = XElement.Load(path + "ApplicationProfile.xml").Element("formats");

            Console.WriteLine("Hello!");
            Graph gr = new Graph(@"D:\home\FactographDatabases\GraphTesting\");
            
            gr.Load(new string[] { @"D:\home\dev2010\VStore\0001.xml" });
            //Console.WriteLine("Fin.");

            DateTime tt0 = DateTime.Now;
            // Доступы
            string id = "svet_100616111408_10864"; //"w20070417_5_8436";
            var en = gr.GetEntityInfoById(id);
            if (en.type != null) 
            { 
                var forma = formats.Elements("record").FirstOrDefault(r => r.Attribute("type").Value == en.type);
                XElement res = gr.GetItemById(id, forma);
                //Console.WriteLine(res.ToString());
            }
            //Console.WriteLine("{0} {1} {2}", en.id, en.type, en.entry);
            //return;
            string[] ids = new string[] { 
                "w20070417_5_8436", "w20070417_3_6151", "fog_pavlovskaya200812255059", 
                "svet_100616111408_10844", "fog_pavlovskaya200812255109", "pavl_100531115859_2020", "w20070417_7_10420",
                "pavl_100531115859_6952", "w20070417_3_7936", "svet_100616111408_10864",
                "w20070417_5_8436", "w20070417_3_6151", "fog_pavlovskaya200812255059", 
                "svet_100616111408_10844", "fog_pavlovskaya200812255109", "pavl_100531115859_2020", "w20070417_7_10420",
                "pavl_100531115859_6952", "w20070417_3_7936", "svet_100616111408_10864",
                ""};
            foreach (string ii in ids)
            {
                var entry = gr.GetEntityInfoById(ii);
                if (entry != null)
                {
                    var forma = formats.Elements("record").FirstOrDefault(r => r.Attribute("type").Value == entry.type);
                    XElement res = gr.GetItemById(ii, forma);
                    //Console.WriteLine(res.ToString());
                }
            }
            Console.WriteLine("Entry duration=" + (DateTime.Now - tt0).Ticks / 10000L); tt0 = DateTime.Now;
        }
    }
}
