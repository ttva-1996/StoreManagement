import './App.css';

import React, { useEffect, useState } from 'react';
import { getStaffs, getStaff, createStaff, updateStaff, deleteStaff } from './api';

const App = () => {
  const [staffs, setStaffs] = useState([]);
  const [staff, setStaff] = useState({ name: '', price: 0 });
  const [editing, setEditing] = useState(false);

  useEffect(() => {
    fetchStaffs();
  }, []);

  const fetchStaffs = async () => {
    const data = await getStaffs();
    setStaffs(data);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setStaff({ ...staff, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (editing) {
      await updateStaff(staff.id, staff);
      setEditing(false);
    } else {
      await createStaff(staff);
    }
    setStaff({ name: '', price: 0 });
    fetchStaffs();
  };

  const handleEdit = async (id) => {
    const staffToEdit = await getStaff(id);
    setStaff(staffToEdit);
    setEditing(true);
  };

  const handleDelete = async (id) => {
    await deleteStaff(id);
    fetchStaffs();
  };

  return (
    <div>
      <h1>Staffs</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="name"
          placeholder="Name"
          value={staff.name}
          onChange={handleInputChange}
        />
        <button type="submit">{editing ? 'Update' : 'Add'} Staff</button>
      </form>
      <ul>
        {staffs.map(p => (
          <li key={p.id}>
            {p.name}
            <button onClick={() => handleEdit(p.id)}>Edit</button>
            <button onClick={() => handleDelete(p.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default App;
