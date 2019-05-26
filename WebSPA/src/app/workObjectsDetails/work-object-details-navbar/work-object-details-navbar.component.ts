import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-work-object-details-navbar',
  templateUrl: './work-object-details-navbar.component.html',
  styleUrls: ['./work-object-details-navbar.component.scss']
})
export class WorkObjectDetailsNavbarComponent implements OnInit {

  @Input() workObjectId: number;

  constructor() { }

  ngOnInit() {
  }

}
