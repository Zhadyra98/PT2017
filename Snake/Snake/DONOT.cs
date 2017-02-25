using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Donsotmove
    {
        public bool Donotmove(Snake sn)
        {


            if (sn.body.Count() >= 2)
            {
                if (sn.body[0].x - sn.body[1].x > 0 && sn.body[0].y == sn.body[1].y)
                    return true;
            }
            return false;
        }
        public bool Donotmove1(Snake sn)
        {


            if (sn.body.Count() >= 2)
            {
                if (sn.body[0].x - sn.body[1].x < 0 && sn.body[0].y == sn.body[1].y)
                    return true;
            }
            return false;

        }
        public bool Donotmove2(Snake sn)
        {


            if (sn.body.Count() >= 2)
            {
                if (sn.body[0].x == sn.body[1].x && sn.body[0].y - sn.body[1].y > 0)
                    return true;
            }
            return false;

        }
        public bool Donotmove3(Snake sn)
        {


            if (sn.body.Count() >= 2)
            {
                if (sn.body[0].x == sn.body[1].x && sn.body[0].y - sn.body[1].y < 0)
                    return true;
            }
            return false;

        }
    }
}
