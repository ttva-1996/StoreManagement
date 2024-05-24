import { Component, OnInit } from '@angular/core';
import { StaffService, Staff } from '../staff.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrls: ['./staff-list.component.css'],
  standalone: true,
  imports: [CommonModule, HttpClientModule]
})
export class StaffListComponent implements OnInit {
  staffs: Staff[] = [];

  constructor(private staffService: StaffService) {}

  ngOnInit(): void {
    this.staffService.getStaffs().subscribe(data => {
      this.staffs = data;
    });
  }
}
