using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken2._1
{
    public class Judge
    {
        // 以下の7つの変数は論理和を用いたシフト演算の計算結果。
        private const int AllRock = 2;        // 全てグーのとき
        private const int AllPaper = 4;       // 全てチョキのとき
        private const int WinPaper = 6;       // パーとグーのみ出ているとき
        private const int AllScissors = 8;    // 全てパーのとき
        private const int WinRock = 10;       // グーとチョキのみ出ているとき
        private const int WinScissors = 12;   // チョキとパーのみ出ているとき
        private const int AllHand = 14;       // 3つの手が出そろったとき

        private static bool draw = false; // 引き分け (true) のときじゃんけんの手の選択から仕切りなおす

        private int winHand;    // 引き分け:0, グーの勝ち:1, パーの勝ち:2, チョキの勝ち:3

        public static bool Draw
        {
            get => draw;
            private set => draw = value;
        }

        /// <summary>
        /// シフト演算で出た結果をもとに全プレイヤーの勝敗引き分けを判断
        /// </summary>
        public int Judger()
        {
            int shiftCalcedNum = ShiftCalculation.AssignShiftCalcResult; // シフト演算で出た結果をここに代入。

            // 以下よりじゃんけんの判定を行う。
            switch (shiftCalcedNum)
            {
                case AllHand:
                case AllRock:
                case AllPaper:
                case AllScissors:
                    Console.WriteLine("     DRAW");
                    Console.WriteLine("-----RETRY-----");
                    this.winHand = 0;
                    Draw = true;
                    break;
                case WinRock:
                    this.winHand = (int)JankenHand.Rock;
                    Draw = false;
                    break;
                case WinPaper:
                    this.winHand = (int)JankenHand.Paper;
                    Draw = false;
                    break;
                case WinScissors:
                    this.winHand = (int)JankenHand.Scissors;
                    Draw = false;
                    break;
                default:
                    break;
            }

            return winHand;
        }
    }
}
