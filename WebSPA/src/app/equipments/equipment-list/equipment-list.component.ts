import { Component, OnInit } from '@angular/core';
import { Equipment } from '../models/equipment';
import { EquipmentService } from '../equipment.service';
import { ActivatedRoute } from '@angular/router';
import { WorkObject } from 'src/app/workObjects/models/workObject';

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
      this.service.getItems().subscribe((data: WorkObject[]) => {
        this.list = data;  
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

}
