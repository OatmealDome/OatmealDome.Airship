using System.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

namespace OatmealDome.Airship.Tests;

public class Blob_Tests
{
    // Example data from https://github.com/bluesky-social/atproto/issues/763#issuecomment-1498745785
    
    private readonly ModernBlob _modernDeserializedObject = new ModernBlob()
    {
        Ref = new Link()
        {
            Cid = "bafkreihcrabxisugjyiw6zclsdrrwihllaexxahrdxt5gtmyzpwzb5gpoi"
        },
        MimeType = "image/jpeg",
        Size = 34923
    };

    private const string ModernPreserializedJson =
        "{\"$type\":\"blob\",\"ref\":{\"$link\":\"bafkreihcrabxisugjyiw6zclsdrrwihllaexxahrdxt5gtmyzpwzb5gpoi\"},\"mimeType\":\"image/jpeg\",\"size\":34923}";
    
    [Fact]
    public void Serialize_AsModernBlob_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<ModernBlob>(_modernDeserializedObject);
        
        Assert.Equal(ModernPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_AsModernBlobWithTestData_MatchesExpected()
    {
        ModernBlob blob = JsonSerializer.Deserialize<ModernBlob>(ModernPreserializedJson)!;
        
        Assert.Equal(_modernDeserializedObject.Ref.Cid, blob.Ref.Cid);
        Assert.Equal(_modernDeserializedObject.MimeType, blob.MimeType);
        Assert.Equal(_modernDeserializedObject.Size, blob.Size);
    }
    
    [Fact]
    public void Serialize_AsGenericBlob_MatchesExpected()
    {
        string json = JsonSerializer.Serialize<GenericBlob>(_modernDeserializedObject);
        
        Assert.Equal(ModernPreserializedJson, json);
    }
    
    [Fact]
    public void Deserialize_AsGenericBlobWithTestData_MatchesExpected()
    {
        GenericBlob blob = JsonSerializer.Deserialize<GenericBlob>(ModernPreserializedJson)!;

        ModernBlob? modernBlob = blob as ModernBlob;
        
        Assert.NotNull(modernBlob);
        Assert.Equal(_modernDeserializedObject.Ref.Cid, modernBlob!.Ref.Cid);
        Assert.Equal(_modernDeserializedObject.MimeType, modernBlob.MimeType);
        Assert.Equal(_modernDeserializedObject.Size, modernBlob.Size);
    }
}
