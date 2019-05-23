import { Component, OnInit } from '@angular/core';
import { WorkObjectService } from '../work-object.service';
import { WorkObject } from '../models/workObject';

@Component({
  selector: 'app-work-object-list',
  templateUrl: './work-object-list.component.html',
  styleUrls: ['./work-object-list.component.scss']
})
export class WorkObjectListComponent implements OnInit {

  items: Array<WorkObject>;

  constructor(private service: WorkObjectService) {
    this.items = new Array<WorkObject>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: WorkObject[]) => {
      this.items = data;  
    });
  }

  delete(item: WorkObject) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };

}
