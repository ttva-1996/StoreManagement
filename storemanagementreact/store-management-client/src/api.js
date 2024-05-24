import axios from 'axios';

const API_URL = 'https://localhost:44372/api/staff';

export const getStaffs = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getStaff = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createStaff = async (staff) => {
    const response = await axios.post(API_URL, staff);
    return response.data;
};

export const updateStaff = async (id, staff) => {
    const response = await axios.put(`${API_URL}/${id}`, staff);
    return response.data;
};

export const deleteStaff = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};