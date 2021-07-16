import { APIClient } from 'api/apiClient';
import { autoinject } from 'aurelia-dependency-injection';


@autoinject
export class App {
  todoDescription = '';

  constructor(private api: APIClient) {
  
}

  Submit() {
    if (this.todoDescription) {
      console.log("rank:" + this.todoDescription);
      this.api.getData();
    }
  }
  Send() {
    
  }

  Reset() {
    
  }
}
