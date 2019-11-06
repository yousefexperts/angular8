import { Routes, RouterModule } from "@angular/router";
import { AppRouteGuard } from "./core/guards/route.guard";
import { AppLayoutMainComponent } from "./layouts/layout-main/layout-main.component";
import { AppLayoutComponent } from "./layouts/layout/layout.component";
import { AppCustomPreloader } from "./AppCustomPreloader";
import { NgModule } from "@angular/core";

export const ROUTES: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            {
                path: "",
                loadChildren: () => import("./views/login/login.module").then((x) => x.AppLoginModule)
            }
        ]
    },
    {
        path: "main",
        component: AppLayoutMainComponent,
        canActivate: [AppRouteGuard],
        children: [
            {
                path: "files",
                loadChildren: () => import("./views/main/files/files.module").then((x) => x.AppFilesModule)
            },
            {
                path: "form",
                loadChildren: () => import("./views/main/form/form.module").then((x) => x.AppFormModule)
            },
            {
                path: "home",
                loadChildren: () => import("./views/main/home/home.module").then((x) => x.AppHomeModule)
            },
            {
                path: "list",
                loadChildren: () => import("./views/main/list/list.module").then((x) => x.AppListModule)
            },
            {
                path: "rxjs",
                loadChildren: () => import("./views/main/rxjs/rxjs.module").then((x) => x.AppRxjsModule)
            },
            {
                path: "search",
                loadChildren: () => import("./views/search/search.module").then((x) => x.AppSearchModule)
            }
            ,
            {
                path: "edit/:id",
                loadChildren: () => import("./views/main/edit/edit.module").then((x) => x.AppEditModule)
            }
            ,
            {
                path: "reservation/create",
                loadChildren: () => import("./views/main/hallreservations/hallreservations.module").then((x) => x.AppReservationsModule)
            }
        ]
    },
    { path: "**", redirectTo: "" }
];
@NgModule({
    imports: [RouterModule.forRoot(ROUTES, { preloadingStrategy: AppCustomPreloader })], //own custom preloader
    exports: [RouterModule],
    providers: [AppCustomPreloader]
})
export class AppRoutingModule { }
