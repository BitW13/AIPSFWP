import { Component, OnInit } from '@angular/core';
import { WorkTask } from '../models/workTask';
import { ActivatedRoute } from '@angular/router';
import { WorkTaskService } from '../work-task.service';

@Component({
  selector: 'app-work-task-edit',
  templateUrl: './work-task-edit.component.html',
  styleUrls: ['./work-task-edit.component.scss']
})
export class WorkTaskEditComponent implements OnInit {

  id: number
  item: WorkTask;

  constructor(private route: ActivatedRoute,
    private service: WorkTaskService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.route.params.subscribe(params => {
      this.id = params['id']
    });
    this.service.getItem(this.item.id).subscribe((data: WorkTask) => {
      this.item = data;  
    });
  }

  edit(){
    this.service.updateItem(this.item).subscribe((data: WorkTask) => {
      this.loadItem();  
    });
  }

  cancel(){
    this.loadItem();
  }

}
