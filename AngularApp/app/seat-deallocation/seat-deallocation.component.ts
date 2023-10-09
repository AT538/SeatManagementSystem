import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-seat-deallocation',
  templateUrl: './seat-deallocation.component.html',
  styleUrls: ['./seat-deallocation.component.scss']
})
export class SeatDeallocationComponent {

  seatdeallocationForm: FormGroup= new FormGroup({});

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.seatdeallocationForm = this.fb.group({
      seatId: [null, [Validators.required, Validators.min(1)]],
      
    });
  }

  
  onSubmit(): Observable<any> {
    if (this.seatdeallocationForm.valid) {
      console.log("valid");
      const formData = this.seatdeallocationForm.value;
      const  totalSeatsParam = encodeURIComponent(formData.seatId);

const apiUrl = `${API_CONFIG.baseUrl}Seat?id=${totalSeatsParam}`;

     
this.http.patch(apiUrl, null).subscribe(
  (response) => {
    console.log('Seat deallocated successfully:', response);
    this.seatdeallocationForm.reset();
  },
  (error) => {
    console.error('Error deallocating seat:', error);
  }
);
    }
    return of(undefined);
  }
}
