import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-work-object-details',
  templateUrl: './work-object-details.component.html',
  styleUrls: ['./work-object-details.component.scss']
})
export class WorkObjectDetailsComponent implements OnInit {

  workObjectId: number;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.workObjectId = params['id']
    });
  }
}
