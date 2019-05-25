import { Component, OnInit } from '@angular/core';
import { WorkObject } from '../models/workObject';
import { ActivatedRoute } from '@angular/router';
import { WorkObjectService } from '../work-object.service';

@Component({
  selector: 'app-work-object-edit',
  templateUrl: './work-object-edit.component.html',
  styleUrls: ['./work-object-edit.component.scss']
})
export class WorkObjectEditComponent implements OnInit {

  id: number
  item: WorkObject;

  constructor(private route: ActivatedRoute,
    private service: WorkObjectService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.route.params.subscribe(params => {
      this.id = params['id']
    });
    this.service.getItem(this.id).subscribe((data: WorkObject) => {
      this.item = data;  
    });
  }

  edit(){
    this.service.updateItem(this.item).subscribe((data: WorkObject) => {
      this.loadItem();  
    });
  }

  cancel(){
    this.loadItem();
  }

}
