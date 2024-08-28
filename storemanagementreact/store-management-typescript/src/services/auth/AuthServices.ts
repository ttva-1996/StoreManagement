import axios from "axios";

const API_URL = "https://localhost:44372/api/auth";

interface Auth {
  username: string;
  password: string;
  token?: string;
}

interface Register {
  username: string;
  email: string;
  password: string;
}

class AuthService {
  async Login(auth: Auth): Promise<Auth> {
    const response = await axios.post<Auth>(`${API_URL}/login`, auth);
    return response.data;
  }

  async Register(register: Register): Promise<Register> {
    const response = await axios.post<Register>(
      `${API_URL}/register`,
      register
    );
    return response.data;
  }
}

export default new AuthService();
