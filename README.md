# 🌍 JadooTravel - Travel Reservation Platform

JadooTravel is a modern ASP.NET Core MVC-based travel reservation management system. It allows you to manage destinations, reservations, and customer reviews using MongoDB database. It also offers AI-powered travel recommendations with OpenAI integration.

## 📋 Table of Contents
- [Features](#-features)
- [Technologies](#-technologies)
- [Architecture](#-architecture)
- [Installation](#-installation)
- [Configuration](#-configuration)
- [Usage](#-usage)
- [Project Structure](#-project-structure)
- [Project Video](#-project-video)
- [License](#-license)

## ✨ Features

### 🎯 Main Features
- **Category Management**: Create, edit, and delete travel categories
- **Destination Management**: Manage travel destinations with visuals
- **Reservation System**: Track customer reservations
- **Feature Management**: Define platform features
- **Customer Reviews**: Testimonial (customer feedback) management
- **Trip Plans**: Create and manage trip plans
- **AI-Powered Recommendations**: City-based travel recommendations with OpenAI integration
- **Dashboard**: Admin panel
- **Multi-Language Support**: i18n infrastructure available

### 🔧 Technical Features
- Repository & Service Pattern architecture
- DTO (Data Transfer Object) usage
- Object mapping with AutoMapper
- Modular view components with ViewComponent structure
- NoSQL database with MongoDB
- Responsive and modern UI

## 🛠 Technologies

### Backend
- **Framework**: ASP.NET Core 9.0 MVC
- **Database**: MongoDB 3.5.0
- **ORM**: MongoDB.Driver
- **Mapping**: AutoMapper 13.0.1
- **AI Integration**: OpenAI-DotNet 8.8.1
- **Language**: C# (.NET 9.0)

### Frontend
- **UI Framework**: Bootstrap (Spike Bootstrap 1.0.0)
- **CSS**: Custom CSS + SCSS
- **JavaScript**: Vanilla JS + i18n.js
- **Icons & Images**: SVG, PNG

### Development Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design 9.0.0

## 🏗 Architecture

The project is developed using layered architecture and Repository/Service pattern:

```
JadooTravel/
├── Controllers/          # Controllers handling HTTP requests
├── Services/            # Business Logic Layer
├── Entities/            # MongoDB entity models
├── Dtos/               # Data Transfer Objects
├── Settings/           # Application settings (Database, etc.)
├── Mapping/            # AutoMapper profiles
├── ViewComponents/     # Reusable view components
├── Views/              # Razor view files
└── wwwroot/            # Static files (CSS, JS, images)
```

### Service Structure
Interface and implementation pair for each entity:
- `ICategoryService` / `CategoryService`
- `IDestinationService` / `DestinationService`
- `IFeatureService` / `FeatureService`
- `IReservationService` / `ReservationService`
- `ITestimonialService` / `TestimonialService`
- `ITripPlanService` / `TripPlanService`

### MongoDB Collections
The application will automatically create the required collections on first run:
- Categories
- Destinations
- Features
- TripPlans
- Reservations
- Testimonials

### Admin Panel
1. **Category Management**: `/Category/CategoryList`
2. **Destination Management**: `/Destination/DestinationList`
3. **Reservation Management**: `/Reservation/ReservationList`
4. **Feature Management**: `/Feature/FeatureList`
5. **Review Management**: `/Testimonial/TestimonialList`
6. **Trip Plans**: `/TripPlan/TripPlanList`

### AI Travel Recommendations
You can get OpenAI-powered travel recommendations by entering a city name from the `/Ai/Index` page.

## 📁 Project Structure

### Controllers
- **DefaultController**: Homepage management
- **DashboardController**: Admin panel
- **CategoryController**: Category CRUD operations
- **DestinationController**: Destination CRUD operations
- **ReservationController**: Reservation CRUD operations
- **FeatureController**: Feature CRUD operations
- **TestimonialController**: Review CRUD operations
- **TripPlanController**: Trip plan CRUD operations
- **AIController**: OpenAI integration

### Entity Models

#### Category
```csharp
- CategoryId: string (ObjectId)
- CategoryName: string
- Description: string
- IconUrl: string
- Status: bool
```

#### Destination
```csharp
- DestinationId: string (ObjectId)
- CityCountry: string
- ImageUrl: string
- Price: decimal
- DayNight: string
- Capacity: int
- Description: string
```

#### Reservation
```csharp
- ReservationId: string (ObjectId)
- FullName: string
- Telephone: string
- Email: string
- Notes: string
- ReservationDate: DateTime
```

### ViewComponents
- `_DefaultBookingStepsComponentPartial`: Reservation steps
- `_DefaultCategoryComponentPartial`: Category list
- `_DefaultDestinationComponentPartial`: Destination cards
- `_DefaultFeatureComponentPartial`: Features section
- `_DefaultHeadComponentPartial`: Page header
- `_DefaultNavbarComponentPartial`: Navigation menu
- `_DefaultTestimonialComponentPartial`: Customer reviews

## 🖼 Project Video

The project has a modern and responsive user interface. The Spike Bootstrap theme is used.




https://github.com/user-attachments/assets/df8a92dd-eed4-480c-9567-0fe09cd85705







