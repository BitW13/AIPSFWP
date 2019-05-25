import { NgModule } from "@angular/core";
import { Routes } from "@angular/router";
import { NSEmptyOutletComponent } from "nativescript-angular";
import { NativeScriptRouterModule } from "nativescript-angular/router";

const routes: Routes = [
    {
        path: "",
        redirectTo: "/(employeesTab:employees/default)",
        pathMatch: "full"
    },

    {
        path: "employees",
        component: NSEmptyOutletComponent,
        loadChildren: "~/app/employees/employees.module#EmployeesModule",
        outlet: "employeesTab"
    }
];

@NgModule({
    imports: [NativeScriptRouterModule.forRoot(routes)],
    exports: [NativeScriptRouterModule]
})
export class AppRoutingModule { }
