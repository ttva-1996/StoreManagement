import axios from 'axios';

const API_URL = 'https://localhost:44372/api/auth';

export interface Auth {
    username: string;
    password: string;
    token?: string;
}

class AuthService {
    async Login(auth: Auth): Promise<Auth> {
        const response = await axios.post<Auth>(`${API_URL}/login`, auth);
        return response.data;
      }
}

export default new AuthService();
