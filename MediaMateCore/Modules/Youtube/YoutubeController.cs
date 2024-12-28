namespace MediaMate
{
    public partial class MediaMateCore
    {
        public static class Youtube
        {
            public static async Task<object> DownloadTrackAsMp3(string trackUrl)
            {
                return await YoutubeServices.DownloadTrackAsMp3(trackUrl);
            }
        }
    }
}
