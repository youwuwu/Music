using System.ComponentModel;

namespace Music.Player.Enum
{
    public enum OrderModes
    {
        [Description("随机播放")] Random,
        [Description("顺序播放")] InOrder,
        [Description("单曲循环")] LoopSingle,
        [Description("列表循环")] LoopList,
    }
}