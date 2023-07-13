# OatmealDome.Airship

Sail the Bluesky with an Airship.

This is a .NET 6 library intended for bots that interact with Bluesky or other AT Protocol compatible servers.

## Usage

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

```
await client.Server_CreateSession("oatmealdome.example.com", "aaaa-bbbb-cccc-dddd");
```

After you have been authenticated, you can access the `Credentials` property and save it elsewhere if needed.

#### Refreshing a Session

Session tokens are only valid for a couple of hours. You can use the refresh token to get a new session token.

```
await client.Server_RefreshSession();
```

#### Deleting a Session

Once you're done with a session, you should delete it.

```
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
