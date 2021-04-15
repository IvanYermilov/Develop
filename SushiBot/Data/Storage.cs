using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Storage
    {
        public List<Sushi> SushiList = JsonConvert
            .DeserializeObject<List<Sushi>>(File.ReadAllText(@"..\..\SushiList\SushiList.json", Encoding.UTF8));
    } 
}
