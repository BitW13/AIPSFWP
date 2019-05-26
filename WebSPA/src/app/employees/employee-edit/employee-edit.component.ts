import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  id: number
  item: Employee;

  constructor(private route: ActivatedRoute,
    private service: EmployeeService) { }

  ngOnInit() {
    this.loadItem();
  }

  loadItem(){
    this.route.params.subscribe(params => {
      this.id = params['id']
    });
    this.service.getItem(this.id).subscribe((data: Employee) => {
      this.item = data;  
    });
  }

  edit(){
    this.service.updateItem(this.item).subscribe((data: Employee) => {
      this.loadItem();  
    });
  }

  cancel(){
    this.loadItem();
  }

}
