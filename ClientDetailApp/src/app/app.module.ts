import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import 'hammerjs';
import { LocalStorageModule, ILocalStorageServiceConfig } from 'angular-2-local-storage';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared';
import {LoanApplicationDetailDialog} from './shared/dialogues/loanapplications/LoanApplicationDetailDialog';
import {ClientDetailsDialog} from './shared/dialogues/clients/ClientDetailsDialog';
import {PersonalDetailsComponent} from './layout/communication/components/app.personaldetails';
import {EmployementComponent} from './layout/communication/components/app.employementdetails';
import { QualificationDetailsComponent } from './layout/communication/components/app.qualificationdetails';

import {MaterialModule} from './shared/app.material';
import { CommunicationDialog } from './layout/communication/communicationDialog/communicationDialog';
// AoT requires an exported function for factories
export function createTranslateLoader(http: HttpClient) {
    // for development
    //return new TranslateHttpLoader(http, '/start-angular/SB-Admin-BS4-Angular-5/master/dist/assets/i18n/', '.json');
    return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
    imports: [
        MaterialModule,
        FormsModule,
        HttpModule,
        CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: createTranslateLoader,
                deps: [HttpClient]
            }
        }),
        AppRoutingModule,
        ReactiveFormsModule,
        LocalStorageModule.withConfig({
            prefix: 'AIMFinServ',
            storageType: 'localStorage'
        })
    ],
    declarations: [AppComponent,
        LoanApplicationDetailDialog,
        PersonalDetailsComponent,
        EmployementComponent,
        QualificationDetailsComponent,
        ClientDetailsDialog,
        CommunicationDialog],

    providers: [AuthGuard],
    bootstrap: [AppComponent],
    entryComponents: [LoanApplicationDetailDialog, ClientDetailsDialog, CommunicationDialog]
})
export class AppModule { }