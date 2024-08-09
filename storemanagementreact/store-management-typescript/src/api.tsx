import axios from 'axios';

// Define the base URL for the API
const API_URL = 'https://localhost:44372/api/staff';

// Define a TypeScript interface for the Staff object
interface Staff {
    id?: number;
    name: string;
    position: string;
    department: string;
    // Add any other fields relevant to the Staff object
}

// Get all staff members
export const getStaffs = async (): Promise<Staff[]> => {
    const response = await axios.get<Staff[]>(API_URL);
    return response.data;
};

// Get a single staff member by ID
export const getStaff = async (id: number): Promise<Staff> => {
    const response = await axios.get<Staff>(`${API_URL}/${id}`);
    return response.data;
};

// Create a new staff member
export const createStaff = async (staff: Staff): Promise<Staff> => {
    const response = await axios.post<Staff>(API_URL, staff);
    return response.data;
};

// Update an existing staff member by ID
export const updateStaff = async (id: number, staff: Staff): Promise<Staff> => {
    const response = await axios.put<Staff>(`${API_URL}/${id}`, staff);
    return response.data;
};

// Delete a staff member by ID
export const deleteStaff = async (id: number): Promise<void> => {
    await axios.delete(`${API_URL}/${id}`);
};
