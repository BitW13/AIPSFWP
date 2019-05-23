import { Component, OnInit } from '@angular/core';
import { WorkTask } from '../models/workTask';
import { WorkTaskService } from '../work-task.service';

@Component({
  selector: 'app-work-task-list',
  templateUrl: './work-task-list.component.html',
  styleUrls: ['./work-task-list.component.scss']
})
export class WorkTaskListComponent implements OnInit {

  items: Array<WorkTask>;

  constructor(private service: WorkTaskService) {
    this.items = new Array<WorkTask>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: WorkTask[]) => {
      this.items = data;  
    });
  }

  delete(item: WorkTask) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };

}
