import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RoutesRecognized } from '@angular/router';

@Component({
  selector: 'app-headline',
  templateUrl: './headline.component.html',
  styleUrls: ['./headline.component.less']
})
export class HeadlineComponent implements OnInit {
  private routeData: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.router.events.subscribe((data) => {
      if (data instanceof RoutesRecognized) {
        this.routeData = data.state.root.firstChild?.data;
      }
    });
  }

  ngOnInit(): void {
  }

  get title() {
    return this.routeData?.title;
  }

  get parent() {
    return this.routeData?.parent;
  }
}
