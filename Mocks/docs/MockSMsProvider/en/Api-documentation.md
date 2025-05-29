# Virtual SMS Service API Documentation

This project is an SMS simulator service that provides the capability to send and receive messages.

## Endpoints

### Send SMS

- **Address**: `POST /api/sms`
- **Description**: This endpoint is used to send an SMS from one user to another
- **Request Type**: JSON
- **Input Parameters**:
  ```json
  {
    "sender": "Sender user ID",
    "receiver": "Receiver user ID",
    "message": "Message text"
  }
  ```
- **Successful Response** (code 200):
  ```json
  {
    "success": true,
    "errorMessage": null
  }
  ```
- **Failed Response** (code 400):
  ```json
  {
    "success": false,
    "errorMessage": "User not found. Please enter a valid user ID."
  }
  ```

### View Inbox

- **Address**: `GET /inbox`
- **Description**: This page is used to display the user's received messages
- **Query Parameters**:
  - `userId`: User ID (required)
- **Sample URL**: `/inbox?userId=123`
- **Output**: Displays the list of user's received messages in a web page format

## Important Notes

1. Users must be registered in the system before using the API
2. Each user has a dedicated inbox that is automatically created upon their first request
3. Messages are sent one-way and there is no direct reply capability
4. If an invalid user ID is entered, the system will return an appropriate error

## Data Models

### Message (SMS)

```json
{
  "id": "Unique message ID (GUID)",
  "message": "Message text",
  "senderId": "Sender user ID",
  "inboxId": "Receiver's inbox ID"
}
```

### Inbox

```json
{
  "id": "Unique inbox ID (GUID)",
  "userId": "Owner user ID",
  "messages": "List of received messages"
}
```

## Usage Examples

### Sending an SMS

```bash
curl -X POST https://your-domain.com/api/sms \
  -H "Content-Type: application/json" \
  -d '{
    "sender": "user1",
    "receiver": "user2",
    "message": "Hello! This is a test message."
  }'
```

### Viewing Inbox

Enter the following URL in your browser:

```
https://your-domain.com/inbox?userId=user1
```
