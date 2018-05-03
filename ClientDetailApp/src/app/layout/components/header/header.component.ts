import { Router, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Component, Injectable, ViewChild, OnInit  } from '@angular/core';
import { Form, FormControl, Validators  } from '@angular/forms';
import 'rxjs/Rx';
import { LocalStorageService } from 'angular-2-local-storage';
import { environment } from '../../../../environments/environment';
import { UserOperationService } from '../../../services/app.userops.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss'],
    providers: [UserOperationService]
})
export class HeaderComponent implements OnInit {
    pushRightClass: string = 'push-right';
    public _UserName: string = '';
    public URL: any;
    public _UserDetails = {
        AccountExpired: '',
        AccountLocked: '',
        ActivaitonCode: '',
        CreatedBy: '',
        CreatedOn: '',
        Description: '',
        DisplayName: '',
        Email: '',
        FailedPasswordAttempts: '',
        FirstName: '',
        IsActive: '',
        LastLoggedOn: '',
        LastName: '',
        LastPasswordChangedOn: '',
        LocationId: '',
        LoginID: '',
        Mobile: '',
        ModifiedBy: '',
        ModifiedOn: '',
        Password: '',
        PasswordExpired: '',
        PasswordResetToken: '',
        Role: '',
        UserGuid: '',
        UserId: '',
        ApplicantImage: '',
        FileType: '',
        FileName: '',
        Extension: ''
    }

   
    constructor(private translate: TranslateService, public router: Router, private _LocalStorageService: LocalStorageService,
        private _UserOperationService: UserOperationService) {
        this.translate.addLangs(['en', 'fr', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
        this.translate.setDefaultLang('en');
        const browserLang = this.translate.getBrowserLang();
        this.translate.use(browserLang.match(/en|fr|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');

        this.router.events.subscribe(val => {
            if (
                val instanceof NavigationEnd &&
                window.innerWidth <= 992 &&
                this.isToggled()
            ) {
                this.toggleSidebar();
            }
        });
    }

    ngOnInit() {
        this.UserInfo();
    }

    UserInfo() {
        if (this._LocalStorageService.get('LoggedInEmailId') != undefined && this._LocalStorageService.get('LoggedInEmailId') != null) {
            this.URL = this._UserDetails.ApplicantImage;
            this._UserOperationService.GetLoggedInUserInfo(<string>this._LocalStorageService.get('LoggedInEmailId'))
                .subscribe(result => this.UserInfoSuccess(result), result => this.UserInfoError(result));
        }
    }


    UserInfoSuccess(result) {
        debugger;
        this._UserName = JSON.parse(JSON.parse(result._body)).FirstName + " " + JSON.parse(JSON.parse(result._body)).LastName;
        this._UserDetails = JSON.parse((JSON.parse(result._body)));
        this.URL = this.GetOriginalContentForPriview(this._UserDetails.FileType) + this._UserDetails.ApplicantImage;
    }

    GetOriginalContentForPriview(FileType) {
        debugger;
        if (FileType == "text/plain")
            return 'data:text/plain;base64,';
        if (FileType == 'application/pdf')
            return 'data:application/pdf;base64,';
        if (FileType == "image/png")
            return 'data:image/png;base64,';
        if (FileType == "image/jpeg")
            return 'data:image/jpeg;base64,';
        if (FileType == 'image/gif')
            return 'data:image/gif;base64,';
    }

    UserInfoError(err) {
    }

    isToggled(): boolean {
        const dom: Element = document.querySelector('body');
        return dom.classList.contains(this.pushRightClass);
    }

    toggleSidebar() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle(this.pushRightClass);
    }

    rltAndLtr() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle('rtl');
    }

    onLoggedout() {
        localStorage.removeItem('isLoggedin');
    }

    changeLang(language: string) {
        this.translate.use(language);
    }
}
