import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from './models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private url = "https://aipsfwpwebapi20190523120052.azurewebsites.net/api/employee/";
  
  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get(this.url);
  }

  getItem(id: number){
    return this.http.get(this.url + id);
  }

  createItem(item: Employee){
      return this.http.post(this.url, item); 
  }

  updateItem(item: Employee) {
    return this.http.put(this.url + item.id, item);
  }
  
  deleteItem(id: number){
    return this.http.delete(this.url + id);
  }

  getItemsByWorkObjectId(id: number){
    return this.http.get(this.url + '/byworkobjectid/' + id);
  }
}
