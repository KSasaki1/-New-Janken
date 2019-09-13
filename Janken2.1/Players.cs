using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken2._1
{
    abstract class AbstractPlayer
    {
        /// <summary>
        /// プレイヤーの名前
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// プレイヤーのじゃんけんの手
        /// </summary>
        public JankenHand Hand { get; set; }

        /// <summary>
        /// プレイヤーの勝利回数
        /// </summary>
        public int WinStatus { get; set; }

        /// <summary>
        /// インスタンス作成時に勝ち数を初期化
        /// </summary>
        public AbstractPlayer()
        {
            WinStatus = 0;
        }

        /// <summary>
        /// 通常プレイヤー用
        /// </summary>
        public virtual void SetHand()
        {
        }

        /// <summary>
        /// NPCプレイヤー用
        /// </summary>
        /// <param name="rand">乱数生成をするためのインスタンス</param>
        public virtual void SetHand(Random rand)
        {
        }

        /// <summary>
        /// int型をJankenHand型(enum)に変換する
        /// </summary>
        /// <param name="handnum">int型の数値</param>
        /// <returns>JankenHand(enum)</returns>
        public JankenHand Convert(int handnum)
        {
            JankenHand sethand = (JankenHand)Enum.ToObject(typeof(JankenHand), handnum);
            return sethand;
        }
    }

    /// <summary>
    /// プレイヤー
    /// </summary>
    class Player : AbstractPlayer
    {
        public Player() : base()
        {
        }

        /// <summary>
        /// プレイヤーの手を設定する
        /// </summary>
        public override void SetHand()
        {
            int hand;
            do
            {
                Console.WriteLine();
                Console.Write("input a number({0}:{1}, {2}:{3}, {4}:{5})>>", nameof(JankenHand.Rock), (int)JankenHand.Rock, nameof(JankenHand.Paper), (int)JankenHand.Paper, nameof(JankenHand.Scissors), (int)JankenHand.Scissors);
                hand = GameMaster.TryInputValidNumber();
            }
            while (hand < (int)JankenHand.Rock || hand > (int)JankenHand.Scissors);

            Hand = Convert(hand);
        }
    }

    /// <summary>
    /// NPCプレイヤー
    /// </summary>
    class NPCPlayer : AbstractPlayer
    {
        public NPCPlayer() : base()
        {
        }

        /// <summary>
        /// NPCプレイヤーの手を設定する
        /// </summary>
        /// <param name="rand">乱数生成をするためのインスタンス</param>
        public override void SetHand(Random rand)
        {
            var hand = rand.Next(1, 4);
            Hand = Convert(hand);
        }
    }
}
