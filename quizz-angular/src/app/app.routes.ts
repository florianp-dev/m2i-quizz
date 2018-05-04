import {Routes} from '@angular/router';
import {QuizzComponent} from './components/quizz/quizz.component';

export const ROUTES: Routes = [
  { path: 'quizz/question/:id', pathMatch: 'full', component: QuizzComponent }
];
