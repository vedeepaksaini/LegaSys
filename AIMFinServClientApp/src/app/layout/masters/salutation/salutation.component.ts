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
    templateUrl: './salutation.component.html',
    animations: [routerTransition()],
    providers: [MastersService]
})

export class SalutationComponent implements OnInit {
    public _SalutationTypes: {
        ID: "",
        IsActive: "",
        Salutation: ""
    };

    public _SalutationObj: {
        ID: "",
        IsActive: "",
        Salutation: ""
    };

    public _Operationtitle: string = "Add";

    constructor(public router: Router, private _LocalStorageService: LocalStorageService, private _MastersService: MastersService) { }

    ngOnInit() {
        this._MastersService.GetSalutationTypes().subscribe(res => this.GetSalutationSuccess(res), res => this.GetSalutationError(res));
        this._SalutationObj = {
            ID: "",
            IsActive: "",
            Salutation: ""
        };
    }
    GetSalutationSuccess(res) {
        if (res._body != null || res._body != undefined || res._body.toString().trim().length > 0) {
            debugger;
            this._SalutationTypes = JSON.parse(res._body);
        }

    }
    GetSalutationError(res) { }

    SwitchStatus(ID) {
        debugger;
        this._MastersService.SwitchSalutationEntityStatus(ID).subscribe(res => this.SwitchSalutationSuccess(res), res => this.SwitchSalutationError(res));
    }
    SwitchSalutationSuccess(res) { this._MastersService.GetSalutationTypes().subscribe(res => this.GetSalutationSuccess(res), res => this.GetSalutationError(res)); }
    SwitchSalutationError(res) { }

    GridSelectionChange(data, event) {
        debugger;
       // this._SalutationObj = data.data.data[selection.index];
        Object.assign(this._SalutationObj, this._SalutationTypes[event.index]);
        this._Operationtitle = "Update";
    }

    UpdateSalutationType() {
        this._MastersService.UpdateSalutationEntity(this._SalutationObj).subscribe(res => this.UpdateSalutationSuccess(res), res => this.UpdateSalutationError(res));
    }

    UpdateSalutationSuccess(res) {
        this._MastersService.GetSalutationTypes().subscribe(res => this.GetSalutationSuccess(res), res => this.GetSalutationError(res));
        this.CancelSalutationType();
    }
    UpdateSalutationError(res) { }


    CancelSalutationType() {
        debugger;
        this._Operationtitle = "Add";
        this._SalutationObj = {
            ID: "",
            IsActive: "",
            Salutation: ""
        };
    }


    AddSalutationType() {
        debugger;
        this._MastersService.AddSalutationEntity(this._SalutationObj).subscribe(res => this.AddSalutationTypeSuccess(res), res => this.AddSalutationTypeError(res));
    }
    AddSalutationTypeSuccess(res) {
        this._MastersService.GetSalutationTypes().subscribe(res => this.GetSalutationSuccess(res), res => this.GetSalutationError(res));
        this.CancelSalutationType();
    }
    AddSalutationTypeError(res) { }
}
