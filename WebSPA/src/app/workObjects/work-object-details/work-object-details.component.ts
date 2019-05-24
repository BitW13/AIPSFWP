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
  editedEmployee: Employee;
  isNewEmployee: boolean;

  @ViewChild('equipmentRead') equipmentRead: TemplateRef<any>;
  @ViewChild('equipmentEdit') equipmentEdit: TemplateRef<any>;
  listOfEquipments: Array<Equipment>;
  editedEquipment: Equipment;
  isNewEquipment: boolean;

  @ViewChild('workTaskRead') workTaskRead: TemplateRef<any>;
  @ViewChild('workTaskEdit') workTaskEdit: TemplateRef<any>;
  listofWorkTasks: Array<WorkTask>;
  editedWorkTask: WorkTask;
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
    if (this.editedEmployee && this.editedEmployee.id == employee.id) {
        return this.editedEmployee;
    } else {
        return this.employeeEdit;
    }
  }
  loadEquipmentTemplate(equipment: Equipment) {
    if (this.editedEquipment && this.editedEquipment.id == equipment.id) {
        return this.editedEquipment;
    } else {
        return this.equipmentEdit;
    }
  }
  loadTemplate(workTask: WorkTask) {
    if (this.editedWorkTask && this.editedWorkTask.id == workTask.id) {
        return this.editWorkTask;
    } else {
        return this.workTaskEdit;
    }
  }

  addEmployee(){
    this.editedEmployee = new Equipment();
    this.listOfEmployees.push(this.editedEmployee);
    this.isNewEmployee = true;
  }

  addEquipment(){
    this.editedEquipment = new Equipment();
    this.listOfEquipments.push(this.editedEquipment);
    this.isNewEquipment = true;
  }
  addWorkTask(){
    this.editedWorkTask = new WorkTask();
    this.listofWorkTasks.push(this.editedWorkTask);
    this.isNewWorkTask = true;
  }

  editEmployee(employee: Employee){
    this.editedEmployee = employee;
  }
  editEquipment(equipment: Equipment){
    this.editedEquipment = equipment;
  }
  editWorkTask(workTask: WorkTask){
    this.editedWorkTask = workTask;
  }

  saveEmployee(){
    if(this.isNewEmployee) {
      this.serviceOfEmployees.createItem(this.editedEmployee).subscribe(data => {
        this.loadItems();
      });
      this.isNewEmployee = false;
      this.editedEmployee = null;
    } else {
      this.serviceOfEmployees.updateItem(this.editedEmployee).subscribe(data => {
        this.loadItems();
      });
      this.editedEmployee = null;
    }
  }
  saveEquipment(){
    if(this.isNewEquipment) {
      this.serviceOfEquipments.createItem(this.editedEquipment).subscribe(data => {
        this.loadItems();
      });
      this.isNewEquipment = false;
      this.editedEquipment = null;
    } else {
      this.serviceOfEquipments.updateItem(this.editedEquipment).subscribe(data => {
        this.loadItems();
      });
      this.editedEquipment = null;
    }
  }
  saveWorkTask(){
    if(this.isNewWorkTask) {
      this.serviceOfWorkTasks.createItem(this.editedWorkTask).subscribe(data => {
        this.loadItems();
      });
      this.isNewWorkTask = false;
      this.editedWorkTask = null;
    } else {
      this.serviceOfWorkTasks.updateItem(this.editedWorkTask).subscribe(data => {
        this.loadItems();
      });
      this.editedWorkTask = null;
    }
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
