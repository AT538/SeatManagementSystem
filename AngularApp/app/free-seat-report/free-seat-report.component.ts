import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-free-seat-report',
  templateUrl: './free-seat-report.component.html',
  styleUrls: ['./free-seat-report.component.scss']
})
export class FreeSeatReportComponent {

  freeSeatReportForm: FormGroup= new FormGroup({});
  

  constructor(private fb: FormBuilder, private http: HttpClient,private router: Router) {
    this.freeSeatReportForm = this.fb.group({
     //Id:[null,],
      City: [null, ],
      Building: [null],
      Facility: [null],
     FloorNumber: [null],
     Page: [null],
     PageSize: [null],
    });
  }
 


  onSubmit(): Observable<any> {
    if (this.freeSeatReportForm.valid) {
      const formData = this.freeSeatReportForm.value;
      //const idparam=encodeURIComponent(formData.id);

      const  cityParam = encodeURIComponent(formData.City);
      const buildingParam = encodeURIComponent(formData.Building);
      const facilityParam = encodeURIComponent(formData.Facility);
      const floorParam = encodeURIComponent(formData.FloorNumber);
      const PageParam = encodeURIComponent(formData.Page);
      const PageSizeParam = encodeURIComponent(formData.PageSize);
      const apiUrl = `${API_CONFIG.baseUrl}Seat`;
     // let apiurl = '';
      
      /*if (idparam !== null && idparam !== undefined) {
        apiurl = `id=${idparam}&`;
      }*/
      
      const finalApiUrl = `${apiUrl}?cityid=${cityParam}&buildingid=${buildingParam}&facilityid=${facilityParam}&Floor=${floorParam}&page=${PageParam}&pageSize=${PageSizeParam}`;
      


      this.http.get(finalApiUrl).subscribe(
        (response) => {
          
          this.router.navigate(['/free-seat-report-result'], { state: { data: response } });
          console.log(response);
        },
        (error) => {
        
          console.error('API Error:', error);
        }
      );
    }
    return of(undefined);
  }}