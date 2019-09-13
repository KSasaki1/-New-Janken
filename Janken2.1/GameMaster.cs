using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken2._1
{
    /// <summary>
    /// じゃんけんの試合回数、プレイ人数を決定する。
    /// </summary>
    public static class GameMaster
    {
        private static int playerCount; // プレイヤー人数
        private static int npcCount;    // コンピュータの数
        private static int gameCount;   // プレイ回数

        public static int PlayerCount
        {
            get => playerCount;
            private set => playerCount = value;
        }

        public static int NpcCount
        {
            get => npcCount;
            private set => npcCount = value;
        }

        public static int GameCount
        {
            get => gameCount;
            private set => gameCount = value;
        }

        /// <summary>
        /// ゲーム準備のための入力
        /// </summary>
        public static void SetNumbersRelateToPlay()
        {
            // じゃんけんを何ゲームするか決定。
            do
            {
                Console.Write("何回勝負?(1回以上)>>");
                GameCount = TryInputValidNumber();
            }
            while (gameCount == 0);

            // 通常プレイヤーの数を決定。
            Console.Write("プレイヤーは何人?(0人でも可)>>");
            PlayerCount = TryInputValidNumber();

            // コンピュータプレイヤーの数を決定。
            do
            {
                Console.Write("コンピュータは何人?(プレイヤーと合わせて2人以上になるように)>>");
                NpcCount = TryInputValidNumber();
            }
            while ((PlayerCount + NpcCount) < 2);
        }

        /// <summary>
        /// 数値が入力されるまでリトライ
        /// </summary>
        /// <returns>int型の数値</returns>
        public static int TryInputValidNumber()
        {
            string input;           // ここに入力された数値が適切なものかどうかを判断

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out int i) && i >= 0)
                {
                    return i;
                }
                else
                {
                    Console.Write("適切な数値を入力してください>>");
                }
            }
        }
    }
}
