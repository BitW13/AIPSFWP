import { Component, OnInit } from '@angular/core';
import { WorkTask } from '../models/workTask';
import { WorkTaskService } from '../work-task.service';

@Component({
  selector: 'app-work-task-add',
  templateUrl: './work-task-add.component.html',
  styleUrls: ['./work-task-add.component.scss']
})
export class WorkTaskAddComponent implements OnInit {

  item: WorkTask

  constructor(private service: WorkTaskService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.item = new WorkTask();
  }

  add(){
    this.service.createItem(this.item);
    this.loadItem();
  }

  cancel(){
    this.loadItem();
  }

}
