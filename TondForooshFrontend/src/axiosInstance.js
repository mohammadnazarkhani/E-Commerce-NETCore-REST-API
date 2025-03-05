import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://localhost:5000/api', // This should be the base URL for your API
  headers: {
    'Content-Type': 'application/json',
  },
});

export default axiosInstance;
