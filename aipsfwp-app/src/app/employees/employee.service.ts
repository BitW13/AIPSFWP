import { Injectable } from '@angular/core';
import { Employee } from './models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor() { }

  items :Employee[] = [
    { "id":0, "firstName":"Ivan", "middleName":"Stepanovich", "lastName":"Kozlov" },
    { "id":1, "firstName":"Konstantin", "middleName":"Grigorievich", "lastName":"Sneg" },
    { "id":2, "firstName":"Alexandr", "middleName":"Ivanovich", "lastName":"Lox" },
    { "id":3, "firstName":"Vitaly", "middleName":"Viktorovich", "lastName":"Orel" }
  ]

  getItems(){
    return this.items;
  }

  getItem(id: number){
    this.items.forEach(element => {
          if (element.id == id){
              return element;
          }
      });
    return null;
  }

  createItem(item: Employee){
      return this.items.push(item);
  }

  updateItem(item: Employee) {
    this.items.forEach(element => {
        if (element.id == item.id){
            element = item;
        }
    });
  }
  
  deleteItem(id: number){
    this.items.forEach(element => {
        if (element.id == id){
            const index = this.items.indexOf(element, 0);
            if (index > -1) {
                this.items.splice(index, 1);
            }
        }
    });
  }

  getItemsByWorkObjectId(id: number){
    this.items.forEach(element => {
        if (element.workObjectId == id){
            return element;
        }
    });
  return null;
  }
}