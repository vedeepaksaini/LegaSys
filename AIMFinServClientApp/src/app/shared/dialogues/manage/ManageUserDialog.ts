import { Component, Inject, OnInit, AfterViewInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MastersService } from '../../../services/app.masters.service';
import { GoogleService } from '../../../services/app.googleservices.service';

@Component({
    templateUrl: './ManageUserDialog.component.html',
    providers: [MastersService, GoogleService]
})
export class ManageUserDialog {
    public _UserPassword: any = {};
    public errorMsg: string = ''
    public isErrorMsg: Boolean = false;
    public errorMessage: string = '';
    public _updatePassword:any= {
        UserGuid: '',
        Password:''
    }

    constructor(
       
        public dialogRef: MatDialogRef<ManageUserDialog>,
        @Inject(MAT_DIALOG_DATA) public data: any, private _mastersServices: MastersService,private _GoogleService: GoogleService) { }

    onNoClick(): void {
        this.dialogRef.close();
       
    }

    SavePassword() {
        this.errorMsg = ''
        if (this._UserPassword.currentPassword == this.data.dataItem.Password) {
            if (this._UserPassword.newPassword == this._UserPassword.confirmPassword) {
                this.isErrorMsg = false;
                this._updatePassword.Password = this._UserPassword.newPassword
                this._updatePassword.UserGuid = this.data.dataItem.UserGuid;
                this._mastersServices.UpdatePassword(this._updatePassword).subscribe(res => this.UpdatePasswordSuccess(res), res => this.UpdatePasswordError(res));
            }else {
                this.isErrorMsg = true
                this.errorMsg = "password does not match the confirm password"
            }
        }else if (this._UserPassword.currentPassword !== this.data.dataItem.Password) {
            this.isErrorMsg = true;
            this.errorMsg = "your current password is not correct"
        }else{
            this.isErrorMsg = false;
            this.errorMsg = "";
        }
    }

    UpdatePasswordSuccess(res) {
        debugger;
        this._mastersServices.GetUpdatedPassword(this._updatePassword.UserGuid).subscribe(res => this.GetUpdatedPasswordSuccess(res), res => this.GetUpdatedPasswordError(res))
        this._GoogleService.GeneratePasswordTemplate(this._updatePassword.UserGuid).subscribe(res => this.GeneratePasswordTemplateSuccess(res), error => this.errorMessage = <any>error);
    }
    GeneratePasswordTemplateSuccess(res) { }

    UpdatePasswordError(res) { }

    GetUpdatedPasswordSuccess(res) {
        this.data.dataItem.Password = JSON.parse(res._body)[0].Password
        this.onNoClick();
    }

    GetUpdatedPasswordError(res) { }
}
