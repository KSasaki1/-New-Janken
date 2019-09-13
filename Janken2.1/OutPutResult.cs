using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Janken2._1
{
    class OutPutResult
    {
        /// <summary>
        /// じゃんけん最終結果の出力
        /// </summary>
        public void ExportResult(IEnumerable<string> result)
        {
            string wannaExport;
            Console.WriteLine();
            Console.Write("Export result ?(YES:y, NO:n)>>");
            wannaExport = Console.ReadLine();

            if (wannaExport.ToLower() == "y")
            {
                StreamWriter standard = new StreamWriter(Console.OpenStandardOutput());
                using (StreamWriter newwriter = new StreamWriter("Result.txt", false, Encoding.UTF8))
                {
                    Console.SetOut(newwriter);      // Console.WriteLineでファイルへ書き込めるようにする
                    Console.WriteLine("[RESULT]");
                    foreach (var res in result)
                    {
                        Console.WriteLine(res);
                    }
                    Console.SetOut(standard);       // Console.WriteLineで書き込み可能な状態から戻す。
                }

                Console.WriteLine();
                Console.WriteLine("exported");
                Console.WriteLine("quit the game....");
            }
            else if (wannaExport.ToLower() == "n")
            {
                Console.WriteLine("quit the game....");
            }
        }
    }
}
