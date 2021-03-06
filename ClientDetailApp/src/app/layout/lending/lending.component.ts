import { Component, Injectable, ViewChild, OnInit, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../../router.animations';
import { Form, FormControl, FormBuilder, Validators } from '@angular/forms';
import { LocalStorageService } from 'angular-2-local-storage';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ClientsService } from '../../services/app.clients.service';
import { MastersService } from '../../services/app.masters.service';
declare var jquery: any;
declare var $: any;


export interface Element {
    ApplicationFormNumber: string,
    ClientID: string,
    Term: string,
    Rate: string,
    Frequency: string,
    Status: string,
}


@Component({
    templateUrl: './lending.component.html',
    animations: [routerTransition()],
    providers: [ClientsService, MastersService]
})
export class LendingComponent {
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    public _EditDetails: boolean = false;
    public ApplicantID: string = '';
    items: any;

    public GetStatusType: any = [];
    public GetLoanRateType: any = [];
    public GetPropertyType: any = [];
    public GetLoanType: any = [];

    public displayedColumns = ['ApplicationFormNumber', 'Client Id', 'Term', 'Rate', 'Frequency','Status'];
    public dataSource: any;
    public LendingDetails = {
        AutoID: '',
        LANNumber: '',
        LoanApplicationNo: '',
        ApplicationFormNumber: '',
        ROIOffered: '',
        LoanTermOffered: '',
        RateTypeOffered: '',
        FrequencyOffered: '',
        LoanValueRatio: '',
        LoanAmountOffered: '',
        LoanTypeID: '',
        ClientID: '',
        StatusID: '',
        EMIStartDay: '',
        EMIStartMonth: '',
        LoanProcessingFee: '',
        AnyLegalCharges: '',
        NoOfEMI: '',
        Loanprovider: '',
        PropertyCost: '',
        PropertyTypeID: '',
        FinanceDate: '',
        SettlementDate: '',
        PropertyType: '',
        LoanType: '',
        Status: ''
    };

    constructor(public router: Router, private _LocalStorageService: LocalStorageService, private _ClientsService: ClientsService, public dialog: MatDialog, private _MastersService: MastersService) {
        debugger;
        this.ApplicantID = this._LocalStorageService.get("LoggedInApplicantId");
        this._ClientsService.GetMatLendingDetailsByAppID(this.ApplicantID)
            .subscribe(res => this.GetMatLendingDetailsByAppIDSuccess(res), res => this.GetMatLendingDetailsByAppIDError(res));
    }

    ngOnInit() {
        debugger;
        this.LendingDetails = {
            AutoID: '',
            LANNumber: '',
            LoanApplicationNo: '',
            ApplicationFormNumber: '',
            ROIOffered: '',
            LoanTermOffered: '',
            RateTypeOffered: '',
            FrequencyOffered: '',
            LoanValueRatio: '',
            LoanAmountOffered: '',
            LoanTypeID: '',
            ClientID: '',
            StatusID: '',
            EMIStartDay: '',
            EMIStartMonth: '',
            LoanProcessingFee: '',
            AnyLegalCharges: '',
            NoOfEMI: '',
            Loanprovider: '',
            PropertyCost: '',
            PropertyTypeID: '',
            FinanceDate: '',
            SettlementDate: '',
            PropertyType: '',
            LoanType: '',
            Status: ''
        };
        debugger;
        this.GetLendingDetails();
        this._ClientsService.GetLendingDetailsByAppID(this.ApplicantID).subscribe(res => this.GetLendingDetailsByAppIDSuccess(res), res => this.GetLendingDetailsByAppIDError(res));
        this._MastersService.GetStatusTypes().subscribe(res => this.GetStatusTypesSuccess(res), res => this.GetStatusTypesError(res));
        this.GetLoanrateTypes()
        this.GetPropertyTypes()
        this.GetLoanTypes()
        $(document).ready(function () {
            $(".content-section").parent().parent().parent().parent().parent().css("background", "#ffffff");
        });
    }
    GetLoanrateTypes() {
        this._MastersService.GetLoanrateTypes().subscribe(res => this.GetLoanrateTypesSuccess(res), res => this.GetLoanrateTypesError(res));

    }

    GetLoanrateTypesSuccess(res) {
        if (JSON.parse(res._body) != null || JSON.parse(res._body) != undefined) {
            this.GetLoanRateType = JSON.parse(res._body)
        }
    }

    GetLoanrateTypesError(res) {

    }

    GetPropertyTypes() {
        this._MastersService.GetPropertyTypes().subscribe(res => this.GetPropertyTypesSuccess(res), res => this.GetPropertyTypesError(res));

    }

    GetPropertyTypesSuccess(res) {
        if (JSON.parse(res._body) != null || JSON.parse(res._body) != undefined) {
            this.GetPropertyType = JSON.parse(res._body)
        }

    }

    GetPropertyTypesError(res) { }

    GetLoanTypes() {
        this._MastersService.GetLoanTypes().subscribe(res => this.GetLoanTypesSuccess(res), res => this.GetLoanTypesError(res));
    }

    GetLoanTypesSuccess(res) {
        if (JSON.parse(res._body) != null || JSON.parse(res._body) != undefined) {
            this.GetLoanType = JSON.parse(res._body)
            console.log(this.GetLoanType)
        }
    }

    GetLoanTypesError(res) {}


    GetStatusTypesSuccess(res) {
        if (JSON.parse(res._body) != null || JSON.parse(res._body) != undefined) {
            this.GetStatusType = JSON.parse(res._body);
        }
    }

    GetStatusTypesError(res) {

    }


    GetLendingDetails() {
        this.ApplicantID = this._LocalStorageService.get("LoggedInApplicantId");
    }

    GetMatLendingDetailsByAppIDSuccess(res) {
        debugger;
        this.dataSource = new MatTableDataSource<Element>(JSON.parse(res._body));
        this.dataSource.paginator = this.paginator;
    }
    GetMatLendingDetailsByAppIDError(res) { }

    GetLendingDetailsByAppIDSuccess(res) {
        debugger;
        if (JSON.parse(res._body) != null || JSON.parse(res._body) != undefined) {

            this.LendingDetails = JSON.parse(res._body);
        }
    }
    GetLendingDetailsByAppIDError(res) {
    }

    UpdateDetails() {
        debugger;
        this._ClientsService.UpdateLendingDetailsByAppID(this.LendingDetails).subscribe(res => this.UpdateLendingDetailsByAppIDSuccess(res), res => this.UpdateLendingDetailsByAppIDError(res));
    }
    UpdateLendingDetailsByAppIDSuccess(res) {
        this._EditDetails = false;
        //this._ClientsService.GetLendingDetailsByAppID(this.ApplicantID).subscribe(res => this.GetLendingDetailsByAppIDSuccess(res), res => this.GetLendingDetailsByAppIDError(res));
        this._ClientsService.GetMatLendingDetailsByAppID(this.ApplicantID)
            .subscribe(res => this.GetMatLendingDetailsByAppIDSuccess(res), res => this.GetMatLendingDetailsByAppIDError(res));

    }
    UpdateLendingDetailsByAppIDError(res) { }

    ViewDetails(LANNumber) {
        debugger;
        this._ClientsService.ViewLendingDetailsByAppID(LANNumber).subscribe(res => this.ViewLendingDetailsByAppIDSuccess(res), res => this.ViewLendingDetailsByAppIDError(res));
    }
    ViewLendingDetailsByAppIDSuccess(res) {
        this._EditDetails = false;
        this.LendingDetails = JSON.parse(res._body);
    }
    ViewLendingDetailsByAppIDError(res) { }

    CancelEditingDetails() {
        this._EditDetails = false;
        this._ClientsService.GetLendingDetailsByAppID(this.ApplicantID).subscribe(res => this.GetLendingDetailsByAppIDSuccess(res), res => this.GetLendingDetailsByAppIDError(res));
        this.router.navigate(['/lending']);
    }

    EditDetails() { this._EditDetails = true; }
}

