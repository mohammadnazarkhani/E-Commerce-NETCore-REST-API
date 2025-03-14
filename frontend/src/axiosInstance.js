import axios from "axios";

const axiosInstance = axios.create({
  baseURL: "http://localhost:5000/",
  headers: {
    "Content-Type": "application/json",
  },
});

axiosInstance.interceptors.request.use((request) => {
  console.log("Starting Request:", request.method, request.url, request.data);
  return request;
});

axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error("API Error:", error.response?.data || error.message);
    return Promise.reject(error);
  }
);

export default axiosInstance;
