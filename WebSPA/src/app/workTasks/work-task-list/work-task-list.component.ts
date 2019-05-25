import { Component, OnInit } from '@angular/core';
import { WorkTask } from '../models/workTask';
import { WorkTaskService } from '../work-task.service';
import { ActivatedRoute } from '@angular/router';
import { WorkObject } from 'src/app/workObjects/models/workObject';
import { WorkObjectService } from 'src/app/workObjects/work-object.service';

@Component({
  selector: 'app-work-task-list',
  templateUrl: './work-task-list.component.html',
  styleUrls: ['./work-task-list.component.scss']
})
export class WorkTaskListComponent implements OnInit {

  workObjectId: number;
  items: Array<WorkTask>;
  hasWorkObjecId: boolean;

  list: Array<WorkObject>;

  constructor(private route: ActivatedRoute,
    private service: WorkTaskService,
    private workObjectService: WorkObjectService) {
    this.items = new Array<WorkTask>();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.workObjectId = params['id'];
    });
    if(this.workObjectId){
      this.hasWorkObjecId = true;
    }
    else{
      this.hasWorkObjecId = false;
    }
    this.loadItems();
  }

  loadItems(){
    if(this.hasWorkObjecId){
      this.service.getItemsByWorkObjectId(this.workObjectId).subscribe((data: WorkTask[]) => {
        this.items = data;  
      });
      this.workObjectService.getItems().subscribe((data: WorkObject[]) => {
        this.list = data;  
      });
    }
    else{
      this.service.getItems().subscribe((data: WorkTask[]) => {
        this.items = data;  
      });
    }
  }

  delete(item: WorkTask) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };

}
