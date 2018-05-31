import { Component, Injectable, ViewChild, OnInit, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../../../router.animations';
import { Form, FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { LocalStorageService } from 'angular-2-local-storage';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { MastersService } from '../../../services/app.masters.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ManageUserDialog } from '../../../shared/dialogues/manage/ManageUserDialog';

@Component({
    templateUrl: './manageuser.component.html',
    animations: [routerTransition()],
    providers: [MastersService]
})
export class ManageuserComponent implements OnInit {
    public _ManageUserGridData: any = [];
        //FirstName: '',
        //LastName: '',
        //Mobile: '',
        //Email: '',
        //Role: '',
        //DisplayName: ''
    

    public _UserTypeRole: any = {}

    public _RoleOfUser: {
        Name: '',
        RoleId: '',
        Description: ''
    }

    public _ClientName: {
        FirstName: ''
    }

    public _SelectApplicantId = {
        ApplicantID: ''
    };

    public _GridUser: any = {};
    public _UserRecord: any = {};
    public _Operationtitle: string = "Add";
    public _isClientRole: boolean = false;
    public _EditUser: boolean = false;
    public AddUpdateDetailsClass: boolean = false;
    public isEmailAllreadyExits: boolean = false;
    public ErrorMsg: string = "";
    public IsErrorMsg: boolean = false;
    public emailId: string = '';
    public _UserData: any = {}

    constructor(private _mastersServices: MastersService, private LocalStorageService: LocalStorageService, public dialog: MatDialog) { }

    ngOnInit() {
        this.GetAllUser();
        this.GetRole();
    }

    GetAllUser() {
        this._mastersServices.GetAllUser().subscribe(res => this.GetAllUserSuccess(res), res => this.GetAllUserError(res));
    }

    GetAllUserSuccess(res) {
        this._ManageUserGridData = JSON.parse(res._body);
        this._UserData = this._ManageUserGridData.find(c => c.EmailID === this.emailId);
        console.log(this._UserData)

    }

    GetAllUserError(res) { }

    GetRole() {
        this._mastersServices.GetRole().subscribe(res => this.GetRoleSuccess(res), res => this.GetRoleError(res));
    }

    GetRoleSuccess(res) {
        this._RoleOfUser = JSON.parse(res._body);
    }

    GetRoleError(res) { }

    SelectApplicantName(applicantId) {
        this._EditUser = false;
        this._mastersServices.GetUserDetails(applicantId).subscribe(res => this.GetUserDetailsSuccess(res, ), res => this.GetUserDetailsError(res));

    }

    GetUserDetailsSuccess(res) {
        this._UserRecord = {}
        this._UserRecord = JSON.parse(res._body);
        this._UserRecord = {
            FirstName: this._UserRecord.FirstName,
            LastName: this._UserRecord.LastName,
            DisplayName: this._UserRecord.FirstName + this._UserRecord.LastName,
            EmailID: this._UserRecord.EmailID,
            Password: this._UserRecord.Password,
            Role: 'Client'

        }
    }

    GetUserDetailsError(res) { }

    SelectUserType(role) {
        this._EditUser = false;
        this._UserRecord = {}
        this._UserRecord.Role = role;
        this._Operationtitle = "Add";
        if (role == "Client") {
            this._isClientRole = true;
            this._mastersServices.GetApplicants().subscribe(res => this.GetApplicantsSuccess(res), res => this.GetApplicantsError(res));
        } else {
            this._isClientRole = false;
        }
    }

    GetApplicantsSuccess(res) {
        this._ClientName = JSON.parse(res._body);
    }

    GetApplicantsError(res) { }

    AddUser() {
        this._mastersServices.ValidateEmail(this._UserRecord.EmailID).subscribe(res => this.ValidateEmailSuccess(res), res => this.ValidateEmailError(res))
    }

    ValidateEmailSuccess(res) {
        this.isEmailAllreadyExits = JSON.parse(res._body);
        if (!this.isEmailAllreadyExits) {
            this.IsErrorMsg = false;
            debugger;
            this.LocalStorageService.set('Email', this._UserRecord.EmailID);
            this.emailId = this.LocalStorageService.get('Email');
            this._mastersServices.AddUser(this._UserRecord).subscribe(res => this.AddUserSuccess(res), res => this.AddUserError(res));
        }else {
            this.IsErrorMsg = true
            this.ErrorMsg = "this Email Address already exits.";
        }
    }

    ValidateEmailError(res) { }

    AddUserSuccess(res) {
        console.log(res)
        this.AddUpdateDetailsClass = true;
        this._mastersServices.GetAllUser().subscribe(res => this.GetAllUserSuccess(res), res => this.GetAllUserError(res));
        this.CancelUser();
    }

    AddUserError(res) { }

    CancelUser() {
        this.AddUpdateDetailsClass = true;
        this._Operationtitle = "Add";
        this._UserRecord = {}
        this._UserTypeRole = {}
        this._SelectApplicantId = {
            ApplicantID:''
        }

    }

    ChangePassword(dataItem): void {
        let dialogRef = this.dialog.open(ManageUserDialog, { data: { dataItem } });

        dialogRef.afterClosed().subscribe(result => {
        });
    }

    SwitchStatus(ID) {
        this._mastersServices.SwitchManageUserEntityStatus(ID).subscribe(res => this.SwitchManageUserEntityStatusSuccess(res), res => this.SwitchManageUserEntityStatusError(res));
    }

    SwitchManageUserEntityStatusSuccess(res) {
        this._mastersServices.GetAllUser().subscribe(res => this.GetAllUserSuccess(res), res => this.GetAllUserError(res));
    }

    SwitchManageUserEntityStatusError(res) { }

    GridSelectionChange(data, event) {
        this._UserRecord = {};
        this._isClientRole = false;
        this._Operationtitle = "Update";
        this._EditUser = true;
        this._UserTypeRole = {}
        this._GridUser = this._ManageUserGridData[event.index];
        Object.assign(this._UserRecord, this._GridUser);
    }

    UpdateUser() {
        this._mastersServices.UpdateUserDetails(this._UserRecord).subscribe(res => this.UpdateUserDetailsSuccess(res), res => this.UpdateUserDetailsError(res));
    }

    UpdateUserDetailsSuccess(res) {
        this.AddUpdateDetailsClass = true;
        this._mastersServices.GetAllUser().subscribe(res => this.GetAllUserSuccess(res), res => this.GetAllUserError(res));
        this.CancelUser();
    }

    UpdateUserDetailsError(res) { }
}
