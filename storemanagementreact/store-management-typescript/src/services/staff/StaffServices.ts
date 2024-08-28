import axios from 'axios';

const API_URL = 'https://localhost:44372/api/staff';

export interface Staff {
    id?: any;
    name: string;
    // Add any other fields relevant to the Staff object
}

class StaffService {
  async getStaffs(): Promise<Staff[]> {
    const response = await axios.get<Staff[]>(API_URL);
    return response.data;
  }

  async getStaff(id: any): Promise<Staff> {
    const response = await axios.get<Staff>(`${API_URL}/${id}`);
    return response.data;
  }

  async createStaff(staff: Omit<Staff, 'id'>): Promise<Staff> {
    const response = await axios.post<Staff>(API_URL, staff);
    return response.data;
  }

  async updateStaff(id: any, staff: Staff): Promise<Staff> {
    const response = await axios.put<Staff>(`${API_URL}/${id}`, staff);
    return response.data;
  }

  async deleteStaff(id: any): Promise<void> {
    await axios.delete(`${API_URL}/${id}`);
  }
}

export default new StaffService();