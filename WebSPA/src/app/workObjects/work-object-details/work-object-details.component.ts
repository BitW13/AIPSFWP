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
    private serviceOfEmployees: EmployeeService,
    private serviceOfEquipments: EquipmentService,
    private serviceOfWorkTasks: WorkTaskService) { 
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
    this.serviceOfEmployees.getItemsByWorkObjectId(this.workObjectId).subscribe((data: Employee[]) => {
      this.listOfEmployees = data;  
    });
    this.serviceOfEquipments.getItemsByWorkObjectId(this.workObjectId).subscribe((data: Equipment[]) => {
      this.listOfEquipments = data;  
    });
    this.serviceOfWorkTasks.getItemsByWorkObjectId(this.workObjectId).subscribe((data: WorkTask[]) => {
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

  cancelEmployee() {
    if (this.isNewEmployee) {
        this.listOfEmployees.pop();
        this.isNewEmployee = false;
    }
    this.editEmployee = null;
  }
  cancelEquipment() {
    if (this.isNewEquipment) {
        this.listOfEquipments.pop();
        this.isNewEquipment = false;
    }
    this.editEquipment = null;
  }
  cancelWorkTask() {
    if (this.isNewWorkTask) {
        this.listofWorkTasks.pop();
        this.isNewWorkTask = false;
    }
    this.editWorkTask = null;
  }

  deleteEmployee(employee: Employee) {
    this.serviceOfEmployees.deleteItem(employee.id).subscribe(data => {
        this.loadItems();
    });
  }
  deleteEquipment(equipment: Equipment) {
    this.serviceOfEquipments.deleteItem(equipment.id).subscribe(data => {
        this.loadItems();
    });
  }
  deleteWorkTask(workTask: WorkTask) {
    this.serviceOfWorkTasks.deleteItem(workTask.id).subscribe(data => {
        this.loadItems();
    });
  }
}
