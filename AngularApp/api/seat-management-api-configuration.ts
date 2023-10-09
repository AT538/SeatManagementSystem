/* tslint:disable */
import { Injectable } from '@angular/core';

/**
 * Global configuration for seat-management-api services
 */
@Injectable({
  providedIn: 'root',
})
export class SeatManagementApiConfiguration {
  rootUrl: string = '';
}

export interface SeatManagementApiConfigurationInterface {
  rootUrl?: string;
}
