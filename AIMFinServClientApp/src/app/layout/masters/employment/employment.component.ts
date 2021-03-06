import { Component, Injectable, ViewChild, OnInit, ElementRef  } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../../../router.animations';
import { Form, FormControl, FormBuilder, Validators  } from '@angular/forms';
import { LocalStorageService } from 'angular-2-local-storage';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import {MastersService} from '../../../services/app.masters.service';

@Component({
    templateUrl: './employment.component.html',
    animations: [routerTransition()],
    providers: [MastersService]
})
export class EmploymentComponent implements OnInit {
    public _Operationtitle: string = "Add";

    public _EmploymentTypes: {
        EmployementType: '',
        ID: '',
        IsActive: '',
    };

    public _EmploymentObj: {
        EmployementType: '',
        ID: '',
        IsActive: '',
    };

    constructor(public router: Router, private _LocalStorageService: LocalStorageService, private _MastersService: MastersService) { }

    ngOnInit() {
        this._MastersService.GetEmploymentTypes().subscribe(res => this.GetEmploymentSuccess(res), res => this.GetEmploymentError(res));
        this._EmploymentObj = {
            EmployementType: '',
            ID: '',
            IsActive: '',
        };
    }
    GetEmploymentSuccess(res) {
        if (res._body != null || res._body != undefined || res._body.toString().trim().length > 0) {
            this._EmploymentTypes = JSON.parse(res._body);
        }
    }
    GetEmploymentError(res) { }

    SwitchStatus(ID) {
        debugger;
        this._MastersService.SwitchEmploymentEntityStatus(ID).subscribe(res => this.SwitchEmploymentSuccess(res), res => this.SwitchEmploymentError(res));
    }
    SwitchEmploymentSuccess(res) { this._MastersService.GetEmploymentTypes().subscribe(res => this.GetEmploymentSuccess(res), res => this.GetEmploymentError(res)); }
    SwitchEmploymentError(res) { }

    GridSelectionChange(data, event) {
        this._Operationtitle = "Update";
        Object.assign(this._EmploymentObj, this._EmploymentTypes[event.index]);
       // this._EmploymentObj = data.data.data[selection.index]
    }

    UpdateEmployementType() {
        debugger;
        this._MastersService.UpdateEmploymentEntity(this._EmploymentObj).subscribe(res => this.UpdateEmploymentSuccess(res), res => this.UpdateEmploymentError(res));
    }

    UpdateEmploymentSuccess(res) {
        this._MastersService.GetEmploymentTypes().subscribe(res => this.GetEmploymentSuccess(res), res => this.GetEmploymentError(res));
        this.CancelEmployementType();
    }
    UpdateEmploymentError(res) { }
    CancelEmployementType() {
        debugger;
        this._Operationtitle = "Add";
        this._EmploymentObj = {
            EmployementType: '',
            ID: '',
            IsActive: '',
        };
    }

    AddEmployementType() {
        debugger;
        this._MastersService.AddEmploymentEntity(this._EmploymentObj).subscribe(res => this.AddEmployementSuccess(res), res => this.AddEmployementError(res));
    }
    AddEmployementSuccess(res) {
        this._MastersService.GetEmploymentTypes().subscribe(res => this.GetEmploymentSuccess(res), res => this.GetEmploymentError(res));
        this.CancelEmployementType();
    }
    AddEmployementError(res) { }
}
