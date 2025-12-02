# Events API

## תיאור הפרויקט
Web API לניהול אירועים, חדרים וקוחות. הפרויקט מאפשר ליצור, לקרוא, לעדכן ולמחוק רשומות במסד הנתונים (בזיכרון).

## ישויות

### Event (אירוע)
| שדה | סוג | תיאור |
|-----|-----|--------|
| Id | int | מזהה ייחודי של האירוע |
| Title | string | שם האירוע |
| CustomerId | int | מזהה הקוח המארגן |
| RoomId | int | מזהה החדר שבו יתקיים האירוע |
| Status | EventStatus | סטטוס האירוע (Planned, Ongoing, Completed, Cancelled) |

### Customer (קוח)
| שדה | סוג | תיאור |
|-----|-----|--------|
| Id | int | מזהה ייחודי של הקוח |
| Name | string | שם הקוח |
| Email | string | כתובת דוא"ל |
| Phone | string | מספר טלפון |
| IsActive | bool | האם הקוח פעיל |

### Room (חדר)
| שדה | סוג | תיאור |
|-----|-----|--------|
| Id | int | מזהה ייחודי של החדר |
| Name | string | שם החדר |
| Capacity | int | קיבולת החדר |
| Location | string | מיקום החדר |

## API Endpoints

### Events
#### קבלת כל האירועים
```
GET /api/events?status=Planned
```
**Query Parameters:**
- `status` (optional): סינון לפי סטטוס של האירוע (Planned, Ongoing, Completed, Cancelled)

**Response Example:**
```json
[
  {
    "id": 1,
    "title": "Company Meeting",
    "customerId": 1,
    "roomId": 1,
    "status": "Planned"
  }
]
```

#### קבלת אירוע לפי ID
```
GET /api/events/{id}
```
**Route Parameters:**
- `id` (required): מזהה האירוע

**Response Example:**
```json
{
  "id": 1,
  "title": "Company Meeting",
  "customerId": 1,
  "roomId": 1,
  "status": "Planned"
}
```

#### יצירת אירוע חדש
```
POST /api/events
Content-Type: application/json

{
  "title": "New Event",
  "customerId": 1,
  "roomId": 2,
  "status": "Planned"
}
```

#### עדכון אירוע
```
PUT /api/events/{id}
Content-Type: application/json

{
  "title": "Updated Event",
  "customerId": 1,
  "roomId": 3,
  "status": "Ongoing"
}
```

#### מחיקת אירוע
```
DELETE /api/events/{id}
```

### Customers
#### קבלת כל הקוחות
```
GET /api/customers?isActive=true
```
**Query Parameters:**
- `isActive` (optional): סינון לפי סטטוס פעילות (true/false)

#### קבלת קוח לפי ID
```
GET /api/customers/{id}
```

#### יצירת קוח חדש
```
POST /api/customers
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john@example.com",
  "phone": "0501234567",
  "isActive": true
}
```

#### עדכון קוח
```
PUT /api/customers/{id}
Content-Type: application/json

{
  "name": "Jane Doe",
  "email": "jane@example.com",
  "phone": "0507654321",
  "isActive": true
}
```

#### מחיקת קוח
```
DELETE /api/customers/{id}
```

### Rooms
#### קבלת כל החדרים
```
GET /api/rooms
```

#### קבלת חדר לפי ID
```
GET /api/rooms/{id}
```

#### יצירת חדר חדש
```
POST /api/rooms
Content-Type: application/json

{
  "name": "Conference Room A",
  "capacity": 50,
  "location": "Floor 1"
}
```

#### עדכון חדר
```
PUT /api/rooms/{id}
Content-Type: application/json

{
  "name": "Meeting Room B",
  "capacity": 30,
  "location": "Floor 2"
}
```

#### מחיקת חדר
```
DELETE /api/rooms/{id}
```

## Response Status Codes
- `200 OK`: בקשה הצליחה וחזרה נתונים
- `201 Created`: הקובץ נוצר בהצלחה
- `204 No Content`: בקשה הצליחה אך אין תוכן להחזיר (מחיקה)
- `400 Bad Request`: בקשה שגויה
- `404 Not Found`: המשאב לא קיים
- `500 Internal Server Error`: שגיאת שרת

## הערות למפתחים

### Route Params
Route Params הם חלק מה-URL והם מגדירים את המשאב הספציפי.
```
GET /api/events/5  <- 5 הוא Route Param
```

### Query String
Query String משמש לסינון ומיון והוא אופציונלי.
```
GET /api/events?status=Planned  <- status הוא Query String Parameter
```

### Request Body
Body משמש בבקשות POST ו-PUT לשליחת נתונים שלמים.
כל בקשה שמעבירה נתונים ב-Body חייבת לכלול את ה-Header:
```
Content-Type: application/json
```

## הרצת הפרויקט
```bash
dotnet run
```

API יהיה זמין ב-`https://localhost:7083`

Swagger UI זמין ב-`https://localhost:7083/swagger`
