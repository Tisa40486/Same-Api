# Social Network - Logical Data Model

```mermaid
erDiagram
    User {
        int id PK
        string username
        string email
        string passwordHash
        string firstName
        string lastName
        string bio
        date birthDate
        string profilePictureUrl
        string coverPictureUrl
        string phoneNumber
        string website
        boolean isAdmin
        boolean isVerified
        boolean isPrivate
        string status
        int followersCount
        int followingCount
        int postsCount
        datetime createdAt
        datetime updatedAt
        datetime lastLoginAt
        int genderId FK
        int schoolId FK
    }

    Gender {
        int id PK
        string name
    }

    School {
        int id PK
        string name
        string city
        string country
        int professionId FK
    }

    Profession {
        int id PK
        string name
        string description
    }

    Post {
        int id PK
        int userId FK
        string content
        string visibility
        string location
        int likeCount
        int commentCount
        int shareCount
        boolean isEdited
        string status
        datetime createdAt
        datetime updatedAt
    }

    Media {
        int id PK
        int postId FK
        string mediaType
        string url
        string altText
        int sortOrder
        datetime createdAt
    }

    Comment {
        int id PK
        int postId FK
        int userId FK
        int parentCommentId FK
        string content
        int likeCount
        boolean isEdited
        datetime createdAt
        datetime updatedAt
    }

    Reaction {
        int id PK
        int userId FK
        int postId FK
        int commentId FK
        string type
        datetime createdAt
    }

    Follow {
        int id PK
        int followerId FK
        int followingId FK
        string status
        datetime createdAt
    }

    Hashtag {
        int id PK
        string name
        datetime createdAt
    }

    PostHashtag {
        int id PK
        int postId FK
        int hashtagId FK
    }

    SavedPost {
        int id PK
        int userId FK
        int postId FK
        datetime createdAt
    }

    Conversation {
        int id PK
        boolean isGroup
        string name
        datetime createdAt
        datetime updatedAt
    }

    ConversationParticipant {
        int id PK
        int conversationId FK
        int userId FK
        string role
        datetime joinedAt
        datetime lastReadAt
    }

    Message {
        int id PK
        int conversationId FK
        int senderId FK
        string content
        string messageType
        string mediaUrl
        boolean isRead
        datetime createdAt
        datetime readAt
    }

    Notification {
        int id PK
        int userId FK
        int actorId FK
        string type
        string content
        string targetType
        int targetId
        boolean isRead
        datetime createdAt
    }

    Block {
        int id PK
        int blockerId FK
        int blockedId FK
        datetime createdAt
    }

    Gender ||--o{ User : "assigned to"
    School ||--o{ User : "attended by"
    Profession ||--o{ School : "related to"

    User ||--o{ Post : "creates"
    Post ||--o{ Media : "contains"

    User ||--o{ Comment : "writes"
    Post ||--o{ Comment : "receives"
    Comment ||--o{ Comment : "replies to"

    User ||--o{ Reaction : "reacts"
    Post ||--o{ Reaction : "receives"
    Comment ||--o{ Reaction : "receives"

    User ||--o{ Follow : "follows"
    User ||--o{ Follow : "is followed"

    Post ||--o{ PostHashtag : "has"
    Hashtag ||--o{ PostHashtag : "used in"

    User ||--o{ SavedPost : "saves"
    Post ||--o{ SavedPost : "is saved"

    Conversation ||--o{ ConversationParticipant : "has"
    User ||--o{ ConversationParticipant : "participates in"

    Conversation ||--o{ Message : "contains"
    User ||--o{ Message : "sends"

    User ||--o{ Notification : "receives"
    User ||--o{ Notification : "triggers"

    User ||--o{ Block : "blocks"
    User ||--o{ Block : "is blocked by"