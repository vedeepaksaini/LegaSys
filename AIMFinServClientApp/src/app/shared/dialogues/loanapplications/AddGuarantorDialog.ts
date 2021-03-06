import { Component, Inject, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { routerTransition } from '../../../router.animations';
import { Form, FormControl, FormBuilder, Validators } from '@angular/forms';
import { LocalStorageService } from 'angular-2-local-storage';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { AppBaseComponent } from '../../../shared/app.basecomponent';
import { ClientsService } from '../../../services/app.clients.service';
import { MastersService } from '../../../services//app.masters.service';
import { NgForm } from '@angular/forms';
@Component({
    templateUrl: './AddGuarantorDialog.html',
    providers: [ClientsService, MastersService]
})
export class AddGuarantorDialog {
    @ViewChild("AddGuarantorform")
    AddGuarantorform: NgForm;

    constructor(
        public dialogRef: MatDialogRef<AddGuarantorDialog>,
        @Inject(MAT_DIALOG_DATA) public data: any, private _ClientsService: ClientsService, public dialog: MatDialog, private _MasterService: MastersService, private _LocalStorageService: LocalStorageService, ) { }

    public gridData: any[];
    public _EditViewDetails: boolean = false;
    public _AddGuarantor: boolean = true;
    public _ViewDetails: boolean = false;
    public LoanApplicationNo: string = '';
    public _ValidationClass: boolean = false;

    public _AddGuarantorDetails = {
        GuarantorID: '',
        Title: '',
        FirstName: '',
        MiddleName: '',
        LastName: '',
        Gender: '',
        DateOfBirth: '',
        MaritalStatus: '',
        NZResidents: true,
        DNZResidents: '',
        CountryOfBirth: '',
        EmailID: '',
        MobileNo: '',
        HomePhoneNo: '',
        WorkPhoneNo: '',
        Duration: '',
        AddressLine1: '',
        AddressLine2: '',
        AddressLine3: '',
        Country: '',
        ZipCode: '',
        LoanApplicationNo: '',
        _LoanApplicationFormDetails: {
            LoanApplicationNo: ''
        }
    };

    public FormatNZResidents() {
        if (this._AddGuarantorDetails.NZResidents.toString() == "1")
        {
            this._AddGuarantorDetails.NZResidents = true;
        }
        else
        {
            this._AddGuarantorDetails.NZResidents = false;
        }
        this._ValidationClass = true;
    }

    ngOnInit()
    {
        debugger;
        if (this._LocalStorageService.get("LoanApplicationNo") != undefined) {
            this.LoanApplicationNo = this._LocalStorageService.get("LoanApplicationNo");
            this.GetGuarantorGrid();
        }
    }

    AddGuarantor()
    {
        debugger;
        if (this._LocalStorageService.get("LoanApplicationNo") != undefined) {
            this._AddGuarantorDetails.LoanApplicationNo = this._LocalStorageService.get("LoanApplicationNo");
            this._ClientsService.AddGuarantor(this._AddGuarantorDetails).subscribe(res => this.AddGuarantorSuccess(res), res => this.AddGuarantorError(res));
        }
    }
    AddGuarantorSuccess(res)
    {
        debugger;
        this._AddGuarantorDetails = JSON.parse(res._body);
        this._AddGuarantorDetails = {
            GuarantorID: '',
            Title: '',
            FirstName: '',
            MiddleName: '',
            LastName: '',
            Gender: '',
            DateOfBirth: '',
            MaritalStatus: '',
            NZResidents: true,
            DNZResidents: '',
            CountryOfBirth: '',
            EmailID: '',
            MobileNo: '',
            HomePhoneNo: '',
            WorkPhoneNo: '',
            Duration: '',
            AddressLine1: '',
            AddressLine2: '',
            AddressLine3: '',
            Country: '',
            ZipCode: '',
            LoanApplicationNo: '',
            _LoanApplicationFormDetails: {
                LoanApplicationNo: ''
            }
        };
        this.GetGuarantorGrid();
        this._ValidationClass = true;  
    }
    AddGuarantorError(res) { }

    GetGuarantorGrid()
    {
        debugger;
        this._ClientsService.GetAddedGuarantorGrid(this.LoanApplicationNo).subscribe(res => this.GetAddedGuarantorGridSuccess(res), res => this.GetAddedGuarantorGridError(res));
    }
    GetAddedGuarantorGridSuccess(res)
    {
        if (res._body != null || res._body != undefined || res._body.toString().trim().length > 0) {
            this.gridData = JSON.parse(res._body);
        }
    }
    GetAddedGuarantorGridError(res) { }

    ViewDetails(GuarantorID) {
      
        this._ViewDetails = true;
        this._AddGuarantor = false;
        this._EditViewDetails = false;
        this._LocalStorageService.set("GuarantorIDNoViewed", GuarantorID);
       this._ClientsService.GetGuarantorDetails(GuarantorID).subscribe(res => this.ViewDetailsSuccess(res), res => this.ViewDetailsError(res));
    }
    ViewDetailsSuccess(res) {
     
        this._AddGuarantorDetails = JSON.parse(res._body);
        if (this._AddGuarantorDetails.NZResidents == true) {
            this._AddGuarantorDetails.DNZResidents = "Yes";
        }
        else {
            this._AddGuarantorDetails.DNZResidents = "No";
        }
        this._ValidationClass = true;
    }
    ViewDetailsError(res) { }

    UpdateGuarantorDetails() {
        this.FormatNZResidents();
        this._ClientsService.UpdateGuarantorDetails(this._AddGuarantorDetails).subscribe(res => this.UpdateGuarantorDetailsSuccess(res), res => this.UpdateGuarantorDetailsError(res));
    }
    UpdateGuarantorDetailsSuccess(res) {
        this.FormatNZResidents();
        this._AddGuarantor = true;
        this.AddGuarantorform.reset();
        this._EditViewDetails = false;
        this._ViewDetails = false;
        this._ClientsService.GetAddedGuarantorGrid(this.LoanApplicationNo).subscribe(res => this.GetAddedGuarantorGridSuccess(res), res => this.GetAddedGuarantorGridError(res));
        this._ValidationClass = true;
    }
    UpdateGuarantorDetailsError(res) { }

    EditDetails() {
        this._ViewDetails = false;
        this._EditViewDetails = true;
    }
 
    onNoClick(): void {
        console.log("jiii")
        this.dialogRef.close();
    }
}
