using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.GameObjects
{
    public class RailManager
    {

        public static List<Rail> Rails = new List<Rail>();

        public static void DrawInstances()
        {
            if(Rails.Count > 0)
            {
                foreach (Rail r in Rails)
                {
                    r.Draw();
                }
            }
        }
    }
}
