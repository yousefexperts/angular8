import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SearchHomeComponent } from "./search.component";
import { jqxDateTimeInputModule } from "jqwidgets-framework/jqwidgets-ng/jqxdatetimeinput";
import { jqxValidatorModule } from "jqwidgets-framework/jqwidgets-ng/jqxvalidator";
import { jqxButtonModule } from 'jqwidgets-framework/jqwidgets-ng/jqxbuttons';
import { jqxCheckBoxModule } from 'jqwidgets-framework/jqwidgets-ng/jqxcheckbox';
import { jqxExpanderModule } from 'jqwidgets-framework/jqwidgets-ng/jqxexpander';
import { jqxInputModule } from 'jqwidgets-framework/jqwidgets-ng/jqxinput';
import { jqxTreeModule } from 'jqwidgets-framework/jqwidgets-ng/jqxtree';
import { jqxNotificationModule } from 'jqwidgets-framework/jqwidgets-ng/jqxnotification';
import { jqxDropDownButtonModule } from 'jqwidgets-ng/jqxdropdownbutton';
import { jqxDataTableModule } from 'jqwidgets-framework/jqwidgets-ng/jqxdatatable';
const routes: Routes = [
    { path: "", component: SearchHomeComponent }
];

@NgModule({
    declarations: [SearchHomeComponent],
    imports: [
        jqxDateTimeInputModule, jqxValidatorModule, jqxValidatorModule, jqxButtonModule, jqxCheckBoxModule,
        jqxDateTimeInputModule, jqxExpanderModule, jqxInputModule, jqxTreeModule, jqxNotificationModule, jqxDropDownButtonModule, jqxDataTableModule,
        RouterModule.forChild(routes)
    ]
})
export class AppSearchModule { }
