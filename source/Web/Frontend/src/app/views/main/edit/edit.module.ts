import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppEditComponent } from "./edit.component";
import { jqxDateTimeInputModule } from "jqwidgets-framework/jqwidgets-ng/jqxdatetimeinput";
import { jqxValidatorModule } from "jqwidgets-framework/jqwidgets-ng/jqxvalidator";
import { jqxButtonModule } from 'jqwidgets-framework/jqwidgets-ng/jqxbuttons';
import { jqxCheckBoxModule } from 'jqwidgets-framework/jqwidgets-ng/jqxcheckbox';
import { jqxExpanderModule } from 'jqwidgets-framework/jqwidgets-ng/jqxexpander';
import { jqxInputModule } from 'jqwidgets-framework/jqwidgets-ng/jqxinput';
import { jqxTreeModule } from 'jqwidgets-framework/jqwidgets-ng/jqxtree';
import { jqxNotificationModule } from 'jqwidgets-framework/jqwidgets-ng/jqxnotification';
import { jqxDropDownButtonModule } from 'jqwidgets-ng/jqxdropdownbutton';
import { jqxDropDownListModule } from 'jqwidgets-framework/jqwidgets-ng/jqxdropdownlist';
import { jqxComboBoxModule } from 'jqwidgets-framework/jqwidgets-ng/jqxcombobox';
const routes: Routes = [
    { path: "", component: AppEditComponent }
];

@NgModule({
    declarations: [AppEditComponent],
    imports: [
        jqxDateTimeInputModule, jqxValidatorModule, jqxValidatorModule, jqxButtonModule, jqxCheckBoxModule, jqxComboBoxModule ,
        jqxDateTimeInputModule, jqxExpanderModule, jqxInputModule, jqxTreeModule, jqxNotificationModule, jqxDropDownButtonModule, jqxDropDownListModule,
        RouterModule.forChild(routes)
    ]
})
export class AppEditModule { }
