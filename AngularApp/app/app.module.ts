import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TitlebarComponent } from './titlebar/titlebar.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { NavigationComponent } from './navigation/navigation.component';

import { OnboardFacilityComponent } from './onboard-facility/onboard-facility.component';
import { OnboardSeatsComponent } from './onboard-seats/onboard-seats.component';
import { OnboardEmployeesComponent } from './onboard-employees/onboard-employees.component';
import { SeatAllocationComponent } from './seat-allocation/seat-allocation.component';
import { SeatDeallocationComponent } from './seat-deallocation/seat-deallocation.component';
import { CabinAllocationComponent } from './cabin-allocation/cabin-allocation.component';
import { CabinDeallocationComponent } from './cabin-deallocation/cabin-deallocation.component';
import { AddAssetComponent } from './add-asset/add-asset.component';
import { FreeSeatReportComponent } from './free-seat-report/free-seat-report.component';
import { ReactiveFormsModule } from '@angular/forms';
import { OnBoardCityComponent } from './on-board-city/on-board-city.component';
import { OnBoardBuildingComponent } from './on-board-building/on-board-building.component';
import { OnBoardCabinsComponent } from './on-board-cabins/on-board-cabins.component';
import { OnBoardMeetingRoomsComponent } from './on-board-meeting-rooms/on-board-meeting-rooms.component';
import { OnBoardMeetingRoomAssetsComponent } from './on-board-meeting-room-assets/on-board-meeting-room-assets.component';

import { OnBoardDepartmentComponent } from './on-board-department/on-board-department.component';
import { FreeSeatReportResultComponent } from './free-seat-report-result/free-seat-report-result.component';
import { AuthenticationService } from './login/authentication.service';
@NgModule({
  declarations: [
    AppComponent,
    TitlebarComponent,
    LoginComponent,
    NavigationComponent,

    OnboardFacilityComponent,
    OnboardSeatsComponent,
    OnboardEmployeesComponent,
    SeatAllocationComponent,
    SeatDeallocationComponent,
    CabinAllocationComponent,
    CabinDeallocationComponent,
    AddAssetComponent,
    FreeSeatReportComponent,
    OnBoardCityComponent,
    OnBoardBuildingComponent,
    OnBoardCabinsComponent,
    OnBoardMeetingRoomsComponent,
    OnBoardMeetingRoomAssetsComponent,

    OnBoardDepartmentComponent,
    FreeSeatReportResultComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent],
})
export class AppModule {}
