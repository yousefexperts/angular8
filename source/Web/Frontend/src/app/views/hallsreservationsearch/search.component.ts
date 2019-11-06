import { Component, ViewChild, ViewEncapsulation, AfterViewInit } from "@angular/core";
import { FormBuilder, Validators, FormControl } from "@angular/forms";
import { AddItemService } from "src/app/services/item.service";
import { ItemModel } from "src/app/models/Item.model";
import { jqxValidatorComponent } from "jqwidgets-framework/jqwidgets-ng/jqxvalidator";
import { jqxInputComponent } from "jqwidgets-framework/jqwidgets-ng/jqxinput";
import { jqxNotificationComponent } from "jqwidgets-ng/jqxnotification";
import { jqxButtonComponent } from "jqwidgets-ng/jqxbuttons";
import { jqxDateTimeInputComponent } from "jqwidgets-framework/jqwidgets-ng/jqxdatetimeinput";
import { jqxDataTableComponent } from "jqwidgets-framework/jqwidgets-ng/jqxdatatable";
import { AppEditComponent } from "src/app/views/main/edit/edit.component";
import { isEmpty } from "rxjs/operators";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";
import { AppTokenService } from "../../core/services/token.service";
@Component({ selector: "app-search", templateUrl: "./search.component.html", encapsulation: ViewEncapsulation.None })
export class SearchHomeComponent implements AfterViewInit {
    myValidator: jqxValidatorComponent;
    passwordInput: jqxInputComponent;
    @ViewChild("submitButton", { static: false }) submitButton: jqxButtonComponent;
    @ViewChild("msgNotification", { static: false }) msgNotification: jqxNotificationComponent;
    @ViewChild("validateform", { static: false }) validateform: jqxValidatorComponent;
    @ViewChild("dateTimeInput", { static: false }) dateTimeInput: jqxDateTimeInputComponent;
    @ViewChild('ItemsDataTable', { static: false }) ItemsDataTable: jqxDataTableComponent;
    that = this;
    out = false;
    selector: AppEditComponent;
    subscription: Subscription;
    rowIndex: number;
    Id: any;
    itemModelShow: ItemModel;

    source =
        {
            datatype: "json",
            datafields: [
                { name: "ItemName", type: "string" },
                { name: "CreateDate", type: "string" },
                { name: "Description", type: "string" },
                { name: "IsExist", type: "bool" },
                { name: "MaxNum", type: "string" },
                { name: "MinNum", type: "string" },
                { name: "CatogryId", type: "string" }

            ],
            addRow: function (_rowID: any, _rowData: any, _position: any, _commit: any) {
                _commit(true);
            },
            updateRow: function (_rowID: any, _rowData: any, _commit: any) {
                _commit(true);
            },
            deleteRow: function (_rowID: any, _commit: any) {
                _commit(true);
            },
            sortcolumn: 'ItemName',
            sortdirection: 'asc',
            id: 'ItemId',
            url: "Items/List"
        };
    dataAdapter = new $.jqx.dataAdapter(this.source);
    getWidth(): any {
        return window.innerWidth - 120;
    }
    columns: any[] =
        [
            { text: 'ItemName', datafield: 'ItemName' },
            { text: 'CreateDate', datafield: 'CreateDate' },
            { text: 'Description', datafield: 'Description' },
            { text: 'IsExist', datafield: 'IsExist' },
            { text: 'MaxNum', datafield: 'MaxNum' },
            { text: 'MinNum', datafield: 'MinNum' },
            { text: 'CatogryId', datafield: 'CatogryId' },
        ];
    columngroups: any[] =
        [
            { text: "Inventory", align: "center", name: "Inventory" }
        ];
    excelExport(): void {
        this.ItemsDataTable.exportData('xls');
    };
    xmlExport(): void {
        this.ItemsDataTable.exportData('xml');
    };
    csvExport(): void {
        this.ItemsDataTable.exportData('csv');
    };
    tsvExport(): void {
        this.ItemsDataTable.exportData('tsv');
    };
    htmlExport(): void {
        this.ItemsDataTable.exportData('html');
    };
    deleteRow(): void {

    };
    updateRow(event: any): void {
        let args = event.args;
        // row index
        let index = args.index;
        // row data
        let rowData = args.row;
        // row key
        let rowKey = args.key;
        this.Id = rowKey;
        console.log(index +" " + rowData+" " + rowKey);
    }
    deleteSelectRow(): void {

    }
    delete() {

    }
    update() {
        if (this.Id == null || this.Id == isEmpty) {
            this.onClickOpenMessageNotification();
            return;
        }
        this.appTokenService.set(this.appTokenService.get());

        this.router.navigate([`main/edit/`, this.Id]);
        /*this.subscription = this.http.get<ItemModel>(`Items/FindBySync/${this.Id}`).pipe(
            map(response => response),
            tap(data => console.log("Item array", data))).subscribe((data: ItemModel) => { this.itemModelShow = data; this.show(this.itemModelShow);});*/
    }

    updateSelectRow(): void {

    }
    jsonExport(): void {
        this.ItemsDataTable.exportData('json');
    };
    pdfExport(): void {
        this.ItemsDataTable.exportData('pdf');
    };
    ngAfterViewInit(): void {

        this.msgNotification.createComponent(this.notificationSettings);
    }

    itemModel: ItemModel;
    Description: any;
    item: any;
    form = this.formBuilder.group({
        CreateDate: new FormControl("dateTimeInput", Validators.required)
    });
    initialDate: Date = new Date(2017, 8, 1);
    sendButton(): void {
        this.myValidator.validate(document.getElementById("validateform"));
        this.onSubmit();
    }
    rules =
        [
            {
                input: "#dateTimeInput", message: "Your birth date must be between 1/1/1900 and 1/1/2050.", action: "valueChanged",
                rule: (_input: any, _commit: any): any => {
                    let date = this.dateTimeInput.value();
                    let result = date.getFullYear() >= 2000 && date.getFullYear() <= 2050;
                    return result;
                }
            }
        ];
    onClickOpenMessageNotification(): void {
        this.msgNotification.open();
    }
    constructor(private readonly formBuilder: FormBuilder, private readonly appUserService: AddItemService, private readonly router: Router, private readonly appTokenService: AppTokenService) { }
    onSubmit() {
        //this.Description = (document.getElementById("Description") as HTMLInputElement).value;
        //this.itemModel = { ItemName: this.ItemNameText.val(), Description: this.Description, MaxNum: this.MaxNum.val(), MinNum: this.MinNum.val(), CreateDate: this.dateTimeInput.val(), IsExist: this.IsExist.val(), CatogryId: this.CatogryId.val() };
        this.appUserService.addItem(this.itemModel);
        this.onClickOpenMessageNotification();
    }
    notificationSettings: jqwidgets.NotificationOptions =
        {
            width: 500, position: "center", opacity: 0.9, showCloseButton: true, appendContainer: "validateform",
            autoOpen: true, animationOpenDelay: 800, closeOnClick: true,
            template: "success"
        };
}
