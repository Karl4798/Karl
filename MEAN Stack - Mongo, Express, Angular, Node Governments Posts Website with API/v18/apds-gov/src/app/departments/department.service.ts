import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Department } from '../departments/department.model';

@Injectable({providedIn: 'root'})
export class DepartmentsService {

  // Constructor with required injections
  constructor(private http: HttpClient, private router: Router) {}

  // Variables used to store department information
  private departments: Department [] = [];
  private updatedDepartments = new Subject<Department[]>();

  // Gets a specific department (for passed id)
  getDepartment(id: string) {
    return this.http.get<{
      _id: string;
      Name: string,
    }>('/api/departments/' + id);
  }

  // Gets a list of all departments stored in the database
  getDepartments() {
    this.http.get<{message: string, departments: any}>('/api/departments')
    .pipe(map((departmentData) => {
      return departmentData.departments.map(department => {
        return {
          id: department._id,
          Name: department.Name,
        };
      });
    }))
    .subscribe((changedDepartments) => {
      this.departments = changedDepartments;
      this.updatedDepartments.next([...this.departments]);
    });
  }

  // Gets the updatedDepartments listener
  getDepartmentUpdateListener() {
    return this.updatedDepartments.asObservable();
  }

  // Method to handle addDepartment button click event
  addDepartment(Name: string) {
    const department: Department = { id: null, Name };
    this.http.post<{message: string, postId: string}>('/api/departments', department)
    .subscribe((responsePostData) => {
      console.log(responsePostData.message);
      const id = responsePostData.postId;
      department.id = id;
      this.departments.push(department);
      this.updatedDepartments.next([...this.departments]);
      this.router.navigate(['/departments']);
    });

  }

  // Method used to handle updateDepartment button click event
  updateDepartment(id: string, Name: string) {
    const department: Department = { id, Name };
    this.http
      .put('/api/departments/' + id, department)
      .subscribe(response => {
        const updatedDepartments = [...this.departments];
        const oldDepartmentIndex = updatedDepartments.findIndex(d => d.id === department.id);
        updatedDepartments[oldDepartmentIndex] = department;
        this.departments = updatedDepartments;
        this.updatedDepartments.next([...this.departments]);
        this.router.navigate(['/departments']);
      });
  }

  // Method used to handle deleteDepartment button click event
  deleteDepartment(departmentID: string) {
    this.http.delete('/api/departments/' + departmentID)
    .subscribe(() => {
      const updateDepartmentsDel = this.departments.filter(department => department.id !== departmentID);
      this.departments = updateDepartmentsDel;
      this.updatedDepartments.next([...this.departments]);
      console.log('Department Deleted');
    });
  }

}
