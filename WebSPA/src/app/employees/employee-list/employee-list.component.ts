import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../models/employee';
import { ActivatedRoute } from '@angular/router';
import { WorkObjectService } from 'src/app/workObjects/work-object.service';
import { WorkObject } from 'src/app/workObjects/models/workObject';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  workObjectId: number;
  items: Array<Employee>;
  hasWorkObjecId: boolean; 
  
  list: Array<Employee>;

  constructor(private route: ActivatedRoute,
    private service: EmployeeService) {
    this.items = new Array<Employee>();
    this.list = new Array<Employee>();
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
      this.service.getItemsByWorkObjectId(this.workObjectId).subscribe((data: Employee[]) => {
        this.items = data;  
      });
      this.service.getItems().subscribe((data: Employee[]) => {
        this.list = data;  
      });
    }
    else{
      this.service.getItems().subscribe((data: Employee[]) => {
        this.items = data;  
      });
    }
  }

  delete(item: Employee) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };
}
