# Changelog

## 0.1.3 — 2026-06-01

### Bug Fixes
- **`SmsResource.CancelScheduledAsync()`** — fixed endpoint from `POST sms/cancel-scheduled` to `DELETE sms/{id}` (was completely broken)
- **`ContactsResource.CreateListAsync()`** — now correctly returns `Task<Guid>` (the new list ID) instead of trying to deserialize a `ContactList` object
- **`ContactsResource.CreateAsync()`** — `CreateContactRequest` no longer exposes the unsupported `Emails` property; API only accepts `PhoneNumbers`
- **`ContactsResource.CreateAsync()`** — return type changed from `Task<int>` to `Task` (API returns `201 Created`, not a count)

### New Features
- **`SendSmsRequest.Fallback`** — new optional `bool?` property to control sender ID fallback behaviour
- **`SmsResource.ListAsync()`** — added `status`, `phone`, `from` and `to` optional filter parameters

### Breaking Changes
- `ContactsResource.CreateAsync()` return type: `Task<int>` → `Task`
- `ContactsResource.CreateListAsync()` return type: `Task<ContactList>` → `Task<Guid>`
- `CreateContactRequest.Emails` property removed

---

## 0.1.2

- Initial release.
