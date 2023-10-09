/* tslint:disable */
import { NgModule, ModuleWithProviders } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { SeatManagementApiConfiguration, SeatManagementApiConfigurationInterface } from './seat-management-api-configuration';

import { AssetService } from './services/asset.service';
import { BuildingService } from './services/building.service';
import { CabinRoomService } from './services/cabin-room.service';
import { CityService } from './services/city.service';
import { DepartmentService } from './services/department.service';
import { EmployeeService } from './services/employee.service';
import { FacilityService } from './services/facility.service';
import { MeetingRoomService } from './services/meeting-room.service';
import { MeetingRoomAssetsService } from './services/meeting-room-assets.service';
import { SeatService } from './services/seat.service';
import { UserService } from './services/user.service';

/**
 * Provider for all seat-management-api services, plus SeatManagementApiConfiguration
 */
@NgModule({
  imports: [
    HttpClientModule
  ],
  exports: [
    HttpClientModule
  ],
  declarations: [],
  providers: [
    SeatManagementApiConfiguration,
    AssetService,
    BuildingService,
    CabinRoomService,
    CityService,
    DepartmentService,
    EmployeeService,
    FacilityService,
    MeetingRoomService,
    MeetingRoomAssetsService,
    SeatService,
    UserService
  ],
})
export class SeatManagementApiModule {
  static forRoot(customParams: SeatManagementApiConfigurationInterface): ModuleWithProviders<SeatManagementApiModule> {
    return {
      ngModule: SeatManagementApiModule,
      providers: [
        {
          provide: SeatManagementApiConfiguration,
          useValue: {rootUrl: customParams.rootUrl}
        }
      ]
    }
  }
}
