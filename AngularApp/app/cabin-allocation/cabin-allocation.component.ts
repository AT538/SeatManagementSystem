import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-cabin-allocation',
  templateUrl: './cabin-allocation.component.html',
  styleUrls: ['./cabin-allocation.component.scss']
})
export class CabinAllocationComponent {

  cabinallocationForm: FormGroup= new FormGroup({});

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.cabinallocationForm = this.fb.group({
      cabinId: [null, [Validators.required, Validators.min(1)]],
      employeeId: [null, Validators.required],
    });
  }

 
  onSubmit(): Observable<any> {
    if (this. cabinallocationForm.valid) {
      console.log("valid");
      const formData = this. cabinallocationForm.value;
      const  cabinparam = encodeURIComponent(formData.cabinId);
const employeeparam = encodeURIComponent(formData.employeeId);
const apiUrl = `${API_CONFIG.baseUrl}CabinRoom?id=${cabinparam}&EmployeeId=${employeeparam}`;

     
           
this.http.patch(apiUrl, null).subscribe(
  (response) => {
    console.log('Cabin allocated successfully:', response);
    this.cabinallocationForm.reset();
  },
  (error) => {
    console.error('Error allocating cabin:', error);
  }
);
    }
    return of(undefined);
  }
}
