import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { EmployeeDTO } from 'src/api/models/employee-dto';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-onboard-employees',
  templateUrl: './onboard-employees.component.html',
  styleUrls: ['./onboard-employees.component.scss']
})
export class OnboardEmployeesComponent {
  employeeForm: FormGroup = new FormGroup({}); 


  constructor(private fb: FormBuilder, private http: HttpClient) {}

  ngOnInit() {
    this.employeeForm = this.fb.group({
      employeeName: [''],
      departmentId: [''],
      isAllocated: [false] 
    });
  }

  onSubmit(): Observable<any>  {
    if (this.employeeForm.valid) {
      const formData: EmployeeDTO = this.employeeForm.value;

     
      this.http.post(API_CONFIG.baseUrl + 'Employee', formData).subscribe(
        (response) => {
         
          console.log('employee created successfully:', response);

       
          this.employeeForm.reset();
        },
        (error) => {
         
          console.error('Error creating employee:', error);
        }
      );
    }
    return of(undefined);
  }
}
