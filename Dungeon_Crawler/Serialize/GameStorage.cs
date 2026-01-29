using Dungeon_Crawler.Serialize.GameSerialize;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dungeon_Crawler.Serialize;

public class GameStorage
{
    private readonly string _path;
    public GameStorage(string path)
    {
        _path = path;
    }

    public void Save(GameState state)
    {
        File.WriteAllText(_path, JsonConvert.SerializeObject(state));
    }
}
