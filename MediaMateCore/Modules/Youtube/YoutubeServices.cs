using MediaMate.Common.Utils;
using MediaMate.Modules.Converter.Audio;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


namespace MediaMate
{
    public static class YoutubeServices
    {
        public async static Task<object> DownloadTrackAsMp3(string trackUrl)
        {
            if(!Directory.Exists(MediaMateCore.MusicFolder))
            {
                Directory.CreateDirectory(MediaMateCore.MusicFolder);
            }
            
            if(!Directory.Exists(MediaMateCore.TemporaryFolder))
            {
                Directory.CreateDirectory(MediaMateCore.TemporaryFolder);
            }

            var youtube = new YoutubeClient();

            var video = await youtube.Videos.GetAsync(trackUrl);

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(trackUrl);
            var audioStream = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var temporaryFile = Path.Combine(MediaMateCore.TemporaryFolder, $"{Guid.NewGuid()}.webm");
            await youtube.Videos.Streams.DownloadAsync(audioStream, temporaryFile);

            var finalFilePath = new AudioServices().Convert(temporaryFile, $"{MediaMateCore.MusicFolder}/{StringUtils.Sanitize(video.Title)}.mp3");
            File.Delete(temporaryFile);

            return new { };
        }
        
    }
}
