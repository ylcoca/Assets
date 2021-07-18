import { DialogController } from 'aurelia-dialog';
import { autoinject, inject } from 'aurelia-framework';
import { UserAsset } from 'entities/UserAsset';

@autoinject

export class Dialog {
  title?: string;
  message?: string;
  resetAction?: (args?: any) => {};
  userAsset: UserAsset;

  constructor(private dialogController: DialogController) {
    dialogController.settings.centerHorizontalOnly = true;
  }

  activate(model: any) {
    this.message = model.message;
    this.title = model.title;
    this.resetAction = model.resetAction;
    this.userAsset = model.userAsset;
  }

  ok(): void {
    this.resetAction(this.userAsset);
    this.dialogController.ok();
    this.dialogController.close(true);
  }

  cancel(): void {
    this.dialogController.close(true);
  }
}
