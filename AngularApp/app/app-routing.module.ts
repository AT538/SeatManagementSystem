import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { OnboardSeatsComponent } from './onboard-seats/onboard-seats.component';
import { OnboardEmployeesComponent } from './onboard-employees/onboard-employees.component';
import { AddAssetComponent } from './add-asset/add-asset.component';
import { CabinAllocationComponent } from './cabin-allocation/cabin-allocation.component';
import { CabinDeallocationComponent } from './cabin-deallocation/cabin-deallocation.component';
import { FreeSeatReportComponent } from './free-seat-report/free-seat-report.component';
import { OnboardFacilityComponent } from './onboard-facility/onboard-facility.component';
import { SeatAllocationComponent } from './seat-allocation/seat-allocation.component';
import { SeatDeallocationComponent } from './seat-deallocation/seat-deallocation.component';
import { OnBoardCityComponent } from './on-board-city/on-board-city.component';
import { OnBoardBuildingComponent } from './on-board-building/on-board-building.component';
import { OnBoardCabinsComponent } from './on-board-cabins/on-board-cabins.component';
import { OnBoardMeetingRoomsComponent } from './on-board-meeting-rooms/on-board-meeting-rooms.component';
import { OnBoardMeetingRoomAssetsComponent } from './on-board-meeting-room-assets/on-board-meeting-room-assets.component';
import { OnBoardDepartmentComponent } from './on-board-department/on-board-department.component';
import { FreeSeatReportResultComponent } from './free-seat-report-result/free-seat-report-result.component';

const routes: Routes = [{ path: '', redirectTo: '/login', pathMatch: 'full' },{path: 'login', component: LoginComponent},{ path: 'onboard-facility', component: OnboardFacilityComponent },
{ path: 'onboard-seats', component: OnboardSeatsComponent },
{ path: 'onboard-employees', component: OnboardEmployeesComponent },
{ path: 'seat-allocation', component: SeatAllocationComponent },
{ path: 'seat-deallocation', component: SeatDeallocationComponent },
{ path: 'cabin-allocation', component: CabinAllocationComponent },
{ path: 'cabin-deallocation', component: CabinDeallocationComponent },
{ path: 'add-asset', component: AddAssetComponent },
{ path: 'free-seat-report', component: FreeSeatReportComponent },
{ path: 'onboard-city', component: OnBoardCityComponent },
{ path: 'onboard-building', component: OnBoardBuildingComponent },
{ path: 'onboard-cabins', component: OnBoardCabinsComponent },
{ path: 'onboard-meeting-rooms', component: OnBoardMeetingRoomsComponent },
{ path: 'onboard-meeting-room-assets', component: OnBoardMeetingRoomAssetsComponent },
{ path: 'onboard-department', component: OnBoardDepartmentComponent },
{ path: 'free-seat-report-result', component: FreeSeatReportResultComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
