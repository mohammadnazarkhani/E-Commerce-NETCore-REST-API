# Frontend Setup

## Prerequisites

- Node.js
- npm

## Setup Instructions

1. Navigate to the frontend directory:
    ```sh
    cd TondForoosh/TondForooshFrontend
    ```

2. Install dependencies:
    ```sh
    npm install
    ```

3. Update the API base URL in `src/axiosInstance.js` if necessary:
    ```javascript
    const axiosInstance = axios.create({
      baseURL: 'http://localhost:5000/', // Ensure this matches your API base URL
      headers: {
        'Content-Type': 'application/json',
      },
    });
    ```

4. Run the frontend application:
    ```sh
    npm start
    ```

## Available Pages

- `/`: Home page with product listings
- `/product/:id`: Product details page
- `/create/product`: Add new product page