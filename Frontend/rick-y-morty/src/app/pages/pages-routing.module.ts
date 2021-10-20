import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EpisodioComponent } from './episodio/episodio.component';
import { PagesComponent } from './pages.component';
import { paginas } from './pages.routes.names';

const routes: Routes = [
  {
    path: '',
    component: EpisodioComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('../pages/episodio/episodio.module').then(
            (m) => m.EpisodioModule
          ),
      },
    ],
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class PagesRoutingModule {}
