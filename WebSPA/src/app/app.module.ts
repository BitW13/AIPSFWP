import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EquipmentComponent } from './equipments/equipment/equipment.component';
import { WorkTaskComponent } from './workTasks/work-task/work-task.component';
import { WorkObjectComponent } from './workObjects/work-object/work-object.component';
import { EmployeeAddComponent } from './employees/employee-add/employee-add.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeEditComponent } from './employees/employee-edit/employee-edit.component';
import { EmployeeService } from './employees/employee.service';
import { EquipmentService } from './equipments/equipment.service';
import { EquipmentListComponent } from './equipments/equipment-list/equipment-list.component';
import { EquipmentAddComponent } from './equipments/equipment-add/equipment-add.component';
import { EquipmentEditComponent } from './equipments/equipment-edit/equipment-edit.component';
import { WorkTaskListComponent } from './workTasks/work-task-list/work-task-list.component';
import { WorkTaskEditComponent } from './workTasks/work-task-edit/work-task-edit.component';
import { WorkTaskAddComponent } from './workTasks/work-task-add/work-task-add.component';
import { WorkTaskService } from './workTasks/work-task.service';
import { WorkObjectListComponent } from './workObjects/work-object-list/work-object-list.component';
import { WorkObjectAddComponent } from './workObjects/work-object-add/work-object-add.component';
import { WorkObjectEditComponent } from './workObjects/work-object-edit/work-object-edit.component';
import { WorkObjectDetailsComponent } from './workObjects/work-object-details/work-object-details.component';
import { WorkObjectService } from './workObjects/work-object.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    EmployeeComponent,
    EquipmentComponent,
    WorkTaskComponent,
    WorkObjectComponent,
    EmployeeAddComponent,
    EmployeeListComponent,
    EmployeeEditComponent,
    EquipmentListComponent,
    EquipmentAddComponent,
    EquipmentEditComponent,
    WorkTaskListComponent,
    WorkTaskEditComponent,
    WorkTaskAddComponent,
    WorkObjectListComponent,
    WorkObjectAddComponent,
    WorkObjectEditComponent,
    WorkObjectDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [EmployeeService, EquipmentService, WorkTaskService, WorkObjectService],
  bootstrap: [AppComponent]
})
export class AppModule { }
