# OatmealDome.Airship

Sail the Bluesky with an Airship.

This is a .NET 6 library intended for bots that interact with Bluesky or other AT Protocol compatible servers.

## Usage

It is recommended that you familiarize yourself with the AT Protocol and other Bluesky-specific concepts before using this library. Refer to the [Bluesky documentation](https://docs.bsky.app/docs/category/advanced-guides) for more detailed information.

At this time, it is only possible to log in and create posts.

First, make a `BlueskyClient` instance:

```csharp
BlueskyClient client = new BlueskyClient();

// alternatively, to connect to a different PDS
BlueskyClient client = new BlueskyClient("https://pds.example.com");
```

### Session Management

To interact with most APIs, you need to first create a session.

#### Creating a Session

You can log in by passing your handle and password to `BlueskyClient.Server_CreateSession()`.

**NOTE**: For security reasons, you should create a dedicated [app password](https://github.com/bluesky-social/atproto-ecosystem/blob/main/app-passwords.md) in Settings -> Advanced -> App Passwords instead of using your account's actual password.

```csharp
await client.Server_CreateSession("oatmealdome.example.com", "aaaa-bbbb-cccc-dddd");
```

After you have been authenticated, you can access the `Credentials` property and save it elsewhere if needed.

#### Refreshing a Session

Session tokens are only valid for a couple of hours. You can use the refresh token to get a new session token.

```csharp
await client.Server_RefreshSession();
```

#### Deleting a Session

Once you're done with a session, you should delete it.

```csharp
await client.Server_DeleteSession();
```

### Blobs

Media files must be uploaded to the server before they can be used. At the time of writing, the primary Bluesky instance only accepts MIME types that start with `image/`.

```csharp
GenericBlob blob = await client.Repo_CreateBlob(File.ReadAllBytes("image.jpg"), "image/jpeg");
```

### Posting

To create a post, use `BlueskyClient.Post_Create()`:

```csharp
await client.Post_Create(new Post()
{
    Text = "Hello, world!",
    CreatedAt = DateTime.UtcNow
});
```

#### Embeds

You can embed things like images into your posts.

```csharp
await client.Post_Create(new Post()
{
    Text = "Hello, world! Here are some images.",
    CreatedAt = DateTime.UtcNow,

    // Optional. Only specify if you want to embed an image.
    Embed = new ImagesEmbed()
    {
        Images = new List<EmbeddedImage>()
        {
            new EmbeddedImage()
            {
                Image = blob, // see "Blobs" section above
                AltText = "Image description for accessibility"
            }
        }
    }
});
```

Other possible embeds include `RecordEmbed` and `RecordWithMediaEmbed`:

```csharp
// Use when you want to quote a post.
RecordEmbed embedOne = new RecordEmbed()
{
    Record = ref // StrongRef
};

// Use when you want to quote a post, but you also want to attach media to it.
RecordWithMediaEmbed embedTwo = new RecordWithMediaEmbed()
{
    Record = ref,
    Media = otherEmbed // ImagesEmbed, for example
};
```

#### Replies

You can create a post that is a reply to another post. Replies can be chained together to make a thread of posts.

```csharp
StrongRef root = await client.Post_Create(new Post()
{
    Text = "This is the first post in the thread!",
    CreatedAt = DateTime.UtcNow
});

StrongRef childOne = await client.Post_Create(new Post()
{
    Text = "This is the second post in the thread!",
    CreatedAt = DateTime.UtcNow,

    Reply = new PostReply()
    {
        Root = root,
        Parent = root
    }
});

StrongRef childTwo = await client.Post_Create(new Post()
{
    Text = "This is the third post in the thread!",
    CreatedAt = DateTime.UtcNow,

    Reply = new PostReply()
    {
        Root = root,
        Parent = childOne
    }
});
```

#### Rich Text

You can also use rich text. Please refer to the [Bluesky documentation](https://docs.bsky.app/docs/advanced-guides/post-richtext) for more information.

```csharp
await client.Post_Create(new Post()
{
    Text = "Hello, world! Here's a #Hashtag and an example URL: https://example.com",
    CreatedAt = DateTime.UtcNow,

    Facets = new List<PostFacet>()
    {
        new PostFacet()
        {
            Index = new FacetRange()
            {
                ByteStart = 23,
                ByteEnd = 31
            },
            Features = new List<GenericFeature>()
            {
                new TagFeature()
                {
                    Tag = "Hashtag"
                }
            }
        },
        new PostFacet()
        {
            Index = new FacetRange()
            {
                ByteStart = 52,
                ByteEnd = 71
            },
            Features = new List<GenericFeature>()
            {
                new LinkFeature()
                {
                    Tag = "https://example.com"
                }
            }
        },
    }
});
```
