import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-free-seat-report-result',
  templateUrl: './free-seat-report-result.component.html',
  styleUrls: ['./free-seat-report-result.component.scss']
})
export class FreeSeatReportResultComponent implements OnInit {
  data: any;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    // Retrieve the data using paramMap
    const stateData = history.state.data;
    if (stateData) {
      this.data = stateData;
      console.log(this.data);
    } else {
      // Handle no data or incorrect data structure
      this.data = [];
    }
  }
}
