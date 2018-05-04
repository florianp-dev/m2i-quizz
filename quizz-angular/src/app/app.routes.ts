import {Routes} from '@angular/router';
import {QuestionsComponent} from './components/questions/questions.component';

export const ROUTES: Routes = [
  { path: 'quizz/question/:id', pathMatch: 'full', component: QuestionsComponent }
];
