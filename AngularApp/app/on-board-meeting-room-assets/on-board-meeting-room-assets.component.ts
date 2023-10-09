import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';
import { MeetingRoomAssetsDTO } from 'src/api/models/meeting-room-assets-dto';

@Component({
  selector: 'app-on-board-meeting-room-assets',
  templateUrl: './on-board-meeting-room-assets.component.html',
  styleUrls: ['./on-board-meeting-room-assets.component.scss']
})
export class OnBoardMeetingRoomAssetsComponent {

  roomassetForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.roomassetForm = this.fb.group({
      MeetingRoomId: [null, [Validators.required]],
      AssetId: [null, Validators.required],
      quantity: [null, Validators.required],
    });
  }

 
  onSubmit(): Observable<any>  {
    if (this.roomassetForm .valid) {
      const formData:MeetingRoomAssetsDTO = this.roomassetForm .value;
      console.log(formData);

     
      this.http.post(API_CONFIG.baseUrl + 'MeetingRoomAssets', formData).subscribe(
     
        (response) => {
         
          console.log('asset added successfully:', response);
          console.log(formData);
       
          this.roomassetForm .reset();
        },
        (error) => {
          console.log("eror");
          console.log(formData);
          console.error('Error allocating asset:', error);
        }
        
      );
    }
    return of(undefined);
  }
}
