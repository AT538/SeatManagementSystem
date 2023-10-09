/* tslint:disable */
import { Building } from './building';
import { City } from './city';
export interface Facility {
  building?: Building;
  buildingId?: number;
  city?: City;
  cityId?: number;
  facilityId?: number;
  facilityName?: string;
  floorNumber?: number;
}
