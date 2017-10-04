using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Maze
	{
        public Character character { get; set; }
        public Location firstLoc { get; set; }
        public Worker worker { get; set; }
		public int height { get; set; }
		public int width { get; set; }

        public Crate[] crates;

        public Maze()
        {
            
        }

                
	}
}
