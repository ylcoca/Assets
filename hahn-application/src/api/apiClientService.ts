import { UserAsset } from '../entities/UserAsset';

import { HttpClient} from 'aurelia-fetch-client';

const httpClient = new HttpClient();
const endpoint = 'http://localhost:51885/api/UserAsset';
/*
httpClient.configure(config => {
  config
    .withBaseUrl('/')
    .withDefaults({
      credentials: 'same-origin',
      headers: {
        'Accept': 'application/json',
        'X-Requested-With': 'Fetch',
        "Access-Control-Allow-Headers": "*"
      }
    })
    .withInterceptor({
      request(request) {
        console.log(`Requesting ${request.method} ${request.url}`);
        return request;
      },
      response(response) {
        console.log(`Received ${response.status} ${response.url}`);
        return response;
      }
    });
});*/
export class APIClient {

  getUserAssetData(id: number): void {
    httpClient.fetch(endpoint + '/' + id)
      .then(response => response.json())
      .then(data => {
        console.log(data);
      });
  }
  postData(userAsset: UserAsset){
    return httpClient.fetch(endpoint, {
      method: "POST",
      body: JSON.stringify(userAsset)
    })
  }

  getAssetNameData(){
    return httpClient.fetch("https://api.coincap.io/v2/assets")
    
  }


 /*  myPostData = {
     id: 101
   }
   postData(myPostData):void {
     httpClient.fetch('http://jsonplaceholder.typicode.com/posts', {
       method: "POST",
       body: JSON.stringify(myPostData)
     })
 
       .then(response => response.json())
       .then(data => {
         console.log(data);
       });
   }
  myUpdateData = {
    id: 1
  }
  updateData(myUpdateData) {
    httpClient.fetch('http://jsonplaceholder.typicode.com/posts/1', {
      method: "PUT",
      body: JSON.stringify(myUpdateData)
    })

      .then(response => response.json())
      .then(data => {
        console.log(data);
      });
  }
  deleteData() {
    httpClient.fetch('http://jsonplaceholder.typicode.com/posts/1', {
      method: "DELETE"
    })
      .then(response => response.json())
      .then(data => {
        console.log(data);
      });
  }*/
}
