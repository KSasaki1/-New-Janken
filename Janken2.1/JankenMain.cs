using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken2._1
{
    class JankenMain
    {
        public static void Main()
        {
            // プレイ回数、人数設定
            GameMaster.SetNumbersRelateToPlay();

            // 全プレイヤーを格納するリスト
            var players = new List<AbstractPlayer>();

            // 通常プレイヤー数に応じてプレイヤーのインスタンスをリストへ格納、名前を設定
            for (int i = 0; i < GameMaster.PlayerCount; i++)
            {
                players.Add(new Player());
                players[i].Name = $"Player{i + 1}";
            }

            // CPプレイヤー数に応じてCPプレイヤーのインスタンスをリストへ格納、名前を設定
            for (int i = GameMaster.PlayerCount; i < GameMaster.NpcCount + GameMaster.PlayerCount; i++)
            {
                players.Add(new NPCPlayer());
                players[i].Name = $"NPCPlayer{i - GameMaster.PlayerCount + 1}";
            }

            // CPプレイヤーの手を決定するメソッドで使用する
            Random handRandom = new Random();

            ShiftCalculation shift = new ShiftCalculation();
            Judge judge = new Judge();
            OutPutResult output = new OutPutResult();

            // じゃんけんでどの手が勝ったのかを入れておく
            int　judged;

            // ゲーム回数だけ繰り返す
            for (int i = 0; i < GameMaster.GameCount; i++)
            {
                // 引き分けの間繰り返す
                do
                {
                    // シフト演算の結果を初期化
                    ShiftCalculation.AssignShiftCalcResult = 0;

                    // リスト内全員の手を設定、どの手が出ているかをシフト演算で計算
                    foreach (var player in players)
                    {
                        player.SetHand();
                        player.SetHand(handRandom);
                        shift.PlayersShiftCalc((int) player.Hand);
                    }

                    // 全員の手を表示
                    foreach (var player in players)
                    {
                        Console.WriteLine($"{player.Name}:{player.Hand}");
                    }

                    judged = judge.Judger();

                } while (Judge.Draw);

                // intをJankenHandに変換
                JankenHand hand = (JankenHand) Enum.ToObject(typeof(JankenHand), judged);

                // 勝者のみをリストから取り出す
                IEnumerable<AbstractPlayer> winnerQuery = players.Where(x => x.Hand == hand);

                Console.WriteLine();
                Console.WriteLine($"↓↓WINNER IS [{hand}]↓↓");
                foreach (var winner in winnerQuery)
                {
                    // 勝者を表示
                    Console.WriteLine(winner.Name);

                    // 勝ち数を加算
                    winner.WinStatus += 1;
                }
                Console.WriteLine();
            }

            // 成績の文字列を格納;
            var result = new List<string>();

            // 総合結果を格納
            foreach (var player in players)
            {
                result.Add( ($"{player.Name}:" +
                          $"　■win:[{player.WinStatus}]" +
                          $"　■lose:[{GameMaster.GameCount - player.WinStatus}]" +
                          $"　■winrate[{((double)player.WinStatus / (double)GameMaster.GameCount):P}]"));
            }

            // 結果表示
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }

            // 結果出力
            output.ExportResult(result);
        }
    }
}
