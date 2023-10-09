import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { DepartmentDTO } from 'src/api/models';
import { API_CONFIG } from '../api.config';

@Component({
  selector: 'app-on-board-department',
  templateUrl: './on-board-department.component.html',
  styleUrls: ['./on-board-department.component.scss']
})
export class OnBoardDepartmentComponent {
  departmentForm: FormGroup = new FormGroup({}); 
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    
  ) {}

  ngOnInit() {
    this.departmentForm = this.fb.group({
 
      DepartmentName: ['' ],
      
    });

 
   
  }

  onSubmit(): Observable<any> {
    if (this.departmentForm.valid) {
      const formData: DepartmentDTO = this.departmentForm.value;

     
      this.http.post(API_CONFIG.baseUrl + 'Department', formData).subscribe(
        (response) => {
        
          console.log('department created successfully:', response);
          window.alert("department added");

       
          this.departmentForm.reset();
        },
        (error) => {
         
          console.error('Error creating department:', error);
          window.alert("unable to add department");

        }
      );
    }
    return of(undefined);
  }


}
