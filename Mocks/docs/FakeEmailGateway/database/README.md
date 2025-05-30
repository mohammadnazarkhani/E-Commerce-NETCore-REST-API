# Database Documentation

## Overview

The FakeEmailGateway uses a relational database to store user information, email inboxes and outboxes, and email messages themselves. This document describes the database structure and relationships between entities.

## Entity Relationship Diagram

![Entity Relationship Diagram](erd.drawio.svg)

## Entities

### User

- **Id** (Guid, PK): Unique identifier for user
- **First Name** (string): User's First name
- **Last Name** (string): User's Last name
- **Phone Number** (string): User's Phone number
- **Email Address** (string): Unique Email address for user
- **Password** (string): Password of email account
- **Date of Birth** (Date Time): User's date of birth
- **Relationships**:
  - Has one Inbox (1:1)
  - Has one Outbox (1:1)

### Inbox

- **Id** (Guid, PK): Unique identifier for the inbox
- **Relationships**:
  - Belongs to one User (1:1)
  - Receives many emails (1:N with Email)

### Outbox

- **Id** (Guid, PK): Unique identifier for the outbox
- **Relationships**:
  - Belongs to one User (1:1)
  - Sends many emails (1:N with Email)

### Email

- **Id** (Guid, PK): Unique identifier for the email
- **Subject** (string): Subject of the email
- **Body** (string): Body section of the email
- **Creating Date** (string): Date of when the email has been sent
- **Relationships**:
  - Belongs to one receiver Inbox (N:1)
  - Belongs to one sender Outbox (N:1)

## Important Notes

1. Each user automatically gets an inbox and an outbox created when they first register
2. Messages are stored in the receiver's inbox
3. Messages which sent are stored in sender's outbox
