import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeEditComponent } from './employees/employee-edit/employee-edit.component';
import { EquipmentListComponent } from './equipments/equipment-list/equipment-list.component';
import { EquipmentEditComponent } from './equipments/equipment-edit/equipment-edit.component';
import { EquipmentComponent } from './equipments/equipment/equipment.component';
import { WorkObjectComponent } from './workObjects/work-object/work-object.component';
import { WorkObjectListComponent } from './workObjects/work-object-list/work-object-list.component';
import { WorkObjectEditComponent } from './workObjects/work-object-edit/work-object-edit.component';
import { WorkObjectDetailsComponent } from './workObjects/work-object-details/work-object-details.component';
import { WorkTaskComponent } from './workTasks/work-task/work-task.component';
import { WorkTaskListComponent } from './workTasks/work-task-list/work-task-list.component';
import { WorkTaskEditComponent } from './workTasks/work-task-edit/work-task-edit.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'employees',
    component: EmployeeComponent,
    children:[
      {
        path: 'employee-list',
        component: EmployeeListComponent
      },
      {
        path: 'employee-edit/:id',
        component: EmployeeEditComponent
      }
    ]
  },
  {
    path: 'equipments',
    component: EquipmentComponent,
    children:[
      {
        path: 'equipment-list',
        component: EquipmentListComponent
      },
      {
        path: 'equipment-edit/:id',
        component: EquipmentEditComponent
      }
    ]
  },
  {
    path: 'workObjects',
    component: WorkObjectComponent,
    children: [
      {
        path: 'work-object-list',
        component: WorkObjectListComponent
      },
      {
        path: 'work-object-edit/:id',
        component: WorkObjectEditComponent
      },
      {
        path: 'work-object-details/:id',
        component: WorkObjectDetailsComponent,
        children: [
          {
            path: 'workTasks',
            component: WorkTaskComponent,
            children:[
              {
                path: 'workTask-list',
                component: WorkTaskListComponent
              },
              {
                path: 'workTask-edit/:id',
                component: WorkTaskEditComponent
              }
            ]
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
