# AR-Based Interior Visualization Tool for Housing Renovation (03/06/2026)

## 📖 Overview

This project is an Android-based mobile Augmented Reality (AR) application designed to support interior visualization for housing renovations. Built for mobile hardware, the system allows users to:

- Map custom room boundaries in real time
- Calculate floor area of irregular room shapes using mathematical formulas
- Simulate room layouts through the placement of 2D and 3D furniture assets within an AR environment

---

## 🚀 Current System Status

**Status:** Active Development (Undergraduate IT Thesis Prototype)

**Target Platform:** Android (Optimized for ARM64 / OpenGLES3 devices)

### Development Progress

| Module   | Status |
|----------|----------|
| Android AR Framework (Unity 6 + URP + ARCore) | 🟢 Completed |
| Point-to-Point Boundary Mapping | 🟢 Completed |
| Floor Area Calculation (Shoelace Formula) | 🟡 In Progress |
| Asset Upload Module | 🔴 Pending |

### Completed Features

- Unity 6 project configured with Universal Render Pipeline (URP)
- Google Play Services for AR integrated
- ARCore plane detection operational
- Boundary mapping logic functional

### Ongoing Development

- C# implementation of the Shoelace Formula for area computation
- Real-time square meter calculation and visualization

### Planned Features

- Laravel-based asset upload workflow
- AI-powered background removal
- Furniture asset generation and management

---

## 🛠️ Technology Stack

### Frontend / AR Engine
- Unity 6 (6000.3.8f1)

### Graphics Pipeline
- Universal Render Pipeline (URP)

### Augmented Reality Framework
- ARCore (Google Play Services for AR)

### Backend
- Laravel (PHP)

### Database
- NeonDB (PostgreSQL)

### Cloud Services
- Cloudinary (Image Hosting)
- Remove.bg (AI Background Removal)

---

## ✨ Core Features

### 1. Custom Boundary Mapping

Utilizes ARCore SLAM and plane detection technologies to allow users to define room boundaries by tapping points within the physical environment.

**Capabilities:**
- Real-time plane detection
- Point-to-point room mapping
- Support for irregular room shapes
- Dynamic boundary visualization

---

### 2. Shoelace Area Calculation

Calculates the exact floor area of user-defined room layouts using the Shoelace Formula.

**Features:**
- Supports irregular polygons
- Uses captured `(x, z)` coordinates
- Generates real-time area measurements
- Outputs floor area in square meters (m²)

---

### 3. Smart Asset Simulation

Allows users to place furniture assets within the AR environment to visualize renovation layouts before implementation.

**Features:**
- 2D and 3D furniture placement
- Billboard rendering support
- Automated background removal
- Interactive layout simulation

---

### 4. Cloud Persistence

Stores renovation layouts and spatial configurations for future retrieval.

**Stored Data Includes:**
- Boundary coordinates
- Furniture placements
- Asset references
- Area calculations
- Room metadata

---

## 🔬 Statement of the Problem

This study seeks to answer the following questions:

1. How can an Android-based mobile AR application be designed and developed to support interior visualization for housing renovation?

2. How can the system support accurate room boundary mapping and floor area calculation for proper spatial representation?

3. How can a furniture asset uploading module and data persistence workflow be integrated into the AR environment to simulate and save renovation layouts?

4. How usable is the developed AR application based on its System Usability Scale (SUS) score?

---

## 🎯 Specific Objectives

### 1. System Development

To design and develop an Android-based mobile AR application for interior visualization.

### 2. Spatial Mapping and Calculation

To implement an environmental data acquisition and point-to-point mapping workflow that uses ARCore-supported plane detection to define custom-shaped layouts and compute floor area using the Shoelace Formula.

### 3. Asset Management

To develop a furniture asset management and data persistence module that allows 2D and 3D assets to be placed within the mapped environment and saves spatial configurations.

### 4. Usability Evaluation

To evaluate the usability and functionality of the developed system through controlled user tasks and the System Usability Scale (SUS) questionnaire.

---

## ⚙️ Data Processing Workflow

The system processes spatial and asset data through a structured pipeline from physical environment acquisition to cloud storage.

### Step 1: Environmental Data Acquisition

- ARCore performs plane detection and spatial tracking.
- Users define room boundaries by placing coordinate points.
- Boundary coordinates are recorded as `(x, z)` values.

### Step 2: Mathematical Area Calculation

- Captured coordinates are passed into a C# implementation of the Shoelace Formula.
- The system computes the area of irregular polygons.
- Real-time floor area metrics are generated in square meters (m²).

### Step 3: Data Serialization and Transmission

- Boundary coordinates and room metadata are serialized into JSON format.
- Data is transmitted through REST API endpoints to the Laravel backend.

### Step 4: Asset Processing

- User-uploaded furniture images are sent to the backend.
- Remove.bg removes image backgrounds automatically.
- Processed assets are uploaded to Cloudinary.

### Step 5: Data Persistence

The final room configuration is stored within NeonDB PostgreSQL, including:

- Boundary coordinates
- Area calculations
- Asset URLs
- Furniture placements
- Room metadata

---

## 📊 Expected Outputs

- Accurate room boundary mapping
- Real-time floor area calculations
- Interactive AR furniture visualization
- Persistent renovation layouts
- SUS-based usability evaluation results

---

## 🏗️ Project Scope

The system focuses on:

- Android-based AR visualization
- Interior layout planning
- Floor area measurement
- Furniture placement simulation
- Cloud-based data storage

The project does not aim to replace professional CAD or architectural software but serves as an accessible visualization and planning tool for residential renovation scenarios.

---

## 📄 License

This project is developed as an Undergraduate Information Technology Thesis Prototype for academic and research purposes.

## FOR COLLABORATORS
-Install: Get Unity Hub 6000.3.8f1.
-Clone: Use GitHub Desktop to clone the repository.
-Open Unity Hub > Add project from disk > Select the cloned folder.
-Wait: Let it finish the initial re-import process (this is normal).
-Sync: Always Pull before you start and Push when you finish.
