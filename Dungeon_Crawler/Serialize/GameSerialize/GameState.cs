using Dungeon_Crawler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler.Serialize.GameSerialize;

public class GameState
{
    public Hero Hero { get; set; }
    public List<Monster> Monsters { get; set; }
}
