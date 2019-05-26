import { Component, OnInit, Input } from '@angular/core';
import { WorkTask } from '../models/workTask';
import { WorkTaskService } from '../work-task.service';

@Component({
  selector: 'app-work-task-add',
  templateUrl: './work-task-add.component.html',
  styleUrls: ['./work-task-add.component.scss']
})
export class WorkTaskAddComponent implements OnInit {

  @Input() workObjectId: number;
  item: WorkTask

  constructor(private service: WorkTaskService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.item = new WorkTask();
  }

  add(){
    console.log(this.workObjectId)
    this.item.workObjectId = this.workObjectId;
    this.service.createItem(this.item).subscribe((data: WorkTask) => {
      this.loadItem();  
    });
  }

  cancel(){
    this.loadItem();
  }

}
