import React, { Component } from 'react';
import StaffService, { Staff } from '../../services/staff/StaffServices';

interface StaffComponentState {
  staffs: Staff[];
  currentStaff: Staff | null;
  name: string;
}

class StaffComponent extends Component<{}, StaffComponentState> {
  constructor(props: {}) {
    super(props);
    this.state = {
      staffs: [],
      currentStaff: null,
      name: '',
    };
  }

  componentDidMount() {
    this.loadStaffs();
  }

  loadStaffs = async () => {
    const staffs = await StaffService.getStaffs();
    this.setState({ staffs });
  };

  handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    this.setState({ [e.target.name]: e.target.value } as unknown as Pick<StaffComponentState, keyof StaffComponentState>);
  };

  handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const { currentStaff, name} = this.state;
    const staffData = { name };

    if (currentStaff) {
      await StaffService.updateStaff(currentStaff.id, { ...currentStaff, ...staffData });
    } else {
      await StaffService.createStaff(staffData);
    }

    this.setState({ currentStaff: null, name: '' });
    this.loadStaffs();
  };

  handleEdit = (staff: Staff) => {
    this.setState({
      currentStaff: staff,
      name: staff.name,
    });
  };

  handleDelete = async (id?: any) => {
    await StaffService.deleteStaff(id);
    this.loadStaffs();
  };

  render() {
    const { staffs, name, currentStaff } = this.state;

    return (
      <div>
        <h1>Staff Management</h1>

        <form onSubmit={this.handleSubmit}>
          <input
            type="text"
            name="name"
            value={name}
            placeholder="Name"
            onChange={this.handleInputChange}
          />
          {/* <input
            type="text"
            name="position"
            value={position}
            placeholder="Position"
            onChange={this.handleInputChange}
          />
          <input
            type="text"
            name="department"
            value={department}
            placeholder="Department"
            onChange={this.handleInputChange}
          /> */}
          <button type="submit">{currentStaff ? 'Update' : 'Create'}</button>
        </form>

        <ul>
          {staffs.map((staff) => (
            <li key={staff.id}>
              {staff.name} 
              <button onClick={() => this.handleEdit(staff)}>Edit</button>
              <button onClick={() => this.handleDelete(staff.id)}>Delete</button>
            </li>
          ))}
        </ul>
      </div>
    );
  }
}

export default StaffComponent;
