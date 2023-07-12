using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

namespace OatmealDome.Airship.Tests;

public class ATJsonProcedureRequest_Tests
{
    private class TestRequest : ATJsonProcedureRequest
    {
        [JsonIgnore]
        public override string NamespacedId => "com.example.test";

        [JsonPropertyName("one")]
        public string One
        {
            get;
            set;
        }

        [JsonPropertyName("two")]
        public int Two
        {
            get;
            set;
        }

        [JsonPropertyName("three")]
        public bool? Three
        {
            get;
            set;
        }
        

        [JsonPropertyName("four")]
        public GenericBlob Four
        {
            get;
            set;
        }

        [JsonIgnore]
        public string Five
        {
            get;
            set;
        }

        [JsonPropertyName("six")]
        [JsonConverter(typeof(OptionalConverterFactory))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Optional<string> Six
        {
            get;
            set;
        }
        
        [JsonPropertyName("seven")]
        [JsonConverter(typeof(OptionalConverterFactory))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Optional<string> Seven
        {
            get;
            set;
        }
    }

    private readonly TestRequest _deserializedObject = new TestRequest()
    {
        One = "dummy",
        Two = 1337,
        Three = null,
        Four = new ModernBlob()
        {
            Ref = new Link()
            {
                Cid = "dummy-cid"
            },
            MimeType = "image/jpeg",
            Size = 420
        },
        Five = "shouldn't be serialized",
        Six = Optional<string>.None,
        Seven = Optional.Null<string>()
    };

    private const string PreserializedJson = "{\"one\":\"dummy\",\"two\":1337,\"three\":null,\"four\":{\"$type\":\"blob\",\"ref\":{\"$link\":\"dummy-cid\"},\"mimeType\":\"image/jpeg\",\"size\":420},\"seven\":null}";

    [Fact]
    public async Task CreateHttpRequestMessage_WithTestRequest_MatchesExpected()
    {
        Assert.Equal(PreserializedJson, await _deserializedObject.CreateHttpContent()!.ReadAsStringAsync());
    }
}
