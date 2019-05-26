import { Component, OnInit } from '@angular/core';
import { Equipment } from '../models/equipment';
import { EquipmentService } from '../equipment.service';

@Component({
  selector: 'app-equipment-add',
  templateUrl: './equipment-add.component.html',
  styleUrls: ['./equipment-add.component.scss']
})
export class EquipmentAddComponent implements OnInit {

  item: Equipment

  constructor(private service: EquipmentService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.item = new Equipment();
  }

  add(){
    this.service.createItem(this.item).subscribe((data: Equipment) => {
      this.loadItem();  
    });
  }

  cancel(){
    this.loadItem();
  }
}
