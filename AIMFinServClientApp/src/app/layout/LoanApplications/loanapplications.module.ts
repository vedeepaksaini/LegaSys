import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { LoanapplicationsRoutingModule } from './loanapplications-routing.module';
import { LoanapplicationsComponent } from './loanapplications.component';
import { PageHeaderModule } from '../../shared';
import { MaterialModule } from '../../shared/app.material';
import { AddLoanApplicationComponent } from './addloanapplication.component';
import { LoanapplicationdetailsComponent } from './loanapplicationdetails.component';

import { FormsModule } from '@angular/forms';
@NgModule({
    imports: [CommonModule, LoanapplicationsRoutingModule, PageHeaderModule, GridModule, MaterialModule, FormsModule],
    declarations: [LoanapplicationsComponent, AddLoanApplicationComponent, LoanapplicationdetailsComponent]
})
export class LoanapplicationsModule { }
