import { Component, OnInit } from '@angular/core';
import { Equipment } from '../models/equipment';
import { EquipmentService } from '../equipment.service';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styleUrls: ['./equipment-list.component.scss']
})
export class EquipmentListComponent implements OnInit {

  items: Array<Equipment>;

  constructor(private service: EquipmentService) {
    this.items = new Array<Equipment>();
  }

  ngOnInit() {
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
