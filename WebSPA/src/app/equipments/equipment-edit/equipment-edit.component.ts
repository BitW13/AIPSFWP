import { Component, OnInit } from '@angular/core';
import { Equipment } from '../models/equipment';
import { ActivatedRoute } from '@angular/router';
import { EquipmentService } from '../equipment.service';

@Component({
  selector: 'app-equipment-edit',
  templateUrl: './equipment-edit.component.html',
  styleUrls: ['./equipment-edit.component.scss']
})
export class EquipmentEditComponent implements OnInit {

  id: number
  item: Equipment;

  constructor(private route: ActivatedRoute,
    private service: EquipmentService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.route.params.subscribe(params => {
      this.id = params['id']
    });
    this.service.getItem(this.item.id).subscribe((data: Equipment) => {
      this.item = data;  
    });
  }

  edit(){
    this.service.updateItem(this.item);
    this.loadItem();
  }

  cancel(){
    this.loadItem();
  }

}
