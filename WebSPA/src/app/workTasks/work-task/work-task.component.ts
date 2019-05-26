import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-work-task',
  templateUrl: './work-task.component.html',
  styleUrls: ['./work-task.component.scss']
})
export class WorkTaskComponent implements OnInit {

  workObjectId: number;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.workObjectId = params['id'];
    });
  }
}
