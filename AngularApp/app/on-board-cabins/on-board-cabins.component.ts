import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, catchError, of, tap, throwError } from 'rxjs';



@Component({
  selector: 'app-on-board-cabins',
  templateUrl: './on-board-cabins.component.html',
  styleUrls: ['./on-board-cabins.component.scss']
})
export class OnBoardCabinsComponent {

  cabinForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.cabinForm = this.fb.group({
      cabinCount: [null, Validators.required], 
      FacilityId: [null, Validators.required],
    });
  }

  onSubmit(): Observable<any> {
    if (this.cabinForm.valid) {
      const formData= this.cabinForm.value;
console.log(formData);
   const  totalcabinsParam = encodeURIComponent(formData.cabinCount);
const facilityIdParam = encodeURIComponent(formData.FacilityId);
const apiUrl = `${API_CONFIG.baseUrl}CabinRoom?totalCabins=${totalcabinsParam}&FacilityId=${facilityIdParam}`;

      console.log(apiUrl);

      this.http.post(apiUrl,null).subscribe(
        (response) => {
          console.log('Seat created successfully:', response);
          this.cabinForm.reset();
        },
        (error) => {
          console.error('Error creating seat:', error);
        }
      );
      }
    return of(undefined);
  }
}
