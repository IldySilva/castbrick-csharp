# castbrick-csharp

Official .NET SDK for the CastBrick API. Published as `CastBrick.SDK` on NuGet. Targets `net8.0` and `netstandard2.0`.

## Commands

```bash
dotnet build CastBrick.SDK/CastBrick.SDK.csproj -c Release
dotnet pack  CastBrick.SDK/CastBrick.SDK.csproj -c Release
dotnet test
```

## Version

Current: `0.1.3` — bump `<Version>` in `CastBrick.SDK/CastBrick.SDK.csproj`.

## Source files

```
CastBrick.SDK/
├── CastBrickClient.cs         # Main client (Sms, Contacts, Broadcasts)
├── CastBrickHttpClient.cs     # Internal HTTP wrapper
├── CastBrickOptions.cs        # ApiKey + BaseUrl
├── CastBrickApiException.cs   # Exception type
├── Models/
│   ├── PagedResult.cs
│   ├── Sms/                   # SendSmsRequest, SendSmsResponse, SmsMessage
│   ├── Contacts/              # Contact, ContactList, CreateContactRequest
│   └── Broadcasts/            # Broadcast, CreateBroadcastRequest, UpdateBroadcastRequest
└── Resources/
    ├── SmsResource.cs
    ├── ContactsResource.cs
    └── BroadcastsResource.cs
```

## Correct API facts

- `Sms.CancelScheduledAsync(Guid messageId)` → `DELETE sms/{id}` (was POST sms/cancel-scheduled)
- `Contacts.CreateListAsync(name)` → returns `Task<Guid>` (ID only, not ContactList)
- `Contacts.CreateAsync(request)` → `Task` (no return value); `CreateContactRequest` only has `PhoneNumbers`
- `Sms.ListAsync(status, phone, from, to, ...)` — filter params supported
- `SendSmsRequest.Fallback` → `bool?` property

## Publishing

Tag `v0.1.x` triggers GitHub Actions → publishes to NuGet via trusted publishing (OIDC, no API key secret).
NuGet trusted publisher must be configured on nuget.org for repo `IldySilva/castbrick-csharp`.
