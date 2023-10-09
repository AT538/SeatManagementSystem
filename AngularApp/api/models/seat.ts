/* tslint:disable */
import { Employee } from './employee';
import { Facility } from './facility';
export interface Seat {
  employee?: Employee;
  employeeId?: number;
  facility?: Facility;
  facilityId?: number;
  seatId?: number;
}
