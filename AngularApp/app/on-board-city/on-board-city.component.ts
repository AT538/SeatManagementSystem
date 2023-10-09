
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CityDTO } from 'src/api/models/city-dto';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';
import { CityService } from './city.service'; 

@Component({
  selector: 'app-onboard-city',
  templateUrl: './on-board-city.component.html',
  styleUrls: ['./on-board-city.component.scss']
})
export class OnBoardCityComponent  implements OnInit {
  cityForm: FormGroup = new FormGroup({}); 
  cities: CityDTO[] = [];

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private cityService: CityService 
  ) {}

  ngOnInit() {
    this.cityForm = this.fb.group({
      
      CityName: ['' ],
      CityAbbreviation: ['' ],
    });

 
    this.cityService.getCities().subscribe(
      (cities) => {
        this.cities = cities;
      },
      (error) => {
        console.error('Error fetching cities:', error);
      }
    );
  }

  onSubmit(): Observable<any> {
    if (this.cityForm.valid) {
      const formData: CityDTO = this.cityForm.value;

      
      this.http.post(API_CONFIG.baseUrl + 'City', formData).subscribe(
        (response) => {
         
          console.log('City created successfully:', response);
          window.alert("city created");

        
          this.cityForm.reset();
        },
        (error) => {
        
          console.error('Error creating city:', error);
          window.alert("unable to add city");

        }
      );
    }
    return of(undefined);
  }
}
