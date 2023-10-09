import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';



@Component({
  selector: 'app-onboard-seats',
  templateUrl: './onboard-seats.component.html',
  styleUrls: ['./onboard-seats.component.scss']
})
export class OnboardSeatsComponent {

  seatForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.seatForm = this.fb.group({
      TotalSeats: [null, Validators.required], 
      FacilityId: [null, Validators.required], 
    });
  }

  onSubmit(): Observable<any> {
    if (this.seatForm.valid) {
      const formData= this.seatForm.value;
console.log(formData);
   const  totalSeatsParam = encodeURIComponent(formData.TotalSeats);
const facilityIdParam = encodeURIComponent(formData.FacilityId);
const apiUrl = `${API_CONFIG.baseUrl}Seat?totalSeats=${totalSeatsParam}&FacilityId=${facilityIdParam}`;

      console.log(apiUrl);

      this.http.post(apiUrl, null).subscribe(
        (response) => {
          console.log('Seat created successfully:', response);
          this.seatForm.reset();
        },
        (error) => {
          console.error('Error creating seat:', error);
        }
      );
      }
    return of(undefined);
  }
}
