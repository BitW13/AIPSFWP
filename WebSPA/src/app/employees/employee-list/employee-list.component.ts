import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../models/employee';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  workObjectId: number
  items: Array<Employee>;

  constructor(private route: ActivatedRoute,
    private service: EmployeeService) {
    this.items = new Array<Employee>();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.workObjectId = params['id']
    });
    if(this.workObjectId){
      console.log('Список сотрудников на объекте ' + this.workObjectId)
    }
    this.loadItems();
  }

  loadItems(){
    this.service.getItems().subscribe((data: Employee[]) => {
      this.items = data;  
    });
  }

  delete(item: Employee) {
    this.service.deleteItem(item.id).subscribe(data => {
        this.loadItems();
    });
  };
}
