import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { BuildingDTO } from 'src/api/models';
import { API_CONFIG } from '../api.config';

@Component({
  selector: 'app-on-board-building',
  templateUrl: './on-board-building.component.html',
  styleUrls: ['./on-board-building.component.scss']
})
export class OnBoardBuildingComponent {
  buildingForm: FormGroup = new FormGroup({}); 
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    
  ) {}

  ngOnInit() {
    this.buildingForm = this.fb.group({
      
      BuildingName: [''],
      BuildingAbbreviation: [''],
    });

 
   
  }

  onSubmit(): Observable<any> {
    if (this.buildingForm.valid) {
      const formData: BuildingDTO = this.buildingForm.value;

     
      this.http.post(API_CONFIG.baseUrl + 'Building', formData).subscribe(
        (response) => {
        
          console.log('Building created successfully:', response);
          window.alert("building added successfully");

         
          this.buildingForm.reset();
        },
        (error) => {
         
          console.error('Error creating Building:', error);
          window.alert("unable to add building");
        }
      );
    }
    return of(undefined);
  }


}
