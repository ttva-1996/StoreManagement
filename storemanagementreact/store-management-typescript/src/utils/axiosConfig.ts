// src/utils/axiosConfig.ts
import axios from 'axios';

// Create an Axios instance
const axiosInstance = axios.create({
    baseURL: 'https://localhost:44372/api', // Set your base URL here
    timeout: 10000, // Optional: Set a timeout for requests
});

// Add a request interceptor
axiosInstance.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        // Do something with request error
        return Promise.reject(error);
    }
);

// Optionally, add a response interceptor
axiosInstance.interceptors.response.use(
    (response) => {
        // Any status code that lies within the range of 2xx causes this function to trigger
        return response;
    },
    (error) => {
        // Any status codes that falls outside the range of 2xx cause this function to trigger
        if (error.response.status === 401) {
            // Handle unauthorized errors (e.g., redirect to login)
        }
        return Promise.reject(error);
    }
);

export default axiosInstance;
