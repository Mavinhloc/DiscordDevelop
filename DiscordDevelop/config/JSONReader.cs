using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDevelop.config
{
    internal class JSONReader
    {
        public string token { get; set; }
        public string prefix { get; set; }

        public async Task ReadJSON()
        {
            using (StreamReader reader = new StreamReader("config.json"))
            {
                string json = await reader.ReadToEndAsync();
                JSONStructure structure = JsonConvert.DeserializeObject<JSONStructure>(json);

                this.token = structure.token;

                this.prefix = structure.prefix;
            }
        }
    }

    internal sealed class JSONStructure
    {
        public string token { get; set; }
        public string prefix { get; set; }
    }
}
