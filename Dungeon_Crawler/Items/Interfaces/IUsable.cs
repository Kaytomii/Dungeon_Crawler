using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Core;
namespace Dungeon_Crawler.Items.Interfaces
{
    public interface IUsable
    {
        void Use(Hero hero);
    }
}
