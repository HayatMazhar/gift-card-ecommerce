import { RouterModule, Routes } from '@angular/router';

const routes : Routes = [

  {
    path: "",
    loadChildren: () =>
      import("./_pages/website/website.module").then((m) => m.WebsiteModule),
  },

  // 404 Not found
  { path: "**", redirectTo: "/error/error404" },
];
export const routing = RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'});
