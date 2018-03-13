import { Component, Injectable, ViewChild, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../../../router.animations';
import { Form, FormControl, FormBuilder, Validators } from '@angular/forms';
import { LocalStorageService } from 'angular-2-local-storage';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { AppBaseComponent } from '../../../shared/app.basecomponent';
import { ClientsService } from '../../../services/app.clients.service';
@Component({
    selector: `applicant-personal-details`,
    templateUrl: './app.applicant.personaldetails.html',
    animations: [routerTransition()],
    providers: [ClientsService]
})
export class ApplicantPersonalDetailsComponent extends AppBaseComponent implements OnInit {

    constructor(public router: Router, private _LocalStorageService: LocalStorageService, private _ClientsService: ClientsService) { super(); }
    ngOnInit() {
    }
    public _ApplicantPersonalDetails = {
        ApplicantID: '',
        FirstName: '',
        MiddleName: '',
        LastName: '',
        Gender: '',
        DateOfBirth: '',
        MaritalStatus: '',
        NoOfDependents: '',
        NZResidents: '',
        CountryOfBirth: '',
        ApplicantTypeID: '',
        EmailID: '',
        MobileNo: '',
        HomePhoneNo: '',
        WorkPhoneNo: '',
        LoanApplicationNo:'',
        ApplicantType: {
            ApplicantTypeID: '',
            ApplicantType: ''
        }
    };


    //   this._LocalStorageService.set("LoanApplicationNoViewed"
    SaveLoanApplicationPersonalDetails() {
        debugger;

        if (this._LocalStorageService.get("LoanApplicationNoViewed") != undefined) {
            this._ApplicantPersonalDetails.ApplicantTypeID = this._ApplicantPersonalDetails.ApplicantType.ApplicantTypeID;

            this._ApplicantPersonalDetails.LoanApplicationNo = this._LocalStorageService.get("LoanApplicationNoViewed");
            return this._ClientsService.SaveLoanApplicationPersonalDetails(this._ApplicantPersonalDetails);
        }
        
    }
}

