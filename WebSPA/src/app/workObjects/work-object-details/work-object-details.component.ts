import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { EmployeeService } from 'src/app/employees/employee.service';
import { EquipmentService } from 'src/app/equipments/equipment.service';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/employees/models/employee';
import { Equipment } from 'src/app/equipments/models/equipment';
import { WorkTaskService } from 'src/app/workTasks/work-task.service';
import { WorkTask } from 'src/app/workTasks/models/workTask';

@Component({
  selector: 'app-work-object-details',
  templateUrl: './work-object-details.component.html',
  styleUrls: ['./work-object-details.component.scss']
})
export class WorkObjectDetailsComponent implements OnInit {

  workObjectId: number;
  
  @ViewChild('employeeRead') employeeRead: TemplateRef<any>;
  @ViewChild('employeeEdit') employeeEdit: TemplateRef<any>;
  listOfEmployees: Array<Employee>;
  editEmployee: Employee;
  isNewEmployee: boolean;

  @ViewChild('equipmentRead') equipmentRead: TemplateRef<any>;
  @ViewChild('equipmentEdit') equipmentEdit: TemplateRef<any>;
  listOfEquipments: Array<Equipment>;
  editEquipment: Equipment;
  isNewEquipment: boolean;

  @ViewChild('workTaskRead') workTaskRead: TemplateRef<any>;
  @ViewChild('workTaskEdit') workTaskEdit: TemplateRef<any>;
  listofWorkTasks: Array<WorkTask>;
  editWorkTask: WorkTask;
  isNewWorkTask: boolean;

  constructor(private route: ActivatedRoute,
    private serviceOfEmployee: EmployeeService,
    private serviceOfEquipment: EquipmentService,
    private serviceOfWorkTask: WorkTaskService) { 
      this.listOfEmployees = new Array<Employee>();
      this.listOfEquipments = new Array<Equipment>();
      this.listofWorkTasks = new Array<WorkTask>();
  }

  ngOnInit() {
    this.loadItems();
  }

  loadItems(){
    this.route.params.subscribe(params => {
      this.workObjectId = params['id']
    });
    this.serviceOfEmployee.getItemsByWorkObjectId(this.workObjectId).subscribe((data: Employee[]) => {
      this.listOfEmployees = data;  
    });
    this.serviceOfEquipment.getItemsByWorkObjectId(this.workObjectId).subscribe((data: Equipment[]) => {
      this.listOfEquipments = data;  
    });
    this.serviceOfWorkTask.getItemsByWorkObjectId(this.workObjectId).subscribe((data: WorkTask[]) => {
      this.listofWorkTasks = data;  
    });
  }

  loadEmployeeTemplate(employee: Employee) {
    if (this.editEmployee && this.editEmployee.id == employee.id) {
        return this.editEmployee;
    } else {
        return this.employeeEdit;
    }
  }
  loadEquipmentTemplate(equipment: Equipment) {
    if (this.editEquipment && this.editEquipment.id == equipment.id) {
        return this.editEquipment;
    } else {
        return this.equipmentEdit;
    }
  }
  loadTemplate(workTask: WorkTask) {
    if (this.editWorkTask && this.editWorkTask.id == workTask.id) {
        return this.editWorkTask;
    } else {
        return this.workTaskEdit;
    }
  }

  addEmployee(){
    this.editEmployee = new Equipment();
    this.listOfEmployees.push(this.editEmployee);
    this.isNewEmployee = true;
  }

  addEquipment(){
    this.editEquipment = new Equipment();
    this.listOfEquipments.push(this.editEquipment);
    this.isNewEquipment = true;
  }
  addWorkTask(){
    this.editWorkTask = new WorkTask();
    this.listofWorkTasks.push(this.editWorkTask);
    this.isNewWorkTask = true;
  }
}
