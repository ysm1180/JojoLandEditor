using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandEditor
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LandEditor());
        }

        public static Array ResizeArray<T>(this T[,,] orgArray, int dimension1, int dimension2, int dimension3)
        {
            T[,,] newArray = new T[dimension1, dimension2, dimension3];
            int minX = Math.Min(orgArray.GetLength(0), newArray.GetLength(0));
            int minY = Math.Min(orgArray.GetLength(1), newArray.GetLength(1));
            int minZ = Math.Min(orgArray.GetLength(2), newArray.GetLength(2));

            for (int i = 0; i < minX; ++i)
            {
                for (int j = 0; j < minY; ++j)
                {
                    Array.Copy(orgArray, i * orgArray.GetLength(1) + j * orgArray.GetLength(2),
                        newArray, i * newArray.GetLength(1) + j * orgArray.GetLength(2), minZ);
                }
            }

            return newArray;
        }

        public static string FilePath { get; set; }
    }
}
