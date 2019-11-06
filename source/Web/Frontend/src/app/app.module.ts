import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { ROUTES } from "./app.routes";
import { AppErrorHandler } from "./core/handlers/error.handler";
import { AppHttpInterceptor } from "./core/interceptors/http.interceptor";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppHomeComponent } from "src/app/views/main/home/home.component";
import { jqxDateTimeInputModule } from 'jqwidgets-framework/jqwidgets-ng/jqxdatetimeinput';
import { NgxLoadingModule } from "ngx-loading";
@NgModule({
    bootstrap: [AppComponent, AppHomeComponent],
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        NgxLoadingModule.forRoot({}),
        FormsModule, jqxDateTimeInputModule,
        RouterModule.forRoot(ROUTES)
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
    ]
})
export class AppModule { }
