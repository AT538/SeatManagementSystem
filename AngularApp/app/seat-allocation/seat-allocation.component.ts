import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-seat-allocation',
  templateUrl: './seat-allocation.component.html',
  styleUrls: ['./seat-allocation.component.scss']
})
export class SeatAllocationComponent {

  seatallocationForm: FormGroup= new FormGroup({});

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.seatallocationForm = this.fb.group({
      seatId: [null],
      employeeId: [null ],
    });
  }


  onSubmit(): Observable<any> {
    if (this.seatallocationForm.valid) {
      console.log("valid");
      const formData = this.seatallocationForm.value;
      const  totalSeatsParam = encodeURIComponent(formData.seatId);
const facilityIdParam = encodeURIComponent(formData.employeeId);
const apiUrl = `${API_CONFIG.baseUrl}Seat?id=${totalSeatsParam}&EmployeeId=${facilityIdParam}`;

     
this.http.patch(apiUrl, null).subscribe(
  (response) => {
    console.log('Seat allocated successfully:', response);
    this.seatallocationForm.reset();
  },
  (error) => {
    console.error('Error allocating seat:', error);
  }
);
    }
    return of(undefined);
  }
}
