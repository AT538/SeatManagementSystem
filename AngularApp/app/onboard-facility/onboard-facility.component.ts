import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { FacilityDTO } from 'src/api/models';
import { API_CONFIG } from '../api.config';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-onboard-facility',
  templateUrl: './onboard-facility.component.html',
  styleUrls: ['./onboard-facility.component.scss']
})
export class OnboardFacilityComponent {
  facilityForm: FormGroup = new FormGroup({}); 


  constructor(private fb: FormBuilder, private http: HttpClient) {}

  ngOnInit() {
    this.facilityForm = this.fb.group({
      buildingId: [''],
      cityId: [''],
      facilityName: [''],
      floorNumber: [''],
     
    });
  }

  onSubmit(): Observable<any>  {
    if (this.facilityForm.valid) {
      const formData: FacilityDTO = this.facilityForm.value;

     
      this.http.post(API_CONFIG.baseUrl + 'Facility', formData).subscribe(
        (response) => {
         
          console.log('facility created successfully:', response);

       
          this.facilityForm.reset();
        },
        (error) => {
         
          console.error('Error creating facility:', error);
        }
      );
    }
    return of(undefined);
  }
}