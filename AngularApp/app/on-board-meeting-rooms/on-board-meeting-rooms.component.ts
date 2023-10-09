import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from '../api.config';
import { Observable, of } from 'rxjs';



@Component({
  selector: 'app-on-board-meeting-rooms',
  templateUrl: './on-board-meeting-rooms.component.html',
  styleUrls: ['./on-board-meeting-rooms.component.scss']
})
export class OnBoardMeetingRoomsComponent {

  meetingroomForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.meetingroomForm = this.fb.group({
     RoomCount: [null, Validators.required], 
      facilityId: [null, Validators.required],
    });
  }

  onSubmit(): Observable<any> {
    if (this.meetingroomForm.valid) {
      const formData= this.meetingroomForm.value;
console.log(formData);
   const  totalmeetingroomParam = encodeURIComponent(formData.RoomCount);
const facilityIdParam = encodeURIComponent(formData.facilityId);
const apiUrl = `${API_CONFIG.baseUrl}MeetingRoom?totalRooms=${  totalmeetingroomParam}&FacilityId=${facilityIdParam}`;

      console.log(apiUrl);

      this.http.post(apiUrl, null).subscribe(
        (response) => {
          console.log('meetingroom created successfully:', response);
          this.meetingroomForm.reset();
        },
        (error) => {
          console.error('Error creating room:', error);
        }
      );
      }
    return of(undefined);
  }
}
