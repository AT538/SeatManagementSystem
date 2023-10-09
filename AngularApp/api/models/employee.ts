/* tslint:disable */
import { Department } from './department';
export interface Employee {
  department?: Department;
  departmentId?: number;
  employeeId?: number;
  employeeName?: string;
  isAllocated?: boolean;
}
