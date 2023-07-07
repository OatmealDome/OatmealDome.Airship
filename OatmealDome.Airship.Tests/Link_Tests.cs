using System.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;

namespace OatmealDome.Airship.Tests;

public class Link_Tests
{
    private const string TestCid = "dummy";
    
    private const string PreserializedJson = "{\"$link\":\"dummy\"}";
    
    [Fact]
    public void Serialize_WithTestData_MatchesExpected()
    {
        Link link = new Link(TestCid);

        Assert.Equal(PreserializedJson, JsonSerializer.Serialize(link));
    }
    
    [Fact]
    public void Deserialize_WithTestData_MatchesExpected()
    {
        Link link = JsonSerializer.Deserialize<Link>(PreserializedJson)!;

        Assert.Equal(TestCid, link.Cid);
    }
}
