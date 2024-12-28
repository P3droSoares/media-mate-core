using MediaMate;

namespace MediaMate
{
    public static partial class MediaMateCore
    {
        public static string TemporaryFolder { get; } = Path.Combine(Path.GetTempPath(), "Media Mate");
        public static string MusicFolder { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Media Mate");
    }
}

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        var app = await MediaMateCore.Youtube.DownloadTrackAsMp3("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
//    }
//}
