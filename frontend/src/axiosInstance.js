import axios from "axios";

const axiosInstance = axios.create({
  baseURL: "http://localhost:5000/",
  headers: {
    "Content-Type": "application/json",
  },
});

axiosInstance.interceptors.request.use(
  (request) => {
    console.log("Starting Request:", request.method, request.url);
    return request;
  },
  (error) => Promise.reject(error)
);

axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    // Extract meaningful error message
    const errorMessage = error.response?.data?.errors
      ? Object.values(error.response.data.errors).flat().join(', ')
      : error.response?.data?.title || error.message || 'An error occurred';
    
    console.error("API Error:", errorMessage);
    return Promise.reject(error);
  }
);

export default axiosInstance;
