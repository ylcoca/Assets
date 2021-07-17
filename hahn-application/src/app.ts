import { UserAsset } from './entities/UserAsset';
import { APIClient } from 'api/apiClient';
import { autoinject } from 'aurelia-dependency-injection';


@autoinject
export class App {
  public userAsset: UserAsset;
  public address: string;
  public address2: string;
  public country: string;
  public state: string;
  public zip: string;

  constructor(private api: APIClient) {
    this.userAsset = new UserAsset();
  }

  submit():void {
    this.setAddress()

    if (this.userAsset.asset) {
      this.userAsset.asset.id = this.userAsset.asset.name.toLowerCase();
      //console.log("UserAsset" + JSON.stringify(this.userAsset));
      this.api.postData(this.userAsset);

     /* const myPostData = {
        id: 101
      }
      this.api.postData(myPostData);*/
    }
  }

  reset():void {
    console.log("Reset");
  }
  setAddress(): void {
    this.userAsset.asset.user.address = this.address + ", " + this.address2 + ", " + this.country + ", " + this.state + ", " + this.zip;
  }
}


