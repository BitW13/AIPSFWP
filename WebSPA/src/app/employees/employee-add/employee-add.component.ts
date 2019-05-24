import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.scss']
})
export class EmployeeAddComponent implements OnInit {

  item: Employee

  constructor(private service: EmployeeService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.item = new Employee();
  }

  add(){
    this.service.createItem(this.item).subscribe((data: Employee) => {
      this.loadItem();  
    });
  }

  cancel(){
    this.loadItem();
  }
}
