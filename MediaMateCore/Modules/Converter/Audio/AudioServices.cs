using NAudio.Lame;
using NAudio.Wave;
using MediaMate.Common.Interface.Converter;


namespace MediaMate.Modules.Converter.Audio
{
    public class AudioServices : IConverterMP3
    {
        public string Convert(string inputPath, string outputPath)
        {
            using(var reader = new MediaFoundationReader(inputPath))
            using(var writer = new LameMP3FileWriter(outputPath, reader.WaveFormat, LAMEPreset.VBR_90))
            {
                reader.CopyTo(writer);

                return outputPath;
            }
        }
    }
}
