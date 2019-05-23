import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  items: Array<Employee>;

  constructor(private service: EmployeeService) {
    this.items = new Array<Employee>();
  }

  ngOnInit() {
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
