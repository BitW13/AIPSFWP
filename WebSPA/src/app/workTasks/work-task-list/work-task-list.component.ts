import { Component, OnInit } from '@angular/core';
import { WorkTask } from '../models/workTask';
import { WorkTaskService } from '../work-task.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-work-task-list',
  templateUrl: './work-task-list.component.html',
  styleUrls: ['./work-task-list.component.scss']
})
export class WorkTaskListComponent implements OnInit {

  workObjectId: number;
  items: Array<WorkTask>;

  constructor(private route: ActivatedRoute,
    private service: WorkTaskService) {
    this.items = new Array<WorkTask>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.route.params.subscribe(params => {
      this.workObjectId = params['id']
    });
    if(this.workObjectId){
      console.log('Список задач на объекте ' + this.workObjectId)
    }
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
