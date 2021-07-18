import { DialogController } from 'aurelia-dialog';
import { autoinject, inject } from 'aurelia-framework';
import { UserAsset } from 'entities/UserAsset';

@autoinject

export class SendDialog {
  userAsset: UserAsset;
  message: string;
  constructor(private dialogController: DialogController) {
    dialogController.settings.centerHorizontalOnly = true;
  }

  activate(model: any) {
    
    if (!model.data.asset) {
      
      this.message = model.data.title ? model.data.title : model.data[0].errorMessage;
    } else {
      this.userAsset = model.data;
    }
  }

  ok(): void {
    this.dialogController.close(true);
  }
}
