import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, Observer, of,Subject } from 'rxjs';
import { AssetDTO } from 'src/api/models/asset-dto';
import { AssetService } from 'src/api/services';

@Component({
  selector: 'app-add-asset',
  templateUrl: './add-asset.component.html',
  styleUrls: ['./add-asset.component.scss'],
})
export class AddAssetComponent {
  AssetForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
  
     
  ) {
    this.AssetForm = this.fb.group({
      AssetName: [
        '',
        [Validators.required, Validators.pattern(/^[A-Za-z0-9]+$/)],
      ],
    });
  }

 











onSubmit() {
  if (this. AssetForm.valid) {
    const formData: AssetDTO = this. AssetForm.value;

   
    this.http.post(API_CONFIG.baseUrl + 'Asset', formData).subscribe(
      (response) => {
      
        console.log('asset created successfully:', response);
        window.alert("asset added");

     
        this. AssetForm.reset();
      })
      
  }

}}