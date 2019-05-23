import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WorkTask } from './models/workTask';

@Injectable({
  providedIn: 'root'
})
export class WorkTaskService {

  private url = "http://localhost:64345/api/employees/";
  
  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get(this.url);
  }

  getItem(id: number){
    return this.http.get(this.url + id);
  }

  createItem(item: WorkTask){
      return this.http.post(this.url, item); 
  }

  updateItem(item: WorkTask) {
    return this.http.put(this.url + item.id, item);
  }
  
  deleteItem(id: number){
    return this.http.delete(this.url + id);
  }
}
