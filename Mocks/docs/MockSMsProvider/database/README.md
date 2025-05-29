# Database Documentation

## Overview

The MockSmsProvider uses a relational database to store user information, inboxes, and SMS messages. This document describes the database structure and relationships between entities.

## Entity Relationship Diagram

![Entity Relationship Diagram](erd.drawio.svg)

## Entities

### User

- **Id** (string, PK): Phone number or company name that identifies the user
- **Relationships**:
  - Has one Inbox (1:1)
  - Has many sent messages (1:N with Sms)

### Inbox

- **Id** (GUID, PK): Unique identifier for the inbox
- **UserId** (string, FK): Reference to the owner user
- **Relationships**:
  - Belongs to one User (1:1)
  - Contains many messages (1:N with Sms)

### Sms

- **Id** (GUID, PK): Unique identifier for the message
- **Message** (string): The content of the SMS
- **SenderId** (string, FK): Reference to the user who sent the message
- **InboxId** (GUID, FK): Reference to the receiving inbox
- **Relationships**:
  - Belongs to one sender User (N:1)
  - Belongs to one receiver Inbox (N:1)

## Important Notes

1. Users are identified by their phone number or company name (stored in the Id field)
2. Each user automatically gets an inbox created when they first receive a message
3. Messages are stored in the receiver's inbox and linked to the sender
4. The database supports one-way messaging (no direct replies in the data model)

## Sample Queries

### Get User's Inbox Messages

```sql
SELECT s.*
FROM Sms s
JOIN Inbox i ON s.InboxId = i.Id
WHERE i.UserId = @userId
ORDER BY s.Id DESC;
```

### Get User's Sent Messages

```sql
SELECT s.*
FROM Sms s
WHERE s.SenderId = @userId
ORDER BY s.Id DESC;
```
