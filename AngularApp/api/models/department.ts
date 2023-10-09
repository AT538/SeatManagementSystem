/* tslint:disable */
import { Employee } from './employee';
export interface Department {
  departmentId?: number;
  departmentName?: string;
  employees?: Array<Employee>;
}
