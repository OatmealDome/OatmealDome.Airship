using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.Tests;

public class ATQueryRequest_Tests
{
    private class TestRequest : ATQueryRequest
    {
        public override string NamespacedId => "com.example.test";

        [ATQueryRequestParameterName("one")]
        public string One
        {
            get;
            set;
        }

        [ATQueryRequestParameterName("two")]
        public int Two
        {
            get;
            set;
        }

        [ATQueryRequestParameterName("three")]
        public bool? Three
        {
            get;
            set;
        }

        public string Four
        {
            get;
            set;
        }

        [ATQueryRequestParameterName("five")]
        public Optional<string> Five
        {
            get;
            set;
        }
        
        [ATQueryRequestParameterName("six")]
        public Optional<string> Six
        {
            get;
            set;
        }
        
        [ATQueryRequestParameterName("seven")]
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
        Four = "shouldn't be serialized",
        Five = Optional<string>.None,
        Six = Optional.Null<string>(),
        Seven = "defined"
    };

    private const string PreserializedJson = "one=dummy&two=1337&three=null&six=null&seven=defined";

    [Fact]
    public async Task CreateFormUrlEncodedContent_WithTestRequest_MatchesExpected()
    {
        FormUrlEncodedContent content = _deserializedObject.CreateFormUrlEncodedContent()!;

        Assert.Equal(PreserializedJson, await content.ReadAsStringAsync());
    }
}
