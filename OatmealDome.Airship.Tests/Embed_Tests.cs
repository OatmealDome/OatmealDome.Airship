using System.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;
using OatmealDome.Airship.Bluesky.Embed;
using OatmealDome.Airship.Bluesky.Embed.Image;
using OatmealDome.Airship.Bluesky.Embed.Record;

namespace OatmealDome.Airship.Tests;

public class Embed_Tests
{
    private static readonly ImagesEmbed ImagesDeserializedObject = new ImagesEmbed()
    {
        Images = new List<EmbeddedImage>()
        {
            new EmbeddedImage()
            {
                Image = new ModernBlob()
                {
                    Ref = new Link()
                    {
                        Cid = "dummy-cid"
                    },
                    MimeType = "image/jpeg",
                    Size = 420
                },
                AltText = "alt text"
            }
        }
    };
    
    private const string ImagesPreserializedJson =
        "{\"$type\":\"app.bsky.embed.images\",\"images\":[{\"image\":{\"$type\":\"blob\",\"ref\":{\"$link\":\"dummy-cid\"},\"mimeType\":\"image/jpeg\",\"size\":420},\"alt\":\"alt text\"}]}";

    private static readonly RecordWithMediaEmbed RecordWithMediaDeserializedObject = new RecordWithMediaEmbed()
    {
        Record = new StrongRef()
        {
            Uri = "dummy-uri",
            Cid = "dummy-cid"
        },
        Media = ImagesDeserializedObject
    };

    private const string RecordWithMediaPreserializedJson =
        "{\"$type\":\"app.bsky.embed.recordWithMedia\",\"record\":{\"uri\":\"dummy-uri\",\"cid\":\"dummy-cid\"},\"media\":" +
        ImagesPreserializedJson + "}";
    
    [Fact]
    public void Serialize_AsImagesEmbed_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<ImagesEmbed>(ImagesDeserializedObject);
        
        Assert.Equal(ImagesPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_AsImagesEmbedWithTestData_MatchesExpected()
    {
        ImagesEmbed embed = JsonSerializer.Deserialize<ImagesEmbed>(ImagesPreserializedJson)!;

        Assert.Single(embed.Images);

        ModernBlob referenceBlob = (ModernBlob)ImagesDeserializedObject.Images[0].Image;
        ModernBlob testBlob = (ModernBlob)embed.Images[0].Image;
        
        Assert.Equal(referenceBlob.Ref.Cid, testBlob.Ref.Cid);
        Assert.Equal(referenceBlob.MimeType, testBlob.MimeType);
        Assert.Equal(referenceBlob.Size, testBlob.Size);
    }
    
    [Fact]
    public void Serialize_ImagesEmbedAsGenericEmbed_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<GenericEmbed>(ImagesDeserializedObject);
        
        Assert.Equal(ImagesPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_ImagesEmbedAsGenericEmbedWithTestData_MatchesExpected()
    {
        GenericEmbed embed = JsonSerializer.Deserialize<GenericEmbed>(ImagesPreserializedJson)!;

        ImagesEmbed? imagesEmbed = embed as ImagesEmbed;

        Assert.NotNull(imagesEmbed);
    }
    
    [Fact]
    public void Serialize_RecordWithMediaEmbed_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<RecordWithMediaEmbed>(RecordWithMediaDeserializedObject);
        
        Assert.Equal(RecordWithMediaPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_AsRecordWithMediaEmbedWithTestData_MatchesExpected()
    {
        RecordWithMediaEmbed embed =
            JsonSerializer.Deserialize<RecordWithMediaEmbed>(RecordWithMediaPreserializedJson)!;

        Assert.Equal("dummy-uri", embed.Record.Uri);
        Assert.Equal("dummy-cid", embed.Record.Cid);

        Assert.IsType<ImagesEmbed>(embed.Media);
        
        ImagesEmbed imagesEmbed = (embed.Media as ImagesEmbed)!;

        Assert.Single(imagesEmbed.Images);

        ModernBlob referenceBlob = (ModernBlob)ImagesDeserializedObject.Images[0].Image;
        ModernBlob testBlob = (ModernBlob)imagesEmbed.Images[0].Image;
        
        Assert.Equal(referenceBlob.Ref.Cid, testBlob.Ref.Cid);
        Assert.Equal(referenceBlob.MimeType, testBlob.MimeType);
        Assert.Equal(referenceBlob.Size, testBlob.Size);
    }
    
    [Fact]
    public void Serialize_RecordWithMediaEmbedAsGenericEmbed_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<GenericEmbed>(RecordWithMediaDeserializedObject);
        
        Assert.Equal(RecordWithMediaPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_RecordWithMediaEmbedAsGenericEmbedWithTestData_MatchesExpected()
    {
        GenericEmbed embed = JsonSerializer.Deserialize<GenericEmbed>(RecordWithMediaPreserializedJson)!;

        RecordWithMediaEmbed? recordWithMediaEmbed = embed as RecordWithMediaEmbed;

        Assert.NotNull(recordWithMediaEmbed);
    }
}
