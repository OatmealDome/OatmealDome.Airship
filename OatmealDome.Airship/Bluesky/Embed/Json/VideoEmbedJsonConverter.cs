using System.Text.Json;
using System.Text.Json.Serialization;
using DotNext;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;
using OatmealDome.Airship.Bluesky.Embed.Image;
using OatmealDome.Airship.Bluesky.Embed.Video;

namespace OatmealDome.Airship.Bluesky.Embed.Json;

public class VideoEmbedJsonConverter : JsonConverter<VideoEmbed>
{
    public override VideoEmbed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        List<VideoCaptionFile>? captionFiles = null;

        if (document.RootElement.TryGetProperty("captions", out JsonElement captionsElement))
        {
            captionFiles = new List<VideoCaptionFile>();
            
            for (int i = 0; i < captionsElement.GetArrayLength(); i++)
            {
                captionFiles.Add(captionsElement[i].Deserialize<VideoCaptionFile>(options)!);
            }
        }

        string? altText = null;

        if (document.RootElement.TryGetProperty("alt", out JsonElement altElement))
        {
            altText = altElement.GetString();
        }

        MediaAspectRatio? aspectRatio = null;

        if (document.RootElement.TryGetProperty("aspectRatio", out JsonElement aspectRatioElement))
        {
            aspectRatio = aspectRatioElement.Deserialize<MediaAspectRatio>();
        }

        return new VideoEmbed()
        {
            Video = document.RootElement.GetProperty("video").Deserialize<GenericBlob>()!,
            CaptionFiles = captionFiles ?? Optional<List<VideoCaptionFile>>.None,
            AltText = altText ?? Optional<string>.None,
            AspectRatio = aspectRatio ?? Optional.None<MediaAspectRatio>()
        };
    }

    public override void Write(Utf8JsonWriter writer, VideoEmbed value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("app.bsky.embed.video");
        
        writer.WritePropertyName("video");
        JsonSerializer.Serialize(writer, value.Video, options);

        if (value.CaptionFiles.HasValue)
        {
            writer.WritePropertyName("captions");
            writer.WriteStartArray();
        
            foreach (VideoCaptionFile captionFile in value.CaptionFiles.Value)
            {
                JsonSerializer.Serialize(writer, captionFile, options);
            }
        
            writer.WriteEndArray();
        }

        if (value.AltText.HasValue)
        {
            writer.WritePropertyName("alt");
            writer.WriteStringValue(value.AltText.Value);
        }

        if (value.AspectRatio.HasValue)
        {
            writer.WritePropertyName("aspectRatio");
            JsonSerializer.Serialize(writer, value.AspectRatio.Value, options);
        }
        
        writer.WriteEndObject();
    }
}
