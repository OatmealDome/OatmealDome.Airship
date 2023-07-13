using System.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;
using OatmealDome.Airship.Bluesky.Embed;
using OatmealDome.Airship.Bluesky.Embed.Image;

namespace OatmealDome.Airship.Tests;

public class Embed_Tests
{
    private readonly ImagesEmbed _imagesDeserializedObject = new ImagesEmbed()
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
    
    [Fact]
    public void Serialize_AsImagesEmbed_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<ImagesEmbed>(_imagesDeserializedObject);
        
        Assert.Equal(ImagesPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_AsImagesEmbedWithTestData_MatchesExpected()
    {
        ImagesEmbed embed = JsonSerializer.Deserialize<ImagesEmbed>(ImagesPreserializedJson)!;

        Assert.Single(embed.Images);

        ModernBlob referenceBlob = (ModernBlob)_imagesDeserializedObject.Images[0].Image;
        ModernBlob testBlob = (ModernBlob)embed.Images[0].Image;
        
        Assert.Equal(referenceBlob.Ref.Cid, testBlob.Ref.Cid);
        Assert.Equal(referenceBlob.MimeType, testBlob.MimeType);
        Assert.Equal(referenceBlob.Size, testBlob.Size);
    }
    
    [Fact]
    public void Serialize_ImagesEmbedAsGenericEmbed_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<GenericEmbed>(_imagesDeserializedObject);
        
        Assert.Equal(ImagesPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_ImagesEmbedAsGenericEmbedWithTestData_MatchesExpected()
    {
        GenericEmbed embed = JsonSerializer.Deserialize<GenericEmbed>(ImagesPreserializedJson)!;

        ImagesEmbed? imagesEmbed = embed as ImagesEmbed;

        Assert.NotNull(imagesEmbed);
    }
}
