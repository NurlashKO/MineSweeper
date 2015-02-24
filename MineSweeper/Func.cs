using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Func
    {
        public static int ConvertToInt(string s, int l, int r)
        {
            int x = Convert.ToInt32(s);
            x = Math.Max(x, l);
            x = Math.Min(x, r);
            return x;
        }

        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static string around(int x, int y)
        {
            int cnt = 0;
            for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx;
                    int ny = y + dy;
                    if (!isExists(nx, ny))
                        continue;
                    if (startLoad.game.Mines[nx, ny].Tag == "Mine")
                        cnt++;
                }
            return Convert.ToString(cnt);
        }

        public static bool isWin()
        {
            for (int i = 0; i < startLoad.game.H; i++)
                for (int j = 0; j < startLoad.game.W; j++)
                {
                    Button buf = startLoad.game.Mines[i, j];
                    if (buf.Tag == "" && (buf.Text == "" || buf.Text == "@"))
                        return false;
                }        
            return true;
        }

        public static bool isExists(int x, int y)
        {
            return x >= 0 && y >= 0 && x < startLoad.game.H && y < startLoad.game.W;
        }
    }
}
