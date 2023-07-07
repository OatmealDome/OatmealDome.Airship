using System.Text;
using System.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;

namespace OatmealDome.Airship.Tests;

public class Bytes_Tests
{
    private const string TestData = "The quick brown fox jumped over the lazy dog.";

    private const string PreserializedJson =
        "{\"$bytes\":\"VGhlIHF1aWNrIGJyb3duIGZveCBqdW1wZWQgb3ZlciB0aGUgbGF6eSBkb2cu\"}";
    
    [Fact]
    public void Serialize_WithTestData_MatchesExpected()
    {
        Bytes bytes = new Bytes(Encoding.UTF8.GetBytes(TestData));

        Assert.Equal(PreserializedJson, JsonSerializer.Serialize(bytes));
    }
    
    [Fact]
    public void Deserialize_WithTestData_MatchesExpected()
    {
        Bytes bytes = JsonSerializer.Deserialize<Bytes>(PreserializedJson)!;

        Assert.Equal(TestData, Encoding.UTF8.GetString(bytes.Data));
    }
}
