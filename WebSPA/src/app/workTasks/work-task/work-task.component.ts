import { Component, OnInit, Input, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkTask } from '../models/workTask';
import { WorkTaskService } from '../work-task.service';

@Component({
  selector: 'app-work-task',
  templateUrl: './work-task.component.html',
  styleUrls: ['./work-task.component.scss']
})
export class WorkTaskComponent implements OnInit {

  @ViewChild('readTemplate') readTemplate: TemplateRef<any>;
  @ViewChild('editTemplate') editTemplate: TemplateRef<any>;

  workObjectId: number;

  editedItem: WorkTask;
  items: Array<WorkTask>;

  isNewRecord: boolean;
  statusMessage: string;

  constructor(private route: ActivatedRoute, private service: WorkTaskService) {
    this.items = new Array<WorkTask>();
  };

  ngOnInit() {
    this.loadItems();
  };

  loadItems() {
    this.route.params.subscribe(params => {
      this.workObjectId = params['id'];
    });
    console.log(this.workObjectId);
    this.service.getItemsByWorkObjectId(this.workObjectId).subscribe((data: WorkTask[]) => {
      this.items = data;  
    });
  };

  add() {
      this.editedItem = new WorkTask();
      this.items.push(this.editedItem);
      this.isNewRecord = true;
  };
   
  edit(item: WorkTask) {
      this.editedItem = item;
  };
  
  loadTemplate(item: WorkTask) {
    if (this.editedItem && this.editedItem.id == item.id) {
      return this.editTemplate;
    } 
    else {
      return this.readTemplate;
    }
  }

  save() {
    this.editedItem.workObjectId = this.workObjectId;
    if (this.isNewRecord) {
      this.service.createItem(this.editedItem).subscribe(data => {
        this.statusMessage = 'Данные успешно добавлены',
        this.loadItems();
      });
      this.isNewRecord = false;
      this.editedItem = null;
    } 
    else {
      this.service.updateItem(this.editedItem).subscribe(data => {
          this.statusMessage = 'Данные успешно обновлены',
          this.loadItems();
      });
      this.editedItem = null;
    }
  }

  cancel() {
    if (this.isNewRecord) {
      this.items.pop();
      this.isNewRecord = false;
    }
    this.editedItem = null;
  }

  delete(item: WorkTask) {
    this.service.deleteItem(item.id).subscribe(data => {
      this.statusMessage = 'Данные успешно удалены',
      this.loadItems();
    });
  }
}
