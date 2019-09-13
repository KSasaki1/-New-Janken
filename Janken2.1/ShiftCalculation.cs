using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken2._1
{
    /// <summary>
    /// 論理和によるシフト演算を行いじゃんけんのどの手が出たかを算出する。
    /// </summary>
    public class ShiftCalculation
    {
        private const int ShiftNumber = 1;    // シフト演算に使う2進数の'1'
        private static int assignShiftCalcResult;  // シフト演算の結果をここに代入していく。

        public static int AssignShiftCalcResult
        {
            get => assignShiftCalcResult;
            set => assignShiftCalcResult = value;
        }

        /// <summary>
        /// プレイヤーの出した手を用いてシフト演算を行う
        /// </summary>
        /// <param name="playerHand">プレイヤー、コンピュータの手が格納された配列</param>
        public void PlayersShiftCalc(int playerHand)
        {
            AssignShiftCalcResult |= ShiftNumber << playerHand;
        }
    }
}
