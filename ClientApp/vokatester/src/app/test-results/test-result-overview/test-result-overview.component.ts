import { Component, OnInit } from '@angular/core';
import { TestResult } from 'src/app/models/test-result';
import { TestResultsService } from 'src/app/services/test-results.service';

@Component({
  selector: 'app-test-result-overview',
  templateUrl: './test-result-overview.component.html',
  styleUrls: ['./test-result-overview.component.less']
})
export class TestResultOverviewComponent implements OnInit {
  testResults: TestResult[] = [];

  constructor(
    private testResultsService: TestResultsService
  ) { }

  ngOnInit(): void {
    this.testResultsService
      .all()
      .subscribe(res => {
        this.testResults = res;
      });
  }
}