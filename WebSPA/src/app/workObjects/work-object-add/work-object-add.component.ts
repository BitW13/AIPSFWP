import { Component, OnInit } from '@angular/core';
import { WorkObject } from '../models/workObject';
import { WorkObjectService } from '../work-object.service';

@Component({
  selector: 'app-work-object-add',
  templateUrl: './work-object-add.component.html',
  styleUrls: ['./work-object-add.component.scss']
})
export class WorkObjectAddComponent implements OnInit {

  item: WorkObject

  constructor(private service: WorkObjectService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.item = new WorkObject();
  }

  add(){
    this.service.createItem(this.item);
    this.loadItem();
  }

  cancel(){
    this.loadItem();
  }

}
