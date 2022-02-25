import axios from 'axios';

const api = axios.create({
    baseURL : "https://localhost:44327/api",
});

export default api;