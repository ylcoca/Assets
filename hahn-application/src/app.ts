import { UserAsset } from './entities/UserAsset';
import { APIClient } from 'api/apiClientService';
import { DialogService } from 'aurelia-dialog';

import { autoinject } from "aurelia-framework";
import { Dialog } from 'components/modal/resetDialog';
import { SendDialog } from 'components/modal/sendDialog';

@autoinject
export class App {
  public userAsset: UserAsset;
  public address: string;
  public address2: string;
  public country: string;
  public state: string;
  public zip: string;

  _dialogService: DialogService


  constructor(private dialogService: DialogService, private api: APIClient) { }
  attached(): void {
    this.userAsset = new UserAsset();
    this._dialogService = this.dialogService;
  }

  submit(): void {
    this.setAddress()
    if (this.userAsset.asset) {
     // this.userAsset.asset.id = this.userAsset.asset.name.toLowerCase();
     
      this.api.postData(this.userAsset)
      .then(response => response.json())
      .then(data => {
        //console.log(data);
        this.dialogService.open({
          viewModel: SendDialog,
          model: {
            data
          }
        }).then(response => {
          console.log(response);
        });
      });
    }
  }

  reset(): void {
    const userAsset = this.userAsset;
    this.dialogService.open({
      viewModel: Dialog,
      model: {
        message: 'Are you sure you want to reset?',
        title: 'Reset',
        resetAction: this.resetAction,
        userAsset
      }
    }).then(response => {
      console.log(response);
    });
  }

  resetAction(userAsset:UserAsset): void {
    //reset all fields
    
    this.userAsset = userAsset;
    this.userAsset.asset.rank = null;
    this.userAsset.asset.name = "";
    this.userAsset.asset.supply = null;
    this.userAsset.asset.maxSupply = null;
    this.userAsset.asset.marketCapUsd = null;
    this.userAsset.asset.volumeUsd24Hr = null;
    this.userAsset.asset.priceUsd = null;
    this.userAsset.asset.user.firstName = null;
    this.userAsset.asset.user.lastName = null;
    this.userAsset.asset.user.age = null;
    this.userAsset.asset.user.email = null;
    this.userAsset.asset.user.address = null;
    this.address2 = null;
    this.country = null;
    this.state = null;
    this.zip = null;
  }

  setAddress(): void {
    this.userAsset.asset.user.address = this.address + ", " + this.address2 + ", " + this.country + ", " + this.state + ", " + this.zip;
  }
}

