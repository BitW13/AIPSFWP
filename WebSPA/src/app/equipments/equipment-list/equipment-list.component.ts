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

  constructor(private route: ActivatedRoute,
    private service: EquipmentService) {
    this.items = new Array<Equipment>();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.workObjectId = params['id']
    });
    if(this.workObjectId){
      console.log('Список оборудования на объекте ' + this.workObjectId)
    }
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: Equipment[]) => {
      this.items = data;  
    });
  }

  delete(item: Equipment) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };

}
