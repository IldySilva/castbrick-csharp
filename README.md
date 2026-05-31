# CastBrick.SDK

Official .NET SDK for the [CastBrick](https://castbrick.com) API — send SMS, manage contacts and run broadcasts from any .NET or .NET Standard project.

## Installation

```bash
dotnet add package CastBrick.SDK
```

## Quick start

```csharp
using CastBrick.SDK;
using CastBrick.SDK.Models.Sms;

var cb = new CastBrickClient(new CastBrickOptions { ApiKey = "your_api_key_here" });

// Send an SMS
var result = await cb.Sms.SendAsync(new SendSmsRequest
{
    Recipients = ["+244923000000"],
    Content = "Hello from CastBrick!"
});
```

## SMS

```csharp
// Send
await cb.Sms.SendAsync(new SendSmsRequest
{
    Recipients = ["+244923000000", "+244912000000"],
    Content = "Your OTP is 1234",
    SenderId = "MyApp",                         // optional — approved Sender ID
    ScheduledAt = DateTime.UtcNow.AddHours(1),  // optional — schedule for later
    Fallback = true,                            // optional — fall back to CastBrick sender
});

// List (with optional filters)
var page = await cb.Sms.ListAsync(
    page: 1,
    pageSize: 20,
    status: "delivered",            // pending | sent | delivered | failed | scheduled
    phone: "+244923000000",
    from: new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    to: new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc)
);
Console.WriteLine($"{page.TotalCount} messages");

// Cancel a scheduled SMS
await cb.Sms.CancelScheduledAsync(messageId);
```

## Contacts

```csharp
// List (with optional search)
var page = await cb.Contacts.ListAsync(search: "john");

// Get
var contact = await cb.Contacts.GetAsync(id);

// Create — comma or newline-separated phone numbers
await cb.Contacts.CreateAsync(new CreateContactRequest
{
    PhoneNumbers = "+244923000000,+244912000000"
});

// Delete
await cb.Contacts.DeleteAsync(id);
```

### Contact lists

```csharp
// List all
var lists = await cb.Contacts.ListListsAsync();

// Create — returns the new list ID (Guid)
var listId = await cb.Contacts.CreateListAsync("VIP Customers");

// Add / remove a contact
await cb.Contacts.AddToListAsync(listId, contact.Id);
await cb.Contacts.RemoveFromListAsync(listId, contact.Id);
```

## Broadcasts

```csharp
// Create
var id = await cb.Broadcasts.CreateAsync(new CreateBroadcastRequest
{
    Name = "Black Friday",
    Message = "50% off everything today!",
    ContactListId = listId,  // optional
    SenderId = "MyApp",      // optional
});

// Send immediately
await cb.Broadcasts.SendAsync(id);

// Update (supports scheduling)
await cb.Broadcasts.UpdateAsync(id, new UpdateBroadcastRequest
{
    Name = "Black Friday",
    Message = "50% off everything today!",
    ScheduleAt = new DateTime(2026, 11, 28, 9, 0, 0, DateTimeKind.Utc),
});

// Other operations
await cb.Broadcasts.CancelAsync(id);
var newId = await cb.Broadcasts.DuplicateAsync(id);
await cb.Broadcasts.DeleteAsync(id);

// List / get
var page = await cb.Broadcasts.ListAsync();
var broadcast = await cb.Broadcasts.GetAsync(id);
```

## Error handling

All API errors throw a `CastBrickApiException`:

```csharp
try
{
    await cb.Sms.SendAsync(...);
}
catch (CastBrickApiException ex)
{
    Console.WriteLine($"{ex.StatusCode}: {ex.ResponseBody}");
    // 401 → invalid or revoked API key
    // 402 → insufficient credits
    // 422 → validation error
}
```

## ASP.NET Core / IHttpClientFactory

```csharp
// Program.cs
builder.Services.AddHttpClient<CastBrickClient>();
builder.Services.AddSingleton(new CastBrickOptions { ApiKey = "your_api_key_here" });

// Inject CastBrickClient directly into your services
```

## License

MIT
