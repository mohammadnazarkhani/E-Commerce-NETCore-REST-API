# Database Documentation

This directory contains the database design and documentation for the E-Commerce REST API project.

## Overview

The database is designed to support a full-featured e-commerce platform with the following core functionalities:

- Product management
- User management and authentication
- Shopping cart functionality
- Order processing
- Payment handling

## Entity Relationship Diagram

The database schema is visualized in the following files:

- `erd.drawio` - Source file created with Draw.io
- `erd.drawio.svg` - SVG export of the ERD for easy viewing

## Core Entities

### Users

- Stores customer and administrator information
- Manages authentication and authorization data
- Tracks user profiles and preferences

### Products

- Contains product catalog information
- Manages product categories and tags
- Tracks inventory and pricing

### Orders

- Stores order information and status
- Manages order items and quantities
- Tracks shipping and delivery information

### Shopping Cart

- Manages temporary storage of items before purchase
- Tracks cart items and quantities
- Handles session management

### Payments

- Records payment transactions
- Stores payment method information
- Tracks payment status

## Data Seeding

Initial data seeding includes:

- Geographic data (provinces and cities of Iran) from `province_city_iran.json`
- Basic product categories
- Administrative user accounts

## Database Configuration

The database connection and configuration settings can be found in:

- `ECommerce.RestAPI/appsettings.json`
- `ECommerce.RestAPI/appsettings.Development.json`

## Migration Management

Database migrations are handled through Entity Framework Core migrations. Migration files can be found in the project's Migrations folder.
