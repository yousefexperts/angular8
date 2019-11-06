import { Component, ViewChild, ViewEncapsulation, Injectable, OnInit } from "@angular/core";
import { FormBuilder, Validators, FormControl } from "@angular/forms";
import { AddItemService } from "src/app/services/item.service";
import { ItemModel } from "../../../models/Item.model";
import { jqxValidatorComponent } from "jqwidgets-framework/jqwidgets-ng/jqxvalidator";
import { jqxDateTimeInputComponent } from "jqwidgets-framework/jqwidgets-ng/jqxdatetimeinput";
import { jqxInputComponent } from "jqwidgets-framework/jqwidgets-ng/jqxinput";
import { jqxTreeComponent } from 'jqwidgets-ng/jqxtree';
import { jqxNotificationComponent } from 'jqwidgets-ng/jqxnotification';
import { jqxButtonComponent } from 'jqwidgets-ng/jqxbuttons';
import { Router, ActivatedRoute } from "@angular/router";
import { AppTokenService } from "src/app/core/services/token.service";
import { CatogryListService } from "src/app/services/catogry.service";
import { jqxDropDownListComponent } from 'jqwidgets-framework/jqwidgets-ng/jqxdropdownlist';
import { HttpClient } from "@angular/common/http";
import { Subscription } from "rxjs";
import { map, tap } from "rxjs/operators";
@Component({ selector: "app-edit", templateUrl: "./edit.component.html", encapsulation: ViewEncapsulation.None })
@Injectable({ providedIn: "root" })
export class AppEditComponent implements OnInit {
    myValidator: jqxValidatorComponent;
    passwordInput: jqxInputComponent;
    catogries: CatogryListService;
    source: string[] = [];
    @ViewChild('submitButton', { static: false }) submitButton: jqxButtonComponent;
    @ViewChild('msgNotification', { static: false }) msgNotification: jqxNotificationComponent;
    @ViewChild('treeReference', { static: false }) tree: jqxTreeComponent;
    @ViewChild('validateform', { static: false }) validateform: jqxValidatorComponent;
    @ViewChild('dateTimeInput', { static: false }) dateTimeInput: jqxDateTimeInputComponent;
    @ViewChild('ItemName', { static: false }) ItemNameText: jqxInputComponent;
    @ViewChild('MaxNum', { static: false }) MaxNum: jqxInputComponent;
    @ViewChild('MinNum', { static: false }) MinNum: jqxInputComponent;
    @ViewChild('CatogryId', { static: false }) CatogryId: jqxInputComponent;
    @ViewChild('IsExist', { static: false }) IsExist: jqxInputComponent;
    @ViewChild("comboBoxReference", { static: false }) comboBoxReference: jqxDropDownListComponent;
    itemModel: ItemModel;
    Catogries: any;
    Description: any;
    CatogrySelected: any;
    subscription: Subscription;
    findBy: Subscription;
    item: any;
    CatogryInit: any
    Id: any;
    selectedIndex: any;
    inputDescription: any;
    inputMinNum: any;
    inputMaxNum: any;
    inputItemName: any;
    InputIsExist: any;
    InputCreateDate: any;
    setId(id: any) {
        this.Id = id;
    }
    ngOnInit() {
        this.fillCatogries();
        this.route.params.subscribe(params => { this.findByItem(params['id']); this.setId(params['id']); })

    }
    form = this.formBuilder.group({
        ItemName: new FormControl("ItemName", Validators.required),
        Description: new FormControl("Description", Validators.required),
        MaxNum: new FormControl("MaxNum", Validators.required),
        MinNum: new FormControl("MinNum", Validators.required),
        IsExist: new FormControl("IsExist", Validators.required),
        CreateDate: new FormControl("dateTimeInput", Validators.required)
    });
    initialDate: Date = new Date(2017, 8, 1);
    sendButton(): void {
        this.myValidator.validate(document.getElementById("validateform"));
        this.onSubmit();
    }
    treeSource: any[] =
        [
            {
                icon: "assets/jqwidgets/styles/images/mail.png", label: "Mail", expanded: true,
                items:
                    [
                        { icon: "assets/jqwidgets/styles/images/icon-calendar-light.png", label: "Calendar" },
                        { icon: "assets/jqwidgets/styles/images/icon-edit.png", label: "Contacts", selected: true }
                    ]
            },
            {
                icon: "assets/jqwidgets/styles/images/hrparent.png", label: "HR", expanded: true,
                items:
                    [
                        { icon: "assets/jqwidgets/styles/images/pdf.jpg", label: "Report" },
                        { icon: "assets/jqwidgets/styles/images/add.jpg", label: "Corporate" },
                        { icon: "assets/jqwidgets/styles/images/charts.png", label: "Finance" },
                        { icon: "assets/jqwidgets/styles/images/search.png", label: "Search" }
                    ]
            }
        ];

    rules =
        [
            { input: "#ItemName", message: "ItemName is required!", action: "keyup, blur", rule: "required" },
            { input: "#Description", message: "Your Description must be between 3 and 255 characters!", action: "keyup, blur", rule: "length=3,255" },
            { input: "#MaxNum", message: "MaxNum is required!", action: "keyup, blur", rule: "required" },
            { input: "#MinNum", message: "MinNum is Required!", action: "keyup, blur", rule: "required" },
            { input: "#CatogryId", message: "CatogryId is Required!", action: "keyup, blur", rule: "required" },
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
    constructor(private readonly formBuilder: FormBuilder, private readonly appUserService: AddItemService, private readonly router: Router, private readonly appTokenService: AppTokenService, private readonly http: HttpClient, private route: ActivatedRoute) { }
    onSubmit() {
        this.Description = (document.getElementById("Description") as HTMLInputElement).value;
        this.itemModel = { ItemName: this.ItemNameText.val(), Description: this.Description, MaxNum: this.MaxNum.val(), MinNum: this.MinNum.val(), CreateDate: this.dateTimeInput.val(), IsExist: this.IsExist.val(), CatogryId: this.CatogrySelected };
        this.appUserService.updateItem(this.itemModel, this.Id);
        this.onClickOpenMessageNotification();
        /*this.naviagte();*/
    }

    naviagte() {
        this.appTokenService.set(this.appTokenService.get());
        this.router.navigate(["main/search"]);
    }

    list(value: any): void {
        var request = JSON.stringify(value);
        var handler = JSON.parse(request);
        let src: string[] = [];
        $.each(handler, function (index, value) {
            src.push(value);
            console.log(value);
            console.log(index);
        });
        this.source = src;
    }

    onCheckChange() {
        this.naviagte();
    }
    treeSettings: jqwidgets.TreeOptions =
        {
            width: "100%",
            height: "100%",
            source: this.treeSource
        }
    notificationSettings: jqwidgets.NotificationOptions =
        {
            width: 500, position: "center", opacity: 0.9, showCloseButton: true, appendContainer: "validateform",
            autoOpen: true, animationOpenDelay: 800, closeOnClick: true,
            template: "success"
        };

    settings: jqwidgets.ComboBoxOptions =
        {
            source: this.source,
            width: 350,
            height: 25
        }

    DropDownList() {
        return this.source;
    }

    findByItem(Id: any): void {
        this.findBy = this.http.get<ItemModel>(`Items/FindBy/${Id}`).pipe(
            map(response => response),
            tap(data => console.log("Item array", data))
        ).subscribe((data: any) => {
            var req = JSON.stringify(data);
            var response = JSON.parse(req);
            var itemName;
            var minNum;
            var catogryId: any;
            var isExist: boolean;
            
            var maxNum;
            var description;
            var createDate;
            this.itemModel = new ItemModel();
            $.each(response, function (key, value) {

                if (key == "itemName") {
                    itemName = value;
                }
                else if (key == "minNum") {
                    minNum = value;
                } else if (key == "maxNum") {
                    maxNum = value;
                }
                else if (key == "description") {
                    description = value;
                } else if (key == "catogryId") {
                    catogryId = value;
                }
                else if (key == "isExist") {
                    if (value == true)
                        isExist = true;
                    else {
                        isExist = false;
                    }
                }
                if (key == "createDate") {
                    createDate = value;
                }
                console.log("Value : " + value);
            })
            
            this.CatogryInit = catogryId;
            this.itemModel.CatogryId = catogryId;
            this.itemModel.CreateDate = createDate;
            this.itemModel.Description = description;
            this.itemModel.ItemName = itemName;
            this.itemModel.MaxNum = maxNum;
            this.itemModel.MinNum = minNum;
            this.itemModel.IsExist = isExist;
            this.show(this.itemModel);
        });
    }
    index() {
        return this.source.indexOf(this.itemModel.CatogryId);
    }

    chcecked(): boolean {
        return this.InputIsExist;
    }

    show(item: ItemModel) {
        this.inputDescription = item.Description;
        this.inputItemName = item.ItemName;
        this.inputMaxNum = item.MaxNum;
        this.inputMinNum = item.MinNum;
        this.InputIsExist = item.IsExist;
        this.InputCreateDate = item.CreateDate;
        this.selectedIndex = this.source.indexOf(this.itemModel.CatogryId);
    }
    
    selectValue(event: any) {
        //findByItem();
        var args = event.args;
        var index = args.index;
        var item = args.item;
        var value = item.value;
        this.CatogrySelected = value;
        this.selectedIndex = index;
        console.log(index + " " + value);
    }

    fillCatogries(): void {
        this.subscription = this.http.get<string>(`Catogries/List`).pipe(
            map(response => response),
            tap(data => console.log("Item array", data))
        ).subscribe(data => {
            this.Catogries = data;
            this.list(this.Catogries);
        });
    }
}
