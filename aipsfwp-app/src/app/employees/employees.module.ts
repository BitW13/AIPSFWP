import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptCommonModule } from "nativescript-angular/common";

import { EmployeesRoutingModule } from "./employees-routing.module";
import { EmployeesComponent } from "./employees.component";

@NgModule({
    imports: [
        NativeScriptCommonModule,
        EmployeesRoutingModule
    ],
    declarations: [
        EmployeesComponent
    ],
    schemas: [
        NO_ERRORS_SCHEMA
    ]
})
export class EmployeesModule { }
