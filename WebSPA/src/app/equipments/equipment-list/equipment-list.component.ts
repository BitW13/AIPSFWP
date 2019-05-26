import { Component, OnInit } from '@angular/core';
import { Equipment } from '../models/equipment';
import { EquipmentService } from '../equipment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styleUrls: ['./equipment-list.component.scss']
})
export class EquipmentListComponent implements OnInit {

  workObjectId: number;
  items: Array<Equipment>;

  hasWorkObjecId: boolean; 
  list: Array<Equipment>;

  constructor(private route: ActivatedRoute,
    private service: EquipmentService) {
    this.items = new Array<Equipment>();
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
      this.service.getItemsByWorkObjectId(this.workObjectId).subscribe((data: Equipment[]) => {
        this.items = data;  
      });
      this.service.getItems().subscribe((data: Equipment[]) => {
        this.list = data;
        this.list = this.list.filter(i => i.workObjectId != this.workObjectId);  
      });
    }
    else{
      this.service.getItems().subscribe((data: Equipment[]) => {
        this.items = data;  
      });
    }
  }

  delete(item: Equipment) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };

  addToWorkObject(item: Equipment){
    item.workObjectId = this.workObjectId;
    this.service.updateItem(item).subscribe(data => {
      this.loadItems();
    });
  };

  deleteFromObject(item: Equipment){
    item.workObjectId = null;
    this.service.updateItem(item).subscribe(data => {
      this.loadItems();
    });
  }
}
