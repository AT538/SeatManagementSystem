import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-cabin-deallocation',
  templateUrl: './cabin-deallocation.component.html',
  styleUrls: ['./cabin-deallocation.component.scss']
})
export class CabinDeallocationComponent {

  cabindeallocationForm: FormGroup= new FormGroup({});

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.cabindeallocationForm = this.fb.group({
      cabinId: [null, [Validators.required, Validators.min(1)]],
      
    });
  }


  onSubmit(): Observable<any> {
    if (this.cabindeallocationForm.valid) {
      console.log("valid");
      const formData = this.cabindeallocationForm.value;
     
const cabinIdParam = encodeURIComponent(formData.cabinId);
const apiUrl = `${API_CONFIG.baseUrl}CabinRoom?id=${cabinIdParam}`;

     
this.http.patch(apiUrl, null).subscribe(
  (response) => {
    console.log('Cabin deallocated successfully:', response);
    this.cabindeallocationForm.reset();
  },
  (error) => {
    console.error('Error deallocating cabin:', error);
  }
);
    }
    return of(undefined);
  }
}
